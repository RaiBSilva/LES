#pragma checksum "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b97b3ba95d810ab2794f963849c00935877dbdd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_PartialViews__ListaEnderecosPartial), @"mvc.1.0.view", @"/Views/Conta/PartialViews/_ListaEnderecosPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b97b3ba95d810ab2794f963849c00935877dbdd3", @"/Views/Conta/PartialViews/_ListaEnderecosPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_PartialViews__ListaEnderecosPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<DetalhesEnderecoModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../PartialViews/_DlEnderecoPartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n    <div>\r\n        <div class=\"row\">\r\n            <h2 class=\"font-weight-light col-sm-12\">\r\n                Endereços\r\n            </h2>\r\n        </div>\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
             foreach (var end in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-6 my-1 card\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b97b3ba95d810ab2794f963849c00935877dbdd34171", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 14 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => end);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <dl>\r\n                        <dd class=\"row justify-content-start mx-1\">\r\n                            <button class=\"btn btn-secondary botaoEndereco col-6 mr-3\" type=\"button\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 659, "\"", 674, 1);
#nullable restore
#line 17 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
WriteAttributeValue("", 667, end.Id, 667, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                Editar este endereço\r\n                            </button>\r\n");
#nullable restore
#line 20 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
                             if (Model.Count > 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <button class=\"btn btn-danger botaoRemoverEndereco col-2 mx-3\" type=\"button\" data-toggle=\"modal\" data-target=\"#myModal\"");
            BeginWriteAttribute("value", " value=\"", 1004, "\"", 1019, 1);
#nullable restore
#line 22 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
WriteAttributeValue("", 1012, end.Id, 1012, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    &times;\r\n                                </button>\r\n");
#nullable restore
#line 25 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
                             if (!end.EPreferencial)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <button class=\"btn btn-outline-warning col-2 ml-3\" type=\"button\"");
            BeginWriteAttribute("value", " value=\"", 1325, "\"", 1340, 1);
#nullable restore
#line 29 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
WriteAttributeValue("", 1333, end.Id, 1333, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    &#9733;\r\n                                </button>\r\n");
#nullable restore
#line 32 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </dd>\r\n                    </dl>\r\n                </div>\r\n");
#nullable restore
#line 36 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_ListaEnderecosPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <div class=""row justify-content-center"">
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
    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<DetalhesEnderecoModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
