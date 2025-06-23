using Google.Cloud.Firestore;
using vue_kintai.Models;

namespace vue_kintai.Data
{
    public class FirebaseDataService 
    {
        private readonly FirestoreDb _firestore;

        public FirebaseDataService(FirestoreDb firestore)
        {
            _firestore = firestore;
        }

        public async Task AddUserAsync(User user)
        {
            CollectionReference users = _firestore.Collection("users");
            await users.AddAsync(user);
        }

    }
}
