#pragma checksum "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1825313d76850eb9a52c72c2fa91a61ad25a0278"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_ListGames), @"mvc.1.0.view", @"/Views/Games/ListGames.cshtml")]
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
#line 1 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\_ViewImports.cshtml"
using GamesShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\_ViewImports.cshtml"
using GamesShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1825313d76850eb9a52c72c2fa91a61ad25a0278", @"/Views/Games/ListGames.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cb5380c15779e5a4aa245899cd195b63c700a3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_ListGames : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GamesShop.Models.Games>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
  
    ViewData["Title"] = "Библиотека игр";


#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1825313d76850eb9a52c72c2fa91a61ad25a02783560", async() => {
                WriteLiteral("\r\n    <title>Магазин компьютерных игр</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1825313d76850eb9a52c72c2fa91a61ad25a02784573", async() => {
                WriteLiteral("\r\n    <h3> Список игр </h3>\r\n    <table class=\"table-condensed\">\r\n        <tr>\r\n            <td></td>\r\n            <td> Название игры:</td>\r\n            <td> Дата Релиза:</td>\r\n            \r\n        </tr>\r\n");
#nullable restore
#line 22 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
         foreach (var games in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("    <tr>\r\n        <td><img");
                BeginWriteAttribute("src", " src=\"", 475, "\"", 493, 1);
#nullable restore
#line 25 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
WriteAttributeValue("", 481, games.Image, 481, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 494, "\"", 512, 1);
#nullable restore
#line 25 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
WriteAttributeValue("", 500, games.Image, 500, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></td>\r\n        <td> ");
#nullable restore
#line 26 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
        Write(games.NameOfGame);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 27 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
       Write(Html.DisplayFor(modelItem => games.DateOfRelease));

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\r\n        <td></td>\r\n\r\n    </tr>\r\n");
#nullable restore
#line 31 "C:\Users\MAXIM\source\repos\Sigma\Sigma\GamesShop\GamesShop\Views\Games\ListGames.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </table>\r\n\r\n   \r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GamesShop.Models.Games>> Html { get; private set; }
    }
}
#pragma warning restore 1591
