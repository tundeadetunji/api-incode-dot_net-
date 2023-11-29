'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop

Public Class AndroidHTTP
#Region "Members"

	Enum TreatResponseAs
		JsonObject = 0
		ListOfJsonObjects = 1
	End Enum

	Public ReadOnly Property HTTPMethodList As List(Of String)
		Get
			Dim l As New List(Of String)
			With l
				.Add("GET")
				.Add("POST")
			End With
			Return l
		End Get
	End Property
	Public Property TreatAs_List As List(Of String) = GetEnum(New TreatResponseAs)

	Private properties As List(Of String)
	Private params As List(Of String)
#End Region

	Public Function AndroidHTTPSnippets(treat_as As String, package_name As String, sample_json As String, model_class_name As String, http_method As String, endpoint_raw_url As String, base_url As String, params__ As List(Of String)) As Array
		properties = keys(sample_json)
		params = params__
		Dim interface_ As String = AndroidHTTPInterface(treat_as, package_name, http_method, model_class_name, endpoint_raw_url)
		Dim model_class As String = AndroidHTTPModelClass(properties, model_class_name, package_name)
		Dim string_values As String = AndroidHTTPStringValues(base_url)
		Dim activity_member_variables As String = AndroidHTTPActivityMemberVariables(model_class_name)
		Dim activity_on_create As String = AndroidHTTPOnCreate(treat_as, model_class_name)
		Return {interface_, model_class, string_values, activity_member_variables, activity_on_create}
	End Function

	Private Function AndroidHTTPInterface(treat_as As String, package_name As String, http_method As String, model_class_name As String, endpoint_raw_url As String) As String
        Dim result As String = ""
        Select Case treat_as
			Case TreatResponseAs.JsonObject.ToString
                result = AndroidHTTPInterfaceJSONObject(package_name, http_method, model_class_name, endpoint_raw_url)
            Case TreatResponseAs.ListOfJsonObjects.ToString
                result = AndroidHTTPInterfaceListOfJSONObjects(package_name, http_method, model_class_name, endpoint_raw_url)
        End Select
        Return result
    End Function

	Private Function AndroidHTTPModelClass(properties As List(Of String), model_class_name As String, package_name As String) As String
		Dim r As String = "package " & package_name & ";

import com.google.gson.JsonObject;

public class " & model_class_name & " {" & vbCrLf

		For i = 0 To properties.Count - 1
			r &= "String " & properties(i) & ";" & vbCrLf
		Next

		r &= vbCrLf & vbCrLf

		For i = 0 To properties.Count - 1
			r &= "public String get" & TransformText(properties(i)) & "() { return " & properties(i) & "; }" & vbCrLf & vbCrLf
		Next

		r &= "}"
		Return r
	End Function


	Private Function AndroidHTTPStringValues(base_url As String) As String
		Return "<string name=""url"">" & base_url & "</string>"
	End Function

	Private Function AndroidHTTPActivityMemberVariables(model_class_name As String) As String
		Return "Button button" & model_class_name & "Request;"
	End Function

	Private Function AndroidHTTPOnCreate(treat_as As String, model_class_name As String) As String
        Dim result As String = ""
        Select Case treat_as
			Case TreatResponseAs.JsonObject.ToString
                result = AndroidHTTPOnCreateJSONObject(model_class_name)
            Case TreatResponseAs.ListOfJsonObjects.ToString
                result = AndroidHTTPOnCreateListOfJSONObjects(model_class_name)
        End Select
        Return result
    End Function

#Region ""

