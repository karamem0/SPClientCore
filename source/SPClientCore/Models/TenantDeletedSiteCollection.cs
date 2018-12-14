//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [ClientObject(Name = "Microsoft.Online.SharePoint.TenantAdministration.DeletedSiteProperties", Id = "{550d568e-79ff-484b-b957-e08eb256e1dc}")]
    [JsonObject()]
    public class TenantDeletedSiteCollection : ClientObject
    {

        public TenantDeletedSiteCollection()
        {
        }

        [JsonProperty()]
        public virtual int DaysRemaining { get; protected set; }

        [JsonProperty()]
        public virtual DateTime DeletionTime { get; protected set; }

        [JsonProperty()]
        public virtual Guid SiteId { get; protected set; }

        [JsonProperty()]
        public virtual string Status { get; protected set; }

        [JsonProperty()]
        public virtual int StorageMaximumLevel { get; protected set; }

        [JsonProperty()]
        public virtual string Url { get; protected set; }

        [JsonProperty()]
        public virtual int UserCodeMaximumLevel { get; protected set; }

    }

}
