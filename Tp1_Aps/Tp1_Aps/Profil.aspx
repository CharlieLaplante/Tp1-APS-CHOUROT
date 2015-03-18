<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="Tp1_Aps.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">

	<div>
		<table>
			<tr>
				<td>
					<table>
						<tr>
							<td>
								<label for="TB_FullName" class='label'>Nom Complet:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_FullName" name="TB_FullName" runat="server" CssClass="textbox"
									onkeyup="ConstrainToAlpha(event);"> </asp:TextBox>

							</td>
						</tr>
						<tr>
							<td>
								<label for="TB_UserName" class='label'>Nom d'Utilisateur:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_UserName" ReadOnly="true" name="TB_UserName" runat="server" CssClass="textbox"
									onkeyup="ConstrainToAlpha(event);"> </asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								<label for="TB_Password" class='label'>Password:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Password" name="TB_Password" runat="server" CssClass="textbox" TextMode="Password" ></asp:TextBox>
							</td>
						</tr>
                        	<tr>
							<td>
								<label for="TB_Password_Confirm" class='label'>Confirmer mot de passe:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Password_Confirm" name="TB_Password_Confirm" runat="server" CssClass="textbox" TextMode="Password" ></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								<label for="TB_Email" class='label'>Email:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Email" name="TB_Email" runat="server" CssClass="textbox"></asp:TextBox>
							</td>
						</tr>
                        <tr>
							<td>
								<label for="TB_Email_Confirm" class='label'>Confirmer l'email:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Email_Confirm" name="TB_Email_Confirm" runat="server" CssClass="textbox"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
							<td>
								<asp:Button ID="BTN_Update" runat="server" Text="Update" class="submitBTN"
									OnClick="BTN_Update_Click" ValidationGroup="PersonneInfo" />
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
							<td>
								<asp:Button ID="BTN_Cancel" runat="server" Text="Cancel" class="submitBTN" OnClick="BTN_Cancel_Click" />
							</td>
						</tr>
					</table>
				</td>
				<td id="AvatarSection">
					<asp:Image ID="IMG_Avatar" runat="server" ClientIDMode="Static" CssClass="thumbnail" ImageUrl="~/Images/Anonymous.png" />
					<hr />
					<asp:FileUpload ID="FU_Avatar" runat="server" ClientIDMode="Static" onchange="PreLoadImage();" />
				</td>
			</tr>
			<tr>
				<td colspan="2" style="text-align: left; font-size: 12px;">
					<asp:ValidationSummary ID="ValidationSummary1"
						HeaderText="Les champs suivants sont vides ou syntaxiquement erronés:"
						DisplayMode="BulletList"
						EnableClientScript="true"
						runat="server" ValidationGroup="PersonneInfo" />
				</td>
			</tr>
		
		</table>
	</div>

    <asp:CustomValidator ID="CV_Password_Confirm" runat="server"
		ControlToValidate="TB_Password_Confirm"
		ErrorMessage="Confirmation Mot de passe" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_Password_Confirm_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">
     </asp:CustomValidator>

    <asp:CustomValidator ID="CV_Email_Confirm" runat="server"
		ControlToValidate="TB_Email_Confirm"
		ErrorMessage="Confirmation d'email" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_Email_Confirm_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">
     </asp:CustomValidator>

	<asp:CustomValidator ID="CV_FullName" runat="server"
		ControlToValidate="TB_FullName"
		ErrorMessage="Nom" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_FullName_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">  
	</asp:CustomValidator>
		
	<asp:CustomValidator ID="CV_Password" runat="server"
		ControlToValidate="TB_Password"
		ErrorMessage="Password" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_Password_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">  
	</asp:CustomValidator>
		
	<asp:CustomValidator ID="CV_Email" runat="server"
		ControlToValidate="TB_Email"
		ErrorMessage="Email" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_Email_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">  
	</asp:CustomValidator>
</asp:Content>
