#pragma checksum "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c84bc922e64ff4438f6e640e78826a276f8ebe90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Company_Index), @"mvc.1.0.view", @"/Views/Company/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Company/Index.cshtml", typeof(AspNetCore.Views_Company_Index))]
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
#line 1 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Mobile_Store_MS;

#line default
#line hidden
#line 2 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Mobile_Store_MS.Data.Model;

#line default
#line hidden
#line 4 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#line 5 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c84bc922e64ff4438f6e640e78826a276f8ebe90", @"/Views/Company/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Company_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Mobile_Store_MS.ViewModel.CompanyViewModel.CompanyViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Company", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("70"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vendor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CompanyModel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CustomScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(81, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = "Company Details";

#line default
#line hidden
            BeginContext(177, 32, true);
            WriteLiteral("\r\n<h1>Company Details</h1>\r\n\r\n\r\n");
            EndContext();
#line 11 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(231, 17, true);
            WriteLiteral("    <p>\r\n        ");
            EndContext();
            BeginContext(248, 130, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe909710", async() => {
                BeginContext(356, 18, true);
                WriteLiteral("Create new Company");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(378, 12, true);
            WriteLiteral("\r\n    </p>\r\n");
            EndContext();
#line 17 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
     foreach (var item in Model)
    {
        var photoPath = "~/image/" + (item.Photopath ?? "download.jpg");

#line default
#line hidden
            BeginContext(505, 195, true);
            WriteLiteral("        <div class = \"d-flex justify-content-center\">\r\n           <div class=\"col-8  card mb-3\">\r\n            <div class=\"card-header text-center font-weight-bold text-primary\">\r\n                ");
            EndContext();
            BeginContext(701, 12, false);
#line 23 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
           Write(item.Phoneid);

#line default
#line hidden
            EndContext();
            BeginContext(713, 4, true);
            WriteLiteral("  : ");
            EndContext();
            BeginContext(718, 13, false);
#line 23 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                            Write(item.Com_name);

#line default
#line hidden
            EndContext();
            BeginContext(731, 132, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"row card-body text-center\">\r\n                <div class=\"col-4\">\r\n                    ");
            EndContext();
            BeginContext(863, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c84bc922e64ff4438f6e640e78826a276f8ebe9012862", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            BeginWriteTagHelperAttribute();
#line 27 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                                                               WriteLiteral(photoPath);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 27 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(958, 156, true);
            WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"col-8 border\">\r\n                    <h4><span class=\"border-bottom\"><b>Company ID </b></span><br /> ");
            EndContext();
            BeginContext(1115, 12, false);
#line 31 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                                                                               Write(item.Phoneid);

#line default
#line hidden
            EndContext();
            BeginContext(1127, 92, true);
            WriteLiteral("</h4>\r\n                    <h4><span class=\"border-bottom\"><b>Company Name</b></span><br/>  ");
            EndContext();
            BeginContext(1220, 13, false);
#line 32 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                                                                                Write(item.Com_name);

#line default
#line hidden
            EndContext();
            BeginContext(1233, 122, true);
            WriteLiteral("</h4>\r\n                    <h4><span class=\"border-bottom\"><b class=\"border-bottom\">Company Destination</b></span><br />  ");
            EndContext();
            BeginContext(1356, 16, false);
#line 33 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                                                                                                              Write(item.com_country);

#line default
#line hidden
            EndContext();
            BeginContext(1372, 136, true);
            WriteLiteral("</h4>\r\n                </div>\r\n            </div>\r\n            <div class=\"card-footer text-center\">\r\n                \r\n                ");
            EndContext();
            BeginContext(1508, 1592, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9017041", async() => {
                BeginContext(1577, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1599, 191, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9017447", async() => {
                    BeginContext(1728, 58, true);
                    WriteLiteral("\r\n                        Add Vendor\r\n                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-PhoneId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 40 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                              WriteLiteral(item.Phoneid);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PhoneId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-PhoneId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PhoneId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1790, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1812, 196, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9020299", async() => {
                    BeginContext(1947, 57, true);
                    WriteLiteral("\r\n                        Add Model\r\n                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-PhoneId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 44 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                              WriteLiteral(item.Phoneid);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PhoneId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-PhoneId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["PhoneId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2008, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(2030, 185, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9023150", async() => {
                    BeginContext(2156, 55, true);
                    WriteLiteral("\r\n                        Details\r\n                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 48 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                         WriteLiteral(item.Phoneid);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2215, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(2237, 179, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9025976", async() => {
                    BeginContext(2360, 52, true);
                    WriteLiteral("\r\n                        Edit\r\n                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 52 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                         WriteLiteral(item.Phoneid);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2416, 29, true);
                WriteLiteral("\r\n\r\n                    <span");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 2445, "\"", 2481, 2);
                WriteAttributeValue("", 2450, "confirmDeleteSpan_", 2450, 18, true);
#line 56 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
WriteAttributeValue("", 2468, item.Phoneid, 2468, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2482, 245, true);
                WriteLiteral(" style=\"display:none\">\r\n                        <span><b>Are you sure you want to delete?</b></span>\r\n                        <button type=\"submit\" class=\"btn btn-danger\">Yes</button>\r\n                        <a href=\"#/\" class=\"btn btn-primary\"");
                EndContext();
                BeginWriteAttribute("onclick", "\r\n                           onclick=\"", 2727, "\"", 2802, 4);
                WriteAttributeValue("", 2765, "confirmDelete(\'", 2765, 15, true);
#line 60 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
WriteAttributeValue("", 2780, item.Phoneid, 2780, 13, false);

#line default
#line hidden
                WriteAttributeValue("", 2793, "\',", 2793, 2, true);
                WriteAttributeValue(" ", 2795, "false)", 2796, 7, true);
                EndWriteAttribute();
                BeginContext(2803, 65, true);
                WriteLiteral(">No</a>\r\n                    </span>\r\n\r\n                    <span");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 2868, "\"", 2897, 2);
                WriteAttributeValue("", 2873, "deleteSpan_", 2873, 11, true);
#line 63 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
WriteAttributeValue("", 2884, item.Phoneid, 2884, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2898, 62, true);
                WriteLiteral(">\r\n                        <a href=\"#/\" class=\"btn btn-danger\"");
                EndContext();
                BeginWriteAttribute("onclick", "\r\n                           onclick=\"", 2960, "\"", 3034, 4);
                WriteAttributeValue("", 2998, "confirmDelete(\'", 2998, 15, true);
#line 65 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
WriteAttributeValue("", 3013, item.Phoneid, 3013, 13, false);

#line default
#line hidden
                WriteAttributeValue("", 3026, "\',", 3026, 2, true);
                WriteAttributeValue(" ", 3028, "true)", 3029, 6, true);
                EndWriteAttribute();
                BeginContext(3035, 58, true);
                WriteLiteral(">Delete</a>\r\n                    </span>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_13.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 38 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
                                                          WriteLiteral(item.Phoneid);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3100, 44, true);
            WriteLiteral("\r\n            </div>\r\n        </div></div>\r\n");
            EndContext();
#line 70 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
    }

#line default
#line hidden
#line 70 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
     
}
else
{

#line default
#line hidden
            BeginContext(3163, 267, true);
            WriteLiteral(@"    <div class=""card"">
        <div class=""card-header"">
            No Company Added yet
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">
                Use the button below to Add new Company
            </h5>
            ");
            EndContext();
            BeginContext(3430, 134, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9034806", async() => {
                BeginContext(3542, 18, true);
                WriteLiteral("Create new Company");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3564, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 86 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Company\Index.cshtml"
}

#line default
#line hidden
            BeginContext(3597, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3616, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3622, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c84bc922e64ff4438f6e640e78826a276f8ebe9037013", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3666, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Mobile_Store_MS.ViewModel.CompanyViewModel.CompanyViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
