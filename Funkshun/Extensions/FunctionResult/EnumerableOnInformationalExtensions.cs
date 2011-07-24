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
        /// Calls a informational action when one of the function results in the sequence contains informationals.
        /// </summary>
        /// <param name="functionResults">The sequence of function results to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults, Action informationalAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (informationalAction == null) throw new ArgumentNullException("informationalAction");

            if (functionResults.HasInformationals())
            {
                informationalAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a informational action when one of the function results in the sequence contains informationals.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults,
                                                          Action<IEnumerable<IFunctionResult<TResult>>> informationalAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (informationalAction == null) throw new ArgumentNullException("informationalAction");

            if (functionResults.HasInformationals())
            {
                informationalAction.Invoke(functionResults);
            }
        }
    
        /// <summary>
        /// Calls a informational func when one of the function results in the sequence contains informationals.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for informationals.</param>
        /// <param name="informationalFunction">The func to call when there are informationals.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnInformational<TResult, TNewResult>(
            this IEnumerable<IFunctionResult<TResult>> functionResults,
            Func<IEnumerable<IFunctionResult<TResult>>, TNewResult> informationalFunction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (informationalFunction == null) throw new ArgumentNullException("informationalFunction");

            if (functionResults.HasInformationals())
            {
                return informationalFunction(functionResults);
            }

            return default(TNewResult);
        }               

        /// <summary>        
        /// Calls a informational action when one of the function results in the sequence contains informationals otherwise the else action.
        /// </summary>
        /// <param name="functionResults">The sequence of function results to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <param name="elseAction">The action to call when there are no informationals.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnInformational<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults, Action informationalAction, Action elseAction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (informationalAction == null) throw new ArgumentNullException("informationalAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResults.HasInformationals())
            {
                informationalAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }

        ///<summary>
        /// Calls a informational action when one of the function results in the sequence contains informationals otherwise the else action.
        ///</summary>
        /// <param name="functionResults">The sequence of function results to check for informationals.</param>
        ///<param name="informationalAction">The action to call when there are informationals.</param>
        ///<param name="elseAction">The action to call when there are no informationals.</param>
        ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnInformational<TResult>(this IEnumerable<IFunctionResult<TResult>> functionResults,
                                                          Action<IEnumerable<IFunctionResult<TResult>>> informationalAction,
                                                          Action<IEnumerable<IFunctionResult<TResult>>> elseAction
                                                          )
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (informationalAction == null) throw new ArgumentNullException("informationalAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResults.HasInformationals())
            {
                informationalAction.Invoke(functionResults);
            } 
            else
            {
                elseAction.Invoke(functionResults);
            }
        }

        /// <summary>
        /// Calls a informational func when one of the function results in the sequence contains informationals otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="functionResults">The sequence of function results to check for informationals.</param>
        /// <param name="informationalFunction">The func to call when there are informationals.</param>
        ///<param name="elseFunction">The func to call when there are no informationals.</param>
        ///<returns>A type of TNewResult which is returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnInformational<TResult, TNewResult>(
            this IEnumerable<IFunctionResult<TResult>> functionResults,
            Func<IEnumerable<IFunctionResult<TResult>>, TNewResult> informationalFunction,
            Func<IEnumerable<IFunctionResult<TResult>>, TNewResult> elseFunction)
        {
            if (functionResults == null) throw new ArgumentNullException("functionResults");
            if (informationalFunction == null) throw new ArgumentNullException("informationalFunction");
            if (elseFunction == null) throw new ArgumentNullException("informationalFunction");

            if (functionResults.HasInformationals())
            {
                return informationalFunction(functionResults);
            } 

            return elseFunction(functionResults);
        }     
    }
}