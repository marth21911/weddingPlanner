#pragma checksum "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c6ccff2e157ac925cdd42abf5f7e6dde1b34393"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewWedding), @"mvc.1.0.view", @"/Views/Home/ViewWedding.cshtml")]
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
#line 1 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\_ViewImports.cshtml"
using weddingPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\_ViewImports.cshtml"
using weddingPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c6ccff2e157ac925cdd42abf5f7e6dde1b34393", @"/Views/Home/ViewWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d2f7e7fad137d735531a94f00fd8cb8297fea8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>");
#nullable restore
#line 2 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
Write(ViewBag.OneWedding.WedOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" and ");
#nullable restore
#line 2 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
                              Write(ViewBag.OneWedding.WedTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" are getting MARRIED!</h1>\r\n<a href=\"/logout\">Logout</a>\r\n<a href=\"/dashboard\">Dashboard</a>\r\n<h3>Save the date: ");
#nullable restore
#line 5 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
              Write(ViewBag.OneWedding.WedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>Guest List</h3>\r\n<ul>\r\n");
#nullable restore
#line 8 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
     foreach (Event a in ViewBag.OneWedding.Attendees)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>");
#nullable restore
#line 10 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
       Write(a.User.FName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
                     Write(a.User.LName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 11 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n<h1><marquee>And its going down at ");
#nullable restore
#line 13 "C:\Users\marth\Documents\coding\csharpDojo\weddingPlanner\Views\Home\ViewWedding.cshtml"
                              Write(ViewBag.OneWedding.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</marquee></h1>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
