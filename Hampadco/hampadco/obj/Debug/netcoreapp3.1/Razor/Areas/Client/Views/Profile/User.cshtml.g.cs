#pragma checksum "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Client\Views\Profile\User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b42b00b69e2e234a2a2a818696dfc054b0d8b05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Profile_User), @"mvc.1.0.view", @"/Areas/Client/Views/Profile/User.cshtml")]
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
#line 1 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Client\Views\_ViewImports.cshtml"
using hampadco;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "f:\Projects\Hampadco\Hampadco\hampadco\Areas\Client\Views\_ViewImports.cshtml"
using hampadco.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b42b00b69e2e234a2a2a818696dfc054b0d8b05", @"/Areas/Client/Views/Profile/User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a77c7bfff406093198dff2bc9c98ebe6752e4157", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Profile_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("edit-profile m-b30"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("edit-profile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--Main container start -->
<main class=""ttr-wrapper"">
	<div class=""container-fluid"">
		<div class=""db-breadcrumb"">
			<h4 class=""breadcrumb-title"">پروفایل کاربر</h4>
			<ul class=""db-breadcrumb-list"">
				<li><a href=""#""><i class=""fa fa-home""></i>خانه</a></li>
				<li>پروفایل کاربر</li>
			</ul>
		</div>	
		<div class=""row"">
			<!-- Your Profile Views Chart -->
			<div class=""col-lg-12 m-b30"">
				<div class=""widget-box"">
					<div class=""wc-title"">
						<h4>پروفایل کاربر</h4>
					</div>
					<div class=""widget-inner"">
						");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b42b00b69e2e234a2a2a818696dfc054b0d8b054560", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("class", " class=\"", 599, "\"", 607, 0);
                EndWriteAttribute();
                WriteLiteral(@">
								<div class=""form-group row"">
									<div class=""col-sm-10  ml-auto"">
										<h3>1. جزییات پروفایل</h3>
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">نام و نام خانوادگی</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""زیبا فروزمند"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">شغل</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""برنامه‌نویسی"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">نام شرکت</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""بامداد"">
										<span class=""help"">اگر می خواهید فاکتورهای خود را به یک شرکت بفرستید. نام کامل خود را برای ما خالی بگذارید.</span>
									</div>
								</div>
								<div cl");
                WriteLiteral(@"ass=""form-group row"">
									<label class=""col-sm-2 col-form-label"">شماره تماس</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""+980 012345 6789"">
									</div>
								</div>
								
								<div class=""seperator""></div>
								
								<div class=""form-group row"">
									<div class=""col-sm-10 ml-auto"">
										<h3>2. آدرس</h3>
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">آدرس</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""میدان ونک"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">شهر</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""تهران"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">شهرستان</label>
									<div class=");
                WriteLiteral(@"""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""تهران"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">کد پستی</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""000702"">
									</div>
								</div>
								<div class=""m-form__seperator m-form__seperator--dashed m-form__seperator--space-2x""></div>
								<div class=""form-group row"">
									<div class=""col-sm-10 ml-auto"">
										<h3 class=""m-form__section"">3. شبکه های اجتماعی</h3>
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">لینکدین</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""www.linkedin.com"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">فیسبوک</label>
									<div class=""col-sm-7"">
										<input ");
                WriteLiteral(@"class=""form-control"" type=""text"" value=""www.facebook.com"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">توییتر</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""www.twitter.com"">
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">اینستاگرام</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""text"" value=""www.instagram.com"">
									</div>
								</div>
							</div>
							<div");
                BeginWriteAttribute("class", " class=\"", 4293, "\"", 4301, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\t\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("class", " class=\"", 4317, "\"", 4325, 0);
                EndWriteAttribute();
                WriteLiteral(@">
									<div class=""row"">
										<div class=""col-sm-2"">
										</div>
										<div class=""col-sm-7"">
											<button type=""reset"" class=""btn"">ذخیره تغییرات</button>
											<button type=""reset"" class=""btn-secondry"">انصراف</button>
										</div>
									</div>
								</div>
							</div>
						");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b42b00b69e2e234a2a2a818696dfc054b0d8b0510689", async() => {
                WriteLiteral("\r\n\t\t\t\t\t\t\t<div");
                BeginWriteAttribute("class", " class=\"", 4708, "\"", 4716, 0);
                EndWriteAttribute();
                WriteLiteral(@">
								<div class=""form-group row"">
									<div class=""col-sm-10 ml-auto"">
										<h3>4. رمزعبور</h3>
									</div>
								</div>
								<div class=""form-group row"">
									<label class=""col-sm-2 col-form-label"">رمز عبور فعلی</label>
									<div class=""col-sm-7"">
										<input class=""form-control"" type=""password""");
                BeginWriteAttribute("value", " value=\"", 5059, "\"", 5067, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"form-group row\">\r\n\t\t\t\t\t\t\t\t\t<label class=\"col-sm-2 col-form-label\">رمز عبور جدید</label>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-sm-7\">\r\n\t\t\t\t\t\t\t\t\t\t<input class=\"form-control\" type=\"password\"");
                BeginWriteAttribute("value", " value=\"", 5299, "\"", 5307, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t<div class=\"form-group row\">\r\n\t\t\t\t\t\t\t\t\t<label class=\"col-sm-2 col-form-label\">تکرار رمزعبور</label>\r\n\t\t\t\t\t\t\t\t\t<div class=\"col-sm-7\">\r\n\t\t\t\t\t\t\t\t\t\t<input class=\"form-control\" type=\"password\"");
                BeginWriteAttribute("value", " value=\"", 5539, "\"", 5547, 0);
                EndWriteAttribute();
                WriteLiteral(@">
									</div>
								</div>
							</div>
							<div class=""row"">
								<div class=""col-sm-2"">
								</div>
								<div class=""col-sm-7"">
									<button type=""reset"" class=""btn"">ذخیره تغییرات</button>
									<button type=""reset"" class=""btn-secondry"">انصراف</button>
								</div>
							</div>
								
						");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<!-- Your Profile Views Chart END-->\r\n\t\t</div>\r\n\t</div>\r\n</main>");
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
