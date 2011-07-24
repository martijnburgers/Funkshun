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
using System.Linq;
using Funkshun.Core.Exceptions;

namespace Funkshun.Core.Extensions
{
    /// <summary>
    /// Static (extension) class for extending the types: 
    /// <see cref="IFunctionResult"/>, 
    /// <see cref="IFunctionResult{TResult}"/>
    /// </summary>
    public static partial class FunctionResultExtensions
    {
        /// <summary>
        /// Throws the first occured error message wrapped in a <see cref="MessageException"/>. 
        /// The complete errorlist is also available as a property of <see cref="MessageException"/>.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function</param>                
        /// <exception cref="MessageException">Thrown when a function result contains a least one message with the severity <see cref="MessageType"/>.Error </exception>
        public static void ThrowOnError(this IFunctionResult functionResult)
        {
            //obtain error list
            var errors = functionResult.Errors();

            //get first occured error
            if (errors != null)
            {
                var firstError = errors.OrderBy(err => err.Timestamp).DefaultIfEmpty().First();

                if (firstError != null)
                {
                    throw new MessageException(firstError, errors);
                }
            }
        }

        /// <summary>
        /// Filters the messages of a function result with a severity <see cref="MessageType"/>.Error.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function</param>
        /// <returns>A <see cref="IEnumerable{Message}" /> that contains <see cref="Message" /> elemens with the severity <see cref="MessageType"/>.Error </returns>
        public static IEnumerable<Message> Errors(this IFunctionResult functionResult)
        {
            return functionResult.Messages.Where(msg => msg.Severity == MessageType.Error);
        }

        /// <summary>
        /// Checks if the function result has any error messages.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function.</param>
        /// <returns>True if the function contains error messages, false if it isn't.</returns>
        public static bool HasErrors(this IFunctionResult functionResult)
        {
            return functionResult.Messages.Any(msg => msg.Severity == MessageType.Error);
        }

        /// <summary>
        /// Filters the messages of a function result with a severity <see cref="MessageType"/>.Warning.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function</param>
        /// <returns>A <see cref="IEnumerable{Message}" /> that contains <see cref="Message" /> elemens with the severity <see cref="MessageType"/>.Warning</returns>
        public static IEnumerable<Message> Warnings(this IFunctionResult functionResult)
        {
            return functionResult.Messages.Where(msg => msg.Severity == MessageType.Warning);
        }

        /// <summary>
        /// Checks if the function result has any warning messages.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function.</param>
        /// <returns>True if the function contains warning messages, false if it isn't.</returns>
        public static bool HasWarnings(this IFunctionResult functionResult)
        {
            return functionResult.Messages.Any(msg => msg.Severity == MessageType.Warning);
        }

        /// <summary>
        /// Filters the messages of a function result with a severity <see cref="MessageType"/>.Informational.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function</param>
        /// <returns>A <see cref="IEnumerable{Message}" /> that contains <see cref="Message" /> elemens with the severity <see cref="MessageType"/>.Informational</returns>
        public static IEnumerable<Message> Informationals(this IFunctionResult functionResult)
        {
            return functionResult.Messages.Where(msg => msg.Severity == MessageType.Information);
        }

        /// <summary>
        /// Checks if the function result has any informational messages.
        /// </summary>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function.</param>
        /// <returns>True if the function contains informational messages, false if it isn't.</returns>
        public static bool HasInformationals(this IFunctionResult functionResult)
        {
            return functionResult.Messages.Any(msg => msg.Severity == MessageType.Information);
        }

        /// <summary>
        /// Checks if the result is a void.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="functionResult"> A result of a executed function that may or may not contain messages returned by a function.</param>
        /// <returns>True if the function return type is a void, false if it isn't</returns>
        public static bool IsVoid<TResult>(this IFunctionResult<TResult> functionResult)
        {
            return typeof (TResult).IsAssignableFrom(typeof (Void));
        }            
    }
}