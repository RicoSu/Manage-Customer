using System.ComponentModel;

namespace ManageCustomer.Backend.Models
{
    //[Table("Addresses")]
    public class Address : IDataErrorInfo
    {
        //Rechnungsadresse, Lieferadresse
        public AddressType Adressart { get; set; }

        //[Required]
        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string PostalCode { get; set; }

        //[Required]
        public string Place { get; set; }

        public string Country { get; set; }

        public string Comment { get; set; }

        #region IDataErrorInfo
        //[NotMapped]
        public string Error
        {
            get { return null; }
        }

        //[NotMapped]
        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "Street")
                {
                    if (string.IsNullOrEmpty(Street))
                    {
                        result = "A street name must be specified";
                    }
                }
                if (columnName == "Place")
                {
                    if (string.IsNullOrEmpty(Place))
                    {
                        result = "A place must be specified";
                    }
                }

                return result;
            }
        }
        #endregion
    }

    /// <summary>
    /// Zeigt zu welcher Tabelle die Addresse gehört
    /// </summary>
    public enum AddressOwner
    {
        Customer,
        Supplier,
        Employee
    }

    /// <summary>
    /// Liste aller Arten von Adressen
    /// </summary>
    public enum AddressType
    {
        GeneralAddress,
        BillingAddress,
        DeliveryAddress
    }
}
