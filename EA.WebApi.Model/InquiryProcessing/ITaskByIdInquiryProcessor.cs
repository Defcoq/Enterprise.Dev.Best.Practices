using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EA.WebApi.Model.InquiryProcessing
{
    public interface ITaskByIdInquiryProcessor
    {
        Task GetTask(long taskId);
    }

}
