Imports Dark.Net

Public Class DebugForm
    Public Sub New(dbg As String())

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        DarkNet.Instance.SetWindowThemeForms(Me, Theme.Auto)
        DarkNet.Instance.SetCurrentProcessTheme(Theme.Auto)

        For Each txt As String In dbg
            debugBox.AppendText(txt + Environment.NewLine)
        Next
    End Sub
End Class