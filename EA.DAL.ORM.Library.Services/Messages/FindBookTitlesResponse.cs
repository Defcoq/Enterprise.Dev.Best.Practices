﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EA.DAL.ORM.Library.Services.Views;

namespace EA.DAL.ORM.Library.Services.Messages
{
    public class FindBookTitlesResponse : ResponseBase 
    {
        public IEnumerable<BookTitleView> BookTitles { get; set; }  
    }
}
