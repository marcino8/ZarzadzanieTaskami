﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Sponsor : Uzytkownik
    {
        public override string ToString()
        {
            return base.ToString()+ " SPONSOR";
        }
    }
}
