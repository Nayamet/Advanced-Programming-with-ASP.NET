﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BEL
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Nullable<int> FK_Users_Id { get; set; }
        public Nullable<int> FK_News_Id { get; set; }
    }
}