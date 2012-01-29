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

namespace Funkshun.Core.Extensions
{
    /// <summary>
    /// Static (extension) class for extending the types: 
    /// <see cref="IResult"/>, 
    /// <see cref="IResult{TResult}"/>
    /// </summary>
    public static partial class FunctionResultExtensions
    {        
        /// <summary>
        /// Calls a succes action when the function result does not contain errors.
        /// </summary>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successAction">The action to call when there are no errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnSuccess(this IResult functionResult, Action successAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a succes action when the function result does not contain errors.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successAction">The action to call when there are no errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnSuccess<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> successAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke(functionResult.ReturnValue);
            }
        }


        /// <summary>
        /// Calls a succes action when the function result does not contain errors.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successAction">The action to call when there are no errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnSuccess<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<IResult<TFunctionReturnType>> successAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a succes action when the function result does not contain errors.
        /// </summary>        
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successAction">The action to call when there are no errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnSuccess(this IResult functionResult, Action<IResult> successAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a succes func when the function result does not contain errors.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successFunction">The func to call when there are no errors.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnSuccess<TFunctionReturnType, TNewResult>(
            this IResult<TFunctionReturnType> functionResult,
            Func<IResult<TFunctionReturnType>, TNewResult> successFunction)
        {
            if (successFunction == null) throw new ArgumentNullException("successFunction");

            return !functionResult.HasErrors() ? successFunction(functionResult) : default(TNewResult);
        }

        /// <summary>
        /// Calls a succes func when the function result does not contain errors.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successFunction">The func to call when there are no errors.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnSuccess<TNewResult>(this IResult functionResult,
                                                       Func<IResult, TNewResult> successFunction)
        {
            if (successFunction == null) throw new ArgumentNullException("successFunction");

            return !functionResult.HasErrors() ? successFunction(functionResult) : default(TNewResult);
        }

        //-----

        /// <summary>
        /// Calls a succes action when the function result does not contain errors otherwise the else action.
        /// </summary>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successAction">The action to call when there are no errors.</param>
        /// <param name="elseAction">The action to call when there are errors.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnSuccess(this IResult functionResult, Action successAction, Action elseAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }


        ///<summary>
        /// Calls a succes action when the function result does not contain errors otherwise the else action.
        ///</summary>
        ///<param name="functionResult">The function result to check for errors.</param>
        ///<param name="successAction">The action to call when there are no errors.</param>
        ///<param name="elseAction">The action to call when there are errors.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnSuccess<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> successAction,
                                                          Action<TFunctionReturnType> elseAction
                                                          )
        {
            if (successAction == null) throw new ArgumentNullException("successAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke(functionResult.ReturnValue);
            } 
            else
            {
                elseAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a succes action when the function result does not contain errors otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for errors.</param>
        ///<param name="successAction">The action to call when there are no errors.</param>
        ///<param name="elseAction">The action to call when there are errors.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnSuccess<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<IResult<TFunctionReturnType>> successAction,
                                                            Action<IResult<TFunctionReturnType>> elseAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a succes action when the function result does not contain errors otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for errors.</param>
        ///<param name="successAction">The action to call when there are no errors.</param>
        ///<param name="elseAction">The action to call when there are errors.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnSuccess(this IResult functionResult, Action<IResult> successAction, Action<IResult> elseAction)
        {
            if (successAction == null) throw new ArgumentNullException("successAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (!functionResult.HasErrors())
            {
                successAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);  
            }
        }

        /// <summary>
        /// Calls a succes func when the function result does not contain errors otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<param name="functionResult">The function result to check for errors.</param>
        /// <param name="successFunction">The func to call when there are no errors.</param>
        ///<param name="elseFunction">The func to call when there are errors.</param>
        ///<returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnSuccess<TFunctionReturnType, TNewResult>(
            this IResult<TFunctionReturnType> functionResult,
            Func<IResult<TFunctionReturnType>, TNewResult> successFunction,
            Func<IResult<TFunctionReturnType>, TNewResult> elseFunction
            )
        {
            if (successFunction == null) throw new ArgumentNullException("successFunction");
            if (elseFunction == null) throw new ArgumentNullException("elseFunction");

            return !functionResult.HasErrors() ? successFunction(functionResult) : elseFunction(functionResult);
        }


        /// <summary>
        /// Calls a succes func when the function result does not contain errors otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>        
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="successFunction">The func to call when there are no errors.</param>
        /// <param name="elseFunction">The func to call when there are errors.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnSuccess<TNewResult>(this IResult functionResult,
                                                       Func<IResult, TNewResult> successFunction,
                                                       Func<IResult, TNewResult> elseFunction)
        {
            if (successFunction == null) throw new ArgumentNullException("successFunction");
            if (elseFunction == null) throw new ArgumentNullException("elseFunction");

            return !functionResult.HasErrors() ? successFunction(functionResult) : elseFunction(functionResult);
        }

    }
}