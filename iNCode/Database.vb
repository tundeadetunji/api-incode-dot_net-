'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Class Database
    '#Region "Code"
    '	Public Structure QParameters
    '		Public operation As Queries
    '		Public table As String
    '		Public SelectColumns As Array
    '		Public WhereKeys As Array
    '		Public InsertKeys As Array
    '		Public WhereOperators As Array
    '		Public MaxField As String
    '		Public OrderByField As String
    '		Public OrderRecordsBy As OrderBy
    '		Public LikeSelect As LIKE_SELECT
    '		Public TopRowsToSelect As Long
    '		Public UpdateKeys As Array
    '	End Structure
    '	Public Enum QOutput
    '		QData
    '		Display
    '		QString
    '		Commit
    '		QExists
    '		QCount
    '		QCount_Conditional
    '		BindProperty
    '	End Enum
    '	Public Enum Output
    '		Web
    '		Desktop
    '	End Enum

    '	Public Shared Function QString(q_parameters As QParameters, Optional q_output As QOutput = QOutput.QData, Optional connection_string_code_variable As String = Nothing, Optional output_ As Output = Output.Web) As String
    '		Dim operation As Queries = q_parameters.operation, table As String = q_parameters.table, SelectColumns As Array = q_parameters.SelectColumns, WhereKeys As Array = q_parameters.WhereKeys, InsertKeys As Array = q_parameters.InsertKeys, WhereOperators As Array = q_parameters.WhereOperators, MaxField As String = q_parameters.MaxField, OrderByField As String = q_parameters.OrderByField, OrderRecordsBy As OrderBy = q_parameters.OrderRecordsBy, LikeSelect As LIKE_SELECT = q_parameters.LikeSelect, TopRowsToSelect As Long = q_parameters.TopRowsToSelect, UpdateKeys As Array = q_parameters.UpdateKeys
    '		Dim r As String

    '		If operation = Queries.BuildUpdateString Then
    '			r = "BuildUpdateString(""" & table & """"
    '			If UpdateKeys IsNot Nothing Then
    '				With UpdateKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & UpdateKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildTopString Then
    '			r = "BuildTopString(""" & table & """"
    '			If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			r &= ", " & TopRowsToSelect
    '			If OrderByField IsNot Nothing Then
    '				r &= ", """ & OrderByField & """"
    '				r &= ", OrderBy." & OrderRecordsBy.ToString
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildTopString_CONDITIONAL Then
    '            'BuildTopString_CONDITIONAL(table, {sk}, {wko}, rows_to_select:=1, "order_by_field", OrderBy.ASC)
    '            r = "BuildTopString_CONDITIONAL(""" & table & """" 'WhereKeys)"
    '            If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing And WhereOperators IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """, """ & WhereOperators(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If TopRowsToSelect > 0 Then
    '				r &= ", " & TopRowsToSelect
    '			Else
    '				r &= ", 1"
    '			End If
    '			If OrderByField IsNot Nothing Then
    '				r &= ", """ & OrderByField & """"
    '				r &= ", OrderBy." & OrderRecordsBy.ToString
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildSelectString_LIKE Then
    '            'BuildSelectString_LIKE(table__, {sk}, {wk}, "order_by_field", OrderBy.ASC, LIKE_SELECT.AND_)
    '            r = "BuildSelectString_LIKE(""" & table & """" 'WhereKeys)"
    '            If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If OrderByField IsNot Nothing Then
    '				r &= ", """ & OrderByField & """"
    '				r &= ", OrderBy." & OrderRecordsBy.ToString
    '			End If
    '			If LikeSelect <> Nothing Then
    '				r &= ", LIKE_SELECT." & LikeSelect.ToString
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildSelectString_DISTINCT Then
    '            'BuildSelectString_DISTINCT(table__, {SelectColumns}, {wk})
    '            r = "BuildSelectString_DISTINCT(""" & table & """" 'WhereKeys)"
    '            If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildSelectString_CONDITIONAL Then
    '            'BuildSelectString_CONDITIONAL(table__, {SelectColumns}, {wko}, "order_by_field", OrderBy.ASC)
    '            r = "BuildSelectString_CONDITIONAL(""" & table & """" 'WhereKeys)"
    '            If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing And WhereOperators IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """, """ & WhereOperators(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If OrderByField IsNot Nothing Then
    '				r &= ", """ & OrderByField & """"
    '				r &= ", OrderBy." & OrderRecordsBy.ToString
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildSelectString_BETWEEN Then
    '            'BuildSelectString_BETWEEN(table__, {SelectColumns}, {WhereKeys}, "order_by_field", OrderBy.ASC)
    '            'SELECT MyAdminMedia FROM MyAdminMedia WHERE (RecordSerial BETWEEN @RecordSerial_FROM AND @RecordSerial_TO)
    '            r = "BuildSelectString_BETWEEN(""" & table & """" 'WhereKeys)"
    '            If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If OrderByField IsNot Nothing Then
    '				r &= ", """ & OrderByField & """"
    '				r &= ", OrderBy." & OrderRecordsBy.ToString
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildSelectString Then
    '            'BuildSelectString(table__, {SelectColumns}, {WhereKeys}, "order_by_field", OrderBy.ASC)
    '            r = "BuildSelectString(""" & table & """" 'WhereKeys)"
    '            If SelectColumns IsNot Nothing Then
    '				With SelectColumns
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & SelectColumns(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			Else
    '				r &= ", Nothing"
    '			End If
    '			If OrderByField IsNot Nothing Then
    '				r &= ", """ & OrderByField & """"
    '				r &= ", OrderBy." & OrderRecordsBy.ToString
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildMaxString Then
    '            'BuildMaxString(table, where_keys, Max_Field)
    '            r = "BuildMaxString(""" & table & """" 'WhereKeys)"
    '            If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}, "
    '				End With
    '			Else
    '				r &= ", Nothing, "
    '			End If
    '			r &= """" & MaxField & """)"
    '		End If

    '		If operation = Queries.BuildInsertString Then
    '            'BuildInsertString(table, InsertKeys)
    '            r = "BuildInsertString(""" & table & """" 'WhereKeys)"
    '            If InsertKeys IsNot Nothing Then
    '				With InsertKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & InsertKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildCountString_CONDITIONAL Then
    '            'BuildCountString_CONDITIONAL(table, WhereKeyOperator)
    '            r = "BuildCountString_CONDITIONAL(""" & table & """" 'WhereKeys)"
    '            If WhereKeys IsNot Nothing And WhereOperators IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """, """ & WhereOperators(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.BuildCountString Then
    '            'BuildCountString(table, WhereKeys)
    '            r = "BuildCountString(""" & table & """" 'WhereKeys)"
    '            If WhereKeys IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			End If
    '			r &= ")"
    '		End If

    '		If operation = Queries.DeleteString_CONDITIONAL Then
    '            'DeleteString_CONDITIONAL(table, {wko})
    '            r = "DeleteString_CONDITIONAL(""" & table & """" 'WhereKeys)"

    '            If WhereKeys IsNot Nothing And WhereOperators IsNot Nothing Then
    '				With WhereKeys
    '					r &= ", {"
    '					For i As Integer = 0 To .Length - 1
    '						r &= """" & WhereKeys(i) & """, """ & WhereOperators(i) & """"
    '						If i < .Length - 1 Then r &= ", "
    '					Next
    '					r &= "}"
    '				End With
    '			End If
    '			r &= ")"
    '		End If

    '		If q_output = QOutput.QString Then Return r

    '		Dim wko As String = ""
    '		If WhereKeys IsNot Nothing And WhereOperators IsNot Nothing Then
    '			With WhereKeys
    '				wko = "{"
    '				For i As Integer = 0 To .Length - 1
    '					wko &= """" & WhereKeys(i) & """, """ & WhereOperators(i) & """"
    '					If i < .Length - 1 Then
    '						wko &= ", "
    '					End If
    '				Next
    '				wko &= "}"
    '			End With
    '		End If

    '		Dim wk As String = ""
    '		If WhereKeys IsNot Nothing Then
    '			With WhereKeys
    '				wk = "{"
    '				For i As Integer = 0 To .Length - 1
    '					wk &= """" & WhereKeys(i) & """"
    '					If i < .Length - 1 Then
    '						wk &= ", "
    '					End If
    '				Next
    '				wk &= "}"
    '			End With
    '		End If

    '		Dim wkv_b As String = ""
    '		If WhereKeys IsNot Nothing Then
    '			With WhereKeys
    '				wkv_b = "{"
    '				For i As Integer = 0 To .Length - 1
    '					wkv_b &= """" & WhereKeys(i) & "_FROM"", """", """ & WhereKeys(i) & "_TO"", """""
    '					If i < .Length - 1 Then
    '						wkv_b &= ", "
    '					End If
    '				Next
    '				wkv_b &= "}"
    '			End With
    '		End If

    '		Dim wkv As String = ""
    '		Dim l_wkv_conditional As New List(Of String)
    '		If WhereKeys IsNot Nothing Then
    '			If operation = Queries.BuildSelectString_CONDITIONAL Or operation = Queries.BuildCountString_CONDITIONAL Or operation = Queries.BuildTopString_CONDITIONAL Then
    '				With WhereKeys
    '					wkv = "{"
    '					For i As Integer = 0 To .Length - 1
    '						If l_wkv_conditional.Contains(WhereKeys(i)) Then
    '							wkv &= """" & WhereKeys(i) & "_" & l_wkv_conditional.LastIndexOf(WhereKeys(i)) & """, """" "
    '						Else
    '							wkv &= """" & WhereKeys(i) & """, """" "
    '						End If
    '						l_wkv_conditional.Add(WhereKeys(i))
    '						If i < .Length - 1 Then
    '							wkv &= ", "
    '						End If
    '					Next
    '					wkv &= "}"
    '				End With
    '			Else
    '				With WhereKeys
    '					wkv = "{"
    '					For i As Integer = 0 To .Length - 1
    '						wkv &= """" & WhereKeys(i) & """, """" "
    '						If i < .Length - 1 Then
    '							wkv &= ", "
    '						End If
    '					Next
    '					wkv &= "}"
    '				End With
    '			End If
    '		End If

    '		Dim ikv As String = ""
    '		If InsertKeys IsNot Nothing Then
    '			With InsertKeys
    '				ikv = "{"
    '				For i As Integer = 0 To .Length - 1
    '					ikv &= """" & InsertKeys(i) & """, """" "
    '					If i < .Length - 1 Then
    '						ikv &= ", "
    '					End If
    '				Next
    '				ikv &= "}"
    '			End With
    '		End If

    '		Dim ukv As String = ""
    '		If UpdateKeys IsNot Nothing Then
    '			With UpdateKeys
    '				ukv = "{"
    '				For i As Integer = 0 To .Length - 1
    '					ukv &= """" & UpdateKeys(i) & """, """" "
    '					If i < .Length - 1 Then
    '						ukv &= ", "
    '					End If
    '				Next
    '				If WhereKeys IsNot Nothing Then
    '					With WhereKeys
    '						ukv &= ", "
    '						For i As Integer = 0 To .Length - 1
    '							ukv &= """" & WhereKeys(i) & """, """" "
    '							If i < .Length - 1 Then
    '								ukv &= ", "
    '							End If
    '						Next
    '					End With
    '				End If
    '				ukv &= "}"
    '			End With
    '		End If

    '		Dim q As String = ""

    '		If q_output = QOutput.BindProperty Then
    '			If output_ = Output.Desktop Then
    '                'BindProperty(New Object, PropertyToBind.Items, r, "con", {kv}, "dataTextField", "dataValueField")
    '                q = "BindProperty(control_here, PropertyToBind.Items, " & r & ", connection_string_here"
    '				If connection_string_code_variable IsNot Nothing Then q = "BindProperty(control_here, PropertyToBind.Items, " & r & ", " & connection_string_code_variable
    '				If wkv.Length > 0 Then
    '					q &= ", " & wkv
    '				Else
    '					q &= ", Nothing"
    '				End If
    '				q &= ", """ & SelectColumns(0) & """"
    '				q &= ")"
    '			Else
    '                'BindProperty(control_here, r, "con", {kv}, "dtf")
    '                q = "BindProperty(control_here, " & r & ", connection_string_here"
    '				If connection_string_code_variable IsNot Nothing Then q = "BindProperty(control_here, " & r & ", " & connection_string_code_variable
    '				If wkv.Length > 0 Then
    '					q &= ", " & wkv
    '				Else
    '					q &= ", Nothing"
    '				End If
    '				q &= ", """ & SelectColumns(0) & """"
    '				q &= ")"
    '			End If
    '			Return q
    '		End If

    '		If q_output = QOutput.QCount Then
    '            'QCount(table, "conn", {where_keys()}, {wherekv})
    '            q = "QCount(""" & table & """, connection_string_here"
    '			If connection_string_code_variable IsNot Nothing Then q = "QCount(""" & table & """, " & connection_string_code_variable

    '			If wk.Length > 0 Then
    '				q &= ", " & wk
    '			End If
    '			If wkv.Length > 0 Then
    '				q &= ", " & wkv
    '			End If
    '			q &= ")"
    '			Return q
    '		End If

    '		If q_output = QOutput.QCount_Conditional Then
    '            'QCount_CONDITIONAL(table, "con", {wko}, {wkv})
    '            q = "QCount_CONDITIONAL(""" & table & """, connection_string_here"
    '			If connection_string_code_variable IsNot Nothing Then q = "QCount_CONDITIONAL(""" & table & """, " & connection_string_code_variable

    '			If wko.Length > 0 Then
    '				q &= ", " & wko
    '			End If
    '			If wkv.Length > 0 Then
    '				q &= ", " & wkv
    '			End If
    '			q &= ")"
    '			Return q
    '		End If

    '		If q_output = QOutput.QExists Then
    '            'QExists(table, server_con, {wk}, {wkv})
    '            q = "QExists(""" & table & """, connection_string_here"
    '			If connection_string_code_variable IsNot Nothing Then q = "QExists(""" & table & """, " & connection_string_code_variable

    '			If wk.Length > 0 Then
    '				q &= ", " & wk
    '			End If
    '			If wkv.Length > 0 Then
    '				q &= ", " & wkv
    '			End If
    '			q &= ")"
    '			Return q
    '		End If

    '		If q_output = QOutput.QData Then
    '            'QData(r, server_con, {KV})
    '            q = "QData(" & r & ", connection_string_here"
    '			If connection_string_code_variable IsNot Nothing Then q = "QData(" & r & ", " & connection_string_code_variable
    '			If WhereKeys IsNot Nothing Then
    '				If operation <> Queries.BuildSelectString_BETWEEN Then
    '					q &= ", " & wkv
    '				Else
    '					q &= ", " & wkv_b
    '				End If
    '			End If
    '			q &= ")"
    '			Return q
    '		End If

    '		If q_output = QOutput.Display Then
    '            'Display(grid, q)
    '            q = "Display(grid_here, " & r & ", connection_string_here"
    '			If connection_string_code_variable IsNot Nothing Then q = "Display(grid_here, " & r & ", " & connection_string_code_variable
    '			If WhereKeys IsNot Nothing Then
    '				If operation <> Queries.BuildSelectString_BETWEEN Then
    '					q &= ", " & wkv
    '				Else
    '					q &= ", " & wkv_b
    '				End If
    '			End If
    '			q &= ")"
    '			Return q
    '		End If

    '		If q_output = QOutput.Commit Then
    '			q = "CommitSequel(" & r & ", connection_string_here"
    '			If connection_string_code_variable IsNot Nothing Then q = "CommitSequel(" & r & ", " & connection_string_code_variable
    '            'If WhereKeys IsNot Nothing Then
    '            If operation = Queries.BuildInsertString Then
    '				q &= ", " & ikv
    '			ElseIf operation = Queries.BuildUpdateString Then
    '				q &= ", " & ukv
    '			ElseIf operation = Queries.BuildUpdateString_CONDITIONAL Then
    '				q &= ", " & ukv
    '			End If
    '			q &= ")"
    '			Return q
    '		End If


    '	End Function

    '#End Region

End Class
