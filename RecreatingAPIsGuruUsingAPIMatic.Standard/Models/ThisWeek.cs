// <copyright file="ThisWeek.cs" company="APIMatic">
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
    /// ThisWeek.
    /// </summary>
    public class ThisWeek
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThisWeek"/> class.
        /// </summary>
        public ThisWeek()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThisWeek"/> class.
        /// </summary>
        /// <param name="added">added.</param>
        /// <param name="updated">updated.</param>
        public ThisWeek(
            int? added = null,
            int? updated = null)
        {
            this.Added = added;
            this.Updated = updated;
        }

        /// <summary>
        /// APIs added in the last week
        /// </summary>
        [JsonProperty("added", NullValueHandling = NullValueHandling.Ignore)]
        public int? Added { get; set; }

        /// <summary>
        /// APIs updated in the last week
        /// </summary>
        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public int? Updated { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ThisWeek : ({string.Join(", ", toStringOutput)})";
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
            return obj is ThisWeek other &&                ((this.Added == null && other.Added == null) || (this.Added?.Equals(other.Added) == true)) &&
                ((this.Updated == null && other.Updated == null) || (this.Updated?.Equals(other.Updated) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Added = {(this.Added == null ? "null" : this.Added.ToString())}");
            toStringOutput.Add($"this.Updated = {(this.Updated == null ? "null" : this.Updated.ToString())}");
        }
    }
}