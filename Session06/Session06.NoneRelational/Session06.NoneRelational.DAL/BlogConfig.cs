using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session06.NoneRelational.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session06.NoneRelational.DAL
{
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(c => c.Person).Ignore();
        }
    }
}
