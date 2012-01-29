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
        /// Calls a warning action when the function result contains warning.
        /// </summary>
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning(this IResult functionResult, Action warningAction)
        {
            if (warningAction == null) throw new ArgumentNullException();

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke();
            }
        }

        /// <summary>
        /// Calls a warning action when the function result contains warnings.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> warningAction)
        {
            if (warningAction == null) throw new ArgumentNullException();

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a warning action when the function result contains warnings.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<IResult<TFunctionReturnType>> warningAction)
        {
            if (warningAction == null) throw new ArgumentNullException();

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a warning action when the function result contains warnings.
        /// </summary>        
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning(this IResult functionResult, Action<IResult> warningAction)
        {
            if (warningAction == null) throw new ArgumentNullException();

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a warning func when the function result contains warnings.
        /// </summary>
        /// <typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningFunction">The func to call when there are warnings.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnWarning<TFunctionReturnType, TNewResult>(
            this IResult<TFunctionReturnType> functionResult,
            Func<IResult<TFunctionReturnType>, TNewResult> warningFunction)
        {
            if (warningFunction == null) throw new ArgumentNullException();

            if (functionResult.HasWarnings())
            {
                return warningFunction(functionResult);
            }

            return default(TNewResult);
        }

        /// <summary>
        /// Calls a warning func when the function result contains warnings.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningFunction">The func to call when there are warnings.</param>
        /// <returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnWarning<TNewResult>(this IResult functionResult,
                                                       Func<IResult, TNewResult> warningFunction)
        {
            if (warningFunction == null) throw new ArgumentNullException("warningFunction");

            if (functionResult.HasWarnings())
            {
                return warningFunction(functionResult);
            }

            return default(TNewResult);
        }

        /// <summary>
        /// Calls a warning action when the function result contains warnings otherwise the else action.
        /// </summary>
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningAction">The action to call when there are warnings.</param>
        /// <param name="elseAction">The action to call when there are no warnings.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnWarning(this IResult functionResult, Action warningAction, Action elseAction)
        {
            if (warningAction == null) throw new ArgumentNullException("warningAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke();
            } 
            else
            {
                elseAction.Invoke();
            }
        }

        ///<summary>
        /// Calls a error warning when the function result contains warnings otherwise the else action.
        ///</summary>
        ///<param name="functionResult">The function result to check for warnings.</param>
        ///<param name="warningAction">The action to call when there are warnings.</param>
        ///<param name="elseAction">The action to call when there are no warnings.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnWarning<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<TFunctionReturnType> warningAction,
                                                          Action<TFunctionReturnType> elseAction
                                                          )
        {
            if (warningAction == null) throw new ArgumentNullException("warningAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke(functionResult.ReturnValue);
            } 
            else
            {
                elseAction.Invoke(functionResult.ReturnValue);
            }
        }

        /// <summary>
        /// Calls a warning action when the function result contains warnings otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for warnings.</param>
        ///<param name="warningAction">The action to call when there are warnings.</param>
        ///<param name="elseAction">The action to call when there are no warnings.</param>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public static void OnWarning<TFunctionReturnType>(this IResult<TFunctionReturnType> functionResult,
                                                          Action<IResult<TFunctionReturnType>> warningAction,
                                                            Action<IResult<TFunctionReturnType>> elseAction)
        {
            if (warningAction == null) throw new ArgumentNullException("warningAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);
            }
        }

        /// <summary>
        /// Calls a warning action when the function result contains warnings otherwise the else action.
        /// </summary>
        ///<param name="functionResult">The function result to check for warnings.</param>
        ///<param name="warningAction">The action to call when there are warnings.</param>
        ///<param name="elseAction">The action to call when there are no warnings.</param>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static void OnWarning(this IResult functionResult, Action<IResult> warningAction, Action<IResult> elseAction)
        {
            if (warningAction == null) throw new ArgumentNullException("warningAction");
            if (elseAction == null) throw new ArgumentNullException("elseAction");

            if (functionResult.HasWarnings())
            {
                warningAction.Invoke(functionResult);
            } 
            else
            {
                elseAction.Invoke(functionResult);  
            }
        }

        /// <summary>
        /// Calls a warning func when the function result contains warnings otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>
        ///<typeparam name="TFunctionReturnType">The type of the return value of the function result.</typeparam>
        ///<param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningFunction">The func to call when there are warnings.</param>
        ///<param name="elseFunction">The func to call when there are no warnings.</param>
        ///<returns>A type of TNewResult which is  returned by the func.</returns>
        ///<exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnWarning<TFunctionReturnType, TNewResult>(
            this IResult<TFunctionReturnType> functionResult,
            Func<IResult<TFunctionReturnType>, TNewResult> warningFunction,
            Func<IResult<TFunctionReturnType>, TNewResult> elseFunction
            )
        {
            if (warningFunction == null) throw new ArgumentNullException("warningFunction");
            if (elseFunction == null) throw new ArgumentNullException("elseFunction");

            if (functionResult.HasWarnings())
            {
                return warningFunction(functionResult);
            } 

            return elseFunction(functionResult);
        }

        /// <summary>
        /// Calls a warning func when the function result contains warnings otherwise the else func.
        /// </summary>
        /// <typeparam name="TNewResult">The type of the result of the func.</typeparam>        
        /// <param name="functionResult">The function result to check for warnings.</param>
        /// <param name="warningFunction">The func to call when there are warnings.</param>
        /// <param name="elseFunction">The func to call when there are no warnings.</param>
        /// <returns>A type of TNewResult which is returned by the func.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the parameters are null.</exception>
        public static TNewResult OnWarning<TNewResult>(this IResult functionResult,
                                                       Func<IResult, TNewResult> warningFunction,
                                                       Func<IResult, TNewResult> elseFunction)
        {
            if (warningFunction == null) throw new ArgumentNullException("warningFunction");
            if (elseFunction == null) throw new ArgumentNullException("elseFunction");

            if (functionResult.HasWarnings())
            {
                return warningFunction(functionResult);
            } 

            return elseFunction(functionResult);            
        }

    }
}