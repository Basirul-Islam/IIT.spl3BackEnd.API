using Common.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3BackEnd.Helper
{
    public interface IPythonService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsFromAPI();
        Task<IEnumerable<CommentWithSPamPredictionDTO>> GetSpamCommentsFromAPI(IEnumerable<CommentDTO> comments);
    }
}
