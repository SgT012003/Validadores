using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Validators.Static.Interface;

namespace Validation.Validators.Static.Method
{
    public class CPF : ICPF
    {
        public bool Validator(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            if (cpf.Length != 11)
            {
                return false;
            }
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }
            int[] cpfDigits = cpf.Select(c => int.Parse(c.ToString())).ToArray();
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += cpfDigits[i] * (10 - i);
            }
            int firstVerifierDigit = 11 - sum % 11;
            firstVerifierDigit = firstVerifierDigit > 9 ? 0 : firstVerifierDigit;
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += cpfDigits[i] * (11 - i);
            }
            int secondVerifierDigit = 11 - sum % 11;
            secondVerifierDigit = secondVerifierDigit > 9 ? 0 : secondVerifierDigit;
            if (cpfDigits[9] != firstVerifierDigit || cpfDigits[10] != secondVerifierDigit)
            {
                return false;
            }
            return true;
        }
    }
}
