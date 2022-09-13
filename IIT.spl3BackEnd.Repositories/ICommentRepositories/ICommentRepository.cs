using IIT.spl3Backend.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3Backend.Repositories.ICommentRepositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> AddComment(IEnumerable<Comment> comments);
        Task<IEnumerable<Comment>> GetAllComments();    
    }
}
