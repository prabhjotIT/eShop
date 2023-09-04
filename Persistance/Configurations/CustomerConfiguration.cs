using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                customerId=>customerId.Value,
                value=>new CustomerId(value));//this is what i have to do in order to work with strong type ID's 
            //in EF core, this explains how we write data in database and how we read data form database 
            builder.Property(name=>name.Name).HasMaxLength(100);
            builder.Property(email=>email.Email).HasMaxLength(255);
            builder.HasIndex(email=>email.Email).IsUnique();//these are all configuration which will be used in order to EF core to figure out how database must be created 
        }
    }
}
