// Global chart registry
window._plotPieRegistry = {};

window.plotPieChart = (elementId, labels, values, colors, dotNetHelper) => {
    const total = values.reduce((a, b) => a + b, 0);

    const customText = values.map((v, i) => {
        const percent = ((v / total) * 100).toFixed(1);
        return `${v}<br>(${percent}%)`;
    });

    const layout = {
        showlegend: false,
        autosize: true,
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

    function drawChart() {
        const data = [{
            values: values,
            labels: labels,
            type: 'pie',
            hole: 0.6,
            marker: { colors: colors },
            text: customText,
            textinfo: "text",
            hoverinfo: "label+value+percent",
            textposition: "outside",
            insidetextorientation: "radial",
            textfont: {
                size: 16,
                family: "Arial",
                color: "black"
            }
        }];

        Plotly.react(elementId, data, layout, config);
    }

    drawChart();

    const chartDiv = document.getElementById(elementId);
    let sliceClicked = false;

    if (chartDiv && !chartDiv.hasClickHandler) {

        // Register reset function globally
        window._plotPieRegistry[elementId] = () => {
            drawChart();
        };

        chartDiv.on('plotly_click', function (data) {
            sliceClicked = true;

            // Reset all other charts
            for (let id in window._plotPieRegistry) {
                if (id !== elementId) {
                    window._plotPieRegistry[id]();
                }
            }

            if (dotNetHelper) {
                const label = data.points[0].label;
                dotNetHelper.invokeMethodAsync('OnSliceClick', elementId + "|" + label);
            }
        });

        chartDiv.addEventListener('click', function () {
            if (!sliceClicked) {
                drawChart();
                if (dotNetHelper) {
                    dotNetHelper.invokeMethodAsync('ResetTableToSDM');
                }
            }
            sliceClicked = false;
        });

        document.addEventListener('click', function (event) {
            const clickedInside = chartDiv.contains(event.target);
            if (!clickedInside) {
                drawChart();
                if (dotNetHelper) {
                    dotNetHelper.invokeMethodAsync('ResetTableToSDM');
                }
            }
        });

        chartDiv.hasClickHandler = true;
    }
};
