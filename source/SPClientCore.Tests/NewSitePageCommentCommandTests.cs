//
// Copyright (c) 2020 karamem0
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
    [TestCategory("New-KshSitePageComment")]
    public class NewSitePageCommentCommandTests
    {

        [TestMethod()]
        public void CreateSitePageComment()
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
                var result2 = context.Runspace.InvokeCommand<Folder>(
                    "Get-KshFolder",
                    new Dictionary<string, object>()
                    {
                        { "FolderUrl", context.AppSettings["SitePageFolderUrl"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Add-KshSitePage",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result2.ElementAt(0) },
                        { "PageName", "Test Site Page 0" },
                        { "LayoutType", "Article" }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<File>(
                    "Get-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result2.ElementAt(0) },
                        { "FileName", "Test Site Page 0.aspx" }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-KshListItem",
                    new Dictionary<string, object>()
                    {
                        { "File", result4.ElementAt(0) }
                    }
                );
                var result6 = context.Runspace.InvokeCommand<SitePageComment>(
                    "New-KshSitePageComment",
                    new Dictionary<string, object>()
                    {
                        { "ListItem", result5.ElementAt(0) },
                        { "Text", "Test Comment 0" }
                    }
                );
                var result7 = context.Runspace.InvokeCommand(
                    "Remove-KshSitePageComment",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result6.ElementAt(0) }
                    }
                );
                var result8 = context.Runspace.InvokeCommand(
                    "Remove-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var actual = result6.ElementAt(0);
            }
        }

        [TestMethod()]
        public void CreateSitePageReplyComment()
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
                var result2 = context.Runspace.InvokeCommand<Folder>(
                    "Get-KshFolder",
                    new Dictionary<string, object>()
                    {
                        { "FolderUrl", context.AppSettings["SitePageFolderUrl"] }
                    }
                );
                var result3 = context.Runspace.InvokeCommand(
                    "Add-KshSitePage",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result2.ElementAt(0) },
                        { "PageName", "Test Site Page 0" },
                        { "LayoutType", "Article" }
                    }
                );
                var result4 = context.Runspace.InvokeCommand<File>(
                    "Get-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result2.ElementAt(0) },
                        { "FileName", "Test Site Page 0.aspx" }
                    }
                );
                var result5 = context.Runspace.InvokeCommand<ListItem>(
                    "Get-KshListItem",
                    new Dictionary<string, object>()
                    {
                        { "File", result4.ElementAt(0) }
                    }
                );
                var result6 = context.Runspace.InvokeCommand<SitePageComment>(
                    "New-KshSitePageComment",
                    new Dictionary<string, object>()
                    {
                        { "ListItem", result5.ElementAt(0) },
                        { "Text", "Test Comment 0" }
                    }
                );
                var result7 = context.Runspace.InvokeCommand<SitePageComment>(
                    "New-KshSitePageComment",
                    new Dictionary<string, object>()
                    {
                        { "Comment", result6.ElementAt(0) },
                        { "Text", "Test Comment 0" }
                    }
                );
                var result8 = context.Runspace.InvokeCommand(
                    "Remove-KshSitePageComment",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result6.ElementAt(0) }
                    }
                );
                var result9 = context.Runspace.InvokeCommand(
                    "Remove-KshFile",
                    new Dictionary<string, object>()
                    {
                        { "Identity", result4.ElementAt(0) }
                    }
                );
                var actual = result7.ElementAt(0);
            }
        }

    }

}