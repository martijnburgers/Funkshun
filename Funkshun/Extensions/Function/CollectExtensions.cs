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

using Funkshun.Core.Decorators;

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
    public static partial class FunctionExtensions
    {   
        /// <summary>
        /// Collects results returned by the Run method of a function.        
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="function">The function for which you want to collect results.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}"/> which decorates the function by collecting results from the Run method.</returns>
        public static ResultCollectorDecorator<TResult> CollectResults<TResult>(this IFunction<TResult> function)
        {
            ResultCollectorDecorator<TResult> decorator;

            if (function is ResultCollectorDecorator<TResult>)
            {
                decorator = (ResultCollectorDecorator<TResult>) function;
            }
            else
            {
                decorator = new ResultCollectorDecorator<TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Collects results returned by the Run method of a function.        
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T">The type of the first parameter.</typeparam>
        /// <param name="function">The function for which you want to collect results.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}"/> which decorates the function by collecting results from the Run method.</returns>
        public static ResultCollectorDecorator<T, TResult> CollectResults<T, TResult>(this IFunction<T, TResult> function)
        {
            ResultCollectorDecorator<T, TResult> decorator;

            if (function is ResultCollectorDecorator<T, TResult>)
            {
                decorator = (ResultCollectorDecorator<T, TResult>) function;
            }
            else
            {
                decorator = new ResultCollectorDecorator<T, TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Collects results returned by the Run method of a function.        
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="function">The function for which you want to collect results.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}"/> which decorates the function by collecting results from the Run method.</returns>
        public static ResultCollectorDecorator<T1, T2, TResult> CollectResults<T1, T2, TResult>(this IFunction<T1, T2, TResult> function)
        {
            ResultCollectorDecorator<T1, T2, TResult> decorator;

            if (function is ResultCollectorDecorator<T1, T2, TResult>)
            {
                decorator = (ResultCollectorDecorator<T1, T2, TResult>) function;
            }
            else
            {
                decorator = new ResultCollectorDecorator<T1, T2, TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Collects results returned by the Run method of a function.        
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="function">The function for which you want to collect results.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}"/> which decorates the function by collecting results from the Run method.</returns>
        public static ResultCollectorDecorator<T1, T2, T3, TResult> CollectResults<T1, T2, T3, TResult>(this IFunction<T1, T2, T3, TResult> function)
        {
            ResultCollectorDecorator<T1, T2, T3, TResult> decorator;

            if (function is ResultCollectorDecorator<T1, T2, T3, TResult>)
            {
                decorator = (ResultCollectorDecorator<T1, T2, T3, TResult>) function;
            }
            else
            {
                decorator = new ResultCollectorDecorator<T1, T2, T3, TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Collects results returned by the Run method of a function.        
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="function">The function for which you want to collect results.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}"/> which decorates the function by collecting results from the Run method.</returns>
        public static ResultCollectorDecorator<T1, T2, T3, T4, TResult> CollectResults<T1, T2, T3, T4, TResult>(this IFunction<T1, T2, T3, T4, TResult> function)
        {
            ResultCollectorDecorator<T1, T2, T3, T4, TResult> decorator;

            if (function is ResultCollectorDecorator<T1, T2, T3, T4, TResult>)
            {
                decorator = (ResultCollectorDecorator<T1, T2, T3, T4, TResult>) function;
            }
            else
            {
                decorator = new ResultCollectorDecorator<T1, T2, T3, T4, TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Collects results returned by the Run method of a function.        
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="function">The function for which you want to collect results.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}"/> which decorates the function by collecting results from the Run method.</returns>
        public static ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult> CollectResults<T1, T2, T3, T4, T5, TResult>(this IFunction<T1, T2, T3, T4, T5, TResult> function)
        {
            ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult> decorator;

            if (function is ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult>)
            {
                decorator = (ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult>) function;
            }
            else
            {
                decorator = new ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult>(function);
            }

            return decorator;
        }
    }
}