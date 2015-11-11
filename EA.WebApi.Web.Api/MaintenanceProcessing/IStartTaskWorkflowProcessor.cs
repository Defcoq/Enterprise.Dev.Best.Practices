using EA.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.MaintenanceProcessing
{
    public interface IStartTaskWorkflowProcessor
    {
        Task StartTask(long taskId);
    }

}