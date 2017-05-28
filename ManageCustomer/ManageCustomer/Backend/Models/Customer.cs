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

        public string Anrede { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Vorname { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Name { get; set; }

        public string Zusatz { get; set; }

        public string Firma { get; set; }

        public string Telefon { get; set; }

        public string Mobil { get; set; }

        public string Fax { get; set; }

        public string Mail { get; set; }

        //[StringLength(250)]
        public string Bemerkung { get; set; }

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

                if (columnName == "Vorname")
                {
                    if (string.IsNullOrEmpty(Vorname))
                    {
                        result = "Es muss zwingend ein Vorname eingegeben werden";
                    }
                }
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                    {
                        result = "Es muss zwingend ein Name eingegeben werden";
                    }
                }
                //if (columnName == "Fax")
                //{
                //    try
                //    {
                //        var cleannumber = Fax.Trim();
                //        var dbnumber = Convert.ToInt32(cleannumber);
                //    }
                //    catch (Exception)
                //    {
                //        result = "Die Nummer darf nur aus Zahlen bestehen";
                //    }
                //}

                return result;
            }
        }
        #endregion
    }
}
