using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;

namespace Session06.Relational.UI
{
    public class Address
    {
        public string AddressLine { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        //[InverseProperty("Writer02")]
        public List<Book> AsWriter01 { get; set; }
        //[InverseProperty("Writer01")]

        public List<Book> AsWriter02 { get; set; }
        public Address Address { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
        //[ForeignKey("Writer01")]
        public int Writer01MyId { get; set; }
        //[ForeignKey("Writer01MyId")]
        public Person Writer01 { get; set; }

        public int Writer02Id { get; set; }
        public Person Writer02 { get; set; }

    }
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasOne(c => c.Address).WithOne().IsRequired();
            builder.HasMany(c => c.AsWriter01).WithOne(c => c.Writer01).OnDelete(DeleteBehavior.SetNull);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
