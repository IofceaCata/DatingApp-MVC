#pragma checksum "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d49d129f3272005ba37dcb3ffaae4317465307c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_SearchCategory), @"mvc.1.0.view", @"/Views/Search/SearchCategory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Search/SearchCategory.cshtml", typeof(AspNetCore.Views_Search_SearchCategory))]
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
#line 1 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\_ViewImports.cshtml"
using MatrimonialProject;

#line default
#line hidden
#line 2 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\_ViewImports.cshtml"
using MatrimonialProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d49d129f3272005ba37dcb3ffaae4317465307c1", @"/Views/Search/SearchCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18b6dc0c0e2251bbed189b2d55873bdc22306189", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_SearchCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MatrimonialProject.ViewModels.SearchViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(56, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
 using (Html.BeginForm("SearchResult", "Search", FormMethod.Post))
{
    

#line default
#line hidden
            BeginContext(136, 21, false);
#line 7 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
Write(Html.Label("Max age"));

#line default
#line hidden
            EndContext();
            BeginContext(164, 35, false);
#line 8 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
Write(Html.TextBoxFor(model => model.Max));

#line default
#line hidden
            EndContext();
            BeginContext(206, 45, false);
#line 9 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
Write(Html.ValidationMessageFor(model => model.Max));

#line default
#line hidden
            EndContext();
            BeginContext(260, 21, false);
#line 11 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
Write(Html.Label("Min age"));

#line default
#line hidden
            EndContext();
            BeginContext(288, 35, false);
#line 12 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
Write(Html.TextBoxFor(model => model.Min));

#line default
#line hidden
            EndContext();
            BeginContext(330, 45, false);
#line 13 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
Write(Html.ValidationMessageFor(model => model.Min));

#line default
#line hidden
            EndContext();
            BeginContext(377, 43, true);
            WriteLiteral("    <button type=\"submit\">Search</button>\r\n");
            EndContext();
#line 15 "C:\Users\catal\OneDrive\Desktop\Work\W10\MatrimonialProject\Views\Search\SearchCategory.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MatrimonialProject.ViewModels.SearchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
