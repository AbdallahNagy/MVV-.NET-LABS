using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastApiLab.DAL;
public class Employee: IdentityUser
{
    public decimal Salary { get; set; }
    public Gender Gender { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
