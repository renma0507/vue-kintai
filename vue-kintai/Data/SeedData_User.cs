using vue_kintai.Models;
namespace vue_kintai.Data
{
    public class SeedData_User
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.User.Any())
            {
                var user = new User
                {
                    Name = "山田",
                    Employ = "syain",
                    AttendTimes = new List<AttendTime>
                    {
                        new AttendTime
                        {
                            Status = "attend",
                            Date = "2025/06/21",
                            Time = "11:00"
                        },
                        new AttendTime
                        {
                            Status = "attend",
                            Date = "2025/06/22",
                            Time = "09:30"
                        }
                    }
                };
                context.User.Add(user);
                context.SaveChanges();
            }
        }
    }
}
