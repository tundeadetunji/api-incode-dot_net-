
'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop

Public Class Snippets

#Region "Types"
	Public Structure ImportGroupToInclude
		Public Standard As Boolean
		Public Desktop As Boolean
		Public Web As Boolean
		Public Encryption As Boolean
		Public Statistics As Boolean
		Public Bank As Boolean
		Public Log As Boolean
		Public Email As Boolean
        Public Scanning As Boolean

    End Structure

#End Region

#Region "Other Members"
	Public Enum ImportGroup
		Standard
		Bank
		Desktop
		Web
		Log
		Statistics
		Email
		Encryption
	End Enum

	Public Enum ProgrammingLanguage
		CS
		VB
	End Enum

	Public Enum CSSFramework
		Bootstrap = 1
		EStore = 2
		Materialize = 3
		Shoppy = 4
	End Enum

	Public Enum ControlsFrom
		ASP = 1
		HTML = 2
	End Enum

	Public Enum Materialize
		Button = 1
		Card = 2
		Card_Reveal = 3
		Carousel = 4
		Carousel_Full_Width = 5
		Checkbox = 6
		Collapsible = 7
		Collection = 8
		Collection_With_Title_Secondary_Content = 9
		DropDownList = 10
		GridView = 11
		GridView_Cart = 12
		MaterialBox = 13
		Modal = 14
		Parallax = 15
		TextArea = 16
		TextBox = 17
		Tooltip = 18
		'		FormGroup
	End Enum

	Public Enum Bootstrap
		Badge = 1
		Button = 2
		Card = 3
		Carousel = 4
		Checkbox = 5
		Collapsible = 6
		Collection = 7
		DropDownList = 8
		FormGroup = 9
		GridView = 10
		GridView_Cart = 11
		Jumbotron = 12
		Modal = 13
		TextArea = 14
		TextBox = 15
	End Enum
	Public Enum EStore
		Blockquote = 1
		Carousel = 2
		ProgressBar = 3
		Table = 4
	End Enum

	Public Enum EStoreProgressBarColorIs
		blue = 1
		green = 2
		orange = 3
		purple = 4
		red = 5
	End Enum

	Public Enum EStoreTableCSSClass
		country = 1
		percentage = 2
		serial = 3
		visit = 4
	End Enum
	Public Enum All
		Image = 1
		UpdatePanel = 2
	End Enum

	Public Enum DropDownListStyle
		FrameworkDefault = 0
		Custom = 1
		Standard = 2
		None = 3
	End Enum

	Public Enum CarouselSize
		FullPage = 1
		Medium = 2
		Mini = 3
	End Enum

	Public Enum Border
		Arched = 1
		Circular = 2
		Flat = 3
	End Enum

	Public Enum DefaultColor
		Danger = 1
		Dark = 2
		Info = 3
		Light = 4
		Primary = 5
		Secondary = 6
		Success = 7
		Warning = 8
	End Enum

	Public Enum ButtonSize
		Block = 1
		Flat = 2
		Large = 3
		Small = 4
	End Enum

	Public Enum VB
		Database = 1
		FormLoad = 2
		Import = 3
		NewFile = 4
		NewForm = 5
		UI = 6
	End Enum
	Public Enum CS
		Import = 1
		NewFile = 2
	End Enum

	Public Enum INPUT
		audio = 0
		button = 1
		checkbox = 2
		color = 3
		date_ = 4
		datetime = 5
		email = 6
		file = 7
		hidden = 8
		image = 9
		month = 10
		number = 11
		password = 12
		radio = 13
		range = 14
		reset = 15
		search = 16
		submit = 17
		text = 18
		textarea = 19
		time = 20
		url = 21
		week = 22
		video = 23
	End Enum

#End Region

#Region "Support Functions"

#End Region

