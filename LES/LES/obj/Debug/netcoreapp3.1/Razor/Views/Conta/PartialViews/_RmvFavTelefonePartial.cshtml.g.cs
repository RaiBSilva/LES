#pragma checksum "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "676be5ecec11cff34a1cd63d4304b2c6f5dc74ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_PartialViews__RmvFavTelefonePartial), @"mvc.1.0.view", @"/Views/Conta/PartialViews/_RmvFavTelefonePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"676be5ecec11cff34a1cd63d4304b2c6f5dc74ca", @"/Views/Conta/PartialViews/_RmvFavTelefonePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05d182fd369d3f2aa535a82b7100c694a2ef0f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_PartialViews__RmvFavTelefonePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DetalhesTelefoneModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../PartialViews/_DlTelefonePartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
   
    string acao = (string)ViewData["Acao"];
    bool fav = acao == "Favoritar" ? true : false;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"modal-content\">\r\n\r\n    <!-- Modal content-->\r\n    <div class=\"modal-header\">\r\n        <h4 class=\"modal-title\">");
#nullable restore
#line 12 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
                           Write(acao);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Telefone</h4>
        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
    </div>
    <div class=""modal-body"">
        <div>
            <div>
                <h5 class=""text-danger"">
                    Tem certeza que deseja ");
#nullable restore
#line 19 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
                                      Write(acao.ToLower());

#line default
#line hidden
#nullable disable
            WriteLiteral(" esse telefone? ");
#nullable restore
#line 19 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
                                                                           if (!fav) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>Essa ação é permanente.</span>");
#nullable restore
#line 19 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
                                                                                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </h5>\r\n            </div>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "676be5ecec11cff34a1cd63d4304b2c6f5dc74ca5550", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 23 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 25 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
             if (fav) 
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    <button type=\"submit\" class=\"btn btn-warning\" id=\"btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 898, "\"", 986, 5);
            WriteAttributeValue("", 908, "window.location.href=\'", 908, 22, true);
#nullable restore
#line 28 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
WriteAttributeValue("", 930, Url.Action("FavoritarTelefone","Conta"), 930, 42, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 972, "?id=", 972, 4, true);
#nullable restore
#line 28 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
WriteAttributeValue("", 976, Model.Id, 976, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 985, "\'", 985, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        Favoritar\r\n                    </button>\r\n                </div>\r\n");
#nullable restore
#line 32 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
            }
            else { 

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <button type=\"submit\"");
            BeginWriteAttribute("value", " value=\"", 1191, "\"", 1208, 1);
#nullable restore
#line 35 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
WriteAttributeValue("", 1199, Model.Id, 1199, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\" id=\"btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1241, "\"", 1327, 5);
            WriteAttributeValue("", 1251, "window.location.href=\'", 1251, 22, true);
#nullable restore
#line 35 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
WriteAttributeValue("", 1273, Url.Action("RemoverTelefone","Conta"), 1273, 40, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1313, "?id=", 1313, 4, true);
#nullable restore
#line 35 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
WriteAttributeValue("", 1317, Model.Id, 1317, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1326, "\'", 1326, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    Remover permanentemente\r\n                </button>\r\n            </div>\r\n");
#nullable restore
#line 39 "C:\Programming\LES\LES\LES\Views\Conta\PartialViews\_RmvFavTelefonePartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Cancelar</button>\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetalhesTelefoneModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
