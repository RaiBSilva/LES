using LES.Controllers.Facade;
using LES.Models.Entity;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Schedulers
{
    public class ScheduleCarrinho : IAgendarJob
    {
        private static StdSchedulerFactory schedulerFactory = new StdSchedulerFactory();
        private static IScheduler scheduler { get; set; }

        public ScheduleCarrinho(){
            CriarScheduler();
        }

        private async void CriarScheduler()
        {
            scheduler = await schedulerFactory.GetScheduler();
        }

        public async void CancelaJob(string keyStr)
        {
            IList<string> parametros = keyStr.Split(".");

            JobKey chave = new JobKey(parametros[0], parametros[1]);

            await scheduler.DeleteJob(chave);
        }

        public async void AgendarJob(DateTime dataExecucao, Carrinho carrinhoCli, string emailCliente)
        {
            IJobDetail job = JobBuilder.Create<ApagaCarrinhoJob>()
                .WithIdentity(carrinhoCli.Id.ToString(), emailCliente)
                .Build();

            job.JobDataMap.Add("carrinho", carrinhoCli);

            ITrigger trigger = TriggerBuilder.Create()
                .StartAt(dataExecucao)
                .WithSchedule(CronScheduleBuilder.CronSchedule(String.Format("{0} {1} {2} * * ?", dataExecucao.Second, dataExecucao.Minute, dataExecucao.Hour)))
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            await scheduler.Start();
        }

    }


    public class ApagaCarrinhoJob : IJob
    {
        IFacadeCrud _facade { get; set; }

        ApagaCarrinhoJob(IFacadeCrud facade)
        {
            _facade = facade;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Carrinho carrinho = (Carrinho)context.MergedJobDataMap["carrinho"];

            _facade.Deletar<Carrinho>(carrinho);

            return Task.FromResult(0);
        }
    }

}
