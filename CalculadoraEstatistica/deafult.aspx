<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="deafult.aspx.cs" Inherits="CalculadoraEstatistica.deafult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- importando bootstrap cs -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

      <style>
        body {
            background-color: #343a40;
            color: #f8f9fa;
        }
        .form-control, .btn {
            margin-bottom: 15px;
        }
        .container {
            margin-top: 50px;
        }
    </style>


    <div class="container">
        <h2 class="text-center">Calculadora de Estatística</h2>
        
        <div class="form-group">
            <label for="numero">Digite um número:</label>
            <asp:TextBox ID="numero" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <asp:Button ID="enviar" OnClick="enviar_Click" CssClass="btn btn-primary" runat="server" Text="Adicionar Número" />
            <asp:Button ID="limpar" OnClick="limpar_Click" CssClass="btn btn-danger" runat="server" Text="Limpar Números" />
            <asp:Button ID="calcular" OnClick="calcular_Click" CssClass="btn btn-success" runat="server" Text="Calcular" />
        </div>
        
        <div class="mt-4">
            <h4>Números Incluídos:</h4>
            <asp:Label ID="exibir" CssClass="form-control bg-dark text-white" runat="server" Text="Nenhum número adicionado"></asp:Label>
        </div>
        
        <div class="mt-4">
            <h4>Resultados:</h4>
            <div class="form-group">
                <label for="media">Média:</label>
                <asp:Label ID="media" CssClass="form-control bg-dark text-white" runat="server" Text="-"></asp:Label>
            </div>
            <div class="form-group">
                <label for="mediana">Mediana:</label>
                <asp:Label ID="mediana" CssClass="form-control bg-dark text-white" runat="server" Text="-"></asp:Label>
            </div>
            <div class="form-group">
                <label for="moda">Moda:</label>
                <asp:Label ID="moda" CssClass="form-control bg-dark text-white" runat="server" Text="-"></asp:Label>
            </div>
        </div>
    </div>

     <!-- importando Bootstrap JS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</asp:Content>
