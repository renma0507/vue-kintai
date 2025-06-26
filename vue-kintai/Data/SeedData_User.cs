using vue_kintai.Models;
namespace vue_kintai.Data
{
    public class SeedData_User
    {
        public static void Initialize(AppDbContext context) // 初期化メソッド
        {
            // Booksテーブルにデータが存在しない場合のみ実行
            if (!context.User.Any())
            {
                //ユーザー情報と連結する属性を作成
                var user1 = new User
                {
                    Name = "山田",
                    Employ = "syain",

                };
                var attend1 = new AttendTime
                {
                   
                    Status = "attend",
                    Date = "06/22",
                    Time = "11:00"
                };

                context.User.Add(user1); // 従業員と出退勤時間をセット
                context.AttendTime.Add(attend1);
                context.SaveChanges(); // データベースに保存
            }
        }
    }
}
