#pragma checksum "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eda873f1b4b4fca607cb43da1bb2469980fe85d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Folders_InnerDet), @"mvc.1.0.view", @"/Views/Folders/InnerDet.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eda873f1b4b4fca607cb43da1bb2469980fe85d7", @"/Views/Folders/InnerDet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0e79c1c365f83f179a037dd7d262446ddbb1b96", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Folders_InnerDet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ITICDE.Models.Folder>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "InnerDet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:whitesmoke"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Folders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MultipleFiles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
  
    ViewData["Title"] = "InnerDet";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br />\r\n\r\n<div>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 120, "\"", 166, 2);
            WriteAttributeValue("", 127, "/Folders/CreateInnerFolder?Id=", 127, 30, true);
#nullable restore
#line 10 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
WriteAttributeValue("", 157, Model.Id, 157, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Create inner Folder</a>\r\n\r\n    <br /> <br />\r\n");
#nullable restore
#line 13 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
     foreach (var item in Model.InnerFolders)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eda873f1b4b4fca607cb43da1bb2469980fe85d76822", async() => {
#nullable restore
#line 15 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
                                                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" </h3>\r\n");
#nullable restore
#line 16 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
    
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n<div>\r\n    <h2>Upload Multiple Files</h2>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eda873f1b4b4fca607cb43da1bb2469980fe85d79668", async() => {
                WriteLiteral("\r\n    <input type=\"file\" name=\"files\" multiple/>\r\n    <button class=\"btn btn-primary\" type=\"submit\" >Submit</button>\r\n    <hr />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
                                                               WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
#nullable restore
#line 31 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
 if(Model.Files.Count()!=0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"" data-interval=""6000"">
    <table class = ""table-responsive table-bordered"">
        <tr>
            <th width=""400px"" style=""text-align :center"">File Name </th>
            <th width=""400px"" style=""text-align :center"">File Type </th>
            

        </tr>
");
#nullable restore
#line 41 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
         foreach (var item in Model.Files)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td style=\"text-align :center\">");
#nullable restore
#line 44 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
                                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"text-align :center\">");
#nullable restore
#line 45 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
                                              Write(item.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"text-align :center\" ><a");
            BeginWriteAttribute("href", " href=\"", 1407, "\"", 1444, 2);
            WriteAttributeValue("", 1414, "/Folders/ViewFiles?Id=", 1414, 22, true);
#nullable restore
#line 46 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
WriteAttributeValue("", 1436, item.Id, 1436, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">View</a></td>\r\n                    <td ><a");
            BeginWriteAttribute("href", " href=\"", 1509, "\"", 1557, 2);
            WriteAttributeValue("", 1516, "/Folders/DownloadFile?fileName=", 1516, 31, true);
#nullable restore
#line 47 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
WriteAttributeValue("", 1547, item.Name, 1547, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Download</a></td>\r\n                    <td ><a");
            BeginWriteAttribute("href", " href=\"", 1629, "\"", 1667, 2);
            WriteAttributeValue("", 1636, "/Folders/DeleteFile?Id=", 1636, 23, true);
#nullable restore
#line 48 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
WriteAttributeValue("", 1659, item.Id, 1659, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-danger\">Delete</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 50 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
#nullable restore
#line 53 "E:\A1Programming\1My.CEI Program\Project\CDEITIProject\ProjectITICDE\ITICDE\ITICDE\Views\Folders\InnerDet.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ITICDE.Models.Folder> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
