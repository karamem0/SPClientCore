﻿//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Core.Tests
{

    [TestClass()]
    [TestCategory("Folder")]
    public class GetFolderCommandTests
    {

        [TestMethod()]
        public void GetFolderByObject()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Folder>(
                    "Get-SPFolder",
                    new Dictionary<string, object>()
                    {
                        { "Folder", context.AppSettings["Folder1Url"] }
                    }
                );
                var result2 = context.Runspace.InvokeCommand<Folder>(
                    "Get-SPFolder",
                    new Dictionary<string, object>()
                    {
                        { "Folder", result1.ElementAt(0) }
                    }
                );
                var actual = result2.ElementAt(0);
            }
        }

        [TestMethod()]
        public void GetFolderByUrl()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<Folder>(
                    "Get-SPFolder",
                    new Dictionary<string, object>()
                    {
                        { "Folder", context.AppSettings["Folder1Url"] }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}