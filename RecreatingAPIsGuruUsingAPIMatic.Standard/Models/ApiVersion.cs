// <copyright file="ApiVersion.cs" company="APIMatic">
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
    /// ApiVersion.
    /// </summary>
    public class ApiVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiVersion"/> class.
        /// </summary>
        public ApiVersion()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiVersion"/> class.
        /// </summary>
        /// <param name="added">added.</param>
        /// <param name="updated">updated.</param>
        /// <param name="swaggerUrl">swaggerUrl.</param>
        /// <param name="swaggerYamlUrl">swaggerYamlUrl.</param>
        /// <param name="info">info.</param>
        /// <param name="openapiVer">openapiVer.</param>
        /// <param name="link">link.</param>
        /// <param name="externalDocs">externalDocs.</param>
        public ApiVersion(
            DateTime added,
            DateTime updated,
            string swaggerUrl,
            string swaggerYamlUrl,
            object info,
            string openapiVer,
            string link = null,
            object externalDocs = null)
        {
            this.Added = added;
            this.Updated = updated;
            this.SwaggerUrl = swaggerUrl;
            this.SwaggerYamlUrl = swaggerYamlUrl;
            this.Link = link;
            this.Info = info;
            this.ExternalDocs = externalDocs;
            this.OpenapiVer = openapiVer;
        }

        /// <summary>
        /// Timestamp when the version was added
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("added")]
        public DateTime Added { get; set; }

        /// <summary>
        /// Timestamp when the version was updated
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// URL to OpenAPI definition in JSON format
        /// </summary>
        [JsonProperty("swaggerUrl")]
        public string SwaggerUrl { get; set; }

        /// <summary>
        /// URL to OpenAPI definition in YAML format
        /// </summary>
        [JsonProperty("swaggerYamlUrl")]
        public string SwaggerYamlUrl { get; set; }

        /// <summary>
        /// Link to the individual API entry for this API
        /// </summary>
        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }

        /// <summary>
        /// Copy of `info` section from OpenAPI definition
        /// </summary>
        [JsonProperty("info")]
        public object Info { get; set; }

        /// <summary>
        /// Copy of `externalDocs` section from OpenAPI definition
        /// </summary>
        [JsonProperty("externalDocs", NullValueHandling = NullValueHandling.Ignore)]
        public object ExternalDocs { get; set; }

        /// <summary>
        /// The value of the `openapi` or `swagger` property of the source definition
        /// </summary>
        [JsonProperty("openapiVer")]
        public string OpenapiVer { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ApiVersion : ({string.Join(", ", toStringOutput)})";
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
            return obj is ApiVersion other &&                this.Added.Equals(other.Added) &&
                this.Updated.Equals(other.Updated) &&
                ((this.SwaggerUrl == null && other.SwaggerUrl == null) || (this.SwaggerUrl?.Equals(other.SwaggerUrl) == true)) &&
                ((this.SwaggerYamlUrl == null && other.SwaggerYamlUrl == null) || (this.SwaggerYamlUrl?.Equals(other.SwaggerYamlUrl) == true)) &&
                ((this.Link == null && other.Link == null) || (this.Link?.Equals(other.Link) == true)) &&
                ((this.Info == null && other.Info == null) || (this.Info?.Equals(other.Info) == true)) &&
                ((this.ExternalDocs == null && other.ExternalDocs == null) || (this.ExternalDocs?.Equals(other.ExternalDocs) == true)) &&
                ((this.OpenapiVer == null && other.OpenapiVer == null) || (this.OpenapiVer?.Equals(other.OpenapiVer) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Added = {this.Added}");
            toStringOutput.Add($"this.Updated = {this.Updated}");
            toStringOutput.Add($"this.SwaggerUrl = {(this.SwaggerUrl == null ? "null" : this.SwaggerUrl)}");
            toStringOutput.Add($"this.SwaggerYamlUrl = {(this.SwaggerYamlUrl == null ? "null" : this.SwaggerYamlUrl)}");
            toStringOutput.Add($"this.Link = {(this.Link == null ? "null" : this.Link)}");
            toStringOutput.Add($"Info = {(this.Info == null ? "null" : this.Info.ToString())}");
            toStringOutput.Add($"ExternalDocs = {(this.ExternalDocs == null ? "null" : this.ExternalDocs.ToString())}");
            toStringOutput.Add($"this.OpenapiVer = {(this.OpenapiVer == null ? "null" : this.OpenapiVer)}");
        }
    }
}