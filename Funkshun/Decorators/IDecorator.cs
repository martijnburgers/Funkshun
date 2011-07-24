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
namespace Funkshun.Core.Decorators
{
    ///<summary>
    /// Marker interface intended for function decorators to create some more hooking possiblities.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result. </typeparam>
    public interface IDecorator<TResult> : IFunction<TResult> { }

    ///<summary>
    /// Marker interface intended for function decorators to create some more hooking possiblities. 
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T">The type of the parameter of the Run method from the function.</typeparam>
    public interface IDecorator<T, TResult> : IFunction<T, TResult> { }

    ///<summary>
    /// Marker interface intended for function decorators to create some more hooking possiblities.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    public interface IDecorator<T1,T2, TResult> : IFunction<T1,T2, TResult> { }

    ///<summary>
    /// Marker interface intended for function decorators to create some more hooking possiblities.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method from the function.</typeparam>
    public interface IDecorator<T1, T2,T3, TResult> : IFunction<T1, T2,T3, TResult> { }

    ///<summary>
    /// Marker interface intended for function decorators to create some more hooking possiblities.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method from the function.</typeparam>
    public interface IDecorator<T1, T2, T3,T4, TResult> : IFunction<T1, T2, T3,T4, TResult> { }

    ///<summary>
    /// Marker interface intended for function decorators to create some hooking possiblities.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    ///<typeparam name="T1">The type of the first parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T2">The type of the second parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T3">The type of the third parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T4">The type of the fourth parameter of the Run method from the function.</typeparam>
    ///<typeparam name="T5">The type of the fifth parameter of the Run method from the function.</typeparam>
    public interface IDecorator<T1, T2, T3, T4,T5, TResult> : IFunction<T1, T2, T3, T4,T5, TResult> { }
}
