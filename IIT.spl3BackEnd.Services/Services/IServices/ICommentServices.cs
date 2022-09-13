using Common.DTOS;
using IIT.spl3Backend.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3Backend.Services.Services.IServices
{
    public interface ICommentServices
    {
        Task<IEnumerable<CommentDTO>> AddComment(IEnumerable<CommentDTO> comments);
        Task<IEnumerable<CommentDTO>> GetAllComments();
    }
}
