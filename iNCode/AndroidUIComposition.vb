'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop

Imports System.Windows.Forms

Public Class AndroidUIComposition
#Region "Enums"
    Public Enum AndroidComponent
        Button = 1
        FAB = 2
        Card = 3
        ProgressIndicator = 4
        DatePicker = 5
        TimePicker = 6
        ImageView = 7
        WebView = 8
    End Enum
    Public Enum AndroidCode
        NavigationDrawer = 1
        OverflowMenu = 2
        ContextMenu = 3
        RecyclerView = 4
        BottomSheet = 5
        Dialog = 6
    End Enum

    Public Enum AndroidText
        EditText = 1
        Username = 2
        Password = 3
        Email = 4
        Phone = 5
        PostalAddress = 6
        MultilineText = 7
        Number = 8
        Label = 9
        DropDown = 10
        RegularEditText = 11
    End Enum

    Public Enum AndroidStyle
        contained = 0 'button
        filled = 1 'text
        outline = 2 'text, button
        FloatingActionButton = 3 'button
    End Enum

    Public Enum AndroidCardOption
        Regular = 1
        Media = 2
        'SupportingText
        'Buttons
    End Enum

    Public Enum AndroidDialogType
        Alert = 1
        Simple = 2
        Confirmation = 3
    End Enum

    Public Enum AndroidDialogOption
        TitleWithSupportingText = 1
        TitleAlone = 2
    End Enum

    Public Enum AndroidLayout
        Constraint = 0
        LinearHorizontal = 1
        LinearVertical = 2

    End Enum
    Public Enum AndroidProgressIndicatorType
        Linear = 1
        Circular = 2
    End Enum

    Public Enum AndroidProgressIndicatorOption
        Indeterminate = 1
        Determinate = 2
    End Enum

    Public Enum AndroidTrailingIcon
        ClearText = 0
        PasswordToggle = 1
        DropDownMenu = 2
        Custom = 3
        None = 4
    End Enum

    Public Enum AndroidLeadingIcon
        Custom = 1
        None = 2
    End Enum

#End Region

#Region "Fields"
    Public Shared AndroidComponent_List As List(Of String) = GetEnum(New AndroidComponent)
    Public Shared AndroidText_List As List(Of String) = GetEnum(New AndroidText)
    Public Shared AndroidCode_List As List(Of String) = GetEnum(New AndroidCode)
    Public Shared AndroidStyle_List As List(Of String) = GetEnum(New AndroidStyle)
    Public Shared AndroidCardOption_List As List(Of String) = GetEnum(New AndroidCardOption)
    Public Shared AndroidDialogType_List As List(Of String) = GetEnum(New AndroidDialogType)
    Public Shared AndroidDialogOption_List As List(Of String) = GetEnum(New AndroidDialogOption)
    Public Shared AndroidProgressIndicatorType_List As List(Of String) = GetEnum(New AndroidProgressIndicatorType)
    Public Shared AndroidProgressIndicatorOption_List As List(Of String) = GetEnum(New AndroidProgressIndicatorOption)
    Public Shared AndroidTrailingIcon_List As List(Of String) = GetEnum(New AndroidTrailingIcon)
    Public Shared AndroidLeadingIcon_List As List(Of String) = GetEnum(New AndroidLeadingIcon)
    Public Shared AndroidLayout_List As List(Of String) = GetEnum(New AndroidLayout)


#End Region

