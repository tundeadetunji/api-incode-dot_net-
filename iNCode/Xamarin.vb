'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports System.Web.Profile
Public Class Xamarin

#Region "Enums"
	Public Enum XamarinLayouts
		StackLayout = 0
		Grid = 1
	End Enum
	Public Enum XamarinControls
		Label = 1
		Button = 2
		Entry = 3
		Editor = 4
		Image = 5
		CollectionView = 6
		PopUps = 7
	End Enum
#End Region

#Region "Properties"
	Public ReadOnly Property Layouts_List As List(Of String) = GetEnum(New XamarinLayouts)
	Public ReadOnly Property Controls_List As List(Of String) = GetEnum(New XamarinControls)

#End Region

#Region "Main"
	Public Function StackLayout() As String
        Return ""
    End Function

	Public Function Grid() As String
        Return ""
    End Function

	Public Function Label() As String
        Return ""
    End Function
	Public Function Button() As String
		Return "<Button Text=""control_text_here"" Clicked=""Button_Clicked"" />"
	End Function
	Public Function Entry() As String
        Return ""
    End Function
	Public Function Image() As String
        Return ""
    End Function
	Public Function CollectionView() As String
        Return ""
    End Function
	Public Function PopUps() As String
        Return ""
    End Function




#End Region

End Class
