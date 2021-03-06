﻿using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Architecture.AR.Model
{
   
        [ActiveRecord("Comments")]
        public class Comment : ActiveRecordBase<Comment>
        {
            [PrimaryKey]
            public int Id { get; set; }

            [BelongsTo("PostID")]
            public Post Post { get; set; }

            [Property]
            public string Text { get; set; }

            [Property]
            public string Author { get; set; }

            [Property]
            public DateTime DateAdded { get; set; }

       
        }
    }

