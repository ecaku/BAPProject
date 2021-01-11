using BaProje.Business.StringInfos;
using BaProje.Business.Tools.JWTTool;
using BAProje.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaProje.Business.Tools.JWTTooll.JwtManager
{
    public class JwtManager : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public JwtToken GenerateJwt(Customer customer)
        {
            try
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: JwtInfo.Issuer,
                    audience: JwtInfo.Audience,
                    claims: SetClaims(customer,_configuration),
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(JwtInfo.expires),
                    signingCredentials: signingCredentials

                );

                JwtToken jwtToken = new JwtToken();
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                jwtToken.Token = handler.WriteToken(jwtSecurityToken);


                return jwtToken;
            }
            catch (Exception ex)
            {
                
                return null;
            }
            
        }
        
        private List<Claim> SetClaims(Customer customer,IConfiguration configuration)
        {
            List<Claim> claims = new List<Claim>();

            if (customer.CustomerName == configuration["Data:AdminUser:username"] && customer.Password==configuration["Data:AdminUser:password"])
            {
                claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                
                
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Customer"));
            }
            
            claims.Add(new Claim(ClaimTypes.Name, customer.CustomerName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()));
            
            
            
            

            return claims;
        }
        
    }
}
