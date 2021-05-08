#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18b1f3e4f421acce514bf056ccc1afb5dd22c7ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_PartialViews__TablePedidos), @"mvc.1.0.view", @"/Views/Conta/PartialViews/_TablePedidos.cshtml")]
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
#line 3 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
using LES.Models.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18b1f3e4f421acce514bf056ccc1afb5dd22c7ac", @"/Views/Conta/PartialViews/_TablePedidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_PartialViews__TablePedidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PedidoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
      bool elegivelTroca = (Model.Status <= (StatusPedidos)6 && Model.Status >= (StatusPedidos)5);
       double precoTotal = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table table-striped table-hover table-sm \">\r\n    <thead>\r\n        <tr>\r\n            <th scope=\"col\">Livro</th>\r\n            <th scope=\"col\">Preço</th>\r\n            <th scope=\"col\">Troca</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 17 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
         if (Model.Livros.Count > 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
             foreach (var livro in Model.Livros)
            {
                precoTotal += livro.Preco;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 23 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                   Write(livro.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                   Write(livro.Preco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 26 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                         if (elegivelTroca)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button class=\"btn btn-info btnTroca\"");
            BeginWriteAttribute("value", " value=\"", 862, "\"", 889, 1);
#nullable restore
#line 28 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
WriteAttributeValue("", 870, livro.CodigoBarras, 870, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" data-target=\"#myModal\">Solicitar</button>\r\n");
#nullable restore
#line 29 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>Não é elegível para troca.</p>\r\n");
#nullable restore
#line 33 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 36 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>Nº de livros: ");
#nullable restore
#line 38 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                             Write(Model.Livros.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>Preço total: R$");
#nullable restore
#line 39 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
                              Write(precoTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td></td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_TablePedidos.cshtml"
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
