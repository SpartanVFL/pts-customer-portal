<%@ Page Title="ViewTickets" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTickets.aspx.cs" Inherits="WebApplication3.ViewTickets" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <main class="container">

            <div class="row" style="padding-top: 5rem;">
                


                <!-- Left Container -->
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-top: 3rem; padding-bottom: 5rem;">
                        <div class="panel-group">
                            <div class="panel panel-default">

                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                       
                                        <a data-toggle="collapse" href="#collapse1">Open Tickets</a>
                                    </h4>
                                </div>

                            <div id="collapse1" class="panel-collapse collapse">
                              <ul class="list-group" id="uListOpen" runat="server">      
                                                                                
                                <asp:Repeater runat="server" ID="ListRepeater">
                                   <ItemTemplate>
                                           <li class="list-group-item" style="padding-right: 0 !important;"> 

                                               <%# Container.DataItem %>
                                                <asp:Button ID="btnCloseSupportTicket" type="submit" runat="server" class="btn btn-default" Text="Close" style="float: right;" CausesValidation="False" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btnCloseSupportTicket_Click"  /></li>
                                                                          
                                   </ItemTemplate>
                                </asp:Repeater>

                              </ul>
                              <div class="panel-footer">Active Tickets: <asp:Label runat="server" ID="lblActiveCount" text="" /></div>
                            </div>

                          </div>
                        </div>
                    </div>
                <!-- End Left Container -->
                </div>  

                <!-- Right Container -->
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6"  style="padding-top: 3rem; padding-bottom: 5rem;">

                    

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <div class="panel-group">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" href="#collapse2">Closed Tickets</a>
                                    </h4>
                                </div>
                            <div id="collapse2" class="panel-collapse collapse">
                              <ul class="list-group">
                                <asp:Repeater runat="server" ID="Repeater2">
                                   <ItemTemplate>
                                       <li class="list-group-item" style="padding-right: 0 !important;">
                                           <%# Container.DataItem %>
                                           <asp:Button runat="server" Text="Reopen" class="btn btn-default" style="float: right;"/>

                                       </li>
                                   </ItemTemplate>
                                </asp:Repeater>
                              </ul>
                              <div class="panel-footer">Closed Tickets: <asp:Label runat="server" ID="lblClosedCount" text="" /> </div>
                            </div>
                          </div>
                        </div>
                    </div>
                <!-- End of Right Container -->     
                </div>                                             
            </div>
        </main>

        


</asp:Content>

