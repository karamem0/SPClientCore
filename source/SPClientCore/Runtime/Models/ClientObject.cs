//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public class ClientObject
    {

        private static readonly IReadOnlyDictionary<string, Type> ClientObjectDictionary =
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(ClientObject)))
                .Where(type => type.IsDefined(typeof(ClientObjectAttribute)))
                .ToDictionary(type => type.GetCustomAttribute<ClientObjectAttribute>().Name, type => type);

        public static Type GetType(string name)
        {
            return ClientObject.ClientObjectDictionary
                .Where(item => item.Key == name)
                .Select(item => item.Value)
                .SingleOrDefault();
        }

        protected ClientObject()
        {
            this.ExtensionProperties = new Dictionary<string, JToken>();
        }

        [JsonIgnore()]
        public object this[string key]
        {
            get
            {
                return this.ExtensionProperties
                    .Select(item => ClientResultValue.Create(item))
                    .Where(item => item.Key == key)
                    .Select(item => item.Value)
                    .SingleOrDefault();
            }
        }

        [JsonIgnore()]
        public IEnumerable<string> ExtensionKeys => this.ExtensionProperties
            .Select(item => ClientResultValue.Create(item))
            .Select(item => item.Key);

        [JsonProperty("_ObjectIdentity_")]
        public string ObjectIdentity { get; private set; }

        [JsonProperty("_ObjectType_")]
        public string ObjectType { get; private set; }

        [JsonProperty("_ObjectVersion_")]
        public string ObjectVersion { get; private set; }

        [JsonExtensionData()]
        protected Dictionary<string, JToken> ExtensionProperties { get; private set; }

    }

}