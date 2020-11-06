namespace EfCoreNew.Model
{
    public class Address
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string Phone { get; set; }
        public string AddressLine { get; set; }

    }
}
