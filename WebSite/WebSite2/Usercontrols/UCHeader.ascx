<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCHeader.ascx.cs" Inherits="UCHeader" %>
<div class="navbar">
    <div class="navbar-inner">
        <div class="container">
            <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></a><a class="brand" href="#">Logo</a>
            <div class="nav-collapse">
                <ul class="nav pull-right">
                    <li>
                        <a href="#">
                            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></a>
                    </li>
                    <li>
                        <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_ServerClick">Çıkış</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
