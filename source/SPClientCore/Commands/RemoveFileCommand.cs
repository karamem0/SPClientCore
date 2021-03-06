//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
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

    [Cmdlet("Remove", "KshFile")]
    [OutputType(typeof(void))]
    public class RemoveFileCommand : ClientObjectCmdlet<IFileService>
    {

        public RemoveFileCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        public File Identity { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter Force { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public SwitchParameter RecycleBin { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.Service.RemoveObject(this.Identity, this.Force);
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                this.ValidateSwitchParameter(nameof(this.RecycleBin));
                this.WriteObject(this.Service.RecycleObject(this.Identity));
            }
        }

    }

}
