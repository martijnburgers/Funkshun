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
namespace Funkshun.Core
{
    /// <summary>
    /// A interface defining a function with no parameters.
    /// </summary>    
    ///<typeparam name="TResult">The type of the return value of the function.</typeparam>
    public interface IFunction<TResult> : IFunction
    {
        /// <summary>
        /// Runs the function.
        /// </summary>
        /// <returns>A <see cref="IResult{TResult}" /> with or without a return value and a list which may or may not contain messages.</returns>
        IResult<TResult> Run();        
    }

    /// <summary>
    /// A interface defining a function with one parameter.
    /// </summary>    
    ///<typeparam name="TResult">The type of the return value of the function.</typeparam>
    ///<typeparam name="T">The type of the first parameter</typeparam>
    public interface IFunction<T, TResult> : IFunction
    {
        /// <summary>
        /// Runs the function.
        /// </summary>
        /// <param name="param1">The first parameter of the function.</param>
        /// <returns>A <see cref="IResult{TResult}" /> with or without a return value and a list which may or may not contain messages.</returns>
        IResult<TResult> Run(T param1);
    }

    /// <summary>
    /// A interface defining a function with two parameters.
    /// </summary>    
    ///<typeparam name="TResult">The type of the return value of the function.</typeparam>
    ///<typeparam name="T1">The type of the first parameter</typeparam>
    ///<typeparam name="T2">The type of the second parameter</typeparam>
    public interface IFunction<T1, T2, TResult> : IFunction
    {
        /// <summary>
        /// Runs the function.
        /// </summary>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <returns>A <see cref="IResult{TResult}" /> with or without a return value and a list which may or may not contain messages.</returns>
        IResult<TResult> Run(T1 param1, T2 param2);
    }

    /// <summary>
    /// A interface defining a function with three parameters.
    /// </summary>    
    ///<typeparam name="TResult">The type of the return value of the function.</typeparam>
    ///<typeparam name="T1">The type of the first parameter</typeparam>
    ///<typeparam name="T2">The type of the second parameter</typeparam>
    ///<typeparam name="T3">The type of the third parameter</typeparam>
    public interface IFunction<T1, T2, T3, TResult> : IFunction
    {
        /// <summary>
        /// Runs the function.
        /// </summary>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <param name="param3">The third parameter of the function.</param>
        /// <returns>A <see cref="IResult{TResult}" /> with or without a return value and a list which may or may not contain messages.</returns>
        IResult<TResult> Run(T1 param1, T2 param2, T3 param3);
    }

    /// <summary>
    /// A interface defining a function with four parameters.
    /// </summary>    
    ///<typeparam name="TResult">The type of the return value of the function.</typeparam>
    ///<typeparam name="T1">The type of the first parameter</typeparam>
    ///<typeparam name="T2">The type of the second parameter</typeparam>
    ///<typeparam name="T3">The type of the third parameter</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter</typeparam>
    public interface IFunction<T1, T2, T3, T4, TResult> : IFunction
    {
        /// <summary>
        /// Runs the function.
        /// </summary>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <param name="param3">The third parameter of the function.</param>
        /// <param name="param4">The fourth parameter of the function.</param>
        /// <returns>A <see cref="IResult{TResult}" /> with or without a return value and a list which may or may not contain messages.</returns>
        IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4);
    }

    /// <summary>
    /// A interface defining a function with five parameters.
    /// </summary>    
    ///<typeparam name="TResult">The type of the return value of the function.</typeparam>
    ///<typeparam name="T1">The type of the first parameter</typeparam>
    ///<typeparam name="T2">The type of the second parameter</typeparam>
    ///<typeparam name="T3">The type of the third parameter</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter</typeparam>
    ///<typeparam name="T5">The type of the fifth parameter</typeparam>
    public interface IFunction<T1, T2, T3, T4, T5, TResult> : IFunction
    {
        /// <summary>
        /// Runs the function.
        /// </summary>
        /// <param name="param1">The first parameter of the function.</param>
        /// <param name="param2">The second parameter of the function.</param>
        /// <param name="param3">The third parameter of the function.</param>
        /// <param name="param4">The fourth parameter of the function.</param>
        /// <param name="param5">The fifth parameter of the function.</param>
        /// <returns>A <see cref="IResult{TResult}" /> with or without a return value and a list which may or may not contain messages.</returns>
        IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5);
    }

    /// <summary>
    /// Marker interface for funkshuns
    /// </summary>
    public interface IFunction { }

}
