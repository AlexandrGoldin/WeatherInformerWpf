﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWeatherDemo.Utils
{
    public class UnauthorizedApiAccessException : Exception
    {
        public UnauthorizedApiAccessException()
        {
        }

        public UnauthorizedApiAccessException(string message) : base(message)
        {
        }

        public UnauthorizedApiAccessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
