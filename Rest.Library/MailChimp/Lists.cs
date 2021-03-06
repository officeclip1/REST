﻿using Newtonsoft.Json;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class Lists
    {
        public const string GetUrl = "https://{0}.api.mailchimp.com/3.0/lists";

        public static async Task<ListsInfo> GetLists(
            RestCredentialInfo restCredentialInfo,
            bool isUnblock = false)
        {
            var restCredential = new Rest(
                "dummy",
                restCredentialInfo.MailChimpApiKey);
            var url = string.Format(
                                    GetUrl,
                                    restCredentialInfo.MailChimpLocation);
            var response1 = await restCredential.GetAsync(
                                                    url, isUnblock);
            var responseContent1 = await response1.Content.ReadAsStringAsync();
            var fetch1 = JsonConvert.DeserializeObject<ListsInfo>(responseContent1);
            return fetch1;
        }
    }
}
