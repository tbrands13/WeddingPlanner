#pragma checksum "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6270913b1d4d802f957928cd7337ab68ce46026"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
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
#line 1 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6270913b1d4d802f957928cd7337ab68ce46026", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""d-flex justify-content-around mb-4"">
    <h1>Welcome to the Wedding Planner</h1>
    <a href=""/"" class=""btn btn-lg btn-outline-secondary"">Logout</a>
</div>
<div class=""mb-4"">
    <table class=""table table-striped table-hover"">
        <tr>
            <th>Wedding</th>
            <th>Date</th>
            <th>Guest</th>
            <th>Action</th>
        </tr>
");
#nullable restore
#line 17 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
         foreach (Wedding w in ViewBag.AllWeddings)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 523, "\"", 551, 2);
            WriteAttributeValue("", 530, "/wedding/", 530, 9, true);
#nullable restore
#line 20 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 539, w.WeddingId, 539, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
                                               Write(w.WedderOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" & ");
#nullable restore
#line 20 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
                                                              Write(w.WedderTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\n                <td>");
#nullable restore
#line 21 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
               Write(w.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 22 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
               Write(w.Guests.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 23 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
                  
                    if(w.UserId == ViewBag.User)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><a");
            BeginWriteAttribute("href", " href=\"", 784, "\"", 819, 3);
            WriteAttributeValue("", 791, "/wedding/", 791, 9, true);
#nullable restore
#line 26 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 800, w.WeddingId, 800, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 812, "/delete", 812, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-outline-danger\">Remove</a></td>\n");
#nullable restore
#line 27 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
                    }
                    else if(w.Guests.Any(rsvp => rsvp.UserId == @ViewBag.User))
                    {
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1059, "\"", 1091, 3);
            WriteAttributeValue("", 1066, "/rsvp/", 1066, 6, true);
#nullable restore
#line 31 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1072, w.WeddingId, 1072, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1084, "/remove", 1084, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-outline-dark\">Un-RSVP</a></td>\n");
#nullable restore
#line 32 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
                        }
                        
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td><a");
            BeginWriteAttribute("href", " href=\"", 1296, "\"", 1329, 3);
            WriteAttributeValue("", 1303, "/wedding/", 1303, 9, true);
#nullable restore
#line 37 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
WriteAttributeValue("", 1312, w.WeddingId, 1312, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1324, "/rsvp", 1324, 5, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-outline-success\">RSVP</a></td>\n");
#nullable restore
#line 38 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\n");
#nullable restore
#line 41 "/Users/tito/Desktop/Coding_Dojo/CSharp/ORM/WeddingPlanner/Views/Home/Dashboard.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n</div>\n<div>\n    <a href=\"/planwedding\" class=\"btn btn-lg btn-outline-warning\">New Wedding</a>\n</div>");
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
