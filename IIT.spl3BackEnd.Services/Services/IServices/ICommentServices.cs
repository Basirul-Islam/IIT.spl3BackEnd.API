using Common.DTOS;
using IIT.spl3Backend.DB.Models;
using IIT.spl3BackEnd.Common.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3Backend.Services.Services.IServices
{
    public interface ICommentServices
    {
        Task<IEnumerable<CommentDTO>> Getcomments(URLDto URL);
        Task<IEnumerable<CommentWithSPamPredictionDTO>> GetSpamLabeledcomments(URLDto URL);
        Task<IEnumerable<CommentDTO>> GetAllComments();
        Task<IEnumerable<ReportDto>> GetReports();
        Task<bool> isValidUrl(string url);
    }
}
