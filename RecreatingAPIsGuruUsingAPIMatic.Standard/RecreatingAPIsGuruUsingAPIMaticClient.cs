// <copyright file="RecreatingAPIsGuruUsingAPIMaticClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RecreatingAPIsGuruUsingAPIMatic.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using RecreatingAPIsGuruUsingAPIMatic.Standard.Controllers;
    using RecreatingAPIsGuruUsingAPIMatic.Standard.Http.Client;
    using RecreatingAPIsGuruUsingAPIMatic.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class RecreatingAPIsGuruUsingAPIMaticClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://api.apis.guru/v2" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly Lazy<APIsController> aPIs;

        private RecreatingAPIsGuruUsingAPIMaticClient(
            Environment environment,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.HttpClientConfiguration = httpClientConfiguration;

            globalConfiguration = new GlobalConfiguration.Builder()
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();


            this.aPIs = new Lazy<APIsController>(
                () => new APIsController(globalConfiguration));
        }

        /// <summary>
        /// Gets APIsController controller.
        /// </summary>
        public APIsController APIsController => this.aPIs.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }


        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the RecreatingAPIsGuruUsingAPIMaticClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> RecreatingAPIsGuruUsingAPIMaticClient.</returns>
        internal static RecreatingAPIsGuruUsingAPIMaticClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("RECREATING_AP_IS_GURU_USING_API_MATIC_STANDARD_ENVIRONMENT");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = RecreatingAPIsGuruUsingAPIMatic.Standard.Environment.Production;
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Creates an object of the RecreatingAPIsGuruUsingAPIMaticClient using the values provided for the builder.
            /// </summary>
            /// <returns>RecreatingAPIsGuruUsingAPIMaticClient.</returns>
            public RecreatingAPIsGuruUsingAPIMaticClient Build()
            {

                return new RecreatingAPIsGuruUsingAPIMaticClient(
                    environment,
                    httpClientConfig.Build());
            }
        }
    }
}
