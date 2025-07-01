// Global chart registry to track all rendered pie charts
// Used for resetting others when one is clicked
window._plotPieRegistry = window._plotPieRegistry || {};

// Main function to render a donut (pie with hole) chart
window.plotPieChart = (elementId, labels, values, colors, dotNetHelper) => {
    // Calculate the total value to show in the center
    const total = values.reduce((a, b) => a + b, 0);

    // Create custom text for each slice: "value (percentage)"
    const customText = values.map((v, i) => {
        const percent = ((v / total) * 100).toFixed(1);
        return `${v}<br>(${percent}%)`;
    });

    // Plotly chart layout configuration
    const layout = {
        showlegend: false,
        autosize: true,
        paper_bgcolor: '#f7f7f7',
        plot_bgcolor: '#f7f7f7',
        margin: { t: 40, b: 40, l: 60, r: 60 },
        annotations: [{
            font: { size: 16 },
            showarrow: false,
            // Center text inside the donut hole
            text: `Total Stores<br><b>${total}</b>`,
            x: 0.5,
            y: 0.5
        }]
    };

    // Plotly config: responsive and hides toolbar
    const config = {
        responsive: true,
        displayModeBar: false
    };

    // Store current "pull" values (how far each slice is pulled)
    let currentPull = new Array(values.length).fill(0);

    // Function to draw (or redraw) the chart
    function drawChart(pullArray) {
        const data = [{
            values: values,
            labels: labels,
            type: 'pie',
            hole: 0.6, // 60% hole makes it a donut chart
            marker: { colors: colors },
            text: customText,
            textinfo: "text", // use the custom text
            hoverinfo: "label+value+percent",
            textposition: "outside",
            insidetextorientation: "radial",
            textfont: {
                size: 16,
                family: "Arial"
            },
            pull: pullArray // control which slice is pulled
        }];

        // Plot or update the chart
        Plotly.react(elementId, data, layout, config).then(() => {
            addCenterClickOverlay(elementId); // add click handler to the center
        });
    }

    // Initial draw of the chart
    drawChart(currentPull);

    // Get the div containing the chart
    const chartDiv = document.getElementById(elementId);
    let sliceClicked = false;

    // Ensure we don't double-bind events
    if (chartDiv && !chartDiv.hasClickHandler) {
        // Register reset function in the global registry
        window._plotPieRegistry[elementId] = {
            reset: () => {
                currentPull = new Array(values.length).fill(0); // unpull all
                drawChart(currentPull); // redraw
            },
            dotNetHelper: dotNetHelper // store .NET interop object
        };

        // When a slice is clicked
        chartDiv.on('plotly_click', function (data) {
            const clickedIndex = data.points[0].pointNumber;
            sliceClicked = true;

            // Reset all *other* pie charts (linked behavior)
            for (let id in window._plotPieRegistry) {
                if (id !== elementId) {
                    window._plotPieRegistry[id].reset();
                }
            }

            // Pull only the clicked slice (e.g., 4% offset)
            currentPull = currentPull.map((v, i) => i === clickedIndex ? 0.04 : 0);
            drawChart(currentPull); // redraw with pulled slice

            // Call .NET method to handle logic in Blazor (e.g., filter table)
            if (dotNetHelper) {
                const label = data.points[0].label;
                dotNetHelper.invokeMethodAsync('OnSliceClick', elementId + "|" + label);
            }
        });

        // Prevent re-binding
        chartDiv.hasClickHandler = true;
    }

    // Adds a transparent circular overlay in the center hole
    // Clicking it will reset the chart (i.e., unselect any slice)
    function addCenterClickOverlay(elementId) {
        const chartDiv = document.getElementById(elementId);
        if (!chartDiv) return;

        // Remove old overlay if it exists
        const oldOverlay = chartDiv.querySelector('.center-click-overlay');
        if (oldOverlay) oldOverlay.remove();

        // Create a transparent circular div
        const overlay = document.createElement('div');
        overlay.className = 'center-click-overlay';

        // Estimate size of center hole to position overlay correctly
        const diameter = Math.min(chartDiv.offsetWidth, chartDiv.offsetHeight) * 0.3;

        // Style the overlay to sit in the middle
        Object.assign(overlay.style, {
            position: 'absolute',
            width: `${diameter}px`,
            height: `${diameter}px`,
            top: `calc(50% - ${diameter / 2}px)`,
            left: `calc(50% - ${diameter / 2}px)`,
            borderRadius: '50%',
            zIndex: 10,
            cursor: 'pointer',
            backgroundColor: 'transparent'
        });

        // On center click: reset pull and invoke Blazor reset
        overlay.addEventListener('click', () => {
            // Reset all pie charts
            for (let id in window._plotPieRegistry) {
                window._plotPieRegistry[id].reset();
            }

            // Call .NET method only for the chart clicked
            const chartInfo = window._plotPieRegistry[elementId];
            if (chartInfo && chartInfo.dotNetHelper) {
                chartInfo.dotNetHelper.invokeMethodAsync('ResetTableToSDM', elementId);
            }
        });

        // Required for absolute positioning to work
        chartDiv.style.position = 'relative';

        // Add the overlay to the chart
        chartDiv.appendChild(overlay);
    }
};
