using Common.DTOS;
using System.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using IIT.spl3BackEnd.Common.DTOS;
using System.Text.Json;

namespace IIT.spl3BackEnd.Helper
{
    public class PythonService : IPythonService
    {
        public async Task<IEnumerable<CommentDTO>> GetCommentsFromAPI(URLDto url)
        {
            //String Videourl = "https://www.youtube.com/watch?v=Uccvf3peELQ";
            //string path = HttpUtility.UrlEncode(Videourl);
            //var url = "http://127.0.0.1:8000/video_comments/" + "&url=" /*+ path*/;

            /* var request = new HttpRequestMessage
             {
                 Method = HttpMethod.Get,
                 RequestUri = new Uri("http://127.0.0.1:8000/get_comments/"),
                 //Content = url;
                 Content = new StringContent(url.URL, Encoding.UTF8, URLDto),
             };*/

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            String payload = System.Text.Json.JsonSerializer.Serialize<URLDto>(url, opt);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            var RequestUri = "http://127.0.0.1:8000/get_comments/";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(RequestUri, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            List<CommentDTO> commentList = JsonConvert.DeserializeObject<List<CommentDTO>>(responseBody);
            Console.WriteLine(commentList);
            return commentList.AsEnumerable();
        }

        public async Task<IEnumerable<CommentWithSPamPredictionDTO>> GetSpamCommentsFromAPI(URLDto url)
        {

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            String payload = System.Text.Json.JsonSerializer.Serialize<URLDto>(url, opt);

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            var RequestUri = "http://127.0.0.1:8000/spam_comments/";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(RequestUri, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            List<CommentWithSPamPredictionDTO> commentList = JsonConvert.DeserializeObject<List<CommentWithSPamPredictionDTO>>(responseBody);
            Console.WriteLine(commentList);
            return commentList.AsEnumerable();
        }
    }
}
