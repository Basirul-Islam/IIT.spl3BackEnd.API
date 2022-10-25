using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3BackEnd.Common.DTOS
{
    public class ReportDto
    {
        [JsonProperty("model_name")]
        public string ModelName { get; set; }
        [JsonProperty("accuracy")]
        public string Accuracy {get; set;}
        [JsonProperty("f1Score")]
        public string F1Score { get; set; }
        [JsonProperty("precision")]
        public string Precision {get; set;}
        [JsonProperty("recall")]
        public string Recall { get; set; }
       /* [JsonProperty("confusionMetrics")]
        public int [] ConfusionMetrics { get; set; }*/
    }
}
