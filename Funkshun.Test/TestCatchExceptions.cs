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
using System.Linq;
using Funkshun.Core.Extensions;
using Funkshun.Core.Helpers;
using Funkshun.Core.Test.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestCatchExceptions
    {
        [TestMethod]
        public void TestCatchExceptionsMethod()
        {
            var result = Funkshun<FunctionStringWithInvalidOperationException>
                            .New()
                            .CatchExceptions<string, InvalidOperationException>()
                            .Run();

            Assert.IsTrue(result.HasErrors());
            Assert.IsNotNull(result.Messages.First().Tag);
            Assert.IsTrue(result.Messages.First().Code == -10);
            Assert.IsTrue(result.Messages.First().Description.Length != 0);
            Assert.IsTrue(result.ReturnValue == default(string));

            var exceptionCatched = false;

            try
            {
                Funkshun<FunctionStringWithInvalidOperationException>
                    .New()
                    .CatchExceptions<string, ArgumentNullException>()
                    .Run();

                Assert.Fail("Exception should be thrown!");
            }
            catch (InvalidOperationException)
            {
                exceptionCatched = true;
            }

            Assert.IsTrue(exceptionCatched);

            result = Funkshun<FunctionStringWithInvalidOperationException>
                    .New()
                    .CatchExceptions()
                    .Run();

            Assert.IsTrue(result.HasErrors());
            Assert.IsNotNull(result.Messages.First().Tag);
            Assert.IsTrue(result.Messages.First().Code == -10);

            result = Funkshun<FunctionStringWithInvalidOperationException>
                            .Instance
                            .CatchExceptions<string, InvalidOperationException>()
                            .Run();

            Assert.IsTrue(result.HasErrors());
            Assert.IsNotNull(result.Messages.First().Tag);

            exceptionCatched = false;

            try
            {
                Funkshun<FunctionStringWithInvalidOperationException>
                    .Instance
                    .CatchExceptions<string, ArgumentNullException>()
                    .Run();

                Assert.Fail("Exception should be thrown!");
            }
            catch (InvalidOperationException)
            {
                exceptionCatched = true;
            }

            Assert.IsTrue(exceptionCatched);

            result = Funkshun<FunctionStringWithInvalidOperationException>
                    .Instance
                    .CatchExceptions()
                    .Run();

            Assert.IsTrue(result.HasErrors());
            Assert.IsNotNull(result.Messages.First().Tag);


            var result2 = Funkshun<FunctionInt>
                .Instance
                .CatchExceptions<int, InvalidOperationException>()
                .Run();

            Assert.IsTrue(result2.ReturnValue == 1);

            result2 = Funkshun<FunctionInt>
                .Instance
                .CatchExceptions()
                .Run();

            Assert.IsTrue(result2.ReturnValue == 1);


            var result3 = Funkshun<FunctionStringWithInvalidOperationException>
           .Instance
           .CatchExceptions(e => {   var rs = ResultHelper.Make("12345");

                                     
                                     return rs;
           })
           .Run();

            Assert.IsTrue(result3.ReturnValue == "12345");                        

            result3 = Funkshun<FunctionStringWithInvalidOperationException>
                        .Instance
                        .CatchExceptions<string, InvalidOperationException>(e =>
                                                                            {
                                                                                var rs = ResultHelper.Make("12345");                     
                                                                                return rs;
                                                                            })
                        .Run();

            Assert.IsTrue(result3.ReturnValue == "12345");

            result2 = Funkshun<FunctionInt>
                        .Instance
                        .CatchExceptions(e => { var rs = ResultHelper.Make(1111111);
                                                  return rs;
                                              })
                        .Run();

            Assert.IsTrue(result2.ReturnValue == 1);
        }               
    }
}
