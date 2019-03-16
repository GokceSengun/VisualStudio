<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEvent.aspx.cs" Inherits="Admin_AddEvent" MasterPageFile="~/Admin/Admin.master" %>

<%@ Register Src="~/Usercontrols/Informer.ascx" TagPrefix="uc1" TagName="Informer" %>
<%@ Register Src="~/Usercontrols/UCHeader.ascx" TagPrefix="uc1" TagName="UCHeader" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <title>Etkinlik Ekleme ekranı</title>

    <style type="text/css" title="currentStyle">
        @import "../../DataTables-1.9.4/media/css/demo_page.css";
        @import "../../DataTables-1.9.4/media/css/demo_table.css";
    </style>
    <script src="../../Scripts/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="span9">
        <h1 style="float: left; width: 50%;">Etkinlik Ekle
        </h1>
        <fieldset class="form-horizontal">
            <uc1:Informer runat="server" ID="Informer" />
            <div class="control-group">
                <label class="control-label">Etkinlik İsmi</label>
                <div class="controls">
                    <asp:TextBox ID="txtEventName" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Etkinlik Süresi</label>
                <div class="controls">
                    <asp:TextBox ID="txtEventDuration" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server" required></asp:TextBox>
                </div>
            </div>


            <div class="control-group">
                <label class="control-label">Yaş Aralığı</label>
                <div class="controls">
                    <asp:TextBox ID="txtEventClassifyByAge" name="v" CssClass="input-xlarge publishDate" runat="server" ></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Seviye</label>
                <div class="controls">
                    <asp:TextBox ID="txtEventClassifyByStage" name="v" CssClass="input-xlarge publishDate" runat="server" ></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Sınıf</label>
                <div class="controls">
                    <asp:DropDownList ID="drpClasses" name="v" CssClass="input-xlarge" runat="server" required></asp:DropDownList>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Eğitmen</label>
                <div class="controls">
                    <asp:DropDownList ID="drpEducater" name="v" CssClass="input-xlarge" runat="server" required></asp:DropDownList>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Etkinlik İçeriği</label>
                <div class="controls">
                    <asp:TextBox ID="txtEventContent" CssClass="input-xlarge" name="exp" ng-model="user.exp" Rows="4" TextMode="MultiLine" runat="server" required></asp:TextBox>
                </div>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnSave" class="btn btn-primary" OnClick="btnSave_Click" type="submit" runat="server" Text="Oluştur" />
                <button class="btn" id="btnCancel">İptal</button>
            </div>
        </fieldset>
    </div>



</asp:Content>
