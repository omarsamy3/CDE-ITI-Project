#pragma checksum "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\ViewFiles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea30b9b0641d99ebb27694e8a7ac58451246aaeb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Folders_ViewFiles), @"mvc.1.0.view", @"/Views/Folders/ViewFiles.cshtml")]
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
#line 1 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\_ViewImports.cshtml"
using ITICDE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\_ViewImports.cshtml"
using ITICDE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea30b9b0641d99ebb27694e8a7ac58451246aaeb", @"/Views/Folders/ViewFiles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0e79c1c365f83f179a037dd7d262446ddbb1b96", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Folders_ViewFiles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ITICDE.Models.File>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\ViewFiles.cshtml"
  
    ViewData["Title"] = "SingleFile";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>");
#nullable restore
#line 5 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\ViewFiles.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<embed id=\"embPDF\"");
            BeginWriteAttribute("src", " src=\"", 115, "\"", 139, 2);
            WriteAttributeValue("", 121, "/Files/", 121, 7, true);
#nullable restore
#line 7 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\ViewFiles.cshtml"
WriteAttributeValue("", 128, Model.Name, 128, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:100%; height:1200px; \"/>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ITICDE.Models.File> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
