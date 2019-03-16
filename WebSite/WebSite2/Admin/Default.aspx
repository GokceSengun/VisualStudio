<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" MasterPageFile="~/Admin/Admin.master" %>

<%@ Register Src="~/Usercontrols/Informer.ascx" TagPrefix="uc1" TagName="Informer" %>




<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadPlaceHolder" runat="server">
    <title>Admin Sayfası</title>

    <style type="text/css" title="currentStyle">
        @import "../../DataTables-1.9.4/media/css/demo_page.css";
        @import "../../DataTables-1.9.4/media/css/demo_table.css";
    @import "../../media/css/jquery.dataTables.css";
    </style>

    <script src="../../Scripts/js/bootstrap.min.js"></script>
    <script src="../../DataTables-1.9.4/media/js/jquery.js"></script>
    <script src="../../DataTables-1.9.4/media/js/jquery.dataTables.js"></script>
    <script src="../../media/js/jquery.js"></script>
    <script src="../../media/js/jquery.dataTables.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.0/jquery.min.js"></script>    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>  

    <script>

        $(document).ready(function(){  
           $('#search').keyup(function(){  
                search_table($(this).val());  
           });  
           function search_table(value){  
                $('#tEvents tr').each(function(){  
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
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainPlaceHolder" runat="server">

    <div class="span9">

        <div style="margin-top: 25px;">
            <uc1:Informer runat="server" ID="Informer" />
        </div>

        <h1 style="float: left; width: 50%;">Etkinlikler</h1>

         
        <div align="center">  
            <input type="text" name="search" id="search" style="float:right" class="form-control" />  
        </div>  

        <table class="table table-bordered" id="tEvents">
            <thead>
                <tr>
                    <th>Adı</th>
                    <th>Süresi</th>
                    <th>İçeriği</th>
                    <th>Yaş Kategorisi</th>
                    <th>Seviye</th>
                    <th>Sınıf</th>
                    <th>Eğitmen</th>
                    <th>Detay</th>
                    <th>Sil</th>
                </tr>
            </thead>
            <tbody class="listItem">
                <asp:Repeater ID="RepetearEvents" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td><%# Eval("Name") %> </td>
                            <td><%# Eval("Duration") %> </td>
                            <td><%# Eval("Contents") %> </td>
                            <td><%# Eval("ClassifyByAge") %> </td>
                            <td><%# Eval("ClassifyByStage") %> </td>
                            <td><%# Eval("ClassName") %> </td>
                            <td><%# Eval("EducaterName") %> </td>
                            <td><a href="<%= Page.ResolveUrl(Urls.Admin.ActivityDetail) %>?Id=<%# Eval("Id") %>" class="view-link">Görüntüle</a>   </td>
                            <td><a href="<%= Page.ResolveUrl(Urls.Admin.MainPage) %>?Action=DeleteEvent&Id=<%# Eval("Id") %>" class="view-link">Sil</a>   </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <h1 style="float: left; width: 50%;">Öğrenciler</h1>
        <table class="table table-bordered table-striped" id="tstudents">
            <thead>
                <tr>
                    <th>Ad Soyad</th>
                    <th>Mail</th>
                    <th>Telefon</th>
                    <th>Detay</th>
                    <th>Sil</th>
                </tr>
            </thead>
            <tbody class="listItem">
                <asp:Repeater ID="RepaterStudents" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td><%# Eval("Name") %> <%# Eval("Surname") %></td>
                            <td><a href="mailto: <%# Eval("Mail") %>"><%# Eval("Mail") %></a> </td>
                            <td><%# Eval("Phone") %> </td>
                            <td><a href="<%= Page.ResolveUrl(Urls.Admin.StudentDetail) %>?Id=<%# Eval("Id") %>" class="view-link">Görüntüle</a>   </td>
                            <td><a href="<%= Page.ResolveUrl(Urls.Admin.MainPage) %>?Action=DeleteStudent&Id=<%# Eval("Id") %>" class="view-link">Sil</a>   </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>



    </div>




    <!-- MODAL-->
    <div class="modal fade" id="myModalActive" tabindex="-1" role="dialog" aria-labelledby="myModalLabelActive" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabelActive">Seçili olan öğrenciler kalıcı olarak silinecek. Onaylıyor musnuz?</h4>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" class="btn btn-primary" data-dismiss="modal" runat="server" Text="Evet" />
                    <button type="button" class="btn btn-default" id="closeModal" data-dismiss="modal">Hayır</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="myModalPassive" tabindex="-1" role="dialog" aria-labelledby="myModalLabelPassive" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabelPassive">Onaylansın mı ?</h4>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onclick="isActivePassive('false');" data-dismiss="modal">Evet</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Hayır</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