#Region "Components and Text"
    Public Shared Function AndroidSnippetComponent(listText As ListBox, listComponent As ListBox, listCode As ListBox, listTrailingIcon As ListBox, listStyle As ListBox, listCardOption As ListBox, listDialogType As ListBox, listDialogOption As ListBox, listProgressIndicatorType As ListBox, listProgressIndicatorOption As ListBox, listLayout As ListBox, listUI As ListBox, listWhichComponent As ListBox, ActivityName As String, listLeadingIcon As ListBox) As Dictionary(Of String, String)

        Dim main_activity_xml As String
        Dim main_activity_instance_variables As String
        Dim main_activity_oncreate As String

        Dim d As New Dictionary(Of Integer, Object)

        For i = 0 To listWhichComponent.Items.Count - 1
            Select Case listWhichComponent.Items.Item(i)
            ''text
                Case AndroidText.EditText.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.Username.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.RegularEditText.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.Email.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.Label.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.MultilineText.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.Number.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.Password.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.Phone.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.PostalAddress.ToString
                    d.Add(i, New AndroidTextView(listTrailingIcon.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString, listUI.Items.Item(i).ToString, listLeadingIcon.Items.Item(i).ToString))
                Case AndroidText.DropDown.ToString

                ''component
                Case AndroidComponent.Button.ToString
                    d.Add(i, New AndroidButton(listStyle.Items.Item(i).ToString, listUI.Items.Item(i).ToString))
                Case AndroidComponent.Card.ToString
                    d.Add(i, New AndroidCard(listCardOption.Items.Item(i).ToString, listStyle.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString))
                'Case AndroidComponent.Dialog.ToString
                '    d.Add(i, New AndroidDialog(listDialogOption.Items.Item(i).ToString, listDialogType.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString))
                Case AndroidComponent.FAB.ToString
                    d.Add(i, New AndroidButton(listStyle.Items.Item(i).ToString, listUI.Items.Item(i).ToString))
                Case AndroidComponent.ProgressIndicator.ToString
                    d.Add(i, New AndroidProgressIndicator(listProgressIndicatorOption.Items.Item(i).ToString, listProgressIndicatorType.Items.Item(i).ToString, listWhichComponent.Items.Item(i).ToString))
                Case AndroidComponent.TimePicker.ToString
                Case AndroidComponent.DatePicker.ToString
                Case AndroidComponent.ImageView.ToString
                Case AndroidComponent.WebView.ToString

            End Select

        Next

        main_activity_xml = ActivityXMLComponent(listWhichComponent, listUI, d)
        main_activity_instance_variables = ActivityInstanceVariablesComponent(listWhichComponent, d)
        main_activity_oncreate = ActivityOnCreateComponent(listWhichComponent, d)

        Dim r As New Dictionary(Of String, String)
        r.Add("ActivityXML", main_activity_xml)
        r.Add("ActivityInstanceVariables", main_activity_instance_variables)
        r.Add("ActivityOnCreate", main_activity_oncreate)
        Return r
    End Function

    Private Shared Function ActivityXMLComponent(listWhichComponent As ListBox, listUI As ListBox, d As Dictionary(Of Integer, Object)) As String
        Dim r As String = ""
        Dim previous_component_id As String
        Dim constraint_top As String = "app:layout_constraintTop_toTopOf=""parent"""
        For i = 0 To listWhichComponent.Items.Count - 1
            If i = 0 Then
                previous_component_id = "parent"
            End If

            If i <> 0 Then
                previous_component_id = listUI.Items.Item(i - 1).ToString
                constraint_top = "app:layout_constraintTop_toBottomOf=""@id/" & previous_component_id & """"
            End If

            If listWhichComponent.Items.Item(i) = AndroidText.EditText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Email.ToString Or listWhichComponent.Items.Item(i) = AndroidText.MultilineText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Number.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Password.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Phone.ToString Or listWhichComponent.Items.Item(i) = AndroidText.PostalAddress.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Username.ToString Then
                Dim trailing_icon__ As String = CType(d.Item(i), AndroidTextView).TrailingIcon
                Dim trailing_icon As String = ""
                Select Case trailing_icon__
                    Case AndroidTrailingIcon.ClearText.ToString
                        trailing_icon = "app:endIconMode=""clear_text"""
                    Case AndroidTrailingIcon.PasswordToggle
                        trailing_icon = "app:endIconMode=""password_toggle"""
                End Select

                Dim text_is As String = CType(d.Item(i), AndroidTextView).TextIs
                If text_is = "Password" Then
                    trailing_icon = "app:endIconMode=""password_toggle"""
                End If
                Dim leading_icon__ As String = CType(d.Item(i), AndroidTextView).LeadingIcon
                Dim leading_icon As String = ""
                Select Case leading_icon__
                    Case AndroidLeadingIcon.Custom.ToString
                        leading_icon = vbCrLf & "app:startIconDrawable=""@drawable/ic_" & text_is & """"
                End Select
                Dim name As String = text_is
                Dim style As String = AndroidStyle.filled.ToString
                Dim id As String = CType(d.Item(i), AndroidTextView).Name
                'If i <> 0 Then
                '    previous_component_id = CType(d.Item(i - 1), AndroidTextView).TextIs & "Row"
                'End If
                If CType(d.Item(i), AndroidTextView).Style IsNot AndroidStyle.filled.ToString Then
                    style = AndroidStyle.outline.ToString
                End If
                'If i <> 0 Then
                '    previous_component_id = CType(d.Item(i - 1), AndroidTextView).TextIs & "Row"
                'End If
                r &= "<com.google.android.material.textfield.TextInputLayout
                            android:id=""@+id/" & id & """
                            android:layout_width=""match_parent""
                            android:layout_height=""wrap_content""
                            android:layout_marginStart=""8dp""
                            android:layout_marginLeft=""8dp""
                            android:layout_marginTop=""8dp""
                            android:layout_marginEnd=""8dp""
                            android:layout_marginRight=""8dp""
                            android:hint=""" & text_is & """
                            app:boxBackgroundMode=""" & style & """
                            " & trailing_icon & "
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            " & constraint_top & leading_icon & ">

                            <com.google.android.material.textfield.TextInputEditText
                                android:id=""@+id/text" & name & """
                                android:layout_width=""match_parent""
                                android:layout_height=""wrap_content"" />

                        </com.google.android.material.textfield.TextInputLayout>"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.Button.ToString Then
                'If i <> 0 Then
                '    previous_component_id = CType(d.Item(i - 1), AndroidTextView).TextIs & "Row"
                'End If
                Dim id As String = CType(d.Item(i), AndroidButton).Name
                Dim style_ As String = CType(d.Item(i), AndroidButton).Style
                Dim style__ As String = "style=""?attr/materialButtonOutlinedStyle"""
                If style_ = AndroidStyle.contained.ToString Then style__ = ""
                r &= "<Button
                            android:id=""@+id/" & id & """
                            android:layout_width=""0dp""
                            android:layout_height=""wrap_content""
                            android:layout_marginStart=""8dp""
                            android:layout_marginLeft=""8dp""
                            android:layout_marginTop=""8dp""
                            android:layout_marginEnd=""8dp""
                            android:layout_marginRight=""8dp""
                            android:text=""button""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            " & constraint_top & "
                            " & style__ & "/>"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.Card.ToString Then
                Dim id As String = CType(d.Item(i), AndroidCard).Name
                Dim card_option As String = CType(d.Item(i), AndroidCard).CardOption
                Dim card_option__ As String = "<!-- Media -->
                                <ImageView
                                    android:layout_width=""match_parent""
                                    android:layout_height=""194dp""
                                    app:srcCompat=""@drawable/media""
                                    android:scaleType=""centerCrop""
                                    android:contentDescription=""@string/" & id & "content_description_media""
                                    />"
                If card_option = AndroidCardOption.Regular.ToString Then
                    card_option__ = ""
                End If
                r &= "<com.google.android.material.card.MaterialCardView
                            android:id=""@+id/" & id & """
                            android:layout_width=""match_parent""
                            android:layout_height=""wrap_content""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            " & constraint_top & "
                            android:layout_margin=""8dp"">

                            <LinearLayout
                                android:layout_width=""match_parent""
                                android:layout_height=""wrap_content""
                                android:orientation=""vertical"">

                                " & card_option__ & "

                                <LinearLayout
                                    android:layout_width=""match_parent""
                                    android:layout_height=""wrap_content""
                                    android:orientation=""vertical""
                                    android:padding=""16dp"">

                                    <!-- Title, secondary and supporting text -->
                                    <TextView
                                        android:layout_width=""wrap_content""
                                        android:layout_height=""wrap_content""
                                        android:text=""@string/" & id & "_title""
                                        android:textAppearance=""?attr/textAppearanceHeadline6""
                                        />
                                    <TextView
                                        android:layout_width=""wrap_content""
                                        android:layout_height=""wrap_content""
                                        android:layout_marginTop=""8dp""
                                        android:text=""@string/" & id & "secondary_text""
                                        android:textAppearance=""?attr/textAppearanceBody2""
                                        android:textColor=""?android:attr/textColorSecondary""
                                        />
                                    <TextView
                                        android:layout_width=""wrap_content""
                                        android:layout_height=""wrap_content""
                                        android:layout_marginTop=""16dp""
                                        android:text=""@string/" & id & "supporting_text""
                                        android:textAppearance=""?attr/textAppearanceBody2""
                                        android:textColor=""?android:attr/textColorSecondary""
                                        />

                                </LinearLayout>

                                <!-- Buttons -->
                                <LinearLayout
                                    android:layout_width=""wrap_content""
                                    android:layout_height=""wrap_content""
                                    android:layout_margin=""8dp""
                                    android:orientation=""horizontal"">
                                    <com.google.android.material.button.MaterialButton
                                        android:layout_width=""wrap_content""
                                        android:layout_height=""wrap_content""
                                        android:layout_marginEnd=""8dp""
                                        android:text=""@string/" & id & "action_1""
                                        style=""?attr/borderlessButtonStyle""
                                        />
                                    <com.google.android.material.button.MaterialButton
                                        android:layout_width=""wrap_content""
                                        android:layout_height=""wrap_content""
                                        android:text=""@string/" & id & "action_2""
                                        style=""?attr/borderlessButtonStyle""
                                        />
                                </LinearLayout>

                            </LinearLayout>

                        </com.google.android.material.card.MaterialCardView>"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.FAB.ToString Then
                Dim id As String = CType(d.Item(i), AndroidButton).Name
                r &= "<com.google.android.material.floatingactionbutton.FloatingActionButton
                            android:id=""@+id/" & id & """
                            android:layout_width=""wrap_content""
                            android:layout_height=""wrap_content""
                            android:layout_marginEnd=""16dp""
                            android:layout_marginRight=""16dp""
                            android:layout_marginBottom=""16dp""
                            android:clickable=""true""
                            app:layout_constraintBottom_toBottomOf=""parent""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:srcCompat=""@drawable/ic_drawable_file"" />"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.ProgressIndicator.ToString Then
                Dim pi As AndroidProgressIndicator = CType(d.Item(i), AndroidProgressIndicator)
                Dim id As String = pi.Name
                Dim dec As String = "<com.google.android.material.progressindicator.LinearProgressIndicator"
                If pi.ProgressIndicatorType = AndroidProgressIndicatorType.Circular.ToString Then
                    dec = "<com.google.android.material.progressindicator.CircularProgressIndicator"
                End If
                Dim option_ As String = ""
                If pi.ProgressIndicatorOption = AndroidProgressIndicatorOption.Indeterminate.ToString Then
                    option_ = "android:indeterminate=""true"""
                End If
                r &= "" & dec & "
                            android:id=""@+id/" & id & """
                            android:layout_width=""match_parent""
                            android:layout_height=""wrap_content""
                            android:layout_marginStart=""8dp""
                            android:layout_marginLeft=""8dp""
                            android:layout_marginTop=""8dp""
                            android:layout_marginEnd=""8dp""
                            android:layout_marginRight=""8dp""
                            " & option_ & "
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            " & constraint_top & "
                        />"
            ElseIf listWhichComponent.Items.Item(i) = Androidtext.RegularEditText.ToString Then
                Dim id As String = CType(d.Item(i), AndroidTextView).Name
                r &= "    <EditText
                            android:id=""@+id/" & id & """
                            android:layout_width=""match_parent""
                            android:layout_height=""wrap_content""
                            android:layout_marginStart=""8dp""
                            android:layout_marginLeft=""8dp""
                            android:layout_marginTop=""8dp""
                            android:layout_marginEnd=""8dp""
                            android:layout_marginRight=""8dp""
                            android:hint=""EditText""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            " & constraint_top & ">
                        </EditText>"
            ElseIf listWhichComponent.Items.Item(i) = Androidtext.Label.ToString Then
                Dim id As String = CType(d.Item(i), AndroidTextView).Name
                r &= "    <TextView
                            android:id=""@+id/" & id & """
                            android:layout_width=""wrap_content""
                            android:layout_height=""wrap_content""
                            android:text=""Caption""
                            android:textStyle=""bold""
                            android:textSize=""24sp""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            " & constraint_top & "/>"
            End If
        Next

        Return r

    End Function

    Private Shared Function ActivityInstanceVariablesComponent(listWhichComponent As ListBox, d As Dictionary(Of Integer, Object)) As String
        Dim r As String = ""
        For i = 0 To listWhichComponent.Items.Count - 1
            If listWhichComponent.Items.Item(i) = AndroidText.EditText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Email.ToString Or listWhichComponent.Items.Item(i) = AndroidText.MultilineText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Number.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Password.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Phone.ToString Or listWhichComponent.Items.Item(i) = AndroidText.PostalAddress.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Username.ToString Then
                Dim text_is As String = CType(d.Item(i), AndroidTextView).TextIs
                'r &= "TextView " & CType(d.Item(i), AndroidTextView).Name & ";"
                r &= "TextView text" & text_is & ";"
            ElseIf listWhichComponent.Items.Item(i) = AndroidText.RegularEditText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Label.ToString Then
                Dim name As String = CType(d.Item(i), AndroidTextView).Name
                'r &= "TextView " & CType(d.Item(i), AndroidTextView).Name & ";"
                r &= "TextView " & name & ";"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.Button.ToString Then
                r &= "Button " & CType(d.Item(i), AndroidButton).Name & ";"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.Card.ToString Then
                r &= "MaterialCardView " & CType(d.Item(i), AndroidCard).Name & ";"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.FAB.ToString Then
                r &= "FloatingActionButton " & CType(d.Item(i), AndroidButton).Name & ";"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.ProgressIndicator.ToString Then
                If CType(d.Item(i), AndroidProgressIndicator).ProgressIndicatorType = AndroidProgressIndicatorType.Circular.ToString Then
                    r &= "CircularProgressIndicator " & CType(d.Item(i), AndroidProgressIndicator).Name & ";"
                Else
                    r &= "LinearProgressIndicator " & CType(d.Item(i), AndroidProgressIndicator).Name & ";"
                End If
            End If
            r &= vbCrLf
        Next

        Return r

    End Function

    Private Shared Function ActivityOnCreateComponent(listWhichComponent As ListBox, d As Dictionary(Of Integer, Object)) As String
        Dim r As String = ""
        For i = 0 To listWhichComponent.Items.Count - 1
            If listWhichComponent.Items.Item(i) = AndroidText.EditText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Email.ToString Or listWhichComponent.Items.Item(i) = AndroidText.MultilineText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Number.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Password.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Phone.ToString Or listWhichComponent.Items.Item(i) = AndroidText.PostalAddress.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Username.ToString Then
                Dim text_is As String = CType(d.Item(i), AndroidTextView).TextIs
                'r &= CType(d.Item(i), AndroidTextView).Name & " = findViewById(R.id." & CType(d.Item(i), AndroidTextView).Name & ");"
                r &= "text" & text_is & " = findViewById(R.id.text" & text_is & ");"
            ElseIf listWhichComponent.Items.Item(i) = AndroidText.RegularEditText.ToString Or listWhichComponent.Items.Item(i) = AndroidText.Label.ToString Then
                Dim name As String = CType(d.Item(i), AndroidTextView).Name
                r &= name & " = findViewById(R.id." & name & ");"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.Button.ToString Then
                r &= CType(d.Item(i), AndroidButton).Name & " = findViewById(R.id." & CType(d.Item(i), AndroidButton).Name & ");"
                r &= vbCrLf & CType(d.Item(i), AndroidButton).Name & ".setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                
                            }
                        });"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.Card.ToString Then
                r &= CType(d.Item(i), AndroidCard).Name & " = findViewById(R.id." & CType(d.Item(i), AndroidCard).Name & ");"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.FAB.ToString Then
                r &= CType(d.Item(i), AndroidButton).Name & " = findViewById(R.id." & CType(d.Item(i), AndroidButton).Name & ");"
                r &= vbCrLf & CType(d.Item(i), AndroidButton).Name & ".setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                
                            }
                        });"
            ElseIf listWhichComponent.Items.Item(i) = AndroidComponent.ProgressIndicator.ToString Then
                r &= CType(d.Item(i), AndroidProgressIndicator).Name & " = findViewById(R.id." & CType(d.Item(i), AndroidProgressIndicator).Name & ");"
            End If
            r &= vbCrLf
        Next

        Return r

    End Function
