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
    /// <see cref="IFunctionResult"/>, 
    /// <see cref="IFunctionResult{TResult}"/>
    /// </summary>
    public static partial class FunctionResultExtensions
    {
        /// <summary>
        /// Calls a error action when the function result contains errors.
        /// </summary>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError(this IFunctionResult functionResult, Action errorAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a error action when the function result contains errors.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError<TFunctionReturnType>(this IFunctionResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> errorAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a error action when the function result contains errors.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError<TFunctionReturnType>(this IFunctionResult<TFunctionReturnType> functionResult,
                                                          Action<IFunctionResult<TFunctionReturnType>> errorAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a error action when the function result contains errors.
        /// </summary>        
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError(this IFunctionResult functionResult, Action<IFunctionResult> errorAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a error func when the function result contains errors.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorFunction">The func to call when there are errors.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnError<TFunctionReturnType, TNewResult>(
            this IFunctionResult<TFunctionReturnType> functionResult,
            Func<IFunctionResult<TFunctionReturnType>, TNewResult> errorFunction)
        {
            if (errorFunction == null) throw new ArgumentNullException("errorFunction");

            if (functionResult.HasErrors())
            {
                return errorFunction(functionResult);
            }

            return default(TNewResult);
        }

        /// <summary>
        /// Calls a error func when the function result contains errors.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorFunction">The func to call when there are errors.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnError<TNewResult>(this IFunctionResult functionResult,
                                                       Func<IFunctionResult, TNewResult> errorFunction)
        {
            if (errorFunction == null) throw new ArgumentNullException("errorFunction");

            if (functionResult.HasErrors())
            {
                return errorFunction(functionResult);
            }

            return default(TNewResult);
        }


        //-----

        /// <summary>
        /// Calls a error action when the function result contains errors otherwise the else action.
        /// </summary>
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorAction">The action to call when there are errors.</param>
        /// <param name="elseAction">The action to call when there are no errors.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnError(this IFunctionResult functionResult, Action errorAction, Action elseAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }

        ///<summary>
        /// Calls a error action when the function result contains errors otherwise the else action.
        ///</summary>
        ///<param name="functionResult">The function result to check for errors.</param>
        ///<param name="errorAction">The action to call when there are errors.</param>
        ///<param name="elseAction">The action to call when there are no errors.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnError<TFunctionReturnType>(this IFunctionResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> errorAction,
                                                          Action<TFunctionReturnType> elseAction
                                                          )
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke(functionResult.ReturnValue);
            } 
            else
            {
                elseAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a error action when the function result contains errors otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for errors.</param>
        ///<param name="errorAction">The action to call when there are errors.</param>
        ///<param name="elseAction">The action to call when there are no errors.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnError<TFunctionReturnType>(this IFunctionResult<TFunctionReturnType> functionResult,
                                                          Action<IFunctionResult<TFunctionReturnType>> errorAction,
                                                            Action<IFunctionResult<TFunctionReturnType>> elseAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a error action when the function result contains errors otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for errors.</param>
        ///<param name="errorAction">The action to call when there are errors.</param>
        ///<param name="elseAction">The action to call when there are no errors.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnError(this IFunctionResult functionResult, Action<IFunctionResult> errorAction, Action<IFunctionResult> elseAction)
        {
            if (errorAction == null) throw new ArgumentNullException("errorAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasErrors())
            {
                errorAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);  
            }
        }

        /// <summary>
        /// Calls a error func when the function result contains errors otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorFunction">The func to call when there are errors.</param>
        ///<param name="elseFunction">The func to call when there are no errors.</param>
        ///<returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnError<TFunctionReturnType, TNewResult>(
            this IFunctionResult<TFunctionReturnType> functionResult,
            Func<IFunctionResult<TFunctionReturnType>, TNewResult> errorFunction,
            Func<IFunctionResult<TFunctionReturnType>, TNewResult> elseFunction
            )
        {
            if (errorFunction == null) throw new ArgumentNullException("errorFunction");
            if (elseFunction == null) throw new ArgumentNullException("errorFunction");

            if (functionResult.HasErrors())
            {
                return errorFunction(functionResult);
            } 

            return elseFunction(functionResult);
        }

        /// <summary>
        /// Calls a error func when the function result contains errors otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>        
        /// <param name="functionResult">The function result to check for errors.</param>
        /// <param name="errorFunction">The func to call when there are errors.</param>
        /// <param name="elseFunction">The func to call when there are no errors.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnError<TNewResult>(this IFunctionResult functionResult,
                                                       Func<IFunctionResult, TNewResult> errorFunction,
                                                       Func<IFunctionResult, TNewResult> elseFunction)
        {
            if (errorFunction == null) throw new ArgumentNullException("errorFunction");
            if (elseFunction == null) throw new ArgumentNullException("elseFunction");

            if (functionResult.HasErrors())
            {
                return errorFunction(functionResult);
            } 

            return elseFunction(functionResult);            
        }

    }
}