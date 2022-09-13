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
        [JsonProperty("comment")]
        public string comment { get; set; }
        [JsonProperty("prediction")]
        public List<object> prediction { get; set; }
    }
}
