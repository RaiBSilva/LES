#pragma checksum "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcce5bee242f4b1963ad7e01cdab3e1fb04fb005"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ConfigLoja), @"mvc.1.0.view", @"/Views/Admin/ConfigLoja.cshtml")]
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
#line 1 "D:\DEVELOPMENT\LES\LES\LES\Views\_ViewImports.cshtml"
using LES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\DEVELOPMENT\LES\LES\LES\Views\_ViewImports.cshtml"
using LES.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DEVELOPMENT\LES\LES\LES\Views\_ViewImports.cshtml"
using LES.Models.ViewModel.Conta;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcce5bee242f4b1963ad7e01cdab3e1fb04fb005", @"/Views/Admin/ConfigLoja.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ConfigLoja : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Admin.ConfigLojaPaginaModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Admin/PartialViews/_TabelaLivrosConfigPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Admin/PartialViews/_TabelaCategoriasConfigPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../Admin/PartialViews/_TabelaGrupoPrecosConfigPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Admin/CarregadorPartialViewConfigLoja.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Conta/Tabs.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
  
    ViewData["Title"] = "Livros";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row justify-content-center""><h1 class=""col-12 text-center"">Configurar loja</h1></div>
<div class=""row"">
    <div class=""col-12 mb-3 border-bottom"">
    </div>
</div>
<div class=""row"">
    <div id=""sidebar"" class=""col-md-3 sticky-top"" style=""height:6rem; top:10%"">
        <div>
            <button class=""btn btn-success tablink"" onclick=""changeTab(event, 'Livros')"" style=""width:100%"">Livros</button>
        </div>
        <div>
            <button class=""btn btn-light tablink"" onclick=""changeTab(event, 'Categorias')"" style=""width:100%"">Categorias</button>
        </div>
        <div>
            <button class=""btn btn-light tablink"" onclick=""changeTab(event, 'Preco')"" style=""width:100%"">Grupos de Preço</button>
        </div>
    </div>
    <div class=""col-sm-9"">
        <div id=""Livros"" class=""tab"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bcce5bee242f4b1963ad7e01cdab3e1fb04fb0056299", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 26 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Livros);

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
            WriteLiteral("\r\n        </div>\r\n\r\n        <div id=\"Categorias\" class=\"tab\" style=\"display:none\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bcce5bee242f4b1963ad7e01cdab3e1fb04fb0058020", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 30 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Categorias);

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
            WriteLiteral("\r\n        </div>\r\n\r\n        <div id=\"Preco\" class=\"tab\" style=\"display:none\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bcce5bee242f4b1963ad7e01cdab3e1fb04fb0059740", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 34 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.GrupoPrecos);

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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"modal fade\" id=\"myModal\">\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script type=\"text/javascript\">\r\n        var urls = urls || {};\r\n\r\n        urls.AdicionarLivro = \'");
#nullable restore
#line 48 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                          Write(Url.Action("_AdicionarLivroPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.EntradaEstoqueLivro = \'");
#nullable restore
#line 49 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                               Write(Url.Action("_EntradaEstoqueLivroPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.VisualizarLivro = \'");
#nullable restore
#line 50 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                           Write(Url.Action("_VisualizarLivroPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.EditarLivro = \'");
#nullable restore
#line 51 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                       Write(Url.Action("_EditarLivroPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.InativarLivro = \'");
#nullable restore
#line 52 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                         Write(Url.Action("_InativarReativarLivroPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n\r\n        urls.AdicionarCategoria = \'");
#nullable restore
#line 54 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                              Write(Url.Action("_AdicionarCategoriaPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.EditarCategoria = \'");
#nullable restore
#line 55 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                           Write(Url.Action("_EditarCategoriaPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.InativarCategoria = \'");
#nullable restore
#line 56 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                             Write(Url.Action("_InativarReativarCategoriaPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n\r\n        urls.AdicionarGrupoPreco = \'");
#nullable restore
#line 58 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                               Write(Url.Action("_AdicionarGrupoPrecoPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.EditarGrupoPreco = \'");
#nullable restore
#line 59 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                            Write(Url.Action("_EditarGrupoPrecoPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        urls.InativarGrupoPreco = \'");
#nullable restore
#line 60 "D:\DEVELOPMENT\LES\LES\LES\Views\Admin\ConfigLoja.cshtml"
                              Write(Url.Action("_InativarReativarGrupoPrecoPartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcce5bee242f4b1963ad7e01cdab3e1fb04fb00514989", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcce5bee242f4b1963ad7e01cdab3e1fb04fb00516089", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Admin.ConfigLojaPaginaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
