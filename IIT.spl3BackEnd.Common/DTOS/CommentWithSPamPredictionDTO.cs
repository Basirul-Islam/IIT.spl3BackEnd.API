using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOS
{
    public class CommentWithSPamPredictionDTO
    {
        [JsonProperty("Id")]
        public string commentId { get; set; }
        [JsonProperty("Comment")]
        public string CommentBody
        {
            get; set;
        }
        [JsonProperty("AuthorDisplayName")]
        public string AuthorDisplayName { get; set; }
        [JsonProperty("ProfileImageUrl")]
        public string ProfileImageUrl
        {
            get; set;
        }
        [JsonProperty("prediction")]
        public string isSpam { get; set; }
    }
}
