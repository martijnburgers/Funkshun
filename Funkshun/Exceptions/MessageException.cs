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

namespace Funkshun.Core.Exceptions
{
    /// <summary>
    /// Exception class which exposes the information of a error message.
    /// </summary>
    public class MessageException : Exception
    {
        ///<summary>
        /// The code of a specific message.
        ///</summary>
        public int Code { get; private set; }

        /// <summary>
        /// The severity of a message.
        /// </summary>
        public MessageType Severity { get; private set; }

        /// <summary>
        /// The created timestamp of message.
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        /// <summary>
        /// A object which is tagged to the message. Could be anything!
        /// </summary>
        public object Tag { get; private set; }

        /// <summary>
        /// A sequence of <see cref="Message"/> elements with the severity of MessageType.Error. Contains additional error messages!
        /// </summary>
        public IEnumerable<Message> Errors { get; private set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The message you want to throw as a exception.</param>
        /// <param name="listOfAllErrors">A sequence of additional errors messages to include in the exception.</param>
        public MessageException(Message message, IEnumerable<Message> listOfAllErrors)
            : base(message.Description)
        {
            Code = message.Code;
            Severity = message.Severity;
            TimeStamp = message.Timestamp;
            Tag = message.Tag;
            Errors = listOfAllErrors;
        }
    }
}
