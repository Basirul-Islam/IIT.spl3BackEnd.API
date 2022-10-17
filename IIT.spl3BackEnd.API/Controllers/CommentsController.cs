using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Web;
using Newtonsoft.Json;
using Common.DTOS;
using IIT.spl3Backend.Services.Services.IServices;

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
        /*[HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserSignUp([FromBody] UserSignUpDTO User)
        {
            
        }
        //This route return a token and user name by  UserTokenDTO
        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> UserSignIn([FromBody] UserSignINDTO user)
        {

            //var User = _mapper.Map<Author>(user);
            var User = await _UserServices.UserSignIn(user);
            if (User != null)
            {
                //user.Role = Roles.admin |  
                *//* user.Role = Roles.admin | Roles.user;*//*
                //user.Role = User.Role;
                return Ok(new UserTokenDTO
                {
                    userName = User.userName,
                    Token = _tokenService.createToken(User)
                });
            }
            else return NotFound("Wrong Username or Password");
        }*/
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            /*string Videourl = "https://www.youtube.com/watch?v=Uccvf3peELQ";
            string path = HttpUtility.UrlEncode(Videourl);
            var url = "http://127.0.0.1:8000/video_comments/" + "&url=" *//*+ path*//*;


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            List<CommentDTO> commentList = JsonConvert.DeserializeObject<List<CommentDTO>>(responseBody);
            Console.WriteLine(commentList);
            
            IEnumerable<CommentDTO> comments = await _commentServices.AddComment(commentList.AsEnumerable());


            Console.WriteLine(comments);*/
            //_commentServices.AddComment();
            //IEnumerable<CommentWithSPamPredictionDTO> commentWithSPamPredictionDTOs =await _commentServices.AddComment();
            IEnumerable<CommentDTO> commentWithSPamPredictionDTOs = await _commentServices.AddComment();
            //return Ok(commentWithSPamPredictionDTOs);
            return Ok(commentWithSPamPredictionDTOs);
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
