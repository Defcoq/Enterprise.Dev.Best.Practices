﻿using EA.DAL.ORM.Library.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.ORM.Library.Model
{
    public class BookTitle : IAggregateRoot
    {
        public string ISBN { get; set; }

        public string Title { get; set; }
    }
}
