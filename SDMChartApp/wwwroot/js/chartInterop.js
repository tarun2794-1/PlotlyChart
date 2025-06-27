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

    let currentPull = new Array(values.length).fill(0);

    function drawChart(pullArray) {
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
                family: "Arial"
            },
            pull: pullArray
        }];

        Plotly.react(elementId, data, layout, config);
    }

    drawChart(currentPull);

    const chartDiv = document.getElementById(elementId);
    let sliceClicked = false;

    if (chartDiv && !chartDiv.hasClickHandler)
    {

        // Register reset function globally
        window._plotPieRegistry[elementId] = () => {
            currentPull = new Array(values.length).fill(0);
            drawChart(currentPull);
        };

        chartDiv.on('plotly_click', function (data)
        {
            const clickedIndex = data.points[0].pointNumber;
            sliceClicked = true;

            // Reset all other charts
            for (let id in window._plotPieRegistry)
            {
                if (id !== elementId)
                {
                    window._plotPieRegistry[id](); // call reset
                }
            }

            currentPull = currentPull.map((v, i) => i === clickedIndex ? 0.05 : 0);
            drawChart(currentPull);

            if (dotNetHelper)
            {
                const label = data.points[0].label;
                dotNetHelper.invokeMethodAsync('OnSliceClick', elementId + "|" + label);
            }
        });

        chartDiv.addEventListener('click', function () {
            if (!sliceClicked) {
                currentPull = new Array(values.length).fill(0);
                drawChart(currentPull);
                if (dotNetHelper) {
                    dotNetHelper.invokeMethodAsync('ResetTableToSDM');
                }
            }
            sliceClicked = false;
        });

        document.addEventListener('click', function (event) {
            const clickedInside = chartDiv.contains(event.target);
            if (!clickedInside) {
                currentPull = new Array(values.length).fill(0);
                drawChart(currentPull);
                if (dotNetHelper) {
                    dotNetHelper.invokeMethodAsync('ResetTableToSDM');
                }
            }
        });

        chartDiv.hasClickHandler = true;
    }
};
