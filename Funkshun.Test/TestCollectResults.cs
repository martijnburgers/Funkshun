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
using Funkshun.Core.Decorators;
using Funkshun.Core.Extensions;
using Funkshun.Core.Test.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestCollectResults
    {
        [TestMethod]
        public void TestCollectResultsMethod()
        {
            var result = Funkshun<FunctionString>.New().CollectResults().Run().ReturnValue;
            Assert.IsTrue(result == "a");

            ResultCollectorDecorator<string> result2 =
                Funkshun<FunctionString>.New().CollectResults();

            Assert.IsNotNull(result2);
            Assert.IsTrue(result2.Count == 0);

            result2.Run();

            Assert.IsTrue(result2.Count == 1);

            result2.Run();

            Assert.IsTrue(result2.Count == 2);

            result2.Run();

            Assert.IsTrue(result2.Count == 3);

            var result3 = result2.GetResults();

            foreach (var functionResult in result3)
            {
                Assert.IsTrue(functionResult.ReturnValue == "a");
            }

            var result4 = result2.GetResults().First().ReturnValue;

            Assert.IsTrue(result4 == "a");

            ResultCollectorDecorator<string> result5 =
                Funkshun<FunctionString>.New().CollectResults();

            for (int i = 1; i <= 5; i++)
            {
                result5.Run();
            }

            var result5Data = result5.GetResults();

            Assert.IsTrue(result5Data.Count() == 5);
            
            var result6 = Funkshun<FunctionStringStringStringStringStringInt>.New().CollectResults();

            result6.Run("a", "b", "c", "d", "e");
            result6.Run("a", "b", "c", "d", "e");

            Assert.IsTrue(result6.Count == 2);

            var collectedResults = result6.GetResults();

            Assert.IsTrue(collectedResults.Count() == 2);
            Assert.IsTrue(collectedResults.Errors().Count() == 0);
            Assert.IsTrue(collectedResults.Warnings().Count() == 0);
            Assert.IsTrue(collectedResults.Informationals().Count() == 0);

            result6.Run("a", "b", "c", "d", "z");//gives back error
            result6.Run("a", "b", "c", "d", "e");

            collectedResults = result6.GetResults();

            Assert.IsTrue(collectedResults.Count() == 4);
            Assert.IsTrue(collectedResults.Errors().Count() == 1);
            Assert.IsTrue(collectedResults.Warnings().Count() == 0);
            Assert.IsTrue(collectedResults.Informationals().Count() == 0);
            
            collectedResults = result6.GetResults(rs => !rs.HasErrors());

            Assert.IsTrue(collectedResults.Count() == 3);
            Assert.IsTrue(collectedResults.Errors().Count() == 0);
            Assert.IsTrue(collectedResults.Warnings().Count() == 0);
            Assert.IsTrue(collectedResults.Informationals().Count() == 0);

            var errors = 0;

            collectedResults = result6.GetResults();
            
            collectedResults.OnError(() => errors = 1);
            Assert.IsTrue(errors == 1);

            collectedResults.OnError(() => errors = 2, () => errors = 20);
            Assert.IsTrue(errors == 2);

            collectedResults.OnError(f => errors = 3);
            Assert.IsTrue(errors == 3);

            collectedResults.OnError(f => errors = 4, f => errors = 40);
            Assert.IsTrue(errors == 4);

            Assert.IsTrue(collectedResults.OnError(f => "a") == "a");
            Assert.IsTrue(collectedResults.OnError(f => "a", f => "b") == "a");

            var warnings = 0;

            //results has no warning
            collectedResults = result6.GetResults();

            collectedResults.OnWarning(() => warnings = 1);
            Assert.IsTrue(warnings == 0);

            collectedResults.OnWarning(() => warnings = 2, () => warnings = 20);
            Assert.IsTrue(warnings == 20);

            collectedResults.OnWarning(f => warnings = 3);
            Assert.IsTrue(warnings == 20);

            collectedResults.OnWarning(f => warnings = 4, f => warnings = 40);
            Assert.IsTrue(warnings == 40);

            Assert.IsTrue(collectedResults.OnWarning(f => "a") == null);
            Assert.IsTrue(collectedResults.OnWarning(f => "a", f => "b") == "b");

            //gives back a warning
            result6.Run("a", "b", "c", "d", "y");


            warnings = 0;

            //results has one warning, one error
            collectedResults = result6.GetResults();

            collectedResults.OnWarning(() => warnings = 1);
            Assert.IsTrue(warnings == 1);

            collectedResults.OnWarning(() => warnings = 2, () => warnings = 20);
            Assert.IsTrue(warnings == 2);

            collectedResults.OnWarning(f => warnings = 3);
            Assert.IsTrue(warnings == 3);

            collectedResults.OnWarning(f => warnings = 4, f => warnings = 40);
            Assert.IsTrue(warnings == 4);

            Assert.IsTrue(collectedResults.OnWarning(f => "a") == "a");
            Assert.IsTrue(collectedResults.OnWarning(f => "a", f => "b") == "a");
        }               
    }
}
