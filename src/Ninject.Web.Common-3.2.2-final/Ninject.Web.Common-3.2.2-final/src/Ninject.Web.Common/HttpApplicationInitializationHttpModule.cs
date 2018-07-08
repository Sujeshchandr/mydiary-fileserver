//-------------------------------------------------------------------------------
// <copyright file="HttpApplicationInitializationHttpModule.cs" company="bbv Software Services AG">
//   Copyright (c) 2010-2011 bbv Software Services AG
//   Author: Remo Gloor (remo.gloor@gmail.com)
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

namespace Ninject.Web.Common
{
    using System;
    using System.Web;
    using Ninject.Infrastructure.Disposal;

    /// <summary>
    /// Initializes a <see cref="HttpApplication"/> instance
    /// </summary>
    public class HttpApplicationInitializationHttpModule : DisposableObject, IHttpModule
    {
        private readonly Func<IKernel> lazyKernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpApplicationInitializationHttpModule"/> class.
        /// </summary>
        /// <param name="lazyKernel">The kernel retriever.</param>
        public HttpApplicationInitializationHttpModule(Func<IKernel> lazyKernel)
        {
            this.lazyKernel = lazyKernel;
        }

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
        public void Init(HttpApplication context)
        {
            this.lazyKernel().Inject(context);
        }
    }
}