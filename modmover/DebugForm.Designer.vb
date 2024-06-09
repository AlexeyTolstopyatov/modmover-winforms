<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.debugBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'debugBox
        '
        Me.debugBox.BackColor = System.Drawing.SystemColors.Control
        Me.debugBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.debugBox.Location = New System.Drawing.Point(12, 12)
        Me.debugBox.Multiline = True
        Me.debugBox.Name = "debugBox"
        Me.debugBox.ReadOnly = True
        Me.debugBox.Size = New System.Drawing.Size(503, 308)
        Me.debugBox.TabIndex = 0
        Me.debugBox.TabStop = False
        '
        'DebugForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 332)
        Me.Controls.Add(Me.debugBox)
        Me.Name = "DebugForm"
        Me.Text = "DebugForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents debugBox As TextBox
End Class
