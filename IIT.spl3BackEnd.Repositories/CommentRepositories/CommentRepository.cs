using IIT.spl3Backend.DB.Models;
using IIT.spl3Backend.Repositories.ICommentRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIT.spl3Backend.Repositories.CommentRepositories
{
    public class CommentRepository: ICommentRepository
    {
        private readonly DatabaseContext _db;

        public CommentRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Comment>> AddComment(IEnumerable<Comment> comments)
        {
            if (comments == null) throw new ArgumentNullException();
            foreach (Comment comment in comments)
                _db.Comments.Add(comment);
            _db.SaveChanges();
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var comments = _db.Comments.OrderBy(Comment => Comment.Id).ToList();
            return comments;
        }
    }
}
