#pragma checksum "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ccb6418b8f8961d738c90750e254278095ce01a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditEntry), @"mvc.1.0.view", @"/Views/Home/EditEntry.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ccb6418b8f8961d738c90750e254278095ce01a", @"/Views/Home/EditEntry.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b6fb50251b9279afcfafd132029793408e05ecb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditEntry : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditEntryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 17 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
 using (Html.BeginForm("SaveEntry", "Home")) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\n        <tr>\n            <th><label for=\"room\">Room</label></th>\n            <th>\n                <input type=\"text\" id=\"room\" name=\"room\" style=\"width:120px\"");
            BeginWriteAttribute("value", " value=", 598, "", 648, 1);
#nullable restore
#line 22 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
WriteAttributeValue("", 605, Context.Request.Query["room"].ToString(), 605, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly>\n            </th>\n        </tr>\n        <tr>\n            <th><label for=\"slot\">Slot</label></th>\n            <th>\n                <input type=\"text\" id=\"slot\" name=\"slot\" style = \"width:120px\"");
            BeginWriteAttribute("value", " value=", 851, "", 901, 1);
#nullable restore
#line 28 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
WriteAttributeValue("", 858, Context.Request.Query["slot"].ToString(), 858, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly>\n            </th>\n        </tr>\n        <tr>\n            <th><label for=\"day\">Day</label></th>\n            <th>\n                <input type=\"text\" id=\"day\" name=\"day\" style = \"width:120px\"");
            BeginWriteAttribute("value", " value=", 1100, "", 1149, 1);
#nullable restore
#line 34 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
WriteAttributeValue("", 1107, Context.Request.Query["day"].ToString(), 1107, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" readonly>\n            </th>\n        </tr>\n        <tr>\n            <th>Group</th>\n            <th>\n");
#nullable restore
#line 41 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
               Write(Html.DropDownList("group", (SelectList)@Model.groupsItems, @Model.group, new { style = "width:140px"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("            </th>\n        </tr>\n        <tr>\n            <th>Teacher</th>\n            <th>\n");
#nullable restore
#line 49 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
               Write(Html.DropDownList("teacher", (SelectList)@Model.teachersItems, @Model.teacher, new { style = "width:140px"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("            </th>\n        </tr>\n        <tr>\n            <th>Class</th>\n            <th>\n");
#nullable restore
#line 57 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
               Write(Html.DropDownList("clas", (SelectList)@Model.classesItems, @Model.clas, new { style = "width:140px"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("            </th>\n        </tr>\n    </table>\n    <input type=\"submit\">\n");
#nullable restore
#line 63 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div>\n");
#nullable restore
#line 67 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
     using (Html.BeginForm("UnassignEntry", "Home", getEventParameters(), FormMethod.Post)) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button name=Unassign>Unassign</button>\n");
#nullable restore
#line 69 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n<div>\n    <a");
            BeginWriteAttribute("href", " href=", 2166, "", 2248, 1);
#nullable restore
#line 73 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
WriteAttributeValue("", 2172, Url.Action("Index", new {room = @Context.Request.Query["room"].ToString()}), 2172, 76, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        <button method=\"post\" class=\"button\">Cancel</button>\n    </a>\n</div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditEntry.cshtml"
           
    public object getEventParameters() {
        var room = Context.Request.Query["room"].ToString();
        var day = Context.Request.Query["day"].ToString();
        var slot = int.Parse(Context.Request.Query["slot"].ToString());

        return new {
            room,
            slot,
            day,
        };
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditEntryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
