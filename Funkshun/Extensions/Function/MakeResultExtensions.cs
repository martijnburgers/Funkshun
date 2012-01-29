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
using Funkshun.Core.Helpers;

namespace Funkshun.Core.Extensions
{
    /// <summary>
    /// Static (extension) class for extending the types: 
    /// <see cref="IFunction{TResult}"/>, 
    /// <see cref="IFunction{T, TResult}"/>, 
    /// <see cref="IFunction{T1,T2, TResult}"/>, 
    /// <see cref="IFunction{T1,T2,T3, TResult}"/>, 
    /// <see cref="IFunction{T1,T2,T3,T4, TResult}"/>, 
    /// <see cref="IFunction{T1,T2,T3,T4,T5, TResult}"/>
    /// </summary>
    public static partial class FunctionExtensions {

        // -> Basic Make Result 
              
        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <returns>A empty <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<TResult>(this IFunction<TResult> function)
        {
            return ResultHelper.Make<TResult>();
        }

        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T">The type of the first parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <returns>A empty <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T, TResult>(this IFunction<T, TResult> function)
        {
            return ResultHelper.Make<TResult>();
        }

        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <returns>A empty <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, TResult>(this IFunction<T1, T2, TResult> function)
        {
            return ResultHelper.Make<TResult>();
        }

        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <returns>A empty <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, TResult>(
            this IFunction<T1, T2, T3, TResult> function)
        {
            return ResultHelper.Make<TResult>();
        }

        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <returns>A empty <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, TResult>(
            this IFunction<T1, T2, T3, T4, TResult> function)
        {
            return ResultHelper.Make<TResult>();
        }

        /// <summary>
        /// Makes an instance of a empty function result.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <returns>A empty <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, T5, TResult>(
            this IFunction<T1, T2, T3, T4, T5, TResult> function)
        {
            return ResultHelper.Make<TResult>();
        }

        // -> Make Result with Messages 

        /// <summary>
        /// Makes an instance of a function result with given messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<TResult>(this IFunction<TResult> function, IEnumerable<Message> messages)
        {
            return ResultHelper.Make<TResult>(messages);
        }

        /// <summary>
        /// Makes an instance of a function result with given messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T">The type of the first parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>        
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T, TResult>(this IFunction<T, TResult> function, IEnumerable<Message> messages)
        {
            return ResultHelper.Make<TResult>(messages);
        }

        /// <summary>
        /// Makes an instance of a function result with given messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>        
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, TResult>(this IFunction<T1, T2, TResult> function, IEnumerable<Message> messages)
        {
            return ResultHelper.Make<TResult>(messages);
        }

        /// <summary>
        /// Makes an instance of a function result with given messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the thirth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>        
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, TResult>(
            this IFunction<T1, T2, T3, TResult> function, IEnumerable<Message> messages)
        {
            return ResultHelper.Make<TResult>(messages);
        }

        /// <summary>
        /// Makes an instance of a function result with given messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the thirth parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>        
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, TResult>(
            this IFunction<T1, T2, T3, T4, TResult> function, IEnumerable<Message> messages)
        {
            return ResultHelper.Make<TResult>(messages);
        }

        /// <summary>
        /// Makes an instance of a function result with given messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the thirth parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>        
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, T5, TResult>(
            this IFunction<T1, T2, T3, T4, T5, TResult> function, IEnumerable<Message> messages)
        {
            return ResultHelper.Make<TResult>(messages);
        }

        // -> Basic Make Result With Return Value

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<TResult>(this IFunction<TResult> function, TResult value)
        {
            return ResultHelper.Make(value);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T">The type of the first parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T, TResult>(this IFunction<T, TResult> function, TResult value)
        {
            return ResultHelper.Make(value);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, TResult>(this IFunction<T1, T2, TResult> function, TResult value)
        {
            return ResultHelper.Make(value);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, TResult>(
            this IFunction<T1, T2, T3, TResult> function, TResult value)
        {
            return ResultHelper.Make(value);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, TResult>(
            this IFunction<T1, T2, T3, T4, TResult> function, TResult value)
        {
            return ResultHelper.Make(value);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, T5, TResult>(
            this IFunction<T1, T2, T3, T4, T5, TResult> function, TResult value)
        {
            return ResultHelper.Make(value);
        }

        // -> Basic Make Result With Return Value And Messages

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<TResult>(this IFunction<TResult> function, TResult value, IEnumerable<Message> messages)
        {
            return ResultHelper.Make(value, messages);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T">The type of the first parameter.</typeparam>>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T, TResult>(this IFunction<T, TResult> function, TResult value, IEnumerable<Message> messages)
        {
            return ResultHelper.Make(value, messages);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, TResult>(this IFunction<T1, T2, TResult> function, TResult value, IEnumerable<Message> messages)
        {
            return ResultHelper.Make(value, messages);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>        
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, TResult>(
            this IFunction<T1, T2, T3, TResult> function, TResult value, IEnumerable<Message> messages)
        {
            return ResultHelper.Make(value, messages);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>        
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, TResult>(
            this IFunction<T1, T2, T3, T4, TResult> function, TResult value, IEnumerable<Message> messages)
        {
            return ResultHelper.Make(value, messages);
        }

        /// <summary>
        /// Makes an instance of a function result with a given return value and sequence of messages.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="function">The function for which you want to make the result.</param>
        /// <param name="value">The return value of the function result.</param>
        /// <param name="messages">A sequence of messages which are added to the function result.</param>
        /// <returns>A <see cref="IResult{TResult}"/> instance.</returns>
        public static IResult<TResult> MakeResult<T1, T2, T3, T4, T5, TResult>(
            this IFunction<T1, T2, T3, T4, T5, TResult> function, TResult value, IEnumerable<Message> messages)
        {
            return ResultHelper.Make(value, messages);
        }
    }
}
