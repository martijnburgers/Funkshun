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

using Funkshun.Core.Extensions;
using Funkshun.Core.Test.Extensions;
using Funkshun.Core.Test.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestOnError
    {
        [TestMethod]
        public void TestOnErrorIFunctionResultGenericExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().OnError(r => 1);
            
            Assert.IsFalse(result == 1);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().OnError(r => 1);

            Assert.IsTrue(result == 1);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnError(r =>
                                                            {
                                                                resultInt = r+1;
                                                            });

            Assert.IsTrue(resultInt == 0);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnError(r =>
            {
                resultInt = r+1;
            });

            Assert.IsTrue(resultInt == 1);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnError(fr => { resultInt = fr.ReturnValue; });

            Assert.IsFalse(resultInt == 1);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnError(fr => { resultInt = fr.ReturnValue+1; });

            Assert.IsTrue(resultInt == 1);
        }

        [TestMethod]
        public void TestOnErrorElseIFunctionResultGenericExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().OnError(r => 1, y => 2);

            Assert.IsTrue(result == 2);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().OnError(r => 1, y => 2);

            Assert.IsTrue(result == 1);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnError(r =>
            {
                resultInt = r;
            }, y =>
            {
                resultInt = y-1;
            });

            Assert.IsTrue(resultInt == 0);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnError(r =>
            {
                resultInt = r-3;
            }, y =>
            {
                resultInt = y-2;
            });

            Assert.IsTrue(resultInt == -3);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnError(fr => { resultInt = fr.ReturnValue; }, fr => { resultInt = fr.ReturnValue-2; });

            Assert.IsTrue(resultInt == -1);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnError(fr => { resultInt = fr.ReturnValue-1; }, fr => { resultInt = fr.ReturnValue-2; });

            Assert.IsTrue(resultInt == -1);
        }

        [TestMethod]
        public void TestOnErrorIFunctionResultExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().DownCast().OnError(r => 1);

            Assert.IsTrue(result == 0);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().DownCast().OnError(r => 1);

            Assert.IsTrue(result == 1);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnError(() =>
            {
                resultInt = 1;
            });

            Assert.IsTrue(resultInt == 0);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnError(() =>
            {
                resultInt = 1;
            });

            Assert.IsTrue(resultInt == 1);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnError(fr => { resultInt = 2; });

            Assert.IsTrue(resultInt == 0);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnError(fr => { resultInt = 3; });

            Assert.IsTrue(resultInt == 3);
        }


        [TestMethod]
        public void TestOnErrorElseIFunctionResultExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().DownCast().OnError(r => 1, r => 2);

            Assert.IsTrue(result == 2);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().DownCast().OnError(r => 1, r => 2);

            Assert.IsTrue(result == 1);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnError(() => { resultInt = 1; }, () => { resultInt = 2; });

            Assert.IsTrue(resultInt == 2);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnError(() => { resultInt = 1; }, () => { resultInt = 2; });

            Assert.IsTrue(resultInt == 1);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnError(fr => { resultInt = 2; }, fr => { resultInt = 4; });

            Assert.IsTrue(resultInt ==4);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnError(fr => { resultInt = 2; }, fr => { resultInt = 4; });

            Assert.IsTrue(resultInt == 2);
        }

        
    }
}
