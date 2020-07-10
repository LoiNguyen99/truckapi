using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Firebase.Auth;

namespace truckapi
{
    public class FileServices
    {
        public static async Task<String> getFile(Stream fileStream, String fileName)
        {
            String apiKey = "AIzaSyD4witV5uIhlnYtWPZ2ZPNfQNh9V-0_RBU";
            var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
            var login = await auth.SignInAnonymouslyAsync();
            var task = new Firebase.Storage.FirebaseStorage("hci-project-281007.appspot.com",
                new Firebase.Storage.FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(login.FirebaseToken)
                })
                .Child("image")
                .Child(fileName)
                .PutAsync(fileStream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            // Await the task to wait until upload is completed and get the download url
            return await task;
        }
    }
}
