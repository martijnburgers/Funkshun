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
    /// <see cref="IFunctionResult{TResult}"/>
    /// </summary>
    public static partial class EnumerableFunctionResultExtensions
    {
        /// <summary>
        /// Calls a warning action when one of the function results in the sequence contains warnings.
        /// </summary>
        /// <param name="functionResults">The sequence of function results to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults, Action warningAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (warningAction == null) throw new ArgumentNullException("warningAction");

            if (functionResults.HasWarnings())
            {
                warningAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a warning action when one of the function results in the sequence contains warnings.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults,
                                                          Action<IEnumerable<IFunctionResult<TResult>>> warningAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (warningAction == null) throw new ArgumentNullException("warningAction");

            if (functionResults.HasWarnings())
            {
                warningAction.Invoke(functionResults);
            }
        }
    
        /// <summary>
        /// Calls a warning func when one of the function results in the sequence contains warnings.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for warnings.</param>
        /// <param name="warningFunction">The func to call when there are warnings.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnWarning<TResult, TNewResult>(
            this IEnumerable<IFunctionResult<TResult>> functionResults,
            Func<IEnumerable<IFunctionResult<TResult>>, TNewResult> warningFunction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (warningFunction == null) throw new ArgumentNullException("warningFunction");

            if (functionResults.HasWarnings())
            {
                return warningFunction(functionResults);
            }

            return default(TNewResult);
        }               

        /// <summary>        
        /// Calls a warning action when one of the function results in the sequence contains warnings otherwise the else action.
        /// </summary>
        /// <param name="functionResults">The sequence of function results to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <param name="elseAction">The action to call when there are no warnings.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnWarning<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults, Action warningAction, Action elseAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (warningAction == null) throw new ArgumentNullException("warningAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResults.HasWarnings())
            {
                warningAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }

        ///<summary>
        /// Calls a warning action when one of the function results in the sequence contains warnings otherwise the else action.
        ///</summary>
        /// <param name="functionResults">The sequence of function results to check for warnings.</param>
        ///<param name="warningAction">The action to call when there are warnings.</param>
        ///<param name="elseAction">The action to call when there are no warnings.</param>
        ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnWarning<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults,
                                                          Action<IEnumerable<IFunctionResult<TResult>>> warningAction,
                                                          Action<IEnumerable<IFunctionResult<TResult>>> elseAction
                                                          )
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (warningAction == null) throw new ArgumentNullException("warningAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResults.HasWarnings())
            {
                warningAction.Invoke(functionResults);
            } 
            else
            {
                elseAction.Invoke(functionResults);
            }
        }

        /// <summary>
        /// Calls a warning func when one of the function results in the sequence contains errors otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for warnings.</param>
        /// <param name="warningFunction">The func to call when there are warnings.</param>
        ///<param name="elseFunction">The func to call when there are no warnings.</param>
        ///<returns>A type of TNewResult which is returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnWarning<TResult, TNewResult>(
            this IEnumerable<IFunctionResult<TResult>> functionResults,
            Func<IEnumerable<IFunctionResult<TResult>>, TNewResult> warningFunction,
            Func<IEnumerable<IFunctionResult<TResult>>, TNewResult> elseFunction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (warningFunction == null) throw new ArgumentNullException("warningFunction");
            if (elseFunction == null) throw new ArgumentNullException("warningFunction");

            if (functionResults.HasWarnings())
            {
                return warningFunction(functionResults);
            } 

            return elseFunction(functionResults);
        }     
    }
}