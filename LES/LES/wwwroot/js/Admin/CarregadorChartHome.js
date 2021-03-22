function getData(endereco) {

    var data = $.get(endereco, function (data) {
        return data;
    });

    return data;

}

function desenhaMaisVendidos() {

    var graph = $("#myChart");

    var endereco = urls.MaisVendidos;
    new Chart(graph, {
        type: 'bar',
        data: {
            labels: ['Janeiro', 'Fevereiro', 'Março' ],
            datasets: [{
                label: "Livro1",
                data: [100, 200, 150],
                backgroundColor: 'rgba(94, 140, 95, 0.5)'
            },
            {
                label: "Livro2",
                data: [50, 20, 100],
                backgroundColor: 'rgba(140, 94, 95, 0.5)'
            },
            {
                label: "Livro3",
                data: [123, 52, 231],
                backgroundColor: 'rgba(95, 94, 140, 0.5)'
            }]
        },
        options: {
            title: {
                display: true,
                text: "Mais Vendidos nos últimos três meses",
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            },
            legend: {
                labels: {
                    defaultFontSize: 20
                }
            }
        }
    });

}

function desenhaVendas3Meses() {
    var graph = $("#myChart");

    var endereco = urls.MaisVendidos;
    new Chart(graph, {
        type: 'line',
        data: {
            labels: ['Janeiro', 'Fevereiro', 'Março'],
            datasets: [{
                label: 'Vendas',
                data: [320, 250, 250],
                backgroundColor: 'rgba(94, 140, 95, 0.5)'
            }]
        },
        options: {
            title: {
                display: true,
                text: "Vendas nos últimos três meses",
            },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            },
            legend: {
                labels: {
                    defaultFontSize: 20
                }
            }
        }
    });
}

desenhaMaisVendidos();