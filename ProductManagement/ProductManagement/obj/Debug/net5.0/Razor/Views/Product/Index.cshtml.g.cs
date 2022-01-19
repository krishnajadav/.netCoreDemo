#pragma checksum "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e62a60f8e9e187d9884c60eaae128d1fede1f7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\_ViewImports.cshtml"
using ProductManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\_ViewImports.cshtml"
using ProductManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e62a60f8e9e187d9884c60eaae128d1fede1f7f", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3c080bb828670149ae3d5dcdc557160bd745a88", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            DefineSection("headFiles", async() => {
                WriteLiteral(@"

    <link href=""https://cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css"" rel=""stylesheet"">
    <link href=""https://cdn.datatables.net/buttons/1.7.0/css/buttons.dataTables.min.css"" rel=""stylesheet"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>





    <script src=""https://cdnjs.cloudflare.com/ajax/libs/bootbox.js/4.4.0/bootbox.min.js""></script>


    <style>
        .red {
            color: red;
        }

        .green {
            color: green;
        }
    </style>

    <script>
        var LoadProduct;
        $(document).ready(function () {

            function binddropdown() {

                $.ajax({
                    url: '");
#nullable restore
#line 37 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\Product\Index.cshtml"
                     Write(Url.Action("GetCategoryList", "Product"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    type: ""POST"",
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: ""{}"",
                    success: function (response) {
                        ddlProduct.empty().append('<option selected=""selected"" value=""0"">Select Category</option>');

                        $.each(response, function () {
                            ddlProduct.append($(""<option></option>"").val(this['value']).html(this['text']));
                        });
                    },
                    error: function (err) {
                        alert(err.statusText);
                    }
                });

            }
            binddropdown();


            LoadProduct = function() {
                var URL = '");
#nullable restore
#line 59 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\Product\Index.cshtml"
                      Write(Url.Action("GetProductList", "Product"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
                $('#Product').dataTable({
                    ""processing"": false,
                    ""serverSide"": false,
                    ""bDestroy"": true,
                    ""bJQueryUI"": true,
                    ""pageLength"": 20,
                    ""lengthMenu"": [[10, 20, 50, -1], [10, 20, 50, ""All""]],
                    ""sEmptyTable"": ""Loading data from server"",
                    ""dom"": 'lfrtip',
                    ""ajax"": {
                        'type': 'POST',
                        'url': URL,
                        ""dataSrc"": """"
                    },
                    ""columns"": [
                        {
                            ""render"": function (data, type, row, meta) {
                                return (row[0])
                            }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                return (row[1])
                            }
 ");
                WriteLiteral(@"                       },
                        {
                            ""render"": function (data, type, row, meta) {
                                return (row[2])
                            }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                return (row[3])
                            }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                return (row[4])
                            }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                if (data == ""True"")
                                    return ""<span class='green'>"" + data + ""</span>"";
                                else
                                    return ""<span class='red'>"" + data + ""</span>"";
      ");
                WriteLiteral(@"                      }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                return (row[6])
                            }
                        },
                        {
                            ""visible"": false,
                            ""render"": function (data, type, row, meta) {
                                return (row[7])
                            }
                        },
                        {
                            ""render"": function (data, type, row, meta) {
                                return '<button class=""btn btn-primary"" onclick=""editdata(' + row[0] + ',\'' + row[1] + '\',\'' + row[2] + '\',\'' + row[3] + '\',\'' + row[4] + '\',\'' + row[5] + '\',\'' + row[7] +'\')""  title=""Edit"">Edit</button>' +
                                    '<button class=""btn btn-danger"" title=""Delete""  onclick=""deletedata(' + row[0] + ')"" style=""margin-left: 10px;"">Delet");
                WriteLiteral(@"e</button>';
                            }
                        }
                    ]
                });
            }
            LoadProduct();

          //  $('#Product').DataTable();

            var ddlProduct = $(""#ddlProduct"");

            $(""#btnupdate"").click(function () {

                var fdata = new FormData();
                fdata.append(""Product_ID"", $(""#hdnID"").val());
                fdata.append(""Product_Name"", $(""#txtuppname"").val());
                fdata.append(""Product_Category_ID"", $(""#ddlProduct option:selected"").val());
                fdata.append(""Product_SKU"", $(""#txtupsku"").val());
                fdata.append(""Product_Price"", $(""#txtuppprice"").val());
                fdata.append(""Is_Active"", $(""input[name=RadioOptions]:checked"").val());
                fdata.append(""Product_Description"", $(""#txtupdescription"").val());

                $.ajax({
                    url: '");
#nullable restore
#line 146 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\Product\Index.cshtml"
                     Write(Url.Action("InUpProduct", "Product"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                    type: ""POST"",
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: fdata,
                    success: function (result) {
                        if (result == ""1"") {
                            swal(""Successfully Product Updated!"", """", ""success"", {
                                button: ""Close"",
                            });
                            //clear();
                            LoadProduct();
                            $('#mmd').modal('hide');
                        }
                        else {
                            swal(""Product Not Updated!"", """", ""error"", {
                                button: ""Close"",
                            });
                        }
                    },
                    error: function (err) {
                        alert(err.statusText);
                    }
                });

       ");
                WriteLiteral(@"     });

        });


        function deletedata(ID) {
            debugger;
            bootbox.confirm({
                title: """",
                message: ""Are you sure to delete this record."",
                buttons: {
                    cancel: {
                        label: '<i class=""fa fa-times""></i> Cancel'
                    },
                    confirm: {
                        label: '<i class=""fa fa-check""></i> Confirm'
                    }
                },
                callback: function (result) {
                    if (result == true) {
                        var fdata = new FormData();
                        fdata.append(""ID"", ID);
                        $.ajax({
                        url: '");
#nullable restore
#line 194 "E:\KrishnaJadav\Project\ProductManagement\ProductManagement\Views\Product\Index.cshtml"
                         Write(Url.Action("DeleteProduct", "Product"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                        type: ""POST"",
                        contentType: false, // Not to set any content header
                        processData: false, // Not to process data
                        data: fdata,
                            success: function (response) {
                                if (response == ""1"") {
                                    swal(""Successfully Product Deleted!"", """", ""success"", {
                                        button: ""Close"",
                                    });
                                    LoadProduct();
                                }
                                else {
                                    swal(""Product Not Deleted!"", """", ""error"", {
                                        button: ""Close"",
                                    });
                                }
                            }
                        });
                    }
                }
            });
        }
        function e");
                WriteLiteral(@"ditdata(ID,Name,Cate,SKU,Price,Active,Description)
        {
            $(""#hdnID"").val(ID);
            $('#ddlProduct option').map(function () {
                if ($(this).text() == Cate) return this;
            }).attr('selected', 'selected');

            $(""#txtuppname"").val(Name);
            $(""#txtuppprice"").val(Price);
            $(""#txtupsku"").val(SKU);
            $(""#txtupdescription"").val(Description);



            if (Active == ""True"") { $(""input[name='RadioOptions'][value='True']"").prop('checked', true); } else { $(""input[name='RadioOptions'][value='False']"").prop('checked', true); }
            $(""btnupdate"").val(""Update"");
            $('#mmd').modal();
        }

        function InsertData() {

            $(""#hdnID"").val('0');
            $('#ddlProduct').val(0);

            $(""#txtuppname"").val('');
            $(""#txtuppprice"").val('');
            $(""#txtupsku"").val('');
            $(""#txtupdescription"").val('');
            $(""btnupdate"").val(""Insert");
                WriteLiteral("\");\r\n            $(\'#mmd\').modal();\r\n        }\r\n\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-2"">
        <input type=""submit"" id=""btninsert"" value=""Insert"" onclick=""InsertData()"" class=""btn btn-info"" /><br />
    </div>
</div>

<table id=""Product"" class=""table table-striped table-bordered table-condensed dt-responsive nowrap bhaav-table"" style=""border-collapse: collapse; border-spacing: 0; width: 100%;"">
    <thead>
        <tr>
            <th>Product ID</th>
            <th>Product Name</th>
            <th>Product Category</th>
            <th>Product SKU</th>
            <th>Product Price</th>
            <th>Product Active</th>
            <th>Created Date</th>
            <th style=""display:none"">Description</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody id=""Product_body""></tbody>
</table>

<div id=""mmd"" class=""modal fade"" role=""dialog"">

    <div class=""modal-dialog modal-md"">

        <div class=""modal-content"">

            <div class=""modal-header"">

                <h3>Product Information</h3>");
            WriteLiteral(@"

            </div>


            <div class=""modal-body"">


                <input type=""hidden"" id=""hdnID"" value=""0"" />

                <div class=""form-group"">
                    <select id=""ddlProduct"" class=""select2 form-control"">
                    </select>
                </div>

                <div class=""form-group"">
                    <input type=""text"" id=""txtuppname"" placeholder=""Product Name"" class=""form-control"">
                </div>

                <div class=""form-group"">
                    <input type=""text"" id=""txtuppprice"" placeholder=""Product Price"" class=""form-control"">
                </div>

                <div class=""form-group"">
                    <input type=""text"" id=""txtupsku"" placeholder=""Product SKU"" class=""form-control"">
                </div>
                <div class=""form-group"">
                    <input type=""text"" id=""txtupdescription"" placeholder=""Product Description"" class=""form-control"">
                </div>

              ");
            WriteLiteral(@"  <div class=""form-check form-check-inline"">
                    <input class=""form-check-input RadioStyle"" type=""radio"" name=""RadioOptions"" value=""True"" checked>
                    <label class=""form-check-label"" for=""inlineRadio1"">Yes</label>
                </div>
                <div class=""form-check form-check-inline"">
                    <input class=""form-check-input RadioStyle"" type=""radio"" name=""RadioOptions"" value=""False"">
                    <label class=""form-check-label"" for=""inlineRadio2"">No</label>
                </div>


            </div>

            <div class=""modal-footer"">

                <input type=""submit"" id=""btnupdate"" value=""Update"" class=""btn btn-primary"">

                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>

            </div>


        </div>
    </div>

</div>


");
            DefineSection("FooterFiles", async() => {
                WriteLiteral(@"
    <!-- <script src=""https://code.jquery.com/jquery-3.5.1.js""></script>-->
    <script src=""https://cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js""></script>

    <script src=""https://cdn.datatables.net/buttons/1.7.0/js/dataTables.buttons.min.js""></script>

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.7.0/js/buttons.html5.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/1.7.0/js/buttons.print.min.js""></script>
");
            }
            );
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
