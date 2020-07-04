using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace truckapi
{
    public class FileServices
    {
        public static async Task<String> getFile(Stream fileStream,String fileName)
        {
            var task = new Firebase.Storage.FirebaseStorage("hci-project-281007.appspot.com")
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
