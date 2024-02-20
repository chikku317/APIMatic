// <copyright file="APIsController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RecreatingAPIsGuruUsingAPIMatic.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using RecreatingAPIsGuruUsingAPIMatic.Standard;
    using RecreatingAPIsGuruUsingAPIMatic.Standard.Http.Client;
    using RecreatingAPIsGuruUsingAPIMatic.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// APIsController.
    /// </summary>
    public class APIsController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIsController"/> class.
        /// </summary>
        internal APIsController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Use this endpoint to list all the providers in the directory.
        /// </summary>
        /// <returns>Returns the Models.ProvidersJsonResponse response from the API call.</returns>
        public Models.ProvidersJsonResponse GetProviders()
            => CoreHelper.RunTask(GetProvidersAsync());

        /// <summary>
        /// Use this endpoint to list all the providers in the directory.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ProvidersJsonResponse response from the API call.</returns>
        public async Task<Models.ProvidersJsonResponse> GetProvidersAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ProvidersJsonResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/providers.json"))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Use this endpoint to list all APIs in the directory for a particular providerName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <returns>Returns the Dictionary of string, Models.API response from the API call.</returns>
        public Dictionary<string, Models.API> GetProvider(
                string provider)
            => CoreHelper.RunTask(GetProviderAsync(provider));

        /// <summary>
        /// Use this endpoint to list all APIs in the directory for a particular providerName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Dictionary of string, Models.API response from the API call.</returns>
        public async Task<Dictionary<string, Models.API>> GetProviderAsync(
                string provider,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Dictionary<string, Models.API>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/{provider}.json")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("provider", provider))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Use this endpoint to return all serviceNames in the directory for a particular providerName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <returns>Returns the Models.ServicesJsonResponse response from the API call.</returns>
        public Models.ServicesJsonResponse GetServices(
                string provider)
            => CoreHelper.RunTask(GetServicesAsync(provider));

        /// <summary>
        /// Use this endpoint to return all serviceNames in the directory for a particular providerName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ServicesJsonResponse response from the API call.</returns>
        public async Task<Models.ServicesJsonResponse> GetServicesAsync(
                string provider,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ServicesJsonResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/{provider}/services.json")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("provider", provider))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Use this endpoint to return the API entry for one specific version of an API where there is no serviceName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <param name="api">Required parameter: API version.</param>
        /// <returns>Returns the Models.API response from the API call.</returns>
        public Models.API GetAPI(
                string provider,
                string api)
            => CoreHelper.RunTask(GetAPIAsync(provider, api));

        /// <summary>
        /// Use this endpoint to return the API entry for one specific version of an API where there is no serviceName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <param name="api">Required parameter: API version.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.API response from the API call.</returns>
        public async Task<Models.API> GetAPIAsync(
                string provider,
                string api,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.API>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/specs/{provider}/{api}.json")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("provider", provider))
                      .Template(_template => _template.Setup("api", api))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Use this endpoint to returns the API entry for one specific version of an API where there is a serviceName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <param name="service">Required parameter: Specific functionality or feature that an API provides to other applications or clients.</param>
        /// <param name="api">Required parameter: API Version.</param>
        /// <returns>Returns the Models.API response from the API call.</returns>
        public Models.API GetServiceAPI(
                string provider,
                string service,
                string api)
            => CoreHelper.RunTask(GetServiceAPIAsync(provider, service, api));

        /// <summary>
        /// Use this endpoint to returns the API entry for one specific version of an API where there is a serviceName.
        /// </summary>
        /// <param name="provider">Required parameter: Entity that offers an API service to other applications or clients.</param>
        /// <param name="service">Required parameter: Specific functionality or feature that an API provides to other applications or clients.</param>
        /// <param name="api">Required parameter: API Version.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.API response from the API call.</returns>
        public async Task<Models.API> GetServiceAPIAsync(
                string provider,
                string service,
                string api,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.API>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/specs/{provider}/{service}/{api}.json")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("provider", provider))
                      .Template(_template => _template.Setup("service", service))
                      .Template(_template => _template.Setup("api", api))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Use this endpoint to list all APIs in the directory.
        /// Returns links to the OpenAPI definitions for each API in the directory.
        /// If API exist in multiple versions `preferred` one is explicitly marked.
        /// Some basic info from the OpenAPI definition is cached inside each object.
        /// This allows you to generate some simple views without needing to fetch the OpenAPI definition for each API.
        /// </summary>
        /// <returns>Returns the Dictionary of string, Models.API response from the API call.</returns>
        public Dictionary<string, Models.API> ListAPIs()
            => CoreHelper.RunTask(ListAPIsAsync());

        /// <summary>
        /// Use this endpoint to list all APIs in the directory.
        /// Returns links to the OpenAPI definitions for each API in the directory.
        /// If API exist in multiple versions `preferred` one is explicitly marked.
        /// Some basic info from the OpenAPI definition is cached inside each object.
        /// This allows you to generate some simple views without needing to fetch the OpenAPI definition for each API.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Dictionary of string, Models.API response from the API call.</returns>
        public async Task<Dictionary<string, Models.API>> ListAPIsAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Dictionary<string, Models.API>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/list.json"))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Use this endpoint to get basic metrics for the entire directory.
        /// </summary>
        /// <returns>Returns the Models.Metrics response from the API call.</returns>
        public Models.Metrics GetMetrics()
            => CoreHelper.RunTask(GetMetricsAsync());

        /// <summary>
        /// Use this endpoint to get basic metrics for the entire directory.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Metrics response from the API call.</returns>
        public async Task<Models.Metrics> GetMetricsAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Metrics>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/metrics.json"))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}