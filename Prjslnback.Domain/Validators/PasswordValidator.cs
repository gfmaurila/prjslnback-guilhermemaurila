using FluentValidation;
using Prjslnback.Domain.Entities;
using System.Linq;
using System.Text.RegularExpressions;

namespace Prjslnback.Domain.Validators
{
    class PasswordValidator : AbstractValidator<EPassword>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Informe a senha")
                .MinimumLength(15).WithMessage("A senha deve ter no mínimo 15 caracteres.") // Conter no mínimo 15 caracteres.
                .Must(RequiredLowerCase).WithMessage("Senha deve ter pelo menos 1 caracter minúsculo") // No mínimo uma letra minúscula.
                .Must(RequireUppercase).WithMessage("Senha deve ter pelo menos 1 caracter maiúsculo") // No mínimo uma letra maiúscula
                .Must(RequireNonAlphanumeric).WithMessage("Digite pelo menos 1 caracter especial (@,#,_,- e ! ...)") // No mínimo um dos seguintes caracteres especiais: (@,#,_,- e !). 
                .Must(RequireNotRepeated).WithMessage("Não poder ter caracteres repetidos em sequência") // Não poder ter caracteres repetidos em sequência, por exemplo: 1111, aaaa, bbbb, @@@@, BBBB. Prever case-sensitive, por exemplo: A é diferente de a.
                .Must(RequireDigit).WithMessage("Senha deve ter pelo menos 1 número");
        }

        private bool RequireDigit(string password)
        {
            if (password.Any(x => char.IsDigit(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequiredLowerCase(string password)
        {
            if (password.Any(x => char.IsLower(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireUppercase(string password)
        {
            if (password.Any(x => char.IsUpper(x)))
            {
                return true;
            }
            return false;
        }

        private bool RequireNonAlphanumeric(string password)
        {
            if (Regex.IsMatch(password, "(?=.*[@#$%^&+=])"))
            {
                return true;
            }
            return false;
        }

        private bool RequireNotRepeated(string password)
        {
            bool flag = true;
            password = password.ToUpper();
            if (password.Length < 3)
            {
                flag = false;
            }
            else
            {
                int contLetras = 0;
                int contNumeros = 0;

                int tmp = (int)password.ToCharArray()[0];
                foreach (char c in password.ToCharArray())
                {
                    if (((int)c < 127 && (int)c >= 65))
                    {
                        if (tmp == (int)c)
                        {
                            contLetras++;
                        }
                        if (contLetras >= 3) { break; }
                        tmp = (int)c;
                    }
                }

                tmp = (int)password.ToCharArray()[0];
                foreach (char c in password.ToCharArray())
                {
                    if (((int)c < 57 && (int)c >= 48))
                    {
                        if (tmp == (int)c)
                        {
                            contNumeros++;
                        }
                        if (contNumeros >= 4) { break; }
                        tmp = (int)c;
                    }
                }
                if (contLetras >= 3 || contNumeros >= 4)
                {
                    flag = false;
                }
            }

            return flag;
        }
    }
}
