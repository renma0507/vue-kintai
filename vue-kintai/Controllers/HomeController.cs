using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using vue_kintai.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace vue_kintai.Controllers
{
    public class HomeController : Controller
    {
        static bool firebaseInitialized = false;

        public HomeController()
        {
            if (!firebaseInitialized)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("../vue-test1-2d4c2-firebase-adminsdk-fbsvc-f95bf5bb51.json")
                });
                firebaseInitialized = true;
            }
        }
    }

}
