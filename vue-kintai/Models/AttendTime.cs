

namespace vue_kintai.Models
{
    public class AttendTime
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }



    }
}
