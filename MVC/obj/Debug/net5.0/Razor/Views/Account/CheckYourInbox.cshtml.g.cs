#pragma checksum "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\Account\CheckYourInbox.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "821ec6a0c1b46a8e5250e6d06a38c0153c5751020467f0ce63b28f9f21dfb3f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_CheckYourInbox), @"mvc.1.0.view", @"/Views/Account/CheckYourInbox.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\_ViewImports.cshtml"
using MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\_ViewImports.cshtml"
using MVC.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\_ViewImports.cshtml"
using MVC_DAL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\_ViewImports.cshtml"
using MVC_BLL.InterfaceRepository;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\_ViewImports.cshtml"
using MVC_BL.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"821ec6a0c1b46a8e5250e6d06a38c0153c5751020467f0ce63b28f9f21dfb3f7", @"/Views/Account/CheckYourInbox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"80b064f5862416082e723791c5b88fbea729f5b03b13fa3414316b07a2421146", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_CheckYourInbox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Captain\source\repos\MVC.Soulation\MVC\Views\Account\CheckYourInbox.cshtml"
  
    ViewData["Title"] = "CheckYourInbox";
    Layout = "~/Views/Shared/_AuthLayout1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""main-agileinfo"">
    <div class=""agileits-top"">
        <div class=""body"">
            Password Reset Link Has Been Sent To Your Mail , Please Check Your Inbox
        </div>
        <a href=""https://mail.google.com/mail/u/0/#all"">Go To Your Inbox</a>
    </div>
</div>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
