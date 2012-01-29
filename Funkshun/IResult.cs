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
using System.Collections.Generic;

namespace Funkshun.Core
{
    /// <summary>
    /// Interface defining a result with a return value.
    /// </summary>
    public interface IResult<TR> : IResult
    {
        /// <summary>
        /// Return value of the function.
        /// </summary>
        TR ReturnValue { get; set; }

        /// <summary>
        /// The type of the return value.
        /// </summary>
        Type ReturnType { get; }
    }

    /// <summary>
    /// Interface defining a result with only contains a list of messages.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// List of messages.
        /// </summary>
        List<Message> Messages { get; }
    }
}
