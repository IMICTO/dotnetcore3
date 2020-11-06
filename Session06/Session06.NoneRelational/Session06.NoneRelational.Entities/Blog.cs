using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Session06.NoneRelational.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public Person Person { get; set; }

    }
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }

    }
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
