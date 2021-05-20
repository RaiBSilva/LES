function fazGrafico() {
    var graph = $("#myChart");

    var endereco = urls.Vendas;
    var data = JSON.stringify({
        Nome: $("#inputTitulo").val,
        Categorias: $("#inputCategorias").val,
        Comeco: $("#inputComeco").val,
        Fim: $("#inputFim").val,
    }
    );

    $.getJSON(endereco, data, function (dados) {
        new Chart(graph, {
            type: 'line',
            data: {
                labels: dados.labels,
                datasets: dados.datasets
            },
            options: {
                title: {
                    display: true,
                    text: "Vendas nos últimos "+ dados.labels.length +" meses",
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
    })

    
}

fazGrafico();