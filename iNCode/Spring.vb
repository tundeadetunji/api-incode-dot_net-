'Imports iNovation.Code.General
Imports iNovation.Code.Web
Public Class Spring
    Public Enum TypeIs
        String_ = 1
        Integer_ = 2
        Float_ = 3
        Long_ = 4
        Double_ = 5
        Boolean_ = 6
    End Enum

    Public Enum SpringBootFileIs
        All = 0
        Models = 1
        Contracts = 2
        Repositories = 3
        Services = 4
        APIController = 5
        UIController = 6
        Application = 7
        IncludesBTT = 8
        IncludesFooter = 9
        IncludesJS = 10
        IncludesNav = 11
        Index = 12
        ApplicationProperties = 13
        ErrorController = 14
        ErrorPage = 15
        NewHTMLPage = 16
        Resources = 17
        CodeFiles = 18
    End Enum

    Public Shared Property SpringBootFileIs_List As List(Of String) = iNovation.Code.General.GetEnum(New SpringBootFileIs)
    Public Shared Property TypeIs_List As List(Of String) = iNovation.Code.General.GetEnum(New TypeIs)

    Private Property package As String
    Private Property project As String
    Private Property entity As String
    Private Property fields As List(Of String)
    Private Property types As List(Of String)

    Public Sub New(base_package__ As String, entity__ As String, fields__ As List(Of String), types__ As List(Of String))
        package = base_package__
        project = CType(iNovation.Code.General.SplitTextInSplits(base_package__, ".", iNovation.Code.General.SideToReturn.AsListOfString), List(Of String))(2)
        entity = toTitleCase(entity__)


        fields = fields__
        types = types__

        fields__.Add("imageUrl")
        types__.Add("String_")
    End Sub

    Public Async Function setupCodeFiles(path_to_main_folder As String, db_username As String, db_password As String) As Task(Of String)
        Dim r As String = ""
        Dim d As List(Of String) = iNovation.Code.General.SplitTextInSplits(package, ".", iNovation.Code.General.SideToReturn.AsListOfString)
        Dim f As String = d(0), s As String = d(1), t As String = d(2)

        Dim main_directory As String = path_to_main_folder
        If main_directory.EndsWith("\") Then main_directory = main_directory.Substring(0, main_directory.Length - 1)

        Dim java_directory As String = main_directory & "\java\" & f & "\" & s & "\" & t
        Dim resources_directory As String = main_directory & "\resources"

        Dim models_directory As String = java_directory & "\business\models"
        Dim contracts_directory As String = java_directory & "\business\policies\contracts"
        Dim repositories_directory As String = java_directory & "\business\repositories\"
        Dim services_directory As String = java_directory & "\business\services\"
        Dim api_directory As String = java_directory & "\web\controllers\api"
        Dim error_directory As String = java_directory & "\web\controllers\error"
        Dim ui_directory As String = java_directory & "\web\controllers\ui"
        Dim app_directory As String = java_directory
        Dim templates_directory As String = resources_directory & "\templates"
        Dim includes_directory As String = resources_directory & "\templates\includes"

        Try
            MkDir(java_directory)
            MkDir(java_directory & "\business\")
            MkDir(models_directory)
            MkDir(contracts_directory)
            MkDir(repositories_directory)
            MkDir(services_directory)
            MkDir(java_directory & "\web\")
            MkDir(java_directory & "\web\controllers\")
            MkDir(api_directory)
            MkDir(error_directory)
            MkDir(ui_directory)
            MkDir(includes_directory)

            WriteText(models_directory & "\" & entity & ".java", model)
            WriteText(contracts_directory & "\" & entity & "Contract.java", contracts)
            WriteText(repositories_directory & "\" & entity & "Repository.java", repositories)
            WriteText(services_directory & "\" & entity & "Service.java", services)
            WriteText(api_directory & "\APIController.java", apiController)
            WriteText(error_directory & "\ErrorController.java", errorController)
            WriteText(ui_directory & "\UIController.java", uiController)
            WriteText(app_directory & "\" & toTitleCase(project) & "Application.java", application)
            WriteText(includes_directory & "\btt.html", includesBTT)
            WriteText(includes_directory & "\footer.html", includesFooter)
            WriteText(includes_directory & "\js.html", includesJS)
            WriteText(includes_directory & "\nav.html", includesNav)
            WriteText(templates_directory & "\error.html", errorPage)
            WriteText(templates_directory & "\index.html", index)
            WriteText(resources_directory & "\application.properties", applicationProperties(db_username, db_password))
            r = "files and folders were created successfully"
        Catch ex As Exception
            r = "errors were encountered while setting up. " & ex.Message
        End Try

        Return r
    End Function

    Public Async Function setupResources(path_to_main_folder As String, resources_directory As String) As Task(Of String)
        Dim directory As String = path_to_main_folder
        If directory.EndsWith("\") Then directory = directory.Substring(0, directory.Length - 1)
        Dim tgt As String = directory & "\resources\static"
        Dim r As String = ""
        Try

            r = "files and folders were copied successfully"
        Catch ex As Exception
            r = "errors were encountered while setting up resources. " & ex.Message
        End Try
        My.Computer.FileSystem.CopyDirectory(resources_directory, tgt, FileIO.UIOption.AllDialogs)
        Return r
    End Function

    Public Function applicationProperties(db_username As String, db_password As String) As String
        Return "spring.datasource.url=jdbc:mysql://localhost:3306/" + project + "
                spring.datasource.username=" + db_username + "
                spring.datasource.password=" + db_password + "
                spring.jpa.hibernate.ddl-auto=create
                //spring.jpa.hibernate.ddl-auto=update
                spring.jpa.properties.hibernate.show_sql=false
                spring.jpa.properties.hibernate.dialect=org.hibernate.dialect.MySQL8Dialect
                spring.jpa.properties.hibernate.format_sql=true"
    End Function

    Public Function model() As String
        Dim f As List(Of String) = fields
        Dim t As List(Of String) = types
        Dim r As String = "package " + package + ".business.models;

import javax.persistence.*;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.UUID;

@Entity
public class " + toTitleCase(entity) + " {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
" + vbCrLf

        For i = 0 To f.Count - 1
            r &= "@Column(unique = false, nullable = false, length = 50)
    private " & typeFromEnum(t(i)) & " " & f(i) & ";" & vbCrLf & vbCrLf
        Next

        r &= "@Column(unique = true, nullable = false, length = 50)
    private String uuid = UUID.randomUUID().toString();

    @Column(nullable = false, length = 50)
    private String createdOn = new SimpleDateFormat(""yyyy/MM/dd HH:mm:ss"").format(new Date(System.currentTimeMillis()));

    @Column(nullable = false, length = 50)
    private String lastModified = new SimpleDateFormat(""yyyy/MM/dd"").format(new Date(System.currentTimeMillis()));" & vbCrLf & vbCrLf

        r &= "public " & toTitleCase(entity) & "() {
    }" & vbCrLf & vbCrLf

        r &= "public " & toTitleCase(entity) & "(Long id, "

        For i = 0 To f.Count - 1
            r &= typeFromEnum(t(i)) & " " & f(i)
            If i <> f.Count - 1 Then r &= ", "
        Next

        r &= ") {" & vbCrLf

        For i = 0 To f.Count - 1
            r &= "this." & f(i) & " = " & f(i) & ";" & vbCrLf
        Next

        r &= "}" & vbCrLf & vbCrLf

        For i = 0 To f.Count - 1
            r &= "public " & typeFromEnum(t(i)) & " get" & toTitleCase(f(i)) & "() {
        return " & f(i) & ";
    }

    public void set" & toTitleCase(f(i)) & "(" & typeFromEnum(t(i)) & " " & f(i) & ") {
        this." & f(i) & " = " & f(i) & ";
    }" & vbCrLf & vbCrLf
        Next

        r &= "public void setUuid(String uuid) {
        this.uuid = uuid;
    }

    public String getCreatedOn() {
        return createdOn;
    }

    public void setCreatedOn(String createdOn) {
        this.createdOn = createdOn;
    }

    public String getLastModified() {
        return lastModified;
    }

    public void setLastModified(String lastModified) {
        this.lastModified = lastModified;
    }
}"

        Return r
    End Function

    Public Function contracts() As String
        Dim r As String = "package " & package & ".business.policies.contracts;

import " & package & ".business.models." & entity & ";

import java.util.List;

public interface " & entity & "Contract {
    " & entity & " add" & entity & "(" & entity & " " & entity.ToLower & ");
    " & entity & " update" & entity & "(" & entity & " " & entity.ToLower & ");
    List<" & entity & "> get" & entity & "s();
    void delete" & entity & "(" & entity & " " & entity.ToLower & ");
}"

        Return r
    End Function

    Public Function repositories() As String
        Dim r As String = "package " & package & ".business.repositories;

import " & package & ".business.models." & entity & ";
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface " & entity & "Repository extends JpaRepository<" & entity & ", Long> {

}
"

        Return r
    End Function

    Public Function services() As String
        Dim r As String = "package " & package & ".business.services;

import " & package & ".business.models." & entity & ";
import " & package & ".business.policies.contracts." & entity & "Contract;
import " & package & ".business.repositories." & entity & "Repository;
import org.springframework.stereotype.Service;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

@Service
public class " & entity & "Service implements " & entity & "Contract {
    private final " & entity & "Repository repository;

    public " & entity & "Service(" & entity & "Repository repository) {
        this.repository = repository;
    }

    @Override
    public " & entity & " add" & entity & "(" & entity & " " & entity.ToLower & ") {
        return repository.save(" & entity.ToLower & ");
    }
        
    @Override
    public " & entity & " update" & entity & "(" & entity & " " & entity.ToLower & ") {
        " & entity & " result = new " & entity & "();"

        For i = 0 To fields.Count - 1
            r &= "
        result.set" & toTitleCase(fields(i)) & "(" & entity.ToLower & ".get" & toTitleCase(fields(i)) & "());"
        Next

        r &= vbCrLf & "result.setLastModified(new SimpleDateFormat(""yyyy/MM/dd"").format(new Date(System.currentTimeMillis())));
        return repository.save(result);
    }

    @Override
    public List<" & entity & "> get" & entity & "s() {
        return repository.findAll();
    }

    @Override
    public void delete" & entity & "(" & entity & " " & entity.ToLower & ") {
        repository.delete(" & entity.ToLower & ");
    }
}"
        Return r
    End Function

    Public Function apiController() As String
        Dim r As String = "package " & package & ".web.controllers.api;

import " & package & ".business.models." & entity & ";
import " & package & ".business.services." & entity & "Service;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping(""/api"")
public class APIController {
    private final " & entity & "Service service;

    public APIController(" & entity & "Service service) {
        this.service = service;
    }

    @GetMapping(""/" & entity.ToLower & "s"")
    public ResponseEntity<List<" & entity & ">> List" & entity & "s(){
        return ResponseEntity.status(HttpStatus.FOUND).body(service.get" & entity & "s());
    }
}
"
        Return r
    End Function

    Public Function uiController() As String
        Dim r As String = "package " & package & ".web.controllers.ui;

import " & package & ".business.services." & entity & "Service;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.text.SimpleDateFormat;
import java.util.Date;

@Controller
public class UIController {
    private final " & entity & "Service service;

    public UIController(" & entity & "Service service) {
        this.service = service;
    }

    @GetMapping(""/"")
    public String index(Model model){
        model.addAttribute(""" & entity.ToLower & "s"", service.get" & entity & "s());
        model.addAttribute(""year"", new SimpleDateFormat(""yyyy"").format(new Date(System.currentTimeMillis())));
        return ""index"";
    }
}
"
        Return r
    End Function

    Public Function application() As String
        Dim r As String = "package " & package & ";

import " & package & ".business.models." & entity & ";
import " & package & ".business.services." & entity & "Service;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class " & toTitleCase(project) & "Application {

	public static void main(String[] args) {
		SpringApplication.run(" & toTitleCase(project) & "Application.class, args);
	}

	@Bean
	CommandLineRunner runner(" & entity & "Service service){
		return args -> {
			service.add" & entity & "(new " & entity & "(null, "

        For i = 0 To fields.Count - 1
            If fields(i).ToLower = "imageurl" Then
                r &= """" & fields(i) & "" & i + 1 & ".jpg" & "" & """"
            Else
                r &= """" & fields(i) & "_value_here" & """"
            End If
            If i <> fields.Count - 1 Then
                r &= ", "
            End If
        Next

        r &= "));
			"

        r &= "System.out.println(""app started"");
		};
	}
}
"
        Return r
    End Function

    Public Function includesBTT() As String
        Dim r As String = "<div class=""fixed-action-btn"" th:fragment=""btt"" xmlns:th=""http://www.thymeleaf.org"">
    <a onclick=""ScrollToDIVStart(_Top)"" class=""btn-floating btn-large"">
        <i class=""fa fa-chevron-up"" aria-hidden=""true""></i>
    </a>
    <!--<ul>
        <li><a class=""btn-floating red""><i class=""material-icons"">insert_chart</i></a></li>
        <li><a class=""btn-floating yellow darken-1""><i class=""material-icons"">format_quote</i></a></li>
        <li><a class=""btn-floating green""><i class=""material-icons"">publish</i></a></li>
        <li><a class=""btn-floating blue""><i class=""material-icons"">attach_file</i></a></li>
    </ul>-->
</div>
"
        Return r
    End Function

    Public Function includesFooter() As String
        Dim r As String = "<footer class=""page-footer"" th:fragment=""footer"" xmlns:th=""http://www.thymeleaf.org"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col l6 s12"">
                <h5 class=""white-text""><span id=""_Company_Name"">" & toTitleCase(project) & "</span></h5>
                <p class=""grey-text text-lighten-4"">
                    <a href=""#"">1, Company Close, City</a>
                </p>
            </div>
            <div class=""col l4 offset-l2 s12"">
                <h5 class=""white-text"">Let's Connect</h5>
                <ul>
                    <li>
                        <a href=""#""><i class=""fa fas fa-phone"" aria-hidden=""true""></i>&nbsp;&nbsp;+234 000 000 0000</a>
                    <li>
                        <a href=""mailto:email@provider.com""><i class=""fa-solid fa-paper-plane"" aria-hidden=""true""></i>&nbsp;&nbsp;Email</a>
                    <li>
                        <a href=""https://www.facebook.com""><i class=""fa-brands fa-facebook-f"" aria-hidden=""true""></i>&nbsp;&nbsp;Facebook</a>
                    <li>
                        <a href=""https://www.twitter.com""><i class=""fa-brands fa-twitter"" aria-hidden=""true""></i>&nbsp;&nbsp;Twitter</a>
                    <li>
                        <a href=""https://www.instagram.com""><i class=""fa-brands fa-instagram"" aria-hidden=""true""></i>&nbsp;&nbsp;Instagram</a>
                    <li>
                        <a href=""https://wa.me/2340000000000""><i class=""fa-brands fa-whatsapp"" aria-hidden=""true""></i>&nbsp;&nbsp;Whatsapp</a>
                    <li>&nbsp;</li>
                    <li><a class=""grey-text text-lighten-3"" href=""#""><i
                            class=""fa fas fa-legal"" aria-hidden=""true""></i>&nbsp;&nbsp;Legal</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class=""footer-copyright"">
        <div class=""container"">
            Design by <a href=""https://domain-of-designer.com"" target=""_blank"">Designer</a> ©
            [[${year}]], All rights reserved.
        </div>
    </div>
</footer>
"

        Return r
    End Function

    Public Function includesJS() As String
        Dim r As String = "<div th:fragment=""js"" xmlns:th=""http://www.thymeleaf.org"">
    <script type=""text/javascript"">
						function ScrollToDIV(div_) {
							div_.scrollIntoView({ behavior: 'smooth', block: 'center' });
						}
						function ScrollToDIVStart(div_) {
							div_.scrollIntoView({ behavior: 'smooth', block: 'start' });
						}
						function ScrollToDIVCenter(div_) {
							div_.scrollIntoView({ behavior: 'smooth', block: 'center' });
						}

</script>

    <script type=""text/javascript"" th:src=""@{js/materialize.min.js}""></script>

    <script type=""text/javascript"">
						M.AutoInit();

</script>

</div>"
        Return r
    End Function

    Public Function includesNav() As String
        Dim r As String = "<header th:fragment=""nav"" xmlns:th=""http://www.thymeleaf.org"">
    <div class=""navbar-fixed"">
        <nav>
            <div class=""nav-wrapper"">
                <a href=""default"" class=""brand-logo center""><i class=""fa fa-address-book""
                                                               aria-hidden=""true""></i>" & entity & "</a>

            </div>
        </nav>
    </div>
</header>
"
        Return r
    End Function

    Public Function index() As String
        Dim r As String = "<!DOCTYPE html>
<html lang=""en"" xmlns:th=""http://www.thymeleaf.org"">

<head th:fragment=""css"" xmlns:th=""http://www.thymeleaf.org"">
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>" & toTitleCase(project) & " | Home</title>
    <link th:href=""@{/images/icons/favicon.png}"" rel=""shortcut icon"" type=""image/x-icon""/>
    <link rel=""stylesheet"" th:href=""@{css/materialize/materialize.min.css}""/>
    <link rel=""stylesheet"" th:href=""@{css/all.css}""/>
    <link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
</head>

<body>

<div th:replace=""~{includes/nav :: nav}""></div>


<main>
<!--    <span style=""padding-top: 80px""></span>-->

    <div class=""container"" id=""_Top"">
        <div class=""row"">
            <div th:each=""" & entity.ToLower & " : ${" & entity.ToLower & "s}"" class=""col s12 m6"">
                <div class=""card"">
                    <div class=""card-image waves-effect waves-block waves-light""><img class=""activator""
                                                                                      th:src=""@{/images/regular/} + ${" & entity.ToLower & ".getImageUrl}"">
                    </div>
                    <div class=""card-content"">
                        <span class=""card-title activator grey-text text-darken-4"">[[${" & entity.ToLower & ".getUuid}]]<i class=""material-icons right"">more_vert</i></span>
                        <p><a href=""#"">[[${" & entity.ToLower & ".getCreatedOn}]]</a></p>
                    </div>
                    <div class=""card-reveal"">
                        <span class=""card-title grey-text text-darken-4"">[[${" & entity.ToLower & ".getUuid}]]<i class=""material-icons right"">close</i></span>
                        <p>[[${" & entity.ToLower & ".getCreatedOn}]]</p>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div th:replace=""~{includes/btt :: btt}""></div>

    <div th:replace=""~{includes/footer :: footer}""></div>
</main>


<div th:replace=""~{includes/js :: js}""></div>

</body>
</html>"

        Return r
    End Function

    Public Function errorController() As String
        Dim r As String = "package " & package & ".web.controllers.error;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class ErrorController {

    @GetMapping(""/error"")
    public String showErrorPage(){
        return ""error"";
    }

}
"
        Return r
    End Function

    Public Function errorPage() As String
        Dim r As String = "<!DOCTYPE html>
<html lang=""en"" xmlns:th=""http://www.thymeleaf.org"">

<head th:fragment=""css"" xmlns:th=""http://www.thymeleaf.org"">
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Error</title>
    <link th:href=""@{/images/icons/favicon.png}"" rel=""shortcut icon"" type=""image/x-icon""/>
    <link rel=""stylesheet"" th:href=""@{css/materialize/materialize.min.css}""/>
    <link rel=""stylesheet"" th:href=""@{css/all.css}""/>
    <link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
</head>

<body>

<div th:replace=""~{includes/nav :: nav}""></div>


<main>

    <div class=""container"" id=""_Top"">
        <div class=""row"">
            <div class=""col s12"">
                <div class=""card blue-grey darken-1 hoverable"">
                    <div class=""card-content white-text"">
                        <span class=""card-title"">Oops!</span>
                        <p>The resource you're looking for seems not reachable at the moment, but will be available shortly.
                            <br><br> Please try again soon - closing the browser tab/window and clearing your cache might help!</p>
                    </div>
                    <div class=""card-action"">
                        <a th:href=""@{/}""><i class=""fa fa-home""
                                       aria-hidden=""true""></i></a></a>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div th:replace=""~{includes/btt :: btt}""></div>

    <div th:replace=""~{includes/footer :: footer}""></div>
</main>


<div th:replace=""~{includes/js :: js}""></div>

</body>
</html>"

        Return r
    End Function

    Public Function newHTMLPage(title As String) As String
        Dim r As String = "<!DOCTYPE html>
<html lang=""en"" xmlns:th=""http://www.thymeleaf.org"">

<head th:fragment=""css"" xmlns:th=""http://www.thymeleaf.org"">
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>" & title & " | " & toTitleCase(project) & "</title>
    <link th:href=""@{/images/icons/favicon.png}"" rel=""shortcut icon"" type=""image/x-icon""/>
    <link rel=""stylesheet"" th:href=""@{css/materialize/materialize.min.css}""/>
    <link rel=""stylesheet"" th:href=""@{css/all.css}""/>
    <link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
</head>

<body>

<div th:replace=""~{includes/nav :: nav}""></div>


<main>

    <div class=""container"" id=""_Top"">
        <div class=""row"">
            <div class=""col s12"">

            </div>
        </div>
    </div>


    <div th:replace=""~{includes/btt :: btt}""></div>

    <div th:replace=""~{includes/footer :: footer}""></div>
</main>


<div th:replace=""~{includes/js :: js}""></div>

</body>
</html>"

        Return r
    End Function

    Private Function typeFromEnum(type As String) As String
        Return stringToEnum(type)
    End Function
End Class
