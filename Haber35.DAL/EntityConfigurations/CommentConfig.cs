using Haber35.CORE.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.DAL.EntityConfigurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId);
            builder.HasOne(x => x.ModifierUser).WithMany(x => x.ModifiedComments).HasForeignKey(x => x.ModifierUserId);
            builder.HasOne(x => x.DeletoryUser).WithMany(x => x.DeletedComments).HasForeignKey(x => x.DeletoryUserId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

        }
    }
}