#Region "Fields"
	Public ReadOnly Property Input_List As List(Of String) = GetEnum(New INPUT)
	Public ReadOnly Property EStoreTableCSSClassList As List(Of String) = GetEnum(New EStoreTableCSSClass)
	Public ReadOnly Property EStoreProgressBarColorIsList As List(Of String) = GetEnum(New EStoreProgressBarColorIs)
	Public ReadOnly Property Materialize_List As List(Of String) = GetEnum(New Materialize)
	Public ReadOnly Property Bootstrap_List As List(Of String) = GetEnum(New Bootstrap)
	Public ReadOnly Property EStore_List As List(Of String) = GetEnum(New EStore)
	Public ReadOnly Property All_List As Array = {All.UpdatePanel.ToString, All.Image.ToString}

	'	Public ReadOnly Property CSSFramework_List As Array = {CSSFramework.Materialize.ToString, CSSFramework.Bootstrap.ToString, CSSFramework.Shoppy.ToString}
	Public ReadOnly Property CSSFramework_List As List(Of String) = GetEnum(New CSSFramework)
	Public ReadOnly Property Controls_List As Array = {ControlsFrom.ASP.ToString, ControlsFrom.HTML.ToString}

	Public ReadOnly Property CarouselSize_List As Array = {CarouselSize.Mini.ToString, CarouselSize.Medium.ToString, CarouselSize.FullPage.ToString}
	Public ReadOnly Property DefaultColors_List As Array = {DefaultColor.Primary.ToString, DefaultColor.Secondary.ToString, DefaultColor.Success.ToString, DefaultColor.Danger.ToString, DefaultColor.Warning.ToString, DefaultColor.Info.ToString, DefaultColor.Light.ToString, DefaultColor.Dark.ToString}
	Public ReadOnly Property ButtonSize_List As Array = {ButtonSize.Large.ToString, ButtonSize.Small.ToString, ButtonSize.Block.ToString, ButtonSize.Flat.ToString}

	Public ReadOnly Property Border_List As Array = {Border.Arched.ToString, Border.Circular.ToString, Border.Flat.ToString}
	Public ReadOnly Property DropDownListStyle_List As Array = {DropDownListStyle.FrameworkDefault.ToString, DropDownListStyle.Custom.ToString, DropDownListStyle.Standard.ToString, DropDownListStyle.None.ToString}


	Public ReadOnly Property ProgrammingLanguage_List As Array = {ProgrammingLanguage.VB.ToString, ProgrammingLanguage.CS.ToString}
	Public ReadOnly Property VB_List As List(Of String) = GetEnum(New VB)
	Public ReadOnly Property CS_List As List(Of String) = GetEnum(New CS)
    Public ReadOnly Property ImportGroup_List As Array = {ImportGroup.Bank.ToString, ImportGroup.Desktop.ToString, ImportGroup.Email.ToString, ImportGroup.Encryption.ToString, ImportGroup.Log.ToString, ImportGroup.Standard.ToString, ImportGroup.Statistics.ToString, ImportGroup.Web.ToString}

    Public Property css_framework__ As CSSFramework = CSSFramework.Materialize


#End Region

#Region "New"
	Public Sub New(Optional css_framework As CSSFramework = CSSFramework.Materialize)
		css_framework__ = css_framework
	End Sub
#End Region

