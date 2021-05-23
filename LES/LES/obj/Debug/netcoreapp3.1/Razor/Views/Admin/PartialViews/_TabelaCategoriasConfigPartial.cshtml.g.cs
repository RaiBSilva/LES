#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4846dac30ce8c7dbc877f35d82cd3225c96e6675"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PartialViews__TabelaCategoriasConfigPartial), @"mvc.1.0.view", @"/Views/Admin/PartialViews/_TabelaCategoriasConfigPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4846dac30ce8c7dbc877f35d82cd3225c96e6675", @"/Views/Admin/PartialViews/_TabelaCategoriasConfigPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PartialViews__TabelaCategoriasConfigPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<LES.Models.ViewModel.Admin.CategoriaLivroModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row mb-2"">
    <div class=""col-sm-12"">
        <button type=""button"" class=""btn-success btn-lg btn-block btnAddCategoria"" data-toggle=""modal"" data-target=""#myModal"">
            Cadastrar nova categoria
        </button>
    </div>
</div>

");
#nullable restore
#line 11 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
 if (Model.Count > 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <table class=""table table-striped"">
        <thead class=""thead-dark"">
            <tr>
                <th>Id</th>
                <th>Nome</th>
                <th>Editar</th>
                <th>Inativar</th>
            </tr>
            <tr>
                <th>
                    <input id=""filtroCategoriasId"" class=""form-control"" placeholder=""1..."" />
                </th>
                <th>
                    <input id=""filtroTitulo"" class=""form-control"" placeholder=""SciFi..."" />
                </th>
                <th>
                    <input id=""filtroCategoriasInativado"" class=""form-check-input"" type=""checkbox"" />
                    <label for=""filtroCategoriasInativado"" class=""form-check-label"">Incluir inativadas?</label>
                </th>
                <th>
                    <button class=""btn btn-primary btnBuscarCategoria"">Buscar</button>
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 38 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
             foreach(var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">\r\n                    ");
#nullable restore
#line 42 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
               Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <button type=\"button\" class=\"btn btn-outline-info btnEditarCategoria\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1746, "\"", 1762, 1);
#nullable restore
#line 48 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
WriteAttributeValue("", 1754, item.Id, 1754, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</button>\r\n                </td>\r\n                <td>\r\n                    <button type=\"button\" class=\"btn btn-danger btnInativarCategoria\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1954, "\"", 1970, 1);
#nullable restore
#line 51 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
WriteAttributeValue("", 1962, item.Id, 1962, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Inativar</button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 54 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>
<div class=""row"">
    <nav aria-label=""Paginação"">
        <ul class=""pagination"">
            <li class=""page-item"">
                <a class=""page-link"" href=""#"" aria-label=""Previous"">
                    <span aria-hidden=""true"">&laquo;</span>
                    <span class=""sr-only"">Previous</span>
                </a>
            </li>
            <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
            <li class=""page-item"">
                <a class=""page-link"" href=""#"" aria-label=""Next"">
                    <span aria-hidden=""true"">&raquo;</span>
                    <span class=""sr-only"">Next</span>
                </a>
            </li>
        </ul>
    </nav>
</div>
");
#nullable restore
#line 77 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_TabelaCategoriasConfigPartial.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<LES.Models.ViewModel.Admin.CategoriaLivroModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
