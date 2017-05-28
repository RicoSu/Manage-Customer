namespace ManageCustomer.Backend.Models
{
    //[Table("CustomerAddresses")]
    public sealed class CustomerAddress : Backend.Models.Address
    {
        public int Id { get; set; }

        //[Required]
        public Customer Customer { get; set; }
    }
}
