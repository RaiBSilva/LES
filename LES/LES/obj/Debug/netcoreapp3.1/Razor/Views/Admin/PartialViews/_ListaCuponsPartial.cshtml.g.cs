#pragma checksum "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2b2a4a4654ed7a1ebfeb7eafe73aa52c4f8687c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PartialViews__ListaCuponsPartial), @"mvc.1.0.view", @"/Views/Admin/PartialViews/_ListaCuponsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2b2a4a4654ed7a1ebfeb7eafe73aa52c4f8687c", @"/Views/Admin/PartialViews/_ListaCuponsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PartialViews__ListaCuponsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<CupomModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
 if (Model.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <table class=""table col-12"">
            <thead>
                <tr>
                    <th> Código do Cupom: </th>
                </tr>
                <tr>
                    <th> Valor do Cupom: </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 20 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 24 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
                       Write(item.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            R$ ");
#nullable restore
#line 27 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
                          Write(item.Valor.ToString("0.00").Replace(".", ","));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 30 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
    <div class=""row justify-content-end"">
        <nav aria-label=""Paginação"" class=""mt-3"">
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
#line 53 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
}
else {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row justify-content-center\">\r\n        <h3 class=\"col-12 text-center\">Este cliente não possui cupons.</h3>\r\n    </div>\r\n");
#nullable restore
#line 58 "C:\Programming\LES\LES\LES\Views\Admin\PartialViews\_ListaCuponsPartial.cshtml"
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
