﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.dal
{
    public class AuthBooks
    {
        public int Id { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
