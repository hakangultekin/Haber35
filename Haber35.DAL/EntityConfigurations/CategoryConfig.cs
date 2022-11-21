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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(x => x.CreatorUser).WithMany(x => x.Categories).HasForeignKey(x => x.CreatorUserId);
            builder.HasMany(x => x.Articles).WithMany(x => x.Categories);
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
        }
    }
}
