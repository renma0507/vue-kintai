using vue_kintai.Data;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

var builder = WebApplication.CreateBuilder(args);

// Firebase�v���W�F�N�gID�̎擾
string projectId = builder.Configuration["vue-test1-2d4c2"];

// FirestoreDb��DI�o�^
builder.Services.AddSingleton(provider => {
    var credential = GoogleCredential.GetApplicationDefault();
    return new FirestoreDbBuilder
    {
        ProjectId = projectId,
        Credential = credential
    }.Build();
});

// Firebase�p�̃T�[�r�X�N���X��o�^
builder.Services.AddScoped< FirebaseDataService>();

// �c��̐ݒ�i�����j
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// CORS�|���V�[�i�ύX�Ȃ��j
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// �ݒ�i�ύX�Ȃ��j
if (app.Environment.IsDevelopment())
{

}

app.UseCors("AllowVueApp");
app.MapControllers();

// Firebase�̏������i�K�v�ɉ����āj
//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider.GetRequiredService<IDataService>();
//}

app.Run();
