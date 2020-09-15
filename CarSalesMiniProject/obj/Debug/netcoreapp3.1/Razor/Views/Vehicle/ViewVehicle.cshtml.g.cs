#pragma checksum "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4faf77f329d1433dc832a759e72118b6f9e748d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_ViewVehicle), @"mvc.1.0.view", @"/Views/Vehicle/ViewVehicle.cshtml")]
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
#line 2 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
using CarSalesMiniProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4faf77f329d1433dc832a759e72118b6f9e748d", @"/Views/Vehicle/ViewVehicle.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_ViewVehicle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarSalesMiniProject.ViewModels.VehicleViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
  
    ViewData["Title"] = "VehicleCreated";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
 if (!ViewBag.IdValid)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 class=\"text-center mt-5 bg-danger py-2 mx-5 rounded\">Vehicle not found.</h1>\r\n");
#nullable restore
#line 11 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
     if (ViewBag.JustCreated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1 class=\"text-center mt-5 bg-success py-2 mx-5 rounded\">Vehicle Created!</h1>\r\n");
#nullable restore
#line 17 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
     switch (Model.VehicleType)
    {
        case "Car":
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
       Write(await Html.PartialAsync("_CarDetails", (CarViewModel) Model));

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
                                                                         
            break;
       default:

#line default
#line hidden
#nullable disable
            WriteLiteral("           <h2 class=\"text-center mt-5 bg-danger py-2 mx-5 rounded\"> Type of vehicle not identified. </h2>\r\n");
#nullable restore
#line 26 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
           break;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Marceau\source\repos\CarSalesMiniProject\CarSalesMiniProject\Views\Vehicle\ViewVehicle.cshtml"
     

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarSalesMiniProject.ViewModels.VehicleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591