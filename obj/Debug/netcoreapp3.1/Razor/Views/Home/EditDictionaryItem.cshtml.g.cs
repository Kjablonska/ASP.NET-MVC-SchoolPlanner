#pragma checksum "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditDictionaryItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16714f30cb6aa255de414f38d1bad554d3697cc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EditDictionaryItem), @"mvc.1.0.view", @"/Views/Home/EditDictionaryItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16714f30cb6aa255de414f38d1bad554d3697cc6", @"/Views/Home/EditDictionaryItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b6fb50251b9279afcfafd132029793408e05ecb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EditDictionaryItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EditDictionaryItemViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n\n");
#nullable restore
#line 18 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditDictionaryItem.cshtml"
 using (Html.BeginForm("SaveDictionaryItem", "Home", getEventParameters()))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label for=\"item\" value=\"Save\"></label>\n    <input type=\"text\" id=\"item\" name=\"item\" style=\"width:100%\"");
            BeginWriteAttribute("value", " value=", 517, "", 565, 1);
#nullable restore
#line 21 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditDictionaryItem.cshtml"
WriteAttributeValue("", 524, Context.Request.Query["item"].ToString(), 524, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n    <div>\n        <a");
            BeginWriteAttribute("href", " href=", 587, "", 687, 1);
#nullable restore
#line 23 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditDictionaryItem.cshtml"
WriteAttributeValue("", 593, Url.Action("EditDictionary", new {dictionary=Context.Request.Query["dictionary"].ToString()}), 593, 94, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <button method=\"post\" class=\"button button3\">Cancel</button>\n        </a>\n        <input class=\"button button1\" style=\"float:right\" type=\"submit\" value=\"Save\">\n    </div>\n");
#nullable restore
#line 28 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditDictionaryItem.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/Views/Home/EditDictionaryItem.cshtml"
           
    public object getEventParameters()
    {
        var editedItem = Context.Request.Query["item"].ToString();
        var dictionary = Context.Request.Query["dictionary"].ToString();

        return new
        {
            dictionary,
            editedItem,
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditDictionaryItemViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
