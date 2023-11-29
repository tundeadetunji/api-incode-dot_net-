'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports iNovation.Code.Machine
Imports iNovation.iNCode.InternalTypes
Public Class Android

#Region "Types"

#End Region

#Region "Other Members"

    Public Enum Components
        ''ClipboardGetSetText = 0
        Dependencies = 1
        ReleaseAPKAppGradle = 2
        ProjectGradle = 3
        ''DeviceID = 2
        ''IfConnectionIsMetered = 3
        ''IfThereIsInternet = 4
        ''Import = 5
        ''MainActivity = 6
        ''MakeCall = 7
        ''Notification = 8
        ''OpenAppPageOnGooglePlaystore = 9
        Permissions = 10
        ''SendSMS = 11
        ''ShareAppURL = 12
        ''StartActivity = 13
        ''TextToSpeech = 14
        ''Toast = 15
        ''WebView = 16
    End Enum

    'Public Enum Java
    '	NewFile = 1
    'End Enum

    Public Enum API
        GoogleSheets = 1
    End Enum

#End Region

#Region "Support Functions"

#End Region

#Region "Fields"
    Public ReadOnly Property Components_List As List(Of String) = GetEnum(New Components)
    Public ReadOnly Property API_List As List(Of String) = GetEnum(New API)


#End Region

#Region "New"
#End Region

