//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Remove", "KshOrganizationSharingLink")]
    [OutputType(typeof(void))]
    public class RemoveOrganizationSharingLinkCommand : ClientObjectCmdlet<ISharingLinkService>
    {

        public RemoveOrganizationSharingLinkCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public string Url { get; private set; }

        [Parameter(Mandatory = true)]
        public bool IsEditLink { get; private set; }

        [Parameter(Mandatory = true)]
        public bool RemoveAssociatedSharingLinkGroup { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.RemoveOrganizationSharingLink(this.Url, this.IsEditLink, this.RemoveAssociatedSharingLinkGroup);
        }

    }

}
