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
    /// <summary>
    /// Internal store for holding funkshun instances.
    /// </summary>
    internal static class FunkshunStore
    {
        private static readonly Dictionary<Type, object> Store = new Dictionary<Type, object>();
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Adds or gets a instance of the typeparam from the store.
        /// </summary>
        /// <typeparam name="TFunctionType"></typeparam>
        /// <returns></returns>
        public static TFunctionType AddOrGet<TFunctionType>() where TFunctionType : class, IFunction, new()
        {
            var result = Get<TFunctionType>();
            
            if (result == null)
            {
                lock (SyncRoot)
                {
                    result = Get<TFunctionType>();

                    if (result == null)
                    {
                        result = new TFunctionType();

                        Store.Add(typeof (TFunctionType), result);
                    }
                }
            }

            return result;                                                                  
        }

        /// <summary>
        /// Gets a instance of the typeparam from the store. IS NOT THREAD SAFE, SO DON'T MAKE IT PUBLIC!
        /// </summary>
        /// <typeparam name="TFunctionType"></typeparam>
        /// <returns>Null if no type is found</returns>
        private static TFunctionType Get<TFunctionType>() where TFunctionType : class, IFunction, new()
        {
            var type = typeof(TFunctionType);

            return Store.ContainsKey(type) ? (TFunctionType) Store[type] : null;      
        }

        /// <summary>
        /// Removes instance of the typeparam from the store.
        /// </summary>
        /// <typeparam name="TFunctionType"></typeparam>
        private static void Remove<TFunctionType>() where TFunctionType : class, IFunction, new()
        {
            var type = typeof(TFunctionType);

            if (Store.ContainsKey(type))
            {
                lock (SyncRoot)
                {
                    if (Store.ContainsKey(type))
                    {
                        Store.Remove(type);
                    }
                }
            }           
        }
    }
}