#Region "Materialize"
	Public Function GridView_Materialize() As String
		Return "<asp:GridView ID=""control_id_here"" CssClass=""highlight responsive-table centered"" runat=""server"" AllowPaging=""true"" PagerSettings-Mode=""NextPreviousFirstLast"" PagerSettings-Position=""TopAndBottom"" EnableSortingAndPagingCallbacks=""true"" PagerStyle-HorizontalAlign=""Left"" PageSize=""10"" PagerSettings-NextPageText='<span><i class=""fa fa-chevron-circle-right"" aria-hidden=""true""></i></span>' PagerSettings-PreviousPageText='<span><i class=""fa fa-chevron-circle-left"" aria-hidden=""true""></i></span>' PagerSettings-LastPageText='<span><i class=""fa fa-chevron-right"" aria-hidden=""true""></i></span>' PagerSettings-FirstPageText='<span><i class=""fa fa-home"" aria-hidden=""true""></i></span>'></asp:GridView>"
	End Function
	Public Function GridView_Cart_Materialize() As String
		Return "<asp:GridView ConflictDetection=""CompareAllValues"" DataSourceID=""src"" DataKeyNames=""ProductID,InvoiceID,ProductName,UnitPrice"" ID=""control_id_here"" CssClass=""highlight responsive-table centered"" runat=""server"" AllowPaging=""false"" PagerSettings-Mode=""NextPreviousFirstLast"" PagerSettings-Position=""TopAndBottom"" EnableSortingAndPagingCallbacks=""true"" PagerStyle-HorizontalAlign=""Left"" PageSize=""10"" PagerSettings-NextPageText='<span><i class=""fa fa-chevron-circle-right"" aria-hidden=""true""></i></span>' PagerSettings-PreviousPageText='<span><i class=""fa fa-chevron-circle-left"" aria-hidden=""true""></i></span>' PagerSettings-LastPageText='<span><i class=""fa fa-chevron-right"" aria-hidden=""true""></i></span>' PagerSettings-FirstPageText='<span><i class=""fa fa-home"" aria-hidden=""true""></i></span>'></asp:GridView>"
	End Function

	Dim p As String = "<!--<div class=""row"">-->" & vbCrLf & "<div class=""input-field col s12"">" & vbCrLf
	Dim c As String = "<i class=""material-icons prefix""><i class=""fa fa-user"" aria-hidden=""true""></i></i>" & vbCrLf
	Dim s As String = vbCrLf & "<label>control_placeholder_here</label></div>" & vbCrLf & "<!--</div>-->"

    Public Function DropDownList_Materialize(Optional number_of_items As Integer = 1, Optional style As String = "", Optional control As ControlsFrom = ControlsFrom.ASP) As String
        Dim result As String = ""
        Dim num As Integer = number_of_items
        If number_of_items < 1 Then num = 1


        Dim h_ As String = p & "<select name=""control_name_here"" " & getDropDownListStyle(style) & " id=""control_id_here"">
    <option value="""" selected=""selected"" disabled=""disabled"">Choose your option</option>"
        Dim m_ As String = "<option value="""">Text_here</option>"
        Dim f_ As String = "</select>" & s
        Dim html_ As String '= ""
        Dim html_m As String = ""

        If control = ControlsFrom.HTML Then
            For i = 1 To num
                html_m &= m_
            Next
        End If
        html_ = h_ & html_m & f_
		Select Case control
			Case ControlsFrom.ASP
				result = p & "<!--" & c.Replace(vbCrLf, "") & "-->" & "<asp:DropDownList ID=""control_id_here"" " & getDropDownListStyle(style) & " runat=""server"" ValidationGroup=""default""></asp:DropDownList>" & s
			Case ControlsFrom.HTML
				result = html_
		End Select
        Return result
    End Function

    Public Function TextBox_Materialize() As String
		Return p & c & "<asp:TextBox ID=""control_id_here"" TextMode=""SingleLine"" ReadOnly=""false"" runat=""server"" ValidationGroup=""default""></asp:TextBox>" & s
	End Function
	Public Function TextArea_Materialize() As String
		Return p & c & "<asp:TextBox ID=""control_id_here"" TextMode=""MultiLine"" CssClass=""materialize-textarea"" ReadOnly=""false"" runat=""server"" ValidationGroup=""default""></asp:TextBox>" & s
	End Function

	Public Function Checkbox_Materialize() As String
		Return p & "<label>
                        <input type=""checkbox"" id=""control_id_here"" runat=""server"" />
                        <span>control_text_here</span>
                    </label>" & s
	End Function

	Public Function Button_Materialize(Optional size As ButtonSize = ButtonSize.Small) As String
		Return "<asp:Button ID=""control_id_here"" runat=""server"" Text=""control_text_here"" CssClass=""btn btn-" & size.ToString.ToLower & """ CausesValidation=""true"" ValidationGroup=""default"" />"
	End Function


	Public Function Parallax(number As Integer, Optional controls As ControlsFrom = ControlsFrom.ASP) As String
        Dim img_tag As String = ""
        Select Case controls
			Case controls.ASP
				img_tag = "<asp:Image ID=""Image1"" runat=""server"" ImageUrl=""images/"" />"
			Case controls.HTML
				img_tag = "<img src=""images/"" alt="""" title="""" style=""width: 100%; height: auto"" />"
		End Select
		Dim r As String = "<div class=""parallax-container"">
        <div class=""parallax"">" & img_tag & "</div>
    </div>
    <div class=""section white"">
        <div class=""container"">
            <div class=""row"">
                </div>
            </div>
        </div>"
		Dim s As String = ""
		For i As Integer = 1 To number
			s &= r
		Next
		Return s
	End Function


	Public Function Tooltip_Materialize() As String
		Return "<a class=""btn tooltipped"" data-position=""bottom"" data-tooltip=""tooltip_here"">Text_Here</a>"
	End Function

	Public Function Modal_Materialize() As String
		Return "<%--Modal Trigger--%>
					<a class=""waves-effect waves-light btn modal-trigger"" href=""#modal1"">Trigger_Text_Here</a>

					<%--Modal Structure--%>
					<div id=""modal1"" class=""card blue-grey darken-1 hoverable modal"">
						<div class=""card-content white-text"">
							<span class=""card-title"">Title_Here</span>
							<p>Content_Here</p>
						</div>
						<div class=""card-action"">
							<a href=""#"">Footer_Content_Here</a>
							<a href=""#"">Footer_Content_here</a>
						</div>
					</div>"

	End Function

	Public Function MaterialBox(Optional control As ControlsFrom = ControlsFrom.ASP)
        Dim img_tag As String = ""
        Select Case control
			Case ControlsFrom.ASP
				img_tag = "<asp:Image ID=""image_id_here"" runat=""server"" class=""materialboxed"" width=""650"" ImageUrl=""images/"" />"
			Case ControlsFrom.HTML
				img_tag = "<img class=""materialboxed"" width=""650"" src=""images/"">"
		End Select
		Return img_tag
	End Function

	Public Function Collapsible_Materialize(Optional number As Integer = 3)
		Dim r As String = "<ul class=""collapsible"">"
		Dim mid_ As String = "<li>
							<div class=""collapsible-header""><i class=""fa fa-plus"" aria-hidden=""true""></i>Title_Here</div>
							<div class=""collapsible-body""><span>Content_Here</span></div>
						</li>"
		Dim mid__ As String = ""
		Dim a, b As String
		For i As Integer = 1 To number
			a = mid_.Replace("Title_Here", "Title_Here_" & i)
			b = a.Replace("Content_Here", "Content_Here_" & i)
			mid__ &= b
		Next
		Dim s As String = "</ul>"
		Return r & mid__ & s
	End Function

	Public Function Carousel_Mini_Materialize(number_of_images As Integer, Optional control As ControlsFrom = ControlsFrom.ASP)
        Dim img_tag As String = ""
        Select Case control
			Case ControlsFrom.ASP
				img_tag = "<asp:Image ID=""img_id_here"" runat=""server"" ImageUrl=""images/"" />"
			Case ControlsFrom.HTML
				img_tag = "<img src=""images/"">"
		End Select
		Dim r As String = "<div class=""carousel"">"
		Dim mid_ As String = "<a class=""carousel-item"" href=""#"">" & img_tag & "</a>"
		Dim mid__ As String = ""
		For i = 1 To number_of_images
			mid__ &= mid_
		Next
		Dim s As String = "</div>"
		Return r & mid__ & s
	End Function

	Public Function Carousel_Medium_Materialize(number_of_images As Integer, Optional control As ControlsFrom = ControlsFrom.ASP)
        Dim img_tag As String = ""
        Select Case control
			Case ControlsFrom.ASP
				img_tag = "<asp:Image ID=""img_id_here"" runat=""server"" ImageUrl=""images/"" />"
			Case ControlsFrom.HTML
				img_tag = "<img src=""images/"">"
		End Select
		Dim r As String = "<div class=""carousel carousel-slider"">"
		Dim mid_ As String = "<a class=""carousel-item"" href=""#"">" & img_tag & "</a>"
		Dim mid__ As String = ""
		For i = 1 To number_of_images
			mid__ &= mid_
		Next
		Dim s As String = "</div>"
		Return r & mid__ & s
	End Function

	Public Function Carousel_Full_Width_Materialize(number_of_items As Long) As String
		Dim id As String = "carousel-" & NewGUID(IDPattern.Short_)
		Dim r As String = "<!--Site.master must have container defined in the main section, like " & "<div class=""container"" style=""width: 100%; min-width: 100%"">" & vbCrLf & "All other pages must explicitly define div.container-->" & vbCrLf & vbCrLf & "<div class=""carousel carousel-slider center " & id & """>

        <div class=""carousel-fixed-item center"">
            <a class=""btn waves-effect white grey-text darken-text-2""><i class=""fa fa-android"" aria-hidden=""true""></i>&nbsp;&nbsp;&nbsp;Get The App</a>
        </div>" & vbCrLf & vbCrLf

		For i = 1 To number_of_items
			r &= "<div class=""carousel-item red white-text"" href=""#"">
            <img src=""images/carousel/image" & i & ".jpg"" alt=""Alternate Text"" style=""width: 100%; height: 100%"" />
            <h2>heading_content_here</h2>
            <p>body_content_here</p>
        </div>" & vbCrLf & vbCrLf
		Next

		r &= "</div>" & vbCrLf & vbCrLf & vbCrLf

		r &= "<%--custom for full width materialize carousel--%>
    <script type=""text/javascript"">
        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.carousel');
            var options = {
                fullWidth: true,
                indicators: true,
                duration: 200
            };
            var instances = M.Carousel.init(elems, options);

            setInterval(function () {
                var instance = M.Carousel.getInstance(document.querySelector('." & id & "'));
                instance.next();
            }, 5000);
        });
    </script>"

		Return r
	End Function

	Public Function Card_Materialize() As String
		Return "<div class=""card blue-grey darken-1 hoverable"">
						<div class=""card-content white-text"">
							<span class=""card-title"">Title_Here</span>
							<p>Content_Here</p>
						</div>
						<div class=""card-action"">
							<a href=""#"">Link_Here</a>
						</div>
					</div>"
	End Function

	Public Function Card_Reveal_Materialize(Optional img_control As ControlsFrom = ControlsFrom.ASP) As String
		Return Card_Reveal(img_control)
	End Function

	Public Function Card_Reveal(Optional img_control As ControlsFrom = ControlsFrom.ASP) As String
        Dim img_tag As String = ""
        Select Case img_control
			Case ControlsFrom.ASP
				img_tag = "<asp:Image class=""activator"" ID=""img_id_here"" runat=""server"" ImageUrl=""images/"" />"
			Case ControlsFrom.HTML
				img_tag = "<img class=""activator"" src=""images/"">"
		End Select

		Return "<div class=""card"">
					<div class=""card-image waves-effect waves-block waves-light"">" & img_tag & "
					</div>
					<div class=""card-content"">
						<span class=""card-title activator grey-text text-darken-4"">Title_Here<i class=""fa fa-ellipsis-v"" aria-hidden=""true""></i></span>
						<p><a href=""#"">Link_Or_Small_Content_Here</a></p>
					</div>
					<div class=""card-reveal"">
						<span class=""card-title grey-text text-darken-4"">Main_Title_Here<i class=""fa fa-close"" aria-hidden=""true""></i></span>
						<p>Main_Content_Here</p>
					</div>
				</div>"
	End Function

	Public Function Collection_Materialize(number As Integer)
		Dim r As String = "<ul class=""collection"">"
		Dim mid_ As String = "<li class=""collection-item"">Text_Here</li>"
		Dim mid__ As String = ""
		For i = 1 To number
			mid__ &= mid_
		Next
		Dim s As String = "</ul>"
		Return r & mid__ & s
	End Function

	Public Function Collection_With_Title_Secondary_Content_Materialize(number As Integer)
		Dim r As String = "<ul class=""collection with-header""><li class=""collection-header""><h4>Title_Here</h4></li>"
		Dim mid_ As String = "<li class=""collection-item"">Text_Here<a href=""#"" class=""secondary-content""><i class=""fa fa-plus"" aria-hidden=""True""></i></a></div></li>"
		Dim mid__ As String = ""
		For i = 1 To number
			mid__ &= mid_
		Next
		Dim s As String = "</ul>"
		Return r & mid__ & s
	End Function
