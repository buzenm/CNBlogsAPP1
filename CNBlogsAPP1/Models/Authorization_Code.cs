﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPAPP.Models
{
    public class Authorization_Code
    {
        public string Content_Type { get; set; }

        public string client_id { get; set; }

        public string grant_type { get; set; }

        public string code { get; set; }

        public string redirect_uri { get; set; }


    }
}