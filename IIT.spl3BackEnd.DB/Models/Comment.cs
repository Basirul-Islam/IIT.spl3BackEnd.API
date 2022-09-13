//using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace IIT.spl3Backend.DB.Models
{

    [Serializable]
    [DataContract(IsReference = true)]
    public class Comment
    {
        
        public int Id { get; set; }
        public string commentId { get; set; }
        public string CommentBody { get; set; }
            
    }
}
