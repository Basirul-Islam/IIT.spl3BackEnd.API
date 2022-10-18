using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Web;
using Newtonsoft.Json;
using Common.DTOS;
using IIT.spl3Backend.Services.Services.IServices;
using IIT.spl3BackEnd.Common.DTOS;

namespace BlogSiteBackEnd.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private readonly ICommentServices _commentServices;
        private readonly IConfiguration _config;

        public CommentsController(IConfiguration config, ICommentServices commentServices /*IUserRepository UserRepository, IUserservice UserService, IMapper mapper, IRegexUtilities regexUtilities, ITokenService tokenService*/)
        {
            _config = config;
            _commentServices = commentServices; 
/*            _regexUtilities = regexUtilities;
            _UserServices = UserService;
            _mapper = mapper;
            _tokenService = tokenService;*/
        }
        
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] URLDto uRLDto)
        {   
            IEnumerable<CommentDTO> commentWithSPamPredictionDTOs = await _commentServices.Getcomments(uRLDto);
            return Ok(commentWithSPamPredictionDTOs);
        }

        [HttpPost("GetAllSpamLabledComments")]
        public async Task<IActionResult> GetAllSpamLabledComments([FromBody] URLDto uRLDto)
        {
            IEnumerable<CommentWithSPamPredictionDTO> commentWithSPamPredictionDTOs = await _commentServices.GetSpamLabeledcomments(uRLDto);
            return Ok(commentWithSPamPredictionDTOs);
        }
        [HttpPost("CeckIsValidUrl")]
        public async Task<IActionResult> CeckIsValidUrl([FromBody] URLDto uRLDto)
        {
            return Ok(await _commentServices.isValidUrl(uRLDto.URL));
        }

        [HttpGet("GetSpamComment")]
        public async Task<IActionResult> GetSpamComment()
        {
            /*var url = "http://127.0.0.1:8000/detect_spam/bashir";


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            List<object> prediction = JsonConvert.DeserializeObject<List<object>>(responseBody);
            int isSpam = (int)(long)prediction.FirstOrDefault();
            Console.WriteLine(isSpam);*/
            //CommentWithSPamPredictionDTO commentWithSPamPrediction = JsonConvert.DeserializeObject<CommentWithSPamPredictionDTO>(responseBody);
            //Console.WriteLine(commentWithSPamPrediction);
            //List<CommentDTO> commentList = JsonConvert.DeserializeObject<List<CommentDTO>>(responseBody);
            //Console.WriteLine(commentList);

            //IEnumerable<CommentDTO> comments = await _commentServices.AddComment(commentList.AsEnumerable());


            //Console.WriteLine(comments);
            IEnumerable<CommentDTO> commentDTOs = await _commentServices.GetAllComments();
            string x = "controller is not uploaded";
            return Ok(commentDTOs);
        }
    }
}
/*        
 {
    "name": "Bashir",
    "UserName": "bashir",
    "Password": "12345678@",
    "Email": "bashir@gmail.com"
 }

// Admin Login
{
    
    "UserName": "~admin",
    "Password": "@Password"
    
}
         
         */
