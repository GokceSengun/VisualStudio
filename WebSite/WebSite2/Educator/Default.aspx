<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Educator_Default" MasterPageFile="~/Educator/Educator.master" %>

<%@ Register Src="~/Usercontrols/Informer.ascx" TagPrefix="uc1" TagName="Informer" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <title>Eğitmen Sayfası</title>
</asp:Content>
 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>    
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> 
    <div class="span9">
        <div style="margin-top: 25px;">
            <uc1:informer runat="server" id="Informer" />
        </div>
        <h1 style="float: left; width: 50%;">Öğrenciler</h1>
        
        <div align="center">  
            <input type="text" name="search" id="search" style="float:right" class="form-control  " />  
        </div>  
        <table class="table table-bordered table-striped" id="tstudents">
            <thead>
                <tr>
                    <th>Ad Soyad</th>
                    <th>Mail</th>
                    <th>Etkinlik</th>
                    <th>Rapor</th>
                </tr>
            </thead>
            <tbody class="listItem">
                <asp:Repeater ID="RepaterStudents" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Name") %> <%# Eval("Surname") %></td>
                            <td><a href="mailto: <%# Eval("Mail") %>"><%# Eval("Mail") %></a> </td>
                            <td><%# Eval("ActivityName") %> </td>
                            <td><a href="<%= Page.ResolveUrl(Urls.Educator.Report) %>?StudentId=<%# Eval("Id") %> &ActivityId=<%# Eval("ActivityId") %>"  class="view-link">Yaz</a>   </td>
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

