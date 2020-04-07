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

    public class JsonDateTimeConverter : JsonConverter
    {

        public JsonDateTimeConverter()
        {
        }

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = new DateTime();
            if (reader.Value == null)
            {
                return value;
            }
            if (DateTime.TryParse(reader.Value.ToString(), out value))
            {
                return value;
            }
            if (DateTimeConverter.TryParse(reader.Value.ToString(), out value))
            {
                return value;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || (DateTime)value == new DateTime())
            {
                serializer.Serialize(writer, null);
            }
            else
            {
                serializer.Serialize(writer, value);
            }
        }

    }

}
