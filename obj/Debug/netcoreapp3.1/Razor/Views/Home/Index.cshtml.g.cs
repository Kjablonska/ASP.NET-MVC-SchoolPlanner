#pragma checksum "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1d74bdbd498b815ad7a734c3ac9b020d8082db8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/_ViewImports.cshtml"
using SchoolPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/_ViewImports.cshtml"
using SchoolPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1d74bdbd498b815ad7a734c3ac9b020d8082db8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b6fb50251b9279afcfafd132029793408e05ecb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
  
    ViewData["Table"] = "School Planner";

    string[] ColumnsHeaders = new string[] {
        ""
        ,"Monday"
        ,"Tuesday"
        ,"Wednesday"
        ,"Thursday"
        ,"Friday"
    };

    string[] RowsHeaders = new string[] {
        "8:00-8:45"
        ,"8:55-9:40"
        ,"9:50-11:35"
        ,"11:55-12:40"
        ,"12:50-13:35"
        ,"13:45-14:30"
        ,"14:40-15:25"
        ,"15:35-16:20"
        ,"16:30-17:15"
    };


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"table-responsive\">\r\n    <table class=\"table table-bordered\">\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 31 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
                  
                    foreach (var col in ColumnsHeaders)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>\r\n                            ");
#nullable restore
#line 35 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
                       Write(col);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n");
#nullable restore
#line 37 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n            <tr>\r\n");
#nullable restore
#line 43 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
                  
                    foreach (var row in RowsHeaders)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>\r\n                            ");
#nullable restore
#line 47 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
                       Write(row);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <tr>\r\n                        </tr></th>\r\n");
#nullable restore
#line 50 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
