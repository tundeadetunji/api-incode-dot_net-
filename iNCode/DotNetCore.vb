Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Public Class DotNetCore

#Region "Logging"

    Public Enum LoggingLevel
        VerboseLevel = 1
        DebugLevel = 2
        InformationLevel = 3
        WarningLevel = 4
        ErrorLevel = 5
        FatalLevel = 6
    End Enum
    Public Enum ConsoleLoggingLevel
        DebugLevel = 1
        VerboseLevel = 2
        InformationLevel = 3
        WarningLevel = 4
        ErrorLevel = 5
        FatalLevel = 6
    End Enum
    Public Enum FileLoggingLevel
        VerboseLevel = 1
        DebugLevel = 2
        InformationLevel = 3
        WarningLevel = 4
        ErrorLevel = 5
        FatalLevel = 6
    End Enum
    Public Enum SeqLoggingLevel
        DebugLevel = 1
        VerboseLevel = 2
        InformationLevel = 3
        WarningLevel = 4
        ErrorLevel = 5
        FatalLevel = 6
    End Enum

    Private Enum OutputTemplateIs
        Concise = 0
        Verbose = 1
    End Enum
    Private Enum ConsoleOutputTemplateIs
        Concise = 0
        Verbose = 1
    End Enum
    Private Enum FileOutputTemplateIs
        Verbose = 0
        Concise = 1
    End Enum

    Public ReadOnly Property ConsoleLoggingLevel_List As List(Of String) = GetEnum(New ConsoleLoggingLevel)
    Public ReadOnly Property FileLoggingLevel_List As List(Of String) = GetEnum(New FileLoggingLevel)
    Public ReadOnly Property SeqLoggingLevel_List As List(Of String) = GetEnum(New SeqLoggingLevel)
    Public ReadOnly Property ConsoleOutputTemplate_List As List(Of String) = GetEnum(New ConsoleOutputTemplateIs)
    Public ReadOnly Property FileOutputTemplate_List As List(Of String) = GetEnum(New FileOutputTemplateIs)

    'Private Function GetOverrides(overrides_list As List(Of String)) As String
    '    If overrides_list.Count < 1 Then Return ""
    '    Dim r As String = ""
    '    For i = 0 To overrides_list.Count - 1
    '        r &= overrides_list(i)
    '        If i <> overrides_list.Count - 1 Then r &= "," & vbCrLf
    '    Next
    '    Return r & vbCrLf
    'End Function

    'Private Function toFile(directory_fixed As String, filename As String, extension As LogFileExtension) As String
    '    Dim r As String = ""
    '    Dim file As String = filename
    '    If file.Contains(".") = False Then file = file & "." & extension.ToString
    '    If (directory_fixed.EndsWith("\")) Then
    '        r &= directory_fixed & file
    '    Else
    '        r &= directory_fixed & "\\" & file
    '    End If
    '    Return r
    'End Function

    'Private Function GetDestinations(destinations As Dictionary(Of String, Boolean), directory As String, filename As String, server_url As String) As String
    '    Dim r As String = vbCrLf
    '    Dim console As String = "", file As String = "", json As String = "", seq As String = ""
    '    If destinations.Keys.Contains("Console") And CType(destinations.Item("Console"), Boolean) = True Then
    '        console &= "{ ""Name"": ""Console"" }"
    '    End If
    '    If destinations.Count > 1 And console.Length > 0 Then console &= "," & vbCrLf
    '    If destinations.Keys.Contains("File") And CType(destinations.Item("File"), Boolean) = True Then
    '        file &= "{
    '    ""Name"": ""File"",
    '    ""Args"": {
    '      ""path"": """ & toPath(directory) & "" & toFile(toPath(directory), filename, LogFileExtension.txt) & """,
    '      ""outputTemplate"": ""{Timestamp:G} {Message}{NewLine:1}{Exception:1}""
    '    }
    '  }"
    '    End If
    '    If destinations.Count > 2 And file.Length > 0 Then file &= "," & vbCrLf
    '    If destinations.Keys.Contains("JSON") And CType(destinations.Item("JSON"), Boolean) = True Then
    '        json &= "{
    '    ""Name"": ""File"",
    '    ""Args"": {
    '      ""path"": """ & toPath(directory) & "" & toFile(toPath(directory), filename, LogFileExtension.json) & """,
    '      ""formatter"": ""Serilog.Formatting.Json.JsonFormatter, Serilog""
    '    }
    '  }"
    '    End If
    '    If destinations.Count > 3 And json.Length > 0 Then json &= "," & vbCrLf
    '    If destinations.Keys.Contains("Seq") And CType(destinations.Item("JSON"), Boolean) = True Then
    '        seq &= "{
    '    ""Name"": ""Seq"",
    '    ""Args"": {
    '      ""serverUrl"": """ & server_url & """
    '    }
    '  }"
    '    End If
    '    json &= vbCrLf

    '    r &= console & file & json & seq & vbCrLf
    '    Return r
    'End Function

    Public Function LoggingSnippets(console As Boolean, console_minimum_level As String, console_output_template As String, file As Boolean, full_file_path As String, file_minimum_level As String, file_output_template As String, seq As Boolean, seq_minimum_level As String, seq_server_url As String) As Dictionary(Of String, Object)
        Dim page_model_field As String
        Dim usage As String
        Dim page_model_constructor As String
        Dim app_settings As String
        Dim nuget_packages As New List(Of String)
        Dim nuget_packages_batch As String
        Dim using_statement As String

        page_model_field = "public IConfigurationRoot configuration
        {
            get
            {
                return new ConfigurationBuilder().AddJsonFile(""appsettings.json"").Build();
            }
        }"

        usage = "//Log.Information(""Info"");
            try
            {
                //...
                Log.Information(""Success"");
            }
            catch (Exception exception) {
                Log.Error(exception.ToString());
            }
            finally { 
            }"

        page_model_constructor = "//public IndexModel(ILogger<PrivacyModel> logger)
            Log.Logger = new LoggerConfiguration()
                .Enrich.With(new ThreadIdEnricher())
                .Enrich.With(new MachineNameEnricher())
                .Enrich.With(new ProcessIdEnricher())
                .Enrich.With(new ProcessNameEnricher())
                .Enrich.With(new ThreadNameEnricher())
                .Enrich.With(new EnvironmentUserNameEnricher())
                .Enrich.With(new EnvironmentNameEnricher())"
        If console Then page_model_constructor &=
        "
                .WriteTo.Console(Serilog.Events.LogEventLevel." & getMinimumLevel(console_minimum_level) & ", outputTemplate: configuration.GetValue<string>(""serilog_output_template_concise_for_console""))"

        If seq Then page_model_constructor &=
        "
                .WriteTo.Seq(configuration.GetValue<string>(""serilog_seq_server_url""), Serilog.Events.LogEventLevel." & getMinimumLevel(seq_minimum_level) & ")"

        If file Then page_model_constructor &=
        "
                .WriteTo.File(configuration.GetValue<string>(""serilog_text_file_path""), Serilog.Events.LogEventLevel." & getMinimumLevel(file_minimum_level) & ", outputTemplate: configuration.GetValue<string>(""serilog_output_template_verbose_for_file""))"

        page_model_constructor &=
        "
                .CreateLogger();"

        app_settings = """serilog_seq_server_url"": """ & seq_server_url & """,
  ""serilog_text_file_path"": """ & toPath(full_file_path) & """,
  ""serilog_output_template_concise_for_console"": """ & getOutputTemplate(console_output_template) & """,
  ""serilog_output_template_verbose_for_file"": """ & getOutputTemplate(file_output_template) & """"

        using_statement = "using Serilog;
using Serilog.Enrichers;
using Microsoft.Extensions.Configuration;
"

        nuget_packages.Add("Install-Package Serilog.AspNetCore")
        nuget_packages.Add("Install-Package Serilog.Settings.AppSettings")
        nuget_packages.Add("Install-Package Serilog.Settings.Configuration")
        nuget_packages.Add("Install-Package Serilog.Sinks.Console")
        nuget_packages.Add("Install-Package Serilog.Sinks.Email")
        nuget_packages.Add("Install-Package Serilog.Sinks.Seq")
        nuget_packages.Add("Install-Package Serilog.Enrichers.Environment")
        nuget_packages.Add("Install-Package Serilog.Enrichers.Thread")
        nuget_packages.Add("Install-Package Serilog.Enrichers.Process")

        nuget_packages_batch = "Install-Package Serilog.AspNetCore
Install-Package Serilog.Settings.AppSettings
Install-Package Serilog.Settings.Configuration
Install-Package Serilog.Sinks.Console
Install-Package Serilog.Sinks.Email
Install-Package Serilog.Sinks.Seq
Install-Package Serilog.Enrichers.Environment
Install-Package Serilog.Enrichers.Thread
Install-Package Serilog.Enrichers.Process"

        Dim d As New Dictionary(Of String, Object)

        d.Add("page_model_field", page_model_field)
        d.Add("usage", usage)
        d.Add("page_model_constructor", page_model_constructor)
        d.Add("app_settings", app_settings)
        d.Add("nuget_packages", nuget_packages)
        d.Add("using_statement", using_statement)
        d.Add("nuget_packages_batch", nuget_packages_batch)

        Return d
    End Function

    'Private Function level_trim(level As String)
    '    Return level.Replace("Level", "")
    'End Function
    Private Function toPath(file_path As String) As String
        Return file_path.Replace("\", "\\")
    End Function

    Private Function getMinimumLevel(minimum_level As String) As String
        Return minimum_level.Replace("Level", "")
    End Function
    Private Function getOutputTemplate(output_template As String) As String
        Dim r As String = ""
        Select Case output_template
            Case OutputTemplateIs.Concise.ToString
                r = "[{Level:u3}] {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Properties:j} {Message:lj}{NewLine}{Exception1}{NewLine}"
            Case OutputTemplateIs.Verbose.ToString
                r = "[{Level:u3}] {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} | Machine: {MachineName} | Environment User Name: {EnvironmentUserName} | Environment Name: {EnvironmentName} | Process Id: {ProcessId} | Process Name: {ProcessName} | Thread Id: {ThreadId} | Thread Name: {ThreadName} | Message: {Message:lj}{NewLine}Exception: {Exception1}{NewLine}"
        End Select
        Return r
    End Function

#End Region


End Class
