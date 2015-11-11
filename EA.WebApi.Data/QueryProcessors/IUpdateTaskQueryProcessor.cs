using EA.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;


namespace EA.WebApi.Data.QueryProcessors
{
    public interface IUpdateTaskQueryProcessor
    {
        Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);
        Task DeleteTaskUsers(long taskId);
        Task AddTaskUser(long taskId, long userId);
        Task DeleteTaskUser(long taskId, long userId);
        Task GetUpdatedTask(long taskId, PropertyValueMapType updatedPropertyValueMap);


    }
}
