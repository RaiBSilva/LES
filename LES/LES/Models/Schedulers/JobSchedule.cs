using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LES.Models.Schedulers
{
    public class JobSchedule
    {
        public JobSchedule(Type jobType, string cronExpression, DateTime dataExecucao)
        {
            JobType = jobType;
            CronExpression = cronExpression;
            DataExecucao = dataExecucao;
        }

        public Type JobType { get; }
        public DateTime DataExecucao { get; }
        public string CronExpression { get; }
    }
}
