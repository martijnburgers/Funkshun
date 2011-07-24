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
using Funkshun.Core.Extensions;
using Funkshun.Core.Test.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestFunctionMessages
    {
        [TestMethod]
        public void TestErrorMessages()
        {
            var errors = Funkshun<FunctionIntWithError>.New().Run().Errors();

            Assert.IsTrue(errors.Count() == 1);

            errors = Funkshun<FunctionInt>.New().Run().Errors();

            Assert.IsTrue(errors.Count() == 0);
        }

        [TestMethod]
        public void TestWarningMessages()
        {
            var warnings = Funkshun<FunctionIntWithWarning>.New().Run().Warnings();

            Assert.IsTrue(warnings.Count() == 1);

            warnings = Funkshun<FunctionInt>.New().Run().Warnings();

            Assert.IsTrue(warnings.Count() == 0);
        }

        [TestMethod]
        public void TestInformationalMessages()
        {
            var informationals = Funkshun<FunctionIntWithInformational>.New().Run().Informationals();

            Assert.IsTrue(informationals.Count() == 1);

            informationals = Funkshun<FunctionInt>.New().Run().Informationals();

            Assert.IsTrue(informationals.Count() == 0);
        }
    }
}
