//-------------------------------------------------------------------------------
// <copyright file="ScopeDisposedException.cs" company="bbv Software Services AG">
//   Copyright (c) 2010 bbv Software Services AG
//   Author: Remo Gloor remo.gloor@bbv.ch
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------
namespace Ninject.Extensions.NamedScope
{
    using System;

    /// <summary>
    /// This exception is thrown when a binding tries to use a scope that already has been disposed.
    /// </summary>
    public class ScopeDisposedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeDisposedException"/> class.
        /// </summary>
        public ScopeDisposedException()
            : base("The requested scope has already been disposed.")
        {
        }
    }
}