# Validators
Validators is a csharp public lib, for verify on non-online methods brazilian oficial documents like CPF, CNPJ and general info like a Email.

## Implementation
Don't have a final method to install, like a oficial lib, but can download and used as you want [ copy and past ].

## Usage

```c#
using Validation.Validators.Task.Method;

namespace Validation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /* def here you validator */
            CPF service = new();
            string value;

            if (args.Length > 0)
            {
                value = args[0];
            }
            else
            {
                value = "123.456.789-09";
            }
            /*
            The cpf on validator is valid, and is only for test questions! [ "123.456.789-09" ]
            this code is only to non-online methods, for online methods see this site bellow!
            [ https://www.gov.br/conecta/catalogo/apis/cadastro-base-do-cidadao-cbc-cpf/swagger-v2.json/swagger_view ]
            */
            if (await service.Validator(value))
            {
                Console.WriteLine("Valid");
              //Console.ReadKey(); /* to continue open after execute. */
                return;
            }
            Console.WriteLine("Invalid");
        }
    }
}
```
## Advice's

My code is based on oficial information given on [gov.br](https://www.gov.br/conecta/catalogo/apis/cadastro-base-do-cidadao-cbc-cpf/swagger-v2.json/swagger_view#operation/consultaCpf).

To change the Validator Type between CPF, CNPJ and Email change the instance on Service Varible and the default value.

```diff
using Validation.Validators.Task.Method;

namespace Validation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /* def here you validator */
-           // CPF service = new();

+           CNPJ service = new();
            /*        or        */
+           Email service = new();

            string value;

            if (args.Length > 0)
            {
                value = args[0];
            }
            else
            {
-               value = "123.456.789-09"; // CPF example

+               value = "08.476.585/0001-22";  // CNPJ example
            /*        or        */
+               value = "askme@hotmail.com"; // email example
            }
            /*
-           The cpf on validator is valid, and is only for test questions! [ "123.456.789-09" ]
+           The cpf on validator is valid, and is only for test questions!
            this code is only to non-online methods, for online methods see this site bellow!
            [ https://www.gov.br/conecta/catalogo/apis/cadastro-base-do-cidadao-cbc-cpf/swagger-v2.json/swagger_view ]
            */
            if (await service.Validator(value))
            {
                Console.WriteLine("Valid");
              //Console.ReadKey(); /* to continue open after execute. */
                return;
            }
            Console.WriteLine("Invalid");
        }
    }
}
```

and has both types of basic comands on C#, like Methods and Tasks for change for each one you only need to change the `using` origin and remove the `await` on `if` and if you want remove the Task on Main.
```diff
-using Validation.Validators.Task.Method;
+using Validation.Validators.Static.Method;

namespace Validation
{
    public class Program
    {
-        public static async Task Main(string[] args)
+        public static void Main(string[] args)
        {
            /* def here you validator */
            CPF service = new();
            string value;

            if (args.Length > 0)
            {
                value = args[0];
            }
            else
            {
                value = "123.456.789-09";
            }
            /*
            The cpf on validator is valid, and is only for test questions! [ "123.456.789-09" ]
            this code is only to non-online methods, for online methods see this site bellow!
            [ https://www.gov.br/conecta/catalogo/apis/cadastro-base-do-cidadao-cbc-cpf/swagger-v2.json/swagger_view ]
            */
-            if (await service.Validator(value))
+            if (service.Validator(value))
            {
                Console.WriteLine("Valid");
              //Console.ReadKey(); /* to continue open after execute. */
                return;
            }
            Console.WriteLine("Invalid");
        }
    }
}
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## IDE

The `.sln` is present for edit it on Visual Studio 2022.

## License
[MIT](https://choosealicense.com/licenses/mit/)
