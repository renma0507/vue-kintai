using vue_kintai.Data;
using Google.Cloud.Firestore;

namespace vue_kintai.Models
{
    public class User
    {
        [FirestoreDocumentId] // ドキュメントIDをマッピング
        public string Id { get; set; }
    }
}
