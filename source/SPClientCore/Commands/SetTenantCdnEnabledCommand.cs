//
// Copyright (c) 2019 karamem0
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

    [Cmdlet("Set", "KshTenantCdnEnabled")]
    [OutputType(typeof(void))]
    public class SetTenantCdnEnabledCommand : ClientObjectCmdlet<ITenantCdnService>
    {

        public SetTenantCdnEnabledCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter Public { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
        public SwitchParameter Private { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public SwitchParameter Enabled { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
        public SwitchParameter Disabled { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.ValidateSwitchParameter(nameof(this.Public));
                this.ValidateSwitchParameter(nameof(this.Enabled));
                this.Service.SetEnabled(TenantCdnType.Public, true);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.ValidateSwitchParameter(nameof(this.Public));
                this.ValidateSwitchParameter(nameof(this.Disabled));
                this.Service.SetEnabled(TenantCdnType.Public, false);
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.ValidateSwitchParameter(nameof(this.Private));
                this.ValidateSwitchParameter(nameof(this.Enabled));
                this.Service.SetEnabled(TenantCdnType.Private, true);
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                this.ValidateSwitchParameter(nameof(this.Private));
                this.ValidateSwitchParameter(nameof(this.Disabled));
                this.Service.SetEnabled(TenantCdnType.Private, false);
            }
        }

    }

}
