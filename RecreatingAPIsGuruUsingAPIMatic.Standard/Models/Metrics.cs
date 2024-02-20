// <copyright file="Metrics.cs" company="APIMatic">
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
    /// Metrics.
    /// </summary>
    public class Metrics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Metrics"/> class.
        /// </summary>
        public Metrics()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Metrics"/> class.
        /// </summary>
        /// <param name="numSpecs">numSpecs.</param>
        /// <param name="numAPIs">numAPIs.</param>
        /// <param name="numEndpoints">numEndpoints.</param>
        /// <param name="unreachable">unreachable.</param>
        /// <param name="invalid">invalid.</param>
        /// <param name="unofficial">unofficial.</param>
        /// <param name="fixes">fixes.</param>
        /// <param name="fixedPct">fixedPct.</param>
        /// <param name="datasets">datasets.</param>
        /// <param name="stars">stars.</param>
        /// <param name="issues">issues.</param>
        /// <param name="thisWeek">thisWeek.</param>
        /// <param name="numDrivers">numDrivers.</param>
        /// <param name="numProviders">numProviders.</param>
        public Metrics(
            int numSpecs,
            int numAPIs,
            int numEndpoints,
            int? unreachable = null,
            int? invalid = null,
            int? unofficial = null,
            int? fixes = null,
            int? fixedPct = null,
            object datasets = null,
            int? stars = null,
            int? issues = null,
            Models.ThisWeek thisWeek = null,
            int? numDrivers = null,
            int? numProviders = null)
        {
            this.NumSpecs = numSpecs;
            this.NumAPIs = numAPIs;
            this.NumEndpoints = numEndpoints;
            this.Unreachable = unreachable;
            this.Invalid = invalid;
            this.Unofficial = unofficial;
            this.Fixes = fixes;
            this.FixedPct = fixedPct;
            this.Datasets = datasets;
            this.Stars = stars;
            this.Issues = issues;
            this.ThisWeek = thisWeek;
            this.NumDrivers = numDrivers;
            this.NumProviders = numProviders;
        }

        /// <summary>
        /// Number of API definitions including different versions of the same API
        /// </summary>
        [JsonProperty("numSpecs")]
        public int NumSpecs { get; set; }

        /// <summary>
        /// Number of unique APIs
        /// </summary>
        [JsonProperty("numAPIs")]
        public int NumAPIs { get; set; }

        /// <summary>
        /// Total number of endpoints inside all definitions
        /// </summary>
        [JsonProperty("numEndpoints")]
        public int NumEndpoints { get; set; }

        /// <summary>
        /// Number of unreachable (4XX,5XX status) APIs
        /// </summary>
        [JsonProperty("unreachable", NullValueHandling = NullValueHandling.Ignore)]
        public int? Unreachable { get; set; }

        /// <summary>
        /// Number of newly invalid APIs
        /// </summary>
        [JsonProperty("invalid", NullValueHandling = NullValueHandling.Ignore)]
        public int? Invalid { get; set; }

        /// <summary>
        /// Number of unofficial APIs
        /// </summary>
        [JsonProperty("unofficial", NullValueHandling = NullValueHandling.Ignore)]
        public int? Unofficial { get; set; }

        /// <summary>
        /// Total number of fixes applied across all APIs
        /// </summary>
        [JsonProperty("fixes", NullValueHandling = NullValueHandling.Ignore)]
        public int? Fixes { get; set; }

        /// <summary>
        /// Percentage of all APIs where auto fixes have been applied
        /// </summary>
        [JsonProperty("fixedPct", NullValueHandling = NullValueHandling.Ignore)]
        public int? FixedPct { get; set; }

        /// <summary>
        /// Data used for charting etc
        /// </summary>
        [JsonProperty("datasets", NullValueHandling = NullValueHandling.Ignore)]
        public object Datasets { get; set; }

        /// <summary>
        /// GitHub stars for our main repo
        /// </summary>
        [JsonProperty("stars", NullValueHandling = NullValueHandling.Ignore)]
        public int? Stars { get; set; }

        /// <summary>
        /// Open GitHub issues on our main repo
        /// </summary>
        [JsonProperty("issues", NullValueHandling = NullValueHandling.Ignore)]
        public int? Issues { get; set; }

        /// <summary>
        /// Summary totals for the last 7 days
        /// </summary>
        [JsonProperty("thisWeek", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ThisWeek ThisWeek { get; set; }

        /// <summary>
        /// Number of methods of API retrieval
        /// </summary>
        [JsonProperty("numDrivers", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumDrivers { get; set; }

        /// <summary>
        /// Number of API providers in directory
        /// </summary>
        [JsonProperty("numProviders", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumProviders { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Metrics : ({string.Join(", ", toStringOutput)})";
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
            return obj is Metrics other &&                this.NumSpecs.Equals(other.NumSpecs) &&
                this.NumAPIs.Equals(other.NumAPIs) &&
                this.NumEndpoints.Equals(other.NumEndpoints) &&
                ((this.Unreachable == null && other.Unreachable == null) || (this.Unreachable?.Equals(other.Unreachable) == true)) &&
                ((this.Invalid == null && other.Invalid == null) || (this.Invalid?.Equals(other.Invalid) == true)) &&
                ((this.Unofficial == null && other.Unofficial == null) || (this.Unofficial?.Equals(other.Unofficial) == true)) &&
                ((this.Fixes == null && other.Fixes == null) || (this.Fixes?.Equals(other.Fixes) == true)) &&
                ((this.FixedPct == null && other.FixedPct == null) || (this.FixedPct?.Equals(other.FixedPct) == true)) &&
                ((this.Datasets == null && other.Datasets == null) || (this.Datasets?.Equals(other.Datasets) == true)) &&
                ((this.Stars == null && other.Stars == null) || (this.Stars?.Equals(other.Stars) == true)) &&
                ((this.Issues == null && other.Issues == null) || (this.Issues?.Equals(other.Issues) == true)) &&
                ((this.ThisWeek == null && other.ThisWeek == null) || (this.ThisWeek?.Equals(other.ThisWeek) == true)) &&
                ((this.NumDrivers == null && other.NumDrivers == null) || (this.NumDrivers?.Equals(other.NumDrivers) == true)) &&
                ((this.NumProviders == null && other.NumProviders == null) || (this.NumProviders?.Equals(other.NumProviders) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.NumSpecs = {this.NumSpecs}");
            toStringOutput.Add($"this.NumAPIs = {this.NumAPIs}");
            toStringOutput.Add($"this.NumEndpoints = {this.NumEndpoints}");
            toStringOutput.Add($"this.Unreachable = {(this.Unreachable == null ? "null" : this.Unreachable.ToString())}");
            toStringOutput.Add($"this.Invalid = {(this.Invalid == null ? "null" : this.Invalid.ToString())}");
            toStringOutput.Add($"this.Unofficial = {(this.Unofficial == null ? "null" : this.Unofficial.ToString())}");
            toStringOutput.Add($"this.Fixes = {(this.Fixes == null ? "null" : this.Fixes.ToString())}");
            toStringOutput.Add($"this.FixedPct = {(this.FixedPct == null ? "null" : this.FixedPct.ToString())}");
            toStringOutput.Add($"Datasets = {(this.Datasets == null ? "null" : this.Datasets.ToString())}");
            toStringOutput.Add($"this.Stars = {(this.Stars == null ? "null" : this.Stars.ToString())}");
            toStringOutput.Add($"this.Issues = {(this.Issues == null ? "null" : this.Issues.ToString())}");
            toStringOutput.Add($"this.ThisWeek = {(this.ThisWeek == null ? "null" : this.ThisWeek.ToString())}");
            toStringOutput.Add($"this.NumDrivers = {(this.NumDrivers == null ? "null" : this.NumDrivers.ToString())}");
            toStringOutput.Add($"this.NumProviders = {(this.NumProviders == null ? "null" : this.NumProviders.ToString())}");
        }
    }
}