#pragma checksum "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\User\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d43bc634ee099cc5c521b3b1fe3463ec3135d4cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Detail), @"mvc.1.0.view", @"/Views/User/Detail.cshtml")]
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
#line 1 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\_ViewImports.cshtml"
using BlogSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\_ViewImports.cshtml"
using BlogSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d43bc634ee099cc5c521b3b1fe3463ec3135d4cb", @"/Views/User/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"295ab12cce6caff78ba4ff7388419b3241a20df4", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Yazi>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div>\r\n        <h1>Metin</h1>\r\n        <p> ");
#nullable restore
#line 5 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\User\Detail.cshtml"
       Write(Model.YaziMetni);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n    </div>\r\n    <hr />\r\n    <div>\r\n        <h2>Yorumlar</h2>\r\n    </div>\r\n    <hr />  \r\n");
#nullable restore
#line 12 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\User\Detail.cshtml"
     foreach (var item in Model.Yorumlar)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <h3>Yorum sahibi : ");
#nullable restore
#line 15 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\User\Detail.cshtml"
                          Write(item.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3> \r\n            <p> ");
#nullable restore
#line 16 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\User\Detail.cshtml"
           Write(item.YorumMetni);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n       <hr /> \r\n");
#nullable restore
#line 19 "C:\Users\Muhammed\source\repos\BlogSite\BlogSite\Views\User\Detail.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Yazi> Html { get; private set; }
    }
}
#pragma warning restore 1591