#End Region

#Region "Code"
    Public Shared Function AndroidSnippetCode(name As String, ActivityName As String, listCustomItems As ComboBox, WhichComponent As String, packageName As String) As Dictionary(Of String, String)
        Dim activity_xml As String
        Dim activity_instance_variables As String
        Dim activity_oncreate As String
        Dim activity_methods As String
        Dim fragment_xml As String
        Dim fragment_java As String
        Dim menu_xml As String
        Dim navigation_xml As String
        Dim activity_classes As String


        activity_xml = ActivityXMLCode(name, ActivityName, listCustomItems, WhichComponent)
        activity_instance_variables = ActivityInstanceVariablesCode(name, WhichComponent)
        activity_oncreate = ActivityOnCreateCode(name, WhichComponent, listCustomItems)
        activity_methods = ActivityMethodsCode(WhichComponent)
        activity_classes = ActivityClassesCode(name, WhichComponent)
        fragment_xml = FragmentXMLCode(WhichComponent)
        fragment_java = FragmentJavaCode(listCustomItems, WhichComponent)
        menu_xml = MenuXMLCode(listCustomItems, WhichComponent)
        navigation_xml = NavigationXMLCode(listCustomItems, WhichComponent, packageName)

        Dim r As New Dictionary(Of String, String)
        r.Add("ActivityXML", activity_xml)
        r.Add("ActivityInstanceVariables", activity_instance_variables)
        r.Add("ActivityOnCreate", activity_oncreate)
        r.Add("ActivityMethods", activity_methods)
        r.Add("ActivityClasses", activity_classes)
        r.Add("FragmentXML", fragment_xml)
        r.Add("FragmentJava", fragment_java)
        r.Add("MenuXML", menu_xml)
        r.Add("NavigationXML", navigation_xml)
        Return r
    End Function
    Private Shared Function ActivityXMLCode(name As String, ActivityName As String, listCustomItems As ComboBox, WhichComponent As String) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.RecyclerView.ToString Then
            result = RecyclerViewActivityXML(name)
        ElseIf WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerActivityXML(ActivityName)
        End If
        Return result
    End Function

    Private Shared Function ActivityInstanceVariablesCode(name As String, WhichComponent As String) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.RecyclerView.ToString Then
            result = RecyclerViewActivityInstanceVariables(name)
        ElseIf WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerActivityInstanceVariables()
        End If
        Return result
    End Function

    Private Shared Function ActivityOnCreateCode(name As String, WhichComponent As String, listCustomItems As ComboBox) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.RecyclerView.ToString Then
            result = RecyclerViewActivityOnCreate(name)
        ElseIf WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerActivityOnCreate(listCustomItems)
        End If
        Return result
    End Function
    Private Shared Function ActivityMethodsCode(WhichComponent As String) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerActivityMethods()
        End If
        Return result
    End Function
    Private Shared Function ActivityClassesCode(name As String, WhichComponent As String) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.RecyclerView.ToString Then
            result = RecyclerViewActivityClasses(name)
        End If
        Return result
    End Function

    Private Shared Function FragmentXMLCode(WhichComponent As String) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.RecyclerView.ToString Then
            result = RecyclerViewFragmentXML()
        ElseIf WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerFragmentXML()
        End If
        Return result
    End Function

    Private Shared Function FragmentJavaCode(listCustomItems As ComboBox, WhichComponent As String) As String
        Dim result As String = ""

        If WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerFragmentJava(listCustomItems)
        End If
        Return result
    End Function
    Private Shared Function MenuXMLCode(listCustomItems As ComboBox, WhichComponent As String) As String

        Dim result As String = ""
        If WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerMenuXML(listCustomItems)
        End If
        Return result
    End Function

    Private Shared Function NavigationXMLCode(listCustomItems As ComboBox, WhichComponent As String, packageName As String) As String
        Dim result As String = ""
        If WhichComponent = AndroidCode.NavigationDrawer.ToString Then
            result = NavigationDrawerNavigationXML(listCustomItems, packageName)
        End If
        Return result
    End Function

