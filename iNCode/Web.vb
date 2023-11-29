'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Public Class Web
#Region "Types"

#End Region

#Region "Other Members"

    Public Enum Components
        Proxy_Quota = 1
        JSONObjectRequest = 2
        JSONArrayRequest = 3
        StringRequest = 4
    End Enum

    Public Enum Methods
        GET_ = 1
        POST_ = 2
        PUT_ = 3
        DELETE_ = 4
    End Enum

    Public Enum APIComponents
        SampleJSON = 1
    End Enum


#End Region

#Region "Support Functions"

#End Region

#Region "Fields"
    Public ReadOnly Property Components_List As List(Of String) = GetEnum(New Components)
    Public ReadOnly Property Methods_List As List(Of String) = GetEnum(New Methods)
    Public ReadOnly Property API_Components_List As List(Of String) = GetEnum(New APIComponents)


#End Region

#Region "New"
#End Region

#Region "API Components"
    Public Function GetSampleJSON(table_ As String, con As String) As String
        Dim query As String = BuildSelectString(table_)
        Dim s As String = SampleJSON(query, con).ToString
        Return s
    End Function
#End Region

#Region "Components"
    Public Function Proxy_Quota() As String
        Return "<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Quota async=""false"" continueOnError=""false"" enabled=""true"" name=""QuotaNameHere"" type=""calendar"">
    <DisplayName>QuotaDisplayNameHere</DisplayName>
    <Properties/>
    <Allow count=""2000"" countRef=""request.header.allowed_quota""/>
    <Interval ref=""request.header.quota_count"">1</Interval>
    <Distributed>false</Distributed>
    <Synchronous>false</Synchronous>
    <TimeUnit ref=""request.header.quota_timeout"">month</TimeUnit>
    <StartTime>2021-6-18 12:00:00</StartTime>
    <AsynchronousConfiguration>
        <SyncIntervalInSeconds>20</SyncIntervalInSeconds>
        <SyncMessageCount>5</SyncMessageCount>
    </AsynchronousConfiguration>
</Quota>"

    End Function

    Public Function StringRequest(url As String, method As String) As String
        Return "//protected void onCreate(Bundle savedInstanceState) {

        //this should go inside onCreate method

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        buttonGet = findViewById(R.id.buttonGet);
        textGet = findViewById(R.id.textGet);

        RequestQueue queue = Volley.newRequestQueue(getApplicationContext());
        url =""" & url & """;
        queue.start();

        StringRequest stringRequest = new StringRequest(Request.Method." & method.Replace("_", "").ToUpper & ", url,
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        //what to do with response, e.g. textGet.setText(response);
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                //handle error, e.g. textGet.setText(""That didn't work!"");
            }
        });


        buttonGet.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                queue.add(stringRequest);
            }
        });
    //}"
    End Function

#End Region

End Class
