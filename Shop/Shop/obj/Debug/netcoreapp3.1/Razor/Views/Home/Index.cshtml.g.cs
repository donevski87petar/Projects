#pragma checksum "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7afa05cfa34cab6c945c60c9a8f1bb4d894cde64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Petar\source\repos\Shop\Shop\Views\_ViewImports.cshtml"
using Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Petar\source\repos\Shop\Shop\Views\_ViewImports.cshtml"
using Shop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7afa05cfa34cab6c945c60c9a8f1bb4d894cde64", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9768fc5a6e7f3ec0a1cf042d086a9edc345b6b28", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Shop.ViewModels.HomeViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/no_image.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <div class=\"container text-center\">\r\n\r\n        <div class=\"row text-dark\">\r\n            <div class=\"col-sm-12\">\r\n                <div class=\"float-right\">\r\n");
#nullable restore
#line 15 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                      
                        if (TempData["WelcomeMessage"] != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5>");
#nullable restore
#line 18 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                           Write(TempData["WelcomeMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 19 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h5>Welcome guest , please login or register. </h5>\r\n");
#nullable restore
#line 23 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
        </div>

        <br />



        <div class=""row"">
            <div class=""col-sm-3 card"" style=""height:512px; background-color:whitesmoke;"">
                <div class=""col-sm-12"">

                    <br />

                    <h4 class=""text-center""><b>Filters</b></h4>

                    <br /><br />

");
#nullable restore
#line 43 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                     using (Html.BeginForm("Index", "Home", FormMethod.Get))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div>\r\n                            <h5>Select Gender</h5>\r\n\r\n                            ");
#nullable restore
#line 48 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                       Write(Html.DropDownList("category",
                            new SelectList(Enum.GetValues(typeof(Shop.DomainModels.Enums.Category))), "All",
                            new { @class = "inpField" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                            <br /><br />\r\n\r\n\r\n                            <h5>Select Product Type</h5>\r\n\r\n                            ");
#nullable restore
#line 58 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                       Write(Html.DropDownList("productType",
                            new SelectList(Enum.GetValues(typeof(Shop.DomainModels.Enums.ProductType))), "All",
                            new { @class = "inpField" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                            <br /><br /><br /><br />

                            <input type=""submit"" id=""btnSearch"" name=""Search"" value=""Apply Filters"" class=""btn btn-primary"" />


                            <br /><br /><br /><br /><br />

                            <small class=""text-muted"">&copy; Petar Donevski - 2020 - </small>

                        </div>
");
#nullable restore
#line 72 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"col-sm-9\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 81 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                     if (Model != null)
                    {
                        foreach (var product in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-sm-4\">\r\n                                <div class=\"card cardProduct\">\r\n");
#nullable restore
#line 87 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                     if (product.Images.Count > 0)
                                    {

                                        var base64 = Convert.ToBase64String(product.Images[0].Photo);
                                        var finalStr = string.Format("data:image/jpg;base64,{0}", base64);


#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7afa05cfa34cab6c945c60c9a8f1bb4d894cde648758", async() => {
                WriteLiteral("\r\n                                            <img");
                BeginWriteAttribute("src", " src=\"", 3100, "\"", 3115, 1);
#nullable restore
#line 94 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
WriteAttributeValue("", 3106, finalStr, 3106, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"responsiveImg\" />\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3008, "~/Home/ProductDetails/", 3008, 22, true);
#nullable restore
#line 93 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 3030, product.ProductId, 3030, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 96 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7afa05cfa34cab6c945c60c9a8f1bb4d894cde6411088", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 100 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"card-body\">\r\n                                        <h5 class=\"card-title\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7afa05cfa34cab6c945c60c9a8f1bb4d894cde6412511", async() => {
#nullable restore
#line 103 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                                                                          Write(product.ModelName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3604, "~/Home/ProductDetails/", 3604, 22, true);
#nullable restore
#line 103 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 3626, product.ProductId, 3626, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </h5>\r\n                                        <hr />\r\n                                        <b>");
#nullable restore
#line 106 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                      Write(product.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                                        <br />\r\n                                        <b>");
#nullable restore
#line 108 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                      Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" $</b>\r\n                                        <p class=\"card-text\">\r\n                                        </p>\r\n                                        <p class=\"card-text\"><small class=\"text-muted\">");
#nullable restore
#line 111 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                                                                  Write(product.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 111 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                                                                                                    Write(product.ProductType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 115 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n            </div>\r\n        </div>\r\n\r\n        <br />\r\n\r\n\r\n");
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-sm-5\"></div>\r\n            <div class=\"col-sm-2\">\r\n                ");
#nullable restore
#line 129 "C:\Users\Petar\source\repos\Shop\Shop\Views\Home\Index.cshtml"
           Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Index", new
           {
               page = page,
               productType = @ViewBag.productType,
               category = @ViewBag.category,
               searchTerm = @ViewBag.searchTerm
           }),
        new X.PagedList.Mvc.Core.Common.PagedListRenderOptions
        {
            LiElementClasses = new string[] { "page-item" },
            PageClasses = new string[] { "page-link" }
        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n            <div class=\"col-sm-5\"></div>\r\n        </div>\r\n");
            WriteLiteral("    </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Shop.ViewModels.HomeViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591