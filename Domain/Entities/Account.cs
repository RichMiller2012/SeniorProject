﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public virtual int accountId { get; set; }
        public virtual Customer customer { get; set; }
    }
}
