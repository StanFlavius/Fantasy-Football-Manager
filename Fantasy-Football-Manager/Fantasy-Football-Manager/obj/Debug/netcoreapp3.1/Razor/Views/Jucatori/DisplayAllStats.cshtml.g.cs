#pragma checksum "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a84a38b4dcce433a698e197262581d3a2872c856"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jucatori_DisplayAllStats), @"mvc.1.0.view", @"/Views/Jucatori/DisplayAllStats.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Jucatori/DisplayAllStats.cshtml", typeof(AspNetCore.Views_Jucatori_DisplayAllStats))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a84a38b4dcce433a698e197262581d3a2872c856", @"/Views/Jucatori/DisplayAllStats.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ffe499005b304603e54d55a39adf8a1e80e7508", @"/Views/_ViewImports.cshtml")]
    public class Views_Jucatori_DisplayAllStats : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fantasy_Football_Manager.ViewModels.PlayerAllInfoDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(104, 164, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<h2>Players Table</h2>\r\n<table id=\"myTable\" class=\"table-striped table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(269, 47, false);
#line 14 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.NumeJucator));

#line default
#line hidden
            EndContext();
            BeginContext(316, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(372, 50, false);
#line 17 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.PrenumeJucator));

#line default
#line hidden
            EndContext();
            BeginContext(422, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(478, 50, false);
#line 20 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.PozitieJucator));

#line default
#line hidden
            EndContext();
            BeginContext(528, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(584, 48, false);
#line 23 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.EchipaFotbal));

#line default
#line hidden
            EndContext();
            BeginContext(632, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(688, 44, false);
#line 26 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.NrGoluri));

#line default
#line hidden
            EndContext();
            BeginContext(732, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(788, 45, false);
#line 29 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.NrAssists));

#line default
#line hidden
            EndContext();
            BeginContext(833, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(889, 49, false);
#line 32 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.NrCleansheets));

#line default
#line hidden
            EndContext();
            BeginContext(938, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(994, 49, false);
#line 35 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           Write(Html.DisplayNameFor(model => model.NrTotalPuncte));

#line default
#line hidden
            EndContext();
            BeginContext(1043, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 40 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
           var playersInfos = ViewData["playersInfos"] as List<Fantasy_Football_Manager.ViewModels.PlayerAllInfoDTO>;

            foreach (var item in playersInfos)
            {

#line default
#line hidden
            BeginContext(1290, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1363, 46, false);
#line 46 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumeJucator));

#line default
#line hidden
            EndContext();
            BeginContext(1409, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1489, 49, false);
#line 49 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PrenumeJucator));

#line default
#line hidden
            EndContext();
            BeginContext(1538, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1618, 49, false);
#line 52 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PozitieJucator));

#line default
#line hidden
            EndContext();
            BeginContext(1667, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1747, 47, false);
#line 55 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EchipaFotbal));

#line default
#line hidden
            EndContext();
            BeginContext(1794, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1874, 43, false);
#line 58 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NrGoluri));

#line default
#line hidden
            EndContext();
            BeginContext(1917, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1997, 44, false);
#line 61 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NrAssists));

#line default
#line hidden
            EndContext();
            BeginContext(2041, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2121, 48, false);
#line 64 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NrCleansheets));

#line default
#line hidden
            EndContext();
            BeginContext(2169, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2249, 48, false);
#line 67 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NrTotalPuncte));

#line default
#line hidden
            EndContext();
            BeginContext(2297, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 70 "C:\Users\flavi\OneDrive\Documents\GitHub\Fantasy-Football-Manager\Fantasy-Football-Manager\Fantasy-Football-Manager\Views\Jucatori\DisplayAllStats.cshtml"
            }
        

#line default
#line hidden
            BeginContext(2375, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2418, 168, true);
                WriteLiteral("\r\n    <script>\r\n\t\t\t$(document).ready(function () {\r\n\t\t\t\t$(\'#myTable\').DataTable();//myTable is the id of the table to be displayed as dataTable\r\n\t\t\t});\r\n    </script>\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fantasy_Football_Manager.ViewModels.PlayerAllInfoDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591