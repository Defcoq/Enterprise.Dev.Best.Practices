﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.Service
{
    public class ProductListResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<ProductViewModel> Products { get; set; }

    }
}
