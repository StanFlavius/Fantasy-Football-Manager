#pragma checksum "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\PostAllPlayers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b7e3baaa813aaae55666235b9641305e20881af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jucatori_PostAllPlayers), @"mvc.1.0.view", @"/Views/Jucatori/PostAllPlayers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Jucatori/PostAllPlayers.cshtml", typeof(AspNetCore.Views_Jucatori_PostAllPlayers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7e3baaa813aaae55666235b9641305e20881af", @"/Views/Jucatori/PostAllPlayers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ffe499005b304603e54d55a39adf8a1e80e7508", @"/Views/_ViewImports.cshtml")]
    public class Views_Jucatori_PostAllPlayers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fantasy_Football_Manager.Models.Jucator>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 31, true);
            WriteLiteral("\r\n<h2>Lista jucatori</h2>\r\n\r\n\r\n");
            EndContext();
#line 6 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\PostAllPlayers.cshtml"
   
        var authorsList = ViewData["jucatori"] as List<Jucator>;
    

#line default
#line hidden
            BeginContext(157, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 10 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\PostAllPlayers.cshtml"
 foreach (var author in authorsList)
    {

#line default
#line hidden
            BeginContext(204, 66, true);
            WriteLiteral("    <div class=\"col-md-4 col-lg-4 col-xs-6 col-sm-4\">\r\n        <p>");
            EndContext();
            BeginContext(271, 18, false);
#line 13 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\PostAllPlayers.cshtml"
      Write(author.NumeJucator);

#line default
#line hidden
            EndContext();
            BeginContext(289, 18, true);
            WriteLiteral("</p>\r\n    </div>\r\n");
            EndContext();
#line 15 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\PostAllPlayers.cshtml"
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
