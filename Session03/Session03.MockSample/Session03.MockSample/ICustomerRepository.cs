namespace Session03.MockSample
{
    public interface IPropertyHolder
    {
        int CustomerId { get; set; }
    }
    public interface IPropertyProxy
    {
        IPropertyHolder IPropertyHolder { get; set; }
    }
    public interface ICustomerRepository
    {
        Customer Get(int id);
        Customer GetFromMongoDb(int id);
        Customer GetFromSqlServer(int id);

        void IsValidCustomer(out bool result);
        bool IsValidCustomer(int id);
        IPropertyProxy IPropertyProxy { get; set; }
        int UsedCount { get; set; }
    }
}
