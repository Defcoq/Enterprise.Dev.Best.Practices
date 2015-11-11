using EA.WebApi.Common.TypeMapping;
using EA.WebApi.Data.Exceptions;
using EA.WebApi.Data.QueryProcessors;
using EA.WebApi.Model;
using EA.WebApi.Model.InquiryProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.InquiryProcessing
{
    public class TaskByIdInquiryProcessor : ITaskByIdInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _queryProcessor;
        public TaskByIdInquiryProcessor(ITaskByIdQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }
        public Task GetTask(long taskId)
        {
            var taskEntity = _queryProcessor.GetTask(taskId);
            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }
            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }

    }
}