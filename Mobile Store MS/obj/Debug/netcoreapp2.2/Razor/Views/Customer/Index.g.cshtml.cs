#pragma checksum "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e49fd34ba434e0b05ae1511a03be7e4923829422"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Index), @"mvc.1.0.view", @"/Views/Customer/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Customer/Index.cshtml", typeof(AspNetCore.Views_Customer_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e49fd34ba434e0b05ae1511a03be7e4923829422", @"/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Mobile_Store_MS.ViewModel.CustomerViewModel.CustomerViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MyOrders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Filter.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(83, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(126, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
 if (User.IsInRole("Super Admin") || User.IsInRole("Admin") || User.IsInRole("Employee"))
{

#line default
#line hidden
            BeginContext(222, 17, true);
            WriteLiteral("    <p>\r\n        ");
            EndContext();
            BeginContext(239, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e49fd34ba434e0b05ae1511a03be7e49238294226978", async() => {
                BeginContext(262, 10, true);
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
            BeginContext(276, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 12 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
}

#line default
#line hidden
            BeginContext(291, 755, true);
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""panel panel-primary filterable"">
            <div class=""panel-heading rounded"">
                <h3 class=""panel-title font-weight-bold"">Customers</h3>
                <div class=""pull-right"">
                    <button class=""btn btn-default btn-xs btn-filter""><i class=""fas fa-filter""></i> Filter</button>
                </div>
            </div>
            <table class=""table table-responsive table-responsive-md table-responsive-lg"">
                <thead>

                    <tr class=""filters"">
                        <th><input type=""text"" class=""form-control"" placeholder=""#"" disabled></th>
                        <th><input type=""text"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 1046, "\"", 1104, 1);
#line 27 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
WriteAttributeValue("", 1060, Html.DisplayNameFor(model => model.CustRef), 1060, 44, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1105, 84, true);
            WriteLiteral(" disabled></th>\r\n                        <th><input type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 1189, "\"", 1248, 1);
#line 28 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
WriteAttributeValue("", 1203, Html.DisplayNameFor(model => model.cus_name), 1203, 45, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1249, 84, true);
            WriteLiteral(" disabled></th>\r\n                        <th><input type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 1333, "\"", 1395, 1);
#line 29 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
WriteAttributeValue("  ", 1347, Html.DisplayNameFor(model => model.cus_phone), 1349, 46, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1396, 130, true);
            WriteLiteral(" disabled></th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 34 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                     foreach (var item in Model)
                    {


#line default
#line hidden
            BeginContext(1601, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1698, 41, false);
#line 39 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cus_id));

#line default
#line hidden
            EndContext();
            BeginContext(1739, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1843, 42, false);
#line 42 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CustRef));

#line default
#line hidden
            EndContext();
            BeginContext(1885, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1989, 43, false);
#line 45 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cus_name));

#line default
#line hidden
            EndContext();
            BeginContext(2032, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2136, 44, false);
#line 48 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.cus_phone));

#line default
#line hidden
            EndContext();
            BeginContext(2180, 81, true);
            WriteLiteral("\r\n                            </td>\r\n\r\n\r\n\r\n                            <td>\r\n\r\n\r\n");
            EndContext();
#line 56 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                                 if (User.IsInRole("Super Admin") || User.IsInRole("Admin") || User.IsInRole("Employee"))
                                {

#line default
#line hidden
            BeginContext(2419, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(2455, 106, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e49fd34ba434e0b05ae1511a03be7e492382942213861", async() => {
                BeginContext(2507, 50, true);
                WriteLiteral("<i class=\"fas fa-info-circle\" title=\"Details\"></i>");
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
#line 58 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                                                              WriteLiteral(item.cus_id);

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
            BeginContext(2561, 53, true);
            WriteLiteral(" <span>|</span>\r\n                                    ");
            EndContext();
            BeginContext(2614, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e49fd34ba434e0b05ae1511a03be7e492382942216327", async() => {
                BeginContext(2663, 40, true);
                WriteLiteral("<i class=\"fas fa-edit\" title=\"Edit\"></i>");
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
#line 59 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                                                           WriteLiteral(item.cus_id);

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
            BeginContext(2707, 53, true);
            WriteLiteral(" <span>|</span>\r\n                                    ");
            EndContext();
            BeginContext(2760, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e49fd34ba434e0b05ae1511a03be7e492382942218781", async() => {
                BeginContext(2841, 15, true);
                WriteLiteral("Customer Orders");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Cusref", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 60 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                                                                                          WriteLiteral(item.CustRef);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Cusref"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Cusref", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Cusref"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2860, 17, true);
            WriteLiteral(" <span>|</span>\r\n");
            EndContext();
            BeginContext(2914, 67, false);
#line 61 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                               Write(await Html.PartialAsync("~/Views/Shared/Modal.cshtml", item.cus_id));

#line default
#line hidden
            EndContext();
#line 61 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                                                                                                        
                                 
                                        }

#line default
#line hidden
            BeginContext(3061, 80, true);
            WriteLiteral("\r\n\r\n\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 69 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Customer\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(3168, 148, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3345, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(3363, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e49fd34ba434e0b05ae1511a03be7e492382942222856", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3416, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(3434, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e49fd34ba434e0b05ae1511a03be7e492382942224204", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3472, 14, true);
                WriteLiteral("\r\n            ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Mobile_Store_MS.ViewModel.CustomerViewModel.CustomerViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
