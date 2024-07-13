#pragma checksum "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5b682b76898c1d42286ac863adeeda753e0c2eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingCart__ShoppingCartPartialView), @"mvc.1.0.view", @"/Views/ShoppingCart/_ShoppingCartPartialView.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\_ViewImports.cshtml"
using project01;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\_ViewImports.cshtml"
using project01.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
using project01.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5b682b76898c1d42286ac863adeeda753e0c2eb", @"/Views/ShoppingCart/_ShoppingCartPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec8e87634d27950e815cfdc2f229ed0a058a1532", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingCart__ShoppingCartPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
  
    var cartJson = Context.Request.HttpContext.Session.GetString("cart");
    var cartItems = !string.IsNullOrEmpty(cartJson) ? JsonConvert.DeserializeObject<List<Item>>(cartJson) : new List<Item>();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
 if (cartItems.Count > 0)
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h1>Your Cart</h1>
    <table class=""table"">
        <thead>
            <tr>
                <th></th>
                <th>Product</th>
                <th>Product Price</th>
                <th>Quantity</th>
                <th>Total amount</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 28 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
             foreach (var item in cartItems)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d5b682b76898c1d42286ac863adeeda753e0c2eb7175", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 798, "~/Images/", 798, 9, true);
#nullable restore
#line 31 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
AddHtmlAttributeValue("", 807, item.Product.ProductPicture, 807, 28, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 31 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
AddHtmlAttributeValue("", 842, item.Product.Name, 842, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
                   Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
                   Write(item.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 34 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 35 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
                    Write(item.Product.Price * item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1160, "\"", 1243, 1);
#nullable restore
#line 37 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
WriteAttributeValue("", 1167, Url.Action("RemoveFromCart", "ShoppingCart", new { @id = item.Product.Id }), 1167, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-danger\">Remove</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 40 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n    </table>\r\n    <br />\r\n    <div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5b682b76898c1d42286ac863adeeda753e0c2eb11445", async() => {
                WriteLiteral("Continue Shopping");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 49 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a class=\"btn btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 1611, "\"", 1650, 1);
#nullable restore
#line 51 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
WriteAttributeValue("", 1618, Url.Action("Index", "Checkout"), 1618, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Procceed to checkout</a>\r\n");
#nullable restore
#line 52 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p><a class=\"btn btn-dark mt-2 text-center\"");
            BeginWriteAttribute("href", " href=\"", 1753, "\"", 1791, 1);
#nullable restore
#line 55 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
WriteAttributeValue("", 1760, Url.Action("Login", "Account"), 1760, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">log in</a>to complete your purchase</p>\r\n");
#nullable restore
#line 56 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
     

    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\" role=\"alert\">\r\n        Your cart is empty\r\n    </div>\r\n");
#nullable restore
#line 64 "C:\Users\HP\Desktop\.netCourse\ecommerce\project01\Views\ShoppingCart\_ShoppingCartPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
