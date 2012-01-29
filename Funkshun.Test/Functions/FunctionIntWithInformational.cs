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

namespace Funkshun.Core.Test.Functions
{
    public class FunctionIntWithInformational : IFunction<int>
    {
        public IResult<int> Run()
        {
            var result = this.MakeResult();

            result.Messages.Add(new Message { Code = 300, Description = "Error -> FunctionIntOnError", Severity = MessageType.Information });

            result.ReturnValue = 0;

            return result;
        }
    }
}
