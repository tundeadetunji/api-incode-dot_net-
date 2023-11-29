'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Public Class AndroidJS

    Public Enum JSSnippetsComponent
        InterfaceClass = 0
        StringsXML = 1
        ActivityOnCreate = 2
        SampleJS = 3
    End Enum

    Private package As String
    Private interface_class_name As String
    Private interface_method As String
    Private url As String

    Public Sub New(package As String, interface_class_name As String, interface_method As String, url As String)
        Me.package = package
        Me.interface_class_name = interface_class_name
        Me.interface_method = interface_method
        Me.url = url
    End Sub

    Public Function JSSnippets() As Dictionary(Of String, String)
        Dim d As New Dictionary(Of String, String)
        d.Add(JSSnippetsComponent.InterfaceClass.ToString, InterfaceClass)
        d.Add(JSSnippetsComponent.StringsXML.ToString, StringsXML)
        d.Add(JSSnippetsComponent.ActivityOnCreate.ToString, ActivityOnCreate)
        d.Add(JSSnippetsComponent.SampleJS.ToString, SampleJS)
        Return d
    End Function

    Private Function InterfaceClass() As String
        Return "package " & package & ";

import android.app.Activity;
import android.content.Context;
import android.webkit.JavascriptInterface;

public class " & interface_class_name & " {
    Context mContext;
    Activity mActivity; //optional, to access the Activity object

    /** Instantiate the interface and set the context */
    " & interface_class_name & "(Context c, Activity activity) {
        mContext = c;
        mActivity = activity;
    }


    @JavascriptInterface
    public void " & interface_method & "(String var) {
        //get the variable from JS
        String android_variable = var;

    }
}
"
    End Function

    Private Function StringsXML() As String
        Return "<string name=""url"">" & url & "</string>" & vbCrLf
    End Function

    Private Function ActivityOnCreate() As String
        Return "        super.onCreate(savedInstanceState);

        WebView myWebView = new WebView(getApplicationContext());
        setContentView(myWebView);
        WebSettings webSettings = myWebView.getSettings();
        webSettings.setJavaScriptEnabled(true);

        myWebView.addJavascriptInterface(new " & interface_class_name & "(this, ActivityNameHere.this), ""Android"");

        myWebView.loadUrl(getString(R.string.url));" & vbCrLf
    End Function

    Private Function SampleJS() As String
        Return "//    Sample JavaScript
        document.addEventListener(""DOMContentLoaded"", function () {
            document.getElementById(""button"").addEventListener(""click"", function () {
                Android." & interface_method & "(document.getElementById(""text"").value);
            });
        });" & vbCrLf
    End Function
End Class
