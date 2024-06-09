<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoverForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoverForm))
        Me.mainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.AайлToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenSchemeItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSchrmeItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalyseItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЛеваяПанельToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToMinecraftItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearImportModsItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearDirectoryItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НастройкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupDirectoriesItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CommonDirectoryView = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImportModsView = New System.Windows.Forms.ListView()
        Me.iconList = New System.Windows.Forms.ImageList(Me.components)
        Me.mainMenuStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenuStrip
        '
        Me.mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AайлToolStripMenuItem, Me.ЛеваяПанельToolStripMenuItem, Me.НастройкиToolStripMenuItem})
        Me.mainMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.mainMenuStrip.Name = "mainMenuStrip"
        Me.mainMenuStrip.Size = New System.Drawing.Size(488, 24)
        Me.mainMenuStrip.TabIndex = 0
        Me.mainMenuStrip.Text = "MenuStrip1"
        '
        'AайлToolStripMenuItem
        '
        Me.AайлToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenSchemeItem, Me.SaveSchrmeItem, Me.AnalyseItem})
        Me.AайлToolStripMenuItem.Name = "AайлToolStripMenuItem"
        Me.AайлToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AайлToolStripMenuItem.Text = "Файл"
        '
        'OpenSchemeItem
        '
        Me.OpenSchemeItem.Name = "OpenSchemeItem"
        Me.OpenSchemeItem.Size = New System.Drawing.Size(166, 22)
        Me.OpenSchemeItem.Text = "Открыть"
        '
        'SaveSchrmeItem
        '
        Me.SaveSchrmeItem.Name = "SaveSchrmeItem"
        Me.SaveSchrmeItem.Size = New System.Drawing.Size(166, 22)
        Me.SaveSchrmeItem.Text = "Сохранить"
        '
        'AnalyseItem
        '
        Me.AnalyseItem.Name = "AnalyseItem"
        Me.AnalyseItem.Size = New System.Drawing.Size(166, 22)
        Me.AnalyseItem.Text = "Проверить Файл"
        '
        'ЛеваяПанельToolStripMenuItem
        '
        Me.ЛеваяПанельToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveToMinecraftItem, Me.ClearImportModsItem, Me.ClearDirectoryItem})
        Me.ЛеваяПанельToolStripMenuItem.Name = "ЛеваяПанельToolStripMenuItem"
        Me.ЛеваяПанельToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ЛеваяПанельToolStripMenuItem.Text = "Сборка"
        '
        'MoveToMinecraftItem
        '
        Me.MoveToMinecraftItem.Name = "MoveToMinecraftItem"
        Me.MoveToMinecraftItem.Size = New System.Drawing.Size(196, 22)
        Me.MoveToMinecraftItem.Text = "Перенести в Minecraft"
        '
        'ClearImportModsItem
        '
        Me.ClearImportModsItem.Name = "ClearImportModsItem"
        Me.ClearImportModsItem.Size = New System.Drawing.Size(196, 22)
        Me.ClearImportModsItem.Text = "Очистить сборку"
        '
        'ClearDirectoryItem
        '
        Me.ClearDirectoryItem.Name = "ClearDirectoryItem"
        Me.ClearDirectoryItem.Size = New System.Drawing.Size(196, 22)
        Me.ClearDirectoryItem.Text = "Очистить папку"
        '
        'НастройкиToolStripMenuItem
        '
        Me.НастройкиToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetupDirectoriesItem})
        Me.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem"
        Me.НастройкиToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.НастройкиToolStripMenuItem.Text = "Настройки"
        '
        'SetupDirectoriesItem
        '
        Me.SetupDirectoriesItem.Name = "SetupDirectoriesItem"
        Me.SetupDirectoriesItem.Size = New System.Drawing.Size(180, 22)
        Me.SetupDirectoriesItem.Text = "Указать папки"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CommonDirectoryView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImportModsView)
        Me.SplitContainer1.Size = New System.Drawing.Size(488, 317)
        Me.SplitContainer1.SplitterDistance = 236
        Me.SplitContainer1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Общая папка (модификаций)"
        '
        'CommonDirectoryView
        '
        Me.CommonDirectoryView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CommonDirectoryView.HideSelection = False
        Me.CommonDirectoryView.Location = New System.Drawing.Point(3, 30)
        Me.CommonDirectoryView.Name = "CommonDirectoryView"
        Me.CommonDirectoryView.Size = New System.Drawing.Size(230, 287)
        Me.CommonDirectoryView.TabIndex = 0
        Me.CommonDirectoryView.UseCompatibleStateImageBehavior = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Сборка"
        '
        'ImportModsView
        '
        Me.ImportModsView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ImportModsView.HideSelection = False
        Me.ImportModsView.Location = New System.Drawing.Point(3, 30)
        Me.ImportModsView.Name = "ImportModsView"
        Me.ImportModsView.Size = New System.Drawing.Size(242, 284)
        Me.ImportModsView.TabIndex = 0
        Me.ImportModsView.UseCompatibleStateImageBehavior = False
        '
        'iconList
        '
        Me.iconList.ImageStream = CType(resources.GetObject("iconList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iconList.TransparentColor = System.Drawing.Color.Transparent
        Me.iconList.Images.SetKeyName(0, "javarc.ico")
        '
        'MoverForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 341)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.mainMenuStrip)
        Me.Name = "MoverForm"
        Me.Text = "Обзор"
        Me.mainMenuStrip.ResumeLayout(False)
        Me.mainMenuStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainMenuStrip As MenuStrip
    Friend WithEvents AайлToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenSchemeItem As ToolStripMenuItem
    Friend WithEvents SaveSchrmeItem As ToolStripMenuItem
    Friend WithEvents AnalyseItem As ToolStripMenuItem
    Friend WithEvents ЛеваяПанельToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CommonDirectoryView As ListView
    Friend WithEvents ImportModsView As ListView
    Friend WithEvents iconList As ImageList
    Friend WithEvents MoveToMinecraftItem As ToolStripMenuItem
    Friend WithEvents ClearImportModsItem As ToolStripMenuItem
    Friend WithEvents НастройкиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetupDirectoriesItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ClearDirectoryItem As ToolStripMenuItem
End Class