#Region "Components"
    Public Function ClipboardText() As String
        Return "@RequiresApi(api = Build.VERSION_CODES.M)
    void ClipboardSetText(String text_to_copy) {
        ClipboardManager clipboard = (ClipboardManager) getSystemService(getApplicationContext().CLIPBOARD_SERVICE);
        /*if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.P) {
            clipboard.clearPrimaryClip();
        }*/
        ClipData clip = ClipData.newPlainText("""", text_to_copy);
        clipboard.setPrimaryClip(clip);
    }

    public String ClipboardGetText() {
        String clipboardText;
        ClipboardManager clipboard = (ClipboardManager) getSystemService(getApplicationContext().CLIPBOARD_SERVICE);

        clipboardText = clipboard.getPrimaryClip().getItemAt(0)
                .coerceToText(getApplicationContext()).toString();

        return clipboardText;
    }"
    End Function


    Public Function OpenAppPageOnGooglePlaystore() As String
        Return "final Uri marketUri = Uri.parse(""market://details?id="" + getPackageName());
                startActivity(new Intent(Intent.ACTION_VIEW, marketUri));
        


        /*
                Intent intent = new Intent(Intent.ACTION_VIEW)
                        .setData(Uri.parse(""https://play.google.com/store/apps/details?id="" + getPackageName()));
                try {
                    startActivity(new Intent(intent)
                            .setPackage(""com.android.vending""));
                } catch (android.content.ActivityNotFoundException exception) {
                    startActivity(intent);
                }
        */"
    End Function

    Public Function ShareAppURL() As String
        Return "String url = ""https://play.google.com/store/apps/details?id="" + getPackageName();

        Intent sendIntent = new Intent();
        sendIntent.setAction(Intent.ACTION_SEND);
        sendIntent.putExtra(Intent.EXTRA_TEXT, url);
        sendIntent.setType(""text/plain"");
        startActivity(sendIntent);"
    End Function

    Public Function MakeCall() As String
        Return "Button callButton = (Button) findViewById(R.id.button);
				callButton.setOnClickListener(new View.OnClickListener() {
				@Override
				public void onClick(View view){
					String phoneNo = phone_number_here;
					String dial = ""tel:"" + phoneNo;
					startActivity(new Intent(Intent.ACTION_CALL, Uri.parse(dial)));
				}
				});"
    End Function

    Public Function StartActivity() As String
        Return "startActivity(new Intent(getBaseContext(), nameOfActivity.class));
                    //startActivity(new Intent(getApplicationContext(), nameOfActivity.class));
                    //startActivity(new Intent(this, nameOfActivity.class));"
    End Function

    Public Function Toast() As String
        Return "Toast.makeText(getApplicationContext(), ""message_here"", Toast.LENGTH_SHORT).show();
                //Toast.makeText(getBaseContext(), ""message_here"", Toast.LENGTH_LONG).show();"
    End Function

    Public Function Import() As String
        Return "import android.support.v7.app.AppCompatActivity;
				import android.os.Bundle;
				import android.content.Intent;
				import android.net.Uri;
				import android.text.TextUtils;
				import android.view.View;
				import android.widget.Button;
				import android.widget.EditText;
				import android.widget.Toast;
				import android.webkit.WebView;
				import android.widget.RelativeLayout;
				import java.sql.Connection;
				import java.sql.DriverManager;
				import java.sql.ResultSet;
				import java.sql.SQLException;
				import java.sql.Statement;"
    End Function

    Public Function MainActivity() As String
        Return "public class MainActivity extends AppCompatActivity {
					@Override
					protected void onCreate(Bundle savedInstanceState) {
						super.onCreate(savedInstanceState);
				//        setContentView(R.layout.activity_main);

						WebView myWebView = (WebView) findViewById(R.id.webview);
						myWebView.loadUrl(""https://www.domain-here.com"");

						RelativeLayout r = (RelativeLayout) findViewById(R.id.RelLayout);
						setContentView(r);

					}
				}

				//<uses-permission android:name=""android.permission.CALL_PHONE""/>"
    End Function

    Public Function Permissions() As String
        Return "<uses-permission android:name=""android.permission.INTERNET"" />
				<!--<uses-permission android:name=""android.permission.CALL_PHONE""/>
				<uses-feature android:name=""android.hardware.camera"" android:required=""true"" />
				<uses-permission android:name=""android.permission.SEND_SMS""/>
				<uses-permission android:name=""android.permission.RECEIVE_SMS""/>
				<uses-permission android:name=""android.permission.ACCESS_NETWORK_STATE"" />-->"
    End Function

    Public Function WebView() As String
        Return "String url = ""https://www.whatever.com/page.html"";

        webHome = (WebView) v.findViewById(R.id.webHome);
        webHome.loadUrl(url);

        // Enable Javascript
        WebSettings webSettings = webHome.getSettings();
        webSettings.setJavaScriptEnabled(true);

        // Force links and redirects to open in the WebView instead of in a browser
        webHome.setWebViewClient(new WebViewTemplate());




/*
public class WebViewTemplate extends WebViewClient {
    @Override
    public boolean shouldOverrideUrlLoading(WebView view, String url) {
        String host = ""www.whatever.com"";

        if (host.equals(Uri.parse(url).getHost())) {
            // This is my website, so do not override; let my WebView load the page
            return false;
        }
        // Otherwise, the link is not for a page on my site, so launch another Activity that handles URLs
        Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
        new Activity().startActivity(intent);
        return true;
    }
}
*/"
    End Function

#End Region

#Region "Java"
    Public Function NewFile(filename As String, fields As Array) As String
        Dim r As String = "public class " & filename & " {" & vbCrLf
        With fields
            For i = 0 To .Length - 1
                r &= "private String " & fields(i) & ";" & vbCrLf
            Next
        End With
        r &= vbCrLf & vbCrLf & "public " & filename & "("
        With fields
            For i = 0 To .Length - 1
                r &= "String " & fields(i)
                If i <> .Length - 1 Then r &= ", "
            Next
        End With
        r &= ")" & vbCrLf & "{" & vbCrLf & vbCrLf & "//super("
        With fields
            For i = 0 To .Length - 1
                r &= fields(i)
                If i <> .Length - 1 Then r &= ", "
            Next
        End With
        r &= ");" & vbCrLf & vbCrLf
        With fields
            For i = 0 To .Length - 1
                r &= "set" & TransformText(fields(i), TextCase.Capitalize) & "(" & fields(i) & ");" & vbCrLf
            Next
        End With
        r &= vbCrLf & "//doThisToo("
        With fields
            For i = 0 To .Length - 1
                r &= fields(i)
                If i <> .Length - 1 Then r &= ", "
            Next
        End With
        r &= ");" & vbCrLf
        r &= "}" & vbCrLf & vbCrLf
        With fields
            For i = 0 To .Length - 1
                r &= "private void set" & TransformText(fields(i), TextCase.Capitalize) & "(String " & fields(i) & "){" & vbCrLf & "this." & fields(i) & " = " & fields(i) & ";" & vbCrLf & "}" & vbCrLf & vbCrLf
            Next
        End With
        With fields
            For i = 0 To .Length - 1
                r &= "public String get" & TransformText(fields(i), TextCase.Capitalize) & "(){" & vbCrLf & "return this." & fields(i) & ";" & vbCrLf & "}" & vbCrLf & vbCrLf
            Next
        End With
        r &= "//@Override" & vbCrLf & "public void doThisToo("
        With fields
            For i = 0 To .Length - 1
                r &= "String " & fields(i)
                If i <> .Length - 1 Then r &= ", "
            Next
        End With
        r &= "){" & vbCrLf & "}" & vbCrLf & "}"

        Return r
    End Function

    Public Function IfThereIsInternet() As String
        Return "protected boolean thereIsInternet() {
        ConnectivityManager cm = (ConnectivityManager) getApplicationContext().getSystemService(getApplicationContext().CONNECTIVITY_SERVICE);

        NetworkInfo activeNetwork = cm.getActiveNetworkInfo();
        boolean isConnected = activeNetwork != null &&
                activeNetwork.isConnectedOrConnecting();

        return isConnected;
    }"
    End Function

    Public Function IfConnectionIsMetered() As String
        Return "private  boolean IsMetered(){
        //i.e. it's not on a wireless network
        ConnectivityManager cm =
                (ConnectivityManager)getApplicationContext().getSystemService(Context.CONNECTIVITY_SERVICE);
        boolean isMetered = cm.isActiveNetworkMetered();
        return isMetered;
    }"
    End Function
    Public Function DeviceID() As String
        Return "private String getDeviceID(){
        return Settings.Secure.getString(getApplicationContext().getContentResolver(), Settings.Secure.ANDROID_ID);
    }

//import android.provider.Settings.Secure;"
    End Function
    Public Function SendSMS() As String
        Return "String number = tPhoneNumber.getText().toString();
                String message = tMessage.getText().toString();

                Intent i = new Intent(getApplicationContext(), SMSActivity.class); //back to this activity
                PendingIntent p = PendingIntent.getActivity(getApplicationContext(), 0, i,0);

                SmsManager s = SmsManager.getDefault();
                s.sendTextMessage(number, null, message, p,null);

                Toast.makeText(getApplicationContext(), ""Message has been sent."", Toast.LENGTH_LONG).show();"
    End Function

    Public Function Notification() As String
        Return "//NotificationCompat.Builder n;
                //private  static final int ID = 999;
                
                n.setSmallIcon(R.drawable.ic_launcher_background);
                n.setTicker(""You just received a notification"");
                n.setWhen(System.currentTimeMillis());
                n.setContentTitle(""Wow! That's great news!"");
                n.setContentText(""Login to receive your gift"");

                //To send the user to an activity, when the user clicks on the notification
                Intent i = new Intent(getApplicationContext(), MainActivity.class);
                PendingIntent p = PendingIntent.getActivity(getApplicationContext(), 0, i, PendingIntent.FLAG_UPDATE_CURRENT);
                n.setContentIntent(p);

                //issue the notification
                NotificationManager m = (NotificationManager) getSystemService(NOTIFICATION_SERVICE);
                m.notify(ID, n.build());"
    End Function
    Public Function TextToSpeech() As String
        Return "    private void readText () {

/*
    TextToSpeech textToSpeech;
    TextView textString;
    Button buttonReadText;


    @Override
    public void onInit(int status){
        if (status == TextToSpeech.SUCCESS) {
            int result = textToSpeech.setLanguage(Locale.US);
            if (result == TextToSpeech.LANG_MISSING_DATA || result == TextToSpeech.LANG_NOT_SUPPORTED) {
                //Log.e(""error"", ""This Language is not supported"");
            } else {
                readText();
            }
        } else {
            //Log.e(""error"", ""Failed to Initialize"");
        }
    }


    @Override
    protected void onDestroy() {
        if (textToSpeech != null) {
            textToSpeech.stop();
            textToSpeech.shutdown();
        }
        super.onDestroy();
    }


        buttonReadText.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                readText();
            }
        });
*/


        String s = textString.getText().toString();
        if ("""".equals(s)) {
            return;
        }
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {
            textToSpeech.speak(s, TextToSpeech.QUEUE_FLUSH, null, null);
        }
        else {
            textToSpeech.speak(s, TextToSpeech.QUEUE_FLUSH, null);
        }
    }"
    End Function

    Public Function Dependencies() As String
        Return "//dependencies {
					//build.gradle(Module: appName.app)

                    //General Module
					implementation 'com.github.tundeadetunji:generalmodule:" & GeneralModuleVersion() & "'


                    //jtds
                    //implementation fileTree(dir: 'libs', include: ['*.jar'])
                    //implementation 'net.sourceforge.jtds:jtds:1.3.1'


                    //retrofit & gson
                    implementation 'com.squareup.retrofit2:converter-gson:2.6.0'
                    implementation 'com.squareup.retrofit2:retrofit:2.9.0'


                    //glide
                    implementation 'com.github.bumptech.glide:glide:4.12.0'
                    annotationProcessor 'com.github.bumptech.glide:compiler:4.12.0'

            
                    //C
                    //implementation 'androidx.legacy:legacy-support-v4:1.0.0'


                    //google
                    //implementation 'com.google.android.gms:play-services-auth:19.2.0'

                    //implementation 'com.google.android.material:material:1.6.0'

                    
                    //lombok
                    compileOnly 'org.projectlombok:lombok:1.18.24'
                    annotationProcessor 'org.projectlombok:lombok:1.18.24'

                    testCompileOnly 'org.projectlombok:lombok:1.18.24'
                    testAnnotationProcessor 'org.projectlombok:lombok:1.18.24'


                    //material
                    //implementation 'androidx.appcompat:appcompat:1.4.1'
                    //implementation 'com.google.android.material:material:1.6.0'

				//}"
    End Function

    Public Function ReleaseAPKAppGradle() As String
        Return "//ToDo
                //1. Change Build Variant to Release 
                //2. Ensure storeFile file matches correct path
                //android {
                    signingConfigs {
                        release {
                            storeFile file('" & GetEnvironmentVariableForUser(EnvironmentVariableKey.storeFile.ToString) & "')
                            storePassword '" & GetEnvironmentVariableForUser(EnvironmentVariableKey.storePassword.ToString) & "'
                            keyAlias '" & GetEnvironmentVariableForUser(EnvironmentVariableKey.keyAlias.ToString) & "'
                            keyPassword '" & GetEnvironmentVariableForUser(EnvironmentVariableKey.keyPassword.ToString) & "'
                        }
                    }

                //buildTypes {
                        //release {
                            //minifyEnabled false
                            //proguardFiles getDefaultProguardFile('proguard-android-optimize.txt'), 'proguard-rules.pro'
                            debuggable false
                            signingConfig signingConfigs.release
                        //}
                    //}
                "
    End Function

    Public Function ProjectGradle() As String
        Return "//buildscript {
                    //repositories {
                        //google()
                        //jcenter()
                        mavenCentral()
                    //}



                //allprojects {
                    //repositories {
                        //google()
                        //jcenter()
                        maven { url 'https://jitpack.io' }
                    //}
                //}"
    End Function
