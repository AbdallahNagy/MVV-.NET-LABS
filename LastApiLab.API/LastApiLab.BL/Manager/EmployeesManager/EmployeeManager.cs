using LastApiLab.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LastApiLab.BL;

public class EmployeeManager : IEmployeeManager
{
    private readonly IConfiguration configuration;

    public EmployeeManager(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public Employee AdminDTOToEmpolyee(RegisterAdminDTO register)
    {
        return new Employee
        {
            UserName = register.Username,
            Email = register.Email,
            Gender = register.Gender,
            Salary = register.Salary,
        };
    }
    public Employee UserDTOToEmpolyee(RegisterUserDTO register)
    {
        return new Employee
        {
            UserName = register.Username,
            Email = register.Email,
            Gender = register.Gender,
            Salary = register.Salary,
        };
    }
    public string GenerateToken(IList<Claim> claims, DateTime expiresIn)
    {
        // if user is authenticated then i want to make a token for him
        // 2.get security key
        var secretKeyString = configuration.GetValue<string>("SecretKey");
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString!); // ! -> will never be null
        var securityKey = new SymmetricSecurityKey(secretKeyInBytes);

        // 3.choose hashing algo -> from identityModel.Tokens.JWT pachage
        var hashingAlgo = SecurityAlgorithms.HmacSha256;

        // 4.signing credentials (secret key + hashing algorithm)
        var signingCredentials = new SigningCredentials(securityKey, hashingAlgo);

        // 5.create token
        var jwt = new JwtSecurityToken
            (
                claims: claims,
                expires: expiresIn,
                signingCredentials: signingCredentials
            );

        // convert object token to string
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(jwt);

        return tokenString;
    }

    public ReadUserInfoDTO EmployeeToReadUserInfoDTO(Employee emp)
    {
        return new ReadUserInfoDTO
            (
            Username: emp.UserName,
            Email: emp.Email,
            Salary: emp.Salary
            );
    }
}
