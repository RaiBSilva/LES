#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5e7642c23d0869f3ec9befe0e75518355626369"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PartialViews__CardTabelaPedidos), @"mvc.1.0.view", @"/Views/Admin/PartialViews/_CardTabelaPedidos.cshtml")]
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
#nullable restore
#line 3 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
using LES.Models.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5e7642c23d0869f3ec9befe0e75518355626369", @"/Views/Admin/PartialViews/_CardTabelaPedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PartialViews__CardTabelaPedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PedidoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
     double precoTotal = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-striped table-hover table-sm \">\r\n    <thead>\r\n        <tr>\r\n            <th scope=\"col\">Livro</th>\r\n            <th scope=\"col\">Preço</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 15 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
         if (Model.Livros.Count > 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
             foreach (var entry in Model.Livros)
            {
                var livro = entry.Value;
                precoTotal += livro.Preco;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 22 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
                   Write(livro.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
                   Write(livro.Preco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 25 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>Nº de livros: ");
#nullable restore
#line 27 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
                             Write(Model.Livros.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>Preço total: R$");
#nullable restore
#line 28 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
                              Write(precoTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td></td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_CardTabelaPedidos.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PedidoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
