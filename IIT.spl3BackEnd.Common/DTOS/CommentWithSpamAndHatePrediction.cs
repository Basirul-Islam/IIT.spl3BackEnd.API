using Common.DTOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3BackEnd.Common.DTOS
{
    public class CommentWithSpamAndHatePrediction: CommentWithSPamPredictionDTO
    {
        [JsonProperty("hate_prediction")]
        public string isHate { get; set; }

        [JsonProperty("combine_label")]
        public string combine_label { get; set; }
    }
}
