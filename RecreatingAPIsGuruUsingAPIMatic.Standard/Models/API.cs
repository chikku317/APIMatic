// <copyright file="API.cs" company="APIMatic">
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
    /// API.
    /// </summary>
    public class API
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="API"/> class.
        /// </summary>
        public API()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="API"/> class.
        /// </summary>
        /// <param name="added">added.</param>
        /// <param name="preferred">preferred.</param>
        /// <param name="versions">versions.</param>
        public API(
            DateTime added,
            string preferred,
            Dictionary<string, Models.ApiVersion> versions)
        {
            this.Added = added;
            this.Preferred = preferred;
            this.Versions = versions;
        }

        /// <summary>
        /// Timestamp when the API was first added to the directory
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("added")]
        public DateTime Added { get; set; }

        /// <summary>
        /// Recommended version
        /// </summary>
        [JsonProperty("preferred")]
        public string Preferred { get; set; }

        /// <summary>
        /// List of supported versions of the API
        /// </summary>
        [JsonProperty("versions")]
        public Dictionary<string, Models.ApiVersion> Versions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"API : ({string.Join(", ", toStringOutput)})";
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
            return obj is API other &&                this.Added.Equals(other.Added) &&
                ((this.Preferred == null && other.Preferred == null) || (this.Preferred?.Equals(other.Preferred) == true)) &&
                ((this.Versions == null && other.Versions == null) || (this.Versions?.Equals(other.Versions) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Added = {this.Added}");
            toStringOutput.Add($"this.Preferred = {(this.Preferred == null ? "null" : this.Preferred)}");
            toStringOutput.Add($"Versions = {(this.Versions == null ? "null" : this.Versions.ToString())}");
        }
    }
}