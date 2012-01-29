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
    /// <summary>
    /// A (base) decorator class for catching exceptions thrown by the Run method of a function.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class BaseCatchExceptionDecorator<TResult>
    {
        /// <summary>
        /// The default message to add to the function result when an exception is catched.
        /// </summary>
        protected readonly Message Message;

        /// <summary>
        /// Constructor
        /// </summary>        
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        protected BaseCatchExceptionDecorator(Type functionType)
        {
            if (functionType == null) throw new ArgumentNullException("functionType");

            Message = new Message
                        {
                            Code = MessageCode.ExceptionCaugth,
                            Description =
                                String.Format("Exception caugth while running function type {0}",
                                                functionType.FullName),
                            Severity = MessageType.Error,
                        };
        }
    }

    ///<summary>
    /// A decorator class for catching exceptions thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result. </typeparam>
    public class CatchExceptionDecorator<TResult> : BaseCatchExceptionDecorator<TResult>, IDecorator<TResult>
    {
        private readonly Func<Exception, IResult<TResult>> _catchFunction;
        private readonly IFunction<TResult> _baseFunction;

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with no parameters</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public CatchExceptionDecorator(IFunction<TResult> function) : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
        }

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with no parameters.</param>
        ///<param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <exception cref="ArgumentNullException">Thrown when the first parameter is null</exception>
        public CatchExceptionDecorator(IFunction<TResult> function, Func<Exception, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch any thrown exception. 
        ///</summary>
        /// <returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run()
        {            
            try
            {
                return _baseFunction.Run();
            }
            catch (Exception e)
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
    /// A decorator class for catching exceptions thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T">The type of the parameter of the Run method in the function.</typeparam>
    public class CatchExceptionDecorator<T, TResult> : BaseCatchExceptionDecorator<TResult>, IDecorator<T, TResult>
    {
        private readonly Func<Exception, IResult<TResult>> _catchFunction;
        private readonly IFunction<T, TResult> _baseFunction;

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with one parameter.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchExceptionDecorator(IFunction<T, TResult> function) : base(function.GetType())
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
        public CatchExceptionDecorator(IFunction<T, TResult> function, Func<Exception, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch any thrown exception. 
        ///</summary>        
        ///<param name="param1">The parameter of the function.</param>
        ///<returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T param1)
        {
            try
            {
                return _baseFunction.Run(param1);
            }
            catch (Exception e)
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
    /// A decorator class for catching exceptions thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    public class CatchExceptionDecorator<T1, T2, TResult> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1,T2, TResult>
    {
        private readonly Func<Exception, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1,T2, TResult> _baseFunction;

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with two parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchExceptionDecorator(IFunction<T1,T2, TResult> function): base(function.GetType())
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
        public CatchExceptionDecorator(IFunction<T1,T2, TResult> function, Func<Exception, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch any thrown exception. 
        ///</summary>        
        ///<param name="param1">The first parameter of the function.</param>
        ///<param name="param2">The second parameter of the function.</param>
        ///<returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2)
        {
            try
            {
                return _baseFunction.Run(param1, param2);
            }
            catch (Exception e)
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
    /// A decorator class for catching exceptions thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
    public class CatchExceptionDecorator<T1, T2, T3, TResult> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2,T3, TResult>
    {
        private readonly Func<Exception, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, T3, TResult> _baseFunction;

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with three parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchExceptionDecorator(IFunction<T1, T2,T3, TResult> function) : base(function.GetType())
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
        public CatchExceptionDecorator(IFunction<T1, T2, T3, TResult> function, Func<Exception, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch any thrown exception. 
        ///</summary>        
        ///<param name="param1">The first parameter of the function.</param>
        ///<param name="param2">The second parameter of the function.</param>
        ///<param name="param3">The third parameter of the function.</param>
        ///<returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3)
        {
            try
            {
                return _baseFunction.Run(param1, param2, param3);
            }
            catch (Exception e)
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
    /// A decorator class for catching exceptions thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
    public class CatchExceptionDecorator<T1, T2, T3, T4, TResult> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2, T3, T4, TResult>
    {
        private readonly Func<Exception, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, T3,T4, TResult> _baseFunction;

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with four parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchExceptionDecorator(IFunction<T1, T2, T3, T4, TResult> function) : base(function.GetType())
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
        public CatchExceptionDecorator(IFunction<T1, T2, T3, T4, TResult> function, Func<Exception, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch any thrown exception. 
        ///</summary>        
        ///<param name="param1">The first parameter of the function.</param>
        ///<param name="param2">The second parameter of the function.</param>
        ///<param name="param3">The third parameter of the function.</param>
        ///<param name="param4">The fourth parameter of the function.</param>
        ///<returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4)
        {
            try
            {
                return _baseFunction.Run(param1, param2, param3, param4);
            }
            catch (Exception e)
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
    /// A decorator class for catching exceptions thrown by Run method of the function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
    ///<typeparam name="T5">The type of the fifth parameter of the Run method in the function.</typeparam>
    public class CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult> : BaseCatchExceptionDecorator<TResult>, IDecorator<T1, T2, T3, T4,T5, TResult>
    {
        private readonly Func<Exception, IResult<TResult>> _catchFunction;
        private readonly IFunction<T1, T2, T3, T4, T5, TResult> _baseFunction;

        ///<summary>
        /// Constructor
        ///</summary>
        ///<param name="function">A function with five parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null.</exception>
        public CatchExceptionDecorator(IFunction<T1, T2, T3, T4,T5, TResult> function)
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
        public CatchExceptionDecorator(IFunction<T1, T2, T3, T4, T5, TResult> function, Func<Exception, IResult<TResult>> catchFunction)
            : base(function.GetType())
        {
            if (function == null) throw new ArgumentNullException("function");

            _baseFunction = function;
            _catchFunction = catchFunction;
        }

        ///<summary>
        /// Runs the function and catch any thrown exception. 
        ///</summary>        
        ///<param name="param1">The first parameter of the function.</param>
        ///<param name="param2">The second parameter of the function.</param>
        ///<param name="param3">The third parameter of the function.</param>
        ///<param name="param4">The fourth parameter of the function.</param>
        ///<param name="param5">The fifth parameter of the function.</param>
        ///<returns>A <see cref="IResult{TResult}" /> that represents the return value of a function.</returns>
        public IResult<TResult> Run(T1 param1, T2 param2, T3 param3, T4 param4, T5 param5)
        {
            try
            {
                return _baseFunction.Run(param1, param2, param3, param4, param5);
            }
            catch (Exception e)
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