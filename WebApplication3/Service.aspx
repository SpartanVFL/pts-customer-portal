<%@ Page Title="Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="WebApplication3.Service" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <main class="container">

            < class="row" style="padding-top: 5rem;">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-left: 3rem; padding-top: 5rem;">
                    <h2>Submit a ticket...</h2>
                </div>


                <!-- Left Container -->
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        
                        <div class="form-group" id="showConfirmation" runat="server" style="padding-bottom: 1rem; padding-top: 3rem; padding-left: 0 !important; display: none;">
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-left: 0 !important;">
                                <asp:Label ID="lblResult" runat="server" Text="Label" CssClass="text-danger" ForeColor="Green" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>


                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-top: 3rem; padding-bottom: 5rem;">
                        <label>Title</label>
                        <asp:TextBox ID="txtSupportTitle" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSupportTitle" Display="Dynamic" ErrorMessage="Title is required" CssClass="text-danger" SetFocusOnError="False"></asp:RequiredFieldValidator>
                        <br />
                        <label>Description</label>
                        <asp:Textbox ID="txtSupportDescr" runat="server" CssClass="form-control textbox-adjust" TextMode="Multiline" style="height: 150px !important; width: 350px !important;" />
                        <br />
                        <asp:Button runat="server" type="submit" Text="Submit" class="btn btn-default" OnClick="btnSubmitSupport_Click" />
                        <br />               
                    </div>
                    </div> 
                <!-- End Left Container -->
                  

                <!-- Right Container -->
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                       

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        
                    </div>
                        </div>
                    </div>
                <!-- End of Right Container -->     
               
        </main>

        


</asp:Content>
