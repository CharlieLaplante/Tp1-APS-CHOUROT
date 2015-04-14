<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="Tp1_Aps.Inscription" %>

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
								<asp:TextBox ID="TB_FullName" name="TB_FullName" runat="server" CssClass="
                                    "
									onkeyup="ConstrainToAlpha(event);"> </asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								<label for="TB_UserName" class='label'>Nom d'Utilisateur:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_UserName" name="TB_UserName" runat="server" CssClass="textbox"
									onkeyup="ConstrainToAlpha(event);"> </asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								<label for="TB_Password" class='label'>Password:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Password" name="TB_Password" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
							</td>
						</tr>
                        	<tr>
							<td>
								<label for="TB_Password" class='label'>Confirmation de mot de passe:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Password_Confirm" name="TB_Password" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
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
								<label for="TB_Email" class='label'>Confirmation d'email:</label>
							</td>
							<td>
								<asp:TextBox ID="TB_Email_Confirm" name="TB_Email" runat="server" CssClass="textbox"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
							<td>
								<asp:Button ID="BTN_Add" runat="server" Text="Add" class="submitBTN"
									OnClick="BTN_Add_Click" ValidationGroup="PersonneInfo" />
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
				<td>
					<div>
						<table>
							<tr>
								<td colspan="2">
									<asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
										<ContentTemplate>
											<table>
												<tr>
													<td>
														<asp:ImageButton ID="RegenarateCaptcha" runat="server"
															ImageUrl="~/Images/RegenerateCaptcha.png"
															CausesValidation="False"
															OnClick="RegenarateCaptcha_Click"
															ValidationGroup="Subscribe_Validation"
															Width="48"
															ToolTip="Regénérer le captcha..." />
													</td>
													<td>
														<asp:Image ID="IMGCaptcha" ImageUrl="~/captcha.png" runat="server" />
													</td>
												</tr>
											</table>
										</ContentTemplate>
									</asp:UpdatePanel>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>
									<asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5"></asp:TextBox>
								</td>
							</tr>
						</table>
					</div>
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
    <asp:CustomValidator ID="CB_Email_Confirm" runat="server"
		ControlToValidate="TB_Email_Confirm"
		ErrorMessage="Email Confirmer" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_Email_Confirm_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">  
	</asp:CustomValidator>
    <asp:CustomValidator ID="CV_Password_Confirm" runat="server"
		ControlToValidate="TB_Password_Confirm"
		ErrorMessage="Password Confirmer" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_Password_Confirm_ServerValidate"
		ValidationGroup="PersonneInfo"
		ValidateEmptyText="True" Display="None">  
	</asp:CustomValidator>
	<asp:CustomValidator ID="CV_Captcha" runat="server"
		ControlToValidate="TB_Captcha"
		ErrorMessage="Captcha" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_Captcha_ServerValidate"
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
	<asp:CustomValidator ID="CV_UserName" runat="server"
		ControlToValidate="TB_UserName"
		ErrorMessage="Nom d'utilisateur" Text=""
		EnableClientScript="true"
		OnServerValidate="CV_TB_UserName_ServerValidate"
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