#End Region

#Region "Bootsrap"
	'Public Function DropDownList_Bootstrap() As String
	'	Return "<asp:DropDownList ID=""control_id_here"" CssClass=""custom-select form-control"" runat=""server"" ValidationGroup=""default""></asp:DropDownList>"
	'End Function

	Public Function Collapsible_Bootstrap(Optional number As Integer = 3) As String

		Dim id As String = NewGUID()
		Dim r As String = "<div class=""accordion"" id=""" & id & """>"
		Dim mid_ As String = ""

		For i As Integer = 1 To number
			Dim heading_id As String = NewGUID()
			Dim content_id As String = NewGUID()
			Dim show_string As String = " show", collapsed_string As String = "btn btn-link", expand_string As String = "true"
			If i > 1 Then
				show_string = ""
				collapsed_string = "btn btn-link collapsed"
				expand_string = "false"
			End If

			mid_ &= "<div class=""card"">
						<div class=""card-header"" id=""" & heading_id & """>
							<h2 class=""mb-0"">
								<button class=""" & collapsed_string & """ type=""button"" data-toggle=""collapse"" data-target=""#" & content_id & """ aria-expanded=""" & expand_string & """ aria-controls=""" & content_id & """>
									Title_Here_For_" & i & "
								</button>
							</h2>
						</div>
						<div id=""" & content_id & """ class=""collapse" & show_string & """ aria-labelledby=""" & heading_id & """ data-parent=""#" & id & """>
							<div class=""card-body"">
								" & "Body_Content_Here_For_" & i & "
							</div>
						</div>
					</div>"
		Next
		Dim s As String = "</div>"
		Return r & mid_ & s
	End Function

	Public Function Card_Bootstrap() As String
		Return "<div class=""card"">
					<div class=""card-body"">
						<h5 class=""card-title"">Title_Here</h5>
						<!--<h6 class=""card-subtitle mb-2 text-muted"">Card_Subtitle_Here</h6>-->
						<p class=""card-text"">Body_Text_Here</p>
						<a href=""#"" class=""card-link btn btn"">Footer_Link_Here</a>
					</div>
				</div>"
	End Function

	Public Function Badge_Bootstrap(badge_ As DefaultColor) As String
		Return "<span class=""badge badge-" & badge_.ToString.ToLower & """>Text_Here</span>"
	End Function
	'Private Enum BadgeColorIs
	'	Primary
	'	Secondary
	'	Success
	'	Danger
	'	Warning
	'	Info
	'	Light
	'	Dark
	'End Enum

	Public Function Checkbox_Bootstrap() As String
		Return "<div class=""checkbox"">
                    <asp:CheckBox runat=""server"" ID=""control_id_here"" />
                    <asp:Label runat=""server"" AssociatedControlID=""control_id_here"">Control_Text_Here</asp:Label>
                </div>"
	End Function
	Public Function Modal_Bootstrap() As String
		Return "<!-- Button trigger modal -->
					<button class=""btn btn-primary"" data-target=""#control_id_here"" data-toggle=""modal"" type=""button"">
						Trigger_Text_Here
					</button>

					<!-- Modal -->
					<div id=""control_id_here"" aria-hidden=""true"" aria-labelledby=""control_id_here"" class=""modal fade"" role=""dialog"" tabindex=""-1"">
						<div class=""modal-dialog modal-dialog-scrollable modal-dialog-centered"" role=""document"">
							<div class=""modal-content"">
								<div class=""modal-header"">
									<h5 class=""modal-title"">Title_Here</h5>
									<button aria-label=""Close"" class=""close"" data-dismiss=""modal"" type=""button"">
										<span aria-hidden=""true"">&times;</span>
									</button>
								</div>
								<div class=""modal-body"">
									Content_Here
								</div>
								<div class=""modal-footer"">
									<button class=""btn btn-secondary"" data-dismiss=""modal"" type=""button"">Close_Button</button>
									<button class=""btn btn-primary"" type=""button"">Other_Button</button>
								</div>
							</div>
						</div>
					</div>"
	End Function

	Public Function FormGroup_Bootstrap() As String
		Return "<%--section--%>
						<div class=""input-group mb-3"">
							<div class=""input-group-prepend"">
								<span class=""input-group-text""><i class=""fa fa-info"" aria-hidden=""true""></i>&nbsp;&nbsp;Label_Text_Here</span>
							</div>
							control_here
							<span class=""input-group-text"">Text_Here</span>
							<div class=""input-group-append"">
								button_here
							</div>
						</div>"
	End Function

	Public Function Jumbotron_Bootstrap() As String
		Return "<div class=""jumbotron"">Content_Here</div>"
	End Function

	Public Function GridView_Cart_Bootstrap() As String
		Return "<div class=""table-responsive"">
					<asp:GridView ConflictDetection=""CompareAllValues"" DataSourceID=""src"" DataKeyNames=""ProductID,InvoiceID,ProductName,UnitPrice"" ID=""control_id_here"" CssClass=""table table-hover"" runat=""server"" AllowPaging=""false"" AutoGenerateEditButton=""true"" AutoGenerateDeleteButton=""true"" PagerSettings-Mode=""NextPreviousFirstLast"" PagerSettings-Position=""TopAndBottom"" EnableSortingAndPagingCallbacks=""true"" PagerStyle-HorizontalAlign=""Left"" PageSize=""10"" PagerSettings-NextPageText='<span><i class=""fa fa-chevron-circle-right"" aria-hidden=""true""></i></span>' PagerSettings-PreviousPageText='<span><i class=""fa fa-chevron-circle-left"" aria-hidden=""true""></i></span>' PagerSettings-LastPageText='<span><i class=""fa fa-chevron-right"" aria-hidden=""true""></i></span>' PagerSettings-FirstPageText='<span><i class=""fa fa-home"" aria-hidden=""true""></i></span>'></asp:GridView>
				</div>"
	End Function
	Public Function GridView_Bootstrap() As String
		Return "<div class=""table-responsive"">
                                <asp:GridView ID=""control_id_here"" CssClass=""table table-hover"" runat=""server"" AllowPaging=""true"" PagerSettings-Mode=""NextPreviousFirstLast"" PagerSettings-Position=""TopAndBottom"" EnableSortingAndPagingCallbacks=""true"" PagerStyle-HorizontalAlign=""Left"" PageSize=""10"" PagerSettings-NextPageText='<span><i class=""fa fa-chevron-circle-right"" aria-hidden=""true""></i></span>' PagerSettings-PreviousPageText='<span><i class=""fa fa-chevron-circle-left"" aria-hidden=""true""></i></span>' PagerSettings-LastPageText='<span><i class=""fa fa-chevron-right"" aria-hidden=""true""></i></span>' PagerSettings-FirstPageText='<span><i class=""fa fa-home"" aria-hidden=""true""></i></span>'></asp:GridView>
                            </div>"
	End Function

	Private function getDropDownListStyle(style__ As String)As String
        Dim result As String = ""
        Select Case style__
            Case DropDownListStyle.Custom.ToString
                Return " class=""custom-select"""
            Case DropDownListStyle.Standard.ToString
                Return " class=""form-control"""
            Case DropDownListStyle.None.ToString
                Return " class=""browser-default"""
            Case DropDownListStyle.FrameworkDefault.ToString
                Return ""
        End Select
    End function


	Public Function DropDownList_Bootstrap(style__ As String) As String
		Dim style_ As String=getDropDownListStyle(style__)
		Return "<asp:DropDownList " & style_ & " ID=""control_id_here"" runat=""server"" ValidationGroup=""default""></asp:DropDownList>"
	End Function

	Public Function TextBox_Bootstrap() As String
		Return "<asp:TextBox ID=""control_id_here"" TextMode=""SingleLine"" CssClass=""form-control"" ReadOnly=""false"" runat=""server"" ValidationGroup=""default""></asp:TextBox>"
	End Function

	Public Function Button_Bootstrap(Optional size As ButtonSize = ButtonSize.Small, Optional color As DefaultColor = DefaultColor.Primary) As String
		Dim size_ As String
		Select Case size
			Case ButtonSize.Block
				size_ = " btn-block"
			Case ButtonSize.Flat
				size_ = " btn-lg"
			Case ButtonSize.Large
				size_ = " btn-lg"
			Case ButtonSize.Small
				size_ = " btn-sm"
		End Select

		Return "<asp:Button ID=""control_id_here"" runat=""server"" Text=""control_text_here"" CssClass=""btn " & size_ & " btn-" & color.ToString.ToLower & """ CausesValidation=""true"" ValidationGroup=""default"" />"
	End Function


#End Region

#Region "HTML"
	Public Function html(html_input_type As String)
		If html_input_type.ToLower = "video" Then
			Return "<video src=""mp4/file_name.mp4"" controls></video>"
		ElseIf html_input_type.ToLower = "textarea" Then
			Return "<textarea name=""control_name_here"" id=""control_id_here"" cols=""30"" rows=""10"" placeholder=""placeholder_here""></textarea>"
		ElseIf html_input_type.ToLower = "audio" Then
			Return "<audio src=""mp3/file_name.mp3"" controls></audio>"
		End If

		Dim c As String = html_input_type.Replace("_", "")
		Return "<input type=""" & c & """ name=""control_name_here"" id=""control_id_here"" placeholder=""placeholder_here"">"
	End Function
#End Region

#Region "Shoppy"
#End Region
#Region "EStore"
	Public Function Blockquote_EStore() As String
		Return "<blockquote class=""generic-blockquote"">
					content_here
				</blockquote>"
	End Function

	Public Function ProgressBar_EStore(EStoreProgressBarColor As String) As String
		Return "<div class=""progress"" style=""height: 4px"">
					<div class=""progress-bar"" role=""progressbar"" style=""width: numeric_value_here%; background-color: " & EStoreProgressBarColor & """
						aria-valuenow=""numeric_value_here"" aria-valuemin=""0"" aria-valuemax=""100"">
					</div>
				</div>"
	End Function

	Public Function Table_EStore(no_of_rows As Integer, no_of_columns As Integer) As String
		Dim r As String = ""
		Dim begin As String = "<div class=""whole-wrap"">
		<div class=""container box_1170"">
			<div class=""section-top-border"">
				<h3 class=""mb-30"">Title_Here_Or_Remove_Tag</h3>
				<div class=""progress-table-wrap"">
					<div class=""progress-table"">
						<div class=""table-head"">"
		r &= begin

		Dim headers As String = ""
		For i = 1 To no_of_columns
			headers &= "<div class=""serial"">header_" & i & "_here</div>"
		Next
		r &= headers & "</div>"

		Dim rows_ As String = ""
		For i = 1 To no_of_rows
			rows_ &= "<div class=""table-row"">"
			For j = 1 To no_of_columns
				rows_ &= "<div class=""serial"">" & i & "_" & j & "</div>"
			Next
			rows_ &= "</div>"
		Next
		r &= rows_

		Dim close As String = "</div>
							</div>
						</div>
					</div>
				</div>"
		r &= close

		Return r
	End Function

	Public Function Table_EStore_CSSClass(EStoreTableCSSClass_ As String) As String
		Return "<div class=""" & EStoreTableCSSClass_ & """>content_here</div>"
	End Function

	Public Function Carousel_EStore(no_of_items As Integer) As String
		Dim r As String
		Dim begin As String = "<!-- client review part here -->
								<section class=""client_review"">
									<div class=""container"">
										<div class=""row justify-content-center"">
											<div class=""col-lg-8"">
												<div class=""client_review_slider owl-carousel"">"
		r &= begin

		Dim content_ As String = ""
		For i = 1 To no_of_items
			content_ &= "<div class=""single_client_review"">
							<div class=""client_img"">
								<img src=""images/image.jpg"" alt="""">
								<%-- <asp:Image ID=""image_slider_" & "_" & NewGUID().ToString.Replace("-", "_") & """ runat=""server"" ImageUrl=""handler_image.ashx?reference="" /> --%>
							</div>
							<p>content_here</p>
							<h5>- quote_here</h5>
						</div>"
		Next
		r &= content_

		Dim close As String = "</div>
							</div>
						</div>
					</div>
				</section>
				<!-- client review part end -->"
		r &= close

		Return r
	End Function

