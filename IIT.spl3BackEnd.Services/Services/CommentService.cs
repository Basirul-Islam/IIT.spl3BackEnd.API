using AutoMapper;
using Common.DTOS;
using IIT.spl3Backend.DB.Models;
using IIT.spl3Backend.Repositories.ICommentRepositories;
using IIT.spl3Backend.Services.Services.IServices;

namespace IIT.spl3Backend.Services.Services
{
    public class CommentService: ICommentServices
    {
        private readonly ICommentRepository _commentRepository;

        private readonly IMapper _mapper;


        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<CommentDTO>> AddComment(IEnumerable<CommentDTO> comments)
        {
            
           await _commentRepository.AddComment(_mapper.Map<IEnumerable<Comment>>(comments));
            return comments;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllComments()
        {
            IEnumerable<Comment> comments = await _commentRepository.GetAllComments();
            IEnumerable<CommentDTO> commentsDto = _mapper.Map<IEnumerable<CommentDTO>>(comments);
            return commentsDto;
        }
    }
}
