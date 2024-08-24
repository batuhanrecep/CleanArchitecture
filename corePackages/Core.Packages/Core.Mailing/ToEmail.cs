using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing;
public class ToEmail
{
    public string Email { get; set; }
    public string FullName { get; set; }

    public ToEmail() { }

    public ToEmail(string email, string fullName)
    {
        Email = email;
        FullName = fullName;
    }
}
