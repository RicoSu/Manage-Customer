using System.ComponentModel;

namespace ManageCustomer.Backend.Models
{
    //[Table("Customers")]
    public sealed class Customer : IDataErrorInfo
    {
        //[Required]
        //[Index(IsUnique = true)]
        // Id = Kundennummer
        public int Id { get; set; }

        public string Salutation { get; set; }

        //[Required]
        //[StringLength(50)]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }

        public string Addition { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Mobil { get; set; }

        public string Fax { get; set; }

        public string Mail { get; set; }

        //[StringLength(250)]
        public string Comment { get; set; }

        public bool Deleted { get; set; }

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

                if (columnName == "Prename")
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        result = "A first name must be specified";
                    }
                }
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                    {
                        result = "A name must be specified";
                    }
                }

                return result;
            }
        }
        #endregion
    }
}
