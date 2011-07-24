#region LICENSE
//  Funkshun.Core 1.0.0.0
//  
//  Copyright 2011, see AUTHORS.txt
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//        http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  
#endregion

using System;
using Funkshun.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestFunctionInt
    {
        [TestMethod]
        public void TestNewOnSuccess()
        {
       
        }
    }

    public class Person1
    {
        public DateTime BirthDay = new DateTime(1984,9,7);
        public string Surname  = "Martijn";
        public string Lastname = "Burgers";

        public IFunctionResult<int> GetAge()
        {            
            DateTime now = DateTime.Today;
            int age = now.Year - BirthDay.Year;
            if (BirthDay > now.AddYears(-age)) age--;

            return ResultHelper.Make(age);
        }

        public IFunctionResult<string> GetFullName()
        {
            return ResultHelper.Make(string.Format("{0}{1}", Surname, Lastname));
        }
    }

    public class Person2 : IPerson
    {
        public DateTime BirthDay { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }

        public IFunctionResult<int> GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - BirthDay.Year;
            if (BirthDay > now.AddYears(-age)) age--;

            return ResultHelper.Make(age);
        }

        public IFunctionResult<string> GetFullName()
        {
            return ResultHelper.Make(string.Format("{0}{1}", Surname, LastName));
        }
    }

    public interface IPerson : IFunction
    {
        DateTime BirthDay { get; set; }
        string Surname { get; set; }
        string LastName { get; set; }

        IFunctionResult<int> GetAge();
        IFunctionResult<string> GetFullName();
    }
}
