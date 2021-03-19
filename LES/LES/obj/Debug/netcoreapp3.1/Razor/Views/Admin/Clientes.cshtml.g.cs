#pragma checksum "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30032afe4f52623192b51cf32e64785ca0cc9fe8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Clientes), @"mvc.1.0.view", @"/Views/Admin/Clientes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30032afe4f52623192b51cf32e64785ca0cc9fe8", @"/Views/Admin/Clientes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Clientes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Admin.ClientesPaginaModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Admin/CarregadorPartialViewClientes.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
  
    ViewData["Title"] = "Livros";
    Layout = "~/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row justify-content-center""><h1 class=""col-12 text-center"">Base de Clientes Cadastrados</h1></div>
<div class=""row"">
    <div class=""col-12 mb-3 border-bottom"">
    </div>
</div>
<div class=""row"">
    <table class=""table"">
        <caption>Lista de clientes</caption>
        <thead class=""thead-dark"">
            <tr>
                <th scope=""col"">Id</th>
                <th scope=""col"">Nome</th>
                <th scope=""col"">E-mail</th>
                <th scope=""col"">Detalhes</th>
                <th scope=""col"">Inativar</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 26 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
             foreach (var cliente in Model.Clientes)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <th scope=\"row\">");
#nullable restore
#line 29 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                               Write(cliente.InfoUsuario.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td>");
#nullable restore
#line 30 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                   Write(cliente.InfoUsuario.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                   Write(cliente.InfoUsuario.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><button type=\"button\" class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1120, "\"", 1212, 3);
            WriteAttributeValue("", 1130, "window.location.href=\'", 1130, 22, true);
#nullable restore
#line 32 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
WriteAttributeValue("", 1152, Url.Action("Cliente", "Admin", cliente.InfoUsuario.Codigo), 1152, 59, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1211, "\'", 1211, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Visualizar</button></td>\r\n");
#nullable restore
#line 33 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                     if (cliente.Inativo)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><button type=\"button\" class=\"btn btn-success btnInativar\" href=\"#myModal\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1450, "\"", 1485, 1);
#nullable restore
#line 35 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
WriteAttributeValue("", 1458, cliente.InfoUsuario.Codigo, 1458, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Reativar</button></td>\r\n");
#nullable restore
#line 36 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                    } 
                    else
                    { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><button type=\"button\" class=\"btn btn-danger btnInativar\" href=\"#myModal\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1728, "\"", 1763, 1);
#nullable restore
#line 39 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
WriteAttributeValue("", 1736, cliente.InfoUsuario.Codigo, 1736, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Inativar</button></td>\r\n");
#nullable restore
#line 40 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 42 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
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
<div class=""modal fade"" id=""myModal"" role=""dialog"">

</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script type=\"text/javascript\">\r\n        var urls = urls || {};\r\n        urls.InativarReativarCliente = \'");
#nullable restore
#line 73 "C:\Programming\LES\LES\LES\Views\Admin\Clientes.cshtml"
                                   Write(Url.Action("_InativarReativarClientePartial", "Admin"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n\r\n    </script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30032afe4f52623192b51cf32e64785ca0cc9fe89503", async() => {
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
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Admin.ClientesPaginaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
