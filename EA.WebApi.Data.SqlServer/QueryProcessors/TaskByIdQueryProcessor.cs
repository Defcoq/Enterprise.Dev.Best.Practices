using EA.WebApi.Data.Entities;
using EA.WebApi.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EA.WebApi.Data.SqlServer.QueryProcessors
{
    public class TaskByIdQueryProcessor : ITaskByIdQueryProcessor
    {
        private readonly ISession _session;
        public TaskByIdQueryProcessor(ISession session)
        {
            _session = session;
        }
        public Task GetTask(long taskId)
        {
            var task = _session.Get<Task>(taskId);
            return task;
        }
    }

}
