using System.ComponentModel;

namespace ManageCustomer.Backend.Models
{
    //[Table("Addresses")]
    public class Address : IDataErrorInfo
    {
        //Rechnungsadresse, Lieferadresse
        public AddressType Adressart { get; set; }

        //[Required]
        public string Strasse { get; set; }

        public string Hausnummer { get; set; }

        public string Postleitzahl { get; set; }

        //[Required]
        public string Ort { get; set; }

        public string Land { get; set; }

        public string Bemerkung { get; set; }

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

                if (columnName == "Strasse")
                {
                    if (string.IsNullOrEmpty(Strasse))
                    {
                        result = "Es muss zwingend ein Strasse eingegeben werden";
                    }
                }
                if (columnName == "Ort")
                {
                    if (string.IsNullOrEmpty(Ort))
                    {
                        result = "Es muss zwingend ein Ort eingegeben werden";
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
        Hauptadresse,
        Rechnungsadresse,
        Lieferadresse
    }
}
