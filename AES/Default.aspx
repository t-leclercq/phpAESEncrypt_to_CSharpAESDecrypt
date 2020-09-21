<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AES._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>PHP => C# | AES Chiffrage/Déchiffrage</h2>
        <br />
        <p class="lead" runat="server">Voici le code provenant de la page PHP, déchiffré par la page C# :</p>
        <p><strong><asp:Label ID="CodeDechiffre" runat="server"></asp:Label></strong></p>
    </div>

</asp:Content>
