#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b7cd6e036db9720cbe55b2372a65d2ee7b64815"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PartialViews__TabelaClientesPartial), @"mvc.1.0.view", @"/Views/Admin/PartialViews/_TabelaClientesPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b7cd6e036db9720cbe55b2372a65d2ee7b64815", @"/Views/Admin/PartialViews/_TabelaClientesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PartialViews__TabelaClientesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Admin.PaginaClientesModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("filtroId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("1..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("filtroNome"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("José..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("filtroEmail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Jose@hotmail.com..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("filtroInativos"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-check-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<table class=""table"">
    <caption>Lista de clientes</caption>
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Id</th>
            <th scope=""col"">Nome</th>
            <th scope=""col"">E-mail</th>
            <th scope=""col"">Detalhes</th>
            <th scope=""col"">Inativar</th>
        </tr>
        <tr>
            <th scope=""col"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b7cd6e036db9720cbe55b2372a65d2ee7b648157190", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 16 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Filtros.Id);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b7cd6e036db9720cbe55b2372a65d2ee7b648158913", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 17 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Filtros.Nome);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n            <th scope=\"col\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b7cd6e036db9720cbe55b2372a65d2ee7b6481510638", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 18 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Filtros.Email);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</th>\r\n            <th scope=\"col\"><button class=\"btn btn-primary btnBuscar\">Buscar</button></th>\r\n            <th scope=\"col\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8b7cd6e036db9720cbe55b2372a65d2ee7b6481512483", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 21 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Filtros.IncluiInativo);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <label class=\"form-check-label\" for=\"filtroInativos\">Incluir inativos?</label>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 27 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
         foreach (var cliente in Model.Clientes.Clientes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 30 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                           Write(cliente.InfoUsuario.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 31 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
               Write(cliente.InfoUsuario.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 32 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
               Write(cliente.InfoUsuario.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><button type=\"button\" class=\"btn btn-outline-info btnVisualizar\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1690, "\"", 1725, 1);
#nullable restore
#line 33 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue("", 1698, cliente.InfoUsuario.Codigo, 1698, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Visualizar</button></td>\r\n");
#nullable restore
#line 34 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                 if (cliente.Inativo)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><button type=\"button\" class=\"btn btn-success btnInativar\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1935, "\"", 1970, 1);
#nullable restore
#line 36 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue("", 1943, cliente.InfoUsuario.Codigo, 1943, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Reativar</button></td>\r\n");
#nullable restore
#line 37 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td><button type=\"button\" class=\"btn btn-danger btnInativar\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 2179, "\"", 2214, 1);
#nullable restore
#line 40 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue("", 2187, cliente.InfoUsuario.Codigo, 2187, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Inativar</button></td>\r\n");
#nullable restore
#line 41 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 43 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td>\r\n                <nav aria-label=\"Paginação\">\r\n                    <ul class=\"pagination justify-content-center\">\r\n                        <li");
            BeginWriteAttribute("class", " class=\"", 2489, "\"", 2568, 2);
            WriteAttributeValue("", 2497, "page-item", 2497, 9, true);
            WriteAttributeValue(" ", 2506, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 50 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                              if (Model.Clientes.PagAtual == 1) {

#line default
#line hidden
#nullable disable
                WriteLiteral(" disabled ");
#nullable restore
#line 50 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                                         }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 2507, 61, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <button type=\"button\" class=\"page-link btnPage\" aria-label=\"Previous\"");
            BeginWriteAttribute("value", " value=\"", 2669, "\"", 2705, 1);
#nullable restore
#line 51 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue("", 2677, Model.Clientes.PagAtual-1, 2677, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 51 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                                                                        if (Model.Clientes.PagAtual == 1) { 

#line default
#line hidden
#nullable disable
            WriteLiteral(" disabled ");
#nullable restore
#line 51 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                                                                                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                                <span aria-hidden=\"true\">&laquo;</span>\r\n                                <span class=\"sr-only\">Anterior</span>\r\n                            </button>\r\n                        </li>\r\n");
#nullable restore
#line 56 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                         for (int i = 1; i <= Model.Clientes.PagMax; i++)
                        {
                            string active = "";
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                             if (i == Model.Clientes.PagAtual) { active = "active"; }
                            else { active = ""; }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li");
            BeginWriteAttribute("class", " class=\"", 3306, "\"", 3331, 2);
            WriteAttributeValue("", 3314, "page-item", 3314, 9, true);
#nullable restore
#line 61 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue(" ", 3323, active, 3324, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <button type=\"button\" class=\"page-link btnPage\"");
            BeginWriteAttribute("value", " value=\"", 3414, "\"", 3424, 1);
#nullable restore
#line 62 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue("", 3422, i, 3422, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 62 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </button>\r\n");
#nullable restore
#line 63 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                 if (i == Model.Clientes.PagAtual)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("<span class=\"sr-only\">(current)</span>");
#nullable restore
#line 64 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </li>\r\n");
#nullable restore
#line 66 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 3672, "\"", 3771, 2);
            WriteAttributeValue("", 3680, "page-item", 3680, 9, true);
            WriteAttributeValue(" ", 3689, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 67 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                              if (Model.Clientes.PagAtual == Model.Clientes.PagMax) {

#line default
#line hidden
#nullable disable
                WriteLiteral(" disabled ");
#nullable restore
#line 67 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                                                             }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 3690, 81, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <button type=\"button\" class=\"page-link btnPage\" aria-label=\"Next\"");
            BeginWriteAttribute("value", " value=\"", 3868, "\"", 3904, 1);
#nullable restore
#line 68 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
WriteAttributeValue("", 3876, Model.Clientes.PagAtual+1, 3876, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 68 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                                                                    if (Model.Clientes.PagAtual == Model.Clientes.PagMax) { 

#line default
#line hidden
#nullable disable
            WriteLiteral(" disabled ");
#nullable restore
#line 68 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaClientesPartial.cshtml"
                                                                                                                                                                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@">
                                <span aria-hidden=""true"">&raquo;</span>
                                <span class=""sr-only"">Próxima</span>
                            </button>
                        </li>
                    </ul>
                </nav>
            </td>
        </tr>
    </tfoot>
</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Admin.PaginaClientesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