#End Region

#Region "API"
    Public Function GoogleSheets() As String
        Return "import com.google.api.services.sheets.v4.Sheets;
import com.google.api.services.sheets.v4.model.*;
import com.google.common.collect.Lists;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class SpreadsheetSnippets {
    private Sheets service;

    public SpreadsheetSnippets(Sheets service) {
        this.service = service;
    }

    public String create(String title) throws IOException {
        Sheets service = this.service;
        // [START sheets_create]
        Spreadsheet spreadsheet = new Spreadsheet()
                .setProperties(new SpreadsheetProperties()
                        .setTitle(title));
        spreadsheet = service.spreadsheets().create(spreadsheet)
                .setFields(""spreadsheetId"")
                .execute();
        System.out.println(""Spreadsheet ID: "" + spreadsheet.getSpreadsheetId());
        // [END sheets_create]
        return spreadsheet.getSpreadsheetId();
    }

    public BatchUpdateSpreadsheetResponse batchUpdate(String spreadsheetId, String title,
                                                      String find, String replacement)
            throws IOException {
        Sheets service = this.service;
        // [START sheets_batch_update]
        List<Request> requests = new ArrayList<>();
        // Change the spreadsheet's title.
        requests.add(new Request()
                .setUpdateSpreadsheetProperties(new UpdateSpreadsheetPropertiesRequest()
                        .setProperties(new SpreadsheetProperties()
                                .setTitle(title))
                        .setFields(""title"")));
        // Find and replace text.
        requests.add(new Request()
                .setFindReplace(new FindReplaceRequest()
                        .setFind(find)
                        .setReplacement(replacement)
                        .setAllSheets(true)));
        // Add additional requests (operations) ...

        BatchUpdateSpreadsheetRequest body =
                new BatchUpdateSpreadsheetRequest().setRequests(requests);
        BatchUpdateSpreadsheetResponse response =
                service.spreadsheets().batchUpdate(spreadsheetId, body).execute();
        FindReplaceResponse findReplaceResponse = response.getReplies().get(1).getFindReplace();
        System.out.printf(""%d replacements made."", findReplaceResponse.getOccurrencesChanged());
        // [END sheets_batch_update]
        return response;
    }

    public ValueRange getValues(String spreadsheetId, String range) throws IOException {
        Sheets service = this.service;
        // [START sheets_get_values]
        ValueRange result = service.spreadsheets().values().get(spreadsheetId, range).execute();
        int numRows = result.getValues() != null ? result.getValues().size() : 0;
        System.out.printf(""%d rows retrieved."", numRows);
        // [END sheets_get_values]
        return result;
    }

    public BatchGetValuesResponse batchGetValues(String spreadsheetId, List<String> _ranges)
            throws IOException {
        Sheets service = this.service;
        // [START sheets_batch_get_values]
        List<String> ranges = Arrays.asList(
                //Range names ...
        );
        // [START_EXCLUDE silent]
        ranges = _ranges;
        // [END_EXCLUDE]
        BatchGetValuesResponse result = service.spreadsheets().values().batchGet(spreadsheetId)
                .setRanges(ranges).execute();
        System.out.printf(""%d ranges retrieved."", result.getValueRanges().size());
        // [END sheets_batch_get_values]
        return result;
    }
    public UpdateValuesResponse updateValues(String spreadsheetId, String range,
                                             String valueInputOption, List<List<Object>> _values)
            throws IOException {
        Sheets service = this.service;
        // [START sheets_update_values]
        List<List<Object>> values = Arrays.asList(
                Arrays.asList(
                        // Cell values ...
                )
                // Additional rows ...
        );
        // [START_EXCLUDE silent]
        values = _values;
        // [END_EXCLUDE]
        ValueRange body = new ValueRange()
                .setValues(values);
        UpdateValuesResponse result =
                service.spreadsheets().values().update(spreadsheetId, range, body)
                        .setValueInputOption(valueInputOption)
                        .execute();
        System.out.printf(""%d cells updated."", result.getUpdatedCells());
        // [END sheets_update_values]
        return result;
    }

    public BatchUpdateValuesResponse batchUpdateValues(String spreadsheetId, String range,
                                                       String valueInputOption,
                                                       List<List<Object>> _values)
            throws IOException {
        Sheets service = this.service;
        // [START sheets_batch_update_values]
        List<List<Object>> values = Arrays.asList(
                Arrays.asList(
                        // Cell values ...
                )
                // Additional rows ...
        );
        // [START_EXCLUDE silent]
        values = _values;
        // [END_EXCLUDE]
        List<ValueRange> data = new ArrayList<>();
        data.add(new ValueRange()
                .setRange(range)
                .setValues(values));
        // Additional ranges to update ...

        BatchUpdateValuesRequest body = new BatchUpdateValuesRequest()
                .setValueInputOption(valueInputOption)
                .setData(data);
        BatchUpdateValuesResponse result =
                service.spreadsheets().values().batchUpdate(spreadsheetId, body).execute();
        System.out.printf(""%d cells updated."", result.getTotalUpdatedCells());
        // [END sheets_batch_update_values]
        return result;
    }

    public AppendValuesResponse appendValues(String spreadsheetId, String range,
                                             String valueInputOption, List<List<Object>> _values)
            throws IOException {
        Sheets service = this.service;
        // [START sheets_append_values]
        List<List<Object>> values = Arrays.asList(
                Arrays.asList(
                        // Cell values ...
                )
                // Additional rows ...
        );
        // [START_EXCLUDE silent]
        values = _values;
        // [END_EXCLUDE]
        ValueRange body = new ValueRange()
                .setValues(values);
        AppendValuesResponse result =
                service.spreadsheets().values().append(spreadsheetId, range, body)
                        .setValueInputOption(valueInputOption)
                        .execute();
        System.out.printf(""%d cells appended."", result.getUpdates().getUpdatedCells());
        // [END sheets_append_values]
        return result;
    }

    public BatchUpdateSpreadsheetResponse pivotTables(String spreadsheetId) throws IOException {
        Sheets service = this.service;

        // Create two sheets for our pivot table.
        List<Request> sheetsRequests = new ArrayList<>();
        sheetsRequests.add(new Request().setAddSheet(new AddSheetRequest()));
        sheetsRequests.add(new Request().setAddSheet(new AddSheetRequest()));

        BatchUpdateSpreadsheetRequest createSheetsBody = new BatchUpdateSpreadsheetRequest()
                .setRequests(sheetsRequests);
        BatchUpdateSpreadsheetResponse createSheetsResponse = service.spreadsheets()
                .batchUpdate(spreadsheetId, createSheetsBody).execute();
        int sourceSheetId = createSheetsResponse.getReplies().get(0).getAddSheet().getProperties()
                .getSheetId();
        int targetSheetId = createSheetsResponse.getReplies().get(1).getAddSheet().getProperties()
                .getSheetId();

        // [START sheets_pivot_tables]
        PivotTable pivotTable = new PivotTable()
                .setSource(
                        new GridRange()
                                .setSheetId(sourceSheetId)
                                .setStartRowIndex(0)
                                .setStartColumnIndex(0)
                                .setEndRowIndex(20)
                                .setEndColumnIndex(7)
                )
                .setRows(Collections.singletonList(
                        new PivotGroup()
                                .setSourceColumnOffset(1)
                                .setShowTotals(true)
                                .setSortOrder(""ASCENDING"")
                ))
                .setColumns(Collections.singletonList(
                        new PivotGroup()
                                .setSourceColumnOffset(4)
                                .setShowTotals(true)
                                .setSortOrder(""ASCENDING"")
                ))
                .setValues(Collections.singletonList(
                        new PivotValue()
                                .setSummarizeFunction(""COUNTA"")
                                .setSourceColumnOffset(4)
                ));
        List<Request> requests = Lists.newArrayList();
        Request updateCellsRequest = new Request().setUpdateCells(new UpdateCellsRequest()
                .setFields(""*"")
                .setRows(Collections.singletonList(
                        new RowData().setValues(
                                Collections.singletonList(
                                        new CellData().setPivotTable(pivotTable))
                        )
                ))
                .setStart(new GridCoordinate()
                        .setSheetId(targetSheetId)
                        .setRowIndex(0)
                        .setColumnIndex(0)

                ));

        requests.add(updateCellsRequest);
        BatchUpdateSpreadsheetRequest updateCellsBody = new BatchUpdateSpreadsheetRequest()
                .setRequests(requests);
        BatchUpdateSpreadsheetResponse result = service.spreadsheets()
                .batchUpdate(spreadsheetId, updateCellsBody).execute();
        // [END sheets_pivot_tables]
        return result;
    }

    public BatchUpdateSpreadsheetResponse conditionalFormat(String spreadsheetId)
            throws IOException {
        // [START sheets_conditional_formatting]
        List<GridRange> ranges = Collections.singletonList(new GridRange()
                .setSheetId(0)
                .setStartRowIndex(1)
                .setEndRowIndex(11)
                .setStartColumnIndex(0)
                .setEndColumnIndex(4)
        );
        List<Request> requests = Arrays.asList(
                new Request().setAddConditionalFormatRule(new AddConditionalFormatRuleRequest()
                        .setRule(new ConditionalFormatRule()
                                .setRanges(ranges)
                                .setBooleanRule(new BooleanRule()
                                        .setCondition(new BooleanCondition()
                                                .setType(""CUSTOM_FORMULA"")
                                                .setValues(Collections.singletonList(
                                                        new ConditionValue().setUserEnteredValue(
                                                                ""=GT($D2,median($D$2:$D$11))"")
                                                ))
                                        )
                                        .setFormat(new CellFormat().setTextFormat(
                                                new TextFormat().setForegroundColor(
                                                        new Color().setRed(0.8f))
                                        ))
                                )
                        )
                        .setIndex(0)
                ),
                new Request().setAddConditionalFormatRule(new AddConditionalFormatRuleRequest()
                        .setRule(new ConditionalFormatRule()
                                .setRanges(ranges)
                                .setBooleanRule(new BooleanRule()
                                        .setCondition(new BooleanCondition()
                                                .setType(""CUSTOM_FORMULA"")
                                                .setValues(Collections.singletonList(
                                                        new ConditionValue().setUserEnteredValue(
                                                                ""=LT($D2,median($D$2:$D$11))"")
                                                ))
                                        )
                                        .setFormat(new CellFormat().setBackgroundColor(
                                                new Color().setRed(1f).setGreen(0.4f).setBlue(0.4f)
                                        ))
                                )
                        )
                        .setIndex(0)
                )
        );

        BatchUpdateSpreadsheetRequest body = new BatchUpdateSpreadsheetRequest()
                .setRequests(requests);
        BatchUpdateSpreadsheetResponse result = service.spreadsheets()
                .batchUpdate(spreadsheetId, body)
                .execute();
        System.out.printf(""%d cells updated."", result.getReplies().size());
        // [END sheets_conditional_formatting]
        return result;
    }
}"

    End Function


#End Region

#Region "Support Functions"
    Private Function GeneralModuleVersion() As String
        Return "0.0.0"
    End Function
#End Region

End Class
