#pragma checksum "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed015302379a4d737a573c2868f296e103c74bd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_PartialViews__DlTelefonePartial), @"mvc.1.0.view", @"/Views/Conta/PartialViews/_DlTelefonePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed015302379a4d737a573c2868f296e103c74bd7", @"/Views/Conta/PartialViews/_DlTelefonePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_PartialViews__DlTelefonePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Conta.DetalhesTelefoneModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
   string classePreferencial = Model.EPreferencial ? "preferencial" : "";
    string classDt = "col-sm-12";
    string classDd = "col-sm-12";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <dl>\r\n        <dt");
            BeginWriteAttribute("class", " class=\"", 230, "\"", 266, 2);
#nullable restore
#line 9 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue("", 238, classDt, 238, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue(" ", 246, classePreferencial, 247, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 10 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
       Write(Html.DisplayNameFor(model => model.TipoTelefone));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
                                                               if (Model.EPreferencial)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"text-warning\">&#9733;</span>\r\n");
#nullable restore
#line 12 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dt>\r\n        <dd");
            BeginWriteAttribute("class", " class=\"", 459, "\"", 495, 2);
#nullable restore
#line 14 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue("", 467, classDd, 467, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue(" ", 475, classePreferencial, 476, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 15 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
       Write(Html.DisplayFor(model => model.TipoTelefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt");
            BeginWriteAttribute("class", " class=\"", 584, "\"", 620, 2);
#nullable restore
#line 17 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue("", 592, classDt, 592, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue(" ", 600, classePreferencial, 601, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 18 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
       Write(Html.DisplayNameFor(model => model.Ddd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd");
            BeginWriteAttribute("class", " class=\"", 704, "\"", 740, 2);
#nullable restore
#line 20 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue("", 712, classDd, 712, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue(" ", 720, classePreferencial, 721, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 21 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
       Write(Html.DisplayFor(model => model.Ddd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt");
            BeginWriteAttribute("class", " class=\"", 820, "\"", 856, 2);
#nullable restore
#line 23 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue("", 828, classDt, 828, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue(" ", 836, classePreferencial, 837, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 24 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
       Write(Html.DisplayNameFor(model => model.NumeroTelefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd");
            BeginWriteAttribute("class", " class=\"", 951, "\"", 987, 2);
#nullable restore
#line 26 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue("", 959, classDd, 959, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
WriteAttributeValue(" ", 967, classePreferencial, 968, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 27 "D:\DESENVOLVIMENTO\LES\LES\LES\Views\Conta\PartialViews\_DlTelefonePartial.cshtml"
       Write(Html.DisplayFor(model => model.NumeroTelefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Conta.DetalhesTelefoneModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
