#pragma checksum "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de8da9156d4fd685ea1c603c21a5ba6d188c846c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoadStudentWithMarkPartial), @"mvc.1.0.view", @"/Views/Shared/_LoadStudentWithMarkPartial.cshtml")]
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
#line 1 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\_ViewImports.cshtml"
using Waitrose;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\_ViewImports.cshtml"
using Waitrose.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\_ViewImports.cshtml"
using Waitrose.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de8da9156d4fd685ea1c603c21a5ba6d188c846c", @"/Views/Shared/_LoadStudentWithMarkPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df27e9b20b814792f064ddbced42a02c9f68e91", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__LoadStudentWithMarkPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Mark>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""card"">
    <div class=""card-block"">
        <div class=""row"">
            <div class=""col-sm-12 table-responsive"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>FullName</th>
                            <th>Class</th>
                            <th>Subject</th>
                            <th>Exam</th>
                            <th>Exam Mark</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
");
#nullable restore
#line 18 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                             foreach (Mark item in Model)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 21 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                               Write(item.Student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 22 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                               Write(item.Student.Class.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 23 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                               Write(item.Subject.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 24 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                               Write(item.Exam.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 25 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                               Write(item.StudentMark);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\Shared\_LoadStudentWithMarkPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Mark>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591