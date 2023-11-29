'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports iNovation.Code.Web

Imports System.IO
Imports System.Text

Public Class Docs
#Region "Properties"
    Public Shared ReadOnly Property beginJava As String = "/*"
    Public Shared ReadOnly Property endJava As String = "*/"
    Public Shared ReadOnly Property beginVB As String = "''' <summary>"
    Public Shared ReadOnly Property endVB1 As String = "Public"
    Public Shared ReadOnly Property endVB2 As String = "Private"
    Public Shared ReadOnly Property endVB3 As String = endVB2
    Public Shared ReadOnly Property endVB4 As String = endVB2

#End Region
#Region "Main"
    Private Shared r As New List(Of String)

    Public Shared Function JavaDoc(file_content As String) As List(Of String)

        Try
            Try
                r.Clear()
            Catch ex As Exception
            End Try
            Dim counter As Integer = 1
            Dim f As String = file_content ' ReadText(filename_)
            Dim bC As Integer = 0
            Dim eC As Integer = 0
            Dim b As String = beginJava
            Dim e As String = endJava
            For i As Integer = 1 To f.Length
                If Mid(f, i, b.Length) = b Then
                    bC = i
                    For j = bC To f.Length - bC
                        If Mid(f, j, e.Length) = e Then
                            eC = j
                            Exit For
                        End If
                    Next
                    r.Add(counter)
                    counter += 1
                    r.Add(Mid(f, bC, eC - bC).Replace(beginJava, ""))
                    'r.Add("bc=" & bC)
                    'r.Add("ec=" & eC)
                    bC = 0
                    eC = 0
                End If
            Next
        Catch ex As Exception
        End Try
        Return r
    End Function
    Public Shared Function VBDoc(file_content As String) As List(Of String)
        Try
            Try
                r.Clear()
            Catch ex As Exception
            End Try
            Dim counter As Integer = 1
            Dim f As String = file_content ' ReadText(filename_)
            Dim bC As Integer '= 0
            Dim eC As Integer '= 0
            Dim bT As Integer
            Dim eT As Integer
            Dim b As String = beginVB
            'Dim e As String = endVB1 Or endVB2
            For i As Integer = 1 To f.Length
                If Mid(f, i, b.Length) = b Then
                    bC = i
                    For j As Integer = bC To f.Length '- i
                        If Mid(f, j, endVB1.Length) = endVB1 Or Mid(f, j, endVB2.Length) = endVB2 Or Mid(f, j, endVB3.Length) = endVB3 Or Mid(f, j, endVB4.Length) = endVB4 Then
                            eC = j
                            bT = j
                            Exit For
                        End If
                    Next
                    For k As Integer = bT To f.Length
                        If Mid(f, k, 1) = vbCr Or Mid(f, k, 2) = vbCrLf Then
                            eT = k
                            Exit For
                        End If
                    Next
                    '                r.Add(counter)
                    r.Add(Mid(f, bT, eT - bT))
                    counter += 1
                    r.Add(PrepareForIO(Mid(f, bC, eC - bC)).Replace("'", ""))

                    '				r.Add("bc=" & bC)
                    '				r.Add("ec=" & eC)
                    bC = 0
                    eC = 0
                    bT = 0
                    eT = 0
                End If
            Next
        Catch ex As Exception
        End Try
        Return r
    End Function
#End Region
#Region "Checks"
    Public Shared Function isJava(filename_ As String) As Boolean
        Dim r As Boolean = False
        Dim c As String = Path.GetExtension(filename_).ToLower
        If c = ".java" Or c = ".js" Or c = ".css" Or c = ".cs" Or c = ".sql" Then r = True
        Return r
    End Function
    Public Shared Function isVBFile(filename_ As String) As Boolean
        Return Path.GetExtension(filename_).ToLower = ".vb"
    End Function

