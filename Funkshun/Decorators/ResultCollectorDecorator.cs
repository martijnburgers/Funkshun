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
using System.Linq;

namespace Funkshun.Core.Decorators
{
    /// <summary>
    /// A (base) decorator class for collecting results from multiple function calls.
    /// </summary>
    ///<typeparam name="TResult">The type of the return value of the function result. </typeparam>
    public abstract class BaseResultCollectorDecorator<TResult>
    {
        /// <summary>
        /// List of collected function results.
        /// </summary>
        protected readonly List<IResult<TResult>> Results = new List<IResult<TResult>>();

        ///<summary>
        /// Gets a sequence of collected results.
        ///</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> that contains elements of type <see cref="IResult{TResult}" />.</returns>
        public IEnumerable<IResult<TResult>> GetResults()
        {
            return Results;
        }

        ///<summary>
        /// Gets a sequence of collected results which meets the predicate.
        ///</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> that contains elements of type <see cref="IResult{TResult}" />.</returns>
        public IEnumerable<IResult<TResult>> GetResults(Predicate<IResult<TResult>> predicate)
        {            
            return Results.Where(r => predicate(r)).DefaultIfEmpty();
        }

        ///<summary>
        /// The number of collected results;
        ///</summary>
        public int Count { get { return Results.Count; } }        
    }

    ///<summary>
    /// A decorator class for collecting results from multiple function calls.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    public class ResultCollectorDecorator<TResult> : BaseResultCollectorDecorator<TResult>, IDecorator<TResult>
    {
        private readonly IFunction<TResult> _baseFunction;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="function">A function with no parameters</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public ResultCollectorDecorator(IFunction<TResult> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Runs the function and adds the result to a internal dictionary.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run()
        {            
            IResult<TResult> result = _baseFunction.Run();

            Results.Add(result);

            return result;
        }       
    }

    ///<summary>
    /// A decorator class for collecting results from multiple function calls.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T">The type of the parameter of the Run method from the function.</typeparam>
    public class ResultCollectorDecorator<T, TResult> : BaseResultCollectorDecorator<TResult>, IDecorator<T, TResult>
    {
        private readonly IFunction<T, TResult> _baseFunction;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="function">A function with one parameter</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public ResultCollectorDecorator(IFunction<T, TResult> function)
        {
            _baseFunction = function;
        }
   
        /// <summary>
        /// Runs the function and adds the result to a internal dictionary.
        /// </summary>
        /// <param name="param1">The input parameter of the function</param>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T param1)
        {
            IResult<TResult> result = _baseFunction.Run(param1);

            Results.Add(result);

            return result;
        }     
    }

    ///<summary>
    /// A decorator class for collecting results from multiple function calls.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    public class ResultCollectorDecorator<T1, T2, TResult> : BaseResultCollectorDecorator<TResult>, IDecorator<T1, T2, TResult>
    {
        private readonly IFunction<T1,T2, TResult> _baseFunction;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="function">A function with two parameters</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public ResultCollectorDecorator(IFunction<T1,T2, TResult> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        /// <summary>
        /// Runs the function and adds the result to a internal dictionary.
        /// </summary>
        /// <param name="param1">The first parameter of the function</param>
        /// <param name="param2">The second parameter of the function</param>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2)
        {
            IResult<TResult> result = _baseFunction.Run(param1, param2);

            Results.Add(result);

            return result;
        }
    }

    ///<summary>
    /// A decorator class for collecting results from multiple function calls.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method from the function.</typeparam>
    public class ResultCollectorDecorator<T1, T2, T3, TResult> : BaseResultCollectorDecorator<TResult>, IDecorator<T1, T2, T3, TResult>
    {
        private readonly IFunction<T1, T2,T3, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="function">A function with three parameters</param>        
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public ResultCollectorDecorator(IFunction<T1,T2,T3, TResult> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        /// <summary>
        /// Runs the function and adds the result to a internal dictionary.
        /// </summary>
        /// <param name="param1">The first parameter of the function</param>
        /// <param name="param2">The second parameter of the function</param>
        /// <param name="param3">The third parameter of the function</param>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3)
        {
            IResult<TResult> result = _baseFunction.Run(param1, param2,param3);

            Results.Add(result);

            return result;
        }      
    }

    ///<summary>
    /// A decorator class for collecting results from multiple function calls.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method from the function.</typeparam>        
    public class ResultCollectorDecorator<T1, T2, T3, T4, TResult> : BaseResultCollectorDecorator<TResult>, IDecorator<T1, T2, T3, T4, TResult>
    {
        private readonly IFunction<T1, T2, T3,T4, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="function">A function with four parameters</param>       
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception> 
        public ResultCollectorDecorator(IFunction<T1, T2, T3,T4, TResult> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        /// <summary>
        /// Runs the function and adds the result to a internal dictionary.
        /// </summary>
        /// <param name="param1">The first parameter of the function</param>
        /// <param name="param2">The second parameter of the function</param>
        /// <param name="param3">The third parameter of the function</param>
        /// <param name="param4">The fourth parameter of the function</param>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            IResult<TResult> result = _baseFunction.Run(param1, param2, param3, param4);

            Results.Add(result);

            return result;
        }       
    }

    ///<summary>
    /// A decorator class for collecting results from multiple function calls.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T5">The type of the fifth parameter of the Run method from the function.</typeparam>
    public class ResultCollectorDecorator<T1, T2, T3, T4, T5, TResult> : BaseResultCollectorDecorator<TResult>, IDecorator<T1, T2, T3, T4, T5, TResult>
    {
        private readonly IFunction<T1, T2, T3, T4,T5, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="function">A function with five parameters</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public ResultCollectorDecorator(IFunction<T1, T2, T3, T4, T5, TResult> function)
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        /// <summary>
        /// Runs the function and adds the result to a internal dictionary.
        /// </summary>
        /// <param name="param1">The first parameter of the function</param>
        /// <param name="param2">The second parameter of the function</param>
        /// <param name="param3">The third parameter of the function</param>
        /// <param name="param4">The fourth parameter of the function</param>
        /// <param name="param5">The fifth parameter of the function</param>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            IResult<TResult> result = _baseFunction.Run(param1, param2, param3, param4, param5);

            Results.Add(result);

            return result;
        }       
    }
}
