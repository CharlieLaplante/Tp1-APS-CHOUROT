<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="Tp1_Aps.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div>
        <table id="TMTable">
            <tr>
                <td>J<asp:ListBox ID="ListBox1" runat="server"></asp:ListBox></td>
                <td>Smith</td>
            </tr>
        </table>
    </div>
</asp:Content>
