//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshCurrentUserProperty")]
    [OutputType(typeof(UserProperty))]
    public class GetCurrentUserPropertyCommand : ClientObjectCmdlet<IUserPropertyService>
    {

        public GetCurrentUserPropertyCommand()
        {
        }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(this.Service.GetObject());
        }

    }

}