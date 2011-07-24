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
    public class TestOnSuccess
    {
        [TestMethod]
        public void TestOnSuccessIFunctionResultGenericExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().OnSuccess(r => 1);
            
            Assert.IsTrue(result == 1);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().OnSuccess(r => 1);

            Assert.IsFalse(result == 1);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnSuccess(r =>
                                                            {
                                                                resultInt = r;
                                                            });

            Assert.IsTrue(resultInt == 1);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnSuccess(r =>
            {
                resultInt = r;
            });

            Assert.IsFalse(resultInt == 1);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnSuccess(fr => { resultInt = fr.ReturnValue; });

            Assert.IsTrue(resultInt == 1);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnSuccess(fr => { resultInt = fr.ReturnValue; });

            Assert.IsFalse(resultInt == 1);
        }

        [TestMethod]
        public void TestOnSuccessElseIFunctionResultGenericExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().OnSuccess(r => 1, y => 2);

            Assert.IsTrue(result == 1);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().OnSuccess(r => 1, y => 2);

            Assert.IsTrue(result == 2);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnSuccess(r =>
            {
                resultInt = r;
            }, y =>
            {
                resultInt = y-1;
            });

            Assert.IsTrue(resultInt == 1);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnSuccess(r =>
            {
                resultInt = r;
            }, y =>
            {
                resultInt = y-2;
            });

            Assert.IsTrue(resultInt == -2);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().OnSuccess(fr => { resultInt = fr.ReturnValue; }, fr => { resultInt = fr.ReturnValue-2; });

            Assert.IsTrue(resultInt == 1);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().OnSuccess(fr => { resultInt = fr.ReturnValue; }, fr => { resultInt = fr.ReturnValue-2; });

            Assert.IsTrue(resultInt == -2);
        }

        [TestMethod]
        public void TestOnSuccessIFunctionResultExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().DownCast().OnSuccess(r => 1);

            Assert.IsTrue(result == 1);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().DownCast().OnSuccess(r => 1);

            Assert.IsFalse(result == 1);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnSuccess(() =>
            {
                resultInt = 1;
            });

            Assert.IsTrue(resultInt == 1);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnSuccess(() =>
            {
                resultInt = 1;
            });

            Assert.IsFalse(resultInt == 1);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnSuccess(fr => { resultInt = 2; });

            Assert.IsTrue(resultInt == 2);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnSuccess(fr => { resultInt = 3; });

            Assert.IsFalse(resultInt == 3);
        }


        [TestMethod]
        public void TestOnSuccessElseIFunctionResultExtensions()
        {
            //#1a.
            var result = Funkshun<FunctionInt>.New().Run().DownCast().OnSuccess(r => 1, r => 2);

            Assert.IsTrue(result == 1);

            //#1b.
            result = Funkshun<FunctionIntWithError>.New().Run().DownCast().OnSuccess(r => 1, r => 2);

            Assert.IsTrue(result == 2);

            //#2a.
            int resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnSuccess(() => { resultInt = 1; }, () => { resultInt = 2; });

            Assert.IsTrue(resultInt == 1);

            //#2b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnSuccess(() => { resultInt = 1; }, () => { resultInt = 2; });

            Assert.IsTrue(resultInt == 2);

            //3a.
            resultInt = 0;
            Funkshun<FunctionInt>.New().Run().DownCast().OnSuccess(fr => { resultInt = 2; }, fr => { resultInt = 4; });

            Assert.IsTrue(resultInt == 2);

            //3b.
            resultInt = 0;
            Funkshun<FunctionIntWithError>.New().Run().DownCast().OnSuccess(fr => { resultInt = 2; }, fr => { resultInt = 4; });

            Assert.IsTrue(resultInt == 4);
        }

        
    }
}
