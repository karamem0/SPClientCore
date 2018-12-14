//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public class SwitchParameterValueAttribute : Attribute
    {

        public SwitchParameterValueAttribute()
        {
        }

        public object TrueValue { get; set; }

        public object FalseValue { get; set; }

    }

}
