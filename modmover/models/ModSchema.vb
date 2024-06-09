Imports System.Management.Instrumentation
Imports System.Runtime.CompilerServices
''' <summary>
''' Модель схемы собранных модификаций для быстрой загрузки сборки
''' </summary>
Public Class ModSchema
    Public Loader As Integer
    Public Minecraft As String
    Public Mods As String()

    Public Sub New(
        type As Integer,
        version As String,
        modlist As List(Of String)
    )
        Loader = type
        Minecraft = version
        Mods = modlist.ToArray()
    End Sub


    ''' <summary>
    ''' Извлекает информацию из схемы модификаций
    ''' </summary>
    ''' <param name="path">Путь до файла + сам файл.xml</param>
    ''' <returns>Модель схемы</returns>
    Public Shared Function FromXml(path As String) As ModSchema
        Dim version As String = "0"
        Dim type As Integer = -1
        Dim list As List(Of String) = New List(Of String)

        Try
            Dim document As XDocument = XDocument.Load(path)

            version = document.Descendants().Elements("Version").First()
            type = document.Descendants().Elements("Loader").First()

            For Each item As String In document.Descendants().Elements("Mod")
                list.Add(item)
            Next

        Catch ex As Exception
            Dim msg = ErrorAnalyser.ReportAsync(ex.Message)
        End Try

        Return New ModSchema(type, version, list)
    End Function

    ''' <summary>
    ''' Создает экземпляр разметки (XDocument) на основе переданной модели
    ''' Если во время операции произошла ошибка, она запишется в документ
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ToXml(model As ModSchema) As XDocument
        Try

            Dim root As XElement = New XElement("mods")
            root.Add(New XElement("Loader", model.Loader))
            root.Add(New XElement("Version", model.Minecraft))

            For Each item As String In model.Mods
                root.Add(New XElement("Mod", item))
            Next

            Dim document As XDocument = New XDocument()
            document.Add(root)

            Return document

        Catch ex As Exception
            Dim msh = ErrorAnalyser.ReportAsync(ex.Message)

            Return New XDocument(
                New XElement("HandledException", ex.ToString)
            )

        End Try
    End Function
End Class
