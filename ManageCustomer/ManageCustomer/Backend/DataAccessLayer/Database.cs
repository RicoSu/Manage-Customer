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

            CustomersTable.Add(new Customer{ Id = 1, Name = "Suter", Vorname = "Rico" });
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
                MetroMessageBox.Show("Fehler beim löschen des Kunden", e.Message);
            }
        }

        public static void InsertCustomerData(Customer customer)
        {
            try
            {
                CustomersTable.Add(customer);
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Fehler beim hinzufügen des Kunden", e.Message);
            }
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
                MetroMessageBox.Show("Fehler beim ändern der Kunden Daten", e.Message);
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
                MetroMessageBox.Show("Fehler beim löschen der Adress", e.Message);
            }


        }

        #endregion

        #region Customer - Address

        public static void InsertCustomerAddressData(CustomerAddress customerAddress)
        {
            try
            {
                AddressesTable.Add(customerAddress);
            }
            catch (SqlException e)
            {
                MetroMessageBox.Show("Fehler beim hinzufügen der Adresse", e.Message);
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
                MetroMessageBox.Show("Fehler beim ändern der Adress Daten", e.Message);
            }
        }

        #endregion
    }
}
