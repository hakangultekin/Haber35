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
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasOne(x => x.CreatorUser).WithMany(x => x.Articles).HasForeignKey(x => x.CreatorUserId);
            builder.HasOne(x => x.ModifierUser).WithMany(x => x.Articles).HasForeignKey(x => x.ModifierUserId);
            builder.HasOne(x => x.DeletoryUser).WithMany(x => x.Articles).HasForeignKey(x => x.DeletoryUserId);
            builder.HasMany(x => x.Comments).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);
            builder.HasMany(x => x.Categories).WithMany(x => x.Articles);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Content).IsRequired();
            builder.Ignore(x => x.ViewTime);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            
            

        }
    }
}
