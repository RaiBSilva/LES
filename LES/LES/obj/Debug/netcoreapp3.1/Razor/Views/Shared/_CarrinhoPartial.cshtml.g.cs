#pragma checksum "C:\Programming\LES\LES\LES\Views\Shared\_CarrinhoPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6111ebbcdf25edd4b00476a440a892102a561c04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CarrinhoPartial), @"mvc.1.0.view", @"/Views/Shared/_CarrinhoPartial.cshtml")]
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
#line 1 "C:\Programming\LES\LES\LES\Views\_ViewImports.cshtml"
using LES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programming\LES\LES\LES\Views\_ViewImports.cshtml"
using LES.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Programming\LES\LES\LES\Views\_ViewImports.cshtml"
using LES.Models.ViewModel.Conta;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6111ebbcdf25edd4b00476a440a892102a561c04", @"/Views/Shared/_CarrinhoPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CarrinhoPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Carrinho.CarrinhoModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ItemCarrinhoPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <div class=\"container dropdown-item\">\r\n        <div>\r\n            <h3 class=\"font-weight-light\">Carrinho de compras</h3>\r\n        </div>\r\n");
#nullable restore
#line 8 "C:\Programming\LES\LES\LES\Views\Shared\_CarrinhoPartial.cshtml"
             foreach (var item in Model.Livros) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                <table class=\"table table-borderless\">\r\n                    <tbody>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6111ebbcdf25edd4b00476a440a892102a561c044046", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 11 "C:\Programming\LES\LES\LES\Views\Shared\_CarrinhoPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => item);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </tbody>\r\n                </table>    \r\n");
#nullable restore
#line 14 "C:\Programming\LES\LES\LES\Views\Shared\_CarrinhoPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"dropdown-divider\"></div>\r\n        <div class=\"container\">\r\n            <div class=\"row justify-content-end\">\r\n                <h6 class=\"text-muted col-4\">Preço:</h6><h5 class=\"text-left mr-3\">R$ ");
#nullable restore
#line 19 "C:\Programming\LES\LES\LES\Views\Shared\_CarrinhoPartial.cshtml"
                                                                                 Write(Model.PrecoTotal.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"row justify-content-center\">\r\n                <button type=\"button\" class=\"btn btn-outline-success col-11\"");
            BeginWriteAttribute("onclick", " onclick=\"", 908, "\"", 972, 3);
            WriteAttributeValue("", 918, "window.location.href=\'", 918, 22, true);
#nullable restore
#line 22 "C:\Programming\LES\LES\LES\Views\Shared\_CarrinhoPartial.cshtml"
WriteAttributeValue("", 940, Url.Action("Comprar","Livros"), 940, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 971, "\'", 971, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size:0.75rem\">Confirmar compra</button>\r\n            </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Carrinho.CarrinhoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