#End Region

#Region "Code Fragments"

#Region "RecyclerView"

    Private Shared Function RecyclerViewActivityXML(name As String)
        Return "<androidx.recyclerview.widget.RecyclerView
                    android:id=""@+id/" & name & """
                    android:layout_width=""match_parent""
                    android:layout_height=""match_parent""
                    app:layout_constraintBottom_toBottomOf=""parent""
                    app:layout_constraintEnd_toEndOf=""parent""
                    app:layout_constraintStart_toStartOf=""parent""
                    app:layout_constraintTop_toTopOf=""parent"" />"
    End Function

    Private Shared Function RecyclerViewActivityInstanceVariables(name As String)
        Return "RecyclerView " & name & ";

                private ArrayList<String> getHeadlines(){
                    ArrayList<String> headlines = new ArrayList<>();
                    headlines.add(""Lorem ipsum dolor, sit amet consectetur adipisicing elit"");
                    headlines.add(""headline2"");
                    headlines.add(""headline3"");
                    headlines.add(""headline4"");
                    headlines.add(""headline5"");
                    headlines.add(""headline6"");
                    headlines.add(""headline7"");
                    headlines.add(""headline8"");
                    headlines.add(""headline9"");
                    headlines.add(""headline10"");
                    return headlines;
                }

                private ArrayList<String> getDetails(){
                    ArrayList<String> details = new ArrayList<>();
                    details.add(""Lorem ipsum dolor, sit amet consectetur adipisicing elit. Iusto non cum laudantium sint minus necessitatibus illum, vero beatae eos maxime veritatis ipsum vitae totam rerum dolor, eaque quae nesciunt nostrum!"");
                    details.add(""details2"");
                    details.add(""details3"");
                    details.add(""details4"");
                    details.add(""details5"");
                    details.add(""details6"");
                    details.add(""details7"");
                    details.add(""details8"");
                    details.add(""details9"");
                    details.add(""details10"");
                    return details;
                }

                private ArrayList<Integer> getPics(){
                    ArrayList<Integer> images = new ArrayList<>();
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    images.add(R.drawable.bride);
                    return images;
                }"
    End Function

    Private Shared Function RecyclerViewActivityOnCreate(name As String)
        Return "ArrayList<String> headlines = getHeadlines();
                ArrayList<String> details = getDetails();
                ArrayList<Integer> pics = getPics();

                " & name & " = findViewById(R.id." & name & ");

                CustomRecyclerViewAdapter adapter = new CustomRecyclerViewAdapter(getApplicationContext(), this, pics, headlines, details);
                " & name & ".setAdapter(adapter);
                " & name & ".setLayoutManager(new LinearLayoutManager(getApplicationContext()));
                //" & name & ".setLayoutManager(new GridLayoutManager(this, 2));

                ItemTouchHelper.Callback callback=new SwipeModule(adapter);
                ItemTouchHelper swipeSupport =new ItemTouchHelper(callback);
                swipeSupport.attachToRecyclerView(" & name & ");"
    End Function

    Private Shared Function RecyclerViewActivityClasses(name As String)
        Return "class CustomRecyclerViewAdapter extends RecyclerView.Adapter<CustomRecyclerViewAdapter.ViewHolder> {

                Context context;
                Activity activity;
                ArrayList<String> headlines;
                ArrayList<String> details;
                ArrayList<Integer> pics;

                public CustomRecyclerViewAdapter(Context context, Activity activity, ArrayList<Integer> pics, ArrayList<String> headlines, ArrayList<String> details) {
                    this.context = context;
                    this.activity = activity;
                    this.pics = pics;
                    this.headlines = headlines;
                    this.details = details;
                }

                @NonNull
                @Override
                public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
                    //create view based on the layout resource - by inflating it
                    //View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_row, parent, false);
                    return new ViewHolder(LayoutInflater.from(parent.getContext()).inflate(R.layout.custom_row, parent, false));
                }

                @Override
                public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
                    Bitmap bitmap = BitmapFactory.decodeResource(context.getResources(), pics.get(position));
                    Glide.with(activity).load(bitmap).circleCrop().into(holder.imagePicR);
                    //Glide.with(activity).load(String.valueOf(url)).circleCrop().into(holder.imagePicR);

                    holder.textHeadlineR.setText(headlines.get(position));
                    holder.textDetailR.setText(details.get(position));
                    holder.imageMoreR.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View v) {
                            MaterialAlertDialogBuilder dialog = new MaterialAlertDialogBuilder(v.getContext());
                            dialog.setTitle(headlines.get(position));
                            dialog.setMessage(details.get(position));
                            dialog.setNeutralButton(""Cancel"", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {

                                }
                            });
                            dialog.setNegativeButton(""Disagree"", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {

                                }
                            });
                            dialog.setPositiveButton(""Agree"", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {

                                }
                            });
                            dialog.show();
                        }
                    });
                }

                @Override
                public int getItemCount() {
                    return pics.size();
                }

                public void RemoveCard(int position){
                    this.headlines.remove(position);
                    this.details.remove(position);
                    this.pics.remove(position);
                    this.notifyItemRemoved(position);
                }


                public class ViewHolder extends RecyclerView.ViewHolder {
                    ImageView imagePicR, imageMoreR;
                    TextView textHeadlineR, textDetailR;

                    public ViewHolder(@NonNull View itemView) {
                        super(itemView);
                        imagePicR = itemView.findViewById(R.id.imagePic);
                        textHeadlineR = itemView.findViewById(R.id.textHeadline);
                        textDetailR = itemView.findViewById(R.id.textDetails);
                        imageMoreR = itemView.findViewById(R.id.imageMore);
                    }
                }
            }

            class SwipeModule extends ItemTouchHelper.SimpleCallback {

                CustomRecyclerViewAdapter adapter;

                public SwipeModule(int dragDirs, int swipeDirs) {
                    super(dragDirs, swipeDirs);
                }

                public SwipeModule(CustomRecyclerViewAdapter adapter) {
                    super(ItemTouchHelper.UP | ItemTouchHelper.DOWN,ItemTouchHelper.LEFT);
                    this.adapter = adapter;
                }

                @Override
                public boolean onMove(@NonNull RecyclerView recyclerView, @NonNull RecyclerView.ViewHolder viewHolder, @NonNull RecyclerView.ViewHolder target) {
                    return false;
                }

                @Override
                public void onSwiped(@NonNull RecyclerView.ViewHolder viewHolder, int direction) {
                    this.adapter.RemoveCard(viewHolder.getAdapterPosition());
                }
            }"
    End Function

    Private Shared Function RecyclerViewFragmentXML()
        Return "<?xml version=""1.0"" encoding=""utf-8""?><!--custom_row.xml-->
                <com.google.android.material.card.MaterialCardView xmlns:android=""http://schemas.android.com/apk/res/android""
                    xmlns:app=""http://schemas.android.com/apk/res-auto""
                    xmlns:tools=""http://schemas.android.com/tools""
                    android:layout_width=""match_parent""
                    android:layout_height=""wrap_content""
                    android:layout_margin=""8dp"">


                    <androidx.constraintlayout.widget.ConstraintLayout
                        android:layout_width=""match_parent""
                        android:layout_height=""match_parent"">

                        <ImageView
                            android:id=""@+id/imagePic""
                            android:layout_width=""73dp""
                            android:layout_height=""80dp""
                            android:scaleType=""centerCrop""
                            app:layout_constraintBottom_toBottomOf=""parent""
                            app:layout_constraintStart_toStartOf=""parent""
                            app:layout_constraintTop_toTopOf=""parent""
                            app:srcCompat=""@drawable/bride"" />

                        <TextView
                            android:id=""@+id/textHeadline""
                            android:layout_width=""0dp""
                            android:layout_height=""wrap_content""
                            android:layout_marginStart=""20dp""
                            android:layout_marginTop=""4dp""
                            android:layout_marginEnd=""8dp""
                            android:ellipsize=""none""
                            android:scrollHorizontally=""false""
                            android:text=""Headline""
                            android:textSize=""18sp""
                            android:textStyle=""bold""
                            app:layout_constraintEnd_toStartOf=""@+id/imageMore""
                            app:layout_constraintStart_toEndOf=""@+id/imagePic""
                            app:layout_constraintTop_toTopOf=""parent"" />

                        <TextView
                            android:id=""@+id/textDetails""
                            android:layout_width=""0dp""
                            android:layout_height=""wrap_content""
                            android:layout_marginEnd=""8dp""
                            android:ellipsize=""none""
                            android:scrollHorizontally=""false""
                            android:text=""Details""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintStart_toStartOf=""@+id/textHeadline""
                            app:layout_constraintTop_toBottomOf=""@+id/textHeadline"" />

                        <ImageView
                            android:id=""@+id/imageMore""
                            android:layout_width=""wrap_content""
                            android:layout_height=""wrap_content""
                            android:layout_marginTop=""4dp""
                            android:layout_marginEnd=""8dp""
                            app:layout_constraintEnd_toEndOf=""parent""
                            app:layout_constraintTop_toTopOf=""parent""
                            app:srcCompat=""@drawable/ic_more_vert"" />

                    </androidx.constraintlayout.widget.ConstraintLayout>
                </com.google.android.material.card.MaterialCardView>"
    End Function
