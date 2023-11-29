#Region "Imports"
'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Machine
Imports iNovation.Code.Sequel
Imports iNovation.Code.Desktop
Imports iNovation.iNCode.InternalTypes
#End Region
Public Class Startup

#Region "support"
    Function ConstructConnectionString() As String

        Return "Data Source="" & Environment.MachineName & ""\SQLEXPRESS;Initial Catalog="" & Environment.GetEnvironmentVariable(InitialCatalogVariableName, EnvironmentVariableTarget.User) & "";Persist Security Info=True;User ID="" & Environment.GetEnvironmentVariable(UserIdVariableName, EnvironmentVariableTarget.User) & "";Password="" & Environment.GetEnvironmentVariable(PasswordVariableName, EnvironmentVariableTarget.User)"
        'Return "Data Source=" & Environment.MachineName & "\SQLEXPRESS;Initial Catalog=" & Environment.GetEnvironmentVariable(InitialCatalogVariableName, EnvironmentVariableTarget.User) & ";Persist Security Info=True;User ID=" & Environment.GetEnvironmentVariable(UsernameVariableName, EnvironmentVariableTarget.User) & ";Password=" & Environment.GetEnvironmentVariable(PasswordVariableName, EnvironmentVariableTarget.User)
    End Function

    Function DataTypeFromColumnName(tableDetails As Dictionary(Of String, String), columnName As String) As String
        Return tableDetails.Item(columnName).Replace("Byte[]", "Byte()")
    End Function
#End Region

#Region "Other Members"
    Public Enum OperationList
        HTTP_js = 1
        NewFile_dll = 2
        'NewInternal_dll = 3
        ProfileData_sql = 4
        Profiles_sql = 5
        Validation_Before_Add_vb = 6
        Validation_Before_Register_vb = 7
    End Enum
    Public Enum Web
        Authentication = 1
        ConnectionSrings = 2
        CustomErrors = 3
        Filter = 4
        httpCookies = 5
        Profile = 6
        Rewrite = 7
        Trace = 8
    End Enum
    Public Enum Code
        Activated_Load = 1
        Database = 2
        Forgot_SendResetEmail = 3
        ImageHandler = 4
        Load = 5
        Load_Anonymous = 6
        Load_Mobile = 7
        Login = 8
        Login_Load = 9
        Login_Profile = 10
        Logout_Profile = 11
        PageIndexChanging = 12
        Reset_Load = 13
        Reset_UpdatePassword = 14
        Shop_Pre_Load = 15
        Web_Anonymous = 16
        Welcome_ActivateAccount_Load = 17
        Welcome_ActivateAccount_Resend_Link = 18

        '5, 6
    End Enum
    Public Enum Site
        SupportFunctions = 1
        Internal = 2
        Load = 3
        LogOut = 4
        PreRender = 5
        Title = 6
    End Enum
    Public Enum Materialize
        Activated_HTML = 1
        CustomErrorHTML = 2
        DeclareCSS = 3
        DeclareJS = 4
        Forgot_HTML = 5
        Header = 6
        Header_NoLogin = 7
        Header_Shop = 8
        InputGroup = 9
        Main = 10
        NewHTML = 11
        NewPage = 12
        Privacy = 13
        TermsAndConditions = 14
        Welcome_ActivateAccount_HTML = 15
        Footer = 16
        '		Header_Shop_Admin
    End Enum
    Public Enum Bootstrap
        Activated_HTML = 1
        CustomErrorHTML = 2
        DeclareCSS = 3
        DeclareJS = 4
        Forgot_HTML = 5
        Header = 6
        Header_NoLogin = 7
        Header_Shop = 8
        InputGroup = 9
        Main = 10
        NewHTML = 11
        NewPage = 12
        Privacy = 13
        TermsAndConditions = 14
        Welcome_ActivateAccount_HTML = 15
        '		Header_Shop_Admin
    End Enum

    Public Enum EStore
        Contact = 1
        DeclareCSS = 2
        DeclareJS = 3
        Default_ = 4
        Footer = 5
        Header = 6
        Login = 7
        Main = 8
        NewHTML = 9
        Preloader = 10
        Privacy = 11
        TermsAndConditions = 12
    End Enum

    Public Enum Shoppy
        DeclareCSS = 1
        DeclareJS = 2

    End Enum
#End Region

#Region "Types"

#End Region

#Region "Fields"
    Private fields__ As Array
    Public Property css_framework__ As Snippets.CSSFramework = Snippets.CSSFramework.Materialize

    Public ReadOnly Property OperationList_List As List(Of String) = GetEnum(New OperationList)
    Public ReadOnly Property Web_List As List(Of String) = GetEnum(New Web)
    Public ReadOnly Property Site_List As List(Of String) = GetEnum(New Site)
    Public ReadOnly Materialize_List As List(Of String) = GetEnum(New Materialize)
    Public ReadOnly Bootstrap_List As List(Of String) = GetEnum(New Bootstrap)
    Public ReadOnly Shoppy_List As List(Of String) = GetEnum(New Shoppy)
    Public ReadOnly Code_List As List(Of String) = GetEnum(New Code)
    Public ReadOnly EStore_List As List(Of String) = GetEnum(New EStore)
#End Region

#Region "New"
    Public Sub New(Optional fields_ As Array = Nothing, Optional css_framework As Snippets.CSSFramework = Snippets.CSSFramework.Materialize)
        fields__ = fields_
        css_framework__ = css_framework
    End Sub

#End Region

