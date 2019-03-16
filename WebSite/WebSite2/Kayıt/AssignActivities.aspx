<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignActivities.aspx.cs" Inherits="Kayıt_AssignActivities" MasterPageFile="~/Kayıt/Registry.master" %>

<%@ Register Src="~/Usercontrols/Informer.ascx" TagPrefix="uc1" TagName="Informer" %>
<%@ Register Src="~/Usercontrols/UCHeader.ascx" TagPrefix="uc1" TagName="UCHeader" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <title>Kayıt Ekleme ekranı</title>
    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
    <style type="text/css" title="currentStyle">
        @import "../../DataTables-1.9.4/media/css/demo_page.css";
        @import "../../DataTables-1.9.4/media/css/demo_table.css";
    </style>
    <script src="../../Scripts/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="span9">
        <h1 style="float: left; width: 50%;">Etkinlik Ata
        </h1>
        <fieldset class="form-horizontal">
            <uc1:Informer runat="server" ID="Informer" />
            

            <div class="control-group">
                <label class="control-label">Öğrenci Seç</label>
                <div class="controls">
                    <asp:DropDownList ID="drpstudents" name="v" CssClass="input-xlarge publishDate" runat="server" required>
                            
                    </asp:DropDownList>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">Etkinlik Seç</label>
                <div class="controls">
                    <asp:DropDownList ID="drpActivities" name="v" CssClass="input-xlarge publishDate" runat="server" required>
                           
                    </asp:DropDownList>
                </div>
            </div>

            
            <div class="form-actions">
                <asp:Button ID="btnSave" class="btn btn-primary" OnClick="btnSave_Click" type="submit" runat="server" Text="Ata" />
                
            </div>
        </fieldset>
    </div>



</asp:Content>
