#pragma checksum "C:\Programming\LES\LES\LES\Views\Carrinho\FinalizarCompra.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65b7db8dcac6574f7620fb84f297afa962fce1db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carrinho_FinalizarCompra), @"mvc.1.0.view", @"/Views/Carrinho/FinalizarCompra.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65b7db8dcac6574f7620fb84f297afa962fce1db", @"/Views/Carrinho/FinalizarCompra.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Carrinho_FinalizarCompra : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Carrinho.FinalizarCompraModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Carrinho/CardsAsRadio.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Carrinho/PartialViews/_ListaCardsEnderecoPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Carrinho/PartialViews/_ListaCardsCartaoPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Programming\LES\LES\LES\Views\Carrinho\FinalizarCompra.cshtml"
  
    ViewData["Title"] = "FinalizarCompra";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "65b7db8dcac6574f7620fb84f297afa962fce1db5057", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<link href=""https://fonts.googleapis.com/css?family=Roboto:300,400,500,700"" rel=""stylesheet"">
<link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">

<div class=""row justify-content-center""><h1 class=""col-12 text-center"">Finalizar Compra</h1></div>
<div class=""row"">
    <div class=""col-12 mb-3 border-bottom"">
    </div>
</div>
<div class=""row"">
    <div class=""col-12 text-center"">
        <h6 class=""font-weight-light"">Preço total:</h6><h5>R$ ");
#nullable restore
#line 18 "C:\Programming\LES\LES\LES\Views\Carrinho\FinalizarCompra.cshtml"
                                                         Write(Model.Pedido.PrecoTotal.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
    </div>
    <div class=""col-1""></div>
    <div class=""col-10 text-center my-1"">Cupom #433: R$ -30,00</div>
    <button class=""btn btn-danger botaoRemoverCupom col-1 my-1"">
        &times;
    </button>
    <div class=""col-1""></div>
    <div class=""col-10 text-center my-1"">Cupom #434: R$ -15,00</div>
    <button class=""btn btn-danger botaoRemoverCupom col-1 my-1"">
        &times;
    </button>
    <div class=""col-6 border-top mt-2 text-center"">
        <h4 class=""font-weight-light"">Preço com descontos:</h4><h3>R$ 205,00</h3>
    </div>
    <div class=""col-6 border-top mt-2 text-center"">
        <h3 class=""font-weight-light""> + Frete(R$30,00):</h3><h2>R$ 235,00</h2>
    </div>
    <button type=""submit"" class=""btn btn-info col-12 text-center"">
        <h4>
            Adicionar cupom
        </h4>
    </button>
</div>
<div class=""row justify-content-around mt-4"">
    <div class=""col-md-6 border-right"">
        <div class=""row"">
            <h4 class=""font-weight-light ml-3"">
");
            WriteLiteral("                Endereços\r\n            </h4>\r\n        </div>\r\n        <div class=\"row mx-2\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "65b7db8dcac6574f7620fb84f297afa962fce1db8168", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 50 "C:\Programming\LES\LES\LES\Views\Carrinho\FinalizarCompra.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Enderecos);

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
            WriteLiteral(@"
        </div>
    </div>
    <div class=""col-md-6 border-left justify-content-end"">
        <div class=""row"">
            <h4 class=""font-weight-light ml-3"">
                Cartões
            </h4>
        </div>
        <div class=""row mx-2"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "65b7db8dcac6574f7620fb84f297afa962fce1db10070", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 60 "C:\Programming\LES\LES\LES\Views\Carrinho\FinalizarCompra.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Cartoes);

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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"row mt-3 justify-content-around\">\r\n    <button class=\"btn btn-success col-12\">\r\n        Comprar\r\n    </button>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Carrinho.FinalizarCompraModel> Html { get; private set; }
    }
}
#pragma warning restore 1591