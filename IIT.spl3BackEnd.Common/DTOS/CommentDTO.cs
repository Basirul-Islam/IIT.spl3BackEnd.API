using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOS
{
    public class CommentDTO
    {

        [JsonProperty("Id")]
        public string commentId { get; set; }
        [JsonProperty("Comment")]
        public string CommentBody
        {
            get; set;
        }
    }
}
