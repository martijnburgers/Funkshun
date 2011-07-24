#region LICENSE
//  Funkshun.Core @VERSION
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

namespace Funkshun.Core.Extensions.Function
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
        /// Runs a (decorated) function. If the decorated function is not of type <see cref="ResultCollectorDecorator{TResult}"/> it creates one and runs it.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <param name="function">A decorated function with no parameters</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}" /> that represents a decorated function that collects function results.</returns>
        public static ResultCollectorDecorator<TResult> RunAndCollect<TResult>(this IDecorator<TResult> function)
        {
            ResultCollectorDecorator<TResult> decorator;

            if (!(function is ResultCollectorDecorator<TResult>))
            {
                decorator = new ResultCollectorDecorator<TResult>(function);
            }
            else
            {
                decorator = (ResultCollectorDecorator<TResult>)function;
            }

            decorator.Run();

            return decorator;
        }

        /// <summary>
        /// Runs a (decorated) function. If the decorated function is not of type <see cref="ResultCollectorDecorator{TResult}"/> it creates one and runs it.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T">The type of the first parameter.</typeparam>
        /// <param name="function">A decorated function with one parameter</param>
        /// <param name="param1">The first parameter of the function</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}" /> that represents a decorated function that collects function results.</returns>
        public static ResultCollectorDecorator<T, TResult> RunAndCollect<T, TResult>(this IDecorator<T, TResult> function, T param1)
        {
            ResultCollectorDecorator<T, TResult> decorator;

            if (!(function is ResultCollectorDecorator<T, TResult>))
            {
                decorator = new ResultCollectorDecorator<T, TResult>(function);
            }
            else
            {
                decorator = (ResultCollectorDecorator<T, TResult>)function;
            }

            decorator.Run(param1);

            return decorator;
        }

        /// <summary>
        /// Runs a (decorated) function. If the decorated function is not of type <see cref="ResultCollectorDecorator{TResult}"/> it creates one and runs it.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="function">A decorated function with two parameters</param>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}" /> that represents a decorated function that collects function results.</returns>
        public static ResultCollectorDecorator<T1, T2, TResult> RunAndCollect<T1, T2, TResult>(this IDecorator<T1, T2, TResult> function, T1 param1, T2 param2)
        {
            ResultCollectorDecorator<T1, T2, TResult> decorator;

            if (!(function is ResultCollectorDecorator<T1, T2, TResult>))
            {
                decorator = new ResultCollectorDecorator<T1, T2, TResult>(function);
            }
            else
            {
                decorator = (ResultCollectorDecorator<T1, T2, TResult>)function;
            }

            decorator.Run(param1, param2);

            return decorator;
        }

        /// <summary>
        /// Runs a (decorated) function. If the decorated function is not of type <see cref="ResultCollectorDecorator{TResult}"/> it creates one and runs it.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="function">A decorated function with three parameters</param>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <param name="param3">The third parameter of the function.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}" /> that represents a decorated function that collects function results.</returns>
        public static ResultCollectorDecorator<T1, T2, T3, TResult> RunAndCollect<T1, T2, T3, TResult>(this IDecorator<T1, T2, T3, TResult> function, T1 param1, T2 param2, T3 param3)
        {
            ResultCollectorDecorator<T1, T2, T3, TResult> decorator;

            if (!(function is ResultCollectorDecorator<T1, T2, T3, TResult>))
            {
                decorator = new ResultCollectorDecorator<T1, T2, T3, TResult>(function);
            }
            else
            {
                decorator = (ResultCollectorDecorator<T1, T2, T3, TResult>)function;
            }

            decorator.Run(param1, param2, param3);

            return decorator;
        }

        /// <summary>
        /// Runs a (decorated) function. If the decorated function is not of type <see cref="ResultCollectorDecorator{TResult}"/> it creates one and runs it.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <param name="function">A decorated function with four parameters</param>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <param name="param3">The third parameter of the function.</param>
        /// <param name="param4">The fourth parameter of the function.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}" /> that represents a decorated function that collects function results.</returns>
        public static ResultCollectorDecorator<T1, T2, T3, T4, TResult> RunAndCollect<T1, T2, T3, T4, TResult>(this IDecorator<T1, T2, T3, T4, TResult> function, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            ResultCollectorDecorator<T1, T2, T3, T4, TResult> decorator;

            if (!(function is ResultCollectorDecorator<T1, T2, T3, T4, TResult>))
            {
                decorator = new ResultCollectorDecorator<T1, T2, T3, T4, TResult>(function);
            }
            else
            {
                decorator = (ResultCollectorDecorator<T1, T2, T3, T4, TResult>)function;
            }

            decorator.Run(param1, param2, param3, param4);

            return decorator;
        }

        /// <summary>
        /// Runs a (decorated) function. If the decorated function is not of type <see cref="ResultCollectorDecorator{TResult}"/> it creates one and runs it.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result. </typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
        /// <param name="function">A decorated function with five parameters</param>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <param name="param3">The third parameter of the function.</param>
        /// <param name="param4">The fourth parameter of the function.</param>
        /// <param name="param5">The fifth parameter of the function.</param>
        /// <returns>A <see cref="ResultCollectorDecorator{TResult}" /> that represents a decorated function that collects function results.</returns>
        public static ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult> RunAndCollect<T1, T2, T3, T4, T5, TResult>(this IDecorator<T1, T2, T3, T4, T5, TResult> function, T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult> decorator;

            if (!(function is ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult>))
            {
                decorator = new ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult>(function);
            }
            else
            {
                decorator = (ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult>)function;
            }

            decorator.Run(param1, param2, param3, param4, param5);

            return decorator;
        }
    }
}
