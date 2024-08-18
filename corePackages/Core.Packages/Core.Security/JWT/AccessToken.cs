using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.JWT;
public class AccessToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }

    public AccessToken()
    {
        Token= String.Empty;
    }

    public AccessToken(string token, DateTime expiration)
    {
        Token = Token;
        Expiration = Expiration;
    }
}