#Region "Main"
    Public Function Forgot_HTML()
        Dim result As String = ""
        Select Case css_framework__
            Case Snippets.CSSFramework.Bootstrap
            Case Snippets.CSSFramework.Materialize
                result = Forgot_HTML_Materialize()
            Case Snippets.CSSFramework.Shoppy
        End Select
        Return result
    End Function
    'Public Function NewFile(programming_language As Snippets.ProgrammingLanguage, table__ As String, update_key__ As String)
    '	Select Case programming_language
    '		Case Snippets.ProgrammingLanguage.CS
    '		Case Snippets.ProgrammingLanguage.VB
    '			Return NewFile_VB(table__, update_key__)
    '	End Select
    'End Function
    Public Function ProfileData()
        Dim r As String = "CREATE TABLE [database_here].[dbo].[ProfileData](
					ProfileID Int," & vbCrLf
        If fields__ IsNot Nothing Then
            For i = 0 To fields__.Length - 1
                r &= "[" & fields__(i) & "] [nvarchar](max) NULL," & vbCrLf
            Next
        End If


        r &= vbCrLf & "		NumberOfVisits Int 
				)"

        r &= vbCrLf & " [datetime] NULL,"
        r &= vbCrLf & " [bit] NULL,"
        r &= vbCrLf & " [nvarchar](255) NULL,"
        r &= vbCrLf & " [datetime] NULL,"
        r &= vbCrLf & " [image] NULL,"
        r &= vbCrLf & " [decimal](38,2) NULL,"

        Return r
    End Function
    Public Function Profiles()
        Return "CREATE TABLE [database_here].[dbo].[Profiles]
				(
					UniqueID [int] IDENTITY NOT NULL PRIMARY KEY,   
					UserName NVarchar(255) NOT NULL,   
					ApplicationName NVarchar(255) NOT NULL,  
					IsAnonymous BIT,   
					LastActivityDate DateTime,   
					LastUpdatedDate DateTime 
				)"
    End Function

    Public Function Profile() As String
        Dim r As String = "<!--<system.web>-->
		<profile defaultProvider=""standardProfileProvider"" automaticSaveEnabled=""true"">
			<properties>"
        If fields__ IsNot Nothing Then
            For i = 0 To fields__.Length - 1
                r &= "<add name=""" & fields__(i) & """ allowAnonymous=""true"" />" & vbCrLf
            Next
        End If
        r &= "<add name=""numberOfVisits"" type=""Int32"" defaultValue=""0"" allowAnonymous=""true"" />
					</properties>
					<providers>
						<add name=""standardProfileProvider"" type=""System.Web.Profile.SqlProfileProvider"" connectionStringName=""profile_con"" profileTableName=""ProfileData"" />
					</providers>
				</profile>"
        Return r
        'Return "<!--<system.web>-->
        '		<profile defaultProvider=""standardProfileProvider"" automaticSaveEnabled=""true"">
        '			<properties>
        '				<add name=""numberOfVisits"" type=""Int32"" defaultValue=""0"" allowAnonymous=""true"" />
        '			</properties>
        '			<providers>
        '				<add name=""standardProfileProvider"" type=""System.Web.Profile.SqlProfileProvider"" connectionStringName=""profile_con"" profileTableName=""ProfileData"" />
        '			</providers>
        '		</profile>"
    End Function

    Public Function ConnectionSrings() As String
        Return "<!--<connectionStrings>-->
				<add name=""server_con"" connectionString=""Data Source=MACHINE_NAME_HERE\SQLEXPRESS;Initial Catalog=DATABASE_NAME_HERE;Integrated Security=True;User ID=ID_HERE;Password=PASSWORD_HERE"" providerName=""System.Data.SqlClient""/>
				<add name=""server_con_ALT"" connectionString=""Data Source=&quot;domain.com, 1500&quot;;Initial Catalog=DATABASE_NAME_HERE;User ID=User_ID_HERE;Password=PASSWORD_HERE"" providerName=""System.Data.SqlClient""/>

				<add name=""profile_con"" connectionString=""Data Source=MACHINE_NAME_HERE\SQLEXPRESS;Initial Catalog=DATABASE_NAME_HERE;Integrated Security=True;User ID=ID_HERE;Password=PASSWORD_HERE"" providerName=""System.Data.SqlClient""/>
				<add name=""profile_con_ALT"" connectionString=""Data Source=&quot;domain.com, 1500&quot;;Initial Catalog=DATABASE_NAME_HERE;User ID=User_ID_HERE;Password=PASSWORD_HERE"" providerName=""System.Data.SqlClient""/>"
    End Function
    Public Function Filter() As String
        Return ""
    End Function
    Public Function Rewrite() As String
        Return "<!--<system.webServer>-->
				<rewrite>
				  <rules>
					<!--
				  <rule name=""Redirect HTTP to HTTPS"" stopProcessing=""true"">
					  <match url=""(.*)""/>
					  <conditions>
						<add input=""{HTTPS}"" pattern=""^OFF$""/>
					  </conditions>
					  <action type=""Redirect"" url=""https://{HTTP_HOST}/{R:1}"" redirectType=""SeeOther""/>
				  </rule>
				  -->
				  </rules>
				</rewrite>"
    End Function

    Public Function Authentication() As String
        Return "<!--<system.web>-->
				<anonymousIdentification cookieName=""" & System.Guid.NewGuid().ToString & """ enabled=""true"" cookieless=""UseCookies"" cookieRequireSSL=""true"" cookieSlidingExpiration=""false"" />
				<authentication mode=""Forms"">
					<forms name=""" & System.Guid.NewGuid().ToString & """ defaultUrl=""~/space/dashboard.aspx"" loginUrl=""Account/Login.aspx"" timeout=""30"" slidingExpiration=""false"" requireSSL=""true"" cookieless=""UseCookies""/>
				</authentication>"
    End Function
    Public Function Trace()
        Return "<!--<system.web>-->
				<trace enabled=""false"" localOnly=""true"" />"
    End Function
    Public Function httpCookies()
        Return "<!--<system.web>-->
				<httpCookies httpOnlyCookies=""true""/>"
    End Function
    Public Function CustomErrors() As String
        Return "<!--<system.web>-->
					<customErrors mode=""RemoteOnly"" defaultRedirect=""Exception/Error.html""/>"
    End Function

    Public Function Web_Anonymous() As String
        Return "<?xml version=""1.0""?>
				<configuration>
					<system.web>
						<authorization>
							<deny users=""?""/>
						</authorization>
					</system.web>
				</configuration>"
    End Function
    Public Function Title() As String
        Return "<title><%: Page.Title %> - <%: Brand_Name %></title>"
    End Function

    Public Function SupportFunctions(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
            Case Snippets.ProgrammingLanguage.VB
                result = SupportFunctions_VB()
        End Select
        Return result
    End Function
    Public Function Shop_Pre_Load(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
                result = Shop_Pre_Load_CS()
            Case Snippets.ProgrammingLanguage.VB
                result = Shop_Pre_Load_VB()
        End Select
        Return result
    End Function
    Public Function Internal(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
                result = Internal_CS()
            Case Snippets.ProgrammingLanguage.VB
                result = Internal_VB()
        End Select
        Return result
    End Function

    Public Function LogOut(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
                result = LogOut_CS()
            Case Snippets.ProgrammingLanguage.VB
                result = LogOut_VB()
        End Select
    End Function

    Public Function Load(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
            Case Snippets.ProgrammingLanguage.VB
                result = Load_VB()
        End Select
        Return result
    End Function
    Public Function Login_Load(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
                result = Login_Load_CS()
            Case Snippets.ProgrammingLanguage.VB
                result = Login_Load_VB()
        End Select
        Return result
    End Function
    Public Function PreRender(Optional programming_language As Snippets.ProgrammingLanguage = Snippets.ProgrammingLanguage.VB) As String
        Dim result As String = ""
        Select Case programming_language
            Case Snippets.ProgrammingLanguage.CS
            Case Snippets.ProgrammingLanguage.VB
                result = PreRender_VB()
        End Select
        Return result
    End Function

#End Region

#Region "VB"

    Public Function Welcome_ActivateAccount_Load_VB()
        Return "FullName.Text = Request.QueryString(""FullName"")
				Email.Text = Request.QueryString(""Email"")
				Username.Text = Request.QueryString(""Username"")"
    End Function
    Public Function Welcome_ActivateAccount_Resend_Link_VB()
        Return "Send_Welcome_Email(Username.Text)"
    End Function

    Public Function Login_Profile_VB() As String
        Return "FormsAuthentication.SetAuthCookie(Statistics.Traffic.GetProfileName(), False)
				Response.Redirect(Request.Path)"
    End Function

    Public Function Logout_Profile_VB() As String
        Return "FormsAuthentication.SignOut()         
				Response.Redirect(Request.Path)"
    End Function

    Public Function Login_VB()
        Return "If Page.IsValid = False Then Exit Sub

				User Input validation checks here

				'if new, redirect to account activation
				'for client
				If IsNew() Then
					Response.Redirect(""~/Welcome/ActivateAccount?Username="" & username_here & ""&FullName="" & full_name_here & ""&Email="" & email_here)
					Exit Sub
				End If

				If Not IsNew() Then
					If UserExists(server_con, Username_Here, Password_Here) Then
						server_con =
						FormsAuthentication.RedirectFromLoginPage(tUsername.Text, True)
					Else
						Toast(""No matching record."", update_panel_id, New ScriptManager)
						'Alert(""We can't find matching record. Please try again with another username/password."", _feedback)
					End If
				End If"
    End Function



    Private Function NewInternal_VB(kv_fields As String())

        Dim si As String = "Public Class SiteInternal_Email

								#Region ""Fields""
									'internal
									Public ReadOnly Property email_private__ As String = New SModule.SecurityController().Decrypt(New SiteInternal_KV().k_MailSK_From_SiteReg, email_private_here)
									Public ReadOnly Property email_public__ As String = New SModule.SecurityController().Decrypt(New SiteInternal_KV().k_MailPK_From_SiteReg, email_public_here)

									Public ReadOnly Property password_reset_link(Get_EProxy_ As String, Username As String) As String

									Get
											Return Get_EProxy_ & ""account/ResetPassword?Username="" & Username
										End Get
									End Property

									'initialization
									Public Shared Property con_string__ As String

									'welcome
									Private Shared ReadOnly Property WelcomeEmailSubject(Get_EProxySiteNameFull_) As String

										Get
											Return ""Welcome, from "" & Get_EProxySiteNameFull_
										End Get
									End Property

									Private Shared ReadOnly Property WelcomeEmailContent(Fullname As String) As String
										Get
											Return ""Welcome, from ""
										End Get
									End Property

									'recover
									Private ReadOnly Property RecoverEmailSubject(Get_EProxySiteName_ As String) As String
										Get
											Return ""Reset Your Password On "" & Get_EProxySiteName_
										End Get
									End Property
									Private ReadOnly Property RecoverEmailContent(Username As String, Get_EProxySiteName_ As String) As String
										Get
											Dim document_ As String = ""<div class=""""container"""">
											<div class=""""row"""">
												<div class=""""col col-sm-12"""">
													<br />
													<h5>Hi, "" & Accounts.Get_FirstName(Username) & ""</h5>
													<p class=""""lead"""">
														You wanted to reset your password. Please click on <a href=""""""

											document_ &= password_reset_link(Get_EProxy, Username)

											document_ &= """"""><u>this link</u></a> to begin the process. The link is valid for 24 hours.<br />
														<br />
														If you did not make this request, then your account details might have be compromised; it is recommended you log into your account immediately and change your password.<br />
														<br />
														Best Regards,
														<br />
														"" & Get_EProxySiteName_ & ""
													</p>
													<br />
													<br />
													<i>(Link not working? copy the line below to your browser's address bar and press enter.)</i>
													<br />
													<br /><blockquote>""

											document_ &= password_reset_link(Get_EProxy, Username)

											document_ &= ""</blockquote>
												</div>
											</div>
										</div>""

											Dim c As New Converter.Converter()
											Return c.begin_html & c.begin_head & c.content_head(Get_EProxy) & c.end_head & c.begin_body & document_ & c.end_body & c.end_html
										End Get
									End Property
								#End Region

								#Region ""New""

									Public Sub New(con_string As String)
										con_string__ = con_string
										.SiteReg.con_string__ = con_string
										.Accounts.con_string__ = con_string
									End Sub

								#End Region

								#Region ""Main""

									Public Function IsNew(con_string As String, Username As String, Password As String)
										'		Return
									End Function
								#End Region

								#Region ""Recover Email""
									Public Function SendContactUsEmail(Email As String, FullName As String, Message As String, EnquiryType As String)
										Dim msg As String = """"

										msg &= ""Name of Site User: "" & vbCrLf & FullName

										msg &= vbCrLf & vbCrLf & ""Email of Site User: "" & vbCrLf & Email

										msg &= vbCrLf & vbCrLf & ""Target Department: "" & EnquiryType

										msg &= vbCrLf & vbCrLf & ""Message: ""

										msg &= vbCrLf & vbCrLf & Message


										Return SendMail(email_public__, email_private__, Get_EProxyEmail, FullName, Get_EProxyEmailInternal, EnquiryType, EnquiryType, msg)
									End Function

									Public Function Send_Recover_Password_Email(Username As String)
										Return SendMail(email_public__, email_private__, Get_EProxyEmail, Get_EProxySiteNameFull, Accounts.Get_Email(Username), Accounts.Get_TitleOfCourtesy(Username) & "" "" & Accounts.Get_FirstName(Username) & "" "" & Accounts.Get_LastName(Username), RecoverEmailSubject(Get_EProxySiteName), RecoverEmailContent(Username, Get_EProxySiteName))
									End Function
								#End Region

								#Region ""Welcome""
									Public Function Welcome_(Fullname As String, Email As String)
										Return SendMail(email_public__, email_private__, Get_EProxyEmail, Get_EProxySiteNameFull, Email, Fullname, WelcomeEmailSubject(Get_EProxySiteNameFull), WelcomeEmailContent(Fullname))
									End Function
								#End Region

								End Class

								Public Class SiteInternal_Pay

								#Region ""Fields""
									'internal
									Public ReadOnly Property pay_private__ As String = New SModule.SecurityController().Decrypt(New SiteInternal_KV().k_PaystackSK_From_SiteReg, pay_private_here)
								    Public ReadOnly Property pay_public__ As String = New SModule.SecurityController().Decrypt(New SiteInternal_KV().k_PaystackSK_From_SiteReg, pay_public_here)

									'initialization
									Public Shared Property con_string__ As String

								#End Region

								#Region ""New""

									Public Sub New(con_string As String)
										con_string__ = con_string
									End Sub

								#End Region

								#Region ""Main""

								#End Region

								End Class"


        Dim kv As String = vbCrLf & vbCrLf & "Public Class SiteInternal_KV" & vbCrLf

        For i = 0 To kv_fields.Count - 1
            kv &= "	Public ReadOnly Property " & kv_fields(i) & " As String = """ & NewID(IDPattern.Long_) & """" & vbCrLf
        Next

        kv &= vbCrLf & "End Class"


        Dim q As String = vbCrLf & vbCrLf & "Public Class SiteInternal_Q
								Public ReadOnly Property server_con As String = server_con_here
								Public ReadOnly Property client_con As String = client_con_here
							End Class"

        Return si & kv & q

    End Function

    Public Function Validation_Before_Register_VB()
        If fields__ Is Nothing Then Return ""
        Dim r As String = "If IsValid = False Then Return" & vbCrLf & vbCrLf

        For i = 0 To fields__.Length - 1
            r &= "If IsEmpty(t" & fields__(i) & ") Then
						Alert(""Enter " & fields__(i) & """, _feedback_)
						Return
					End If" & vbCrLf & vbCrLf
        Next

        r &= "Try
					'if already exists
					If .Exists(Content(t)) Then
						Alert(String.Format("" with the name {0} already exists."", Content(t)), _feedback_)
						Return
					End If

					Dim r As Boolean = .Add(Content(t, TextCase.Capitalize))

					Welcome_(tFirstName.Text.Trim & "" "" & tLastName.Text.Trim, tEmail.Text.Trim)
					'don't use yet --				Response.Redirect(""~/Welcome/ActivateAccount?Username="" & Username.Value.Trim & ""&FullName="" & FirstName.Value.Trim & "" "" & LastName.Value.Trim & ""&Email="" & Username.Value.Trim)
					FormsAuthentication.RedirectFromLoginPage(Content(Username, TextCase.None), Content(hRememberMe))
				Catch ex As Exception
					Alert(""Oops. That didn't work. Please try again, or restart your browser. If this persists, you may need to clear your browser cookies and/or cache."", _feedback_, False)
				End Try"
        Return r
    End Function

    Public Function Validation_Before_Add_VB()
        If fields__ Is Nothing Then Return ""
        Dim r As String = "If IsValid = False Then Return" & vbCrLf & vbCrLf

        For i = 0 To fields__.Length - 1
            r &= "If IsEmpty(t" & fields__(i) & ") Then
						Alert(""Enter " & fields__(i) & """, _feedback_)
						Return
					End If" & vbCrLf & vbCrLf
        Next

        r &= "Try
					'if user exists
					If Get_IsEnabled(Context.User.Identity.GetUserName) = False Or Get_CanAdd(Context.User.Identity.GetUserName) = False Then
						Alert(""Error adding ."", _feedback_)
						Return
					End If
					'if already exists
					If .Exists(Content(t)) Then
						Alert(String.Format("" with the name {0} already exists."", Content(t)), _feedback_)
						Return
					End If

					Dim r As Boolean = .Add(Content(t, TextCase.Capitalize))
					'clear
					.Clear({t})
					ClearText(d)

					Alert("" has been added."", _feedback_, True, AlertIs.success)
				Catch ex As Exception
					Alert("" has not been added."", _feedback_, False)
				End Try"
        Return r
    End Function

    Public Function NewFile_VB(tableDetails As Dictionary(Of String, String), table__ As String, primary_key__ As String, groups_to_include As iNCode.Snippets.ImportGroupToInclude, sprogramming_language As String, Optional email_field As String = Nothing) As String

        If fields__ Is Nothing Then Return ""
        Dim update_key__ As String = primary_key__
        Dim new_string As String = fields_vb(False) & "Public Shared Function Add("
        Dim params_string As String = ""
        Dim update_string As String = "Public Shared Function Update("
        Dim update_params_string As String = ""
        Dim update_keys As New List(Of String)
        Dim where_keys As New List(Of String)

        Dim clear_string_ As String = "{"
        For i = 0 To fields__.Length - 1
            clear_string_ &= fields__(i) & "Control"
            If i < fields__.Length - 1 Then clear_string_ &= ", "
        Next
        clear_string_ &= "}"
        Dim clear_string As String = "Public Sub Clear("
        For i = 0 To fields__.Length - 1
            clear_string &= fields__(i) & "Control As System.Web.UI.WebControls.WebControl"
            If i < fields__.Length - 1 Then clear_string &= ", "
        Next
        clear_string &= ")" & vbCrLf & "
											iNovation.Code.Web.Clear(" & clear_string_ & ")
										End Sub"

        Dim delete_string As String = "Public Shared Function Delete() As Boolean
											Return CommitSequel(DeleteString_CONDITIONAL(""" & table__ & """, {""" & primary_key__ & """, ""=""}), con_string__, {""" & primary_key__ & """, """"})
										End Function"
        Dim get_string As String = ""
        Dim set_string As String = ""
        Dim display_string As String = ""
        Dim display_by_string As String = ""
        Dim drop_string As String = ""
        Dim migrate_profile As String = vbCrLf & vbCrLf & "Public Shared Function MigrateProfileToAccount()
											'shop only
											'update field of same name in accounts table with ...
											Dim p As New System.Web.Profile.ProfileBase()
											p.GetPropertyValue(""numberOfVisits"")
											'or Statistics.Traffic.GetNumberOfVisits 
										End Function" & vbCrLf

        where_keys.Add(update_key__)
        With fields__
            For i = 0 To .Length - 1
                'If fields__(i) IsNot primary_key__ Then
                If i <> 0 Then
                    params_string &= fields__(i) & " AS " & DataTypeFromColumnName(tableDetails, fields__(i))
                    If i < .Length - 1 Then params_string &= ", "
                End If
                If fields__(i).ToString.ToLower <> primary_key__ And
                    fields__(i).ToString.ToLower <> update_key__.ToLower Then
                    update_params_string &= fields__(i) & " AS " & DataTypeFromColumnName(tableDetails, fields__(i))
                    If i < .Length - 1 Then update_params_string &= ", "
                        update_keys.Add(fields__(i).ToString)
                    End If
                    If fields__(i).ToString.ToLower <> update_key__.ToLower Then
                    get_string &= "Public Shared Function Get" & fields__(i).ToString & "(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As " & DataTypeFromColumnName(tableDetails, fields__(i)) & vbCrLf
                    get_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.QData, "con_string__").Replace("""" & primary_key__ & """, """"", """" & primary_key__ & """, " & primary_key__)
                    get_string &= vbCrLf & "End Function" & vbCrLf
                End If
                If fields__(i).ToString.ToLower <> update_key__.ToLower Then '/
                    set_string &= "Public Shared Function Set" & fields__(i).ToString & "(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ", " & fields__(i) & " As " & DataTypeFromColumnName(tableDetails, fields__(i)) & ") As Boolean" & vbCrLf
                    Dim set_keys As New List(Of String)
                    set_keys.Add(fields__(i))
                    Dim set_keys_where As New List(Of String)
                    set_keys_where.Add(primary_key__)
                    set_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildUpdateString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = set_keys.ToArray, .WhereKeys = set_keys_where.ToArray, .WhereOperators = Nothing}, QOutput.Commit, "con_string__").Replace("{""" & fields__(i) & """, """", """ & primary_key__ & """, """"}", "{""" & fields__(i) & """, " & fields__(i) & ", """ & primary_key__ & """, " & primary_key__ & "}")
                    set_string &= vbCrLf & "End Function" & vbCrLf
                End If '/

                drop_string &= "Public Shared Function Drop" & fields__(i).ToString & "(" & fields__(i) & "DropDown As System.Web.UI.WebControls.DropDownList) As System.Web.UI.WebControls.DropDownList" & vbCrLf
                ''replaced with next line					drop_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "RecordSerial", .operation = Queries.BuildSelectString_DISTINCT, .OrderByField = "RecordSerial", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.BindProperty, "con_string__").Replace("control_here", "d" & fields__(i))
                drop_string &= "If " & fields__(i) & "DropDown.Items.Count < 1 Then " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString_DISTINCT, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.BindProperty, "con_string__").Replace("control_here", fields__(i) & "DropDown")
                drop_string &= vbCrLf & "Return " & fields__(i) & "DropDown" & vbCrLf
                drop_string &= vbCrLf & "End Function" & vbCrLf
                '/				End If
            Next
        End With

        For i = 0 To fields__.Length - 1
            If set_string.Contains("""" & fields__(i) & """, """"") Then
                set_string = set_string.Replace("""" & fields__(i) & """, """"", """" & fields__(i) & """, " & fields__(i))
            End If
        Next


        Dim insert_keys As New List(Of String)
        With fields__
            For i As Integer = 0 To .Length - 1
                'If fields__(i).ToString.ToLower <> "" & primary_key__ & "" Then
                If i <> 0 Then

                    insert_keys.Add(fields__(i))
                End If
            Next
        End With
        new_string &= params_string & ") As Boolean" & vbCrLf
        new_string &= "Return " & QString(New QParameters With {.InsertKeys = insert_keys.ToArray, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "", .operation = Queries.BuildInsertString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.Commit, "con_string__")

        For i = 0 To fields__.Length - 1
            If new_string.Contains("""" & fields__(i) & """, """"") Then
                new_string = new_string.Replace("""" & fields__(i) & """, """"", """" & fields__(i) & """, " & fields__(i))
            End If
        Next

        If insert_keys.Contains("NumberOfVisits") Or insert_keys.Contains("numberOfVisits") Or insert_keys.Contains("numberofvisits") Then
            new_string &= vbCrLf & "'Use Statistics.Traffic.GetNumberOfVisits or MigrateProfileToAccount() as value for NumberOfVisits"
        End If
        new_string &= vbCrLf & "End Function"


        'update_keys.Add(primary_key__)
        update_string &= update_params_string & ", " & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As Boolean" & vbCrLf
        update_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildUpdateString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = update_keys.ToArray, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.Commit, "con_string__")

        For i = 0 To fields__.Length - 1
            If update_string.Contains("""" & fields__(i) & """, """"") Then
                update_string = update_string.Replace("""" & fields__(i) & """, """"", """" & fields__(i) & """, " & fields__(i))
            End If
        Next

        update_string &= vbCrLf & "End Function"

        'display_string &= "Public Function Display_Info(g As System.Web.UI.WebControls.GridView) As System.Web.UI.WebControls.GridView" & vbCrLf
        'display_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "RecordSerial", .operation = Queries.BuildSelectString, .OrderByField = "RecordSerial", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.Display, "con_string__").Replace("grid_here", "g")
        'display_string &= vbCrLf & "End Function"

        display_string &= "Public Shared Function DisplayAll(grid_here As System.Web.UI.WebControls.GridView) As System.Web.UI.WebControls.GridView" & vbCrLf
        'display_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.Display, "con_string__").Replace("grid_here", "g")
        display_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.Display, "con_string__")
        display_string &= vbCrLf & "End Function"

        display_by_string &= "Public Shared Function DisplayByID(grid_here As System.Web.UI.WebControls.GridView, " & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As System.Web.UI.WebControls.GridView" & vbCrLf
        display_by_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.Display, "con_string__").Replace("""" & primary_key__ & """, """"", """" & primary_key__ & """, " & primary_key__)
        display_by_string &= vbCrLf & "'If ID is Username, like in Cart, replace ID with Username"
        display_by_string &= vbCrLf & "End Function"

        Dim exists_string As String = "Public Shared Function Exists(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As Boolean
											Return QExists(""" & table__ & """, con_string__, {""" & primary_key__ & """}, {""" & primary_key__ & """, " & primary_key__ & " })
										End Function"

        Return Imports_VB(False) & "Public class " & table__ & vbCrLf & vbCrLf & new_string & vbCrLf & vbCrLf & update_string & vbCrLf & vbCrLf & clear_string & vbCrLf & vbCrLf & get_string & vbCrLf & vbCrLf & set_string & vbCrLf & vbCrLf & display_string & vbCrLf & vbCrLf & display_by_string & vbCrLf & vbCrLf & drop_string & migrate_profile & vbCrLf & vbCrLf & delete_string & vbCrLf & vbCrLf & exists_string & vbCrLf & vbCrLf & "End Class"

    End Function
    Public Function NewFile_VB_Encryption(tableDetails As Dictionary(Of String, String), table__ As String, primary_key__ As String, groups_to_include As iNCode.Snippets.ImportGroupToInclude, programming_language As String, Optional email_field As String = Nothing) As String

        If fields__ Is Nothing Then Return ""
        Dim update_key__ As String = primary_key__

        Dim new_string As String = fields_vb(True) & "Public Shared Function Add("
        Dim params_string As String = ""
        Dim update_string As String = "Public Shared Function Update("
        Dim update_params_string As String = ""
        Dim update_keys As New List(Of String)
        Dim where_keys As New List(Of String)

        Dim clear_string_ As String = "{"
        For i = 0 To fields__.Length - 1
            clear_string_ &= fields__(i) & "Control"
            If i < fields__.Length - 1 Then clear_string_ &= ", "
        Next
        clear_string_ &= "}"
        Dim clear_string As String = "Public Sub Clear("
        For i = 0 To fields__.Length - 1
            clear_string &= fields__(i) & "Control As System.Web.UI.WebControls.WebControl"
            If i < fields__.Length - 1 Then clear_string &= ", "
        Next
        clear_string &= ")" & vbCrLf & "
											iNovation.Code.Web.Clear(" & clear_string_ & ")
										End Sub"

        Dim delete_string As String = "Public Shared Function Delete() As Boolean
											Return CommitSequel(DeleteString_CONDITIONAL(""" & table__ & """, {""" & primary_key__ & """, ""=""}), con_string__, {""" & primary_key__ & """, """"})
										End Function"
        Dim get_string As String = ""
        Dim set_string As String = ""
        Dim display_string As String = ""
        Dim display_by_string As String = ""
        Dim drop_string As String = ""
        Dim migrate_profile As String = vbCrLf & vbCrLf & "Public Shared Function MigrateProfileToAccount()
											'shop only
											'update field of same name in accounts table with ...
											Dim p As New System.Web.Profile.ProfileBase()
											p.GetPropertyValue(""numberOfVisits"")
											'or Statistics.Traffic.GetNumberOfVisits 
										End Function" & vbCrLf

        where_keys.Add(update_key__)
        With fields__
            For i = 0 To .Length - 1
                'If fields__(i) IsNot primary_key__ Then
                If i <> 0 Then
                    'params_string &= fields__(i) & " AS Type_Here, "
                    params_string &= fields__(i) & " AS " & DataTypeFromColumnName(tableDetails, fields__(i))
                    If i < .Length - 1 Then params_string &= ", "
                End If
                If fields__(i).ToString.ToLower <> "" & primary_key__ & "" And
                    fields__(i).ToString.ToLower <> update_key__.ToLower Then
                    update_params_string &= fields__(i) & " AS " & DataTypeFromColumnName(tableDetails, fields__(i))
                    If i < .Length - 1 Then update_params_string &= ", "
                        update_keys.Add(fields__(i).ToString)
                    End If
                    If fields__(i).ToString.ToLower <> update_key__.ToLower Then
                    get_string &= "Public Shared Function Get" & fields__(i).ToString & "(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As " & DataTypeFromColumnName(tableDetails, fields__(i)) & "" & vbCrLf
                    'If fields__(i).ToString.ToLower <> "picture" Then
                    get_string &= "Return Decrypt(key__, " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.QData, "con_string__").Replace("""" & primary_key__ & """, """"", """" & primary_key__ & """, " & primary_key__) & ")"
                    'Else
                    '	get_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.QData, "con_string__").Replace("""" & primary_key__ & """, """"", """" & primary_key__ & """, " & primary_key__)
                    'End If

                    get_string &= vbCrLf & "End Function" & vbCrLf
                End If

                If fields__(i).ToString.ToLower <> update_key__.ToLower Then
                    set_string &= "Public Shared Function Set" & fields__(i).ToString & "(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ", " & fields__(i) & " As " & DataTypeFromColumnName(tableDetails, fields__(i)) & ") As Boolean" & vbCrLf
                    Dim set_keys As New List(Of String)
                    set_keys.Add(fields__(i))
                    Dim set_keys_where As New List(Of String)
                    set_keys_where.Add(primary_key__)
                    'If fields__(i).ToString.ToLower <> "picture" Then
                    set_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildUpdateString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = set_keys.ToArray, .WhereKeys = set_keys_where.ToArray, .WhereOperators = Nothing}, QOutput.Commit, "con_string__").Replace("{""" & fields__(i) & """, """", """ & primary_key__ & """, """"}", "{""" & fields__(i) & """, " & fields__(i) & ", """ & primary_key__ & """, " & primary_key__ & "}")
                    'Else
                    '	set_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildUpdateString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = set_keys.ToArray, .WhereKeys = set_keys_where.ToArray, .WhereOperators = Nothing}, QOutput.Commit, "con_string__").Replace("{""" & fields__(i) & """, """", """ & primary_key__ & """, """"}", "{""" & fields__(i) & """, " & fields__(i) & ", """ & primary_key__ & """, " & primary_key__ & "}")
                    'End If

                    set_string &= vbCrLf & "End Function" & vbCrLf
                End If

                drop_string &= "Public Shared Function Drop" & fields__(i).ToString & "(" & fields__(i) & "DropDown As System.Web.UI.WebControls.DropDownList, TempDropDown As System.Web.UI.WebControls.DropDownList) As System.Web.UI.WebControls.DropDownList" & vbCrLf

                'If fields__(i).ToString.ToLower <> primary_key__.ToLower And fields__(i).ToString.ToLower <> "picture" Then
                If fields__(i).ToString.ToLower <> primary_key__.ToLower Then
                    drop_string &= "If " & fields__(i) & "DropDown.Items.Count < 1 Then " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString_DISTINCT, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.BindProperty, "con_string__").Replace("control_here", "TempDropDown")
                    drop_string &= vbCrLf & "For i = CType(TempDropDown, System.Web.UI.WebControls.DropDownList).Items.Count - 1 To 0 Step -1
										CType(" & fields__(i) & "DropDown, System.Web.UI.WebControls.DropDownList).Items.Add(Decrypt(key__, CType(TempDropDown, System.Web.UI.WebControls.DropDownList).Items.Item(i).ToString))
									Next
									CType(TempDropDown, System.Web.UI.WebControls.DropDownList).Visible = False"
                Else
                    drop_string &= "If " & fields__(i) & "DropDown.Items.Count < 1 Then " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString_DISTINCT, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = {fields__(i).ToString}, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.BindProperty, "con_string__").Replace("control_here", fields__(i) & "DropDown")
                End If

                drop_string &= vbCrLf & "Return " & fields__(i) & "DropDown" & vbCrLf
                drop_string &= vbCrLf & "End Function" & vbCrLf
                '/End If
            Next
        End With

        For i = 0 To fields__.Length - 1
            If set_string.Contains("""" & fields__(i) & """, """"") Then
                set_string = set_string.Replace("""" & fields__(i) & """, """"", """" & fields__(i) & """, " & fields__(i))
            End If
        Next
        '
        For i = 0 To fields__.Length - 1
            'If fields__(i).ToString.ToLower <> "picture" And fields__(i).ToString.ToLower <> primary_key__.ToLower Then _
            If fields__(i).ToString.ToLower <> primary_key__.ToLower Then _
            set_string = set_string.Replace("""" & fields__(i) & """, " & fields__(i) & "", """" & fields__(i) & """, Encrypt(key__, " & fields__(i) & ")")
        Next


        Dim insert_keys As New List(Of String)
        With fields__
            For i As Integer = 0 To .Length - 1
                'If fields__(i).ToString.ToLower <> "" & primary_key__ & "" Then
                If i <> 0 Then

                    insert_keys.Add(fields__(i))
                End If
            Next
        End With
        new_string &= params_string & ") As Boolean" & vbCrLf
        new_string &= "Return " & QString(New QParameters With {.InsertKeys = insert_keys.ToArray, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "", .operation = Queries.BuildInsertString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.Commit, "con_string__")

        For i = 0 To fields__.Length - 1
            If new_string.Contains("""" & fields__(i) & """, """"") Then
                new_string = new_string.Replace("""" & fields__(i) & """, """"", """" & fields__(i) & """, " & fields__(i))
            End If
            '
        Next
        '
        For i = 0 To fields__.Length - 1
            'If fields__(i).ToString.ToLower <> "picture" Then _
            new_string = new_string.Replace("""" & fields__(i) & """, " & fields__(i) & "", """" & fields__(i) & """, Encrypt(key__, " & fields__(i) & ")")
        Next

        If insert_keys.Contains("NumberOfVisits") Or insert_keys.Contains("numberOfVisits") Or insert_keys.Contains("numberofvisits") Then
            new_string &= vbCrLf & "'Use Statistics.Traffic.GetNumberOfVisits or MigrateProfileToAccount() as value for NumberOfVisits"
        End If
        new_string &= vbCrLf & "End Function"


        'update_keys.Add(primary_key__)
        update_string &= update_params_string & ", " & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As Boolean" & vbCrLf
        update_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildUpdateString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = Nothing, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = update_keys.ToArray, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.Commit, "con_string__")

        For i = 0 To fields__.Length - 1
            If update_string.Contains("""" & fields__(i) & """, """"") Then
                update_string = update_string.Replace("""" & fields__(i) & """, """"", """" & fields__(i) & """, " & fields__(i))
            End If
        Next
        '
        For i = 0 To fields__.Length - 1
            'If fields__(i).ToString.ToLower <> "picture" And fields__(i).ToString.ToLower <> primary_key__.ToLower Then _
            If fields__(i).ToString.ToLower <> primary_key__.ToLower Then _
            update_string = update_string.Replace("""" & fields__(i) & """, " & fields__(i) & "", """" & fields__(i) & """, Encrypt(key__, " & fields__(i) & ")")
        Next

        update_string &= vbCrLf & "End Function"

        'display_string &= "Public Function Display_Info(g As System.Web.UI.WebControls.GridView) As System.Web.UI.WebControls.GridView" & vbCrLf
        'display_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "RecordSerial", .operation = Queries.BuildSelectString, .OrderByField = "RecordSerial", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.Display, "con_string__").Replace("grid_here", "g")
        'display_string &= vbCrLf & "End Function"

        display_string &= "Public Shared Function DisplayAll(grid_here As System.Web.UI.WebControls.GridView) As System.Web.UI.WebControls.GridView" & vbCrLf
        'display_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.Display, "con_string__").Replace("grid_here", "g")
        display_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = Nothing, .WhereOperators = Nothing}, QOutput.Display, "con_string__")
        display_string &= vbCrLf & "End Function"

        display_by_string &= "Public Shared Function DisplayByID(grid_here As System.Web.UI.WebControls.GridView, " & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As System.Web.UI.WebControls.GridView" & vbCrLf
        display_by_string &= "Return " & QString(New QParameters With {.InsertKeys = Nothing, .LikeSelect = LIKE_SELECT.AND_, .MaxField = "" & primary_key__ & "", .operation = Queries.BuildSelectString, .OrderByField = "" & primary_key__ & "", .OrderRecordsBy = OrderBy.ASC, .SelectColumns = fields__, .table = table__, .TopRowsToSelect = 1, .UpdateKeys = Nothing, .WhereKeys = where_keys.ToArray, .WhereOperators = Nothing}, QOutput.Display, "con_string__").Replace("""" & primary_key__ & """, """"", """" & primary_key__ & """, " & primary_key__)
        display_by_string &= vbCrLf & "'If ID is Username, like in Cart, replace ID with Username"
        display_by_string &= vbCrLf & "End Function"

        Dim exists_string As String
        If primary_key__.ToLower = "" & primary_key__ & "" Then
            exists_string = "Public Shared Function Exists(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As Boolean
											Return QExists(""" & table__ & """, con_string__, {""" & primary_key__ & """}, {""" & primary_key__ & """, " & primary_key__ & " })
										End Function"
        Else
            exists_string = "Public Shared Function Exists(" & primary_key__ & " As " & DataTypeFromColumnName(tableDetails, primary_key__) & ") As Boolean
											Return QExists(""" & table__ & """, con_string__, {""" & primary_key__ & """}, {""" & primary_key__ & """, Encrypt(key__, " & primary_key__ & ") })
										End Function"
        End If



        Return Imports_VB(True) & "Public class " & table__ & vbCrLf & vbCrLf & new_string & vbCrLf & vbCrLf & update_string & vbCrLf & vbCrLf & clear_string & vbCrLf & vbCrLf & get_string & vbCrLf & vbCrLf & set_string & vbCrLf & vbCrLf & display_string & vbCrLf & vbCrLf & display_by_string & vbCrLf & vbCrLf & drop_string & migrate_profile & vbCrLf & vbCrLf & delete_string & vbCrLf & vbCrLf & exists_string & vbCrLf & vbCrLf & "End Class"

    End Function

    Private Function fields_vb(includeEncryption As Boolean) As String
        Return "Private Shared ReadOnly Property  InitialCatalogVariableName As String = """"" & vbCrLf & "Private Shared ReadOnly Property  UserIdVariableName As String = """"" & vbCrLf & "Private Shared ReadOnly Property  PasswordVariableName As String = """"" & vbCrLf & If(includeEncryption, "Private Shared ReadOnly Property  EncryptionKeyVariableName As String = """"" & vbCrLf, "") & "Private Shared ReadOnly Property con_string__ As String = """ & ConstructConnectionString() &
            If(includeEncryption, vbCrLf & "Private Shared ReadOnly Property key__ As String = Environment.GetEnvironmentVariable(EncryptionKeyVariableName, EnvironmentVariableTarget.User)", "") &
            vbCrLf & vbCrLf
        'Return "Private Shared ReadOnly Property con_string__ As String = ""connection_string_here""" &
        '    If(includeEncryption, vbCrLf & "Private Shared ReadOnly Property key__ As String = ""encryption_key_here""", "") &
        '    vbCrLf & vbCrLf

    End Function

    Public Function Imports_VB(includeEncryption As Boolean) As String
        Return "Imports iNovation.Code.General
'Imports iNovation.Code.Desktop  'uncomment this line if targeting desktop environment
Imports iNovation.Code.Web  'comment this line if targeting desktop environment
Imports iNovation.Code.Sequel" & If(includeEncryption, "
Imports iNovation.Code.Encryption", "") & vbCrLf & vbCrLf
    End Function

    Public Function Imports_CS(includeEncryption As Boolean)
        Return "using static iNovation.Code.General;
using static iNovation.Code.Desktop;
using static iNovation.Code.Web;
using static iNovation.Code.Sequel;" & If(includeEncryption, "
using static iNovation.Code.Encryption;", "") & vbCrLf & vbCrLf
    End Function

    Public Function Forgot_SendResetEmail_VB()
        Return "If IsEmpty(tEmail) Then Return

				If EmailExists(Content(tEmail)) = False Then
					Alert(""Could not find matching record."", _feedback_)
					'Toast(""Could not find matching record."", sender, Page, New ScriptManager)
					Return
				End If

				Set_AlternatePasswordExpires(Get_Username(Content(tEmail)), DateAdd(DateInterval.Day, 2, Date.Parse(Now)))
				Alert(""Email has been sent. Please check your mailbox."", _feedback_)
				'Toast(""Email has been sent. Please check your mailbox."", sender, Page, New ScriptManager)"
    End Function

    Public Function Reset_Load_VB() As String
        Return "If Request.QueryString(""Username"") IsNot Nothing Then username__ = Request.QueryString(""Username"")

				.Accounts.con_string__ = server_con
				.SiteReg.con_string__ = server_con

				If Date.Parse(Now) > DateAdd(DateInterval.Day, 1, Date.Parse(Get_AlternatePasswordExpires(Request.QueryString(""Username"")))) Then
					_Form.Visible = False
					Alert(""This page is no longer valid. Please make another request."", _feedback_, False)
					'Toast(""This page is no longer valid. Please make another request."", sender, Page, New ScriptManager)
				Else
					_Form.Visible = True
					_feedback_.Visible = False
				End If"
    End Function
    Public Function Reset_UpdatePassword_VB() As String
        Return "If IsValid = False Then Return

				If IsEmpty(tPassword) Then Return

				If IsEmpty(tPasswordConfirm) Then
					Alert(""Confirm your password"", _feedback_)
					Return
				End If

				If Content(tPassword).ToLower <> Content(tPasswordConfirm).ToLower Then
					Alert(""Choose a password, and confirm your password"", _feedback_)
					Return
				End If
				Dim error_in_password As String = CheckPassword(Content(tPassword))
				If error_in_password.Length > 0 Then
					Alert(error_in_password, _feedback_)
					Return
				End If


				Try
					Set_Password(username__, Content(tPassword))

					Response.Redirect(""ResetPasswordConfirmation"")
				Catch ex As Exception
					Alert(""Oops. That didn't work. Please try again, or restart your browser. If this persists, you may need to clear your browser cookies and/or cache."", _feedback_)
				End Try"
    End Function
    Public Function Activated_Load_VB()
        Return "tUsername.Text = Request.QueryString(""Username"")
				tEmail.Text = Request.QueryString(""Email"")
				tName.Text = Request.QueryString(""Name"")
				Dim query_ As String = ""UPDATE Accounts SET IsNew='False' WHERE (Username=@Username)""
				Dim entries_parameters_() = {""Username"", tUsername.Text.Trim}
				CommitSequel(query_, server_con, entries_parameters_)"
    End Function

    Public Function Database_VB()
        Return "#Region ""Internal Members""
					Public Enum EnquiryType
						Select_an_option = 0
						General_Enquiry = 1
						Report_Payment_Issue = 2
						Delivery = 3
						Privacy = 4
						Support = 5
						Marketing = 6
					End Enum
				#End Region

				#Region ""Fields""
					Public default_con_server As String = 'ConfigurationManager.ConnectionStrings.Item(""server_con"").ToString()
					Public default_con_client As String = '
					Public client_con As String 
					Public server_con As String 

					Public Property search_ As String
					Public Property match_has_been_expanded As Boolean = False

					Public Property empty_cart_string As String = ""You have no items in your cart.""

					Public ReadOnly Property EnquiryTypeList As List(Of String)
						Get
							Dim l As List(Of String) = GetEnum(New EnquiryType)
							Dim r As New List(Of String)
							For i = 0 To l.Count - 1
								r.Add(l(i).Replace(""_"", "" ""))
							Next
							Return r
						End Get
					End Property
				#End Region

				#Region ""Main""
				#End Region"
    End Function

    Public Function HelperFunctions_VB_EStore()
        Return "#Region ""Support Functions""

					Protected Function GetPhone()
						Return Get_EProxyPhone(1)
					End Function

					Protected Function GetAddress()
						Return Get_EProxyAddress(1)
					End Function

					Protected Function GetEmail()
						Return Get_EProxyEmail(1)
					End Function

					Protected Function GetCity()
						Return Get_EProxyCity(1)
					End Function

					Protected Function GetCountry()
						Return Get_EProxyCountry(1)
					End Function

					Protected Function GetSiteNameFull()
						Return Get_EProxySiteNameFull(1)
					End Function

					Protected Function GetTwitterURL()
						Return Get_EProxyTwitter(1)
					End Function

					Protected Function GetFacebookURL()
						Return Get_EProxyFacebook(1)
					End Function
					Protected Function GetInstagramURL()
						Return Get_EProxyInstagram(1)
					End Function
					Protected Function GetWhatsAppNumber()
						Return Get_EProxyWhatsApp(1)
					End Function


				#End Region
				#Region ""Address""
					Protected Sub Addresses()
						hyperLink_Twitter.Text = ""<i class=""""fa fa-twitter"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Twitter_URL()
						hyperlink_Twitter.NavigateUrl = GetTwitterURL()
						hyperLink_Facebook.Text = ""<i class=""""fa fa-facebook"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Facebook_URL()
						hyperlink_Facebook.NavigateUrl = GetFacebookURL()
						hyperLink_Instagram.Text = ""<i class=""""fa fa-instagram"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Instagram_URL()
						hyperlink_Instagram.NavigateUrl = GetInstagramURL()
						hyperLink_WhatsApp.Text = ""<i Class=""""fa fa-whatsapp"""" aria-hidden=""""True""""></i>&nbsp;&nbsp;"" & GetwhatsappNumber()
						hyperlink_WhatsApp.NavigateUrl = ""#""

						hyperLink_Phone.NavigateUrl = ""#""
						hyperLink_Phone.Text = ""<i Class=""""fa fa-phone"""" aria-hidden=""""True""""></i>&nbsp;&nbsp;"" & GetPhone()
						hyperLink_Email.NavigateUrl = ""mailto:"" & Getemail()
						hyperLink_Email.Text = ""<i class=""""fa fa-envelope"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & GetEmail()

						hyperLink_Address.Text = ""<i Class=""""fa fa-map-marker"""" aria-hidden=""""True""""></i><br />"" & GetAddress() & ""<br />"" & GetCity() & "", "" & GetCountry() & ""<br />""

						hyperlink_ReportPaymentIssue.NavigateUrl = ""~/Contact.aspx?reference=Report Payment Issue""
					End Sub
				#End Region
				#Region ""Buttons""
					Protected Shadows Sub Controls()
						'sign in
						li_SignIn.Visible = Request.IsAuthenticated = False
						li_LogOut.Visible = Request.IsAuthenticated
						hyperlink_Welcome.Visible = Request.IsAuthenticated
						_welcome.InnerHtml = Get_FirstName(Context.User.Identity.GetUserName)
						'logo
						'image_logo_footer.ImageUrl = Get_EProxy() & ""handler_image.ashx?reference=logo""
						'image_logo_header.ImageUrl = Get_EProxy() & ""handler_image.ashx?reference=logo""
						'image_logo_preloader.ImageUrl = Get_EProxy() & ""handler_image.ashx?reference=logo""


					End Sub
					Protected Sub a_LogOut_ServerClick(sender As Object, e As EventArgs)
						'match_has_been_expanded = False 
						FormsAuthentication.SignOut()
						'		Response.Redirect(Request.Path)
						Response.Redirect(""~/Shop"")
					End Sub
				#End Region"
    End Function

    Public Function SupportFunctions_VB()
        Return "#Region ""Support Functions""
					Private WithEvents _number_of_cart_items As HtmlGenericControl
					Private Sub CartInformation()
						_number_of_cart_items = loginView.FindControl(""_number_of_cart_items"")
						_number_of_cart_items.InnerHtml = Val(Number_Of_Cart_Items)
					End Sub
					Private Function Number_Of_Cart_Items() As String
						Return 
					End Function
					Private Sub Addresses()
						'logo
						'image_Logo.ImageUrl = ""images/logo/logo.png""
						'brand
						_Brand_Name.InnerText = Brand_Name()
						'company
						_Company_Name.InnerText = Company_Name()
						'address
						hyperLink_Address.Text = ""<i class=""""fa fa-map-marker"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Street_Address()
						'phone
						hyperLink_Phone.Text = ""<i class=""""fa fa-phone"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Phone_Number()
						'email
						hyperLink_Email.Text = ""<i class=""""fa fa-envelope"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Email_Address()
						hyperLink_Email.NavigateUrl = ""mailto:"" & Email_Address()
						'facebook
						hyperLink_Facebook.Text = ""<i class=""""fa fa-facebook"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Facebook_URL()
						hyperLink_Facebook.NavigateUrl = Facebook_URL()
						'twitter
						hyperLink_Twitter.Text = ""<i class=""""fa fa-twitter"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Twitter_URL()
						hyperLink_Twitter.NavigateUrl = Twitter_URL()
						'instagram
						hyperLink_Instagram.Text = ""<i class=""""fa fa-instagram"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & Instagram_URL()
						hyperLink_Instagram.NavigateUrl = Instagram_URL()
						'whatsapp
						hyperLink_WhatsApp.Text = ""<i class=""""fa fa-whatsapp"""" aria-hidden=""""true""""></i>&nbsp;&nbsp;"" & WhatsApp_Number()

						'Fullname
						_Fullname.InnerHtml = Account_FullName()
						'Email
						_Email.InnerHtml = Account_Email
					End Sub
					Protected Function Account_FullName() As String
						If Request.IsAuthenticated Then
							'from database
						Else
							'
						End If
					End Function
					Protected Function Account_Email() As String
						If Request.IsAuthenticated Then
							'from database
						Else
							'
						End If
					End Function
					Protected Function Website_URL() As String
						Return Get_
					End Function

					Protected Function Brand_Name() As String
						Return Get_
					End Function
					Protected Function Company_Name() As String
						Return Get_
					End Function

					Protected Function Street_Address() As String
						Return Get_
					End Function
					Protected Function Phone_Number() As String
						Return Get_
					End Function
					Protected Function Email_Address() As String
						Return Get_
					End Function
					Protected Function Facebook_URL() As String
						Return Get_
					End Function
					Protected Function Twitter_URL() As String
						Return Get_
					End Function
					Protected Function Instagram_URL() As String
						Return Get_
					End Function
					Protected Function WhatsApp_Number() As String
						Return Get_
					End Function

				#End Region"
    End Function

    Public Function Load_Site_VB()
        Return "Page.MaintainScrollPositionOnPostBack = True"
    End Function

    Public Function Internal_VB()
        Return "#Region ""Internal""
					Private Const AntiXsrfTokenKey As String = ""__AntiXsrfToken""
					Private Const AntiXsrfUserNameKey As String = ""__AntiXsrfUserName""
					Private _antiXsrfTokenValue As String

					Protected Sub Page_Init(sender As Object, e As EventArgs)
						' The code below helps to protect against XSRF attacks
						Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
						Dim requestCookieGuidValue As Guid
						If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
							' Use the Anti-XSRF token from the cookie
							_antiXsrfTokenValue = requestCookie.Value
							Page.ViewStateUserKey = _antiXsrfTokenValue
						Else
							' Generate a new Anti-XSRF token and save to the cookie
							_antiXsrfTokenValue = Guid.NewGuid().ToString(""N"")
							Page.ViewStateUserKey = _antiXsrfTokenValue

							Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With { _
								 .HttpOnly = True, _
								 .Value = _antiXsrfTokenValue _
							}
							If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
								responseCookie.Secure = True
							End If
							Response.Cookies.[Set](responseCookie)
						End If

						AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
					End Sub

					Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
						If Not IsPostBack Then
							' Set Anti-XSRF token
							ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
							ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
						Else
							' Validate the Anti-XSRF token
							If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
								Throw New InvalidOperationException(""Validation of Anti-XSRF token failed."")
							End If
						End If
					End Sub
				#End Region"
    End Function

    Public Function LogOut_VB()
        Return "Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
					'Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
					FormsAuthentication.SignOut()
				End Sub"
    End Function
    Public Function PreRender_VB_EStore()
        Return "Controls()
				Addresses()

				If tSearch.Value.ToString.Length > 1 Then
					search_ = tSearch.Value.ToString
					Response.Redirect(""~/Shop.aspx"")
				End If"
    End Function

    Public Function PreRender_VB()
        Return "Addresses()
			CartInformation()"
    End Function
    Public Function Shop_Pre_Load_VB()
        Return "Dim p As New ProfileBase()
				If p.IsAnonymous Then
					p.SetPropertyValue(""numberOfVisits"", CInt(p.GetPropertyValue(""numberOfVisits"")) + 1)
				Else
					'update same field in accounts table
				End If"
    End Function
    Public Function Load_VB()
        Return "If server_con Is Nothing Then FormsAuthentication.SignOut() : Response.Redirect(FormsAuthentication.LoginUrl & ""?ReturnUrl="" & HttpUtility.UrlEncode(Request.CurrentExecutionFilePath))
				Values()"
    End Function
    Public Function Load_Anonymous_VB()
        Return "If Request.IsAuthenticated Then Response.Redirect(""space/Dashboard.aspx"")"
    End Function

    Public Function Login_Load_VB()
        Return "If Request.IsAuthenticated Then
					Response.Redirect(""~/space/Dashboard.aspx"")
				End If

				ForgotPasswordHyperLink.NavigateUrl = ""Forgot"""
    End Function
    Public Function ImageHandler_VB()
        Return "context.Response.ContentType = ""image/jpg""

				Dim con As SqlConnection = New SqlConnection(m_con)
				Dim cmd As SqlCommand = New SqlCommand(""SELECT SchoolLogo FROM MyAdminSettings WHERE AccountID=@AccountID"", con)
				cmd.Parameters.AddWithValue(""@AccountID"", context.User.Identity.GetUserName())
				'Dim cmd As SqlCommand = New SqlCommand(""SELECT Picture FROM SiteSettings"", con)
				Try
					Using con
						con.Open()
						Dim file() As Byte = CType(cmd.ExecuteScalar(), Byte())
						If file IsNot Nothing Then context.Response.BinaryWrite(file)
					End Using
				Catch
				End Try"
    End Function

    Public Function PageIndexChanging_VB()
        Return "grid_here.PageIndex = e.NewPageIndex
				PopulateGrid()"
    End Function
    Public Function Load_Mobile_VB()
        Return "Dim AlternateView = ""Desktop""
				Dim switchViewRouteName = ""AspNet.FriendlyUrls.SwitchView""
				Dim url = GetRouteUrl(switchViewRouteName, New With {Key .view = AlternateView, Key .__FriendlyUrls_SwitchViews = True})
				url += ""?ReturnUrl="" & HttpUtility.UrlEncode(Request.RawUrl)
				Response.Redirect(url)"
    End Function


#End Region

#Region "CS"
    Public Function Forgot_SendResetEmail_CS() As String
        Return ""
    End Function
    Public Function Database_CS() As String
        Return ""

    End Function

    Public Function HelperFunctions_CS() As String
        Return ""

    End Function
    Public Function ImageHandler_CS() As String
        Return ""

    End Function
    Public Function Shop_Pre_Load_CS() As String
        Return ""

    End Function

    Public Function Load_CS() As String
        Return ""

    End Function
    Public Function PageIndexChanging_CS() As String
        Return ""

    End Function

    Public Function NewInternal_CS() As String
        Return ""

    End Function
    Public Function NewFile_CS() As String
        Return ""
    End Function

    Public Function Load_Site_CS() As String
        Return ""
    End Function
    Public Function Login_CS() As String
        Return ""
    End Function
    Public Function Login_Load_CS() As String
        Return ""
    End Function
    Public Function Load_Anonymous_CS() As String
        Return ""
    End Function
    Public Function Load_Mobile_CS() As String
        Return ""
    End Function

    Public Function Internal_CS() As String
        Return ""
    End Function

    Public Function LogOut_CS() As String
        Return ""
    End Function

    Public Function PreRender_CS() As String
        Return ""
    End Function

#End Region

#Region "Materialize"
    Public Function Privacy_Materialize() As String
        Dim r = "..."
        Return FormatForHTML(r)
    End Function
    Public Function TermsAndConditions_Materialize() As String
        Dim r = "..."
        Return FormatForHTML(r)
    End Function

    Public Function DeclareCSS_Materialize() As String
        Return "<link href=""~/images/icon/favicon.png"" rel=""shortcut icon"" type=""image/x-icon"" />
				<link rel=""stylesheet"" type=""text/css"" href=""fonts/font-awesome-4.7.0/css/font-awesome.min.css"" />
				<link rel=""stylesheet"" href=""css/materialize/materialize.min.css"" />

				<link rel=""stylesheet"" href=""css/inovation/_style.css"">"
    End Function

    Public Function DeclareJS_Materialize() As String
        Return "<script src=""js/jquery-3.2.1.min.js""></script>
					<script type=""text/javascript"" src=""js/materialize.min.js""></script>
				
					<%--required for materialize componenets--%>
					<script type=""text/javascript"">
						M.AutoInit();
					</script>

					<script type=""text/javascript"">
						function ScrollToDIV(div_) {
							div_.scrollIntoView({ behavior: 'smooth', block: 'center' });
						}
					</script>" _
                &
               "<script src=""js/functions/Alert.js""></script>
				<script src=""js/functions/CustomFunctions.js""></script>
				<script src=""js/functions/MakeCall.js""></script>
				<script src=""js/functions/AppSpecific.js""></script>
				<script src=""js/timers/Notify_.js""></script>"
    End Function
    Public Function NewPage_Materialize() As String
        Return "<div class=""container"">
					<div class=""row"">
						<div class=""col s12"">

						</div>
					</div>
				</div>"
    End Function

    Public Function NewHTML_Materialize()
        If fields__ Is Nothing Then Return ""
        Dim r As String = ""

        With fields__
            For i = 0 To .Length - 1
                r &= "<div class=""row"">
						<div class=""input-field col s12"">
							<asp:TextBox ID=""t" & fields__(i).ToString & """ runat=""server"" placeholder=""" & fields__(i).ToString & " Here"" ReadOnly=""false"" TextMode=""SingleLine"" style=""text-transform:none"" ValidationGroup=""default""></asp:TextBox>
							<%--<asp:DropDownList ID=""d" & fields__(i).ToString & """ runat=""server"" ValidationGroup=""default""></asp:DropDownList>
							<asp:CheckBox ID=""h" & fields__(i).ToString & """ runat=""server"" Text=""" & fields__(i).ToString & """ ValidationGroup=""default"" />--%>

							<label for=""control_id_here"">" & fields__(i).ToString & "</label>

							<%--<asp:FileUpload ID=""f" & fields__(i).ToString & """ runat=""server"" ValidationGroup=""default"" />
							<asp:HyperLink ID=""hyperlink_" & fields__(i).ToString & """ runat=""server"">Link_Text_Here</asp:HyperLink>
							<asp:Button ID=""b" & fields__(i).ToString & """ runat=""server"" CausesValidation=""true"" Text=""Set " & fields__(i).ToString & """ CssClass=""btn"" ValidationGroup=""default"" />--%>
						</div>
					</div>"
            Next
        End With
        Return FormatForHTML(r)
    End Function
    Public Function Forgot_HTML_Materialize()
        Dim r = "<h3>Recover Password</h3>
			Enter your email. We'll send you how to reset your password.
			<br />
			<br />
			<br />

			<div class=""row"">
				<div id=""Form_"" runat=""server"">
					<!-- email -->
					<div class=""input-field col s6"">
						<asp:TextBox ID=""Email"" runat=""server"" TextMode=""Email""></asp:TextBox>
						<label for=""Email"">Email</label>
					</div>
					<div class=""input-field col s6"">
						<asp:RequiredFieldValidator runat=""server"" ControlToValidate=""Email"" CssClass=""text-danger"" ErrorMessage=""Enter your email."" />
					</div>
				</div>
			</div>

			<div class=""row"">
				<!-- validation -->
				<div class=""input-field col s12"">
					<span runat=""server"" id=""x"" visible=""false""></span>
				</div>
			</div>

			<div class=""row"">
				<!-- submit -->
				<div class=""input-field col s12"">
					<asp:Button runat=""server"" Text=""Send Link"" class=""btn"" ID=""bSend"" OnClick=""bSend_Click"" />
				</div>
			</div>

			<div class=""row"">
				<!-- confirmation -->
				<div class=""input-field col s12"">
					<span runat=""server"" id=""ConfirmationDIV"" visible=""false""></span>
				</div>
			</div>"
        Return FormatForHTML(r)
    End Function
    Public Function InputGroup_Materialize()
        Dim r As String = "<div class=""row"">
				<div class=""input-field col s6"">
					<asp:TextBox ID=""control_id_here"" runat=""server"" ReadOnly=""false"" TextMode=""SingleLine"" ValidationGroup=""default""></asp:TextBox>
					<%--<asp:DropDownList ID=""control_id_here"" runat=""server"" ValidationGroup=""default""></asp:DropDownList>
					<asp:CheckBox ID=""control_id_here"" runat=""server"" Text=""Control_Text_here"" ValidationGroup=""default"" />--%>

					<label for=""control_id_here"">Label_Text_Here</label>

					<%--<asp:FileUpload ID=""control_id_here"" runat=""server"" ValidationGroup=""default"" />
					<asp:HyperLink ID=""control_id_here"" runat=""server"" ValidationGroup=""default"">Link_Text_Here</asp:HyperLink>
					<asp:Button ID=""control_id_here"" runat=""server"" CausesValidation=""true"" Text=""OK"" CssClass=""btn"" ValidationGroup=""default"" />--%>
				</div>
				<div class=""input-field col s6"">
				</div>
			</div>"
        Return FormatForHTML(r)
    End Function

    Public Function Activated_HTML_Materialize()
        Dim r = "<div class=""container"">
				<div class=""row"">
					<div class=""col s12"">
						<blockquote>
							<h3>Account Activated</h3>
						</blockquote>
						<p>Thank you for registering with us. Your account has been activated. In the meantime, you can
							<asp:HyperLink ID=""login"" runat=""server"" NavigateUrl=""~/Account/Login""><u>lo</u>g<u> in here</u></asp:HyperLink>.</p>
					</div>
				</div>
			</div>

			<!-- data -->
			<div runat=""server"" visible=""false"">
				<asp:TextBox ID=""tUsername"" Visible=""false"" runat=""server""></asp:TextBox>
				<asp:TextBox ID=""tEmail"" Visible=""false"" runat=""server""></asp:TextBox>
				<asp:TextBox ID=""tName"" Visible=""false"" runat=""server""></asp:TextBox>
			</div>
			<script type=""text/javascript"" src=""js/materialize.min.js""></script>
			<script type=""text/javascript"">M.AutoInit();</script>
			<script type=""text/javascript"" src=""js/CallFunction.js""></script>"
        Return FormatForHTML(r)
    End Function
    Public Function Welcome_ActivateAccount_HTML_Materialize()
        Dim r = "<div class=""container"">
				<div class=""row"">
					<div class=""col s12"">
						<h3>Registration is almost complete.
						</h3>
						Email has been sent to your address. Please check your mailbox and follow the instruction in the email to complete the process.
					<br />
						<br />
						<br />
						<p>
							If you didn't see the email, press the button to re-send it.
						</p>
						<asp:Button ID=""bResend"" class=""btn btn-large"" runat=""server"" Text=""Re-send Mail"" OnClick=""bResend_Click"" />
					</div>
				</div>

			</div>

			<!-- data -->
			<div runat=""server"" visible=""false"">
				<asp:TextBox ID=""FullName"" Visible=""false"" runat=""server""></asp:TextBox>
				<asp:TextBox ID=""Email"" Visible=""false"" runat=""server""></asp:TextBox>
				<asp:TextBox ID=""Username"" Visible=""false"" runat=""server""></asp:TextBox>
			</div>

			<script type=""text/javascript"" src=""js/materialize.min.js""></script>
			<script type=""text/javascript"">M.AutoInit();</script>
			<script type=""text/javascript"" src=""js/CallFunction.js""></script>"
        Return FormatForHTML(r)
    End Function
    Public Function Header_Shop_Materialize() As String
        Dim r = "..."
        Return FormatForHTML(r)

    End Function
    Public Function Header_Materialize() As String
        Dim r = "<header>
            <div class=""navbar-fixed"">
                <nav>
                    <div class=""nav-wrapper"">
                        <a href=""#"" class=""brand-logo center""><i class=""material-icons"">settings_remote</i></a>
                        <asp:LoginView ID=""LoginView1"" runat=""server"" ViewStateMode=""Disabled"">
                            <AnonymousTemplate>
                                <ul class=""right"">
                                    <li><a href=""Account/Login.aspx"" class=""btn-floating btn-large""><i class=""material-icons"">lock</i></a></li>
                                </ul>
                            </AnonymousTemplate>
                            <LoggedInTemplate>
                                <ul class=""right"">
                                    <li>
                                        <asp:LoginStatus ID=""LoginStatus1"" cssclass=""btn-floating btn-large"" runat=""server"" LogoutAction=""RedirectToLoginPage"" LogoutPageUrl=""~/Default.aspx"" LogoutText=""<i class='material-icons'>power_settings_new</i>"" OnLoggingOut=""Unnamed_LoggingOut"" />
                                    </li>
                                </ul>
                            </LoggedInTemplate>

                        </asp:LoginView>

                    </div>
                </nav>
            </div>
        </header>"
        Return FormatForHTML(r)

    End Function
    Public Function Header_NoLogin_Materialize() As String
        Dim r As String = "<header>
					<div class=""navbar-fixed"">
						<nav>
							<div class=""nav-wrapper"">
								<a href=""default"" class=""brand-logo center""><i class=""fa fa-graduation-cap""
										aria-hidden=""true""></i>&nbsp;&nbsp;Company-name-here</a>
								<a href=""#"" data-target=""mobile"" class=""sidenav-trigger""><i class=""fa fa-navicon""
										aria-hidden=""true""></i></a>
								<ul class=""right"">
									<li><a href=""Account/Login.aspx""><i class=""fa fa-user""
												aria-hidden=""true""></i>&nbsp;&nbsp;&nbsp;Log
											in&nbsp;&nbsp;&nbsp;&nbsp;</a></li>
								</ul>
							</div>
						</nav>
					</div>
				</header>"
        Return FormatForHTML(r)
    End Function
    Public Function Main_Materialize() As String
        Dim r = "<main>

					<div class=""container"">
						<span id=""_Top"" style=""padding-top: 80px""></span>
						<asp:ContentPlaceHolder ID=""MainContent"" runat=""server"">
						</asp:ContentPlaceHolder>
						<div class=""fixed-action-btn"">
							<a onclick=""ScrollToDIV(_Top)"" class=""btn-floating btn-large"">
								<i class=""fa fa-angle-double-up"" aria-hidden=""true""></i>
							</a>
							<%--<ul>
								<li><a class=""btn-floating red""><i class=""material-icons"">insert_chart</i></a></li>
								<li><a class=""btn-floating yellow darken-1""><i class=""material-icons"">format_quote</i></a></li>
								<li><a class=""btn-floating green""><i class=""material-icons"">publish</i></a></li>
								<li><a class=""btn-floating blue""><i class=""material-icons"">attach_file</i></a></li>
							</ul>--%>
						</div>
					</div>
				</main>"
        Return FormatForHTML(r)
    End Function
    Public Function Footer_Materialize() As String

        Dim r As String = "						<footer class=""page-footer"">
							<div class=""container"">
								<div class=""row"">
									<div class=""col l6 s12"">
										<h5 class=""white-text""><span id=""_Company_Name"" runat=""server""></span></h5>
										<p class=""grey-text text-lighten-4"">
											<asp:HyperLink ID=""hyperLink_Address"" runat=""server""></asp:HyperLink>
										</p>
									</div>
									<div class=""col l4 offset-l2 s12"">
										<%--<h5 class=""white-text"">Links</h5>--%>
										<ul>
											<li>
												<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Phone"" runat=""server""></asp:HyperLink></li>
											<li>
												<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Email"" runat=""server""></asp:HyperLink></li>
											<li>
												<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Facebook"" runat=""server""></asp:HyperLink></li>
											<li>
												<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Twitter"" runat=""server""></asp:HyperLink></li>
											<li>
												<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Instagram"" runat=""server""></asp:HyperLink></li>
											<li>
												<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_WhatsApp"" runat=""server""></asp:HyperLink></li>
											<li>&nbsp;</li>
											<li><a class=""grey-text text-lighten-3"" href=""Legal.aspx"" target=""_blank""><i class=""fa fa-legal"" aria-hidden=""true""></i>&nbsp;&nbsp;Legal</a></li>
										</ul>
									</div>
								</div>
							</div>
							<div class=""footer-copyright"">
								<div class=""container"">
									Design by <a href=" & GetEnvironmentVariableForUser(EnvironmentVariableKey.defaultWebsite.ToString) & " target=""_blank"">" & GetEnvironmentVariableForUser(EnvironmentVariableKey.defaultCompanyName.ToString) & "</a> © <%: DateTime.Now.Year %>, All rights reserved.
					<%--<a class=""grey-text text-lighten-4 right"" href=""#!"">More Links</a>--%>
								</div>
							</div>
						</footer>"


        Return FormatForHTML(r)
    End Function
    Public Function CustomErrorHTML_Materialize()
        Dim r = "..."
        Return FormatForHTML(r)

    End Function
#End Region

#Region "EStore"
    Public Function EnquiryType_Enum_vb() As String
        Return "Public Enum EnquiryType
					Select_an_option = 0
					General_Enquiry = 1
					Report_Payment_Issue = 2
					Delivery = 3
					Privacy = 4
					Support = 5
					Marketing = 6
				End Enum"
    End Function
    Public Function EnquiryType_Enum_cs() As String
        Return ""
    End Function

    Public Function Privacy_EStore() As String
        Return "<section class=""section_padding"">
					<div class=""container"">

						<div class=""row"">
							<div class=""col-sm-12"" runat=""server"">
								<%: Get_EProxySiteNameFull %>, (""We"", the ""Company"") believe that privacy is important to the success and use of the Internet. This statement sets forth our policy and describes the practices that we will follow with respect to the privacy of the information of users of this site. Should you have any questions about this policy or our practices, please send an email to <a style=""color:green"" href='mailto:<%: get_eproxyemail %>'><%: get_eproxyemail %></a>.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>What Personal Information We Collect</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								The Company collects your personal information online when you voluntarily provide it to us. If you choose to register online, we ask you to provide limited personal information, such as your name, address, telephone number and/or email address. 
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>How to Review and Change Your Personal Information</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								If you register for an account on the website, you may review and change your personal information by logging into your account, then clicking on My Account from the menu.
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>How We Use Personal Information That We Collect Online</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								<u>Internal Uses</u>
								<br />
								We may use your personal information within the Company: (1) to process or collect payments for our service, (2) to conduct customer surveys; and (3) to contact you about the products and services that we offer.
						<br />
								<u>Disclosure of Personal Information to Third Parties</u>
								<br />
								We will not disclose any personal information to any third party (excluding our contractors to whom we may provide such information for the limited purpose of providing services to us and who are obligated to keep the information confidential), unless (1) you have authorized us to do so; (2) we are legally required to do so, for example, in response to a subpoena, court order or other legal process and/or, (3) it is necessary to protect our property rights related to this website. We also may share aggregate, non-personal information about website usage with unaffiliated third parties. This aggregate information does not contain any personal information about our users.
						<br />
								<u>Cookie Placement</u>
								<br />
								This Website, like many other commercial sites, may use a standard technology called ""cookies"" to collect information about how our site is used. Cookies were designed to help a website operator determine that a particular user had visited the site previously and thus save and remember any preferences that may have been set. We may use cookies to keep track of information about your current web browsing session which will be discarded as soon as you log out or close your web browser. This information also allows us to statistically monitor how many people are using our site and for what purpose. We may also make use of ““persistent Or memory based”” cookies, which remain on your computer’s hard drive until you delete them. Examples include our use of these cookies to pre-populate forms you complete on our website based on information you have previously provided to us, enable interest-based advertising and collect information about your web browsing history. Although you have the ability to modify your browser to either accept all cookies, notify you when a cookie is sent, or reject all cookies, it may not be possible to utilize our services if you reject cookies.
						<br />
								<u>IP Address</u>
								<br />
								We may collect your IP address to gather broad demographic information, to track your general visiting patterns (how many pages you view while at the website, downloads, etc).<%--; and for security and identification purposes which may be required, for example, when processing payments.--%>
						<br />
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>How We Protect Information Online</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								We exercise great care to protect your personal information. This includes, among other things, using industry standard techniques such as passwords and encryption. As a result, while we strive to protect your personal information, we cannot ensure or warrant the security of any information you transmit to us or receive from us. 
						<br />
								<br />
								In addition, we limit our employees’ and contractors' access to personal information. Only those employees and contractors with a business reason to know have access to this information. We educate our employees about the importance of maintaining confidentiality of customer information.
						<br />
								<br />
								We review our security arrangements from time to time as we deem appropriate.
			
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>


						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>How can you help protect your information?</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								If you are using our website for which you registered and chose a password, we recommend that you do not divulge your password to anyone. We will never ask you for your password in an unsolicited phone call or in an unsolicited email. Also remember to sign out of the website and close your browser window when you have finished your work. This is to ensure that others cannot access your personal information and correspondence if others have access to your computer.
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Links to Other Sites</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								We want to provide site visitors valuable information, services and products. Featured programs and other site content within our site may link our users to third party sites. The Company does not control and is not responsible for practices of any third-party websites.
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>


						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Note</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								From time to time, we may change this privacy statement. For example, as we update and improve our services, new features may require modifications to the privacy statement. Accordingly, please check back periodically.
						<br />
								<br />
								<br />
								Date: " & Now.ToLongDateString & "
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>


					</div>
				</section>"
    End Function
    Public Function TermsAndConditions_EStore() As String
        Return "<a name=""TheService"">&nbsp;</a>
				<section class=""section_padding"">
					<div class=""container"">
						<div class=""row"">
							<div class=""col-sm-12"" runat=""server"">
								Welcome to <%: Get_EProxy %> (the ""Site""). Please read these terms and conditions carefully before using this Site. By accessing or using the Site, you agree to be bound by these terms and conditions. The provision of information and services on the Site by the owners and operators of <%: Get_EProxy %> is subject to your agreement to the terms and conditions below.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>The Service</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								The owners and operators of the Site (""We"", the ""Company"") will provide you (""User"", ""Your""), through the Site, the ability to shop for products that We sell, order the products, and pay for the order (please see the <a href=""#payment"" style=""color: green"">Payment section</a> of this document); and We may deliver the products to you depending on the order. However, in the event that your products could not be delivered and you have made a payment toward the same, you will be refunded the amount stated on the order for the cost of delivery, and you will be required to pick your package at the nearest delivery point to you, which will be communicated to you via your account details, during the course of the delivery.
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Modifications to Service</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								Features, specifications and payment rates of any product or service described or depicted on the Site are subject to change at any time without notice.
							</div>
						</div>

						<%--<div class=""col-sm-12 _line_break""></div>
						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Disclaimer of Content</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								While We attempt to keep all the information on the Site up-to-date and accessible to the User via the Site, We make no representation or warranty for any content uploaded to or transmitted via the Site. We are not responsible for the conduct, whether offline or online, of any User of the Site.
							</div>
						</div>--%>

						<div class=""col-sm-12 _line_break""><a name=""payment"">&nbsp;</a></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Copyright, Trademarks and other Intellectual Property</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								<%: Get_EProxy %> is owned by <%: Get_EProxySiteNameFull %>, <%: Get_EProxycity %>, <%: Get_EProxycountry %>. None of the names, trademarks, service marks and logos of <%: Get_EProxySiteNameFull %> appearing on this Site may be used in any advertising or publicity, or otherwise to indicate <%: Get_EProxySiteNameFull %>' sponsorship of or affiliation with any product or service without express written permission of the Company. Nothing contained on the Site should be construed as granting, by implication, estoppel, waiver or otherwise, any license or right of use to any trademark displayed on the Site without the written permission of the owners and operators of <%: Get_EProxy %> or the third party owner of the trademark, if any.
						<br />
								<br />
								This Site may contain other proprietary notices and copyright information, the terms of which must be observed and followed.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Payment</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								Any payment made for an order (except in the event of a failed delivery, as described in the <a href=""#TheService"" style=""color: green"">The Service</a> section of this document), is non-refundable, and all transactions are final. However, you can alert us to any payment issue via the <a href=""Contact.aspx?reference=PaymentIssue"" target=""_blank"" style=""color: green"">Report a Payment Issue</a> section of the Site.
						<br />
								<br />
								DISCLAIMER: The payment facility integrated into the Site is provided on an ""as-is"" and ""as-available"" basis, for convenience only, and in some cases may attract additional charges. In no event shall the Company or its representatives, contractors or affilliates be liable for any direct or indirect damages or loss arising in connection with the use or lack of use of the payment facility.
							</div>
						</div>
						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Right to Change Terms and Conditions</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								We may, at any time and from time to time, change these terms and conditions. Any changes to these terms and conditions will be effective immediately upon posting of the changed terms and conditions on the Site. You agree to review these terms and conditions periodically, and use of the Site or Service following any such change constitutes your agreement to follow and be bound by the terms and conditions as changed.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Links to Other Sites</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								This Site may contain third party-owned content (e.g., articles, data feeds, abstracts, etc.) and may also include hypertext links to third party-owned web sites. We provide such third party content and links as a courtesy to our users. We have no control over any third party-owned web sites or content referenced, accessed by or available on this Site and, therefore, We do not endorse, sponsor, recommend or otherwise accept any responsibility for such third party web sites or content or for the availability of such web sites. IN PARTICULAR, WE DO NOT ACCEPT ANY LIABILITY ARISING OUT OF ANY ALLEGATION THAT ANY THIRD PARTY-OWNED CONTENT (WHETHER PUBLISHED ON THIS, OR ANY OTHER, WEB SITE) INFRINGES THE INTELLECTUAL PROPERTY RIGHTS OF ANY PERSON OR ANY LIABILITY ARISING OUT OF ANY INFORMATION OR OPINION CONTAINED ON SUCH THIRD PARTY WEB SITE OR CONTENT.
						<br />
								<br />
								If you link to third party sites from this Site, we encourage you to consult the policy statements of each site you visit.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Disclaimer of Warranty; Limitation of Liability</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								The Company is not responsible for any interruption, delay in operation or transmission, error, deletion, omission, communications failure, theft or destruction or unauthorized access to any user. The Company is not responsible for any problems or technical errors of any telephone network, online service, servers or providers, software, computer equipment, email systems, technical problems or congestion or service interruptions on the internet or any web site or combination thereof. 
						<br />
								<br />
								THE COMPANY DISCLAIMS ALL EXPRESS AND IMPLIED WARRANTIES WITH REGARD TO THE INFORMATION AND SERVICE CONTAINED ON THIS SITE, INCLUDING, WITHOUT LIMITATION, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. YOUR USE OF THIS SITE AND SERVICE IS AT YOUR OWN RISK. ACCESS TO THIS SITE MAY BE INTERRUPTED AND INFORMATION AND SERVICE MAY NOT BE ERROR-FREE. NONE OF THE COMPANY, ITS SUPPLIERS, CONTRACTORS OR ANYONE ELSE INVOLVED IN CREATING, PRODUCING OR DELIVERING THIS SITE OR THE INFORMATION, SERVICE AND MATERIALS CONTAINED HEREIN ASSUMES ANY LIABILITY OR RESPONSIBILITY FOR THE ACCURACY, COMPLETENESS OR USEFULNESS OF ANY INFORMATION, SERVICE AND MATERIALS PROVIDED ON THIS SITE; THEY ALSO SHALL NOT BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, CONSEQUENTIAL OR PUNITIVE DAMAGES ARISING OUT OF YOUR USE OF, OR INABILITY TO USE, THIS SITE. ALL INFORMATION, SERVICE AND MATERIALS ARE PROVIDED ""AS IS"" AND ""AS AVAILABLE"" WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED.
						<br />
								<br />
								YOU ACKNOWLEDGE AND AGREE THAT THE LIMITATIONS SET FORTH ABOVE ARE FUNDAMENTAL ELEMENTS OF THIS AGREEMENT AND THIS SITE WOULD NOT BE PROVIDED TO YOU ABSENT SUCH LIMITATIONS.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Privacy Policy</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								The Company will treat as confidential all information submitted by you or other visitors to the Site, in accordance with the Company's <a href=""Privacy.aspx"" title=""Our Privacy Policy"" style=""color: green"" target=""_blank"">Privacy Policy</a>. The purpose of our privacy policy is to identify the information We collect online, the steps We take to protect it and your choices regarding how that information is used.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Indemnification</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								You agree to indemnify, defend and hold harmless the Company and its suppliers, contractors and their respective affiliates, employees, officers, directors, agents, servants and representatives of each from any liability, loss, claim, suit, damage, and expense (including reasonable attorneys´ fees and expenses) related to your violation of these terms and conditions.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Applicable Law</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								These terms and conditions and the resolution of any dispute related to these terms and conditions shall be construed in accordance with the laws of the state of <%: get_eproxystate %>, <%: Get_EProxyCountry %>. Any dispute between the Company and you related to these terms and conditions shall be resolved exclusively by the state and federal courts of <%: Get_EProxyState %>.
						<br />
								<br />
								In the event that any portion of these terms and conditions is deemed by a court of <%: Get_EProxyState %> to be invalid, the remaining provisions shall remain in full force and effect. 
						<br />
								<br />
								You agree that regardless of any statute or law to the contrary, any claim or cause of action arising out of or related to the Site, must be filed within one year after such claim or cause of action arose.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Termination</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								These terms and conditions are effective unless and until modified as noted above, or terminated, at any time  by the Company, or by you (through the My Account page of your account on the Site), upon which, all data associated with your account will be deleted immediately.
						<br />
								<br />
								If, in the sole discretion of the Company, you fail to comply with these terms and conditions, the Company may terminate these terms and conditions without notice and deny you access to the Site.
							</div>
						</div>

						<div class=""col-sm-12 _line_break""></div>

						<div class=""row"">
							<div class=""col-sm-12 col-md-3"" runat=""server"">
								<h4>Contact Information</h4>
							</div>
							<div class=""col-sm-12 col-md-9"" runat=""server"">
								<%: Get_EProxySiteNameFull %>
								<br />
								<%: Get_EProxyaddress %>
								<br />
								<br />
								<%: Get_EProxyPhone %>
								<br />
								<br />
								<asp:HyperLink ID=""hyperlink_Email"" runat=""server""></asp:HyperLink>
								<br />
								<br />
								<%--Specific questions and comments should be directed to the appropriate department via email.<br /><br />--%>
								While we make every effort to respond to all emails within 1 business week, we cannot guarantee a response to every electronic communication.
							</div>
						</div>
					</div>
				</section>

			    <%--With hyperlink_Email
						.NavigateUrl = ""mailto:"" & Get_EProxyEmail()
						.Text = Get_EProxyEmail()
						.Style.Add(""color"", ""green"")
				    End With--%>"
    End Function
    Public Function DeclareCSS_EStore() As String
        Return "<link href=""images/icon/favicon.png"" rel=""shortcut icon"" type=""image/x-icon"" />
				<link rel=""stylesheet"" href=""assets/css/bootstrap.min.css"">
				<link rel=""stylesheet"" href=""assets/css/owl.carousel.min.css"">
				<link rel=""stylesheet"" href=""assets/css/flaticon.css"">
				<link rel=""stylesheet"" href=""assets/css/slicknav.css"">
				<link rel=""stylesheet"" href=""assets/css/animate.min.css"">
				<link rel=""stylesheet"" href=""assets/css/magnific-popup.css"">
				<!--<link rel=""stylesheet"" href=""assets/css/fontawesome-all.min.css"">-->
				<link rel=""stylesheet"" href=""assets/css/themify-icons.css"">
				<link rel=""stylesheet"" href=""assets/css/slick.css"">
				<link rel=""stylesheet"" href=""assets/css/nice-select.css"">
				<link rel=""stylesheet"" href=""assets/css/style.css"">

				<link rel=""stylesheet"" type=""text/css"" href=""fonts/font-awesome-4.7.0/css/font-awesome.min.css"" />
				<link rel=""stylesheet"" href=""css/inovation/_style.css"">"

    End Function
    Public Function DeclareJS_EStore() As String
        Return "<!-- JS here -->
				<script src=""js/functions/Alert.js""></script>
				<script src=""js/functions/CallFunction.js""></script>
				<script src=""js/functions/MakeCall.js""></script>
				<script src=""js/functions/AppSpecific.js""></script>
				<script src=""js/timers/Notify_.js""></script>
				<script type=""text/javascript"">
					function ScrollToDIV(div_)
					{
						div_.scrollIntoView({ behavior: 'smooth', block: 'center' });
					}
				</script>

				<!-- All JS Custom Plugins Link Here here -->
				<script src=""./assets/js/vendor/modernizr-3.5.0.min.js""></script>
				<!-- Jquery, Popper, Bootstrap -->
				<script src=""./assets/js/vendor/jquery-1.12.4.min.js""></script>
				<script src=""./assets/js/popper.min.js""></script>
				<script src=""./assets/js/bootstrap.min.js""></script>
				<!-- Jquery Mobile Menu -->
				<script src=""./assets/js/jquery.slicknav.min.js""></script>

				<!-- Jquery Slick , Owl-Carousel Plugins -->
				<script src=""./assets/js/owl.carousel.min.js""></script>
				<script src=""./assets/js/slick.min.js""></script>

				<!-- One Page, Animated-HeadLin -->
				<script src=""./assets/js/wow.min.js""></script>
				<script src=""./assets/js/animated.headline.js""></script>
				<script src=""./assets/js/jquery.magnific-popup.js""></script>

				<!-- Scrollup, nice-select, sticky -->
				<script src=""./assets/js/jquery.scrollUp.min.js""></script>
				<script src=""./assets/js/jquery.nice-select.min.js""></script>
				<script src=""./assets/js/jquery.sticky.js""></script>

				<!-- contact js -->
				<script src=""./assets/js/contact.js""></script>
				<script src=""./assets/js/jquery.form.js""></script>
				<script src=""./assets/js/jquery.validate.min.js""></script>
				<script src=""./assets/js/mail-script.js""></script>
				<script src=""./assets/js/jquery.ajaxchimp.min.js""></script>

				<!-- Jquery Plugins, main Jquery -->
				<script src=""./assets/js/plugins.js""></script>
				<script src=""./assets/js/main.js""></script>"
    End Function

    Public Function Preloader_EStore() As String
        Return "<!-- Preloader Start -->
				<div id=""preloader-active"">
					<div class=""preloader d-flex align-items-center justify-content-center"">
						<div class=""preloader-inner position-relative"">
							<div class=""preloader-circle""></div>
							<div class=""preloader-img pere-text"">
								<img src=""images/logo/logo.png"" alt=""Company Logo"">
								<%-- <asp:Image ID=""image_logo_preloader"" runat=""server"" AlternateText=""Company Logo"" /> --%>
							</div>
						</div>
					</div>
				</div>
				<!-- Preloader End -->"
    End Function

    Public Function Header_EStore() As String
        Dim r = "<header>
					<!-- Header Start -->
					<div class=""header-area"">
						<div class=""main-header "">
							<div class=""header-top top-bg d-none d-lg-block"">
								<div class=""container-fluid"">
									<div class=""col-xl-12"">
										<div class=""row d-flex justify-content-between align-items-center"">
											<div class=""header-info-left d-flex"">
												<div class=""flag"">
													<img src=""assets/img/icon/header_icon.png"" alt="""" style=""width: 27px; height: 27px"">
												</div>
												<div class=""select-this"">
													<div class=""select-itms"">
														<select name=""select"" id=""select1"">
															<option value="""">NIGERIA</option>
														</select>
													</div>
												</div>
												<ul class=""contact-now"">
													<li><%: GetPhone %></li>
												</ul>
											</div>
											<div class=""header-info-right"">
												<ul>
													<li>
														<asp:HyperLink ID=""hyperlink_Welcome"" runat=""server"">Welcome, <span id=""_welcome"" runat=""server""></span>!</asp:HyperLink>
													</li>
													<li>
														<asp:HyperLink ID=""hyperlink_MyAccount"" NavigateUrl=""~/Account/Manage"" runat=""server"">My Account</asp:HyperLink></li>
													<li>
														<asp:HyperLink ID=""hyperlink_Cart"" NavigateUrl=""~/Space/Cart"" runat=""server"">Cart</asp:HyperLink></li>
													<li>
														<asp:HyperLink ID=""hyperlink_Checkout"" NavigateUrl=""~/Space/Checkout"" runat=""server"">Checkout</asp:HyperLink></li>
													<li id=""li_LogOut"" runat=""server""><a href=""#"" runat=""server"" id=""a_LogOut"" onserverclick=""a_LogOut_ServerClick"">Log out</a></li>
												</ul>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class=""header-bottom  header-sticky"">
								<div class=""container-fluid"">
									<div class=""row align-items-center"">
										<!-- Logo -->
										<div class=""col-xl-1 col-lg-1 col-md-1 col-sm-3"">
											<div class=""logo"">
												<img src=""images/logo/logo.png"" alt=""Company Logo"" Style=""width: 102px; height: 23px"">
												<%-- <asp:Image ID=""image_logo_header"" runat=""server"" AlternateText=""Company Logo"" Style=""width: 102px; height: 23px"" /> --%>
											</div>
										</div>
										<div class=""col-xl-6 col-lg-8 col-md-7 col-sm-5"">
											<!-- Main-menu -->
											<div class=""main-menu f-right d-none d-lg-block"">
												<nav>
													<ul id=""navigation"">
														<li>
															<asp:HyperLink ID=""hyperlink_Home"" NavigateUrl=""~/Default"" runat=""server"">Home</asp:HyperLink></li>
														<li>
															<asp:HyperLink ID=""hyperlink_Shop"" NavigateUrl=""~/Shop"" runat=""server"">Shop</asp:HyperLink></li>
														<li>
															<asp:HyperLink ID=""hyperlink_Contact"" NavigateUrl=""~/Contact"" runat=""server"">Contact</asp:HyperLink></li>
													</ul>
												</nav>
											</div>
										</div>
										<div class=""col-xl-5 col-lg-3 col-md-3 col-sm-3 fix-card"">
											<ul class=""header-right f-right d-none d-lg-block d-flex justify-content-between"">
												<li class=""d-none d-xl-block"">
													<div class=""form-box f-right "">
														<input type=""text"" name=""Search"" placeholder=""Search products"">
														<div class=""search-icon"">
															<i class=""fas fa-search special-tag""></i>
														</div>
													</div>
												</li>
												<li class=""d-none d-lg-block"" id=""li_SignIn"" runat=""server""><a href=""account/login"" class=""btn header-btn"">Sign in</a></li>
											</ul>
										</div>
										<!-- Mobile Menu -->
										<div class=""col-12"">
											<div class=""mobile_menu d-block d-lg-none""></div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- Header End -->
				</header>"
        Return FormatForHTML(r)
    End Function
    Public Function Main_EStore() As String
        Return "<main>
					<asp:ContentPlaceHolder ID=""MainContent"" runat=""server"">
					</asp:ContentPlaceHolder>
				</main>"
    End Function
    Public Function Footer_EStore() As String
        Dim r = "<footer>
					<!-- Footer Start-->
					<div class=""footer-area footer-padding"">
						<div class=""container"">
							<div class=""row d-flex justify-content-between"">
								<div class=""col-xl-3 col-lg-3 col-md-5 col-sm-6"">
									<div class=""single-footer-caption mb-50"">
										<div class=""single-footer-caption mb-30"">
											<!-- logo -->
											<div class=""footer-logo"">
												<img src=""images/logo/logo.png"" alt=""Company Logo"" Style=""width: 102px; height: 23px"">												
												<%-- <asp:Image ID=""image_logo_footer"" runat=""server"" AlternateText=""Company Logo"" Style=""width: 102px; height: 23px"" /> --%>
											</div>
											<div class=""footer-tittle"">
												<div class=""footer-pera"">
												</div>
											</div>
										</div>
									</div>
								</div>
								<div class=""col-xl-2 col-lg-3 col-md-3 col-sm-5"">
									<div class=""single-footer-caption mb-50"">
										<div class=""footer-tittle"">
											<h4>Quick Links</h4>
											<ul>
												<li>
													<asp:HyperLink ID=""hyperlink_About"" NavigateUrl=""~/About"" runat=""server"">About</asp:HyperLink></li>
												<li>
													<asp:HyperLink ID=""hyperlink_Contact_Footer"" runat=""server"">Contact Us</asp:HyperLink></li>
											</ul>
										</div>
									</div>
								</div>
								<div class=""col-xl-3 col-lg-3 col-md-4 col-sm-7"">
									<div class=""single-footer-caption mb-50"">
										<div class=""footer-tittle"">
											<h4>New Products</h4>
											<ul>
												<li><a href=""#"">Woman Cloth</a></li>
												<li><a href=""#"">Fashion Accessories</a></li>
												<li><a href=""#"">Man Accessories</a></li>
												<li><a href=""#"">Rubber made Toys</a></li>
											</ul>
										</div>
									</div>
								</div>
								<div class=""col-xl-3 col-lg-3 col-md-5 col-sm-7"">
									<div class=""single-footer-caption mb-50"">
										<div class=""footer-tittle"">
											<h4>Support</h4>
											<ul>
												<%--<li><asp:HyperLink ID=""hyperlink_FAQ"" NavigateUrl=""~/FAQ"" runat=""server"">Frequently Asked Questions</asp:HyperLink></li>--%>
												<li>
													<asp:HyperLink ID=""hyperlink_Terms"" NavigateUrl=""~/Terms"" runat=""server"">Terms & Conditions</asp:HyperLink></li>
												<li>
													<asp:HyperLink ID=""hyperlink_Privacy"" NavigateUrl=""~/Privacy"" runat=""server"">Privacy Policy</asp:HyperLink></li>
												<li>
													<asp:HyperLink ID=""hyperlink_ReportPaymentIssue"" runat=""server"">Report a Payment Issue</asp:HyperLink></li>
											</ul>
										</div>
									</div>
								</div>
							</div>
							<!-- Footer bottom -->
							<div class=""row"">
								<div class=""col-xl-7 col-lg-7 col-md-7"">
									<div class=""footer-copy-right"">
										<p>© <%: DateTime.Now.Year %> <%: GetSiteNameFull %>, All rights reserved.</p>
									</div>
								</div>
								<div class=""col-xl-5 col-lg-5 col-md-5"">
									<div class=""footer-copy-right f-right"">
										<!-- social -->
										<div class=""footer-social"">
											<asp:HyperLink ID=""hyperlink_Twitter"" runat=""server""><i class=""fab fa-twitter""></i></asp:HyperLink>
											<asp:HyperLink ID=""hyperlink_Facebook"" runat=""server""><i class=""fab fa-facebook-f""></i></asp:HyperLink>
											<asp:HyperLink ID=""hyperlink_Instagram"" runat=""server""><i class=""fab fa-instagram""></i></asp:HyperLink>
											<asp:HyperLink ID=""hyperlink_WhatsApp"" runat=""server""><i class=""fab fa-whatsapp""></i></asp:HyperLink>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- Footer End-->
				</footer>"
        Return FormatForHTML(r)
    End Function

    Public Function Default_EStore(no_of_items As Integer) As String
        Dim r As String = ""
        Dim feature_ As String = "<!-- slider Area Start -->
									<div class=""slider-area "">
										<!-- Mobile Menu -->
										<div class=""slider-active"">
											<div class=""single-slider slider-height"" data-background=""assets/img/hero/h1_hero.jpg"">
												<div class=""container"">
													<div class=""row d-flex align-items-center justify-content-between"">
														<div class=""col-xl-6 col-lg-6 col-md-6 col-sm-6 d-none d-md-block"">
															<div class=""hero__img"" data-animation=""bounceIn"" data-delay="".4s"">
																<img src=""assets/img/hero/hero_man.png"" alt="""">
															</div>
														</div>
														<div class=""col-xl-5 col-lg-5 col-md-5 col-sm-8"">
															<div class=""hero__caption"">
																<span data-animation=""fadeInRight"" data-delay="".4s"">Discount_Text_Here</span>
																<h1 data-animation=""fadeInRight"" data-delay="".6s"">Main_Text_Line1_Here <br> Main_Text_Continuation_Here</h1>
																<div class=""hero__btn"" data-animation=""fadeInRight"" data-delay=""1s"">
																	<a class=""btn hero-btn"" href=""#"">Button_Text_Here</a>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
											<!-- Desktop Menu -->
											<div class=""single-slider slider-height"" data-background=""assets/img/hero/h1_hero.jpg"">
												<div class=""container"">
													<div class=""row d-flex align-items-center justify-content-between"">
														<div class=""col-xl-6 col-lg-6 col-md-6 col-sm-6 d-none d-md-block"">
															<div class=""hero__img"" data-animation=""bounceIn"" data-delay="".4s"">
																<img src=""assets/img/hero/hero_man.png"" alt="""">
															</div>
														</div>
														<div class=""col-xl-5 col-lg-5 col-md-5 col-sm-8"">
															<div class=""hero__caption"">
																<span data-animation=""fadeInRight"" data-delay="".4s"">Discount_Text_Here</span>
																<h1 data-animation=""fadeInRight"" data-delay="".6s"">Main_Text_Line1_Here <br> Main_Text_Continuation_Here</h1>
																<div class=""hero__btn"" data-animation=""fadeInRight"" data-delay=""1s"">
																	<a class=""btn hero-btn"" href=""#"">Button_Text_Here</a>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
									<!-- slider Area End-->"

        r &= feature_

        Dim categories_top As String = "<!-- Category Area Start-->
										<section class=""category-area section-padding30"">
											<div class=""container-fluid"">
												<!-- Section Tittle -->
												<div class=""row"">
													<div class=""col-lg-12"">
														<div class=""section-tittle text-center mb-85"">
															<h2>Sections_Text_Here</h2>
														</div>
													</div>
												</div>
												<div class=""row"">"

        r &= categories_top

        Dim categories_content As String = ""
        For i = 1 To no_of_items
            categories_content &= "<div class=""col-xl-4 col-lg-6"">
					<div class=""single-category mb-30"">
						<div class=""category-img"">
							<%--<img src=""images/categories/image.jpg"" alt="""">
							<asp:Image ID=""image_for_category_" & i + 1 & """ runat=""server"" ImageUrl=""handler_image.ashx?reference=_category_"" />--%>
							<video src=""filename_here.mp4"" controls></video>
							<div class=""category-caption"">
								<h2>category_name_here</h2>
							</div>
						</div>
					</div>
				</div>"
        Next
        r &= categories_content

        Dim categories_close As String = "</div>
										</div>
									</section>
									<!-- Category Area End-->"
        r &= categories_close


        Dim shopping_method As String = "<!-- Shop Method Start-->
										<div class=""shop-method-area section-padding30"">
											<div class=""container"">
												<div class=""row d-flex justify-content-between"">
													<div class=""col-xl-3 col-lg-3 col-md-6"">
														<div class=""single-method mb-40"">
															<i class=""fa fa-user"" aria-hidden=""true""></i>
															<h6>Heading_Here</h6>
															<p>Content_Here</p>
														</div>
													</div>
													<div class=""col-xl-3 col-lg-3 col-md-6"">
														<div class=""single-method mb-40"">
															<i class=""fa fa-user"" aria-hidden=""true""></i>
															<h6>Heading_Here</h6>
															<p>Content_Here</p>
														</div>
													</div>
													<div class=""col-xl-3 col-lg-3 col-md-6"">
														<div class=""single-method mb-40"">
															<i class=""fa fa-user"" aria-hidden=""true""></i>
															<h6>Heading_Here</h6>
															<p>Content_Here</p>
														</div>
													</div>
												</div>
											</div>
										</div>
										<!-- Shop Method End-->"
        r &= shopping_method

        Return FormatForHTML(r)
    End Function

    Public Function Login_EStore()
        Dim r = "<!-- slider Area Start-->
				<div class=""slider-area "">
					<!-- Mobile Menu -->
					<div class=""single-slider slider-height2 d-flex align-items-center"" data-background=""assets/img/hero/category.jpg"">
						<div class=""container"">
							<div class=""row"">
								<div class=""col-xl-12"">
									<div class=""hero-cap text-center"">
										<h2>Login</h2>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<!-- slider Area End-->

				<!--================login_part Area =================-->
				<section class=""login_part section_padding "">
					<div class=""container"">
						<div class=""row align-items-center"">
							<div class=""col-lg-6 col-md-6"">
								<div class=""login_part_text text-center"">
									<div class=""login_part_text_iner"">
										<h2>New to our Shop?</h2>
										<p>We add new products daily!</p>
										<asp:HyperLink class=""btn_3"" ID=""hyperlink_Register"" NavigateUrl=""~/account/register"" runat=""server"">Create an Account</asp:HyperLink>
									</div>
								</div>
							</div>
							<div class=""col-lg-6 col-md-6"">
								<div class=""login_part_form"">
									<div class=""login_part_form_iner"">
										<h3>Welcome Back! <br>
											Please Sign in now</h3>
										<div class=""row contact_form"">
											<div class=""col-md-12 form-group p_star"">
												<asp:TextBox ID=""tUsername"" class=""form-control"" runat=""server"" placeholder=""Username or Email""></asp:TextBox>
											</div>
											<div class=""col-md-12 form-group p_star"">
												<asp:TextBox ID=""tPassword"" TextMode=""Password"" class=""form-control"" runat=""server"" placeholder=""Password""></asp:TextBox>
											</div>
											<div class=""col-md-12 form-group"">
												<div class=""creat_account d-flex align-items-center"">
													<asp:CheckBox ID=""hRememberMe"" runat=""server"" />
													<asp:Label AssociatedControlID=""hRememberMe"" ID=""Label1"" runat=""server"" Text=""Remember me""></asp:Label>
												</div>
												<div id=""_feedback_"" runat=""server""></div>
												<asp:Button ID=""bLogin"" class=""btn_3"" runat=""server"" Text=""LOG IN"" />
												<asp:HyperLink ID=""hyperlink_ForgotPassword"" class=""lost_pass"" runat=""server"">forgot password?</asp:HyperLink>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</section>
				<!--================login_part end =================-->"
        Return FormatForHTML(r)
    End Function

    Public Function NewHTML_EStore() As String
        Dim r = "<!-- slider Area Start-->
				<div class=""slider-area "">
					<!-- Mobile Menu -->
					<div class=""single-slider slider-height2 d-flex align-items-center"" data-background=""assets/img/hero/category.jpg"">
						<div class=""container"">
							<div class=""row"">
								<div class=""col-xl-12"">
									<div class=""hero-cap text-center"">
										<h2>Title_Here</h2>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<!-- slider Area End-->

				<%--feedback--%>
				<div Class=""_line_break"">
					<div Class=""container"">
						<div Class=""row"">
							<div Class=""col-sm-12"">
								<div id = ""_feedback_"" runat=""server""></div>
							</div>
						</div>
					</div>
				</div>

				<section class=""section_padding""></section>"
        Return FormatForHTML(r)
    End Function

    Public Function Contact_EStore() As String
        Dim r = "<!-- slider Area Start-->
				<div class=""slider-area "">
					<!-- Mobile Menu -->
					<div class=""single-slider slider-height2 d-flex align-items-center"" data-background=""assets/img/hero/category.jpg"">
						<div class=""container"">
							<div class=""row"">
								<div class=""col-xl-12"">
									<div class=""hero-cap text-center"">
										<h2>Contact Us</h2>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<!-- slider Area End-->

				<!-- ================ contact section start ================= -->
				<section class=""contact-section"">
					<div class=""container"">
						<div class=""d-none d-sm-block mb-5 pb-4"">
							map_here
						</div>


						<div class=""row"">
							<div class=""col-12"">
								<h2 class=""contact-title"">Get in Touch</h2>
							</div>
							<div class=""col-lg-8"">
								<div class=""form-contact contact_form"">
									<div class=""row"">
										<div class=""col-12"">
											<div class=""form-group"">
												<asp:TextBox CssClass=""form-control w-100"" ID=""tMessage"" TextMode=""MultiLine"" cols=""30"" rows=""9"" runat=""server"" placeholder="" Enter Message"" ValidationGroup=""contact""></asp:TextBox>
											</div>
										</div>
										<div class=""col-sm-6"">
											<div class=""form-group"">
												<asp:TextBox CssClass=""form-control"" placeholder=""Enter your name"" ID=""tName"" runat=""server"" ValidationGroup=""contact""></asp:TextBox>
											</div>
										</div>
										<div class=""col-sm-6"">
											<div class=""form-group"">
												<asp:TextBox CssClass=""form-control"" ID=""tEmail"" placeholder=""Enter your e-mail address"" TextMode=""Email"" runat=""server"" ValidationGroup=""contact""></asp:TextBox>
											</div>
										</div>
										<div class=""col-12"">
											<div class=""form-group"">
												<asp:DropDownList CssClass=""form-control"" ID=""dEnquiryType"" runat=""server"" ValidationGroup=""contact""></asp:DropDownList>
											</div>
										</div>
									</div>
									<div class=""form-group mt-3"">
										<asp:Button CssClass=""button button-contactForm boxed-btn"" ID=""bSend"" runat=""server"" Text=""Send"" ValidationGroup=""contact"" />
									</div>
								</div>
							</div>
							<div class=""col-lg-3 offset-lg-1"">
								<div class=""media contact-info"">
									<span class=""contact-info__icon""><i class=""ti-home""></i></span>
									<div class=""media-body"">
										<h3><%: Get_EProxyAddress(1) %></h3>
									</div>
								</div>
								<div class=""media contact-info"">
									<span class=""contact-info__icon""><i class=""ti-tablet""></i></span>
									<div class=""media-body"">
										<h3><%: Get_EProxyPhone(1) %></h3>
										<p><%: Get_EProxyHours(1) %></p>
									</div>
								</div>
								<div class=""media contact-info"">
									<span class=""contact-info__icon""><i class=""ti-email""></i></span>
									<div class=""media-body"">
										<h3><%: Get_EProxyEmail(1) %></h3>
										<p>Send us your enquiry anytime!</p>
									</div>
								</div>
							</div>
						</div>
					</div>
				</section>
				<!-- ================ contact section end ================= -->


				<%--dEnquiryType.DataSource = EnquiryTypeList
				dEnquiryType.DataBind()--%>"
        Return FormatForHTML(r)
    End Function

#End Region

#Region "Bootstrap"
    Public Function Privacy_Bootstrap() As String
        Return ""
    End Function
    Public Function TermsAndConditions_Bootstrap() As String
        Return ""
    End Function
    Public Function DeclareCSS_Bootstrap() As String
        Return "<link href=""~/images/icon/favicon.png"" rel=""shortcut icon"" type=""image/x-icon"" />
				<link rel=""stylesheet"" type=""text/css"" href=""fonts/font-awesome-4.7.0/css/font-awesome.min.css"" />
				<link rel=""stylesheet"" href=""css/bootstrap/bootstrap.min.css"">

				<link rel=""stylesheet"" href=""css/inovation/_style.css"">"
    End Function
    Public Function DeclareJS_Bootstrap() As String
        Return "<script src=""js/jquery-3.3.1.slim.min.js""></script>
				<script src=""js/popper.min.js""></script>
				<script src=""js/bootstrap.min.js""></script>" _
                &
               "<script src=""js/functions/Alert.js""></script>
				<script src=""js/functions/CallFunction.js""></script>
				<script src=""js/functions/MakeCall.js""></script>
				<script src=""js/functions/AppSpecific.js""></script>
				<script src=""js/timers/Notify_.js""></script>" _
               &
               "<script type=""text/javascript"">
						function ScrollToDIV(div_) {
							div_.scrollIntoView({ behavior: 'smooth', block: 'center' });
						}
					</script>"
    End Function
    Public Function NewPage_Bootstrap() As String
        Return "<div class=""container"">
					<div class=""row"">
						<div class=""col-sm-12"">

						</div>
					</div>
				</div>"
    End Function
    Public Function Forgot_HTML_Bootstrap()
        Return "<div class=""row"">
				<div class=""col col-sm-12"">
					<h3>Recover Password</h3>
					Enter your email. We'll send you how to reset your password.
					<br />
					<br />
					<br />
					<div id=""Form_"" runat=""server"">
						<!-- email -->
						<div class=""input-group mb-3"">
							<div class=""input-group-prepend"">
								<span class=""input-group-text"" id=""basic-addon3""><span><i class=""fa fa-envelope"" aria-hidden=""true""></i></span></span>
							</div>
							<asp:TextBox CssClass=""form-control"" ID=""Email"" runat=""server"" TextMode=""Email"" aria-label=""Email"" aria-describedby=""basic-addon3""></asp:TextBox>
							<asp:RequiredFieldValidator runat=""server"" ControlToValidate=""Email"" CssClass=""text-danger"" ErrorMessage=""Enter your email."" />
						</div>
						<!-- validation -->
						<div class=""form-group"">
							<span runat=""server"" id=""x"" visible=""false""></span>
						</div>
						<!-- submit -->
						<div class=""form-group"">
							<asp:Button runat=""server"" Text=""Send Link"" class=""btn btn-primary _button"" ID=""bSend"" OnClick=""bSend_Click"" />
						</div>
					</div>
					<!-- confirmation -->
					<div class=""form-group"">
						<span runat=""server"" id=""ConfirmationDIV"" visible=""false""></span>
					</div>
				</div>
				<%--<div class=""col col-sm-6""></div>--%>
			</div>

			<!-- data -->
			<div runat=""server"" visible=""false"">
				<asp:TextBox ID=""tFullName"" visible=""false"" runat=""server""></asp:TextBox>
				<asp:TextBox ID=""tEmail"" visible=""false"" runat=""server""></asp:TextBox>
				<asp:TextBox ID=""tUsername"" visible=""false"" runat=""server""></asp:TextBox>
				<asp:GridView ID=""gEmail_Check"" visible=""false"" runat=""server""></asp:GridView>
			</div>"
    End Function
    Public Function Header_Shop_Bootstrap() As String
        Return FormatForHTML("")
    End Function
    Public Function Header_Bootstrap() As String
        Dim r = "<nav runat=""server"" class=""navbar navbar-expand-lg navbar-dark bg-dark sticky-top"">
					<a class=""navbar-brand"" runat=""server"" href=""~/"">
						<img src=""images/Logo/Logo.gif"" alt=""Company logo"" title=""Company logo"" style=""height: 48px; width: auto"" />
					</a>
					<%--<a class=""navbar-brand"" runat=""server"" href=""~/""><span id=""_Brand_Name"" runat=""server""></span></a>--%>
					<button type=""button"" class=""navbar-toggler"" data-toggle=""collapse"" data-target=""#navbarSupportedContent"">
						<span><i class=""fa fa-th-large"" aria-hidden=""true""></i>&nbsp;&nbsp;Menu</span>
					</button>

					<asp:LoginView ID=""LoginView1"" runat=""server"" ViewStateMode=""Disabled"">
						<AnonymousTemplate>
							<ul class=""navbar-nav"">
								<li>
									<asp:HyperLink ID=""hyperlink_Login"" NavigateUrl=""~/Account/Login.aspx"" runat=""server"" class=""nav-link""><i class='fa fa-user' aria-hidden='true'></i></asp:HyperLink></li>
							</ul>
						</AnonymousTemplate>
						<LoggedInTemplate>
							<ul class=""navbar-nav"">
								<li class=""navbar-brand"">Welcome, <%: GetUserName %></li>
							</ul>
							<div id=""navbarSupportedContent"" class=""collapse navbar-collapse"">
								<ul class=""nav navbar-nav navbar-right"">
									<li class=""navbar-brand dropdown"">
										<a class=""nav-link dropdown-toggle"" href=""#"" id=""navbarDropdown"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false""><span><i class=""fa fa-thumb-tack"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Tasks</a>
										<div class=""dropdown-menu"" aria-labelledby=""navbarDropdown"">
											<a class=""dropdown-item"" href=""Collapse""><span><i class=""fa fa-flash"" aria-hidden=""true""></i></span>&nbsp;&nbsp;&nbsp;&nbsp;Profiles</a>
											<a class=""dropdown-item"" href=""Dropdowns""><span><i class=""fa fa-line-chart"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Statistics</a>
											<a class=""dropdown-item"" href=""Forms""><span><i class=""fa fa-send"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Delivery</a>
											<a class=""dropdown-item"" href=""InputGroup""><span><i class=""fa fa-info"" aria-hidden=""true""></i></span>&nbsp;&nbsp;&nbsp;&nbsp;VAT</a>
											<a class=""dropdown-item"" href=""Products""><span><i class=""fa fa-file"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Products</a>
											<a class=""dropdown-item"" href=""ListGroup""><span><i class=""fa fa-user"" aria-hidden=""true""></i></span>&nbsp;&nbsp;&nbsp;Accounts</a>
											<a class=""dropdown-item"" href=""MediaObject""><span><i class=""fa fa-shopping-cart"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Coupons</a>
											<a class=""dropdown-item"" href=""Modal""><span><i class=""fa fa-shopping-cart"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Sales</a>
											<a class=""dropdown-item"" href=""Navs""><span><i class=""fa fa-users"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Admins</a>
											<a class=""dropdown-item"" href=""Popovers""><span><i class=""fa fa-gears"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Settings</a>
										</div>
									</li>
									<li class=""navbar-brand"">
										<asp:LoginStatus ID=""LoginStatus1"" runat=""server"" class=""nav-link"" LogoutAction=""Redirect"" LogoutPageUrl=""~/Default.aspx"" LogoutText=""&nbsp;&nbsp;<span><i class='fa fa-power-off' aria-hidden='true'></i></span>"" OnLoggingOut=""Unnamed_LoggingOut"" />
									</li>
								</ul>
							</div>
						</LoggedInTemplate>
					</asp:LoginView>
				</nav>"
        Return FormatForHTML(r)
    End Function
    Public Function Header_NoLogin_Bootstrap() As String
        Dim r = ""
        Return FormatForHTML(r)
    End Function
    Public Function NewHTML_Bootstrap()
        If fields__ Is Nothing Then Return ""
        Dim r As String = ""

        With fields__
            For i = 0 To .Length - 1 ' 2 Step 2
                r &= "<div class=""form-row"">
						<div class=""col-sm-12 col-md-6 mb-3"">
							<label for=""control_id_here"">" & fields__(i).ToString & "</label>
							<div class=""input-group"">
								<div class=""input-group-prepend"">
									<span class=""input-group-text""><i class=""fa fa-user"" aria-hidden=""true""></i>&nbsp;&nbsp;" & fields__(i).ToString & "</span>
								</div>
								<asp:TextBox ID=""t" & fields__(i).ToString & """ runat=""server"" TextMode=""SingleLine"" ReadOnly=""false"" class=""form-control"" placeholder=""" & fields__(i).ToString & " Here"" style=""text-transform:none"" ValidationGroup=""default""></asp:TextBox>
								<%--<asp:DropDownList ID=""d" & fields__(i).ToString & """ runat=""server"" class=""custom-select"" ValidationGroup=""default""></asp:DropDownList>
								<asp:CheckBox ID=""h" & fields__(i).ToString & """ runat=""server"" Text=""" & fields__(i).ToString & """ ValidationGroup=""default"" />
								<asp:FileUpload ID=""f" & fields__(i).ToString & """ runat=""server"" ValidationGroup=""default"" />
								<asp:HyperLink ID=""hyperlink_" & fields__(i).ToString & """ runat=""server"">Link_Text_Here</asp:HyperLink>
								<asp:Button ID=""b" & fields__(i).ToString & """ runat=""server"" Text=""Set " & fields__(i).ToString & """ CssClass=""btn btn-primary btn-lg"" CausesValidation=""true"" ValidationGroup=""default"" />--%>
							</div>
						</div>
						<div class=""col-sm-12 col-md-6 mb-3"">
						</div>
					</div>"
            Next
        End With
        Return FormatForHTML(r)
    End Function
    Public Function InputGroup_Bootstrap()
        Dim r = " <div class=""form-row"">
				<div class=""col-sm-12 col-md-6 mb-3"">
					<label for=""control_id_here"">Label_Text_Here</label>
					<div class=""input-group"">
						<div class=""input-group-prepend"">
							<span class=""input-group-text""><i class=""fa fa-user"" aria-hidden=""true""></i></span>&nbsp;&nbsp;Label_Text_Here
						</div>
						<asp:TextBox ID=""control_id_here"" runat=""server"" TextMode=""SingleLine"" ReadOnly=""false"" class=""form-control"" placeholder=""placeholder_here"" ValidationGroup=""default""></asp:TextBox>
						<%--<asp:DropDownList ID=""control_id_here"" runat=""server"" class=""custom-select"" ValidationGroup=""default""></asp:DropDownList>
						<asp:CheckBox ID=""control_id_here"" runat=""server"" Text=""Label_Text_Here"" ValidationGroup=""default"" />
						<asp:FileUpload ID=""control_id_here"" runat=""server"" ValidationGroup=""default"" />
						<asp:HyperLink ID=""control_id_here"" runat=""server"" ValidationGroup=""default"">Link_Text_Here</asp:HyperLink>
						<asp:Button ID=""control_id_here"" runat=""server"" Text=""OK"" CssClass=""btn btn-primary btn-lg"" CausesValidation=""true"" ValidationGroup=""default"" />--%>
					</div>
				</div>
				<div class=""col-sm-12 col-md-6 mb-3"">
				</div>
			</div>"
        Return FormatForHTML(r)
    End Function
    Public Function Main_Bootstrap() As String
        Dim r = "<div class=""container body-content"" style=""padding-top: 35px"">
					<asp:ContentPlaceHolder ID=""MainContent"" runat=""server"">
					</asp:ContentPlaceHolder>
					<hr />
					<footer class=""text-center"">
						<h5><span id=""_Company_Name"" runat=""server""></span></h5>
						<asp:HyperLink ID=""hyperLink_Address"" runat=""server""></asp:HyperLink>
						<br />
						<br />
						<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Phone"" runat=""server""></asp:HyperLink>
						<br />
						<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_WhatsApp"" runat=""server""></asp:HyperLink>
						<br />
						<br />
						<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Email"" runat=""server""></asp:HyperLink>
						<br />
						<br />
						<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Facebook"" runat=""server""></asp:HyperLink>
						&nbsp;&nbsp;&middot;&nbsp;&nbsp;
						<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Twitter"" runat=""server""></asp:HyperLink>
						&nbsp;&nbsp;&middot;&nbsp;&nbsp;
						<asp:HyperLink class=""grey-text text-lighten-3"" ID=""hyperLink_Instagram"" runat=""server""></asp:HyperLink>
						<br />
						<br />
						Design by <a href=" & GetEnvironmentVariableForUser(EnvironmentVariableKey.defaultWebsite.ToString) & " target=""_blank"">" & GetEnvironmentVariableForUser(EnvironmentVariableKey.defaultCompanyName.ToString) & "</a> © <%: DateTime.Now.Year %>, All rights reserved.
					</footer>
				</div>"
        Return FormatForHTML(r)
    End Function
    Public Function CustomErrorHTML_Bootstrap() As String
        Return ""
    End Function

#End Region

#Region "JS"
    Public Function HTTP_JS() As String
        Return "function sendData(d)
				{
					const Http = new XMLHttpRequest();
					var url = ""https://domain.com/handler.ashx?value="" + d;
					Http.open(""GET"", url);
					Http.send();
				}
				function multipleData(url, data)
				{
					const Http = new XMLHttpRequest();
					//var url = ""http://domain.com/handler.ashx?value="" + d;
					Http.open(""GET"", url + data);
					Http.send();
				}"
    End Function


#End Region

#Region "Shoppy"
    Public Function DeclareJS_Shoppy() As String
        Return "<!--scrolling js-->
        <script src=""js/jquery.nicescroll.js""></script>
        <script src=""js/scripts.js""></script>
        <!--//scrolling js-->
        <script src=""js/bootstrap.js""></script>" _
                &
               "<script src=""js/functions/Alert.js""></script>
				<script src=""js/functions/CallFunction.js""></script>
				<script src=""js/functions/MakeCall.js""></script>
				<script src=""js/timers/Notify_.js""></script>" _
               &
               "<script type=""text/javascript"">
						function ScrollToDIV(div_) {
							div_.scrollIntoView({ behavior: 'smooth', block: 'center' });
						}
					</script>"

    End Function

    Public Function DeclareCSS_Shoppy() As String
        Return "<asp:PlaceHolder runat=""server"" ID=""shoppy_css"">
        <script type=""application/x-javascript"">
		addEventListener(""load"", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }
        </script>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <link href=""css/bootstrap.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />
        <!-- Custom Theme files -->
        <link href=""css/style.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />
        <!--js-->
        <script src=""js/jquery-2.1.1.min.js""></script>
        <!--icons-css-->
        <!--<link href=""css/font-awesome.css"" rel=""stylesheet"" />-->


		<link rel=""stylesheet"" type=""text/css"" href=""fonts/font-awesome-4.7.0/css/font-awesome.min.css"" />

        <!--Google Fonts-->
        <link href='//fonts.googleapis.com/css?family=Carrois+Gothic' rel='stylesheet' type='text/css' />
        <link href='//fonts.googleapis.com/css?family=Work+Sans:400,500,600' rel='stylesheet' type='text/css' />
        <!--//skycons-icons-->
        <!--button css-->
        <link href=""css/demo-page.css"" rel=""stylesheet"" media=""all"" />
        <link href=""css/hover.css"" rel=""stylesheet"" media=""all"" />
        <!--static chart-->
        <script src=""js/Chart.min.js""></script>
        <!--//charts-->
        <!-- geo chart
	<script src=""//cdn.jsdelivr.net/modernizr/2.8.3/modernizr.min.js"" type=""text/javascript""></script>
	rem removed-->
        <script src=""js/modernizr.min.js""></script>
        <!-- rem added  -->

        <script src=""lib/modernizr/modernizr-custom.js""></script>
        <!-- rem added  -->
        <script>
            window.modernizr || document.write('<script src=""lib/modernizr/modernizr-custom.js""><\/script>')
        </script>

        <!--<script src=""lib/html5shiv/html5shiv.js""></script>-->
        <!-- Chartinator  -->
        <script src=""js/chartinator.js""></script>
        <!--geo chart-->

        <!--skycons-icons-->
        <script src=""js/skycons.js""></script>
        <!--//skycons-icons-->
        <!--mapcss-->
        <link rel=""stylesheet"" type=""text/css"" href=""css/examples.css"" />
        <!--js-->
        <script type=""text/javascript"" src=""//maps.google.com/maps/api/js?sensor=true""></script>
        <script type=""text/javascript"" src=""js/gmaps.js""></script>
        <!--map-->
        <!--pop up strat here-->
        <script src=""js/jquery.magnific-popup.js"" type=""text/javascript""></script>
        <script>
            $(document).ready(function () {
                $('.popup-with-zoom-anim').magnificPopup({
                    type: 'inline',
                    fixedContentPos: false,
                    fixedBgPos: true,
                    overflowY: 'auto',
                    closeBtnInside: true,
                    preloader: false,
                    midClick: true,
                    removalDelay: 300,
                    mainClass: 'my-mfp-zoom-in'
                });

            });
        </script>


    </asp:PlaceHolder>



	<link rel=""stylesheet"" href=""css/inovation/_style.css"">"
    End Function

#End Region

#Region "Support Functions"
    Public Property control_is As String = "ASP"
    Private Function FormatForHTML(str) As String
        If control_is.ToLower = "asp" Then Return str
        '		asp:HyperLink
        '.aspx
        'asp:TextBox
        '</asp:TextBox>
        '<%--
        '--%>
        '~/

        Dim removed_hyperlink_string As String = "asp:HyperLink"
        Dim removed_aspx_string As String = ".aspx"
        Dim removed_begin_textbox_string As String = "asp:TextBox"
        Dim removed_end_textbox_string As String = "</asp:TextBox>"
        Dim removed_begin_comment_string As String = "<%--"
        Dim removed_end_comment_string As String = "--%>"
        Dim removed_tilde_string As String = "~/"


        Dim raw_ As String = str
        Dim removed_hyperlink As String = raw_.Replace(removed_hyperlink_string, "a href=""ref_here""")
        Dim removed_aspx As String = removed_hyperlink.Replace(removed_aspx_string, ".html")
        Dim removed_begin_textbox As String = removed_aspx.Replace(removed_begin_textbox_string, "input type=""text""")
        Dim removed_end_textbox As String = removed_begin_textbox.Replace(removed_end_textbox_string, "")
        Dim removed_begin_comment As String = removed_end_textbox.Replace(removed_begin_comment_string, "<!--")
        Dim removed_end_comment As String = removed_begin_comment.Replace(removed_end_comment_string, "-->")
        Dim removed_tilde As String = removed_end_comment.Replace(removed_tilde_string, "")

        Return removed_tilde.Replace("</input type=""text"">", "")

    End Function
#End Region
End Class

