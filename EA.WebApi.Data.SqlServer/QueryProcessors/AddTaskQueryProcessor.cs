using EA.WebApi.Common;
using EA.WebApi.Common.Security;
using EA.WebApi.Data.Entities;
using EA.WebApi.Data.Exceptions;
using EA.WebApi.Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Data.SqlServer.QueryProcessors
{
   public class AddTaskQueryProcessor : IAddTaskQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;
        public AddTaskQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
        {
            _session = session;
            _userSession = userSession;
            _dateTime = dateTime;
        }

       
        public void AddTask(EA.WebApi.Data.Entities.Task task)
        {
            task.CreatedDate = _dateTime.UtcNow;
            task.Status = _session.QueryOver<Status>().Where(x => x.Name == "Not Started").SingleOrDefault();
           // task.CreatedBy = _session.QueryOver<User>().Where(x => x.Username == _userSession.Username).SingleOrDefault();
            task.CreatedBy = _session.Get<User>(1L); // HACK: All tasks created by user 1 for now

            if (task.Users != null && task.Users.Any())
            {
                for (var i = 0; i < task.Users.Count; ++i)
                {
                    var user = task.Users[i];
                    var persistedUser = _session.Get<User>(user.UserId);
                    if (persistedUser == null)
                    {
                        throw new ChildObjectNotFoundException("User not found");
                    }
                    task.Users[i] = persistedUser;
                }
            }
            _session.SaveOrUpdate(task);
        }

    }
}
