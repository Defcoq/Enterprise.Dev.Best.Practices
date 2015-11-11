using EA.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EA.WebApi.Web.Api.MaintenanceProcessing
{
    public interface IUpdateTaskMaintenanceProcessor
    {
        Task UpdateTask(long taskId, object taskFragment);

    }
}
