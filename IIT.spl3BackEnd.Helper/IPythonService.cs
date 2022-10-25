using Common.DTOS;
using IIT.spl3BackEnd.Common.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3BackEnd.Helper
{
    public interface IPythonService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsFromAPI(URLDto url);
        Task<IEnumerable<CommentWithSPamPredictionDTO>> GetSpamCommentsFromAPI(URLDto url);

        Task<IEnumerable<ReportDto>> GetRepotsFromAPI();
    }
}
