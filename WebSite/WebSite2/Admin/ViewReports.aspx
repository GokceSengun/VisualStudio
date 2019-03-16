<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewReports.aspx.cs" Inherits="Admin_ViewReports" MasterPageFile="~/Admin/Admin.master" %>

<%@ Register Src="~/Usercontrols/Informer.ascx" TagPrefix="uc1" TagName="Informer" %>
<%@ Register Src="~/Usercontrols/UCHeader.ascx" TagPrefix="uc1" TagName="UCHeader" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
   
    <title>Öğrenci Raporları</title>

    <style type="text/css" title="currentStyle">
        @import "../../DataTables-1.9.4/media/css/demo_page.css";
        @import "../../DataTables-1.9.4/media/css/demo_table.css";
    </style>
    <script src="../../Scripts/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="span9">
        <h1 style="float: left; width: 50%;">Öğrenci Raporu
        </h1>
        <fieldset class="form-horizontal" id="reportForm" runat="server" visible="false">
            <uc1:Informer runat="server" ID="Informer" />
            <div class="control-group">
                <label class="control-label">Öğrenci Adı</label>
                <div class="controls">
                    <asp:TextBox ID="txtStudentName" Enabled="false" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Etkinlik Adı</label>
                <div class="controls">
                    <asp:TextBox ID="txtActivityName" Enabled="false" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server"></asp:TextBox>
                </div>
            </div>

             <div class="control-group">
                <label class="control-label">Eğitmen Adı</label>
                <div class="controls">
                    <asp:TextBox ID="txtEducater"  Enabled="false" CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Not</label>
                <div class="controls">
                    <asp:TextBox ID="txtGrade" Enabled="false"  CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Seviye</label>
                <div class="controls">
                    <asp:TextBox ID="txtStage" Enabled="false"  CssClass="input-xlarge" name="exp" ng-model="user.exp" runat="server"></asp:TextBox>
                </div>
            </div>

         
            <div class="control-group">
                <label class="control-label">Rapor</label>
                <div class="controls">
                    <asp:TextBox ID="txtReport" Enabled="false"  name="v" CssClass="input-xlarge publishDate" Rows="5" TextMode="MultiLine" runat="server" required></asp:TextBox>
                </div>
            </div>


            <div class="form-actions">
                <asp:Button ID="btnSave" class="btn btn-primary" OnClick="btnSave_Click" type="submit" runat="server" Text="Onayla" />
            </div>

        </fieldset>


        <div align="center">  
            <input type="text" name="search"  id="search" style="float:right; " class="form-control" />  
        </div>
        <table class="table table-bordered table-striped" id="tstudents">
            <thead>
                <tr>
                    <th>Etkinlik</th>
                    <th>Eğitmen</th>
                    <th>Tarih</th>
                    <th>Rapor</th>
                    <th>Onaylayan</th>
                </tr>
            </thead>
            <tbody class="listItem">
                <asp:Repeater ID="RepetearReports" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Detail.ActivityName") %>  </td>
                            <td><%# Eval("Detail.EducaterName") %></a> </td>
                            <td><%# Eval("Date") %> </td>
                            <td><a href="<%= Page.ResolveUrl(Urls.Admin.Rapors) %>?StudentId=<%# Eval("StudentId") %>&ActivityId=<%# Eval("ActivityId") %>" class="view-link">Görüntüle</a>   </td>
                            <td><%# Eval("ApproverName") %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

 <script>  
      $(document).ready(function(){  
           $('#search').keyup(function(){  
                search_table($(this).val());  
           });  
           function search_table(value){  
                $('#tstudents tr').each(function(){  
                     var found = 'false';  
                     $(this).each(function(){  
                          if($(this).text().toLowerCase().indexOf(value.toLowerCase()) >= 0)  
                          {  
                               found = 'true';  
                          }  
                     });  
                     if(found == 'true')  
                     {  
                          $(this).show();  
                     }  
                     else  
                     {  
                          $(this).hide();  
                     }  
                });  
           }  
      });  
 </script>
</asp:Content>