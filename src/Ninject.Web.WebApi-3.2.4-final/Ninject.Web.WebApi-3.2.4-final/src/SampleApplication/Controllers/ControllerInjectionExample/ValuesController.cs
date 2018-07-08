﻿//-------------------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="Ninject Project Contributors">
//   Copyright (c) 2012 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SampleApplication.Controllers.ControllerInjectionExample
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using SampleApplication.Services.ValuesService;

    /// <summary>
    /// Controller for the values
    /// </summary>
    public class ValuesController : ApiController
    {
        private readonly IValuesProvider valuesProvider1;
        private readonly IValuesProvider valuesProvider2;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController"/> class.
        /// </summary>
        /// <param name="valuesProvider">The values provider.</param>
        public ValuesController(IValuesProvider valuesProvider1, IValuesProvider valuesProvider2)
        {
            this.valuesProvider1 = valuesProvider1;
            this.valuesProvider2 = valuesProvider2;
        }

        /// <summary>
        /// Handles: GET /values
        /// </summary>
        /// <returns>The values</returns>
        public IEnumerable<string> Get()
        {
            return this.valuesProvider1.GetValues().Union(this.valuesProvider2.GetValues());
        }
    }
}
