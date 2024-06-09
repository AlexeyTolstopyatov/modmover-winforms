Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Runtime.Remoting.Messaging
Imports SharpCompress
Imports SharpCompress.Archives
Imports SharpCompress.Readers

Public Class JavaExecAnalyser
    ''' <summary>
    ''' Определяет загрузчик модификации
    ''' Логику обнаружения загрузчика читайте в LoadersDetectionLogic.md
    ''' </summary>
    ''' <param name="address">Путь до файла</param>
    ''' <returns>
    ''' -1 - Во время операции произошла ошибка
    ''' 0 - Необнаружен
    ''' 1 - fabric
    ''' 11 - fabric-based API
    ''' 2 - forge
    ''' 22 - forge-based API
    ''' </returns>
    Public Shared Function DefineLoaderAsync(address As String) As Task(Of Integer)
        Dim type As Integer = 0
        Try
            Using fstream As Stream = File.OpenRead(address)
                Using entries = ReaderFactory.Open(fstream)
                    ' Особенности определения смотрите в LoaderDefinitionLogic.md
                    ' Внутри Java-архива модификации хранится файл конфигурации, с помощью
                    ' которого, архив загружается и определяется.
                    ' (больше смотрите в LoaderDifference.md)

                    While entries.MoveToNextEntry()
                        Select Case entries.Entry.Key
                            Case "META-INF/forge/mods.toml"
                            Case "META-INF/mods.toml"
                                If Not entries.Entry.IsDirectory Then
                                    type = 2
                                End If
                        End Select

                        ' err: Не удается обнаружить файлы конфигурации fabric-подобных
                        ' type возвращает 0
                        If entries.Entry.Key.Equals("fabric.mod.json", StringComparison.OrdinalIgnoreCase) Then
                            If Not entries.Entry.IsDirectory Then
                                type = 1
                            End If
                        End If

                        If entries.Entry.Key.Equals("quilt.mod.json", StringComparison.OrdinalIgnoreCase) Then
                            If Not entries.Entry.IsDirectory Then
                                type = 11
                            End If
                        End If

                    End While
                End Using
            End Using
            Return Task.FromResult(type)
        Catch e As Exception
            type = -1
            ErrorAnalyser.Report(e.Message)
            Return Task.FromResult(type)
        End Try
    End Function
End Class
