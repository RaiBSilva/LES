#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1237c9fcbc62d6f3288d49994e537fec99a9bf92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Livros_Descricao), @"mvc.1.0.view", @"/Views/Livros/Descricao.cshtml")]
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
#line 1 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\_ViewImports.cshtml"
using LES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\_ViewImports.cshtml"
using LES.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\_ViewImports.cshtml"
using LES.Models.ViewModel.Conta;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1237c9fcbc62d6f3288d49994e537fec99a9bf92", @"/Views/Livros/Descricao.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Livros_Descricao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Shared.LivroBaseModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Shared/AddToCarrinho.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Carrinho/ComprarAgora.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
  
    ViewData["Title"] = "Descrição";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">

<div class=""container "">
    <div class=""row"">
        <div class=""col-4 text-center pr-3 border-right border-secondary"">
            <img");
            BeginWriteAttribute("src", " src=\"", 405, "\"", 470, 3);
#nullable restore
#line 13 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
WriteAttributeValue("", 411, Url.Action("Livro", "Imagem"), 411, 30, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 441, "?codBar=", 441, 8, true);
#nullable restore
#line 13 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
WriteAttributeValue("", 449, Model.CodigoBarras, 449, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""img-fluid"" />
        </div>
        <div class=""col-7 mt-lg-3"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-12 align-content-lg-start font-weight-light"">
                        <h3>");
#nullable restore
#line 19 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                       Write(Model.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-sm-8 align-content-lg-start border-bottom\">\r\n                        <h4 class=\"font-weight-light\">");
#nullable restore
#line 24 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                 Write(Model.Autor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-12 text-justify border-bottom mb-2\">\r\n                        ");
#nullable restore
#line 29 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                   Write(Model.Sinopse);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""row justify-content-center"">
                    <div class=""col-12 font-weight-light text-center border-bottom"">
                        <h4>Ficha Técnica</h4>
                    </div>
                </div>
                <div class=""row justify-content-center"">
                    <div class=""col-sm-4"">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Editora</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 43 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.Editora);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""col-sm-4"">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Ano de lançamento</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 51 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.DtLancamento.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""col-sm-4 "">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Páginas</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 59 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.Paginas);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                </div>
                <div class=""row justify-content-center"">
                    <div class=""col-lg-3"">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Edição</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 69 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.Edicao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Largura</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 77 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.Largura);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Comprimento</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 85 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.Comprimento);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-bold text-center"">Altura</span>
                        </div>
                        <div class=""row"">
                            <span class=""col-sm-12 font-weight-light text-center"">");
#nullable restore
#line 93 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                             Write(Model.Altura);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                    </div>
                </div>
                <div class=""row justify-content-center"">
                    <div class=""col-sm-8 align-content-lg-end text-center my-4"">
                        <h2 class=""font-weight-bold"">R$ ");
#nullable restore
#line 99 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                   Write(Model.Preco.ToString("0.00").Replace('.', ','));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    </div>
                </div>
                <div class=""row justify-content-center"">
                    <div class=""col-8 font-weight-bold text-center"">
                        <span class=""text-center"">
                            Categorias
                        </span>
                    </div>
                </div>
                <div class=""row justify-content-center"">
");
#nullable restore
#line 110 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                     foreach (var item in Model.Categorias)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"border rounded bg-light text-dark p-1 mb-2 mx-3\"><small>");
#nullable restore
#line 112 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                                                                                        Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></span>\r\n");
#nullable restore
#line 113 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <div class=""row justify-content-end"">
                    <div class=""col-8""></div>
                    <span class=""col-1""> x </span>
                    <div class=""col-3 justify-content-end"">
                        <input class=""form-control mr-1"" type=""number"" min=""1"" value=""1"" id=""QuantiaItens"" />
                    </div>
                </div>
                <div class=""row justify-content-center"">
                    <button type=""button"" class=""btn btn-success col-sm-7 mr-4 text-center comprarAgora""");
            BeginWriteAttribute("value", " value=\"", 6096, "\"", 6123, 1);
#nullable restore
#line 123 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
WriteAttributeValue("", 6104, Model.CodigoBarras, 6104, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">COMPRAR AGORA</button>\r\n                    <button type=\"button\" class=\"btn btn-outline-success col-sm-4 text-center addtoCarrinho\"");
            BeginWriteAttribute("value", " value=\"", 6257, "\"", 6284, 1);
#nullable restore
#line 124 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
WriteAttributeValue("", 6265, Model.CodigoBarras, 6265, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><small><i class=\"fa fa-shopping-cart\"></i></small></button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        var urls = urls || {};\r\n        urls.AddCarrinho = \'");
#nullable restore
#line 134 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                       Write(Url.Action("_AddToCarrinho", "CarrinhoCompra"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.FinalizarCompra = \'");
#nullable restore
#line 135 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Livros\Descricao.cshtml"
                           Write(Url.Action("FinalizarCompra","CarrinhoCompra"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1237c9fcbc62d6f3288d49994e537fec99a9bf9216029", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1237c9fcbc62d6f3288d49994e537fec99a9bf9217129", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Shared.LivroBaseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
