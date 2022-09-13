using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTOS;
using IIT.spl3Backend.DB.Models;

namespace IIT.spl3Backend.Services.Mappers
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
        
    }
}
