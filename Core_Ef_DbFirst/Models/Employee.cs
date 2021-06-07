using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Core_Ef_DbFirst.Models
{
    public partial class Employee
    {
        public int EmpUniqueId { get; set; }
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public int DeptUniqueId { get; set; }

        public virtual Department DeptUnique { get; set; }
    }
}
