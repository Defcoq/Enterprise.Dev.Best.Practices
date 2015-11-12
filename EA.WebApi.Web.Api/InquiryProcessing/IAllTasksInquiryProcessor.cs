using EA.WebApi.Data;
using EA.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.InquiryProcessing
{
    public interface IAllTasksInquiryProcessor
    {
        PagedDataInquiryResponse<Task> GetTasks(PagedDataRequest requestInfo);
    }

}