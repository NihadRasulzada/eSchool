#pragma checksum "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8880da3078b60d26713c2b375edb750c352a6861"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViewMarks_Index), @"mvc.1.0.view", @"/Views/ViewMarks/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8880da3078b60d26713c2b375edb750c352a6861", @"/Views/ViewMarks/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df27e9b20b814792f064ddbced42a02c9f68e91", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ViewMarks_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Mark>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""content-wrapper"">
    <div class=""container-fluid"">
        <div class=""row dashboard-header"">
            <div class=""col-lg-4 col-md-6"">
                <div class=""card dashboard-product"">
                    <span>Select Class</span>
                    <div class=""form-group"">
                        <select class=""form-control"" name=""classId"" id=""classId"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8880da3078b60d26713c2b375edb750c352a68614226", async() => {
                WriteLiteral("NULL");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 11 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                             foreach (Class item in ViewBag.Classes)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8880da3078b60d26713c2b375edb750c352a68615518", async() => {
#nullable restore
#line 13 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6"">
                <div class=""card dashboard-product"">
                    <span>Select Exam</span>
                    <div class=""form-group"">
                        <select class=""form-control"" name=""examId"" id=""examId"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8880da3078b60d26713c2b375edb750c352a68618005", async() => {
                WriteLiteral("NULL");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 25 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                             foreach (Exam item in ViewBag.Exams)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8880da3078b60d26713c2b375edb750c352a68619294", async() => {
#nullable restore
#line 27 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </select>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6"">
                <div class=""card dashboard-product"">
                    <span>Select Subject</span>
                    <div class=""form-group"">
                        <select class=""form-control"" name=""subjectId"" id=""subjectId"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8880da3078b60d26713c2b375edb750c352a686111790", async() => {
                WriteLiteral("NULL");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6"">
                <div class=""form-group"">
                    <button id=""find"" class=""btn btn-info"">Find</button>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-sm-12"" style=""margin-top:30px"" id=""studentList"">
                <div class=""card"">
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
    ");
            WriteLiteral("                                        <th>Exam Mark</th>\r\n                                        </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 66 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                         foreach (Mark item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td>");
#nullable restore
#line 69 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                               Write(item.Student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 70 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                               Write(item.Student.Class.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 71 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                               Write(item.Subject.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 72 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                               Write(item.Exam.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 73 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                               Write(item.StudentMark);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 75 "C:\Users\nihad\Documents\Me\MyProjects\Back\Waitrose\Waitrose\Views\ViewMarks\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8880da3078b60d26713c2b375edb750c352a686116760", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        $(document).on(""change"", ""#classId"", function () {
            $.ajax({
                url: ""/ViewMarks/LoadSubject/"",
                type: ""get"",
                data: {
                    ""classId"": $(""#classId"").val()
                },
                success: function (res) {
                    if (res == """") {
                        $(""#subjectId"").empty()
                        $(""#subjectId"").append(""<option>NULL</option>"")
                        $(""#subjectId"").append(res)
                    }
                    else {
                        $(""#subjectId"").empty()
                        $(""#subjectId"").append(res)
                    }

                }
            });
        });
        $(document).on(""click"", ""#find"", function () {
            $.ajax({
                url: ""/ViewMarks/LoadStudentWithMark/"",
                type: ""get"",
                data: {
                    ""classId"": $(""#classId"").val(),
                    ""exa");
                WriteLiteral(@"mId"": $(""#examId"").val(),
                    ""subjectId"": $(""#subjectId"").val()
                },
                success: function (res) {
                    $(""#studentList"").empty()
                    $(""#studentList"").append(res)
                }
            });
        });
    </script>
");
            }
            );
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
