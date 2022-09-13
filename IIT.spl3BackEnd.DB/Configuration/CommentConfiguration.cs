using IIT.spl3Backend.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IIT.spl3Backend.DB.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(Comment => Comment.Id);
            builder.Property(Comment => Comment.Id).IsRequired();
            builder.Property(Comment => Comment.CommentBody).IsRequired();
        }

    }
}
