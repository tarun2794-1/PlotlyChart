// Global chart registry to track all rendered pie charts for inter-chart coordination
window._plotPieRegistry = window._plotPieRegistry || {};

window.plotPieChart = (elementId, labels, values, colors, dotNetHelper) => {
    const total = values.reduce((a, b) => a + b, 0);
    let currentPull = new Array(values.length).fill(0);
    let clickedSliceIndex = -1;

    // Function to convert hex color to rgba with alpha transparency
    function hexToRgba(hex, alpha) {
        let c = hex.replace('#', '');
        if (c.length === 3) c = c.split('').map(ch => ch + ch).join('');
        const r = parseInt(c.substring(0, 2), 16);
        const g = parseInt(c.substring(2, 4), 16);
        const b = parseInt(c.substring(4, 6), 16);
        return `rgba(${r}, ${g}, ${b}, ${alpha})`;
    }

    // Function to render the pie chart
    function drawChart(pullArray, clickedIndex = -1) {
        const customText = values.map((v, i) => {
            const percent = ((v / total) * 100).toFixed(1);
            return `${v}<br>(${percent}%)`;
        });

        const textColors = colors.map((color, i) =>
            i === clickedIndex ? color : '#000'
        );
        const textFonts = values.map((_, i) =>
            i === clickedIndex ? 'Arial Black, Arial Bold, sans-serif' : 'Arial'
        );

        // Define slice outlines (glow effect)
        const lineWidths = values.map((_, i) => i === clickedIndex ? 8 : 0);
        const lineColors = colors.map((color, i) =>
            i === clickedIndex ? hexToRgba(color, 0.5) : 'transparent'
        );

        const data = [{
            values: values,
            labels: labels,
            type: 'pie',
            hole: 0.6,
            marker: {
                colors: colors,
                line: {
                    width: lineWidths,
                    color: lineColors
                }
            },
            text: customText,
            textinfo: "text",
            hoverinfo: "label+value+percent",
            hoverlabel: { 
                font: {
                    size: 16,  
                    family: "Arial Black, sans-serif" 
                }
            },
            textposition: "outside",
            insidetextorientation: "radial",
            textfont: {
                size: 14,
                color: textColors,
                family: textFonts
            },
            pull: pullArray
        }];

        const layout = {
            showlegend: false,
            autosize: true,
            paper_bgcolor: '#f7f7f7',
            plot_bgcolor: '#f7f7f7',
            margin: { t: 40, b: 40, l: 60, r: 60 },
            annotations: [{
                font: { size: 16 },
                showarrow: false,
                text: `Total Stores<br><b>${total}</b>`,
                x: 0.5,
                y: 0.5
            }]
        };

        const config = {
            responsive: true,
            displayModeBar: false
        };

        // Render chart and add center overlay for reset
        const chartDiv = document.getElementById(elementId);
        if (!chartDiv) {
            console.error("Chart container not found:", elementId);
            return;
        }

        Plotly.react(chartDiv, data, layout, config).then(() => {
            addCenterClickOverlay(elementId);
        });
    }

    // Draw the initial chart
    drawChart(currentPull, clickedSliceIndex);

    // Attach click event only once per chart
    const chartDiv = document.getElementById(elementId);
    if (chartDiv && !chartDiv.hasClickHandler) {
        // Register chart for coordinated reset
        window._plotPieRegistry[elementId] = {
            reset: () => {
                currentPull = new Array(values.length).fill(0);
                clickedSliceIndex = -1;
                drawChart(currentPull, clickedSliceIndex);
            },
            dotNetHelper: dotNetHelper
        };

        // Slice click handler
        chartDiv.on('plotly_click', function (data) {
            const clickedIndex = data.points[0].pointNumber;

            // Reset all other pie charts
            for (let id in window._plotPieRegistry) {
                if (id !== elementId) {
                    window._plotPieRegistry[id].reset();
                }
            }

            // Update pull array for selected slice
            currentPull = currentPull.map((v, i) => i === clickedIndex ? 0.05 : 0);
            clickedSliceIndex = clickedIndex;
            drawChart(currentPull, clickedSliceIndex);

            // Notify .NET handler of slice click
            if (dotNetHelper) {
                const label = data.points[0].label;
                dotNetHelper.invokeMethodAsync('OnSliceClick', `${elementId}|${label}`);
            }
        });

        chartDiv.hasClickHandler = true;
    }

    // Adds an invisible div at the center of the donut to handle reset click
    function addCenterClickOverlay(elementId) {
        const chartDiv = document.getElementById(elementId);
        if (!chartDiv) return;

        const oldOverlay = chartDiv.querySelector('.center-click-overlay');
        if (oldOverlay) oldOverlay.remove();

        const overlay = document.createElement('div');
        overlay.className = 'center-click-overlay';

        const diameter = Math.min(chartDiv.offsetWidth, chartDiv.offsetHeight) * 0.3;

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

        overlay.addEventListener('click', () => {
            for (let id in window._plotPieRegistry) {
                window._plotPieRegistry[id].reset();
            }

            const chartInfo = window._plotPieRegistry[elementId];
            if (chartInfo?.dotNetHelper) {
                chartInfo.dotNetHelper.invokeMethodAsync('ResetTableToSDM', elementId);
            }
        });

        chartDiv.style.position = 'relative';
        chartDiv.appendChild(overlay);
    }
};
