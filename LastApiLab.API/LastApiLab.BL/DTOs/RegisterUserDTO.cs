using LastApiLab.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastApiLab.BL;
public record RegisterUserDTO(string Username, string Email, string Password, Gender Gender, decimal Salary);

