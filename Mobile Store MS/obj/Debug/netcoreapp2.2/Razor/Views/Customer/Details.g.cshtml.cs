#pragma checksum "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a0e3c9798a83d0950768b61ffa73ddb3563a93f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Details), @"mvc.1.0.view", @"/Views/Customer/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/Details.cshtml", typeof(AspNetCore.Views_Customer_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a0e3c9798a83d0950768b61ffa73ddb3563a93f", @"/Views/Customer/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mobile_Store_MS.ViewModel.CustomerViewModel.CustomerViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MyOrders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CustomScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(70, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(115, 110, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n  \r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(226, 42, false);
#line 14 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cus_id));

#line default
#line hidden
            EndContext();
            BeginContext(268, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(330, 38, false);
#line 17 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayFor(model => model.cus_id));

#line default
#line hidden
            EndContext();
            BeginContext(368, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(429, 44, false);
#line 20 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cus_name));

#line default
#line hidden
            EndContext();
            BeginContext(473, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(535, 40, false);
#line 23 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayFor(model => model.cus_name));

#line default
#line hidden
            EndContext();
            BeginContext(575, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(636, 43, false);
#line 26 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustRef));

#line default
#line hidden
            EndContext();
            BeginContext(679, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(741, 39, false);
#line 29 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustRef));

#line default
#line hidden
            EndContext();
            BeginContext(780, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(841, 45, false);
#line 32 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cus_phone));

#line default
#line hidden
            EndContext();
            BeginContext(886, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(948, 41, false);
#line 35 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
       Write(Html.DisplayFor(model => model.cus_phone));

#line default
#line hidden
            EndContext();
            BeginContext(989, 17, true);
            WriteLiteral("\r\n        </dd>\r\n");
            EndContext();
#line 37 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
         if (Model.Address != null)
        {

#line default
#line hidden
            BeginContext(1054, 51, true);
            WriteLiteral("            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(1106, 51, false);
#line 40 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Address.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1157, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(1231, 47, false);
#line 43 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayFor(model => model.Address.Country));

#line default
#line hidden
            EndContext();
            BeginContext(1278, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(1351, 49, false);
#line 46 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Address.State));

#line default
#line hidden
            EndContext();
            BeginContext(1400, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(1474, 45, false);
#line 49 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayFor(model => model.Address.State));

#line default
#line hidden
            EndContext();
            BeginContext(1519, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(1592, 48, false);
#line 52 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Address.City));

#line default
#line hidden
            EndContext();
            BeginContext(1640, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(1714, 44, false);
#line 55 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayFor(model => model.Address.City));

#line default
#line hidden
            EndContext();
            BeginContext(1758, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-sm-2\">\r\n                ");
            EndContext();
            BeginContext(1831, 57, false);
#line 58 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Address.StreetAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1888, 73, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-sm-10\">\r\n                ");
            EndContext();
            BeginContext(1962, 53, false);
#line 61 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
           Write(Html.DisplayFor(model => model.Address.StreetAddress));

#line default
#line hidden
            EndContext();
            BeginContext(2015, 21, true);
            WriteLiteral("\r\n            </dd>\r\n");
            EndContext();
#line 63 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(2047, 28, true);
            WriteLiteral("\r\n    </dl>\r\n</div>\r\n<div>\r\n");
            EndContext();
#line 68 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
     if (User.IsInRole("Super Admin") || User.IsInRole("Admin") || User.IsInRole("Employee"))
    {

#line default
#line hidden
            BeginContext(2177, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(2185, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a0e3c9798a83d0950768b61ffa73ddb3563a93f13728", async() => {
                BeginContext(2235, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 70 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
                               WriteLiteral(Model.cus_id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2243, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(2253, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a0e3c9798a83d0950768b61ffa73ddb3563a93f16072", async() => {
                BeginContext(2298, 14, true);
                WriteLiteral("Back to Orders");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2316, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(2326, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a0e3c9798a83d0950768b61ffa73ddb3563a93f17669", async() => {
                BeginContext(2348, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2364, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2375, 68, false);
#line 73 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
   Write(await Html.PartialAsync("~/Views/Shared/Modal.cshtml", Model.cus_id));

#line default
#line hidden
            EndContext();
#line 73 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
                                                                             
    }
    else
    {      

#line default
#line hidden
            BeginContext(2475, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(2483, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a0e3c9798a83d0950768b61ffa73ddb3563a93f19686", async() => {
                BeginContext(2531, 14, true);
                WriteLiteral("Back to Orders");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2549, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 78 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(2558, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2585, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2591, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a0e3c9798a83d0950768b61ffa73ddb3563a93f21709", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2635, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mobile_Store_MS.ViewModel.CustomerViewModel.CustomerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
