#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e98d023a5121964cb807fa01aa28d256cc2c0f28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LivroCardPartial), @"mvc.1.0.view", @"/Views/Shared/_LivroCardPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e98d023a5121964cb807fa01aa28d256cc2c0f28", @"/Views/Shared/_LivroCardPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LivroCardPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Shared.LivroBaseModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <div class=\"col-md-3\">\r\n        <div class=\"card mb-3\">\r\n            <div class=\"align-items-center p-2 text-center\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 320, "\"", 384, 3);
#nullable restore
#line 10 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
WriteAttributeValue("", 326, Url.Action("Livro","Imagem"), 326, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 355, "?codBar=", 355, 8, true);
#nullable restore
#line 10 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
WriteAttributeValue("", 363, Model.CodigoBarras, 363, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"max-height:200px\"/>\r\n                <h5 class=\"font-weight-light\">");
#nullable restore
#line 11 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
                                          Write(Model.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <h6>");
#nullable restore
#line 12 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
                Write(Model.Autor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <div class=\"row mt-3\">\r\n                    <div class=\"col-sm-12 font-weight-light\" style=\"height:4rem\">\r\n                        <small");
            BeginWriteAttribute("class", " class=\"", 676, "\"", 684, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
                                    Write(Model.Sinopse.Substring(0, 60) + "...");

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                    </div>\r\n                    <div class=\"col-sm-12 mt-3 text-dark\">\r\n                        <h5>R$ ");
#nullable restore
#line 18 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
                           Write(Model.Preco.ToString("0.00").Replace('.',','));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                    </div>
                </div>
            </div>
            <div class=""container"">
                <div class=""row no-gutters justify-content-sm-around"">
                        <button type=""button"" class=""btn btn-outline-success col-8""");
            BeginWriteAttribute("onclick", " onclick=\"", 1175, "\"", 1272, 5);
            WriteAttributeValue("", 1185, "window.location.href=\'", 1185, 22, true);
#nullable restore
#line 24 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
WriteAttributeValue("", 1207, Url.Action("Descricao","Livros"), 1207, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1242, "?codBar=", 1242, 8, true);
#nullable restore
#line 24 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
WriteAttributeValue("", 1250, Model.CodigoBarras, 1250, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1271, "\'", 1271, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size:0.75rem\">SAIBA MAIS</button>\r\n                        <button type=\"button\" class=\"btn btn-success col-3 addToCarrinho\"");
            BeginWriteAttribute("value", " value=\"", 1410, "\"", 1437, 1);
#nullable restore
#line 25 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Shared\_LivroCardPartial.cshtml"
WriteAttributeValue("", 1418, Model.CodigoBarras, 1418, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size:0.75rem\"><i class=\"fa fa-shopping-cart\"></i></button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
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
