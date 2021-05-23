function fazGrafico(primeiravez) {
    if (primeiravez === undefined)
        primeiravez = false;

    var graph = $("#myChart");

    if (!primeiravez)
        Chart.helpers.each(Chart.instances, function (instance) {
            instance.destroy();
        })

    var endereco = urls.Vendas;
    var data = JSON.stringify({
        Nome: $("#inputTitulo")[0].value,
        Categorias: $("#inputCategorias")[0].value,
        Comeco: $("#inputComeco")[0].value,
        Fim: $("#inputFim")[0].value
    });

    $.ajax({
        url: endereco,
        method: 'POST',
        data: { json: data },
        success: function (dados) {

            new Chart(graph, {
                type: 'line',
                data: {
                    labels: dados.labels,
                    datasets: dados.datasets
                },
                options: {
                    title: {
                        display: true,
                        text: "Vendas nos últimos " + dados.labels.length + " meses",
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

        }, 
    })

    
}

$(document).ready(function () {
    fazGrafico(true);
});
