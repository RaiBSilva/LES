using LES.Controllers.Facade;
using LES.Models.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Schedulers
{

    [DisallowConcurrentExecution]
    public class ApagaCarrinhoJob : IJob
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<ApagaCarrinhoJob> _logger;

        public ApagaCarrinhoJob(IServiceProvider provider, ILogger<ApagaCarrinhoJob> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            using (var scope = _provider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
                Cliente c = new Cliente();

                DateTime dataAtual = DateTime.Now;

                IList<Carrinho> listaCarrinhos = dbContext.Set<Carrinho>().Where(c => c.TimeoutDate <= dataAtual).ToList();

                if (listaCarrinhos.Count > 0)
                {

                    foreach (var carrinho in listaCarrinhos)
                    {
                        dbContext.Remove(carrinho);
                        _logger.LogInformation("Registros deletados: " + carrinho.DtCadastro);
                    }
                    try
                    {
                        dbContext.SaveChanges();
                    }catch(Exception e){
                        _logger.LogInformation("Mensagem Exception: " + e.Message);
                    }
                    
                }
                
            }

            return Task.FromResult(0);
        }
    }

}
