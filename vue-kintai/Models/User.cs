
using System.Text.Json.Serialization;

namespace vue_kintai.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Employ { get; set; }

        [JsonIgnore]
        public ICollection<AttendTime>? AttendTime { get; set; }

    }
}
