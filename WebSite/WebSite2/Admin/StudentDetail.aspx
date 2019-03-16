<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDetail.aspx.cs" Inherits="StudentDetail" MasterPageFile="~/Admin/Admin.master" %>

<%@ Register Src="~/Usercontrols/UCHeader.ascx" TagPrefix="uc1" TagName="UCHeader" %>
<%@ Register Src="~/Usercontrols/Informer.ascx" TagPrefix="uc1" TagName="Informer" %>






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
        <h1 style="float: left; width: 50%;">Öğrenci Detayı
        </h1>
        <fieldset class="form-horizontal">
            <uc1:Informer runat="server" ID="Informer" />

            <div class="control-group">
                <label class="control-label">Id</label>
                <div class="controls">
                    <asp:TextBox ID="txtId" CssClass="input-xlarge" Enabled="false" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>
            
            <div class="control-group">
                <label class="control-label">Öğrenci Adı</label>
                <div class="controls">
                    <asp:TextBox ID="txtStudentName" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Öğrenci Soyadı</label>
                <div class="controls">
                    <asp:TextBox ID="txtStudentSurname" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Veli Adı</label>
                <div class="controls">
                    <asp:TextBox ID="txtParentName" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Yaşı</label>
                <div class="controls">
                    <asp:TextBox ID="txtAge" onkeypress="return isNumberKey(event)" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Telefon Numarası</label>
                <div class="controls">
                    <asp:TextBox ID="txtPhone" name="v" onkeypress="return isNumberKey(event)" CssClass="input-xlarge publishDate" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">E-Mail</label>
                <div class="controls">
                    <asp:TextBox ID="txtEmail" name="v" CssClass="input-xlarge publishDate" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Adres</label>
                <div class="controls">
                    <asp:TextBox ID="txtAddress" name="v" CssClass="input-xlarge publishDate" Rows="3" TextMode="MultiLine" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Ödeme Şekli</label>
                <div class="controls">
                    <asp:DropDownList ID="txtPaymentType" name="v" CssClass="input-xlarge publishDate" runat="server" required>
                        <asp:ListItem Value="1">Nakit</asp:ListItem>
                        <asp:ListItem Value="2">Kredi Kartı</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Ücret</label>
                <div class="controls">
                    <asp:TextBox ID="txtAmount" name="v" CssClass="input-xlarge publishDate" runat="server" required></asp:TextBox>
                </div>
            </div>


             <div class="control-group">
                <label class="control-label">Atanan Etkinlikler</label>
                <div class="controls">
                    <asp:DropDownList ID="drpActivities" name="v" CssClass="input-xlarge publishDate" runat="server" >
                    </asp:DropDownList>

                <asp:Button ID="btnDeleteActivity" CssClass="btn"  style="margin-left:15px" OnClick="btnDeleteActivity_Click" type="submit" runat="server" Text="Seçili Etkinlik Sil" />

                </div>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnSave" class="btn btn-primary" OnClick="btnSave_Click" type="submit" runat="server" Text="Güncelle" />
            </div>
        </fieldset>
    </div>



</asp:Content>
