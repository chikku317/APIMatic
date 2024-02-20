// <copyright file="ProvidersJsonResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RecreatingAPIsGuruUsingAPIMatic.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RecreatingAPIsGuruUsingAPIMatic.Standard;
    using RecreatingAPIsGuruUsingAPIMatic.Standard.Utilities;

    /// <summary>
    /// ProvidersJsonResponse.
    /// </summary>
    public class ProvidersJsonResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvidersJsonResponse"/> class.
        /// </summary>
        public ProvidersJsonResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvidersJsonResponse"/> class.
        /// </summary>
        /// <param name="data">data.</param>
        public ProvidersJsonResponse(
            List<string> data = null)
        {
            this.Data = data;
        }

        /// <summary>
        /// Array containing JSON-formatted response
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ProvidersJsonResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is ProvidersJsonResponse other &&                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
        }
    }
}