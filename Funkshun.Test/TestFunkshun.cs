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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funkshun.Core.Test
{
    [TestClass]
    public class TestFunkshun
    {
        [TestMethod]
        public void TestInstance()
        {
            var reference1 = Funkshun<Functions.FunctionInt>.Instance;

            var reference2 = Funkshun<Functions.FunctionInt>.Instance;

            Assert.IsTrue(object.ReferenceEquals(reference1, reference2));

            var reference3 = Funkshun<Functions.FunctionVoid>.Instance;

            Assert.IsFalse(object.ReferenceEquals(reference2, reference3));

            var reference4 = Funkshun<Functions.FunctionVoid>.Instance;

            Assert.IsTrue(object.ReferenceEquals(reference3, reference4));

            var reference5 = Funkshun<Functions.FunctionInt>.Instance;

            Assert.IsTrue(object.ReferenceEquals(reference1, reference5));

            var reference6 = Funkshun<Functions.FunctionInt>.New();

            Assert.IsFalse(object.ReferenceEquals(reference1, reference6));
        }

        [TestMethod]
        public void TestNewInstance()
        {
            var reference1 = Funkshun<Functions.FunctionInt>.New();

            var reference2 = Funkshun<Functions.FunctionInt>.New();

            Assert.IsFalse(object.ReferenceEquals(reference1, reference2));

            var reference3 = Funkshun<Functions.FunctionVoid>.New();

            Assert.IsFalse(object.ReferenceEquals(reference2, reference3));

            var reference4 = Funkshun<Functions.FunctionVoid>.New();

            Assert.IsFalse(object.ReferenceEquals(reference3, reference4));           
        }
    }
}
