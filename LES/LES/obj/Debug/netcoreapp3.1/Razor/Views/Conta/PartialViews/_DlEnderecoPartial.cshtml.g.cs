#pragma checksum "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d0e6303094803deefd3d69388b216766a415582"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_PartialViews__DlEnderecoPartial), @"mvc.1.0.view", @"/Views/Conta/PartialViews/_DlEnderecoPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d0e6303094803deefd3d69388b216766a415582", @"/Views/Conta/PartialViews/_DlEnderecoPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_PartialViews__DlEnderecoPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LES.Models.ViewModel.Conta.DetalhesEnderecoModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   string classePreferencial = Model.EPreferencial ? "preferencial" : "";
    string classDt = "";
    string classDd = "";
    bool obs = Model.Observacoes != "";
    string classeObs = obs ? "col-4" : "col-6";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<dl class=\"row mb-0 text-info\">\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 321, "\"", 367, 3);
#nullable restore
#line 11 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 329, classDd, 329, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 337, classePreferencial, 338, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 357, "col-sm-12", 358, 10, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <h5>");
#nullable restore
#line 12 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
       Write(Html.DisplayFor(model => model.NomeEndereco));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
                                                          if (Model.EPreferencial) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"text-warning\">&#9733;</span> \r\n");
#nullable restore
#line 13 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    </dd>\r\n</dl>\r\n<dl class=\"row\">\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 557, "\"", 599, 3);
#nullable restore
#line 17 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 565, classDt, 565, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 573, classePreferencial, 574, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 593, "col-3", 594, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        Tipo\r\n    </dt>\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 635, "\"", 677, 3);
#nullable restore
#line 20 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 643, classDt, 643, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 651, classePreferencial, 652, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 671, "col-7", 672, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 21 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Logradouro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 756, "\"", 798, 3);
#nullable restore
#line 23 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 764, classDt, 764, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 772, classePreferencial, 773, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 792, "col-2", 793, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 24 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Numero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 873, "\"", 915, 3);
#nullable restore
#line 26 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 881, classDd, 881, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 889, classePreferencial, 890, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 909, "col-3", 910, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 27 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.TipoEndereco));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 992, "\"", 1034, 3);
#nullable restore
#line 29 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1000, classDd, 1000, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1008, classePreferencial, 1009, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1028, "col-7", 1029, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 30 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Logradouro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 1109, "\"", 1151, 3);
#nullable restore
#line 32 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1117, classDd, 1117, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1125, classePreferencial, 1126, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1145, "col-2", 1146, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 33 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Numero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n</dl>\r\n<dl class=\"row\">\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 1247, "\"", 1289, 3);
#nullable restore
#line 37 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1255, classDt, 1255, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1263, classePreferencial, 1264, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1283, "col-4", 1284, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 38 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Complemento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 1369, "\"", 1411, 3);
#nullable restore
#line 40 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1377, classDt, 1377, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1385, classePreferencial, 1386, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1405, "col-5", 1406, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 41 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Cidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 1486, "\"", 1528, 3);
#nullable restore
#line 43 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1494, classDt, 1494, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1502, classePreferencial, 1503, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1522, "col-3", 1523, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 44 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Cep));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 1600, "\"", 1642, 3);
#nullable restore
#line 46 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1608, classDd, 1608, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1616, classePreferencial, 1617, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1636, "col-4", 1637, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 47 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Complemento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 1718, "\"", 1760, 3);
#nullable restore
#line 49 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1726, classDd, 1726, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1734, classePreferencial, 1735, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1754, "col-5", 1755, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 50 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Cidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 1831, "\"", 1873, 3);
#nullable restore
#line 52 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1839, classDd, 1839, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 1847, classePreferencial, 1848, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1867, "col-3", 1868, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 53 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Cep));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n</dl>\r\n<dl class=\"row justify-content-center\">\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 1989, "\"", 2036, 3);
#nullable restore
#line 57 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 1997, classDt, 1997, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2005, classePreferencial, 2006, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2025, classeObs, 2026, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 58 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dt");
            BeginWriteAttribute("class", " class=\"", 2111, "\"", 2158, 3);
#nullable restore
#line 60 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 2119, classDt, 2119, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2127, classePreferencial, 2128, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2147, classeObs, 2148, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 61 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayNameFor(model => model.Pais));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n");
#nullable restore
#line 63 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
     if (obs)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt");
            BeginWriteAttribute("class", " class=\"", 2257, "\"", 2299, 3);
#nullable restore
#line 65 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 2265, classDt, 2265, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2273, classePreferencial, 2274, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2293, "col-4", 2294, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
#nullable restore
#line 66 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
       Write(Html.DisplayNameFor(model => model.Observacoes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n");
#nullable restore
#line 68 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 2396, "\"", 2443, 3);
#nullable restore
#line 70 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 2404, classDd, 2404, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2412, classePreferencial, 2413, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2432, classeObs, 2433, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 71 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dd");
            BeginWriteAttribute("class", " class=\"", 2514, "\"", 2561, 3);
#nullable restore
#line 73 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 2522, classDd, 2522, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2530, classePreferencial, 2531, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2550, classeObs, 2551, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 74 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
   Write(Html.DisplayFor(model => model.Pais));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n");
#nullable restore
#line 76 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
     if (obs)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dd");
            BeginWriteAttribute("class", " class=\"", 2660, "\"", 2702, 3);
#nullable restore
#line 78 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue("", 2668, classDd, 2668, 8, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
WriteAttributeValue(" ", 2676, classePreferencial, 2677, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 2696, "col-4", 2697, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 79 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
           Write(Html.DisplayFor(model => model.Observacoes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 81 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_DlEnderecoPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</dl>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LES.Models.ViewModel.Conta.DetalhesEnderecoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
