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

namespace Funkshun.Core.Extensions
{
    /// <summary>
    /// Static (extension) class for extending the sequences of types:     
    /// <see cref="IResult{TResult}"/>
    /// </summary>
    public static partial class EnumerableFunctionResultExtensions
    {
        /// <summary>
        /// Calls a error action when one of the function results in the sequence contains errors.
        /// </summary>
        /// <param name="functionResults">The sequence of function results to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError<TResult>(this IEnumerable<IResult<TResult>> functionResults, Action errorAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (errorAction == null) throw new ArgumentNullException("errorAction");

            if (functionResults.HasErrors())
            {
                errorAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a error action when one of the function results in the sequence contains errors.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError<TResult>(this IEnumerable<IResult<TResult>> functionResults,
                                                          Action<IEnumerable<IResult<TResult>>> errorAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (errorAction == null) throw new ArgumentNullException("errorAction");

            if (functionResults.HasErrors())
            {
                errorAction.Invoke(functionResults);
            }
        }
    
        /// <summary>
        /// Calls a error func when one of the function results in the sequence contains errors.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for errors.</param>
        /// <param name="errorFunction">The func to call when there are errors.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnError<TResult, TNewResult>(
            this IEnumerable<IResult<TResult>> functionResults,
            Func<IEnumerable<IResult<TResult>>, TNewResult> errorFunction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (errorFunction == null) throw new ArgumentNullException("errorFunction");

            if (functionResults.HasErrors())
            {
                return errorFunction(functionResults);
            }

            return default(TNewResult);
        }               

        /// <summary>        
        /// Calls a error action when one of the function results in the sequence contains errors otherwise the else action.
        /// </summary>
        /// <param name="functionResults">The sequence of function results to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <param name="elseAction">The action to call when there are no errors.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnError<TResult>(this IEnumerable<IResult<TResult>> functionResults, Action errorAction, Action elseAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (errorAction == null) throw new ArgumentNullException("errorAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResults.HasErrors())
            {
                errorAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }

        ///<summary>
        /// Calls a error action when one of the function results in the sequence contains errors otherwise the else action.
        ///</summary>
        /// <param name="functionResults">The sequence of function results to check for errors.</param>
        ///<param name="errorAction">The action to call when there are errors.</param>
        ///<param name="elseAction">The action to call when there are no errors.</param>
        ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnError<TResult>(this IEnumerable<IResult<TResult>> functionResults,
                                                          Action<IEnumerable<IResult<TResult>>> errorAction,
                                                          Action<IEnumerable<IResult<TResult>>> elseAction
                                                          )
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (errorAction == null) throw new ArgumentNullException("errorAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResults.HasErrors())
            {
                errorAction.Invoke(functionResults);
            } 
            else
            {
                elseAction.Invoke(functionResults);
            }
        }

        /// <summary>
        /// Calls a error func when one of the function results in the sequence contains errors otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for errors.</param>
        /// <param name="errorFunction">The func to call when there are errors.</param>
        ///<param name="elseFunction">The func to call when there are no errors.</param>
        ///<returns>A type of TNewResult which is returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnError<TResult, TNewResult>(
            this IEnumerable<IResult<TResult>> functionResults,
            Func<IEnumerable<IResult<TResult>>, TNewResult> errorFunction,
            Func<IEnumerable<IResult<TResult>>, TNewResult> elseFunction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (errorFunction == null) throw new ArgumentNullException("errorFunction");
            if (elseFunction == null) throw new ArgumentNullException("errorFunction");

            if (functionResults.HasErrors())
            {
                return errorFunction(functionResults);
            } 

            return elseFunction(functionResults);
        }     
    }
}