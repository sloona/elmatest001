﻿using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperOperation
{
    public class Therma : IOperation
    {
        public string Name
        {
            get
            {
                return "th";
            }
        }

        public object Execute(object[] args)
        {
            return "Therma";
        }
    }
}
