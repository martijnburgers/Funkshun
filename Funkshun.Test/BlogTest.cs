using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Funkshun.Core.Exceptions;
using Funkshun.Core.Extensions;
using Funkshun.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{

    public static class CustomerService
    {
//        //method with a real return value and possible functional messages.
//        public static IResult<Customer> GetCustomer(int id)
//        {
//            var result = ResultHelper.Make<Customer>();
//
//            //do some more...
//
//            return result;
//        }

        public static IResult<Customer> GetCustomer(int id)
        {

            var result = ResultHelper.Make<Customer>();

            if (id < 1)
            {
                result.Messages.Add(
                    new Message
                    {
                        Code = 1,
                        Description = String.Format("Customer ID {0} does not exists!", id),
                        Severity = MessageType.Error
                    });
            }
            else
            {
                var customer = new Customer { BirthDay = new DateTime(1984, 9, 7), ID = id, Name = "Martijn Burgers" };

                result.ReturnValue = customer;
            }

            return result;
        }

        //void method but with possible functional messages.
        public static IResult DeleteCustomer(int id)
        {
            var result = ResultHelper.Make<Void>();

            //do some more...

            return result;
        }

        //method to indicate that it's not bad to not use the IResult types. 
        //Sometimes you don't have or want to return any technical or 
        //functional messages back to the caller. In this case just don't use it!
        public static void TryDeleteCustomer(int id)
        {
            try {}
            catch (Exception) {}
        }
    }

    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
    }

    [TestClass]
    public class BlogTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IResult<Customer> result1 = CustomerService.GetCustomer(1);

//            if (result.HasInformationals() || result.HasWarnings())
//            {
//                //Trace this information with a custom .Trace() custom extension method.
//                //It's very easy to extend it with your own extension methods
//                result.Informationals().Trace();
//                result.Warnings().Trace();
//            }
//            
//            if(result.HasErrors()) //result.Errors().Any() is the same
//            {
//                //rollback transaction
//            }
//            
//            try
//            {
//                //revert functional error to exception (yes we also support it, altough it against my principle)
//                result.ThrowOnError();                
//            }
//            catch (MessageException e)
//            {
//                string msg = String.Format("A total of {0} error(s) occurred!. The first error occurred at {1}",
//                                           e.Errors.Count(), e.TimeStamp);
//
//                e.Errors.Log();
//
//                Debug.WriteLine(msg);
//
//                //loop through errors
//                foreach (var message in e.Errors)
//                {
//                    //...
//                }
//            }
//
//            //work with the return value which is a customer
//            //var customer = result.ReturnValue;
//
//            //Debug.WriteLine(customer.Name);
//
//            CustomerService.GetCustomer(1).OnSuccess(customer => CustomerService.DeleteCustomer(customer.ID));
//
//
//            CustomerService.GetCustomer(1).OnSuccess(
//                result => Debug.WriteLine(String.Format("Retrieved Customer {0}", result.ReturnValue.Name)),
//                result => Debug.WriteLine(String.Format("{0} error(s) occured", result.Errors().Count()))
//                );



            int customerID = CustomerService.GetCustomer(1).OnSuccess(result => result.ReturnValue.ID);


        }
    }
}
