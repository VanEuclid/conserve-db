#pragma checksum "/Users/van/Documents/Github/ConserveDB/ConserveDB/ConserveDB/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5656184df0ba0ba5e81d2c8018bcbcb344306ba"
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
#line 1 "/Users/van/Documents/Github/ConserveDB/ConserveDB/ConserveDB/Views/_ViewImports.cshtml"
using ConserveDB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/van/Documents/Github/ConserveDB/ConserveDB/ConserveDB/Views/_ViewImports.cshtml"
using ConserveDB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5656184df0ba0ba5e81d2c8018bcbcb344306ba", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebfdee7356006a3eef47dc13f3bab75d29282522", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/van/Documents/Github/ConserveDB/ConserveDB/ConserveDB/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">
        Welcome to the Conservice Team Manager
    </h1>
    <p>
        Author: Van Euclid Dy.
        <br />This is my first encounter to ASP.net, please excuse the lack of polish.
        <br />Thank you for looking at this project!!
    </p>
</div>
<br />
<br />

    List of updates since submission:
<br />
<li>Added protections on employment status</li>
<li>Created department manager feature</li>
<li>Added department/manager metric</li>
<li>Restructured project to one master context that holds all the DbSets so that its easy to create relations</li>
<li>Added dropdown for departments in create and edit</li>");
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
