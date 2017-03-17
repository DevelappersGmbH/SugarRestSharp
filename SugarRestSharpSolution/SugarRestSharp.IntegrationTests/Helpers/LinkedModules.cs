﻿// -----------------------------------------------------------------------
// <copyright file="LinkedModules.cs" company="SugarCrm + PocoGen + REST">
// Copyright (c) SugarCrm + PocoGen + REST. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace SugarRestSharp.IntegrationTests.Helpers
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal static class LinkedModules
    {
        public static async Task<SugarRestResponse> ReadAccountLinkContact(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest(RequestType.LinkedReadById);
            request.Parameter = accountId;

            List<string> selectedFields = new List<string>();

            selectedFields.Add(nameof(Account.Id));
            selectedFields.Add(nameof(Account.Name));
            selectedFields.Add(nameof(Account.Industry));
            selectedFields.Add(nameof(Account.Website));
            selectedFields.Add(nameof(Account.ShippingAddressCity));

            request.Options.SelectFields = selectedFields;

            Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();

            List<string> selectContactFields = new List<string>();
            selectContactFields.Add(nameof(Contact.FirstName));
            selectContactFields.Add(nameof(Contact.LastName));
            selectContactFields.Add(nameof(Contact.Title));
            selectContactFields.Add(nameof(Contact.Description));
            selectContactFields.Add(nameof(Contact.PrimaryAddressPostalcode));

            linkedListInfo[typeof(Contact)] = selectContactFields;

            request.Options.LinkedModules = linkedListInfo;

            return await client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> ReadAccountLinkItems(SugarRestClient client, string accountId)
        {
            var request = new SugarRestRequest(RequestType.LinkedReadById);
            request.Parameter = accountId;

            List<string> selectedFields = new List<string>();

            selectedFields.Add(nameof(Account.Id));
            selectedFields.Add(nameof(Account.Name));
            selectedFields.Add(nameof(Account.Industry));
            selectedFields.Add(nameof(Account.Website));
            selectedFields.Add(nameof(Account.ShippingAddressCity));

            request.Options.SelectFields = selectedFields;

            Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();
            linkedListInfo[typeof(Contact)] = null;
            linkedListInfo["Leads"] = null;
            linkedListInfo[typeof(Case)] = null;

            request.Options.LinkedModules = linkedListInfo;

            return await client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> BulkReadAccountLinkContact(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest(RequestType.LinkedBulkRead);
            request.Options.MaxResult = count;

            List<string> selectedFields = new List<string>();

            selectedFields.Add(nameof(Account.Id));
            selectedFields.Add(nameof(Account.Name));
            selectedFields.Add(nameof(Account.Industry));
            selectedFields.Add(nameof(Account.Website));
            selectedFields.Add(nameof(Account.ShippingAddressCity));

            request.Options.SelectFields = selectedFields;

            Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();

            List<string> selectContactFields = new List<string>();
            selectContactFields.Add(nameof(Contact.FirstName));
            selectContactFields.Add(nameof(Contact.LastName));
            selectContactFields.Add(nameof(Contact.Title));
            selectContactFields.Add(nameof(Contact.Description));
            selectContactFields.Add(nameof(Contact.PrimaryAddressPostalcode));

            linkedListInfo[typeof(Contact)] = selectContactFields;

            request.Options.LinkedModules = linkedListInfo;

            return await client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> BulkReadAccountLinkItems(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest(RequestType.LinkedBulkRead);
            request.Options.MaxResult = count;

            List<string> selectedFields = new List<string>();

            selectedFields.Add(nameof(Account.Id));
            selectedFields.Add(nameof(Account.Name));
            selectedFields.Add(nameof(Account.Industry));
            selectedFields.Add(nameof(Account.Website));
            selectedFields.Add(nameof(Account.ShippingAddressCity));

            request.Options.SelectFields = selectedFields;

            Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();
            linkedListInfo[typeof(Contact)] = null;
            linkedListInfo["Leads"] = null;
            linkedListInfo[typeof(Case)] = null;

            request.Options.LinkedModules = linkedListInfo;

            return await client.Execute<Account>(request);
        }

        public static async Task<SugarRestResponse> BulkReadAccountLinkItems2(SugarRestClient client, int count)
        {
            var request = new SugarRestRequest(RequestType.LinkedBulkRead);
            request.Options.MaxResult = count;

            List<string> selectedFields = new List<string>();

            selectedFields.Add("id");
            selectedFields.Add("name");
            selectedFields.Add("industry");
            selectedFields.Add("website");

            request.Options.SelectFields = selectedFields;

            Dictionary<object, List<string>> linkedListInfo = new Dictionary<object, List<string>>();

            List<string> selectContactFields = new List<string>();
            selectContactFields.Add(nameof(Contact.FirstName));
            selectContactFields.Add(nameof(Contact.LastName));
            selectContactFields.Add(nameof(Contact.Title));
            selectContactFields.Add(nameof(Contact.Description));
            selectContactFields.Add(nameof(Contact.PrimaryAddressPostalcode));

            linkedListInfo[typeof(Contact)] = selectContactFields;

            // Get all fields for Bug
            linkedListInfo["Bugs"] = null;

            request.Options.LinkedModules = linkedListInfo;

            return await client.Execute<Account>(request);
        }
    }
}

