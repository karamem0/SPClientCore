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

    [Cmdlet("Remove", "KshTermLocalCustomProperty")]
    [OutputType(typeof(void))]
    public class RemoveTermLocalCustomPropertyCommand : ClientObjectCmdlet<ITermLocalCustomPropertyService>
    {

        public RemoveTermLocalCustomPropertyCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Term Term { get; private set; }

        [Parameter(Mandatory = true)]
        public string Name { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.RemoveObject(this.Term, this.Name);
        }

    }

}