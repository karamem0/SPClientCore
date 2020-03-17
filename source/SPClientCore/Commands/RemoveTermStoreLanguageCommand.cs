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

    [Cmdlet("Remove", "KshTermStoreLanguage")]
    [OutputType(typeof(void))]
    public class RemoveTermStoreLanguageCommand : ClientObjectCmdlet<ITermStoreLanguageService>
    {

        public RemoveTermStoreLanguageCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public uint Lcid { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.Service.RemoveObject(this.Lcid);
        }

    }

}
