#pragma checksum "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b76e0ba93ad9834517a9886312dd4e751fc4f39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carrinho_PartialViews__ListaCupomPartial), @"mvc.1.0.view", @"/Views/Carrinho/PartialViews/_ListaCupomPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b76e0ba93ad9834517a9886312dd4e751fc4f39", @"/Views/Carrinho/PartialViews/_ListaCupomPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Carrinho_PartialViews__ListaCupomPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<CupomModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
 if (Model.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
     foreach (var cupom in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-1\"></div>\r\n        <div class=\"col-10 text-center my-1\">Cupom #");
#nullable restore
#line 7 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
                                               Write(cupom.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral(": R$ -");
#nullable restore
#line 7 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
                                                                  Write(cupom.Valor.ToString("0.00").Replace('.', ','));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <button class=\"btn btn-danger botaoRemoverCupom col-1 my-1\"");
            BeginWriteAttribute("value", " value=\"", 322, "\"", 343, 1);
#nullable restore
#line 8 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
WriteAttributeValue("", 330, cupom.Codigo, 330, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            &times;\r\n        </button>\r\n");
#nullable restore
#line 11 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
     
}
else { 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-12\">\r\n        <h4 class=\"font-weight-light\">Não há cupons adicionados à sua compra.</h4>\r\n    </div>\r\n");
#nullable restore
#line 17 "D:\DEVELOPMENT\LES\LES\LES\Views\Carrinho\PartialViews\_ListaCupomPartial.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<CupomModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
