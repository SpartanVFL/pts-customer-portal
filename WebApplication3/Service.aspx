<%@ Page Title="Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="WebApplication3.Service" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <main class="container">

            <div class="row" style="padding-top: 5rem;">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <h2>Submit a ticket...</h2>
                </div>
            </div>

            <div class="row">       
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6" style="padding-top: 3rem; padding-bottom: 5rem;">
                    <label>Title</label>
                    <asp:TextBox ID="txtSupportTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSupportTitle" Display="Dynamic" ErrorMessage="Title is required" CssClass="text-danger" SetFocusOnError="False"></asp:RequiredFieldValidator>
                    <br />
                    <label>Description</label>
                    <asp:Textbox ID="txtSupportDescr" runat="server" CssClass="form-control"></asp:Textbox>
                    <br />
                    <asp:Button runat="server" type="submit" Text="Submit" class="btn btn-default" OnClick="btnSubmitSupport_Click" />
                    <br />               
                </div>

                <%-- Result Label --%>
                <div class="form-group" style="padding-top:2rem;">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="float: left;">
                        <asp:Label ID="lblResult" runat="server" Text="Label" CssClass="text-danger" ForeColor="Green" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">

                </div>
            </div>
        </main>

        


</asp:Content>
