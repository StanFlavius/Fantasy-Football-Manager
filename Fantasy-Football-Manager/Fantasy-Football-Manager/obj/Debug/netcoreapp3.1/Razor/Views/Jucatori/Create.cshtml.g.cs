#pragma checksum "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "476397b585e4df56f47edf92d3cceeaa3e825aed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jucatori_Create), @"mvc.1.0.view", @"/Views/Jucatori/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Jucatori/Create.cshtml", typeof(AspNetCore.Views_Jucatori_Create))]
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
#line 1 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\_ViewImports.cshtml"
using Fantasy_Football_Manager;

#line default
#line hidden
#line 2 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\_ViewImports.cshtml"
using Fantasy_Football_Manager.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"476397b585e4df56f47edf92d3cceeaa3e825aed", @"/Views/Jucatori/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ffe499005b304603e54d55a39adf8a1e80e7508", @"/Views/_ViewImports.cshtml")]
    public class Views_Jucatori_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fantasy_Football_Manager.Models.Jucator>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
            BeginContext(90, 21, true);
            WriteLiteral("\r\n<h1>Create</h1>\r\n\r\n");
            EndContext();
#line 8 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(141, 83, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(225, 76, false);
#line 13 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
       Write(Html.LabelFor(x => x.NumeJucator, new { @class = "control-label col-md-3" }));

#line default
#line hidden
            EndContext();
            BeginContext(301, 54, true);
            WriteLiteral("\r\n            <div class=\"col-md-9\">\r\n                ");
            EndContext();
            BeginContext(356, 68, false);
#line 15 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
           Write(Html.TextBoxFor(x => x.NumeJucator, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(424, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(511, 79, false);
#line 20 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
       Write(Html.LabelFor(x => x.PrenumeJucator, new { @class = "control-label col-md-3" }));

#line default
#line hidden
            EndContext();
            BeginContext(590, 54, true);
            WriteLiteral("\r\n            <div class=\"col-md-9\">\r\n                ");
            EndContext();
            BeginContext(645, 71, false);
#line 22 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
           Write(Html.TextBoxFor(x => x.PrenumeJucator, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(716, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(803, 79, false);
#line 27 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
       Write(Html.LabelFor(x => x.PozitieJucator, new { @class = "control-label col-md-3" }));

#line default
#line hidden
            EndContext();
            BeginContext(882, 54, true);
            WriteLiteral("\r\n            <div class=\"col-md-9\">\r\n                ");
            EndContext();
            BeginContext(937, 71, false);
#line 29 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
           Write(Html.TextBoxFor(x => x.PozitieJucator, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 86, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1095, 77, false);
#line 34 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
       Write(Html.LabelFor(x => x.EchipaFotbal, new { @class = "control-label col-md-3" }));

#line default
#line hidden
            EndContext();
            BeginContext(1172, 54, true);
            WriteLiteral("\r\n            <div class=\"col-md-9\">\r\n                ");
            EndContext();
            BeginContext(1227, 69, false);
#line 36 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
           Write(Html.TextBoxFor(x => x.EchipaFotbal, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1296, 254, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-10 col-md-offset-2\">\r\n                <input type=\"submit\" value=\"Add\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
            EndContext();
#line 47 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\Create.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fantasy_Football_Manager.Models.Jucator> Html { get; private set; }
    }
}
#pragma warning restore 1591
