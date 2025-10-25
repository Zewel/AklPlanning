//Morris chartting Custom Library   date : 09-05-2017
//sample chartdata - chartData.push({ 'xLabel': Lables[i], 'yKeyvalue1': chartValues1[i], 'yKeyValue2': chartValues2[i] });
//sample for donut chart data -  donutchartArray.push({ 'label': Lables[i], 'value': chartValues2[i] });
//Use same format for donut chart data that is mentioned above - 'label','value' must not be changed
//Function Calling -DoubleBarChart(chartData, 'myfirstchart', 'xLabel', 'yKeyvalue1', 'yKeyValue2', 'CustomLabelName1', 'CustomLabelName2');
// chart 
//-------------
//Parameter - dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, label1, label2 so on ....
//dataObjectName -  array that hold chart data
//elementName - id of div where chart will be showing 
//xKeyValue - Name of dataObjectName propertise that hold label 
// ykeyValue1,ykeyValue2,ykeyValue3... - Name of dataObjectName propertises that hold Values
// label1, label2,label3 .... - Is custom user text that will be shown when hover in chart value point
function SingleBarChart(dataObjectName,elementName,xKeyValue,ykeyValue,label) {
    var bar = new Morris.Bar({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue],
        labels: [label],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function DoubleBarChart(dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, label1, label2) {
    var bar = new Morris.Bar({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1, yKeyValue2],
        labels: [label1, label2],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function TripleBarChart(dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, yKeyValue3, label1, label2, label3) {
    var bar = new Morris.Bar({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1, yKeyValue2, yKeyValue3],
        labels: [label1, label2, label3],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function SingleLineChart(dataObjectName, elementName, xKeyValue, ykeyValue1, label1) {
    var bar = new Morris.Line({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1],
        labels: [label1],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function DoubleLineChart(dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, label1, label2) {
    var bar = new Morris.Line({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1, yKeyValue2],
        labels: [label1, label2],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 65,
        grid: true,
        axes : true
    });
}
function TripleLineChart(dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, yKeyValue3, label1, label2, label3) {
    var bar = new Morris.Line({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1, yKeyValue2, yKeyValue3],
        labels: [label1, label2, label3],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function SingleAreaChart(dataObjectName, elementName, xKeyValue, ykeyValue1, label1) {
    var bar = new Morris.Area({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1],
        labels: [label1],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function DoubleAreaChart(dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, label1, label2) {
    var bar = new Morris.Area({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1, yKeyValue2],
        labels: [label1, label2],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function TripleAreaChart(dataObjectName, elementName, xKeyValue, ykeyValue1, yKeyValue2, yKeyValue3, label1, label2, label3) {
    var bar = new Morris.Area({
        element: elementName,
        data: dataObjectName,
        xkey: [xKeyValue],
        ykeys: [ykeyValue1, yKeyValue2, yKeyValue3],
        labels: [label1, label2, label3],
        parseTime: false,
        pointSize: 2,
        hideHover: 'auto',
        resize: true,
        xLabelAngle: 35
    });
}
function DonutChart(elementName, data) {
    var donut = new Morris.Donut({
        element: elementName,
        data: data
    });
}

