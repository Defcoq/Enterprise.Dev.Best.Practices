using EA.WebApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EA.WebApi.Web.Api.Models
{
    public class NewTaskV2
    {
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public User Assignee { get; set; }
    }

}