//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    [JsonObject()]
    public class ODataRequestPayload<T> where T : ODataObject
    {

        public ODataRequestPayload(IReadOnlyDictionary<string, object> parameters)
        {
            this.Entity = Activator.CreateInstance<T>();
            foreach (var property in this.Entity.GetType().GetDeclaringProperties())
            {
                if (parameters.TryGetValue(property.Name, out var value))
                {
                    property.SetValue(this.Entity, value);
                }
            }
        }

        [JsonProperty("parameters")]
        public T Entity { get; private set; }

    }

}