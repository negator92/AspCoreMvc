using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("https://ya.ru");
            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent)
                => antecedent.Result.Content.Headers.ContentLength);
        }
    }
}