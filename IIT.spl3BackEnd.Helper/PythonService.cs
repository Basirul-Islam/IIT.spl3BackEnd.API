using Common.DTOS;
using System.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IIT.spl3BackEnd.Helper
{
    public class PythonService : IPythonService
    {
        public async Task<IEnumerable<CommentDTO>> GetCommentsFromAPI()
        {
            string Videourl = "https://www.youtube.com/watch?v=Uccvf3peELQ";
            string path = HttpUtility.UrlEncode(Videourl);
            var url = "http://127.0.0.1:8000/video_comments/" + "&url=" /*+ path*/;


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            List<CommentDTO> commentList = JsonConvert.DeserializeObject<List<CommentDTO>>(responseBody);
            Console.WriteLine(commentList);
            return commentList.AsEnumerable();
        }

        public async Task<IEnumerable<CommentWithSPamPredictionDTO>> GetSpamCommentsFromAPI(IEnumerable<CommentDTO> comments)
        {
            List<int> arr = new List<int>();
            List<CommentWithSPamPredictionDTO> commentWithSPamPredictionDTOs = new List<CommentWithSPamPredictionDTO>();
            foreach(CommentDTO comment in comments)
            {
                if(Regex.IsMatch(comment.CommentBody,
                @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)"))
                {
                    CommentWithSPamPredictionDTO commentWithSPamPredictionDTO1 = new CommentWithSPamPredictionDTO()
                    {
                        commentId = comment.commentId,
                        CommentBody = comment.CommentBody,
                        isSpam = 1,
                    };
                    commentWithSPamPredictionDTOs.Add(commentWithSPamPredictionDTO1);
                    continue;
                }
                if(Uri.IsWellFormedUriString(comment.CommentBody, UriKind.RelativeOrAbsolute))
                {
                    CommentWithSPamPredictionDTO commentWithSPamPredictionDTO1 = new CommentWithSPamPredictionDTO()
                    {
                        commentId = comment.commentId,
                        CommentBody = comment.CommentBody,
                        isSpam = 1,
                    };
                    commentWithSPamPredictionDTOs.Add(commentWithSPamPredictionDTO1);
                    continue;
                }
                var url = "http://127.0.0.1:8000/detect_spam/" + comment.CommentBody;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                List<object> prediction = JsonConvert.DeserializeObject<List<object>>(responseBody);
                int isSpam = (int)(long)prediction.FirstOrDefault();
                Console.WriteLine(isSpam);
                arr.Add(isSpam);
                CommentWithSPamPredictionDTO commentWithSPamPredictionDTO = new CommentWithSPamPredictionDTO()
                {
                    commentId = comment.commentId,
                    CommentBody = comment.CommentBody,
                    isSpam = isSpam,
                };
                commentWithSPamPredictionDTOs.Add(commentWithSPamPredictionDTO);
                //commentWithSPamPredictionDTO.CommentBody = comment.CommentBody; 
            }
            Console.WriteLine(arr);
            return commentWithSPamPredictionDTOs.AsEnumerable();
            
        }
    }
}
