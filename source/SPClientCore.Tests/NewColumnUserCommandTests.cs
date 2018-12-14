//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Tests.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("New-KshColumnUser")]
    public class NewColumnUserCommandTests
    {

        [TestMethod()]
        public void NewListColumnUser()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<List>(
                    "Get-KshList",
                    new Dictionary<string, object>()
                    {
                        { "ListId", context.AppSettings["List1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ColumnUser>(
                    "New-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "List", result2.ElementAt(0) },
                        { "AllowMultipleValues", false },
                        // { "ClientSideComponentId", null },
                        // { "ClientSideComponentProperties", null },
                        { "Description", "Test Column 0 Description" },
                        { "Direction", "none" },
                        { "EnforceUniqueValues", true },
                        { "Group", "Test Column 0 Group" },
                        { "Hidden", true },
                        { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                        { "Indexed", true },
                        { "JSLink", "clienttemplates.js" },
                        { "LookupColumnName", "EMail" },
                        { "Name", "TestColumn0" },
                        { "NoCrawl", true },
                        { "ReadOnly", true },
                        { "Required", true },
                        { "RelationshipDeleteBehavior", "None" },
                        { "SelectionGroupId", context.AppSettings["Group1Id"] },
                        { "SelectionMode", "PeopleOnly" },
                        { "StaticName", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "UnlimitedLengthInDocumentLibrary", true },
                        { "AddColumnOptions", "AddColumnInternalNameHint" },
                        { "AddToDefaultView", true },
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Update-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "Hidden", false },
                        { "ReadOnly", false }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-KshColumn",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

        [TestMethod()]
        public void NewListColumnUserMulti()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<List>(
                    "Get-KshList",
                    new Dictionary<string, object>()
                    {
                        { "ListId", context.AppSettings["List1Id"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand<ColumnUser>(
                    "New-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "List", result2.ElementAt(0) },
                        { "AllowMultipleValues", true },
                        // { "ClientSideComponentId", null },
                        // { "ClientSideComponentProperties", null },
                        { "Description", "Test Column 0 Description" },
                        { "Direction", "none" },
                        { "EnforceUniqueValues", false },
                        { "Group", "Test Column 0 Group" },
                        { "Hidden", true },
                        { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                        { "Indexed", false },
                        { "JSLink", "clienttemplates.js" },
                        { "LookupColumnName", "EMail" },
                        { "Name", "TestColumn0" },
                        { "NoCrawl", true },
                        { "ReadOnly", true },
                        { "Required", true },
                        { "RelationshipDeleteBehavior", "None" },
                        { "SelectionGroupId", context.AppSettings["Group1Id"] },
                        { "SelectionMode", "PeopleOnly" },
                        { "StaticName", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "UnlimitedLengthInDocumentLibrary", true },
                        { "AddColumnOptions", "AddColumnInternalNameHint" },
                        { "AddToDefaultView", true },
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Update-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) },
                        { "Hidden", false },
                        { "ReadOnly", false }
                    }
                );
                var result5 = context.Runspace.InvokeCommand(
                    "Remove-KshColumn",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result3.ElementAt(0) }
                    }
                );
                var actual = result3.ElementAt(0);
            }
        }

        [TestMethod()]
        public void NewSiteColumnUser()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ColumnUser>(
                    "New-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "AllowMultipleValues", false },
                        // { "ClientSideComponentId", null },
                        // { "ClientSideComponentProperties", null },
                        { "Description", "Test Column 0 Description" },
                        { "Direction", "none" },
                        { "EnforceUniqueValues", true },
                        { "Group", "Test Column 0 Group" },
                        { "Hidden", true },
                        { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                        { "Indexed", true },
                        { "JSLink", "clienttemplates.js" },
                        { "LookupColumnName", "EMail" },
                        { "Name", "TestColumn0" },
                        { "NoCrawl", true },
                        { "ReadOnly", true },
                        { "Required", true },
                        { "RelationshipDeleteBehavior", "None" },
                        { "SelectionGroupId", context.AppSettings["Group1Id"] },
                        { "SelectionMode", "PeopleOnly" },
                        { "StaticName", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "UnlimitedLengthInDocumentLibrary", true },
                        { "AddColumnOptions", "AddColumnInternalNameHint" },
                        { "AddToDefaultView", true },
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Update-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) },
                        { "Hidden", false },
                        { "ReadOnly", false }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-KshColumn",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void NewSiteColumnUserMulti()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<ColumnUser>(
                    "New-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "AllowMultipleValues", true },
                        // { "ClientSideComponentId", null },
                        // { "ClientSideComponentProperties", null },
                        { "Description", "Test Column 0 Description" },
                        { "Direction", "none" },
                        { "EnforceUniqueValues", false },
                        { "Group", "Test Column 0 Group" },
                        { "Hidden", true },
                        { "Id", "35aa78a6-66d7-472c-ab6b-d534193842af" },
                        { "Indexed", false },
                        { "JSLink", "clienttemplates.js" },
                        { "LookupColumnName", "EMail" },
                        { "Name", "TestColumn0" },
                        { "NoCrawl", true },
                        { "ReadOnly", true },
                        { "Required", true },
                        { "RelationshipDeleteBehavior", "None" },
                        { "SelectionGroupId", context.AppSettings["Group1Id"] },
                        { "SelectionMode", "PeopleOnly" },
                        { "StaticName", "TestColumn0" },
                        { "Title", "Test Column 0" },
                        { "UnlimitedLengthInDocumentLibrary", true },
                        { "AddColumnOptions", "AddColumnInternalNameHint" },
                        { "AddToDefaultView", true },
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Update-KshColumnUser",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) },
                        { "Hidden", false },
                        { "ReadOnly", false }
                    }
                );
                var result4 = context.Runspace.InvokeCommand(
                    "Remove-KshColumn",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result2.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

    }

}
