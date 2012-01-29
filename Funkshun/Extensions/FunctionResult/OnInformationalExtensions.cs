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
        /// Calls a informational action when the function result contains informationals.
        /// </summary>
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational(this IResult functionResult, Action informationalAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a informational action when the function result contains informationals.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> informationalAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a informational action when the function result contains informationals.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<IResult<TFunctionReturnType>> informationalAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a informational action when the function result contains informationals.
        /// </summary>        
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational(this IResult functionResult, Action<IResult> informationalAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a error func when the function result contains informationals.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalFunction">The func to call when there are informationals.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnInformational<TFunctionReturnType, TNewResult>(
            this IResult<TFunctionReturnType> functionResult,
            Func<IResult<TFunctionReturnType>, TNewResult> informationalFunction)
        {
            if (informationalFunction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                return informationalFunction(functionResult);
            }

            return default(TNewResult);
        }

        /// <summary>
        /// Calls a informational func when the function result contains informationals.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalFunction">The func to call when there are informationals.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnInformational<TNewResult>(this IResult functionResult,
                                                       Func<IResult, TNewResult> informationalFunction)
        {
            if (informationalFunction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                return informationalFunction(functionResult);
            }

            return default(TNewResult);
        }

        //-----

        /// <summary>
        /// Calls a informational action when the function result contains informationals otherwise the else action.
        /// </summary>
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalAction">The action to call when there are informationals.</param>
        /// <param name="elseAction">The action to call when there are no informationals.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnInformational(this IResult functionResult, Action informationalAction, Action elseAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();
            if (elseAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }

        ///<summary>
        /// Calls a informational action when the function result contains informationals otherwise the else action.
        ///</summary>
        ///<param name="functionResult">The function result to check for informationals.</param>
        ///<param name="informationalAction">The action to call when there are informationals.</param>
        ///<param name="elseAction">The action to call when there are no informationals.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnInformational<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> informationalAction,
                                                          Action<TFunctionReturnType> elseAction
                                                          )
        {
            if (informationalAction == null) throw new ArgumentNullException();
            if (elseAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke(functionResult.ReturnValue);
            } 
            else
            {
                elseAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a informational action when the function result contains informationals otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for informationals.</param>
        ///<param name="informationalAction">The action to call when there are informationals.</param>
        ///<param name="elseAction">The action to call when there are no informationals.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnInformational<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<IResult<TFunctionReturnType>> informationalAction,
                                                            Action<IResult<TFunctionReturnType>> elseAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();
            if (elseAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a informational action when the function result contains informationals otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for informationals.</param>
        ///<param name="informationalAction">The action to call when there are informationals.</param>
        ///<param name="elseAction">The action to call when there are no informationals.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnInformational(this IResult functionResult, Action<IResult> informationalAction, Action<IResult> elseAction)
        {
            if (informationalAction == null) throw new ArgumentNullException();
            if (elseAction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                informationalAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);  
            }
        }

        /// <summary>
        /// Calls a informational func when the function result contains informationals otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalFunction">The func to call when there are informationals.</param>
        ///<param name="elseFunction">The func to call when there are no informationals.</param>
        ///<returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnInformational<TFunctionReturnType, TNewResult>(
            this IResult<TFunctionReturnType> functionResult,
            Func<IResult<TFunctionReturnType>, TNewResult> informationalFunction,
            Func<IResult<TFunctionReturnType>, TNewResult> elseFunction
            )
        {
            if (informationalFunction == null) throw new ArgumentNullException();
            if (elseFunction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                return informationalFunction(functionResult);
            } 

            return elseFunction(functionResult);
        }


        /// <summary>
        /// Calls a informational func when the function result contains informationals otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>        
        /// <param name="functionResult">The function result to check for informationals.</param>
        /// <param name="informationalFunction">The func to call when there are informationals.</param>
        /// <param name="elseFunction">The func to call when there are no informationals.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnInformational<TNewResult>(this IResult functionResult,
                                                       Func<IResult, TNewResult> informationalFunction,
                                                       Func<IResult, TNewResult> elseFunction)
        {
            if (informationalFunction == null) throw new ArgumentNullException();
            if (elseFunction == null) throw new ArgumentNullException();

            if (functionResult.HasInformationals())
            {
                return informationalFunction(functionResult);
            } 

            return elseFunction(functionResult);            
        }

    }
}