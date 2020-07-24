#pragma checksum "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfc9b7405bea92b979b2d48f1aafbc5f460ae98b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_GetAllOrders), @"mvc.1.0.view", @"/Views/Order/GetAllOrders.cshtml")]
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
#line 2 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfc9b7405bea92b979b2d48f1aafbc5f460ae98b", @"/Views/Order/GetAllOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9768fc5a6e7f3ec0a1cf042d086a9edc345b6b28", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_GetAllOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Shop.ViewModels.OrderViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
  
    ViewData["Title"] = "All Orders";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center\"><i class=\"fa fa-lock\" aria-hidden=\"true\"></i> All Orders</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderPlacedTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 42 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.OrderPlacedTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 67 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.OrderTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral(" $\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 70 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<br />\r\n\r\n");
            WriteLiteral("<div class=\"row\" style=\"justify-content:center\">\r\n        ");
#nullable restore
#line 78 "C:\Users\Petar\source\repos\Shop\Shop\Views\Order\GetAllOrders.cshtml"
   Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("AllOrders", new { page = page }),
        new X.PagedList.Mvc.Core.Common.PagedListRenderOptions
            {
                DisplayItemSliceAndTotal = false,
                ContainerDivClasses = new[] { "navigation" },
                LiElementClasses = new[] { "page-item" },
                PageClasses = new[] { "page-link" },
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Shop.ViewModels.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
