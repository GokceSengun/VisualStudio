<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Kayıt_Default" MasterPageFile="~/Kayıt/Registry.master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <title>Kayıt Sayfası</title>

     <style type="text/css" title="currentStyle">
        @import "../../DataTables-1.9.4/media/css/demo_page.css";
        @import "../../DataTables-1.9.4/media/css/demo_table.css";
    </style>

    <script src="../../Scripts/js/bootstrap.min.js"></script>
    <script src="../../DataTables-1.9.4/media/js/jquery.js"></script>
    <script src="../../DataTables-1.9.4/media/js/jquery.dataTables.js"></script>

    <script>
        $(document).ready(function () {

            //fiyat kolonu için sorting 
            jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                "currency-pre": function (a) {
                    a = (a === "-") ? 0 : a.replace(/[^\d\-\.]/g, "");
                    return parseFloat(a);
                },
                "currency-asc": function (a, b) {
                    return a - b;
                },
                "currency-desc": function (a, b) {
                    return b - a;
                }
            });

            jQuery.fn.dataTableExt.oSort['string-asc'] = function (a, b) {
                var x = a.toLowerCase();
                var y = b.toLowerCase();
                return x.localeCompare(y);
            };

            jQuery.fn.dataTableExt.oSort['string-desc'] = function (a, b) {
                var x = a.toLowerCase();
                var y = b.toLowerCase();
                return y.localeCompare(x);
            };

            jQuery.extend(jQuery.fn.dataTableExt.oSort, {
                "date-euro-pre": function (a) {
                    if ($.trim(a) != '') {
                        var frDatea = $.trim(a).split(' ');
                        var frTimea = frDatea[1].split(':');
                        var frDatea2 = frDatea[0].split('.');
                        var x = (frDatea2[2] + frDatea2[1] + frDatea2[0] + frTimea[0] + frTimea[1] + frTimea[2]) * 1;
                    } else {
                        var x = 10000000000000; // = l'an 1000 ...
                    }

                    return x;
                },

                "date-euro-asc": function (a, b) {
                    return a - b;
                },

                "date-euro-desc": function (a, b) {
                    return b - a;
                }
            });

            $('#example').dataTable({
                "sPaginationType": "full_numbers",
                "aoColumns": [
                    { "sType": "string" },
                    null,
                    { "sType": "string" },
                    null,
                ],
                "aaSorting": [[1, "desc"]]
            });


            $("#closeModal").click(function () {
                $("#myModalActive").hide("fast");
                $(".modal-backdrop").hide();
            });
            $('.allItem').click('true', function () {
                if ($(this).attr("checked") == "checked") {

                    $('tbody.listItem tr input[type="checkbox"]').attr('checked', true);
                    $('.activeAll').css('display', 'block');
                    $('.passiveAll').css('display', 'block');
                    $('tbody.listItem tr, tbody.listItem tr td,tbody.listItem tr th').css('background-color', '#ffc');


                }
                else {
                    $('tbody.listItem tr input[type="checkbox"]').attr('checked', false);
                    $('.activeAll').css('display', 'none');
                    $('.passiveAll').css('display', 'none');
                    $('tbody.listItem tr, tbody.listItem tr td,tbody.listItem tr th').css('background-color', '');
                }

            });

            $('tbody.listItem').on('click', 'tr input[type="checkbox"]', function () {
                if ($(this).attr("checked") == "checked") {
                    $(this).parent('th').css('background-color', '#ffc').parent('tr').css('background-color', '#ffc').children('td').css('background-color', '#ffc');
                    $('.activeAll').css('display', 'block');
                    $('.passiveAll').css('display', 'block');
                }
                else {
                    $(this).parent('th').css('background-color', '').parent('tr').css('background-color', '').children('td').css('background-color', '');
                    $('.allItem').attr('checked', false);
                    if ($('tbody.listItem tr input[type="checkbox"]:checked').length < 1) {
                        $('.activeAll').css('display', 'none');
                        $('.passiveAll').css('display', 'none');
                    }
                }
            });


        });

        function restCheck() {
            $('.allItem').attr('checked', false);
            $('.activeAll').css('display', 'none');
            $('.passiveAll').css('display', 'none');
            $('tbody.listItem tr input[type="checkbox"]').attr('checked', false);
            $('tbody.listItem tr, tbody.listItem tr td,tbody.listItem tr th').css('background-color', '');

            $('tbody.listItem tr input[type="checkbox"]').parent('th').css('background-color', '').parent('tr').css('background-color', '').children('td').css('background-color', '');
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="span9">
        <h1>
            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
        </h1>
        <div class="hero-unit">
        </div>
    </div>

</asp:Content>
