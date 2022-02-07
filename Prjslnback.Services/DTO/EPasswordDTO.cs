using System.Text.Json.Serialization;

namespace Prjslnback.Services.DTO
{
    public class EPasswordDTO
    {
        public long Id { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public EPasswordDTO()
        { }

        public EPasswordDTO(long id, string password)
        {
            Id = id;
            Password = password;
        }
    }
}
