﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Manager : Uzytkownik
    {
        public override string ToString()
        {
            return base.ToString() + " MANAGER";
        }
    }
}
