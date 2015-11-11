using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.QueryProcessors;
using EA.WebApi.Model;
using EA.WebApi.Web.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;


namespace EA.WebApi.Web.Api.MaintenanceProcessing
{
    public class UpdateTaskMaintenanceProcessor : IUpdateTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateTaskQueryProcessor _queryProcessor;
        private readonly IUpdateablePropertyDetector _updateablePropertyDetector;
        public UpdateTaskMaintenanceProcessor(IUpdateTaskQueryProcessor queryProcessor,
        IAutoMapper autoMapper,
        IUpdateablePropertyDetector updateablePropertyDetector)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
            _updateablePropertyDetector = updateablePropertyDetector;
        }
        public Task UpdateTask(long taskId, object taskFragment)
        {
            var taskFragmentAsJObject = (JObject)taskFragment;
            var taskContainingUpdateData = taskFragmentAsJObject.ToObject<Task>();
            var updatedPropertyValueMap = GetPropertyValueMap(
            taskFragmentAsJObject, taskContainingUpdateData);
            var updatedTaskEntity = _queryProcessor.GetUpdatedTask(taskId, updatedPropertyValueMap);
            var task = _autoMapper.Map<Task>(updatedTaskEntity);
            return task;
        }
        public virtual PropertyValueMapType GetPropertyValueMap(
        JObject taskFragment, Task taskContainingUpdateData)
        {
            var namesOfModifiedProperties = _updateablePropertyDetector
            .GetNamesOfPropertiesToUpdate<Task>(taskFragment).ToList();
            var propertyInfos = typeof(Task).GetProperties();
            var updatedPropertyValueMap = new PropertyValueMapType();
            foreach (var propertyName in namesOfModifiedProperties)
            {
                var propertyValue = propertyInfos.Single(
                x => x.Name == propertyName).GetValue(taskContainingUpdateData);
                updatedPropertyValueMap.Add(propertyName, propertyValue);
            }
            return updatedPropertyValueMap;
        }

    }
}