//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Lock", "KshTenantSiteCollection")]
    [OutputType(typeof(void))]
    public class LockTenantSiteCollectionCommand : ClientObjectCmdlet<ITenantSiteCollectionService>
    {

        public LockTenantSiteCollectionCommand()
        {
        }


        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public TenantSiteCollection Identity { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter PassThru { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter NoWait { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.LockObjectAwait(this.Identity);
                var clientObject = this.Service.GetObjectAwait(this.Identity);
                if (this.PassThru)
                {
                    this.WriteObject(clientObject);
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.NoWait)
                {
                    this.Service.LockObject(this.Identity);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueCannotBeValue, false),
                        nameof(this.NoWait));
                }
            }
        }

    }

}
