using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ManageCustomer.Backend.Dialogs;
using ManageCustomer.Backend.Models;

namespace ManageCustomer.Backend.DataAccessLayer
{
    internal static class Database
    {
        internal static List<Customer> CustomersTable;
        internal static List<CustomerAddress> AddressesTable;

        internal static void CreateDatabase()
        {
            CustomersTable = new List<Customer>();
            AddressesTable = new List<CustomerAddress>();

            CustomersTable.Add(new Customer { Id = 1, Name = "Suter", FirstName = "Rico", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(355) 660-0673", Phone = "", Addition = ""});
            CustomersTable.Add(new Customer { Id = 2, Name = "Doe", FirstName = "Frank", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(792) 478-2568", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 3, Name = "Feraro", FirstName = "Belinda", Salutation = "Ms.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(892) 440-950", Addition = "" });
            CustomersTable.Add(new Customer { Id = 4, Name = "Cruz", FirstName = "Carley", Salutation = "Ms.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(836) 574-7799", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 5, Name = "Smith", FirstName = "Brice", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(265) 328-7745", Addition = "" });
            CustomersTable.Add(new Customer { Id = 6, Name = "Chapman", FirstName = "Jason", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(651) 569-9030", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 7, Name = "Lindon", FirstName = "Ginny", Salutation = "Ms.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(208) 332-5313", Addition = "" });
            CustomersTable.Add(new Customer { Id = 8, Name = "Santos", FirstName = "Doug", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(710) 820-2069", Addition = "" });
            CustomersTable.Add(new Customer { Id = 9, Name = "Sal", FirstName = "Dave", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(353) 421-4234", Addition = "" });
            CustomersTable.Add(new Customer { Id = 10, Name = "Eisenhower", FirstName = "Clay", Salutation = "", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(531) 925-6150", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 11, Name = "Foye", FirstName = "Branson", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(513) 796-4994", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 12, Name = "Chenkins", FirstName = "Caro", Salutation = "Ms.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(291) 998-0244", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 13, Name = "Crenshaw", FirstName = "Aubin", Salutation = "", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(651) 569-9030", Addition = "" });
            CustomersTable.Add(new Customer { Id = 14, Name = "Crider", FirstName = "Ahmed", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(934) 776-0277", Addition = "" });
            CustomersTable.Add(new Customer { Id = 15, Name = "Ecker", FirstName = "Declan", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(349) 738-7300", Addition = "" });
            CustomersTable.Add(new Customer { Id = 16, Name = "Blackwell", FirstName = "Fred", Salutation = "", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(455) 659-3610", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 17, Name = "Anders", FirstName = "Randy", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(319) 402-4718", Addition = "" });
            CustomersTable.Add(new Customer { Id = 18, Name = "Philips", FirstName = "Willyan", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(455) 659-3610", Phone = "", Addition = "" });
            CustomersTable.Add(new Customer { Id = 19, Name = "Kahn", FirstName = "Kristen", Salutation = "Ms.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "", Phone = "(355) 660-0673", Addition = "" });
            CustomersTable.Add(new Customer { Id = 20, Name = "Gray", FirstName = "Daniel", Salutation = "Mr.", Comment = "", Fax = "", Company = "", Mail = "", Mobil = "(892) 440-9508", Phone = "", Addition = "" });

            var rnd = new Random();

            AddressesTable.Add(new CustomerAddress { Id = 1, Comment = "", Customer = GetSingelCustomerData(1), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Zürich", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Upper Marlborough Loop" });
            AddressesTable.Add(new CustomerAddress { Id = 2, Comment = "", Customer = GetSingelCustomerData(1), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Germany", Place = "Basel", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "North Gadsen Townline" });
            AddressesTable.Add(new CustomerAddress { Id = 3, Comment = "", Customer = GetSingelCustomerData(2), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "USA", Place = "Bern", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Wacouta Path" });
            AddressesTable.Add(new CustomerAddress { Id = 4, Comment = "", Customer = GetSingelCustomerData(3), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Canada", Place = "Geneve", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Brinkwood Canyon" });
            AddressesTable.Add(new CustomerAddress { Id = 5, Comment = "", Customer = GetSingelCustomerData(3), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Austria", Place = "Uster", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "West Slager Mount" });
            AddressesTable.Add(new CustomerAddress { Id = 6, Comment = "", Customer = GetSingelCustomerData(4), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Wetzikon", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "North New Holland Way" });
            AddressesTable.Add(new CustomerAddress { Id = 7, Comment = "", Customer = GetSingelCustomerData(5), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Italy", Place = "Wald", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "South Tib Close" });
            AddressesTable.Add(new CustomerAddress { Id = 8, Comment = "", Customer = GetSingelCustomerData(6), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "France", Place = "Rüti", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "East St Alphege Alley" });
            AddressesTable.Add(new CustomerAddress { Id = 9, Comment = "", Customer = GetSingelCustomerData(6), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Austria", Place = "Rapperswil", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "East Barbers Turnpike" });
            AddressesTable.Add(new CustomerAddress { Id = 10, Comment = "", Customer = GetSingelCustomerData(7), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Hinwil", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "West Milne Cove Causeway" });
            AddressesTable.Add(new CustomerAddress { Id = 11, Comment = "", Customer = GetSingelCustomerData(8), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Canada", Place = "Washington", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "North Bay Club Byway" });
            AddressesTable.Add(new CustomerAddress { Id = 12, Comment = "", Customer = GetSingelCustomerData(8), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "USA", Place = "New York", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Chestnut Manor North" });
            AddressesTable.Add(new CustomerAddress { Id = 13, Comment = "", Customer = GetSingelCustomerData(9), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Germay", Place = "Biel", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Ratekin Quay" });
            AddressesTable.Add(new CustomerAddress { Id = 14, Comment = "", Customer = GetSingelCustomerData(10), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Gunsgen", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "West Havendale Boulevard" });
            AddressesTable.Add(new CustomerAddress { Id = 15, Comment = "", Customer = GetSingelCustomerData(11), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Italy", Place = "Bernadion", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Trowtree Byway" });
            AddressesTable.Add(new CustomerAddress { Id = 16, Comment = "", Customer = GetSingelCustomerData(12), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Austria", Place = "Winterthur", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "South Baroque Lawn" });
            AddressesTable.Add(new CustomerAddress { Id = 17, Comment = "", Customer = GetSingelCustomerData(12), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Sweden", Place = "Zürich", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "North Honey Croft Knoll" });
            AddressesTable.Add(new CustomerAddress { Id = 18, Comment = "", Customer = GetSingelCustomerData(13), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Japan", Place = "Tokyo", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Ledgebrook Trail" });
            AddressesTable.Add(new CustomerAddress { Id = 19, Comment = "", Customer = GetSingelCustomerData(13), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Zürich", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Rivercreek Croft" });
            AddressesTable.Add(new CustomerAddress { Id = 20, Comment = "", Customer = GetSingelCustomerData(14), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Japan", Place = "Wald", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Meroo Byway" });
            AddressesTable.Add(new CustomerAddress { Id = 21, Comment = "", Customer = GetSingelCustomerData(14), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Italy", Place = "Bern", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "South Band Circle" });
            AddressesTable.Add(new CustomerAddress { Id = 22, Comment = "", Customer = GetSingelCustomerData(15), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "USA", Place = "Basel", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Brockswood Quay" });
            AddressesTable.Add(new CustomerAddress { Id = 23, Comment = "", Customer = GetSingelCustomerData(16), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Germay", Place = "Winterthur", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "South Little Joyce Viaduct" });
            AddressesTable.Add(new CustomerAddress { Id = 24, Comment = "", Customer = GetSingelCustomerData(16), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Washington", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "West Golden Rod" });
            AddressesTable.Add(new CustomerAddress { Id = 25, Comment = "", Customer = GetSingelCustomerData(17), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Sweden", Place = "Hinwil", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Southeast Hubbell Quay" });
            AddressesTable.Add(new CustomerAddress { Id = 26, Comment = "", Customer = GetSingelCustomerData(18), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "France", Place = "Rapperswil", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Fumia Boulevard" });
            AddressesTable.Add(new CustomerAddress { Id = 27, Comment = "", Customer = GetSingelCustomerData(18), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Japan", Place = "Uster", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Mascalls Way" });
            AddressesTable.Add(new CustomerAddress { Id = 28, Comment = "", Customer = GetSingelCustomerData(19), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Schweiz", Place = "Hinwil", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Southwest Winding Waye Pike" });
            AddressesTable.Add(new CustomerAddress { Id = 29, Comment = "", Customer = GetSingelCustomerData(20), Adressart = AddressType.GeneralAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "China", Place = "Winterthur", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "North Aksarben Croft" });
            AddressesTable.Add(new CustomerAddress { Id = 30, Comment = "", Customer = GetSingelCustomerData(20), Adressart = AddressType.BillingAddress, HouseNumber = rnd.Next(1, 120).ToString(), Country = "Korea", Place = "Zürich", PostalCode = rnd.Next(1000, 9999).ToString(), Street = "Tybenham Grove" });
        }

#region Customer

        public static void DeleteCustomer(int customerId)
        {
            try
            {
                var itemToRemove = CustomersTable.Single(c => c.Id == customerId);
                CustomersTable.Remove(itemToRemove);

            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Error during deleting customer data", e.Message);
            }
        }

        public static void InsertCustomerData(Customer customer)
        {
            try
            {
                // This would do the Dabase or Entity Framework
                var maxId = CustomersTable.Select(item => item.Id).Concat(new[] {int.MinValue}).Max();
                maxId = maxId + 1;

                customer.Id = maxId;
                CustomersTable.Add(customer);
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Error during inserting customer data", e.Message);
            }
        }



        public static int FindMaxValue<T>(List<T> list, Converter<T, int> projection)
        {
            int maxValue = int.MinValue;
            foreach (T item in list)
            {
                int value = projection(item);
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }

        public static void UpdateCustomerData(Customer customer)
        {
            try
            {
                var oldValue = CustomersTable.Find(c => c.Id == customer.Id);
                var newValue = customer;
                var index = CustomersTable.IndexOf(oldValue);

                if (index != -1)
                {
                    CustomersTable[index] = newValue;
                }
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Error during changing customer data", e.Message);
            }
        }

        public static Customer GetSingelCustomerData(int customerId)
        {
            return CustomersTable.Find(c => c.Id == customerId);
        }

        #endregion

#region Address

        public static IEnumerable<CustomerAddress> GetAllCustomerAdressesById(int customerId)
        {
            // Return nothing if id is 0 because it can never be 0
            if (customerId == 0) return Enumerable.Empty<CustomerAddress>();
            {
                return AddressesTable.Where(a => a.Customer.Id == customerId).ToList();
            }
        }

        public static CustomerAddress GetSingelCustomerAddressData(int id)
        {
                return AddressesTable.Find(a => a.Id == id);
        }

        public static void DeleteCustomerAddress(int customerAddressId)
        {
            try
            {
                var itemToRemove = AddressesTable.Single(a => a.Id == customerAddressId);
                AddressesTable.Remove(itemToRemove);
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Error during deleting address data", e.Message);
            }


        }

        #endregion

        #region Customer - Address

        public static void InsertCustomerAddressData(CustomerAddress customerAddress)
        {
            try
            {
                // This would do the Dabase or Entity Framework
                var maxId = AddressesTable.Select(item => item.Id).Concat(new[] { int.MinValue }).Max();
                maxId = maxId + 1;

                customerAddress.Id = maxId;
                AddressesTable.Add(customerAddress);
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Error during insering Address data", e.Message);
            }
        }

        public static void UpdateCustomerAddressData(CustomerAddress customerAddress)
        {
            try
            {
                var oldValue = AddressesTable.Find(a => a.Id == customerAddress.Id);
                var newValue = customerAddress;
                var index = AddressesTable.IndexOf(oldValue);

                if (index != -1)
                {
                    AddressesTable[index] = newValue;
                }
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Error during changing customer data", e.Message);
            }
        }

        #endregion
    }
}
