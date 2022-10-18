using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3BackEnd.Common.DTOS
{
    public class URLDto
    {
        [JsonProperty("Url")]
        public string URL { get; set; }
    }
}
