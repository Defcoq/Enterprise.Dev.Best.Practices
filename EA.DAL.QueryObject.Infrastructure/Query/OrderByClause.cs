﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.DAL.QueryObject.Infrastructure.Query
{
    public class OrderByClause
    {
        public string PropertyName { get; set; }
        public bool Desc { get; set; }
    }
}
