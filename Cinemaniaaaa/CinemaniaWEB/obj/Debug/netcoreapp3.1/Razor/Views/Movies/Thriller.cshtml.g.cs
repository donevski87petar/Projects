#pragma checksum "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4beb4487be90ffe425cf2c385b61c6f0aa6778a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Thriller), @"mvc.1.0.view", @"/Views/Movies/Thriller.cshtml")]
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
#line 1 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\_ViewImports.cshtml"
using CinemaniaWEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\_ViewImports.cshtml"
using CinemaniaWEB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4beb4487be90ffe425cf2c385b61c6f0aa6778a", @"/Views/Movies/Thriller.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2066d9d89df902f421214e9948e23a899fdad04d", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Thriller : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CinemaniaAPI.Models.DTO.MovieDTO>>
    {
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
#line 3 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
  
    ViewData["Title"] = "Thriller Movies";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Thriller Movies</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.LengthMin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.ReleaseYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.Director));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayNameFor(model => model.Actors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 38 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
       Write(Html.HiddenFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n");
#nullable restore
#line 43 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
                  
                    var base64 = Convert.ToBase64String(item.Cover);
                    var finalStr = string.Format("data:image/jpg;base64,{0}", base64);
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4beb4487be90ffe425cf2c385b61c6f0aa6778a6696", async() => {
                WriteLiteral("\r\n                    <img");
                BeginWriteAttribute("src", " src=\"", 1372, "\"", 1387, 1);
#nullable restore
#line 48 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
WriteAttributeValue("", 1378, finalStr, 1378, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"75\" height=\"100\" alt=\"cover\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1314, "~/movies/moviedetails/", 1314, 22, true);
#nullable restore
#line 47 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
AddHtmlAttributeValue("", 1336, item.Id, 1336, 8, false);

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
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4beb4487be90ffe425cf2c385b61c6f0aa6778a8744", async() => {
                WriteLiteral("\r\n                    ");
#nullable restore
#line 53 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1513, "~/movies/moviedetails/", 1513, 22, true);
#nullable restore
#line 52 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
AddHtmlAttributeValue("", 1535, item.Id, 1535, 8, false);

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
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayFor(modelItem => item.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayFor(modelItem => item.LengthMin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 66 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayFor(modelItem => item.ReleaseYear));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 69 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayFor(modelItem => item.Director));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 72 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
           Write(Html.DisplayFor(modelItem => item.Actors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "C:\Users\Petar\source\repos\Cinemania\CinemaniaWEB\Views\Movies\Thriller.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CinemaniaAPI.Models.DTO.MovieDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
