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
using Funkshun.Core.Extensions;

namespace Funkshun.Core.Decorators
{
    ///<summary>
    /// A decorator class for catching exceptions of a given exception type thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="TException">The type of the exception you want to catch.</typeparam>    
    public class CatchTExceptionDecorator<TResult, TException> : BaseCatchExceptionDecorator<TResult>, IDecorator<TResult> where TException : Exception
    {
        private readonly Func<TException, IResult<TResult>> _catchFunction;
        private readonly IFunction<TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="function">A function with no parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<TResult> function) : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with no parameters.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<TResult> function, Func<TException, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch thrown exceptions of a given exception type.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run()
        {
            try
            {
                return _baseFunction.Run();
            }
            catch (TException e)
            {
                if (_catchFunction == null)
                {
                    Message.Tag = e;

                    return this.MakeResult(default(TResult), new[] { Message });
                }

                return _catchFunction(e);
            }
        }
    }


    ///<summary>
    /// A decorator class for catching exceptions of a given exception type thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="TException">The type of the exception you want to catch.</typeparam>
    ///<typeparam name="T">The type of the parameter of the Run method in the function.</typeparam>    
    public class CatchTExceptionDecorator<T, TResult, TException> : BaseCatchExceptionDecorator<TResult>, IDecorator<T, TResult> where TException : Exception
    {
        private readonly Func<TException, IResult<TResult>> _catchFunction;
        private readonly IFunction<T, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="function">A function with one parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T, TResult> function)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with one parameter.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T, TResult> function, Func<TException, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch thrown exceptions of a given exception type.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T param1)
        {
            try
            {
                return _baseFunction.Run(param1);
            }
            catch (TException e)
            {
                if (_catchFunction == null)
                {
                    Message.Tag = e;

                    return this.MakeResult(default(TResult), new[] { Message });
                }

                return _catchFunction(e);
            }
        }
    }

    ///<summary>
    /// A decorator class for catching exceptions of a given exception type thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="TException">The type of the exception you want to catch.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>    
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>    
    public class CatchTExceptionDecorator<T1, T2, TResult, TException> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2, TResult> where TException : Exception
    {
        private readonly Func<TException, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="function">A function with two parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, TResult> function)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with two parameters.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, TResult> function, Func<TException, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch thrown exceptions of a given exception type.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2)
        {
            try
            {
                return _baseFunction.Run(param1, param2);
            }
            catch (TException e)
            {
                if (_catchFunction == null)
                {
                    Message.Tag = e;

                    return this.MakeResult(default(TResult), new[] { Message });
                }

                return _catchFunction(e);
            }
        }
    }

    ///<summary>
    /// A decorator class for catching exceptions of a given exception type thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="TException">The type of the exception you want to catch.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>    
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>    
    public class CatchTExceptionDecorator<T1, T2, T3, TResult, TException> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2, T3, TResult> where TException : Exception
    {
        private readonly Func<TException, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, T3, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="function">A function with three parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, T3, TResult> function)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with three parameters.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, T3, TResult> function, Func<TException, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch thrown exceptions of a given exception type.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3)
        {
            try
            {
                return _baseFunction.Run(param1, param2, param3);
            }
            catch (TException e)
            {
                if (_catchFunction == null)
                {
                    Message.Tag = e;

                    return this.MakeResult(default(TResult), new[] { Message });
                }

                return _catchFunction(e);
            }
        }
    }

    ///<summary>
    /// A decorator class for catching exceptions of a given exception type thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="TException">The type of the exception you want to catch.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>    
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>    
    public class CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2, T3, T4, TResult> where TException : Exception
    {
        private readonly Func<TException, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, T3, T4, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="function">A function with four parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, T3, T4, TResult> function)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with four parameters.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, T3, T4, TResult> function, Func<TException, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch thrown exceptions of a given exception type.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            try
            {
                return _baseFunction.Run(param1, param2, param3, param4);
            }
            catch (TException e)
            {
                if (_catchFunction == null)
                {
                    Message.Tag = e;

                    return this.MakeResult(default(TResult), new[] { Message });
                }

                return _catchFunction(e);
            }
        }
    }


    ///<summary>
    /// A decorator class for catching exceptions of a given exception type thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="TException">The type of the exception you want to catch.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>    
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T5">The type of the fifth parameter of the Run method in the function.</typeparam>    
    public class CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2, T3, T4, T5, TResult> where TException : Exception
    {
        private readonly Func<TException, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, T3, T4, T5, TResult> _baseFunction;

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="function">A function with five parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, T3, T4, T5, TResult> function)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with five parameters.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null.</exception>
        public CatchTExceptionDecorator(IFunction<T1, T2, T3, T4, T5, TResult> function, Func<TException, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch thrown exceptions of a given exception type.
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            try
            {
                return _baseFunction.Run(param1, param2, param3, param4, param5);
            }
            catch (TException e)
            {
                if (_catchFunction == null)
                {
                    Message.Tag = e;

                    return this.MakeResult(default(TResult), new[] { Message });
                }

                return _catchFunction(e);
            }
        }
    }


}
