#pragma checksum "D:\pruebas\aiswebprueba2migrandousuarios\AISWEB(v0.0.1)\AISWEB\Areas\Usuarios\Pages\Eliminar\Eliminar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c94e2e1f9c78bfbd929ae8c504940811f32bf61d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AISWEB.Areas.Usuarios.Pages.Eliminar.Areas_Usuarios_Pages_Eliminar_Eliminar), @"mvc.1.0.razor-page", @"/Areas/Usuarios/Pages/Eliminar/Eliminar.cshtml")]
namespace AISWEB.Areas.Usuarios.Pages.Eliminar
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
#line 1 "D:\pruebas\aiswebprueba2migrandousuarios\AISWEB(v0.0.1)\AISWEB\Areas\Usuarios\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\pruebas\aiswebprueba2migrandousuarios\AISWEB(v0.0.1)\AISWEB\Areas\Usuarios\Pages\_ViewImports.cshtml"
using AISWEB.Areas.Usuarios;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c94e2e1f9c78bfbd929ae8c504940811f32bf61d", @"/Areas/Usuarios/Pages/Eliminar/Eliminar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ffd65e53a227adf0405a204d642c7f6c4f83ca", @"/Areas/Usuarios/Pages/_ViewImports.cshtml")]
    public class Areas_Usuarios_Pages_Eliminar_Eliminar : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <div class=""right_col"" role=""main"">
        <div class=""modal fade"" id=""fm-modal-grid"" tabindex=""-1"" role=""dialog"" aria-labelledby=""fm-modal-grid"" aria-hidden=""true"">
            <div class=""modal-dialog"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title""");
            BeginWriteAttribute("id", " id=\"", 426, "\"", 431, 0);
            EndWriteAttribute();
            WriteLiteral(@">Seguro que desea Eliminar este usuario?</h5>
                        <button class=""close"" data-dismiss=""modal"" aria-label=""Cerrar"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>

                    <div class=""modal-body"">
                        <div class=""container-fluid"">
                            <div class=""row"">
                                <div class=""col-12 label-important"">

                                    <h5>Se eliminara el usuario Permanentemente!</h5>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class=""modal-footer"">
                        <button class=""btn btn-danger"">Aceptar</button>
                        <button class=""btn btn-default"" data-dismiss=""modal"">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

  ");
            WriteLiteral("  </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AISWEB.Areas.Usuarios.Pages.Eliminar.EliminarModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AISWEB.Areas.Usuarios.Pages.Eliminar.EliminarModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AISWEB.Areas.Usuarios.Pages.Eliminar.EliminarModel>)PageContext?.ViewData;
        public AISWEB.Areas.Usuarios.Pages.Eliminar.EliminarModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591