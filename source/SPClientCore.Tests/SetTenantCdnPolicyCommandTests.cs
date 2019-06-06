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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    [TestClass()]
    [TestCategory("Set-KshTenantCdnPolicy")]
    public class SetTenantCdnPolicyCommandTests
    {

        [TestMethod()]
        public void SetTenantPublicCdnPolicy()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AdminUrl"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Set-KshTenantCdnPolicy",
                    new Dictionary<string, object>()
                    {
                        { "Public", true },
                        { "Type", "IncludeFileExtensions" },
                        { "Value", "CSS,EOT,GIF,ICO,JPEG,JPG,JS,MAP,PNG,SVG,TTF,WOFF" }
                    }
                );
            }
        }

        [TestMethod()]
        public void GetTenantPrivateCdnPolicy()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand(
                    "Connect-KshSite",
                    new Dictionary<string, object>()
                    {
                        { "Url", context.AppSettings["AdminUrl"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            context.AppSettings["LoginUserName"],
                            context.AppSettings["LoginPassword"])
                        }
                    }
                );
                var result2 = context.Runspace.InvokeCommand(
                    "Set-KshTenantCdnPolicy",
                    new Dictionary<string, object>()
                    {
                        { "Private", true },
                        { "Type", "IncludeFileExtensions" },
                        { "Value", "GIF,ICO,JPEG,JPG,JS,PNG" }
                    }
                );
            }
        }

    }

}
