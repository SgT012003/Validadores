using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation.Validators.Task.Interface
{
    public interface ICNPJ
    {
        Task<bool> Validator(string cnpj);
    }
}
