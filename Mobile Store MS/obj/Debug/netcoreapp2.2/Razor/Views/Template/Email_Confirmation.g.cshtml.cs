#pragma checksum "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Template\Email_Confirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61761d8137ce620f3b3fd818a4a97520cde95bf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Template_Email_Confirmation), @"mvc.1.0.view", @"/Views/Template/Email_Confirmation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Template/Email_Confirmation.cshtml", typeof(AspNetCore.Views_Template_Email_Confirmation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61761d8137ce620f3b3fd818a4a97520cde95bf7", @"/Views/Template/Email_Confirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"890773786f46f7151a3bd0c2741ea0ced62203d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Template_Email_Confirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #e9ecef;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Template\Email_Confirmation.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(42, 29, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            EndContext();
            BeginContext(71, 2270, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61761d8137ce620f3b3fd818a4a97520cde95bf75105", async() => {
                BeginContext(77, 241, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Email Confirmation</title>\r\n    <style type=\"text/css\">\r\n  /**\r\n   * Google webfonts. Recommended to include the .woff version for cross-client compatibility.\r\n   */\r\n  ");
                EndContext();
                BeginContext(319, 21, true);
                WriteLiteral("@media screen {\r\n    ");
                EndContext();
                BeginContext(341, 312, true);
                WriteLiteral(@"@font-face {
      font-family: 'Source Sans Pro';
      font-style: normal;
      font-weight: 400;
      src: local('Source Sans Pro Regular'), local('SourceSansPro-Regular'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/ODelI1aHBYDBqgeIAH2zlBM0YzuT7MdOe03otPbuUS0.woff) format('woff');
    }

    ");
                EndContext();
                BeginContext(654, 1680, true);
                WriteLiteral(@"@font-face {
      font-family: 'Source Sans Pro';
      font-style: normal;
      font-weight: 700;
      src: local('Source Sans Pro Bold'), local('SourceSansPro-Bold'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/toadOcfmlt9b38dHJxOBGFkQc6VGVFSmCnC_l7QZG60.woff) format('woff');
    }
  }

  /**
   * Avoid browser level font resizing.
   * 1. Windows Mobile
   * 2. iOS / OSX
   */
  body,
  table,
  td,
  a {
    -ms-text-size-adjust: 100%; /* 1 */
    -webkit-text-size-adjust: 100%; /* 2 */
  }

  /**
   * Remove extra space added to tables and cells in Outlook.
   */
  table,
  td {
    mso-table-rspace: 0pt;
    mso-table-lspace: 0pt;
  }

  /**
   * Better fluid images in Internet Explorer.
   */
  img {
    -ms-interpolation-mode: bicubic;
  }

  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inhe");
                WriteLiteral(@"rit !important;
    color: inherit !important;
    text-decoration: none !important;
  }

  /**
   * Fix centering issues in Android 4.4.
   */
  div[style*=""margin: 16px 0;""] {
    margin: 0 !important;
  }

  body {
    width: 100% !important;
    height: 100% !important;
    padding: 0 !important;
    margin: 0 !important;
  }

  /**
   * Collapse table borders to avoid space between cells.
   */
  table {
    border-collapse: collapse !important;
  }

  a {
    color: #1a82e2;
  }

  img {
    height: auto;
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
    </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2341, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2343, 6395, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61761d8137ce620f3b3fd818a4a97520cde95bf78941", async() => {
                BeginContext(2384, 736, true);
                WriteLiteral(@"

    <!-- start preheader -->
    <div class=""preheader"" style=""display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;"">
                     Confirm Your Email 
     </div>
    <!-- end preheader -->
    <!-- start body -->
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width:100%;"">

        <!-- start logo -->
        <tr>
            <td align=""center"" bgcolor=""#e9ecef"">
              
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""max-width: 600px; width:100%;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 36px 24px;"">
                            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3120, "\"", 3169, 1);
#line 124 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Template\Email_Confirmation.cshtml"
WriteAttributeValue("", 3127, Url.Action("Index", "Home",null, "https"), 3127, 42, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3170, 1934, true);
                WriteLiteral(@" target=""_blank"" style=""display: inline-block;"">
                                <img src=""https://cmkt-image-prd.freetls.fastly.net/0.1.0/ps/2345761/580/386/m2/fpnw/wm0/template-for-preview-km-1-.jpg?1488346749&s=d503d055531f7442a86bcfe3ab864fde"" alt=""Logo"" border=""0"" width=""100"" style=""display: block; width: 100px; max-width: 100px; min-width: 100px; height:100px;"">
                            </a>
                        </td>
                    </tr>
                </table>
               
            </td>
        </tr>
        <!-- end logo -->
        <!-- start hero -->
        <tr>
            <td align=""center"" bgcolor=""#e9ecef"">
               
                <table border=""0"" cellpadding=""0"" cellspacing=""0""  style=""max-width: 600px; width:100%;"">
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 36px 24px 0; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; border-top: 3px solid #d4dadf;"">
                           ");
                WriteLiteral(@" <h1 style=""margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px;"">Confirm Your Email Address</h1>
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <!-- end hero -->
        <!-- start copy block -->
        <tr>
            <td align=""center"" bgcolor=""#e9ecef"">
               
                <table border=""0"" cellpadding=""0"" cellspacing=""0""  style=""max-width: 600px; width:100%;"">

                    <!-- start copy -->
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
                            <p style=""margin: 0;"">Tap the button below to confirm your email address. If you didn't create an account with ");
                EndContext();
                BeginContext(5104, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61761d8137ce620f3b3fd818a4a97520cde95bf712583", async() => {
                    BeginContext(5148, 11, true);
                    WriteLiteral("Mobile Shop");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
                BeginContext(5163, 815, true);
                WriteLiteral(@", you can safely delete this email.</p>
                        </td>
                    </tr>
                    <!-- end copy -->
                    <!-- start button -->
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"">
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""width:100%;"">
                                <tr>
                                    <td align=""center"" bgcolor=""#ffffff"" style=""padding: 12px;"">
                                        <table border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tr>
                                                <td align=""center"" bgcolor=""#1a82e2"" style=""border-radius: 6px;"">
                                                    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 5978, "\"", 5991, 1);
#line 171 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Template\Email_Confirmation.cshtml"
WriteAttributeValue("", 5985, Model, 5985, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(5992, 1023, true);
                WriteLiteral(@" target=""_blank"" style=""display: inline-block; padding: 16px 36px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;"">Confirm</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- end button -->
                    <!-- start copy -->
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
                            <p style=""margin: 0;"">If that doesn't work, copy and paste the following link in your browser:</p>
                            <p style=""margin: 0;""><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 7015, "\"", 7028, 1);
#line 185 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Template\Email_Confirmation.cshtml"
WriteAttributeValue("", 7022, Model, 7022, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(7029, 17, true);
                WriteLiteral(" target=\"_blank\">");
                EndContext();
                BeginContext(7047, 5, false);
#line 185 "C:\Users\smsam\source\repos\Mobile Store MS\Mobile Store MS\Views\Template\Email_Confirmation.cshtml"
                                                                              Write(Model);

#line default
#line hidden
                EndContext();
                BeginContext(7052, 1679, true);
                WriteLiteral(@"</a></p>
                        </td>
                    </tr>
                    <!-- end copy -->
                    <!-- start copy -->
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf"">
                            <p style=""margin: 0;"">Cheers,<br> From Mobile Store</p>
                        </td>
                    </tr>
                    <!-- end copy -->

                </table>
               
            </td>
        </tr>
        <!-- end copy block -->
        <!-- start footer -->
        <tr>
            <td align=""center"" bgcolor=""#e9ecef"" style=""padding: 24px;"">
              
                <table border=""0"" cellpadding=""0"" cellspacing=""0""  style=""max-width: 600px; width:100%;"">

                    <!-- start permission -->
                    <tr>
                        ");
                WriteLiteral(@"<td align=""center"" bgcolor=""#e9ecef"" style=""padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;"">
                            <p style=""margin: 0;"">You received this email because we received a request for Joining Our Mobile Market. If you didn't request for Signup you can safely delete this email.</p>
                        </td>
                    </tr>
                    <!-- end permission -->
                  
                </table>
               
            </td>
        </tr>
        <!-- end footer -->

    </table>
    <!-- end body -->

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8738, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
