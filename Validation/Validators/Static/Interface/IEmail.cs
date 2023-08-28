using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Validators.Static.Interface
{
    public interface IEmail
    {
        public abstract bool Validator(string email);
    }
}
