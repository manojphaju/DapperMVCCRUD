﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDDapper.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}