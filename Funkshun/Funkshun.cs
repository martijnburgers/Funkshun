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
    /// Funkshun class factory
    /// </summary>
    /// <typeparam name="TFunctionType"></typeparam>
    public static class Funkshun<TFunctionType> where TFunctionType : class, IFunction, new()
    {       
        /// <summary>
        /// Gets a new or recycled instance of the specified type parameter.
        /// </summary>
        public static TFunctionType Instance
        {
            get
            {
                return FunkshunStore.AddOrGet<TFunctionType>();
            }
        }

        /// <summary>
        /// Gets a new instance of the specified type parameter.
        /// </summary>
        /// <returns></returns>
        public static TFunctionType New()
        {
            return new TFunctionType();
        }
    }
}