#End Region

#Region "NavigationDrawer"
    Private Shared Function NavigationDrawerActivityXML(ActivityName As String)
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
                <androidx.drawerlayout.widget.DrawerLayout xmlns:android=""http://schemas.android.com/apk/res/android""
                    xmlns:app=""http://schemas.android.com/apk/res-auto""
                    xmlns:tools=""http://schemas.android.com/tools""
                    android:id=""@+id/drawerLayout""
                    android:layout_width=""match_parent""
                    android:layout_height=""match_parent""
                    tools:context=""." & ActivityName & """>

                    <fragment
                        android:id=""@+id/hostForNavGraph""
                        android:name=""androidx.navigation.fragment.NavHostFragment""
                        android:layout_width=""match_parent""
                        android:layout_height=""match_parent""
                        app:defaultNavHost=""true""
                        app:layout_constraintBottom_toBottomOf=""parent""
                        app:layout_constraintEnd_toEndOf=""parent""
                        app:layout_constraintStart_toStartOf=""parent""
                        app:layout_constraintTop_toTopOf=""parent""
                        app:navGraph=""@navigation/nav_graph"" />

                    <com.google.android.material.navigation.NavigationView
                        android:id=""@+id/navigationView""
                        android:layout_width=""wrap_content""
                        android:layout_height=""match_parent""
                        android:layout_gravity=""start""
                        app:headerLayout=""@layout/nav_header""
                        app:menu=""@menu/drawer_menu"" />
                </androidx.drawerlayout.widget.DrawerLayout>"
    End Function

    Private Shared Function NavigationDrawerActivityInstanceVariables()
        Return "NavController navController;
                DrawerLayout drawerLayout;
                NavigationView navigationView;

                AppBarConfiguration actionBarConfiguration;

                //headerLayout
                TextView navEmail, navName;
                ImageView navPicture;"
    End Function

    Private Shared Function destinations(listCustomItems As ComboBox) As String
        Dim r As String = ""
        With listCustomItems
            .SelectedIndex = 0
            For i = 0 To .Items.Count - 1
                r &= "R.id." & .SelectedItem.ToString.ToLower & "Fragment"
                If i <> .Items.Count - 1 Then
                    r &= ", "
                End If
                Try
                    .SelectedIndex += 1
                Catch ex As Exception

                End Try
            Next

        End With
        Return r
    End Function
    Private Shared Function NavigationDrawerActivityOnCreate(listCustomItems As ComboBox)
        Return "navController = Navigation.findNavController(this, R.id.hostForNavGraph);
                drawerLayout = findViewById(R.id.drawerLayout);
                navigationView = findViewById(R.id.navigationView);

                actionBarConfiguration = new AppBarConfiguration.Builder(" & destinations(listCustomItems) & ")
                    .setOpenableLayout(drawerLayout)
                    .build();

                NavigationUI.setupWithNavController(navigationView, navController);
                //show hamburger icon
                NavigationUI.setupActionBarWithNavController(this, navController, actionBarConfiguration);

                //set header layout picture, username/fullname, email
                View headerView = navigationView.getHeaderView(0);
                navName = (TextView) headerView.findViewById(R.id.textNavName);
                navName.setText(getNavName());
                navEmail = (TextView) headerView.findViewById(R.id.textNavEmail);
                navEmail.setText(getNavEmail());
                navPicture = (ImageView) headerView.findViewById(R.id.imageNavPicture);
                setNavPicture();"
    End Function

    Private Shared Function NavigationDrawerActivityMethods()
        Return "@Override
                public boolean onSupportNavigateUp() {
                    NavController navController = Navigation.findNavController(this, R.id.hostForNavGraph);
                    return NavigationUI.navigateUp(navController, actionBarConfiguration) || super.onSupportNavigateUp();
                }
                private String getNavName() {
                    return ""name_or_username_here"";
                }

                private String getNavEmail() {
                    return ""email_here"";
                }

                private int getNavPictureInt() {
                    return R.drawable.user;
                }

                private String getNavPictureUrl() {
                    return ""picture_url"";
                }

                private void setNavPicture() {
                    Bitmap bitmap = BitmapFactory.decodeResource(getResources(), getNavPictureInt());
                    Glide.with(MainActivity.this).load(bitmap).circleCrop().into(navPicture);

                    //Glide.with(this).load(String.valueOf(getNavPictureUrl())).circleCrop().into(imageView);
                }"
    End Function

    Private Shared Function NavigationDrawerFragmentXML()
        Return "<?xml version=""1.0"" encoding=""utf-8""?> <!--use this for nav_header.xml-->
                <androidx.constraintlayout.widget.ConstraintLayout xmlns:android=""http://schemas.android.com/apk/res/android""
                    xmlns:app=""http://schemas.android.com/apk/res-auto""
                    xmlns:tools=""http://schemas.android.com/tools""
                    android:layout_width=""match_parent""
                    android:layout_height=""176dp""
                    android:padding=""16dp"">

                    <ImageView
                        android:id=""@+id/imageNavPicture""
                        android:layout_width=""96dp""
                        android:layout_height=""96dp""
                        android:scaleType=""centerCrop""
                        app:layout_constraintEnd_toEndOf=""parent""
                        app:layout_constraintStart_toStartOf=""parent""
                        app:layout_constraintTop_toTopOf=""parent""
                        app:srcCompat=""@drawable/user"" />

                    <TextView
                        android:id=""@+id/textNavName""
                        android:layout_width=""wrap_content""
                        android:layout_height=""wrap_content""
                        android:layout_marginStart=""8dp""
                        android:layout_marginLeft=""8dp""
                        android:layout_marginEnd=""8dp""
                        android:layout_marginRight=""8dp""
                        android:text=""FullName""
                        android:textSize=""18sp""
                        android:textStyle=""bold""
                        app:layout_constraintEnd_toEndOf=""parent""
                        app:layout_constraintStart_toStartOf=""parent""
                        app:layout_constraintTop_toBottomOf=""@+id/imageNavPicture"" />

                    <TextView
                        android:id=""@+id/textNavEmail""
                        android:layout_width=""wrap_content""
                        android:layout_height=""wrap_content""
                        android:layout_marginStart=""8dp""
                        android:layout_marginLeft=""8dp""
                        android:layout_marginEnd=""8dp""
                        android:layout_marginRight=""8dp""
                        android:text=""TextView""
                        app:layout_constraintEnd_toEndOf=""parent""
                        app:layout_constraintStart_toStartOf=""parent""
                        app:layout_constraintTop_toBottomOf=""@+id/textNavName"" />
                </androidx.constraintlayout.widget.ConstraintLayout>"
    End Function

    Private Shared Function NavigationDrawerFragmentJava(listCustomItems As ComboBox) As String
        Dim r As String = ""
        With listCustomItems
            .SelectedIndex = 0
            For i = 0 To .Items.Count - 1
                r &= "//onCreateView...

                      // make this instance variable?
                      View view;

                      view = inflater.inflate(R.layout.fragment_" & .SelectedItem.ToString.ToLower & ", container, false);
                      return view;" & vbCrLf & vbCrLf
                Try
                    .SelectedIndex += 1
                Catch ex As Exception

                End Try
            Next
        End With
        Return r
    End Function

    Public Shared Function NavigationDrawerMenuXML(listCustomItems As ComboBox)
        Dim r As String = "<?xml version=""1.0"" encoding=""utf-8""?> <!--use this for drawer_menu.xml-->
                           <menu xmlns:android=""http://schemas.android.com/apk/res/android"">"
        With listCustomItems
            .SelectedIndex = 0
            For i = 0 To .Items.Count - 1

                r &= vbCrLf & vbCrLf & "<item
                            android:id=""@+id/" & .SelectedItem.ToString.ToLower & "Fragment""
                            android:icon=""@drawable/ic_" & .SelectedItem.ToString.ToLower & """
                            android:title=""" & TransformText(.SelectedItem.ToString) & """ />"

                Try
                    .SelectedIndex += 1
                Catch ex As Exception

                End Try
            Next
        End With
        Return r & vbCrLf & vbCrLf & "</menu>"
    End Function

    Public Shared Function NavigationDrawerNavigationXML(listCustomItems As ComboBox, packageName As String)
        listCustomItems.SelectedIndex = 0
        Dim r As String = "<?xml version=""1.0"" encoding=""utf-8""?><!--use this for nav_graph.xml-->
                           <navigation xmlns:android=""http://schemas.android.com/apk/res/android""
                               xmlns:app=""http://schemas.android.com/apk/res-auto""
                               xmlns:tools=""http://schemas.android.com/tools""
                               android:id=""@+id/nav_graph""
                               app:startDestination=""@id/" & listCustomItems.SelectedItem.ToString.ToLower & "Fragment"">"
        With listCustomItems
            .SelectedIndex = 0
            For i = 0 To .Items.Count - 1
                r &= vbCrLf & vbCrLf & "<fragment
                        android:id=""@+id/" & .SelectedItem.ToString.ToLower & "Fragment""
                        android:name=""" & packageName & "." & TransformText(.SelectedItem.ToString.ToLower) & "Fragment""
                        android:label=""" & TransformText(.SelectedItem.ToString.ToLower) & """
                        tools:layout=""@layout/fragment_" & .SelectedItem.ToString.ToLower & """ />"

                Try
                    .SelectedIndex += 1
                Catch ex As Exception

                End Try
            Next
        End With
        Return r & vbCrLf & vbCrLf & "</navigation>"
    End Function
