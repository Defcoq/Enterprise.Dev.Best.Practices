using EA.WebApi.Data.Entities;
using EA.WebApi.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EA.WebApi.Data.SqlServer.QueryProcessors
{
    public class UpdateTaskStatusQueryProcessor : IUpdateTaskStatusQueryProcessor
    {
        private readonly ISession _session;
        public UpdateTaskStatusQueryProcessor(ISession session)
        {
            _session = session;
        }
        public void UpdateTaskStatus(Task taskToUpdate, string statusName)
        {
            var status = _session.QueryOver<Status>().Where(x => x.Name == statusName).SingleOrDefault();
            taskToUpdate.Status = status;
            _session.SaveOrUpdate(taskToUpdate);
        }
    }

}
