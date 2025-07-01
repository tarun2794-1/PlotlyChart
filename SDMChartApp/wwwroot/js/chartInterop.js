// Global chart registry
window._plotPieRegistry = window._plotPieRegistry || {};

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

        Plotly.react(elementId, data, layout, config).then(() => {
            addCenterClickOverlay(elementId);
        });
    }

    drawChart(currentPull);

    const chartDiv = document.getElementById(elementId);
    let sliceClicked = false;

    if (chartDiv && !chartDiv.hasClickHandler) {

        // Register reset function globally
        window._plotPieRegistry[elementId] = {
            reset: () => {
                currentPull = new Array(values.length).fill(0);
                drawChart(currentPull);
            },
            dotNetHelper: dotNetHelper
        };

        chartDiv.on('plotly_click', function (data) {
            const clickedIndex = data.points[0].pointNumber;
            sliceClicked = true;

            // Reset all other charts
            for (let id in window._plotPieRegistry) {
                if (id !== elementId) {
                    window._plotPieRegistry[id].reset();
                }
            }

            currentPull = currentPull.map((v, i) => i === clickedIndex ? 0.04 : 0);
            drawChart(currentPull);

            if (dotNetHelper) {
                const label = data.points[0].label;
                dotNetHelper.invokeMethodAsync('OnSliceClick', elementId + "|" + label);
            }
        });

        chartDiv.hasClickHandler = true;
    }

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
            backgroundColor: 'transparent',
        });

        overlay.addEventListener('click', () => {
            const chartInfo = window._plotPieRegistry[elementId];
            if (chartInfo) {
                chartInfo.reset();
                if (chartInfo.dotNetHelper) {
                    chartInfo.dotNetHelper.invokeMethodAsync('ResetTableToSDM', elementId);
                }
            }
        });

        chartDiv.style.position = 'relative';
        chartDiv.appendChild(overlay);
    }
};
