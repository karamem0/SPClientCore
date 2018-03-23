﻿//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Karamem0.SharePoint.PowerShell.Services.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands.Core
{

    [Cmdlet("Find", "SPRoleAssignment", DefaultParameterSetName = "ByWeb")]
    [OutputType(typeof(RoleAssignment[]))]
    public class FindRoleAssignmentCommand : PSCmdlet
    {

        public FindRoleAssignmentCommand()
        {
        }

        [Parameter(Mandatory = true, ParameterSetName = "ByList")]
        [Parameter(Mandatory = true, ParameterSetName = "ByListItem")]
        public ListPipeBind List { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ByListItem")]
        public ListItemPipeBind ListItem { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByWeb")]
        [Parameter(Mandatory = false, ParameterSetName = "ByList")]
        [Parameter(Mandatory = false, ParameterSetName = "ByListItem")]
        public string[] Includes { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByWeb")]
        [Parameter(Mandatory = false, ParameterSetName = "ByList")]
        [Parameter(Mandatory = false, ParameterSetName = "ByListItem")]
        public string[] OrderBy { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByWeb")]
        [Parameter(Mandatory = false, ParameterSetName = "ByList")]
        [Parameter(Mandatory = false, ParameterSetName = "ByListItem")]
        public int? Top { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ByWeb")]
        [Parameter(Mandatory = false, ParameterSetName = "ByList")]
        [Parameter(Mandatory = false, ParameterSetName = "ByListItem")]
        public int? Skip { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var roleAssignmentQuery = ODataQuery.Create<RoleAssignment>(this.MyInvocation.BoundParameters);
            if (this.ParameterSetName == "ByWeb")
            {
                var webService = ClientObjectService.ServiceProvider.GetService<IWebService>();
                this.WriteObject(webService.FindWebRoleAssignments(roleAssignmentQuery), true);
            }
            if (this.ParameterSetName == "ByList")
            {
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                this.WriteObject(listService.FindListRoleAssignments(list.Id, roleAssignmentQuery), true);
            }
            if (this.ParameterSetName == "ByListItem")
            {
                var listItemService = ClientObjectService.ServiceProvider.GetService<IListItemService>();
                var listService = ClientObjectService.ServiceProvider.GetService<IListService>();
                var list = listService.GetList(this.List);
                var listItem = listItemService.GetListItem(list.Id, this.ListItem);
                this.WriteObject(listItemService.FindListItemRoleAssignments(list.Id, listItem.Id, roleAssignmentQuery), true);
            }
        }

    }

}