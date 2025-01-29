using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace EarTrain.Application.OtherServices.JWT
{
    public static class JwtDataProviderService
    {
        public static Guid GetUserIDFromToken(KeyValuePair<string, StringValues> HeaderData)
        {
            string strToken = HeaderData.Value.ToString()["Bearer ".Length..];

            if (string.IsNullOrEmpty(strToken)) 
                return Guid.Empty;

            JwtSecurityToken token = default;

            try
            {
                token = new JwtSecurityTokenHandler().ReadJwtToken(strToken);
            }
            catch(SecurityTokenMalformedException)
            {
                return Guid.Empty;
            }

            Guid UserID = Guid.Parse(token.Claims.FirstOrDefault(x => x.Type == "ID").Value);

            return UserID;
        }

        public static string GetUserRoleFromToken(KeyValuePair<string, StringValues> HeaderData)
        {
            string strToken = HeaderData.Value.ToString()["Bearer ".Length..];

            if (string.IsNullOrEmpty(strToken)) 
                return null;

            JwtSecurityToken token = default;
            try
            {
                token = new JwtSecurityTokenHandler().ReadJwtToken(strToken);
            }
            catch (SecurityTokenMalformedException)
            {
                return null;
            }

            string role = token.Claims.FirstOrDefault(x => x.Type == "Role").Value;

            return role;
        }
    }
}
