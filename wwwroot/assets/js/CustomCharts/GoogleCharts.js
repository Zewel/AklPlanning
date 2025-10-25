function PieChart_Google(chartinfoList, listLength) {
    var data = new window.google.visualization.DataTable();
    data.addColumn('string', 'Column Name');
    data.addColumn('number', 'Column Value');
    for (var i = 0; i < listLength; i++) {
        data.addRow([chartinfoList[i].WeekNo, chartinfoList[i].MinTemp]);
    }
    var options = {
        title: 'USA City Distribution',
        is3D: true
    };
    new window.google.visualization.PieChart(document.getElementById('myChartDiv')).
    draw(data, {
        title: "Google Pie Chart",
        options : options
    });
}
function BarChart_Google(chartinfoList, listLength) {
    var data = new google.visualization.DataTable();
    data.addColumn('string', "Test1");
    data.addColumn('number', "Test2");
    data.addColumn('number', "Test3");
    for (i = 0; i < listLength; i++) {
        data.addRow([chartinfoList[i].WeekNo, chartinfoList[i].MaxTemp, chartinfoList[i].MinTemp]);
    }
    var options = {
        title: 'Sale and Purchase Compare',
        hAxis: { title: "asd", titleTextStyle: { color: 'red' } }
    };
    var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}
function LineChart_Google(chartinfoList, listLength) {
    var data = new google.visualization.DataTable();
    data.addColumn('string', "Test1");
    data.addColumn('number', "Test2");
    data.addColumn('number', "Test3");
    for (i = 0; i < listLength; i++) {
        data.addRow([chartinfoList[i].WeekNo, chartinfoList[i].MaxTemp, chartinfoList[i].MinTemp]);
    }
    var options = {
        hAxis: {
            title: 'Week'
        },
        vAxis: {
            title: 'Values'
        },
        colors: ['#a52714', '#097138'],
        series: {
            0: { lineWidth: 3, pointShape: 'diamond' },
            1: { lineWidth: 3, pointShape: 'diamond' }
        },
        pointsVisible: true,
        backgroundColor: { fill: 'transparent' },
        curveType: 'function'
        //crosshair: {
        //    color: '#000',
        //    trigger: 'selection'
        //}
    };
    var chart = new google.visualization.AreaChart(document.getElementById('chart_div2'));
    chart.draw(data, options);
}

