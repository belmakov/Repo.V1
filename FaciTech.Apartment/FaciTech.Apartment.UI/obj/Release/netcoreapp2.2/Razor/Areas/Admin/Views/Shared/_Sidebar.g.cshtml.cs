#pragma checksum "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Sidebar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb3a3e742b155740b25de552cad901f115da83de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__Sidebar), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Sidebar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/_Sidebar.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared__Sidebar))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb3a3e742b155740b25de552cad901f115da83de", @"/Areas/Admin/Views/Shared/_Sidebar.cshtml")]
    public class Areas_Admin_Views_Shared__Sidebar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(9, 635, true);
            WriteLiteral(@"<style>
    
</style>
<div class=""sidebar"" data-color=""blue"">
    <!--
        Tip 1: You can change the color of the sidebar using: data-color=""blue | green | orange | red | yellow""
    -->
    <div class=""logo"" style=""margin:20px"">
        <div class=""simple-text logo-normal"" style=""float:left;padding-right:10px;"">
            <i class=""fa fa-user-plus"" style=""font-size:1.3em""></i>
        </div>
        <span class=""simple-text logo-normal"" >
            
            Admin
            
        </span>
    </div>
    <div class=""sidebar-wrapper"" id=""sidebar-wrapper"">
        <ul class=""nav"">
            <li");
            EndContext();
            BeginWriteAttribute("class", " class=", 644, "", 673, 1);
#line 23 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Sidebar.cshtml"
WriteAttributeValue("", 651, getClass("community"), 651, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(673, 193, true);
            WriteLiteral(">\r\n                <a href=\"/Admin\">\r\n                    <i class=\"now-ui-icons design_app\"></i>\r\n                    <p>Community</p>\r\n                </a>\r\n            </li>\r\n            <li");
            EndContext();
            BeginWriteAttribute("class", " class=", 866, "", 898, 1);
#line 29 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Sidebar.cshtml"
WriteAttributeValue("", 873, getClass("placeholder1"), 873, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(898, 215, true);
            WriteLiteral(">\r\n                <a href=\"/Admin/Home/Placeholder1\">\r\n                    <i class=\"now-ui-icons education_atom\"></i>\r\n                    <p>Amenities</p>\r\n                </a>\r\n            </li>\r\n            <li");
            EndContext();
            BeginWriteAttribute("class", " class=", 1113, "", 1145, 1);
#line 35 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Sidebar.cshtml"
WriteAttributeValue("", 1120, getClass("placeholder2"), 1120, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1145, 235, true);
            WriteLiteral(">\r\n                <a href=\"/Admin/Home/Placeholder2\">\r\n                    <i class=\"now-ui-icons location_map-big\"></i>\r\n                    <p>Areas</p>\r\n                </a>\r\n            </li>\r\n\r\n        </ul>\r\n    </div>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
#line 45 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Sidebar.cshtml"
            

string getClass(string option)
{
    var selection = ViewData["Sidebar-Selection"] as string;
    if (selection == option)
    {
        return "active";
    }
    return "";
}

#line default
#line hidden
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
