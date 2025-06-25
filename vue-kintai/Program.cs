using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using vue_kintai.Data;

var builder = WebApplication.CreateBuilder(args);

//コントローラーとJSON循環参照許可設定を登録
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // 循環参照（User → AttendTime → User...）を許可する設定
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


// 🔧 SQLiteデータベースを使用するように設定（app.db というファイルに保存される）
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();             // コントローラー機能
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔓 CORSポリシーの定義：Vue.js（http://localhost:5173）からのアクセスを許可
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowVueApp");

app.MapControllers();

// DB初期化（マイグレーション不要、テーブル作成＆初期データ登録）
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    SeedData_User.Initialize(db);

}

app.Run();