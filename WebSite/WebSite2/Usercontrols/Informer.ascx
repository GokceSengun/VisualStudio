<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Informer.ascx.cs" Inherits="Scop.UserControls.Informer" %>
<div class="alert alert-error" id="infoError" runat="server">
    <a href="#" class="close" data-dismiss="alert">&times;</a>
    <strong>Hata !</strong>
    <label style="display: inline" id="lblinfoError" runat="server">A problem has been occurred while submitting your data.</label>
</div>
<div class="alert alert-success" id="infoSuccess" runat="server">
    <a href="#" class="close" data-dismiss="alert">&times;</a>
    <strong>Başarılı!</strong>
    <label style="display: inline" id="lblinfoSuccess" runat="server">Your message has been sent successfully.</label>
</div>
<div class="alert alert-warning" id="infoWarning" runat="server">
    <a href="#" class="close" data-dismiss="alert">&times;</a>
    <strong>Uyarı!</strong>
    <label style="display: inline" id="lblinfoWarning" runat="server">Your message has been sent successfully.</label>
</div>
