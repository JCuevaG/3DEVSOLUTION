﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEV.MODELS
{
    public class Product : IAuditInfo
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }        
        public DateTime ModifiedOn { get; set; }        
    }
}
