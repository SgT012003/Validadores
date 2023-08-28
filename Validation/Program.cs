using Validation.Validators.Task.Method;
using Validation.Validators.Task.Interface;

namespace Validation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string value;
            if (args.Length > 0)
            {
                value = args[0];
            }
            else
            {
                value = "123.456.789-09";
            }

            CPF cpf = new();
            /*
            The cpf on validator is valid, and is only for test questions! [ "123.456.789-09" ]
            this code is only to non-online methods, for online methods see this site bellow!
            [ https://www.gov.br/conecta/catalogo/apis/cadastro-base-do-cidadao-cbc-cpf/swagger-v2.json/swagger_view ]
            */
            if (await cpf.Validator(value))
            {
                Console.WriteLine("Valid");
                Console.ReadKey(); //to continue open after execute.
                return;
            }
            Console.WriteLine("Invalid");
        }
    }
}