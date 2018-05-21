 
        // 路径配置
        require.config({
            paths: {
                echarts: 'http://echarts.baidu.com/build/dist'
            }
        });
// 使用
require(['echarts', 'echarts/chart/map'], function (ch) {

    // 基于准备好的dom，初始化echarts图表
    var myChart = ch.init(document.getElementById('main'));

    option = {
        tooltip: {
            trigger: 'item',
            formatter: '{b}'
        },
        dataRange: {
            x: 'left',
            y: 'bottom',
            //东北（黑龙江省、吉林省、辽宁省）；
            //华东（上海市、江苏省、浙江省、安徽省、福建省、江西省、山东省、台湾省）；
            //华北（北京市、天津市、山西省、河北省、内蒙古自治区）；
            //华中（河南省、湖北省、湖南省）；
            //华南（广东省、广西壮族自治区、海南省、香港特别行政区、澳门特别行政区）；
            //西南（四川省、贵州省、云南省、重庆市、西藏自治区）；
            //西北（陕西省、甘肃省、青海省、宁夏回族自治区、新疆维吾尔自治区）
            splitList: [
                { start: 1, end: 1, label: '东北', color: '#2de55b' },
                { start: 2, end: 2, label: '华东', color: '#8DEEEE' },
                { start: 3, end: 3, label: '华北', color: '#BF3EFF' },
                { start: 4, end: 4, label: '华中', color: '#CD5C5C' },
                { start: 5, end: 5, label: '华南', color: '#e56700' },
                { start: 6, end: 6, label: '西南', color: '#CDAF95' },
                { start: 7, end: 7, label: '西北', color: '#e5d32d' }
            ],
        },
        series: [{
            name: '中国',
            type: 'map',
            mapType: 'china',

            itemStyle: {
                normal: { label: { show: true } },
                emphasis: { label: { show: true } },
            },
            data: [
       { name: '北京', selected: false, value: 3 },
       { name: '天津', selected: false, value: 3 },
       { name: '上海', selected: false, value: 2 },
       { name: '重庆', selected: false, value: 6 },
       { name: '河北', selected: false, value: 3 },
       { name: '河南', selected: false, value: 4 },
       { name: '云南', selected: false, value: 6 },
       { name: '辽宁', selected: false, value: 1 },
       { name: '黑龙江', selected: false, value: 1 },
       { name: '湖南', selected: false, value: 4 },
       { name: '安徽', selected: false, value: 2 },
       { name: '山东', selected: false, value: 2 },
       { name: '新疆', selected: false, value: 7 },
       { name: '江苏', selected: false, value: 2 },
       { name: '浙江', selected: false, value: 2 },
       { name: '江西', selected: false, value: 2 },
       { name: '湖北', selected: false, value: 4 },
       { name: '广西', selected: false, value: 5 },
       { name: '甘肃', selected: false, value: 7 },
       { name: '山西', selected: false, value: 3 },
       { name: '内蒙古', selected: false, value: 3 },
       { name: '陕西', selected: false, value: 7 },
       { name: '吉林', selected: false, value: 1 },
       { name: '福建', selected: false, value: 2 },
       { name: '贵州', selected: false, value: 6 },
       { name: '广东', selected: false, value: 5 },
       { name: '青海', selected: false, value: 7 },
       { name: '西藏', selected: false, value: 6 },
       { name: '四川', selected: false, value: 6 },
       { name: '宁夏', selected: false, value: 7 },
       { name: '海南', selected: false, value: 5 },
       { name: '台湾', selected: false, value: 2 },
       { name: '香港', selected: false, value: 5 },
       { name: '澳门', selected: false, value: 5 }
            ]
        }]
    };
             
    var ecConfig = require('echarts/config');
    myChart.on(ecConfig.EVENT.CLICK, function (param) {
        //点击时间
       // alert(param.name)

    })

    // 为echarts对象加载数据 
    myChart.setOption(option);





});



 