#pragma checksum "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f164fb98c5635b14878cf0f0b5bb5e5cadc3b378"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Purchasing_Index), @"mvc.1.0.view", @"/Views/Purchasing/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Purchasing/Index.cshtml", typeof(AspNetCore.Views_Purchasing_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f164fb98c5635b14878cf0f0b5bb5e5cadc3b378", @"/Views/Purchasing/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Purchasing_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Mobile_Store_MS.ViewModel.PurchasingViewModel.PurchasingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Purchasing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Filter.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(87, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(177, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(206, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f164fb98c5635b14878cf0f0b5bb5e5cadc3b3787147", async() => {
                BeginContext(229, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(243, 33, true);
            WriteLiteral("\r\n</p>\r\n<div class=\"container\">\r\n");
            EndContext();
#line 14 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
     if (Model.Any())
    {

#line default
#line hidden
            BeginContext(306, 1722, true);
            WriteLiteral(@"        <div class=""row"">
            <div class=""panel panel-primary filterable"">
                <div class=""panel-heading rounded"">
                    <h3 class=""panel-title font-weight-bold"">Purchasing</h3>
                    <div class=""pull-right"">
                        <button class=""btn btn-default btn-xs btn-filter""><i class=""fas fa-filter""></i> Filter</button>
                    </div>
                </div>
                <table class=""table table-responsive table-responsive-md table-responsive-lg"">
                    <thead>

                        <tr class=""filters"">
                            <th><input type=""text"" class=""form-control"" placeholder=""#"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Store Name"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Company"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Mode");
            WriteLiteral(@"l"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Vendor"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Date"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Quantity"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Amount"" disabled></th>
                            <th><input type=""text"" class=""form-control"" placeholder=""Placed By"" disabled /></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 41 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                         foreach (var item in Model)
                        {
                            var className = "";
                            if (item.Quantity <= 1)
                            {
                                className = "bg-warning";
                            }

#line default
#line hidden
            BeginContext(2332, 31, true);
            WriteLiteral("                            <tr");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2363, "\"", 2381, 1);
#line 48 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
WriteAttributeValue("", 2371, className, 2371, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2382, 77, true);
            WriteLiteral(">\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2460, 46, false);
#line 50 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.purchase_id));

#line default
#line hidden
            EndContext();
            BeginContext(2506, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2622, 44, false);
#line 53 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(2666, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2782, 43, false);
#line 56 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Com_name));

#line default
#line hidden
            EndContext();
            BeginContext(2825, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2941, 44, false);
#line 59 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.modelName));

#line default
#line hidden
            EndContext();
            BeginContext(2985, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3103, 45, false);
#line 63 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.VendorName));

#line default
#line hidden
            EndContext();
            BeginContext(3148, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3264, 39, false);
#line 66 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(3303, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3419, 43, false);
#line 69 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(3462, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3578, 41, false);
#line 72 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(3619, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3735, 38, false);
#line 75 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(Html.DisplayFor(model => item.takenBy));

#line default
#line hidden
            EndContext();
            BeginContext(3773, 155, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td class=\"d-flex flex-nowrap flex-row\">\r\n\r\n                                    ");
            EndContext();
            BeginContext(3928, 98, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f164fb98c5635b14878cf0f0b5bb5e5cadc3b37816364", async() => {
                BeginContext(3982, 40, true);
                WriteLiteral("<i class=\"fas fa-edit\" title=\"Edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 80 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                                                           WriteLiteral(item.purchase_id);

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
            BeginContext(4026, 42, true);
            WriteLiteral("  ||\r\n                                    ");
            EndContext();
            BeginContext(4068, 111, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f164fb98c5635b14878cf0f0b5bb5e5cadc3b37818814", async() => {
                BeginContext(4125, 50, true);
                WriteLiteral("<i class=\"fas fa-info-circle\" title=\"Details\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 81 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                                                              WriteLiteral(item.purchase_id);

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
            BeginContext(4179, 42, true);
            WriteLiteral("  ||\r\n                                    ");
            EndContext();
            BeginContext(4222, 72, false);
#line 82 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                               Write(await Html.PartialAsync("~/Views/Shared/Modal.cshtml", item.purchase_id));

#line default
#line hidden
            EndContext();
            BeginContext(4294, 80, true);
            WriteLiteral("\r\n\r\n\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 87 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(4401, 92, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 92 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(4517, 309, true);
            WriteLiteral(@"        <div class=""card"">
            <div class=""card-header"">
                No Purchasing Added yet
            </div>
            <div class=""card-body"">
                <h5 class=""card-title"">
                    Use the button below to Add new Purchasing
                </h5>
                ");
            EndContext();
            BeginContext(4826, 144, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f164fb98c5635b14878cf0f0b5bb5e5cadc3b37822726", async() => {
                BeginContext(4945, 21, true);
                WriteLiteral("Create new Purchasing");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4970, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 107 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(5015, 10, true);
            WriteLiteral("</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5042, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(5050, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f164fb98c5635b14878cf0f0b5bb5e5cadc3b37824968", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5103, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5109, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f164fb98c5635b14878cf0f0b5bb5e5cadc3b37826303", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5147, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Mobile_Store_MS.ViewModel.PurchasingViewModel.PurchasingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
