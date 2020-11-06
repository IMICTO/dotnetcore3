namespace Session03.MockSample
{
    public class TestProtected
    {
        protected virtual int GetInt()
        {
            return 1;
        }
    }
    public enum DbEngine
    {
        Mongo,
        SqlServer
    }
    public class GetDiscountValueService
    {
        private readonly ICustomerRepository customerRepository;
        
        public GetDiscountValueService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public int Execute(int customerId)
        {
            var customer = customerRepository.Get(customerId);
            customerRepository.UsedCount += 1;
            switch (customer.CustomerType)
            {
                case CustomerType.Usual:
                    return 1000;
                case CustomerType.Silver:
                    return 2000;
                case CustomerType.Gold:
                    return 10000;
            }
            return 0;
        }
        public Customer GetCustomer(int customerId, DbEngine dbEngine)
        {
            Customer customer = new Customer();
            switch (dbEngine)
            {
                case DbEngine.Mongo:
                    customer = customerRepository.GetFromMongoDb(customerId);
                    break;
                case DbEngine.SqlServer:
                    customer = customerRepository.GetFromSqlServer(customerId);                    break;

            }
            return customer;
        }
        public bool IsValidCustomer(int customerId)
        {
            customerRepository.IsValidCustomer(out bool temp);
            return temp;
        }
    }
}
