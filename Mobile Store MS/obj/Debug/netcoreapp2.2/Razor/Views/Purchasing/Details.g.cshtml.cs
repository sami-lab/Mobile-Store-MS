#pragma checksum "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9909cddf0d4b42955e7f6c80d23ac8deeec1158"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Purchasing_Details), @"mvc.1.0.view", @"/Views/Purchasing/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Purchasing/Details.cshtml", typeof(AspNetCore.Views_Purchasing_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9909cddf0d4b42955e7f6c80d23ac8deeec1158", @"/Views/Purchasing/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Purchasing_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mobile_Store_MS.ViewModel.PurchasingViewModel.PurchasingViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Image/Logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid w-50 h-50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-holder-rendered", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CompanyModel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Invoice.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/JSpdf/jspdf.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/html2canvas.min (1).js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(74, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(119, 679, true);
            WriteLiteral(@"<div id=""invoice"">
    <div class=""toolbar hidden-print"" id=""hidediv"">
        <div class=""text-right"">
            <button id=""printInvoice"" class=""btn btn-info""><i class=""fa fa-print""></i> Print</button>
            <input type=""hidden"" name=""ExportData"" />
            <button class=""btn btn-info"" id=""btnSubmit""><i class=""far fa-file-pdf""></i> Export as PDF</button>


        </div>
        <hr>
    </div>
    <div class=""invoice"">
        <div>
            <header>
                <div class=""row d-flex justify-content-around"">
                    <div class=""col-6"">
                        <a href=""/Home"" target=""_blank"">
                            ");
            EndContext();
            BeginContext(798, 86, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a9909cddf0d4b42955e7f6c80d23ac8deeec11588567", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(884, 261, true);
            WriteLiteral(@"
                        </a>
                    </div>
                    <div class=""col-6 text-right"">
                        <h2 class=""mt-0 mb-0 text-right"">
                            <a target=""_blank"" href=""#"">
                                ");
            EndContext();
            BeginContext(1146, 13, false);
#line 29 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                           Write(Model.takenBy);

#line default
#line hidden
            EndContext();
            BeginContext(1159, 96, true);
            WriteLiteral("\r\n                            </a>\r\n                        </h2>\r\n                        <div>");
            EndContext();
            BeginContext(1256, 17, false);
#line 32 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                        Write(Model.StoreAdress);

#line default
#line hidden
            EndContext();
            BeginContext(1273, 37, true);
            WriteLiteral("</div>\r\n                        <div>");
            EndContext();
            BeginContext(1311, 16, false);
#line 33 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                        Write(Model.StorePhone);

#line default
#line hidden
            EndContext();
            BeginContext(1327, 37, true);
            WriteLiteral("</div>\r\n                        <div>");
            EndContext();
            BeginContext(1365, 15, false);
#line 34 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                        Write(Model.StoreName);

#line default
#line hidden
            EndContext();
            BeginContext(1380, 350, true);
            WriteLiteral(@"</div>
                    </div>
                </div>
            </header>
            <main>
                <div class=""row d-flex justify-content-around mb-4"">
                    <div class=""col text-left"">
                        <div class=""text-gray-light"">INVOICE TO:</div>
                        <h2 class=""text-left mb-0 mt-0"">");
            EndContext();
            BeginContext(1731, 16, false);
#line 42 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                                   Write(Model.VendorName);

#line default
#line hidden
            EndContext();
            BeginContext(1747, 52, true);
            WriteLiteral("</h2>\r\n                        <div class=\"address\">");
            EndContext();
            BeginContext(1800, 17, false);
#line 43 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                        Write(Model.VendorPhone);

#line default
#line hidden
            EndContext();
            BeginContext(1817, 158, true);
            WriteLiteral("</div>\r\n                    </div>\r\n                    <div class=\"col text-right\">\r\n                        <h1 class=\"mt-0\" style=\"color: #3989c6\">INVOICE ");
            EndContext();
            BeginContext(1976, 17, false);
#line 46 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                                                   Write(Model.purchase_id);

#line default
#line hidden
            EndContext();
            BeginContext(1993, 66, true);
            WriteLiteral("</h1>\r\n                        <div class=\"date\">Date of Invoice: ");
            EndContext();
            BeginContext(2060, 33, false);
#line 47 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                                      Write(Model.Date.ToString("yyyy-MM-dd"));

#line default
#line hidden
            EndContext();
            BeginContext(2093, 906, true);
            WriteLiteral(@"</div>
                    </div>
                </div>
                <table border=""0"" cellspacing=""0"" cellpadding=""0"" class=""w-100 table-sm table-responsive-sm"">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th class=""text-left font-weight-bold"">DESCRIPTION</th>
                            <th class=""text-left font-weight-bold"">Each Model Price</th>
                            <th class=""text-right font-weight-bold"">Quantity</th>
                            <th class=""text-right font-weight-bold"">TOTAL</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class=""no"">01</td>
                            <td class=""text-left"">
                                <h3>
                                    ");
            EndContext();
            BeginContext(2999, 216, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9909cddf0d4b42955e7f6c80d23ac8deeec115814935", async() => {
                BeginContext(3099, 42, true);
                WriteLiteral("\r\n                                        ");
                EndContext();
                BeginContext(3142, 14, false);
#line 66 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                   Write(Model.Com_name);

#line default
#line hidden
                EndContext();
                BeginContext(3156, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(3158, 15, false);
#line 66 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                                   Write(Model.modelName);

#line default
#line hidden
                EndContext();
                BeginContext(3173, 38, true);
                WriteLiteral("\r\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                                                                            WriteLiteral(Model.modelId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3215, 78, true);
            WriteLiteral("\r\n                                </h3>\r\n\r\n                            </td>\r\n");
            EndContext();
#line 71 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                              
                                var eachPrize = Model.Amount / Model.Quantity;
                            

#line default
#line hidden
            BeginContext(3436, 46, true);
            WriteLiteral("                            <td class=\"total\">");
            EndContext();
            BeginContext(3483, 9, false);
#line 74 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                         Write(eachPrize);

#line default
#line hidden
            EndContext();
            BeginContext(3492, 52, true);
            WriteLiteral("</td>\r\n                            <td class=\"unit\">");
            EndContext();
            BeginContext(3545, 14, false);
#line 75 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                        Write(Model.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(3559, 53, true);
            WriteLiteral("</td>\r\n                            <td class=\"total\">");
            EndContext();
            BeginContext(3613, 12, false);
#line 76 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                                         Write(Model.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(3625, 271, true);
            WriteLiteral(@"</td>
                        </tr>

                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan=""2""></td>
                            <td colspan=""2"">SUBTOTAL</td>
                            <td>");
            EndContext();
            BeginContext(3897, 12, false);
#line 84 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                           Write(Model.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(3909, 433, true);
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td colspan=""2""></td>
                            <td colspan=""2"">Shipping Price</td>
                            <td>Free</td>
                        </tr>
                        <tr>
                            <td colspan=""2""></td>
                            <td colspan=""2"">GRAND TOTAL</td>
                            <td>");
            EndContext();
            BeginContext(4343, 12, false);
#line 94 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
                           Write(Model.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(4355, 480, true);
            WriteLiteral(@"</td>
                        </tr>
                    </tfoot>
                </table>
                <div class=""thanks"">Thank you!</div>

            </main>
            <footer>
                Invoice was created on a computer and is valid without the signature and seal.
            </footer>
        </div>
        <!--DO NOT DELETE THIS div. IT is responsible for showing footer always at the bottom-->
        <div></div>
    </div>
</div>

<div>
    ");
            EndContext();
            BeginContext(4836, 63, false);
#line 111 "D:\Files and Softwares\repos\Mobile Store MS\Mobile Store MS\Views\Purchasing\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.purchase_id }));

#line default
#line hidden
            EndContext();
            BeginContext(4899, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(4907, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9909cddf0d4b42955e7f6c80d23ac8deeec115822537", async() => {
                BeginContext(4929, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4945, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4974, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(4982, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a9909cddf0d4b42955e7f6c80d23ac8deeec115824115", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5032, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5038, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9909cddf0d4b42955e7f6c80d23ac8deeec115825450", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5086, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(5092, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a9909cddf0d4b42955e7f6c80d23ac8deeec115826706", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5143, 912, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#printInvoice').click(function () {
                Popup($('.invoice')[0].outerHTML);
                function Popup(data) {
                    window.print();
                    return true;
                }
            });
                 
            $(""#btnSubmit"").click(function () {

                var Pagewidth = $('.invoice').width();
                var Pageheight = $('.invoice').height();
                html2canvas(document.querySelector('.invoice')).then(function (canvas) {
                    var img = canvas.toDataURL('image/png');
                    var doc = new jsPDF('p', 'px', [Pagewidth, Pageheight]);
              
                    doc.addImage(img, 'JPEG', 5, 5);
                    doc.save('invoice.pdf');
                });

            });

        });

    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mobile_Store_MS.ViewModel.PurchasingViewModel.PurchasingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
