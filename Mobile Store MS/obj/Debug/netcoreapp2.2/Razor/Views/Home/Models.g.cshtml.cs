#pragma checksum "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Home\Models.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d1efcf864d225de4c2dd9e702f52339cc40a814"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Models), @"mvc.1.0.view", @"/Views/Home/Models.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Models.cshtml", typeof(AspNetCore.Views_Home_Models))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Mobile_Store_MS;

#line default
#line hidden
#line 2 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Mobile_Store_MS.Data.Model;

#line default
#line hidden
#line 4 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#line 5 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d1efcf864d225de4c2dd9e702f52339cc40a814", @"/Views/Home/Models.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Models : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Mobile_Store_MS.ViewModel.GroupBYCompany>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Home\Models.cshtml"
    
    ViewData["Title"] = "Brand Details";

#line default
#line hidden
            BeginContext(115, 76, true);
            WriteLiteral("\r\n<h1>Models</h1>\r\n\r\n<div style=\"margin-top:100px;\" class=\"container\">\r\n    ");
            EndContext();
            BeginContext(192, 64, false);
#line 10 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Home\Models.cshtml"
Write(await Html.PartialAsync("~/Views/Shared/Products.cshtml", Model));

#line default
#line hidden
            EndContext();
            BeginContext(256, 8, true);
            WriteLiteral("\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Mobile_Store_MS.ViewModel.GroupBYCompany>> Html { get; private set; }
    }
}
#pragma warning restore 1591