	Public Function AndroidHTTPInterfaceJSONObject(package_name As String, http_method As String, model_class_name As String, endpoint_raw_url As String) As String
		Dim r As String = "package " & package_name & ";

import retrofit2.Call;
import retrofit2.http." & TransformText(http_method, TextCase.UpperCase) & ";

public interface I" & model_class_name & "API {
    @" & TransformText(http_method, TextCase.UpperCase) & "(""" & endpoint_raw_url & """)
    Call<" & model_class_name & "> getContentFromServer(" & vbCrLf
		If params.Count > 0 Then
			For i = 0 To params.Count - 1
				r &= "@Query(""" & params(i) & """) String " & params(i) & "" & vbCrLf
				If i <> params.Count - 1 Then
					r &= ","
				End If
				r &= vbCrLf
			Next
		End If

		r &= vbCrLf & ");

}
"

		Return r
	End Function

	Public Function AndroidHTTPInterfaceListOfJSONObjects(package_name As String, http_method As String, model_class_name As String, endpoint_raw_url As String) As String
		Dim r As String = "package " & package_name & ";

import java.util.List;

import retrofit2.Call;
import retrofit2.http." & http_method.ToUpper & ";

public interface I" & model_class_name & "API {
    @" & http_method.ToUpper & "(""" & endpoint_raw_url & """)
    Call<List<" & model_class_name & ">> getContentFromServer(" & vbCrLf

		If params.Count > 0 Then
			For i = 0 To params.Count - 1
				r &= "@Query(""" & params(i) & """) String " & params(i) & "" & vbCrLf
				If i <> params.Count - 1 Then
					r &= ","
				End If
				r &= vbCrLf
			Next
		End If

		r &= vbCrLf & ");
}
"
		Return r
	End Function

	Public Function AndroidHTTPOnCreateJSONObject(model_class_name As String) As String
		Dim r As String = "Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(getString(R.string.url))
                .addConverterFactory(GsonConverterFactory.create())
                .build();" & vbCrLf & vbCrLf & vbCrLf

		r &= "button" & model_class_name & "Request = findViewById(R.id.button" & model_class_name & "Request);
        button" & model_class_name & "Request.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                I" & model_class_name & "API " & model_class_name.ToLower & "API = retrofit.create(I" & model_class_name & "API.class);
                Call<" & model_class_name & "> call = " & model_class_name.ToLower & "API.getContentFromServer("

		If params.Count > 0 Then
			For i = 0 To params.Count - 1
				r &= params(i)
				If i <> params.Count - 1 Then
					r &= ","
				End If
			Next
		End If

		r &= ");
                call.enqueue(new Callback<" & model_class_name & ">() {
                    @Override
                    public void onResponse(Call<" & model_class_name & "> call, Response<" & model_class_name & "> response) {
                        if (response.isSuccessful()) {
                            " & model_class_name & " dataFromServer = response.body();" & vbCrLf

		For i = 0 To properties.Count - 1
			r &= "String " & properties(i) & " = dataFromServer.get" & TransformText(properties(i)) & "();" & vbCrLf
		Next

		r &= vbCrLf & "} else {
                            //textResult.setText(""Failed with code "" + response.code());
                        }
                    }

                    @Override
                    public void onFailure(Call<" & model_class_name & "> call, Throwable t) {
                        //textResult.setText(t.getMessage());
                    }
                });
            }
        });"

		Return r
	End Function

	Public Function AndroidHTTPOnCreateListOfJSONObjects(model_class_name As String) As String
		Dim r As String = "Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(getString(R.string.url))
                .addConverterFactory(GsonConverterFactory.create())
                .build();" & vbCrLf & vbCrLf & vbCrLf


		r &= "button" & model_class_name & "Request.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                I" & model_class_name & "API " & model_class_name.ToLower & "API = retrofit.create(I" & model_class_name & "API.class);
                Call<List<" & model_class_name & ">> call = " & model_class_name.ToLower & "API.getContentFromServer("

		If params.Count > 0 Then
			For i = 0 To params.Count - 1
				r &= params(i)
				If i <> params.Count - 1 Then
					r &= ","
				End If
			Next
		End If

		r &= ");
                call.enqueue(new Callback<List<" & model_class_name & ">>() {
                    @Override
                    public void onResponse(Call<List<" & model_class_name & ">> call, Response<List<" & model_class_name & ">> response) {
                        if (response.isSuccessful()) {
                            List<" & model_class_name & "> dataFromServer = response.body();
                            for (int i = 0; i < dataFromServer.size(); i++) {
                            }
                        } else {
                            //textResult.setText(""Failed with code "" + response.code());
                        }
                    }

                    @Override
                    public void onFailure(Call<List<" & model_class_name & ">> call, Throwable t) {
                        //textResult.setText(t.getMessage());
                    }
                });
            }
        });"

		Return r

	End Function
#End Region

#Region ""
	Private Function keys(sample_json As String) As List(Of String)
		Return Si_Properties(sample_json)
	End Function

#End Region


End Class
