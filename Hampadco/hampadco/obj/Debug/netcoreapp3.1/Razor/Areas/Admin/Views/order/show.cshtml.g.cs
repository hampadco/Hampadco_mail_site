#pragma checksum "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c91217dbb2cf736a76aa19b663b4aa962dda3407"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_order_show), @"mvc.1.0.view", @"/Areas/Admin/Views/order/show.cshtml")]
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
#line 1 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\_ViewImports.cshtml"
using hampadco;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\_ViewImports.cshtml"
using hampadco.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c91217dbb2cf736a76aa19b663b4aa962dda3407", @"/Areas/Admin/Views/order/show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab99064084068b19349a35efc6c15a1d282f4711", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_order_show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- BEGIN: Content-->\r\n<section id=\"data-list-view\" class=\"data-list-view-header\">\r\n  <!-- DataTable starts -->\r\n");
#nullable restore
#line 4 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
   if (ViewBag.er != null)
  {

#line default
#line hidden
#nullable disable
            WriteLiteral("  <p class=\"alert alert-success\">");
#nullable restore
#line 6 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                            Write(ViewBag.er);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 7 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
  }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  <div class=""table-responsive"">
    <table class=""table data-list-view"">
      <thead>
        <tr>
          <th></th>
          <th>ردیف</th>
          <th> عنوان محصول </th>
          <th>شماره فاکتور </th>
         
          <th> قیمت </th>
          <th> تعداد</th>
          <th> جمع کل</th>

          
        </tr>
      </thead>
      <tbody>
");
#nullable restore
#line 25 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
         if ( ViewBag.listp != null)
        {

        int i=1;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
         foreach (var item in ViewBag.listp)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n          <td></td>\r\n          <td class=\"product-category\"> ");
#nullable restore
#line 34 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-name\">");
#nullable restore
#line 35 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                              Write(item.product_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n          <td class=\"product-category\">");
#nullable restore
#line 36 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                                  Write(item.Id_Order);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n          <td class=\"product-category\">");
#nullable restore
#line 38 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                                  Write(item.product_Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n          <td class=\"product-category\">");
#nullable restore
#line 39 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                                  Write(item.Product_Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n          <td class=\"product-category\">");
#nullable restore
#line 41 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                                  Write(item.Total_sum);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n         \r\n        </tr>\r\n");
#nullable restore
#line 45 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
i++;
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
         

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"







      </tbody>
    </table>
  </div>
  <!-- DataTable ends -->

  <!-- add new sidebar starts -->

  <!-- add new sidebar ends -->
</section>
<!-- Data list view end -->
<p class=""alert alert-info text-center"" style=""color: black !important;"">جمع کل: ");
#nullable restore
#line 67 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Admin\Views\order\show.cshtml"
                                                                            Write(ViewBag.sum);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<div class=\"text-center\">\r\n\r\n</div>\r\n");
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
