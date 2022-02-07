using Prjslnback.Core.Exceptions;
using Prjslnback.Domain.Validators;
using System.Collections.Generic;

namespace Prjslnback.Domain.Entities
{
    public class EPassword : Base
    {
        //Propriedades
        public string Password { get; private set; }

        protected EPassword() { }

        public EPassword(string password)
        {
            Password = password;
            _errors = new List<string>();

            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new PasswordValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
