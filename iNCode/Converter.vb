'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Public Class Converter
    Public Shared Function RemoveQuotes(str_ As String, Optional wrap_with_quotes As Boolean = True) As String
        Dim result As String = ""
        If str_.Length > 1 Then
            Dim str As String = str_.Replace(Chr(34), Chr(34) & Chr(34))
            If wrap_with_quotes Then
                result = Chr(34) & str & Chr(34)
            Else
                result = str
            End If
        End If
        Return result
    End Function
    Public Shared Function IncludeQuotes(str_ As String, Optional wrap_with_quotes As Boolean = False) As String
        Dim result As String = ""
        If str_.Length > 1 Then
            Dim str__ As String = str_.Replace(Chr(34) & Chr(34), Chr(34))
            Dim str As String
            If wrap_with_quotes Then
                result = str__
            Else
                str = Mid(str__, 2)
                result = Mid(str, 1, str.Length - 1)
            End If

        End If
        Return result
    End Function

End Class
