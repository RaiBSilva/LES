#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c77a609241f3d1aeee81873b415e047bc4d0ea0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PartialViews__RowTabelaPedidosPartial), @"mvc.1.0.view", @"/Views/Admin/PartialViews/_RowTabelaPedidosPartial.cshtml")]
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
#line 2 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
using LES.Models.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c77a609241f3d1aeee81873b415e047bc4d0ea0d", @"/Views/Admin/PartialViews/_RowTabelaPedidosPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PartialViews__RowTabelaPedidosPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Admin.AdminPedidoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
   IDictionary<StatusPedidos, string[]> statusInfo = new Dictionary<StatusPedidos, string[]>();

    statusInfo[(StatusPedidos)0] = new string[] { "text-info", "Em processamento..." };
    statusInfo[(StatusPedidos)1] = new string[] { statusInfo[(StatusPedidos)0][0], "Em trânsito." };
    statusInfo[(StatusPedidos)2] = new string[] { "text-success", "Autorizada!" };
    statusInfo[(StatusPedidos)3] = new string[] { statusInfo[(StatusPedidos)2][0], "Concluída!" };
    statusInfo[(StatusPedidos)4] = new string[] { "text-danger", "Cancelada." };
    statusInfo[(StatusPedidos)5] = new string[] { statusInfo[(StatusPedidos)4][0], "Negada." };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<tr>\r\n    <th scope=\"row\">");
#nullable restore
#line 15 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
               Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    <td>");
#nullable restore
#line 16 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
   Write(Model.Cliente.InfoUsuario.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>´");
#nullable restore
#line 17 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
    Write(Model.DtPedido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>R$ ");
#nullable restore
#line 18 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
      Write(Model.PreçoTotal.ToString("0.00").Replace('.', ','));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td");
            BeginWriteAttribute("class", " class=\"", 935, "\"", 971, 1);
#nullable restore
#line 19 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
WriteAttributeValue("", 943, statusInfo[Model.Status][0], 943, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
                                        Write(statusInfo[Model.Status][1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    <td>\r\n        <button class=\"btn btn-outline-info btnVisualizarPedido btn-block\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1135, "\"", 1152, 1);
#nullable restore
#line 21 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Admin\PartialViews\_RowTabelaPedidosPartial.cshtml"
WriteAttributeValue("", 1143, Model.Id, 1143, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Visualizar/Editar</button>\r\n    </td>\r\n</tr>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Admin.AdminPedidoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
