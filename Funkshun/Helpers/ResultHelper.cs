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

using System.Collections.Generic;

namespace Funkshun.Core.Helpers
{
    /// <summary>
    /// Helper class for function results.
    /// </summary>
    public static class ResultHelper
    {
        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <returns>A empty <see cref="IFunctionResult{TResult}"/> instance.</returns>
        public static IFunctionResult<TResult> Make<TResult>()
        {
            return FunctionResult<TResult>.New();
        }

    
        ///<summary>
        /// Makes an instance of a function result with given messages.
        ///</summary>
        ///<param name="messages">A sequence of messages which are added to the function result.</param>
        ///<typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <returns>A <see cref="IFunctionResult{TResult}"/> instance.</returns>
        public static IFunctionResult<TResult> Make<TResult>(IEnumerable<Message> messages)
        {
            var result = FunctionResult<TResult>.New();

            if (messages != null)
            {
                result.Messages.AddRange(messages);
            }

            return result;
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        ///<typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IFunctionResult{TResult}"/> instance.</returns>
        public static IFunctionResult<TResult> Make<TResult>(TResult value)
        {
            return Make(value, null);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="value">The return value of the function result.</param>
        ///<param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IFunctionResult{TResult}"/> instance.</returns>
        public static IFunctionResult<TResult> Make<TResult>(TResult value, IEnumerable<Message> messages)
        {
            var result = FunctionResult<TResult>.New();

            if (messages != null)
            {
                result.Messages.AddRange(messages);
            }

            result.ReturnValue = value;

            return result;
        }
    }
}
