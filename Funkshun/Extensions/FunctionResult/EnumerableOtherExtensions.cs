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

namespace Funkshun.Core.Extensions
{
    /// <summary>
    /// Static (extension) class for extending the sequences of types:        
    /// <see cref="IFunctionResult{TResult}"/>
    /// </summary>
    public static partial class EnumerableFunctionResultExtensions
    {
        /// <summary>
        /// Checks if the sequence of function results contains a result which has a error message.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="functionResults"> A sequence of results from executed functions.</param>
        /// <returns>True if there is a result with at least one error message, false if there isn't</returns>
        public static bool HasErrors<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults)
        {
            return functionResults.Any(fr => fr.HasErrors());
        }

        /// <summary>
        /// Checks if the sequence of function results contains a result which has a warning message.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="functionResults"> A sequence of results from executed functions.</param>
        /// <returns>True if there is a result with at least one warning message, false if there isn't</returns>
        public static bool HasWarnings<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults)
        {
            return functionResults.Any(fr => fr.HasWarnings());
        }

        /// <summary>
        /// Checks if the sequence of function results contains a result which has a informational message.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="functionResults"> A sequence of results from executed functions.</param>
        /// <returns>True if there is a result with at least one informational message, false if there isn't</returns>
        public static bool HasInformationals<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults)
        {
            return functionResults.Any(fr => fr.HasInformationals());
        }

        /// <summary>
        /// Filters the function results that resulted into messages with the severity <see cref="MessageType"/>.Error.
        /// </summary>
        /// <param name="functionResults">A sequence of function results.</param>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <returns>A seqeunece of function results that contains messages with the severity <see cref="MessageType"/>.Error.</returns>
        public static IEnumerable<IFunctionResult<TResult>> Errors<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults)
        {
            return functionResults.Where(fr => fr.HasErrors());
        }

        /// <summary>
        /// Filters the function results that resulted into messages with the severity <see cref="MessageType"/>.Warning.
        /// </summary>
        /// <param name="functionResults">A sequence of function results.</param>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <returns>A seqeunece of function results that contains messages with the severity <see cref="MessageType"/>.Warning.</returns>
        public static IEnumerable<IFunctionResult<TResult>> Warnings<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults)
        {
            return functionResults.Where(fr => fr.HasWarnings());
        }

        /// <summary>
        /// Filters the function results that resulted into messages with the severity <see cref="MessageType"/>.Informationals.
        /// </summary>
        /// <param name="functionResults">A sequence of function results.</param>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <returns>A seqeunece of function results that contains messages with the severity <see cref="MessageType"/>.Informationals.</returns>
        public static IEnumerable<IFunctionResult<TResult>> Informationals<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults)
        {
            return functionResults.Where(fr => fr.HasInformationals());
        }       
    }
}