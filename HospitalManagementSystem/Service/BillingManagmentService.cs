using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem.Service
{
    public class BillingManagmentService
    {
        readonly static DbService db = new DbService();
        readonly static IHospital<Accountant> accountantDb = new AccountantRepository(db);
        readonly static IHospital<BillingManagement> billingDb = new BillingRepository(db);
        //Billing
        //Create billing
        public static void CreateBilling(BillingManagement billing, Guid accountantId)
        {
            Accountant accountant = accountantDb.Get(accountantId).Result;
            if (accountant == null)
            {
                Console.WriteLine("Unauthorized user");
            }
            else
            {
                int inserted = billingDb.Add(billing).Result;
                if (inserted == 0)
                {
                    Console.WriteLine("Try Again");
                }
                else
                {
                    Console.WriteLine("Created Successfully");
                }
            }

        }
        //Get bill
        public static void GetBilling(Guid billingId, Guid accountantId)
        {
            Accountant accountant = accountantDb.Get(accountantId).Result;
            if (accountant == null)
            {
                Console.WriteLine("Unauthorized user");
            }
            else
            {
                BillingManagement billing = billingDb.Get(billingId).Result;
                if (billing == null)
                {
                    Console.WriteLine("This doesn't exist");
                }
                else
                {
                    Console.WriteLine($"The price is {billing.Price} and an outstanding bill of {billing.OutstandingBill} for {billing.Patient.Name}");
                }
            }

        }
        //Get  all patient bills
        public static void GetPatientBills(Guid patientId, Guid accountantId)
        {
            Accountant accountant = accountantDb.Get(accountantId).Result;
            if (accountant == null)
            {
                Console.WriteLine("Unauthorized user");
            }
            else
            {
                IEnumerable<BillingManagement> billings = billingDb.GetAll(patientId);
                foreach (var bill in billings)
                {
                    Console.WriteLine($"The price is {bill.Price} and an outstanding bill of {bill.OutstandingBill}");
                }
            }

        }

        //update bill
        public static void UpdateBill(BillingManagement billing, Guid accountantId)
        {
            Accountant accountant = accountantDb.Get(accountantId).Result;
            if (accountant == null)
            {
                Console.WriteLine("Unauthorized user");
            }
            else
            {
                int updated = billingDb.Update(billing).Result;
                if (updated == 0)
                {
                    Console.WriteLine("Try Again");
                }
                else
                {
                    Console.WriteLine("Updated Successfully");
                }
            }

        }
        //Delete bill
        public static void DeleteBill(Guid billingId, Guid accountantId)
        {
            Accountant accountant = accountantDb.Get(accountantId).Result;
            if (accountant == null)
            {
                Console.WriteLine("Unauthorized user");
            }
            else
            {
                int deleted = accountantDb.Delete(billingId).Result;
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
}
