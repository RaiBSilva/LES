function getData(endereco) {

    var dados = $.getJSON(endereco, function (resposta) {
        return resposta;
    });

    return dados;
}

function desenhaMaisVendidos() {

    var graph = $("#myChart");

    var endereco = urls.MaisVendidos;
    var dados = getData(endereco);

    new Chart(graph, {
        type: 'bar',
        data: {
            labels: dados.labels,
            datasets: dados.datasets
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
            },
            responsive: true
        }
    });

}

function desenhaVendas3Meses() {
    var graph = $("#myChart");

    var endereco = urls.VendasPorMes;
    var dados = getData(endereco);

    new Chart(graph, {
        type: 'line',
        data: {
            labels: dados.labels,
            datasets: dados.datasets
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