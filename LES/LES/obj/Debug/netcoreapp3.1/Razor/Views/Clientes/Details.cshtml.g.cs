#pragma checksum "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "854f6f3d4bff7b8618fa100665543889185c35cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clientes_Details), @"mvc.1.0.view", @"/Views/Clientes/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"854f6f3d4bff7b8618fa100665543889185c35cc", @"/Views/Clientes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26cf44f01c1eae048a1ce84ded07886f12edd399", @"/Views/_ViewImports.cshtml")]
    public class Views_Clientes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.Entity.Cliente>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
  
    ViewData["Title"] = "Detalhes";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detalhes</h1>\r\n\r\n<div>\r\n    <h4>Cliente</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DtNascimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.DtNascimento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Genero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Genero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Telefone.Ddd));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 42 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                                       Write(Html.DisplayFor(model => model.Telefone.Numero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DtCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.DtCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EnderecoResidencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.EnderecoResidencia.Logradouro));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 54 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                                                      Write(Html.DisplayFor(model => model.EnderecoResidencia.Numero));

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n            ");
#nullable restore
#line 55 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayFor(model => model.EnderecoResidencia.Cidade.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 55 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                                                         Write(Html.DisplayFor(model => model.EnderecoResidencia.Cidade.Estado.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                                                                                                                                Write(Html.DisplayFor(model => model.EnderecoResidencia.Cidade.Estado.Pais.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
#nullable restore
#line 57 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
          int i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 59 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EnderecosEntrega));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <dl class=\"row\">\r\n");
#nullable restore
#line 63 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                 foreach (var endereco in Model.EnderecosEntrega)
                {
                    { i++; }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <dt class=\"col-sm-2\">\r\n                        Endereco de entrega ");
#nullable restore
#line 67 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 70 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                   Write(endereco.Logradouro);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 70 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                        Write(endereco.Numero);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                        ");
#nullable restore
#line 71 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                   Write(endereco.Cidade.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 71 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                           Write(endereco.Cidade.Estado.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 71 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                                                         Write(endereco.Cidade.Estado.Pais.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n");
#nullable restore
#line 73 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dl>\r\n        </dd>\r\n");
#nullable restore
#line 76 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
           i = 0; 

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 78 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.EnderecosCobranca));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <dl class=\"row\">\r\n");
#nullable restore
#line 82 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                 foreach (var endereco in Model.EnderecosCobranca)
                {
                    { i++; }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <dt class=\"col-sm-2\">\r\n                        Endereco de cobrança ");
#nullable restore
#line 86 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 89 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                   Write(endereco.Logradouro);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 89 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                        Write(endereco.Numero);

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n                        ");
#nullable restore
#line 90 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                   Write(endereco.Cidade.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 90 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                           Write(endereco.Cidade.Estado.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 90 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                                                                         Write(endereco.Cidade.Estado.Pais.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n");
#nullable restore
#line 92 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dl>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 98 "C:\Programming\LES\LES\LES\Views\Clientes\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "854f6f3d4bff7b8618fa100665543889185c35cc15235", async() => {
                WriteLiteral("De volta a listagem");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.Entity.Cliente> Html { get; private set; }
    }
}
#pragma warning restore 1591