#End Region
#Region "Retrieval"
    Public Shared Function GrabDoc(filename_ As String, file_content As String, folder_ As String, Optional div_ As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing, Optional AsCollapsible As Boolean = True) As String
        Dim result As String = ""
        'Dim l As List(Of String)
        If isJava(filename_) Then
            '			l = JavaDoc(file_content)
            result = ReturnJavaDoc(JavaDoc(file_content), filename_, folder_, div_, AsCollapsible)
        ElseIf isVBFile(filename_) Then
            '			l = VBDoc(file_content)
            result = ReturnVBDoc(VBDoc(file_content), filename_, folder_, div_, AsCollapsible)
        End If
        Return result
    End Function
    Private Shared Function ReturnJavaDoc(l As List(Of String), filename_ As String, folder_ As String, Optional div_ As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing, Optional AsCollapsible As Boolean = True)
        Dim file_ As String() = GetFilename(filename_, folder_)
        Dim r As String = "" ' Collapsible(l)
        Try
            If AsCollapsible Then
                For i As Integer = 0 To l.Count - 1 Step 2
                    Dim d As New List(Of String)
                    d.Add(l(i) & "&nbsp;&nbsp;|&nbsp;&nbsp;File: " & file_(0) & ", " & file_(1))
                    d.Add(l(i + 1))
                    r &= Collapsible(d)
                Next
            Else
                For i As Integer = 0 To l.Count - 1
                    r &= l(i) & "<br />"
                Next
            End If
            If div_ IsNot Nothing Then WriteContent(r, div_)
            Return r
        Catch ex As Exception
        End Try
        Return r
    End Function
    Private Shared Function ReturnVBDoc(l As List(Of String), filename_ As String, folder_ As String, Optional div_ As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing, Optional AsCollapsible As Boolean = True)
        Dim file_ As String() = GetFilename(filename_, folder_)
        Dim r As String = "" ' Collapsible(l)
        Try
            If AsCollapsible Then
                For i As Integer = 0 To l.Count - 1 Step 2
                    Dim d As New List(Of String)
                    d.Add(l(i) & "&nbsp;&nbsp;|&nbsp;&nbsp;File: " & file_(0) & ", " & file_(1))
                    d.Add(l(i + 1))
                    r &= Collapsible(d)
                Next
            Else
                For i As Integer = 0 To l.Count - 1
                    r &= l(i) & "<br />"
                Next
            End If
            If div_ IsNot Nothing Then WriteContent(r, div_)
            Return r
        Catch ex As Exception
        End Try
        Return r
    End Function
    Private Shared Function Collapsible(list_HEADER_BODY As List(Of String)) As String
        Dim top_ As String = "<ul class=""collapsible"">"
        Dim body_ As String = ""
        With list_HEADER_BODY
            For i As Integer = 0 To .Count - 1 Step 2
                body_ &= "<li>
      <div class=""collapsible-header"">" & list_HEADER_BODY(i) & "</div>
      <div class=""collapsible-body""><span>" & list_HEADER_BODY(i + 1) & "</span></div>
    </li>
  </ul>"
            Next
        End With

        Dim bottom_ As String = "</ul>"
        Return top_ & body_ & bottom_
    End Function

#End Region
#Region "Support Functions"
    Private Shared Function GetFilename(filename_ As String, folder As String) As String()
        Dim file_ As String = Path.GetFileName(filename_)
        Dim project_ As String = Path.GetFileName(Path.GetDirectoryName(filename_))
        Return {project_, file_}

        'Dim eC = 0
        'Dim e As String = "\"
        'Dim str As String = filename_.Replace(folder, "")
        'With str
        '    For i As Integer = 1 To .Length
        '        If Mid(str, 1, e.Length) = e Then
        '            eC = i
        '            Exit For
        '        End If
        '    Next
        'End With
        'project_ = Mid(str, 1, eC - 1)
        '        Return {project_.Replace("\", ""), file_}
    End Function

#End Region

End Class
