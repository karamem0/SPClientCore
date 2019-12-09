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

    [ClientObject(Name = "SP.NavigationNodeCollection", Id = "{2d818ed7-8fef-4a1c-bceb-a9404dfa482f}")]
    [JsonObject()]
    public class NavigationNodeEnumerable : ClientObjectEnumerable<NavigationNode>
    {

        public NavigationNodeEnumerable()
        {
        }

    }

}
