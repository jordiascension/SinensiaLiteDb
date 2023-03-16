﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinensia.Transversal.Model.CustomExceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException()
        {
        }

        public StudentNotFoundException(string message)
            : base(message)
        {
        }

        public StudentNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
