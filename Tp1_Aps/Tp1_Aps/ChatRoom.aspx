<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="Tp1_Aps.ChatRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="FormStyles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">

<asp:Timer ID="Timer1" runat="server" Interval="3000" ontick="Timer1_Tick"></asp:Timer>
     <asp:UpdatePanel ID="UpdatePanel1" class="Tableau" runat="server" UpdateMode="Conditional"> 
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID ="Timer1" EventName ="Tick"/>
         </Triggers>           
         <ContentTemplate>
        <table>    
            <tr>
                <td>
                    <asp:Panel id="PN_ListeChat" class="Tableau" runat="server" style="overflow-x : auto; overflow-y: auto; height: 300px; width: 100%;"></asp:Panel>
                </td>
                <td>
                    <asp:Panel id="PN_ListeMessage" class="Tableau" runat="server" style="overflow-x : auto; overflow-y: auto; height: 300px; width: 100%;"></asp:Panel>
                </td>
			     <td>
                     <asp:Panel id="PN_ListeUser" class="Tableau" runat="server" style="overflow-x : auto; overflow-y: auto; height: 300px; width: 100%;"></asp:Panel>				   
                </td> 
            </tr>                
        </table>

         </ContentTemplate>
    </asp:UpdatePanel>    
        <table>               
        <tr>       
         <td>
             <asp:Button ID="BTN_Return" runat="server" Text="Retour..." class="submitBTN" OnClick="BTN_Return_Click" />
         </td>
         <td>
             <asp:TextBox ID="TB_ChatBox" name="TB_ChatBox" runat="server" CssClass="ChatBox" TextMode="Multiline"></asp:TextBox>
         </td>
         <td>
             <asp:Button ID="BTN_Envoyez" runat="server" Text="Envoyez..." class="submitBTN" OnClick="BTN_Envoyez_Click" />
         </td>
        </tr>
        </table>
   

</asp:Content>
