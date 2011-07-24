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

namespace Funkshun.Core
{   
    /// <summary>
    /// Class with properties which defines a message which can be interacted between functions.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Constructor which fills the timestamp.
        /// </summary>
        public Message()
        {
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// The code which describes a message.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The description text of a message.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The severity of a message.
        /// </summary>
        public MessageType Severity { get; set; }

        /// <summary>
        /// The timestamp of a created message.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// A not defined tag object, could be anything you want.
        /// </summary>
        public object Tag { get; set; }
    }

    /// <summary>
    /// The severity of a message.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Error severity.
        /// </summary>
        Error,
        /// <summary>
        /// Warning severity.
        /// </summary>
        Warning,
        /// <summary>
        /// Information severity.
        /// </summary>
        Information
    }

    internal struct MessageCode
    {
        public const int ExceptionCaugth = -10;
    }
}
