using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.WebApi.Data.QueryProcessors
{
    public interface IAddTaskQueryProcessor
    {
        void AddTask(EA.WebApi.Data.Entities.Task task);
    }

}
