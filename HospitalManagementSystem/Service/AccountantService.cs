using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Service
{
    public class AccountantService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Accountant> accountantDb = new AccountantRepository(db);


        //Create Accountant
        public static void CreateAccount(Accountant accountant)
        {
            int inserted = accountantDb.Add(accountant).Result;
            if (inserted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Created Successfully");
            }

        }
        //Get Accountant
        public static void GetAccountant(Guid accountantId)
        {
            Accountant accountant = accountantDb.Get(accountantId).Result;
            if (accountant == null)
            {
                Console.WriteLine("This Accountant doesn't exist");
            }
            Console.WriteLine($"{accountant.Hospital} Accountant {accountant.AccountantId}");
        }
        //Update Accountant
        public static void UpdateAccountant(Accountant accountant)
        {
            int updated = accountantDb.Update(accountant).Result;
            if (updated == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Updated Successfully");
            }
        }
        //Delete Accountant
        public static void DeleteAccountant(Guid accountantId)
        {
            int deleted = accountantDb.Delete(accountantId).Result;
            if (deleted == 0)
            {
                Console.WriteLine("Try Again");
            }
            else
            {
                Console.WriteLine("Deleted Successfully");
            }
        }


    }
}