#End Region


#Region "Start_All_CSS_Frameworks"
    Public Function FormGroup() As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
				result = FormGroup_Bootstrap()
			Case CSSFramework.Materialize
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

    Public Function UpdatePanel() As String
		Return "<asp:UpdatePanel ID=""control_id_here"" runat=""server"">
		<ContentTemplate>
			<asp:Timer ID=""control_id_here"" runat=""server"" Interval=""1000"" Enabled=""true""></asp:Timer>
		</ContentTemplate>
	</asp:UpdatePanel>"
	End Function

    Public Function GridView()
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
				result = GridView_Bootstrap()
			Case CSSFramework.Materialize
				result = GridView_Materialize()
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

    'Public Function DropDownList(Optional style As ListStyle = ListStyle.Custom) As String
    '	Select Case css_framework__
    '		Case CSSFramework.Bootstrap
    '			Return DropDownList_Bootstrap()
    '		Case CSSFramework.Materialize
    '			Return DropDownList_Materialize()
    '		Case CSSFramework.Shoppy
    '	End Select
    'End Function

    Public Function Image(Optional border As Border = Border.Arched, Optional control As ControlsFrom = ControlsFrom.ASP) As String
        Dim border_ As String = ""
        Select Case border
			Case Border.Arched
				border_ = " style=""border-radius:5%; width:auto; height:40px;"""
			Case Border.Circular
				border_ = " style=""border-radius:50%; width:auto; height:40px;"""
			Case Border.Flat
				border_ = ""
		End Select
        Dim r As String = ""
        Select Case control
			Case ControlsFrom.ASP
				r = "<asp:Image ID=""control_id_here"" ImageUrl=""images/"" runat=""server"" " & border_ & " />"
			Case ControlsFrom.HTML
				r = "<img ID=""element_id_here"" runat=""server"" src=""images/"" title="""" alt="""" " & border_ & " />"
		End Select
		Return r
	End Function

	Public Function TextBox() As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
				result = TextBox_Bootstrap()
			Case CSSFramework.Materialize
				result = TextBox_Materialize()
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Button(Optional size As ButtonSize = ButtonSize.Small, Optional color As DefaultColor = DefaultColor.Primary) As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
				result = Button_Bootstrap(size, color)
			Case CSSFramework.Materialize
				result = Button_Materialize(size)
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	'Public Function NewPage() As String
	'	Select Case css_framework__
	'		Case CSSFramework.Bootstrap
	'			Return NewPage_Bootstrap()
	'		Case CSSFramework.Materialize
	'			Return NewPage_Materialize()
	'		Case CSSFramework.Shoppy
	'	End Select
	'End Function

	'Public Function DeclareCSS() As String
	'	Select Case css_framework__
	'		Case CSSFramework.Bootstrap
	'			Return DeclareCSS_Bootstrap()
	'		Case CSSFramework.Materialize
	'			Return DeclareCSS_Materialize()
	'		Case CSSFramework.Shoppy
	'			Return DeclareCSS_Shoppy()
	'		Case CSSFramework.EStore
	'			Return DeclareCSS_EStore()
	'	End Select
	'End Function

	'Public Function DeclareJS() As String
	'	Select Case css_framework__
	'		Case CSSFramework.Bootstrap
	'			Return DeclareJS_Bootstrap()
	'		Case CSSFramework.Materialize
	'			Return DeclareJS_Materialize()
	'		Case CSSFramework.Shoppy
	'			Return DeclareJS_Shoppy()
	'	End Select
	'End Function

	Public Function Tooltip() As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
			Case CSSFramework.Materialize
				result = Tooltip_Materialize()
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Modal() As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
				result = Modal_Bootstrap()
			Case CSSFramework.Materialize
				result = Modal_Materialize()
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Collapsible(Optional number As Integer = 3) As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
			Case CSSFramework.Materialize
				result = Collapsible_Materialize(number)
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Carousel(size_ As CarouselSize, number_of_images As Integer, Optional control As ControlsFrom = ControlsFrom.ASP) As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
			Case CSSFramework.Materialize
				Select Case size_
					Case CarouselSize.Medium
						result = Carousel_Medium_Materialize(number_of_images, control)
					Case CarouselSize.Mini
						result = Carousel_Mini_Materialize(number_of_images, control)
				End Select
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Card() As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
			Case CSSFramework.Materialize
				result = Card_Materialize()
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Collection(number As Integer) As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
			Case CSSFramework.Materialize
				result = Collection_Materialize(number)
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

	Public Function Collection_With_Title_Secondary_Content(number As Integer) As String
        Dim result As String = ""
		Select Case css_framework__
			Case CSSFramework.Bootstrap
			Case CSSFramework.Materialize
				result = Collection_With_Title_Secondary_Content_Materialize(number)
			Case CSSFramework.Shoppy
		End Select
        Return result
    End Function

#End Region


End Class
