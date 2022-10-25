using System.Web;
using Newtonsoft.Json;
using AutoMapper;
using Common.DTOS;
using IIT.spl3Backend.DB.Models;
using IIT.spl3Backend.Repositories.ICommentRepositories;
using IIT.spl3Backend.Services.Services.IServices;
using IIT.spl3BackEnd.Helper;
using IIT.spl3BackEnd.Common.DTOS;
using System.Net;

namespace IIT.spl3Backend.Services.Services
{
    public class CommentService: ICommentServices
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPythonService _pythonService;
        private readonly IMapper _mapper;


        public CommentService(ICommentRepository commentRepository, IPythonService pythonService , IMapper mapper)
        {
            _commentRepository = commentRepository;
            _pythonService = pythonService; 
            _mapper = mapper;

        }
        public async Task<IEnumerable<CommentDTO>> Getcomments(/*IEnumerable<CommentDTO> comments*/ URLDto URL)
        {

            IEnumerable<CommentDTO> comments = await _pythonService.GetCommentsFromAPI(URL);
            await _commentRepository.AddComment(_mapper.Map<IEnumerable<Comment>>(comments));
            return comments;
            //IEnumerable<CommentWithSPamPredictionDTO> commentWithSPamPredictions = await _pythonService.GetSpamCommentsFromAPI(comments);
            //await _commentRepository.AddComment(_mapper.Map<IEnumerable<Comment>>());
            //Console.WriteLine(commentWithSPamPredictions);
            //return commentWithSPamPredictions;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllComments()
        {
            IEnumerable<Comment> comments = await _commentRepository.GetAllComments();
            IEnumerable<CommentDTO> commentsDto = _mapper.Map<IEnumerable<CommentDTO>>(comments);
            return commentsDto;
        }

        public async Task<IEnumerable<CommentWithSPamPredictionDTO>> GetSpamLabeledcomments(URLDto URL)
        {
            return await _pythonService.GetSpamCommentsFromAPI(URL);
            //throw new NotImplementedException();
        }

        public async Task<bool> isValidUrl(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "HEAD";
                HttpWebResponse Response = (HttpWebResponse)request.GetResponse();
                if (Response.ResponseUri.ToString().Contains("https://www.youtube.com/watch?")) return true;
                else return false;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<ReportDto>> GetReports()
        {
            return await _pythonService.GetRepotsFromAPI();
        }
    }
}
