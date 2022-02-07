using Bogus;
using Bogus.DataSets;
using Prjslnback.Domain.Entities;
using Prjslnback.Services.DTO;

namespace Prjslnback.Tests.Fixtures
{
    public class PasswordFixture
    {
        public static string[] Password = { "@Ca123456789147852", "Ca123456789147852", "@Ca12345", "@A123456789147852", "@a123456789147852", "@Ca123456789147852AAA", "@Ca123456789147852aaa", "@Ca123456789147852aaaAAAA" };

        public static EPassword CreateValidPassword()
        {
            return new EPassword(password: new Internet().Password());
        }

        public static EPasswordDTO CreatePasswordDTO(bool newId = false)
        {
            return new EPasswordDTO
            {
                Id = newId ? new Randomizer().Int(0, 1000) : 0,
                Password = Password[0]
            };
        }

        public static EPasswordDTO ValidatorDTO(bool newId = false)
        {
            return new EPasswordDTO
            {
                Id = newId ? new Randomizer().Int(0, 1000) : 0,
                Password = Password[0]
            };
        }

        public static EPasswordDTO CreateInvalidPasswordDTO()
        {
            return new EPasswordDTO
            {
                Id = 0,
                Password = ""
            };
        }
    }
}
