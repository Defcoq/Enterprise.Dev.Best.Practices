using EA.WebApi.Model;
using EA.WebApi.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.MaintenanceProcessing
{
    public interface IAddTaskMaintenanceProcessor
    {
        Task AddTask(NewTask newTask);
    }

}