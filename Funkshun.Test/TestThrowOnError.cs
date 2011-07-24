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

using System.Linq;
using Funkshun.Core.Exceptions;
using Funkshun.Core.Extensions;
using Funkshun.Core.Test.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestThrowOnError
    {
        [TestMethod]
        public void TestExpectedExceptions()
        {
            try
            {
                Funkshun<FunctionIntWithError>.New().Run().ThrowOnError();
            }
            catch (MessageException e)
            {
                Assert.IsTrue(e.Code == 100);
                Assert.IsTrue(e.Message == "Error -> FunctionIntOnError");
                Assert.IsTrue(e.Severity == MessageType.Error);

                Assert.IsNotNull(e.Errors);
                Assert.IsTrue(e.Errors.Count() == 1);
            }

            try
            {
                Funkshun<FunctionStringIntWithErrors>.New().Run("bogus data")
                    .ThrowOnError();
            }
            catch (MessageException e)
            {
                Assert.IsTrue(e.Code == 100);
                Assert.IsTrue(e.Message == "Error -> FunctionIntOnError 1");
                Assert.IsTrue(e.Severity == MessageType.Error);

                Assert.IsNotNull(e.Errors);
                Assert.IsTrue(e.Errors.Count() == 3);
            }


            try
            {
                Funkshun<FunctionStringInt>.New().Run("bogus data").ThrowOnError();
            }
            catch (MessageException e)
            {
               Assert.Fail(string.Format("Should not be throwing an error : {0} ", e.Message));
            }
        }
    }
}
