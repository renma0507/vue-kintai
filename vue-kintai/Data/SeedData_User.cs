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
                var user = new User
                {
                    Name = "山田",
                    Employ = "syain",
                    AttendTime = new AttendTime
                    {
                        Status = "attend",
                        Date = "2025/06/21",
                        Time = "11:00",

                    }

                };

                context.User.Add(user); // 従業員と出退勤時間をセット
                context.SaveChanges(); // データベースに保存
            }
        }
    }
}
