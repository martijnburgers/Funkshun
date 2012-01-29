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

namespace Funkshun.Core
{
    ///<summary>
    /// Base class for <see cref="Result{TResult}"/>.
    ///</summary>
    [Serializable]
    public class Result : IResult
    {
        readonly List<Message> _messages = new List<Message>();
        /// <summary>
        /// List of messages
        /// </summary>
        public List<Message> Messages
        {
            get { return _messages; }            
        }      
    }

    ///<summary>
    /// Class containing the return value and messages of function.
    ///</summary>
    ///<typeparam name="TResult">The type of the return value of the function result.</typeparam>
    [Serializable]
    public class Result<TResult> : Result, IResult<TResult>
    {
        /// <summary>
        /// Factory method for creating new instances.
        /// </summary>
        /// <returns></returns>
        public static Result<TResult> New()
        {
            return new Result<TResult>();
        }

        /// <summary>
        /// Return value of the function.
        /// </summary>
        public TResult ReturnValue { get; set; }

        /// <summary>
        /// The type of the return value.
        /// </summary>
        public Type ReturnType
        {
            get
            {
                return typeof (TResult);
            }
        }
    }

}
