#pragma checksum "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3e9bb181762b7f86e6ad180b6e2fa28de2fd8cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__Amenities), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Amenities.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/_Amenities.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared__Amenities))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3e9bb181762b7f86e6ad180b6e2fa28de2fd8cc", @"/Areas/Admin/Views/Shared/_Amenities.cshtml")]
    public class Areas_Admin_Views_Shared__Amenities : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<List<FaciTech.Apartment.UI.Areas.Admin.Models.AmenityViewModel>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(78, 49, true);
            WriteLiteral("<form id=\"amenityForm\" class=\"form-horizontal\">\r\n");
            EndContext();
#line 3 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
     foreach (var amenityRow in Model)
    {

#line default
#line hidden
            BeginContext(174, 85, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-sm-1\">\r\n\r\n            </div>\r\n");
            EndContext();
#line 9 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
             foreach (var amenity in amenityRow)
            {
                var id = "amenity_" + amenity.Id.ToString();
                var check = amenity.Selected ? "checked='checked'" : "";

#line default
#line hidden
            BeginContext(460, 147, true);
            WriteLiteral("                <div class=\"col-sm-2\">\r\n                    <div class=\"form-group\">\r\n                        <input type=\"checkbox\" name=\"amenity\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 607, "\"", 615, 1);
#line 15 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
WriteAttributeValue("", 612, id, 612, 3, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(616, 20, true);
            WriteLiteral(" autocomplete=\"off\" ");
            EndContext();
            BeginContext(637, 5, false);
#line 15 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
                                                                                     Write(check);

#line default
#line hidden
            EndContext();
            BeginContext(642, 10, true);
            WriteLiteral(" data-id=\"");
            EndContext();
            BeginContext(653, 10, false);
#line 15 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
                                                                                                     Write(amenity.Id);

#line default
#line hidden
            EndContext();
            BeginContext(663, 89, true);
            WriteLiteral("\" />\r\n                        <div class=\"btn-group\">\r\n                            <label");
            EndContext();
            BeginWriteAttribute("for", " for=\"", 752, "\"", 761, 1);
#line 17 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
WriteAttributeValue("", 758, id, 758, 3, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(762, 228, true);
            WriteLiteral(" class=\"btn btn-outline-primary\">\r\n                                <span class=\"fa fa-check fa-2x\"></span>\r\n                                <span> </span>\r\n                            </label>\r\n                            <label");
            EndContext();
            BeginWriteAttribute("for", " for=\"", 990, "\"", 999, 1);
#line 21 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
WriteAttributeValue("", 996, id, 996, 3, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1000, 67, true);
            WriteLiteral(" class=\"btn btn-outline-primary\">\r\n                                ");
            EndContext();
            BeginContext(1068, 12, false);
#line 22 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
                           Write(amenity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1080, 124, true);
            WriteLiteral("\r\n                            </label>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
            EndContext();
#line 27 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
            }

#line default
#line hidden
            BeginContext(1219, 74, true);
            WriteLiteral("            <div class=\"col-sm-1\">\r\n\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 32 "D:\Users\belma\source\repos\Repo.V1\FaciTech.Apartment\FaciTech.Apartment.UI\Areas\Admin\Views\Shared\_Amenities.cshtml"
    }

#line default
#line hidden
            BeginContext(1300, 367, true);
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-sm-6"">
        </div>
        <div class=""col-sm-6"">
            <div class=""form-group float-right"" style="""">
                <div>
                    <button type=""button"" class=""btn btn-primary"" id=""save_amenities"">Save</button>
                </div>
            </div>
        </div>
    </div>
</form>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<List<FaciTech.Apartment.UI.Areas.Admin.Models.AmenityViewModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591