#End Region

#End Region

End Class

#Region "Classes"

Public Class AndroidTextView
    Private leading_icon As String
    Private trailing_icon As String
    Private style_ As String
    Private text_is As String
    Private name_ As String


    Public Property TextIs As String
        Get
            Return text_is
        End Get
        Set(value As String)
            text_is = value
        End Set
    End Property

    Public Property TrailingIcon As String
        Get
            Return trailing_icon
        End Get
        Set(value As String)
            trailing_icon = value
        End Set
    End Property
    Public Property LeadingIcon As String
        Get
            Return leading_icon
        End Get
        Set(value As String)
            leading_icon = value
        End Set
    End Property
    Public Property Style As String
        Get
            Return style_
        End Get
        Set(value As String)
            style_ = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return name_
        End Get
        Set(value As String)
            name_ = value
        End Set
    End Property

    Public Sub New(TrailingIcon__ As String, Style__ As String, TextIs__ As String, Name__ As String, LeadingIcon__ As String)
        TrailingIcon = TrailingIcon__
        Style = Style__
        TextIs = TextIs__
        Name = Name__
        LeadingIcon = LeadingIcon__
    End Sub

End Class

Public Class AndroidButton
    Private name_ As String
    Private style_ As String
    Public Property Style As String
        Get
            Return style_
        End Get
        Set(value As String)
            style_ = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return name_
        End Get
        Set(value As String)
            name_ = value
        End Set
    End Property
    Public Sub New(Style__ As String, Name__ As String)
        Style = Style__
        Name = Name__
    End Sub
