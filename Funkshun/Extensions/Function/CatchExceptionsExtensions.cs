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
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<TResult> CatchExceptions<TResult>(this IFunction<TResult> function,
                                                                                Func<Exception, IFunctionResult<TResult>> 
                                                                                    catchFunction)
        {
            CatchExceptionDecorator<TResult> decorator;

            if (function is CatchExceptionDecorator<TResult>)
            {
                decorator = (CatchExceptionDecorator<TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<TResult>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<TResult> CatchExceptions<TResult>(this IFunction<TResult> function)
        {
            CatchExceptionDecorator<TResult> decorator;

            if (function is CatchExceptionDecorator<TResult>)
            {
                decorator = (CatchExceptionDecorator<TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T">The type of the parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T, TResult> CatchExceptions<T, TResult>(
            this IFunction<T, TResult> function, Func<Exception, IFunctionResult<TResult>> catchFunction)
        {
            CatchExceptionDecorator<T, TResult> decorator;

            if (function is CatchExceptionDecorator<T, TResult>)
            {
                decorator = (CatchExceptionDecorator<T, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T, TResult>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T">The type of the parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T, TResult> CatchExceptions<T, TResult>(
            this IFunction<T, TResult> function)
        {
            CatchExceptionDecorator<T, TResult> decorator;

            if (function is CatchExceptionDecorator<T, TResult>)
            {
                decorator = (CatchExceptionDecorator<T, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T, TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1,T2, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, TResult> CatchExceptions<T1, T2, TResult>(
            this IFunction<T1, T2, TResult> function, Func<Exception, IFunctionResult<TResult>> catchFunction)
        {
            CatchExceptionDecorator<T1, T2, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, TResult>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1, T2, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, TResult> CatchExceptions<T1, T2, TResult>(
            this IFunction<T1, T2, TResult> function)
        {
            CatchExceptionDecorator<T1, T2, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, TResult>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1,T2,T3, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, T3, TResult> CatchExceptions<T1, T2, T3, TResult>(
            this IFunction<T1, T2, T3, TResult> function, Func<Exception, IFunctionResult<TResult>> catchFunction)
        {
            CatchExceptionDecorator<T1, T2, T3, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, T3, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, T3, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, T3, TResult>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1, T2, T3, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, T3, TResult> CatchExceptions<T1, T2, T3, TResult>(
            this IFunction<T1, T2, T3, TResult> function)
        {
            CatchExceptionDecorator<T1, T2, T3, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, T3, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, T3, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, T3, TResult>(function);
            }

            return decorator;
        }


        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1,T2,T3,T4, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, T3, T4, TResult> CatchExceptions<T1, T2, T3, T4, TResult>(
            this IFunction<T1, T2, T3, T4, TResult> function, Func<Exception, IFunctionResult<TResult>> catchFunction)
        {
            CatchExceptionDecorator<T1, T2, T3, T4, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, T3, T4, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, T3, T4, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, T3, T4, TResult>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1, T2, T3, T4,  TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, T3, T4, TResult> CatchExceptions<T1, T2, T3, T4, TResult>(
            this IFunction<T1, T2, T3, T4, TResult> function)
        {
            CatchExceptionDecorator<T1, T2, T3, T4, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, T3, T4, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, T3, T4, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, T3, T4, TResult>(function);
            }

            return decorator;
        }


        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1,T2,T3,T4,T5, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult> CatchExceptions<T1, T2, T3, T4, T5, TResult>(
            this IFunction<T1, T2, T3, T4, T5, TResult> function,
            Func<Exception, IFunctionResult<TResult>> catchFunction)
        {
            CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches any exceptions thrown by the Run method of a function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchExceptionDecorator{T1, T2, T3, T4, T5, TResult}"/> which decorates the function by catching exceptions.</returns>
        public static CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult> CatchExceptions<T1, T2, T3, T4, T5, TResult>(
            this IFunction<T1, T2, T3, T4, T5, TResult> function)
        {
            CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult> decorator;

            if (function is CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult>)
            {
                decorator = (CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult>) function;
            }
            else
            {
                decorator = new CatchExceptionDecorator<T1, T2, T3, T4, T5, TResult>(function);
            }

            return decorator;
        }


        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<TResult, TException> CatchExceptions<TResult, TException>(
            this IFunction<TResult> function) where TException : Exception
        {
            CatchTExceptionDecorator<TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<TResult, TException>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<TResult, TException> CatchExceptions<TResult, TException>(
            this IFunction<TResult> function, Func<TException, IFunctionResult<TResult>> catchFunction)
            where TException : Exception
        {
            CatchTExceptionDecorator<TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<TResult, TException>(function, catchFunction);
            }

            return decorator;
        }


        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T">The type of the parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T, TResult, TException> CatchExceptions<T, TResult, TException>(
            this IFunction<T, TResult> function) where TException : Exception
        {
            CatchTExceptionDecorator<T, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T, TResult, TException>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T">The type of the parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T, TResult, TException> CatchExceptions<T, TResult, TException>(
            this IFunction<T, TResult> function, Func<TException, IFunctionResult<TResult>> catchFunction)
            where TException : Exception
        {
            CatchTExceptionDecorator<T, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T, TResult, TException>(function, catchFunction);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, TResult, TException> CatchExceptions<T1, T2, TResult, TException>
            (this IFunction<T1, T2, TResult> function) where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, TResult, TException>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, TResult, TException> CatchExceptions<T1, T2, TResult, TException>
            (this IFunction<T1, T2, TResult> function, Func<TException, IFunctionResult<TResult>> catchFunction)
            where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, TResult, TException>(function, catchFunction);
            }

            return decorator;
        }


        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, T3, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, T3, TResult, TException> CatchExceptions
            <T1, T2, T3, TResult, TException>(this IFunction<T1, T2, T3, TResult> function) where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, T3, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, T3, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, T3, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, T3, TResult, TException>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, T3, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, T3, TResult, TException> CatchExceptions
            <T1, T2, T3, TResult, TException>(this IFunction<T1, T2, T3, TResult> function,
                                              Func<TException, IFunctionResult<TResult>> catchFunction)
            where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, T3, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, T3, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, T3, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, T3, TResult, TException>(function, catchFunction);
            }

            return decorator;
        }


        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, T3, T4, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException> CatchExceptions
            <T1, T2, T3, T4, TResult, TException>(this IFunction<T1, T2, T3, T4, TResult> function)
            where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, T3, T4, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException> CatchExceptions
            <T1, T2, T3, T4, TResult, TException>(this IFunction<T1, T2, T3, T4, TResult> function,
                                                  Func<TException, IFunctionResult<TResult>> catchFunction)
            where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, T3, T4, TResult, TException>(function, catchFunction);
            }

            return decorator;
        }


        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, T3, T4, T5, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException> CatchExceptions
            <T1, T2, T3, T4, T5, TResult, TException>(this IFunction<T1, T2, T3, T4, T5, TResult> function)
            where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException>(function);
            }

            return decorator;
        }

        /// <summary>
        /// Catches exceptions a of a given exception type thrown by Run method of the function.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value of the function result.</typeparam>
        /// <typeparam name="TException">The type of the exception you want to catch.</typeparam>
        /// <typeparam name="T1">The type of the first parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the Run method in the function.</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the Run method in the function.</typeparam>
        /// <param name="function">The function for which you want to catch exceptions.</param>
        /// <param name="catchFunction">A Func delegate for handling the catched exception.</param>
        /// <returns>A <see cref="CatchTExceptionDecorator{T1, T2, T3, T4,T5, TResult, TException}"/> which decorates the function by catching exceptions.</returns>
        public static CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException> CatchExceptions
            <T1, T2, T3, T4, T5, TResult, TException>(this IFunction<T1, T2, T3, T4, T5, TResult> function,
                                                      Func<TException, IFunctionResult<TResult>> catchFunction)
            where TException : Exception
        {
            CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException> decorator;

            if (function is CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException>)
            {
                decorator = (CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException>) function;
            }
            else
            {
                decorator = new CatchTExceptionDecorator<T1, T2, T3, T4, T5, TResult, TException>(function,
                                                                                                  catchFunction);
            }

            return decorator;
        }
    }
}
