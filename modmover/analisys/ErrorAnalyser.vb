Public Class ErrorAnalyser
    ''' <summary>
    ''' Отправляет сообщение об ошибке, (в дальнейшем обрабатывает ее и записывает в журнал)
    ''' </summary>
    ''' <param name="message"></param>
    Public Shared Sub Report(message As String)
        MessageBox.Show(
            message,
            "Stop",
            MessageBoxButtons.OK,
            MessageBoxIcon.Stop
        )
    End Sub

    ''' <summary>
    ''' (Поддерживает ожидание) Отправляет сообщение об ошибке (в дальнейшем обрабатывает ее и записывает в журнал событий)
    ''' </summary>
    ''' <param name="message"></param>
    ''' <returns></returns>
    Public Shared Function ReportAsync(message As String) As Task
        MessageBox.Show(
            message,
            "Stop",
            MessageBoxButtons.OK,
            MessageBoxIcon.Stop
        )
        Return Task.CompletedTask
    End Function
End Class
