using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Validation.Validators.Task.Interface;

namespace Validation.Validators.Task.Method
{
    public class Email : IEmail
    {
#pragma warning disable CS1998
        public async Task<bool> Validator(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
#pragma warning restore CS1998
        }
    }
}
