Imports System.IO
Imports System.Runtime.CompilerServices
Imports Dark.Net
Imports modmover.My
Imports SharpCompress
Imports SharpCompress.Common

Public Class MoverForm
    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        DarkNet.Instance.SetWindowThemeForms(Me, Theme.Auto)
    End Sub

    ' я ~НЕ ЗНАЮ~ зачем они именно здесь но ~вЕрОяТНо~
    ' они будут использоваться за пределами одной функции
    ' -------------------------------------
    Private _files As String()
    Private _fileInfo As List(Of FileInfo)
    ' -------------------------------------

    ''' <summary>
    ''' Проверяет список модификаций. 
    ''' Если все выбранные модификации были обнаружены с одним типом загрузчика, 
    ''' возвращает True и определенный ведущий тип загрузчика. 
    ''' </summary>
    Private Async Function SelectedModsHaveSingleLoader() As Task(Of Tuple(Of Boolean, Integer))
        Dim State = True            ' По умолчанию результат отрицательный.
        Dim Template As Integer = 0 ' Значение-образец.
        Dim Loader As Integer = 0   ' Сравниваемый результат

        ' Единственная здоровая мысль, которая пришла в голову: 
        ' определиться с загрузчиком автоматически при импорте первого мода.
        ' (Число, определенное у первого архива, используя DefineLoaderAsync(string))

        Template =
            Await JavaExecAnalyser.DefineLoaderAsync(WorkingDirectories.Default.CommonDirectory + "\" + ImportModsView.Items(0).Text)

        For Each entry As ListViewItem In ImportModsView.Items
            Loader = Await JavaExecAnalyser.DefineLoaderAsync(WorkingDirectories.Default.CommonDirectory + "\" + entry.Text)

            If Loader <> Template Then
                State = False
                Exit For
            End If
        Next
        Return Tuple.Create(State, Template)
    End Function

    ''' <summary>
    ''' Открывает и проверяет список модов (XML)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AnalyseItem_Click(sender As Object, e As EventArgs) Handles AnalyseItem.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog With {
            .Filter = "Схема модификаций|*.xml"
        }

        If dialog.ShowDialog() = DialogResult.OK Then
            Dim model As ModSchema = ModSchema.FromXml(dialog.FileName)

            Dim arr As List(Of String) = New List(Of String) From {
                model.Minecraft,
                model.Loader
            }

            For Each item In model.Mods
                arr.Add(item)
            Next

            Dim dbg As DebugForm = New DebugForm(arr.ToArray())
            dbg.Show()
        End If

    End Sub

    ''' <summary>
    ''' При загрузке главного окна
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MoverForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cminit As Task = InitializeExplorerAsync(WorkingDirectories.Default.CommonDirectory, CommonDirectoryView)
        Dim mcinit As Task = InitializeExplorerAsync(WorkingDirectories.Default.MinecraftDirectory, ImportModsView)
    End Sub

    ''' <summary>
    ''' Отображает все файлы внутри папок (WorkingDirectories)
    ''' </summary>
    ''' <returns></returns>
    Private Function InitializeExplorerAsync(path As String, panel As ListView) As Task
        Try
            Dim list As List(Of FileInfo) = New List(Of FileInfo)

            For Each jar As String In Directory.GetFiles(path)
                Dim fileInfo As FileInfo = New FileInfo(jar)
                list.Add(fileInfo)

                panel.Items.Add(fileInfo.Name, 0)
            Next
            _fileInfo = list ' _fileInfo будет постоянно меняться в процессе редактирования

            panel.LargeImageList = iconList
            panel.SmallImageList = iconList

        Catch exc As Exception
            MessageBox.Show(exc.ToString(), "Stop")
        End Try

        Return Task.CompletedTask
    End Function

    ''' <summary>
    ''' Удаляет ВСЕ элементы в импортируемых архивах
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearImportModsItem_Click(sender As Object, e As EventArgs) Handles ClearImportModsItem.Click
        ImportModsView.Clear()
    End Sub


    ''' <summary>
    ''' Если нажать DEL выбрав элемент, он удалится из списка
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ImportModsView_KeyDown(sender As Object, e As KeyEventArgs) Handles ImportModsView.KeyDown
        Select Case e.KeyValue
            Case Keys.Delete
                For Each item In ImportModsView.SelectedItems
                    ImportModsView.Items.Remove(item)
                Next
        End Select
    End Sub

    ''' <summary>
    ''' Добавляет выбранные элементы в импортируемые архивы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CommonDirectoryView_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles CommonDirectoryView.MouseDoubleClick
        AddModification()
    End Sub

    ''' <summary>
    ''' Добавляет список модификаций из общей папки в импортируемые архивы
    ''' </summary>
    Private Sub AddModification()
        For Each item As ListViewItem In CommonDirectoryView.SelectedItems
            ImportModsView.Items.Add(item.Clone())
        Next
    End Sub

    ''' <summary>
    ''' Если нажать enter в выбранных общих архивах, они добавятся в импортируемые
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CommonDirectoryView_KeyDown(sender As Object, e As KeyEventArgs) Handles CommonDirectoryView.KeyDown
        Select Case e.KeyValue
            Case Keys.Enter
                AddModification()
        End Select
    End Sub

    ''' <summary>
    ''' Реакция на указание "Сохранить" в меню "Файл"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveSchrmeItem_Click(sender As Object, e As EventArgs) Handles SaveSchrmeItem.Click
        Dim task = CreateModSchemaAsync()
    End Sub

    ''' <summary>
    ''' Сохраняет все импортируемые архивы в виде XML разметки которая в дальнейшем
    ''' будет использоваться для быстрой загрузки сборки
    ''' </summary>
    Private Async Function CreateModSchemaAsync() As Task

        Dim singleLoader As Tuple(Of Boolean, Integer) =
            Await SelectedModsHaveSingleLoader()

        If Not singleLoader.Item1 Then
            MessageBox.Show(
                "Выбранные вами модификации используют разные загрузчики. Будьте осторожны",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
        End If

        Dim version As String = InputBox(
            "Укажите версию Minecraft для которой используется сборка",
            "Версия Minecraft",
            "1.20.4"
        )

        Dim dialog As New SaveFileDialog() With {
            .Filter = "Схема Модификаций (*.XML)|*.XML",
            .Title = "Сохранение файла сборки",
            .InitialDirectory = Environment.SpecialFolder.Desktop
        }

        If dialog.ShowDialog() = DialogResult.OK Then
            Dim jars As List(Of String) = New List(Of String)

            For Each item As ListViewItem In ImportModsView.Items
                jars.Add(WorkingDirectories.Default.CommonDirectory + "\" + item.Text)
            Next

            Dim model As ModSchema =
                New ModSchema(
                    singleLoader.Item2,
                    version,
                    jars
                )

            Dim result As XDocument = ModSchema.ToXml(model)
            result.Save(dialog.FileName)
        End If
    End Function

    Private Sub OpenSchemeItem_Click(sender As Object, e As EventArgs) Handles OpenSchemeItem.Click
        Dim dialog As OpenFileDialog = New OpenFileDialog() With {
            .Filter = "Схема модификаций|*.xml",
            .Title = "Открытие схемы подключаемых модификаций",
            .InitialDirectory = Environment.SpecialFolder.Desktop
        }

        If dialog.ShowDialog() = DialogResult.OK Then
            Dim model As ModSchema = ModSchema.FromXml(dialog.FileName)

            ImportModsView.Clear()
            For Each item As String In model.Mods
                ImportModsView.Items.Add(
                    New FileInfo(item).Name,
                    0
                )
            Next

            ImportModsView.LargeImageList = iconList

        End If

    End Sub

    ''' <summary>
    ''' Удаляет все модификации в папке модов игры
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearDirectoryItem_Click(sender As Object, e As EventArgs) Handles ClearDirectoryItem.Click
        For Each ifile In Directory.EnumerateFiles(WorkingDirectories.Default.MinecraftDirectory)
            File.Delete(ifile)
        Next
    End Sub

    ''' <summary>
    ''' Переносит все модификации из сборки в папку модификаций игры. 
    ''' (Только если все недостающие моды существуют в общей папке)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MoveToMinecraftItem_Click(sender As Object, e As EventArgs) Handles MoveToMinecraftItem.Click
        Dim mv = MoveAsync()

        While Not mv.IsCompleted
            ImportModsView.Enabled = False
        End While

        ImportModsView.Enabled = True

    End Sub

    ''' <summary>
    ''' Перемещает все файлы, указанные в импортируемых (ImportModsView)
    ''' </summary>
    ''' <returns></returns>
    Private Function MoveAsync() As Task
        For Each modif As ListViewItem In ImportModsView.Items
            File.Copy(
                WorkingDirectories.Default.CommonDirectory + "\" + modif.Text,
                WorkingDirectories.Default.MinecraftDirectory + "\" + modif.Text,
                True
            )
        Next
        Return Task.CompletedTask
    End Function

    ''' <summary>
    ''' Устанавливает новые значения для параметров хранимых рабочие каталоги
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SetupDirectoriesItem_Click(sender As Object, e As EventArgs) Handles SetupDirectoriesItem.Click
        Dim cmf As String = Environment.SpecialFolder.MyDocuments
        Dim mcf As String = Environment.SpecialFolder.Desktop

        Dim cmd As FolderBrowserDialog = New FolderBrowserDialog With {
            .Description = "Укажите Общую папку (где содержатся все моды)"
        }

        Dim mcd As FolderBrowserDialog = New FolderBrowserDialog With {
            .Description = "Укажите папку модификаций Minecraft"
        }


        If cmd.ShowDialog() = DialogResult.OK Then
            cmf = cmd.SelectedPath
        End If

        If mcd.ShowDialog() = DialogResult.OK Then
            mcf = mcd.SelectedPath
        End If

        WorkingDirectories.Default.MinecraftDirectory = mcf
        WorkingDirectories.Default.CommonDirectory = cmf

        WorkingDirectories.Default.Save()
    End Sub
End Class
