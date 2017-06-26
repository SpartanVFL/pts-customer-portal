<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


<div class="container content">
    <div class="row" style="padding-top: 5rem;">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <h2>You are currently not logged in...</h2>
        </div>
    </div>

    <div class="row" style="padding-top: 3rem; padding-bottom: 5rem;">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="form-group">
                <label for="email">Email address:</label>
                <asp:Textbox runat="server" class="form-control" id="email"/>
            </div>
            <div class="form-group">
                <label for="pwd">Password:</label>
                <asp:Textbox runat="server" class="form-control" type="password" id="pwd"/>
            </div>
            <asp:Button runat="server" id="button1" type="submit" Text="Submit" class="btn btn-default" onclick="ValidationClick"></asp:Button>
            <br />
            <br />
            <asp:Label runat="server" id="user1" text=""/>
            <br />
            <div style="color: red;">
            <asp:Label runat="server" id="pass1" text=""/>
                </div>
        </div>
    </div>
</div>
</asp:Content>
