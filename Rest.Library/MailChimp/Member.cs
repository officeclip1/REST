﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OfficeClip.OpenSource.Integration.Rest.Library.MailChimp
{
    public class Member
    {
        public const string PostUrl = "https://{0}.api.mailchimp.com/3.0/lists/{1}/members";

        public static async Task<string> PostAsync(
            RestCredentialInfo restCredentialInfo, 
            string listId, 
            MemberInfo memberInfo)
        {
            var restCredential = new Rest(
                "dummy",
                restCredentialInfo.MailChimpApiKey);
            string url = string.Format(
                PostUrl,
                restCredentialInfo.MailChimpLocation,
                listId);
            var stringContent = new StringContent(
                                        JsonConvert.SerializeObject(memberInfo), 
                                        Encoding.UTF8, 
                                        "application/json");
            var result = await restCredential.PostAsync(url, stringContent);
            string resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;
        }

    }
}
