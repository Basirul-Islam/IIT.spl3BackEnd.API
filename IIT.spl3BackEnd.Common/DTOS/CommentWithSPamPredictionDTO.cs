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
        public string commentId { get; set; }
        public string CommentBody { get; set; }
        public int isSpam { get; set; }
    }
}
