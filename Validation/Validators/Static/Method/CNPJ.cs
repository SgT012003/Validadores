using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation.Validators.Static.Interface;

namespace Validation.Validators.Static.Method
{
    public class CNPJ : ICNPJ
    {
        public bool Validator(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());
            if (cnpj.Length != 14)
            {
                return false;
            }
            if (cnpj.Distinct().Count() == 1)
            {
                return false;
            }
            int[] cnpjDigits = cnpj.Select(c => int.Parse(c.ToString())).ToArray();
            int sum = 0;
            int[] weightsFirst = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 12; i++)
            {
                sum += cnpjDigits[i] * weightsFirst[i];
            }
            int firstVerifierDigit = 11 - (sum % 11);
            firstVerifierDigit = firstVerifierDigit > 9 ? 0 : firstVerifierDigit;
            sum = 0;
            int[] weightsSecond = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 13; i++)
            {
                sum += cnpjDigits[i] * weightsSecond[i];
            }
            int secondVerifierDigit = 11 - (sum % 11);
            secondVerifierDigit = secondVerifierDigit > 9 ? 0 : secondVerifierDigit;
            if (cnpjDigits[12] != firstVerifierDigit || cnpjDigits[13] != secondVerifierDigit)
            {
                return false;
            }
            return true;
        }
    }
}
