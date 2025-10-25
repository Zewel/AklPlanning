//Uses of Chart js withCredentials Dynamic chartValues1
// call function with number of parameters , Parameters are used as Array of Values and Array of Labels
//chartValues1,chartValues2 represnet the chart values - These are array of value
//lables represent array of label
//getRandomColor have been used to generate random colors
//reference to be needed to include in your layout 
//<script src="~/assets/plugins/ChartjsBundle/Chart.bundle.js"></script>
//<script src="~/assets/plugins/ChartjsBundle/Chart.PieceLabel.js"></script>
//<script src="~/assets/plugins/ChartjsBundle/Chart.PieceLabel.min.js"></script>
function SingleBarChart_ChartJs(chartValues1, lables) {
    var ctx = document.getElementById("canvas1").getContext("2d");
    var color = [];
    //This is to push color for bar
    for (var i = 0; i < chartValues1.length; i++) {  
        color.push('#006666');
    }
    var barData = {
        labels: lables,
        datasets: [
            {
                label: "Name of Label",
                backgroundColor: color,
                borderColor: [
                    'rgba(255,99,132,1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1,
                data: chartValues1
            }
        ]
    };
    var options = {
        title:
   {
       display: true,
       text: "Maximum Weekly Temparature"
   },
        scales: {
            xAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "Week Number "
                }
            }],
            yAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "Values"
                },
                ticks: {
                    beginAtZero: true
                }
            }]
        },
        // have Been Used to show values on teh Bar
        animation: {
            onComplete: function () {
                var ctx = this.chart.ctx;
                ctx.textAlign = "center";
                ctx.textBaseline = "middle";
                var chart = this;
                var datasets = this.config.data.datasets;
                datasets.forEach(function (dataset, i) {
                    ctx.font = "10px Arial";
                    ctx.fillStyle = "White";
                    chart.getDatasetMeta(i).data.forEach(function (p, j) {
                        ctx.fillText(datasets[i].data[j], p._model.x, p._model.y + 20);
                    });
                });
            }
        }
    };
    window.myBar = new Chart(ctx,
    {
        type: 'bar',
        data: barData,
        options: options
    });
}
function DoubleBarChart_ChartJs(chartValues1, chartValues2, lables) {
    var ctx = document.getElementById("canvas2").getContext("2d");
    var color1 = [];
    var color2 = [];
    //for (var i = 0; i < chartValues1.length; i++) {
    //    color1.push('#003300');
    //    color2.push('#000066');
    //}
    var barData = {
        labels: lables,
        datasets: [
            {
                label: ["Minimum temperature"],
                backgroundColor: color1,
                borderColor: [
                    'rgba(255,99,132,1)'
                ],
                borderWidth: 1,
                data: chartValues1
            },
            {
                label: ["Max temperature"],
                backgroundColor: color2,
                borderColor: [
                    'rgba(255,99,132,1)'
                ],
                borderWidth: 1,
                data: chartValues2
            }
        ]
    };
    window.myBar = new Chart(ctx,
      {
          type: 'bar',
          data: barData,
          options:
          {
              title:
              {
                  display: true,
                  text: "temperature Ratio"
              },
              responsive: true,
              maintainAspectRatio: true,
              scales: {
                  xAxes: [{
                      scaleLabel: {
                          display: true,
                          labelString: "Week Number "
                      }
                  }],
                  yAxes: [{
                      scaleLabel: {
                          display: true,
                          labelString: "Values"
                      },
                      ticks: {
                          beginAtZero: true
                      }
                  }]
              }
          }
      });
}
function SingleLineChart_ChartJs(chartValues1, lables) {
    var ctx = document.getElementById("LineCanvas").getContext("2d");
    var barData = {
        labels: lables,
        datasets: [
            {
                label: ['Week Temp'],
                fill: false,
                lineTension: 0.1,
                backgroundColor: "rgba(75,192,192,0.4)",
                borderColor: "rgba(75,192,192,1)",
                borderCapStyle: 'butt',
                borderDash: [],
                borderDashOffset: 0.0,
                borderJoinStyle: 'miter',
                pointBorderColor: "rgba(75,192,192,1)",
                pointBackgroundColor: "#fff",
                pointBorderWidth: 1,
                pointHoverRadius: 5,
                pointHoverBackgroundColor: "rgba(75,192,192,1)",
                pointHoverBorderColor: "rgba(220,220,220,1)",
                pointHoverBorderWidth: 2,
                pointRadius: 1,
                pointHitRadius: 10,
                data: chartValues1
            }
        ]
    };
    var options = {
        title:
             {
       display: true,
       text: "Minimum Weekly Temparature"
         },
        scales: {
            xAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "Week Number "
                }
            }],
            yAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "Values"
                },
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    };
    window.myBar = new Chart(ctx,
    {
        type: 'line',
        data: barData,
        options: options
    });
}
function DoubleLineChart_ChartJs(chartValues1, chartValues2, lables) {
    var ctx = document.getElementById("doubleLine").getContext("2d");
    var barData = {
        labels: lables,
        datasets: [
            {
                label: ['Min Temp'],
                fill: false,
                lineTension: 0.1,
                backgroundColor: "rgba(75,192,192,0.4)",
                borderColor: "rgba(75,192,192,1)",
                data: chartValues1
            },
                    {
                        label: ['Max Temp'],
                        fill: false,
                        lineTension: 0.1,
                        backgroundColor: "rgb(244, 173, 66)",
                        borderColor: "rgb(244, 173, 66)",
                        data: chartValues2
                    }
        ]
    };
    var options = {
        title:
             {
                 display: true,
                 text: "Minimum Weekly Temparature"
             },
        scales: {
            xAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "Week Number "
                }
            }],
            yAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: "Values"
                },
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    };
    window.myBar = new Chart(ctx,
    {
        type: 'line',
        data: barData,
        options: options
    });
}
function PieCharts(chartValues1, lables) {
    var ctx = document.getElementById("canvas3").getContext("2d");
    var color = [];
    for (var i = 0; i < chartValues1.length; i++) {
        var col = getRandomColor();
        color.push(col);
    }
    var barData = {
        labels: lables,
        datasets: [
            {
                backgroundColor: color,
                borderColor: [
                    'rgba(255,99,132,1)'
                ],
                borderWidth: 1,
                data: chartValues1
            }
        ]
    };
    window.myBar = new Chart(ctx,
    {
        type: 'pie',
        data: barData,
        options:
        {
            title:
            {
                display: true,
                text: "Maximum Weekly Temparature"
            },
            responsive: true,
            maintainAspectRatio: true,
            // pieceLabel are used for showing percentage or Label on The pie chart
            pieceLabel: {
                mode: 'percentage',
                precision: 2
            },
            scales: {
                xAxes: [
                    {
                        display: this.scalesdisplay,
                        ticks: {
                            beginAtZero: this.beginzero
                        }
                    }
                ],
                yAxes: [
                    {
                        display: this.scalesdisplay,
                        ticks: {
                            beginAtZero: this.beginzero
                        }
                    }
                ]
            }
        }
    });
}
function doughnut(chartValues2, lables) {
    var ctx = document.getElementById("donut").getContext("2d");
    var color = [];
    for (var i = 0; i < chartValues2.length; i++) {
        var col = getRandomColor();
        color.push(col);
    }
    var barData = {
        labels: lables,
        datasets: [
            {
                label: ["Male"],
                backgroundColor: color,
                borderColor: [
                    'rgba(255,99,132,1)'
                ],
                borderWidth: 1,
                data: chartValues2
            }
        ]
    };
    window.myBar = new Chart(ctx,
    {
        type: 'doughnut',
        data: barData,
        options:
        {
            title:
            {
                display: true,
                text: "Minimum Weekly Temparature"
            },
            responsive: true,
            maintainAspectRatio: true,
            pieceLabel: {
                mode: 'percentage',
                precision: 2
            },
            scales: {
                xAxes: [
                    {
                        display: this.scalesdisplay,
                        ticks: {
                            beginAtZero: this.beginzero
                        }
                    }
                ],
                yAxes: [
                    {
                        display: this.scalesdisplay,
                        ticks: {
                            beginAtZero: this.beginzero
                        }
                    }
                ]
            }
        }
    });
}
//Geeting Random Color 
function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
