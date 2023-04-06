using LastApiLab.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LastApiLab.BL;
public interface IEmployeeManager
{
    string GenerateToken(IList<Claim> claims, DateTime expiresIn);
    Employee AdminDTOToEmpolyee(RegisterAdminDTO register);
    Employee UserDTOToEmpolyee(RegisterUserDTO register);
    ReadUserInfoDTO EmployeeToReadUserInfoDTO(Employee employee);

}
