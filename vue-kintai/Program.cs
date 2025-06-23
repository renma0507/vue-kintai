using vue_kintai.Data;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

// FirebaseプロジェクトIDの取得
string projectId = builder.Configuration["vue-test1-2d4c2"];

// FirestoreDbのDI登録
builder.Services.AddSingleton(provider => {
    var credential = GoogleCredential.GetApplicationDefault();
    return new FirestoreDbBuilder
    {
        ProjectId = projectId,
        Credential = credential
    }.Build();
});

// Firebase用のサービスクラスを登録
builder.Services.AddScoped< FirebaseDataService>();

// 残りの設定（同じ）
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// CORSポリシー（変更なし）
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// 設定（変更なし）
if (app.Environment.IsDevelopment())
{

}

app.UseCors("AllowVueApp");
app.MapControllers();

// Firebaseの初期化（必要に応じて）
//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider.GetRequiredService<IDataService>();
//}

app.Run();
