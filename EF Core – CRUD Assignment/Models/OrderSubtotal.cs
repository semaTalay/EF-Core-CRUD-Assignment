﻿using System;
using System.Collections.Generic;

namespace EF_Core___CRUD_Assignment.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