End Class
Public Class AndroidCard
    Private option_ As String
    Private style_ As String
    Private name_ As String
    Public Property CardOption As String
        Get
            Return option_
        End Get
        Set(value As String)
            option_ = value
        End Set
    End Property
    Public Property Style As String
        Get
            Return style_
        End Get
        Set(value As String)
            style_ = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return name_
        End Get
        Set(value As String)
            name_ = value
        End Set
    End Property
    Public Sub New(CardOption__ As String, Style__ As String, Name__ As String)
        CardOption = CardOption__
        Style = Style__
        Name = Name__
    End Sub

End Class

Public Class AndroidProgressIndicator
    Private option_ As String
    Private type_ As String
    Private name_ As String
    Public Property ProgressIndicatorOption As String
        Get
            Return option_
        End Get
        Set(value As String)
            option_ = value
        End Set
    End Property
    Public Property ProgressIndicatorType As String
        Get
            Return type_
        End Get
        Set(value As String)
            type_ = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return name_
        End Get
        Set(value As String)
            name_ = value
        End Set
    End Property
    Public Sub New(ProgressIndicatorOption__ As String, ProgressIndicatorType__ As String, Name__ As String)
        ProgressIndicatorOption = ProgressIndicatorOption__
        ProgressIndicatorType = ProgressIndicatorType__
        Name = Name__
    End Sub

End Class
Public Class AndroidDialog
    Private option_ As String
    Private type_ As String
    Private name_ As String
    Public Property DialogOption As String
        Get
            Return option_
        End Get
        Set(value As String)
            option_ = value
        End Set
    End Property
    Public Property DialogType As String
        Get
            Return type_
        End Get
        Set(value As String)
            type_ = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return name_
        End Get
        Set(value As String)
            name_ = value
        End Set
    End Property
    Public Sub New(DialogOption__ As String, DialogType__ As String, Name__ As String)
        DialogOption = DialogOption__
        DialogType = DialogType__
        Name = Name__
    End Sub



End Class

Public Class AndroidRecyclerView

End Class
#End Region
