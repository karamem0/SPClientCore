﻿//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "Microsoft.SharePoint.Marketplace.CorporateCuratedGallery.SiteCollectionAppCatalogAllowedItem")]
    public class SiteCollectionAppCatalogAllowedItem : ClientObject
    {

        public SiteCollectionAppCatalogAllowedItem()
        {
        }

        [JsonProperty()]
        public string AbsoluteUrl { get; private set; }

        [JsonProperty(PropertyName = "SiteID")]
        public Guid? SiteId { get; private set; }

    }

}
