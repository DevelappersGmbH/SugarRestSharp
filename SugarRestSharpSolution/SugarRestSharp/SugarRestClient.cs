// -----------------------------------------------------------------------
// <copyright file="SugarRestClient.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Responses;

    /// <summary>
    /// Represents SugarRestClient class
    /// </summary>
    public class SugarRestClient
    {
        private string url;
        private string username;
        private string password;

        /// <summary>
        /// Initializes a new instance of the SugarRestClient class.
        /// </summary>
        public SugarRestClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestClient class.
        /// </summary>
        /// <param name="url">SugarCrm REST API url.</param>
        public SugarRestClient(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Initializes a new instance of the SugarRestClient class.
        /// </summary>
        /// <param name="url">SugarCrm REST API Url.</param>
        /// <param name="username">SugarCrm REST API Username.</param>
        /// <param name="password">SugarCrm REST API Password.</param>
        public SugarRestClient(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Execute client based on entity type.
        /// </summary>
        /// <param name="request">The request object</param>
        /// <typeparam name="TEntity">Entity type of EntityBase type</typeparam>
        /// <returns>SugarRestResponse object.</returns>
        public async Task<SugarRestResponse> Execute<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            ModelInfo modelInfo = ModelInfo.ReadByType(typeof(TEntity));
            request.ModuleName = modelInfo.ModelName;

            SugarRestResponse response = new SugarRestResponse();
            if (!this.IsRequestValidate(ref request, ref response))
            {
                return response;
            }

            return await this.InternalExceute(request, modelInfo);
        }

        /// <summary>
        /// Execute request asynchronously using the C# SugarCrm model type.
        /// </summary>
        /// <typeparam name="TEntity">The template parameter.</typeparam>
        /// <param name="request">The request object.</param>
        /// <returns>SugarRestResponse object.</returns>
        public async Task<SugarRestResponse> ExecuteAsync<TEntity>(SugarRestRequest request) where TEntity : EntityBase 
        {
            ModelInfo modelInfo = ModelInfo.ReadByType(typeof(TEntity));
            request.ModuleName = modelInfo.ModelName;

            SugarRestResponse response = new SugarRestResponse();
            if (!this.IsRequestValidate(ref request, ref response))
            {
                return response;
            }
          
            return await this.InternalExceute(request, modelInfo);
        }

        /// <summary>
        /// Execute request.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <param name="modelInfo">The model info for the referenced SugarCrm module.</param>
        /// <returns>SugarRestResponse object.</returns>
        private async Task<SugarRestResponse> InternalExceute(SugarRestRequest request, ModelInfo modelInfo)
        {
            switch (request.RequestType)
            {
                case RequestType.ReadById:
                {
                    return await this.ExecuteGetById(request, modelInfo);
                }

                case RequestType.BulkRead:
                {
                    return await this.ExecuteGetAll(request, modelInfo);
                }

                case RequestType.PagedRead:
                {
                    return await this.ExecuteGetPaged(request, modelInfo);
                }

                case RequestType.Create:
                {
                    return await this.ExecuteInsert(request, modelInfo);
                }

                case RequestType.BulkCreate:
                {
                    return await this.ExecuteInserts(request, modelInfo);
                }

                case RequestType.Update:
                {
                    return await this.ExecuteUpdate(request, modelInfo);
                }

                case RequestType.BulkUpdate:
                {
                    return await this.ExecuteUpdates(request, modelInfo);
                }

                case RequestType.Delete:
                {
                    return await this.ExecuteDelete(request, modelInfo);
                }

                case RequestType.LinkedReadById:
                {
                    return await this.ExecuteLinkedGetById(request, modelInfo);
                }

                case RequestType.LinkedBulkRead:
                {
                    return await this.ExecuteLinkedGetAll(request, modelInfo);
                }
            }

            throw new Exception("Request type is invalid!");
        }

        /// <summary>
        /// Method checks if request is valid.
        /// </summary>
        /// <param name="request">The request object.</param>
        /// <param name="response">The response object.</param>
        /// <returns>True or false.</returns>
        private bool IsRequestValidate(ref SugarRestRequest request, ref SugarRestResponse response)
        {
            if (request == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Error = ErrorResponse.Format("Request is invalid.");
                return false;
            }

            request.Url = string.IsNullOrEmpty(request.Url) ? this.url : request.Url;
            request.Username = string.IsNullOrEmpty(request.Username) ? this.username : request.Username;
            request.Password = string.IsNullOrEmpty(request.Password) ? this.password : request.Password;

            if (!request.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Error = ErrorResponse.Format(request.ValidationMessage);
                return false;
            }

            return true;
        }
    }
}
