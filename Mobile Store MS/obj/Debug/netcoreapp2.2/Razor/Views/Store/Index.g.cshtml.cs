#pragma checksum "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f96e9daf192b536183284b9b636e08bfdb1c17ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_Index), @"mvc.1.0.view", @"/Views/Store/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Store/Index.cshtml", typeof(AspNetCore.Views_Store_Index))]
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
#line 2 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f96e9daf192b536183284b9b636e08bfdb1c17ac", @"/Views/Store/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Store_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Mobile_Store_MS.ViewModel.Store.StoreViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CustomScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Filter.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(93, 4, true);
            WriteLiteral("    ");
            EndContext();
#line 3 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
      
        ViewData["Title"] = "Index";

    

#line default
#line hidden
            BeginContext(148, 32, true);
            WriteLiteral("\r\n    <h1>Store Details</h1>\r\n\r\n");
            EndContext();
#line 10 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
     if (Model.Any())
    {

#line default
#line hidden
            BeginContext(210, 25, true);
            WriteLiteral("        <p>\r\n            ");
            EndContext();
            BeginContext(235, 130, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f96e9daf192b536183284b9b636e08bfdb1c17ac7842", async() => {
                BeginContext(345, 16, true);
                WriteLiteral("Create new Store");
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
            BeginContext(365, 632, true);
            WriteLiteral(@"
        </p>
        <div class=""row"">
            <div class=""panel panel-primary filterable"">
                <div class=""panel-heading rounded"">
                    <h3 class=""panel-title font-weight-bold"">Stores</h3>
                    <div class=""pull-right"">
                        <button class=""btn btn-default btn-xs btn-filter""><i class=""fas fa-filter""></i> Filter</button>
                    </div>
                </div>
                <table class=""table"">
                    <thead>
                        <tr class=""filters"">
                            <th><input type=""text"" class=""form-control""");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 997, "\"", 1056, 1);
#line 27 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
WriteAttributeValue("", 1011, Html.DisplayNameFor(model => model.store_id), 1011, 45, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1057, 88, true);
            WriteLiteral(" disabled></th>\r\n                            <th><input type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 1145, "\"", 1205, 1);
#line 28 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
WriteAttributeValue("", 1159, Html.DisplayNameFor(model => model.StoreName), 1159, 46, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1206, 88, true);
            WriteLiteral(" disabled></th>\r\n                            <th><input type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 1294, "\"", 1353, 1);
#line 29 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
WriteAttributeValue("", 1308, Html.DisplayNameFor(model => model.CityName), 1308, 45, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1354, 88, true);
            WriteLiteral(" disabled></th>\r\n                            <th><input type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 1442, "\"", 1503, 1);
#line 30 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
WriteAttributeValue(" ", 1456, Html.DisplayNameFor(model => model.SupportNo), 1457, 46, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1504, 146, true);
            WriteLiteral(" disabled></th>\r\n                            <th></th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
            EndContext();
#line 35 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(1731, 108, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1840, 43, false);
#line 39 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.store_id));

#line default
#line hidden
            EndContext();
            BeginContext(1883, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1999, 44, false);
#line 42 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.StoreName));

#line default
#line hidden
            EndContext();
            BeginContext(2043, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2159, 43, false);
#line 45 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CityName));

#line default
#line hidden
            EndContext();
            BeginContext(2202, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2318, 44, false);
#line 48 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.SupportNo));

#line default
#line hidden
            EndContext();
            BeginContext(2362, 81, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n\r\n");
            EndContext();
#line 52 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                     if (User.IsInRole("Super Admin"))
                                    {

#line default
#line hidden
            BeginContext(2554, 40, true);
            WriteLiteral("                                        ");
            EndContext();
            BeginContext(2594, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f96e9daf192b536183284b9b636e08bfdb1c17ac15273", async() => {
                BeginContext(2645, 40, true);
                WriteLiteral("<i class=\"far fa-edit\" title=\"Edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 54 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                                               WriteLiteral(item.store_id);

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
            BeginContext(2689, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
            BeginContext(2746, 69, false);
#line 55 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                   Write(await Html.PartialAsync("~/Views/Shared/Modal.cshtml", item.store_id));

#line default
#line hidden
            EndContext();
            BeginContext(2815, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
            BeginContext(2872, 98, false);
#line 56 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                   Write(Html.ActionLink("Add Employee", "AddEmployee", "Administration", new { store_id = item.store_id }));

#line default
#line hidden
            EndContext();
            BeginContext(2970, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
#line 57 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                    }
                                    else if (User.IsInRole("Admin"))
                                    {
                                        

#line default
#line hidden
            BeginContext(3175, 88, false);
#line 60 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                   Write(Html.ActionLink("Add Employee", "Register", "Account", new { store_id = item.store_id }));

#line default
#line hidden
            EndContext();
#line 60 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                                                                                                                 
                                    }

#line default
#line hidden
            BeginContext(3304, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(3340, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f96e9daf192b536183284b9b636e08bfdb1c17ac19670", async() => {
                BeginContext(3394, 50, true);
                WriteLiteral("<i class=\"fas fa-info-circle\" title=\"Details\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 62 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                                                              WriteLiteral(item.store_id);

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
            BeginContext(3448, 52, true);
            WriteLiteral("<span>|</span>\r\n                                    ");
            EndContext();
            BeginContext(3501, 86, false);
#line 63 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.ActionLink("Stock Details", "StoreStock", "Quantity", new { id = item.store_id }));

#line default
#line hidden
            EndContext();
            BeginContext(3587, 40, true);
            WriteLiteral(" |\r\n                                    ");
            EndContext();
            BeginContext(3628, 93, false);
#line 64 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.ActionLink("Store Employees", "GetEmployees", "Store", new { store_id = item.store_id }));

#line default
#line hidden
            EndContext();
            BeginContext(3721, 40, true);
            WriteLiteral(" |\r\n                                    ");
            EndContext();
            BeginContext(3762, 102, false);
#line 65 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.ActionLink("Store Purchasing", "StorePurchasing", "Purchasing", new { store_id = item.store_id }));

#line default
#line hidden
            EndContext();
            BeginContext(3864, 40, true);
            WriteLiteral(" |\r\n                                    ");
            EndContext();
            BeginContext(3905, 89, false);
#line 66 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                               Write(Html.ActionLink("Store Orders", "StoreOrders", "Order", new { store_id = item.store_id }));

#line default
#line hidden
            EndContext();
            BeginContext(3994, 88, true);
            WriteLiteral(" |\r\n\r\n\r\n\r\n\r\n                                </td>\r\n\r\n                            </tr>\r\n");
            EndContext();
#line 74 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"

                        }

#line default
#line hidden
            BeginContext(4111, 156, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <div id=\"map\" style=\"width:100%; height:500px;\"></div>\r\n");
            EndContext();
            BeginContext(4271, 29, true);
            WriteLiteral("        <script>\r\n\r\n       \r\n");
            EndContext();
            BeginContext(4443, 21, true);
            WriteLiteral("\r\n        </script>\r\n");
            EndContext();
            BeginContext(4466, 64, true);
            WriteLiteral("        <div>\r\n            <script>\r\n                var data = ");
            EndContext();
            BeginContext(4531, 31, false);
#line 94 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
                      Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
            EndContext();
            BeginContext(4562, 947, true);
            WriteLiteral(@"
                    console.log(""Map Loaded"")
                var map = new L.Map(""map"", {
                    center: new L.LatLng(30.3753, 69.3451),
                    zoom: 6,
                    layers: new L.TileLayer(""https://tile.openstreetmap.org/{z}/{x}/{y}.png"")
                });
                var marker; var circle;
                data.forEach(x => {
                    marker = new L.Marker(new L.LatLng(x.lat, x.lng));
                    marker.bindPopup(`<b>${x.storeName}</b><br>${x.completeAddress}.<br>${x.supportNo}`);
                    map.addLayer(marker);

                    circle = L.circle([x.lat, x.lng], {
                        color: 'red',
                        fillColor: '#f03',
                        fillOpacity: 0.5,
                        radius: 500
                    }).addTo(map);
                })
              
            </script>

        
        </div>
");
            EndContext();
#line 119 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"


    }
    else
    {

#line default
#line hidden
            BeginContext(5537, 299, true);
            WriteLiteral(@"        <div class=""card"">
            <div class=""card-header"">
                No Store Added yet
            </div>
            <div class=""card-body"">
                <h5 class=""card-title"">
                    Use the button below to Add new Store
                </h5>
                ");
            EndContext();
            BeginContext(5836, 134, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f96e9daf192b536183284b9b636e08bfdb1c17ac26844", async() => {
                BeginContext(5950, 16, true);
                WriteLiteral("Create new Store");
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
            BeginContext(5970, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 136 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Store\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(6015, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(6038, 14, true);
                WriteLiteral("\r\n\r\n\r\n        ");
                EndContext();
                BeginContext(6052, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f96e9daf192b536183284b9b636e08bfdb1c17ac29073", async() => {
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
                BeginContext(6105, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(6115, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f96e9daf192b536183284b9b636e08bfdb1c17ac30413", async() => {
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
                BeginContext(6159, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(6169, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f96e9daf192b536183284b9b636e08bfdb1c17ac31674", async() => {
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
                BeginContext(6207, 189, true);
                WriteLiteral("\r\n        <script src=\"https://unpkg.com/leaflet@1.0.2/dist/leaflet.js\"></script>\r\n        <link rel=\"stylesheet\" href=\"https://unpkg.com/leaflet@1.0.2/dist/leaflet.css\" />\r\n\r\n       \r\n    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Mobile_Store_MS.ViewModel.Store.StoreViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
