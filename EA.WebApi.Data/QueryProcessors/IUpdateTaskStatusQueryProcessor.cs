using EA.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EA.WebApi.Data.QueryProcessors
{
    public interface IUpdateTaskStatusQueryProcessor
    {
        void UpdateTaskStatus(Task taskToUpdate, string statusName);
    }

}
