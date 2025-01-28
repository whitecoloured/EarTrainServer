using Microsoft.Extensions.Primitives;
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
            string token = HeaderData.Value.ToString()["Bearer ".Length..];
            if (string.IsNullOrEmpty(token)) 
                return Guid.Empty;

            Guid UserID = Guid.Parse(new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(x => x.Type == "ID").Value);

            return UserID;
        }

        public static string GetUserRoleFromToken(KeyValuePair<string, StringValues> HeaderData)
        {
            string token = HeaderData.Value.ToString()["Bearer ".Length..];

            if (string.IsNullOrEmpty(token)) 
                return null;

            string role = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(x => x.Type == "Role").Value;

            return role;
        }
    }
}
