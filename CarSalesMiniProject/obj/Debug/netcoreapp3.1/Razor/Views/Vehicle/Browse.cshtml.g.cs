#pragma checksum "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd7743dc5373ee4e2aa4c60602e097f1f2d8a470"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_Browse), @"mvc.1.0.view", @"/Views/Vehicle/Browse.cshtml")]
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
#line 2 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
using CarSalesMiniProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd7743dc5373ee4e2aa4c60602e097f1f2d8a470", @"/Views/Vehicle/Browse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_Browse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarSalesMiniProject.ViewModels.CarListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-5 container-fluid vehicle-abstract rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vehicle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewVehicle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid py-5\">\r\n");
#nullable restore
#line 9 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
       int rowIndex = 0; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
     foreach (var car in Model.CarList.Select((value, index) => new { index, value }))
    {
        if (car.index % 2 == 0)
        {
            string divClass = "row mt-3";
            if (rowIndex == 0)
            {
                divClass = "row";
            }
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
       Write(Html.Raw(string.Format("<div class=\"{0}\">", divClass)));

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
                                                                     
        }


#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd7743dc5373ee4e2aa4c60602e097f1f2d8a4705522", async() => {
                WriteLiteral(@"
            <div class=""row justify-content-center"">
                <div class=""col-10 car-image py-5 text-center"">
                    <span class=""fa fa-car""></span>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-6 font-weight-bold"">
                    ");
#nullable restore
#line 30 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
               Write(car.value.Make);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
                               Write(car.value.Model);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-6\">\r\n                    Created on ");
#nullable restore
#line 33 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
                          Write(car.value.AddDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-VehicleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
                                                                                                                             WriteLiteral(car.value.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["VehicleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-VehicleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["VehicleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"

        if (car.index % 2 != 0)
        {
            rowIndex++;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
       Write(Html.Raw("</div>"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\Browse.cshtml"
                               
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarSalesMiniProject.ViewModels.CarListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
