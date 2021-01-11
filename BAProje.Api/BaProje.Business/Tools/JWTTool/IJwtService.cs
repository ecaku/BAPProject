using BAProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaProje.Business.Tools.JWTTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(Customer customer);
    }
}
