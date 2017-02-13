Imports System.IO
Imports System.Text

Public Class FormMain
    Inherits System.Windows.Forms.Form

    Dim totallines As Integer = 0                       '总行数
    Dim totalcodelines As Integer = 0                '总的代码行
    Dim totalcommentlines As Integer = 0         '总的注释行
    Dim totalblanklines As Integer = 0              '总的空白行
    Dim totalsize As Integer = 0                        '总的大小

    ''' <summary>
    ''' 窗体加载
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Showdir()   '显示驱动器列表

        ''显示最后设置的保存路径
        txtFilePath.Text = My.Settings.SaveFilePath

    End Sub

    ''' <summary>
    ''' 选择保存目录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelPath.Click
        '选择目录
        FolderBrowserDialog1.Description =
                "请你选择目录，以存放生成的csv文件或者txt文件．没有选择的情况下，默认在C:\"

        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '设置目录
            txtFilePath.Text = FolderBrowserDialog1.SelectedPath
            My.Settings.SaveFilePath = txtFilePath.Text
        End If
    End Sub

    ''' <summary>
    ''' 显示驱动器列表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Showdir()
        Dim drivers() As String = Nothing
        Dim sdesktop() As String
        Dim desktopdir As String
        Dim mydocuments As String
        Dim mydocumentsdir() As String
        drvs = fso.Drives

        desktopdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        sdesktop = desktopdir.Split("\")
        nd = New TreeNode(sdesktop(sdesktop.Length - 1), 1, 1)
        nd.Tag = desktopdir
        tvList.Nodes.Add(nd)

        mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        mydocumentsdir = mydocuments.Split("\")
        nd = New TreeNode((mydocumentsdir(mydocumentsdir.Length - 1)), 8, 8)
        nd.Tag = mydocuments
        tvList.Nodes(0).Nodes.Add(nd)

        fldrs = fso.GetFolder(mydocuments).SubFolders
        If fldrs.Count <> 0 Then
            For Each fldr In fldrs
                nd = New TreeNode(fldr.Name, 0, 2)
                nd.Tag = mydocuments + "\" + fldr.Name
                tvList.Nodes(0).Nodes(0).Nodes.Add(nd)
            Next
        End If
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        fldrs = fso.GetFolder(path).SubFolders
        nd = New TreeNode("我的电脑", 5, 5)
        nd.Tag = "1"
        tvList.Nodes(0).Nodes.Add(nd)

        Dim intimagindex As Integer
        Dim j As Integer = 0
        For Each drv In drvs
            Select Case drv.DriveType
                Case Scripting.DriveTypeConst.CDRom
                    intimagindex = 6
                Case Scripting.DriveTypeConst.RamDisk
                    intimagindex = 3
                Case Scripting.DriveTypeConst.Removable
                    intimagindex = 9
                Case Scripting.DriveTypeConst.Remote
                    intimagindex = 7
                Case Scripting.DriveTypeConst.Fixed
                    intimagindex = 3
            End Select
            If drv.DriveType = Scripting.DriveTypeConst.Fixed Then
                nd = New TreeNode(drv.VolumeName + " (" + drv.Path + ")", intimagindex, intimagindex)
                tvList.Nodes(0).Nodes(1).Nodes.Add(nd)
            Else
                nd = New TreeNode(drv.Path, intimagindex, intimagindex)
                tvList.Nodes(0).Nodes(1).Nodes.Add(New TreeNode(drv.Path, intimagindex, intimagindex))
            End If
            tvList.Nodes(0).Nodes(1).Nodes(j).Tag = drv.Path.ToString
            j += 1
        Next

        fldrs = fso.GetFolder(desktopdir).SubFolders
        Dim ii As Integer = 0
        If fldrs.Count <> 0 Then
            For Each fldr In fldrs
                nd = New TreeNode(fldr.Name, 0, 2)
                nd.Tag = desktopdir + "\" + fldr.Name
                tvList.Nodes(0).Nodes.Add(nd)
                Dim temp As String
                temp = nd.Tag
                fldrs2 = fso.GetFolder(nd.Tag).SubFolders
                For Each fldr2 In fldrs2
                    nd = New TreeNode(fldr2.Name, 0, 2)
                    nd.Tag = temp + "\" + fldr2.Name
                    tvList.Nodes(0).Nodes(ii + 2).Nodes.Add(nd)
                Next
                ii += 1
            Next
        End If
    End Sub


    ''' <summary>
    ''' 展开驱动器目录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvList_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvList.AfterExpand

        drvs = fso.Drives
        Dim i As Integer = 0
        If e.Node.Tag = "1" Then
            For Each drv In drvs
                If drv.DriveType <> Scripting.DriveTypeConst.Removable And drv.DriveType <> Scripting.DriveTypeConst.CDRom Then
                    If drv.IsReady Then
                        fldrs = drv.RootFolder.SubFolders
                        Dim j As Integer = 0
                        For Each fldr In fldrs
                            nd = New TreeNode(fldr.Name, 0, 2)
                            tvList.Nodes(0).Nodes(1).Nodes(i).Nodes.Add(nd)
                            tvList.Nodes(0).Nodes(1).Nodes(i).Nodes(j).Tag = tvList.Nodes(0).Nodes(1).Nodes(i).Tag + "\" + fldr.Name
                            j += 1
                        Next
                    Else
                        MsgBox("无法访问驱动器" + drv.Path + Chr(10) + "设备没有准备好", MsgBoxStyle.RetryCancel, "警告")
                    End If
                    i += 1
                End If
            Next
        End If

        If e.Node.Tag <> "" And e.Node.Tag <> "1" Then
            Dim k As Integer = 0
            For Each nd In e.Node.Nodes
                Try
                    If Not (e.Node.Nodes.Count > 2 AndAlso e.Node.Nodes(1).Tag = "1") Then
                        If e.Node.Nodes(k).Tag <> "1" Then
                            fldrs = fso.GetFolder(e.Node.Nodes(k).Tag).SubFolders
                            Dim kk As Integer = 0
                            If fldrs.Count <> 0 Then
                                For Each fldr In fldrs
                                    nd = New TreeNode(fldr.Name, 0, 2)
                                    e.Node.Nodes(k).Nodes.Add(nd)
                                    e.Node.Nodes(k).Nodes(kk).Tag = e.Node.Nodes(k).Tag + "\" + fldr.Name
                                    kk += 1
                                Next
                            End If
                        End If
                        k += 1
                    End If
                Catch exp As Exception
                End Try
            Next
        End If
    End Sub

    ''' <summary>
    ''' 点击列表事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvList_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvList.AfterCheck
        Dim path As String = e.Node.Tag
        If path = "1" Then
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        End If
        If e.Node.Checked Then
            ' Create three items and three sets of subitems for each item.
            Dim item1 As New ListViewItem(CStr(lvSelected.Items.Count + 1), 0)
            ' Place a check mark next to the item.
            item1.SubItems.Add(path)
            'Add the items to the ListView.
            lvSelected.Items.AddRange(New ListViewItem() {item1})
        Else
            Dim item1 As New ListViewItem()
            For Each item1 In lvSelected.Items
                If item1.SubItems(1).Text = path Then
                    item1.Remove()
                    Exit For
                End If
            Next
        End If
        Dim i As String = 0
        Dim item2 As New ListViewItem()
        For Each item2 In lvSelected.Items
            item2.SubItems(0).Text = CStr(i + 1)
            i += 1
        Next
    End Sub

    ''' <summary>
    ''' 计算函数
    ''' </summary>
    ''' <param name="foundFile"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SourceCounter(ByVal foundFile As String, ByVal path As String)
        Dim lines As Integer = 0
        Dim codelines As Integer = 0
        Dim commentlines As Integer = 0
        Dim blanklines As Integer = 0
        Dim commentflag As Boolean = False
        Dim strline As String = ""
        Dim formpath As String = ""

        Dim sr As StreamReader = New StreamReader(foundFile)

        Do While sr.Peek() >= 0
            strline = sr.ReadLine().Trim.Trim(" ")


            If [String].IsNullOrEmpty(strline) Then
                blanklines += 1
            ElseIf strline.StartsWith("/*") And Not commentflag Then
                commentlines += 1
                If Not strline.EndsWith("*/") Then
                    commentflag = True
                End If
            ElseIf strline.EndsWith("*/") Then
                commentlines += 1
                commentflag = False
            ElseIf strline.StartsWith("/") Then
                commentlines += 1
            ElseIf commentflag Then
                commentlines += 1
            Else
                codelines += 1
            End If
        Loop
        sr.Close()
        lines = codelines + commentlines + blanklines

        If foundFile.Length > path.Length Then
            formpath = foundFile.Substring(path.Length)
        End If

        Dim formarr() As String = formpath.Split("\")

        Dim filename As String = ""
        Dim filepath As String = ""
        If formarr.Length > 0 Then
            filename = formarr(formarr.Length - 1)
            filepath = formpath.Substring(0, formpath.Length - filename.Length)
        End If

        totallines = totallines + lines

        Dim fileDetails As System.IO.FileInfo = New System.IO.FileInfo(foundFile)
        Dim filesize As Integer = fileDetails.Length
        totalcodelines = totalcodelines + codelines
        totalcommentlines = totalcommentlines + commentlines
        totalblanklines = totalblanklines + blanklines
        totalsize = totalsize + filesize

        Dim outputstr As String = ""
        Dim fieltypestr As String = ""
        Dim filetype() As String = Nothing
        filetype = filename.Split(".")
        If filetype.Length >= 2 Then
            fieltypestr = filetype(filetype.Length - 1)
        End If

        If rbCSV.Checked Then

            outputstr = path & _
                            "," & filepath & _
                            "," & filename & _
                            "," & " *." & fieltypestr & _
                            "," & lines.ToString & _
                            "," & codelines.ToString & _
                            "," & commentlines.ToString & _
                            "," & blanklines.ToString & _
                            "," & filesize.ToString & "字节"

        ElseIf rbTXT.Checked Then

            outputstr = "┃" & stringFormat(path, 79, 0, 0) & _
                            "┃" & stringFormat(filepath, 79, 0, 0) & _
                            "┃" & stringFormat(filename, 49, 0, 0) & _
                            "┃" & stringFormat(" *." & fieltypestr, 8, 0, 0) & _
                            "┃" & stringFormat(lines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(codelines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(commentlines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(blanklines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(filesize.ToString + "字节", 15, 0, 1) & "┃"
        ElseIf rbView.Checked Then
            ' Create three items and three sets of subitems for each item.
            Dim item1 As New ListViewItem(CStr(FormView.ListView1.Items.Count + 1), 0)
            ' Place a check mark next to the item.
            item1.SubItems.Add(path)
            item1.SubItems.Add(filepath)
            item1.SubItems.Add(filename)
            item1.SubItems.Add(" *." & fieltypestr)
            item1.SubItems.Add(lines.ToString)
            item1.SubItems.Add(codelines.ToString)
            item1.SubItems.Add(commentlines.ToString)
            item1.SubItems.Add(blanklines.ToString)
            item1.SubItems.Add(filesize.ToString)
            'Add the items to the ListView.
            FormView.ListView1.Items.AddRange(New ListViewItem() {item1})
        End If
        SourceCounter = outputstr

    End Function

    ''' <summary>
    ''' 字符串格式化
    ''' </summary>
    ''' <param name="inputstring"></param>
    ''' <param name="inputlength"></param>
    ''' <param name="change"></param>
    ''' <param name="pos"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function stringFormat(ByVal inputstring As String, ByVal inputlength As Integer, ByVal change As Integer, ByVal pos As Integer)
        Dim space As String = "                                                                               "
        Dim stringFormatEnd As String = ""
        Try
            Dim lengthstr As Integer = System.Text.Encoding.Default.GetByteCount(inputstring)
            If lengthstr > inputlength Then
                stringFormatEnd = inputstring.Substring(lengthstr - inputlength)
            Else
                If pos = 0 Then
                    stringFormatEnd = inputstring & space.Substring(79 - inputlength + lengthstr)
                Else
                    stringFormatEnd = space.Substring(79 - inputlength + lengthstr) & inputstring
                End If

            End If
        Catch ex As Exception
            MsgBox("选择的文件夹或者文件内容有问题，文件将被忽略，处理继续。")
        End Try
        stringFormat = stringFormatEnd

    End Function

    ''' <summary>
    ''' 第二种计算方式
    ''' </summary>
    ''' <param name="foundFile"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SourceCounter2(ByVal foundFile As String, ByVal path As String)
        Dim lines As Integer = 0
        Dim codelines As Integer = 0
        Dim commentlines As Integer = 0
        Dim blanklines As Integer = 0
        Dim commentflag As Boolean = False
        Dim commentflag2 As Boolean = False
        Dim commentflag3 As Boolean = False
        Dim strline As String = ""
        Dim formpath As String = ""
        Dim sr As StreamReader = New StreamReader(foundFile)
        Do While sr.Peek() >= 0
            strline = sr.ReadLine().Trim.Trim(" ")


            If [String].IsNullOrEmpty(strline) Then
                blanklines += 1
            ElseIf strline.StartsWith("<%--") And Not commentflag Then
                commentlines += 1
                If Not strline.EndsWith("--%>") Then
                    commentflag3 = True
                End If
            ElseIf strline.EndsWith("--%>") Then
                commentlines += 1
                commentflag3 = False
            ElseIf strline.StartsWith("/*") And Not commentflag Then
                commentlines += 1
                If Not strline.EndsWith("*/") Then
                    commentflag = True
                End If
            ElseIf strline.EndsWith("*/") Then
                commentlines += 1
                commentflag = False
            ElseIf strline.StartsWith("/") Then
                commentlines += 1
            ElseIf commentflag Then
                commentlines += 1
            ElseIf strline.StartsWith("<!--") And Not commentflag2 Then
                commentlines += 1
                If Not strline.EndsWith("-->") Then
                    commentflag2 = True
                End If
            ElseIf strline.EndsWith("-->") Then
                commentlines += 1
                commentflag2 = False
            ElseIf strline.StartsWith("'") Then
                commentlines += 1
                commentflag = False
            Else

                codelines += 1
            End If
        Loop
        sr.Close()
        lines = codelines + commentlines + blanklines

        If foundFile.Length > path.Length Then
            formpath = foundFile.Substring(path.Length)
        End If

        Dim formarr() As String = formpath.Split("\")

        Dim filename As String = ""
        Dim filepath As String = ""
        If formarr.Length > 0 Then
            filename = formarr(formarr.Length - 1)
            filepath = formpath.Substring(0, formpath.Length - filename.Length)
        End If

        totallines = totallines + lines

        Dim fileDetails As System.IO.FileInfo = New System.IO.FileInfo(foundFile)
        Dim filesize As Integer = fileDetails.Length
        totalcodelines = totalcodelines + codelines
        totalcommentlines = totalcommentlines + commentlines
        totalblanklines = totalblanklines + blanklines
        totalsize = totalsize + filesize

        Dim outputstr As String = ""
        Dim fieltypestr As String = ""
        Dim filetype() As String = Nothing
        filetype = filename.Split(".")
        If filetype.Length >= 2 Then
            fieltypestr = filetype(filetype.Length - 1)
        End If

        If rbCSV.Checked Then

            outputstr = path & _
                            "," & filepath & _
                            "," & filename & _
                            "," & " *." & fieltypestr & _
                            "," & lines.ToString & _
                            "," & codelines.ToString & _
                            "," & commentlines.ToString & _
                            "," & blanklines.ToString & _
                            "," & filesize.ToString + "字节"

        ElseIf rbTXT.Checked Then


            outputstr = "┃" & stringFormat(path, 79, 0, 0) & _
                            "┃" & stringFormat(filepath, 79, 0, 0) & _
                            "┃" & stringFormat(filename, 49, 0, 0) & _
                            "┃" & stringFormat(" *." & fieltypestr, 8, 0, 0) & _
                            "┃" & stringFormat(lines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(codelines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(commentlines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(blanklines.ToString, 10, 0, 1) & _
                            "┃" & stringFormat(filesize.ToString + "字节", 15, 0, 1) & "┃"
        ElseIf rbView.Checked Then
            ' Create three items and three sets of subitems for each item.
            Dim item1 As New ListViewItem(CStr(FormView.ListView1.Items.Count + 1), 0)
            ' Place a check mark next to the item.
            item1.SubItems.Add(path)

            item1.SubItems.Add(filepath)
            item1.SubItems.Add(filename)
            item1.SubItems.Add(" *." & fieltypestr)
            item1.SubItems.Add(lines.ToString)
            item1.SubItems.Add(codelines.ToString)
            item1.SubItems.Add(commentlines.ToString)
            item1.SubItems.Add(blanklines.ToString)
            item1.SubItems.Add(filesize.ToString)
            'Add the items to the ListView.
            FormView.ListView1.Items.AddRange(New ListViewItem() {item1})
        End If
        SourceCounter2 = outputstr

    End Function


    ''' <summary>
    ''' 点击关于按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 关于ToolStripMenuItem1.Click
        关于.Show()
    End Sub

    ''' <summary>
    ''' 打开支持网站
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 支持网站ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 支持网站ToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.haikan.com.cn")
    End Sub

    ''' <summary>
    ''' 点击重置按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        tvList.Nodes.Clear()
        lvSelected.Items.Clear()
        Showdir()
    End Sub

    ''' <summary>
    ''' 点击开始统计按钮
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim path As String = txtFilePath.Text
        Dim ErrorMessage As String = ""

        Try
            ChDir(path)
            ' This checks to make sure the path is not blank.
        Catch ex As Exception When path = ""
            path = "C:\"
            ' This catches errors caused by a path that is not valid.
        Catch
            ErrorMessage = "你必须输入一个可写入的目录！"
        End Try
        ' Display the error message only if one exists.
        If ErrorMessage <> "" Then
            MsgBox(ErrorMessage)
            Exit Sub
        End If

        totallines = 0
        totalcodelines = 0
        totalcommentlines = 0
        totalblanklines = 0
        totalsize = 0

        Dim log(1) As String
        Dim i As Integer = 0

        Dim item2 As New ListViewItem()
        If lvSelected.Items.Count = 0 Then
            MsgBox("请选择要统计的文件夹。")
            Exit Sub
        End If

        Me.btnStart.Enabled = False
        Me.btnSelPath.Enabled = False
        Me.btnReset.Enabled = False


        For Each item2 In lvSelected.Items
            Try
                Dim fileList As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
                Dim fileList2 As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
                fileList = My.Computer.FileSystem.GetFiles(item2.SubItems(1).Text & "\", FileIO.SearchOption.SearchAllSubDirectories, ("*.java"), "*.c", "*.h", "*.cpp", "*.js", "*.css")
                fileList2 = My.Computer.FileSystem.GetFiles(item2.SubItems(1).Text & "\", FileIO.SearchOption.SearchAllSubDirectories, ("*.jsp"), "*.asp", "*.html", "*.htm", "*.asps", "*.vb")
                For Each foundFile As String In fileList
                    i += 1
                    ReDim Preserve log(i)
                    log(i) = SourceCounter(foundFile, item2.SubItems(1).Text & "\")

                Next
                For Each foundFile As String In fileList2
                    i += 1
                    ReDim Preserve log(i)
                    log(i) = SourceCounter2(foundFile, item2.SubItems(1).Text & "\")
                Next

            Catch exp As Exception
                MsgBox("选择的文件夹或者文件内容有问题，文件夹将被忽略，处理继续。")
            End Try
        Next

        Dim datestr As String = DateString
        Dim timestr As String = TimeString.Replace(":", "-")
        Dim datetimestr As String = datestr & " " & timestr

        If rbCSV.Checked Then

            Try
                If File.Exists(path & "\" & "MayiSourceCounter_" & datetimestr & ".csv") Then
                    File.Delete(path & "\" & "MayiSourceCounter_" & datetimestr & ".csv")
                End If
                If Not fso.FolderExists(path) Then
                    fso.CreateFolder(path)
                End If
                Dim sw As StreamWriter = New StreamWriter(path & "\" & "MayiSourceCounter_" & datetimestr & ".csv", True, Encoding.GetEncoding("gb2312"), 512)
                sw.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓")
                sw.WriteLine("┃ 欢迎使用海看源代码统计工具                              ┃")
                sw.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫")
                sw.WriteLine("┃   公司名称：杭州海看网络科技有限公司                           ┃")
                sw.WriteLine("┃   网址：http://www.haikan.com.cn                                 ┃")
                sw.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛")
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine("")

                sw.WriteLine("文件路径,工程路径,文件,文件类型,总行数,代码行数,注释行数,空行行数,文件大小")
                For Each logline As String In log
                    If Not String.IsNullOrEmpty(logline) Then
                        sw.WriteLine(logline)
                    End If

                Next
                sw.WriteLine("")

                sw.WriteLine("合计行,,,,总行数,代码行数,注释行数,空行行数,文件大小")
                sw.WriteLine(",,," & _
                            "," & totallines.ToString & _
                            "," & totalcodelines.ToString & _
                            "," & totalcommentlines.ToString & _
                            "," & totalblanklines.ToString & _
                            "," & totalsize.ToString & "字节")

                sw.Close()
            Catch ex As Exception
                MsgBox("选择的文件夹或者文件内容有问题，文件夹将被忽略，处理继续。")
            End Try

        ElseIf rbTXT.Checked Then

            Try
                If File.Exists(path & "\" & "MayiSourceCounter_" & datetimestr & ".txt") Then
                    File.Delete(path & "\" & "MayiSourceCounter_" & datetimestr & ".txt")
                End If
                If Not fso.FolderExists(path) Then
                    fso.CreateFolder(path)
                End If
                Dim sw As StreamWriter = New StreamWriter(path & "\" & "MayiSourceCounter_" & datetimestr & ".txt", True)
                sw.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓")
                sw.WriteLine("┃欢迎使用海看源代码统计工具                                ┃")
                sw.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫")
                sw.WriteLine("┃   公司名称：杭州海看网络科技有限公司                             ┃")
                sw.WriteLine("┃   网址：http://www.haikan.com.cn                                     ┃")
                sw.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛")
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓")
                sw.WriteLine("┃                                    文件路径                                   ┃                                    工程路径                                   ┃                      文件                       ┃文件类型┃  总行数  ┃ 代码行数 ┃ 注释行数 ┃ 空行行数 ┃    文件大小   ┫")
                sw.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫")


                For Each logline As String In log
                    If Not String.IsNullOrEmpty(logline) Then
                        sw.WriteLine(logline)
                    End If

                Next
                sw.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛")


                sw.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓")
                sw.WriteLine("┃                                                                                                       合计行                                                                                                                ┃  总行数  ┃ 代码行数 ┃ 注释行数 ┃ 空行行数 ┃    文件大小   ┫")
                sw.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫")
                sw.WriteLine("┃" & "                                                                                                                                                                                                                             " &
                            "┃" & stringFormat(totallines.ToString, 10, 0, 1) &
                            "┃" & stringFormat(totalcodelines.ToString, 10, 0, 1) &
                            "┃" & stringFormat(totalcommentlines.ToString, 10, 0, 1) &
                            "┃" & stringFormat(totalblanklines.ToString, 10, 0, 1) &
                            "┃" & stringFormat(totalsize.ToString + "字节", 15, 0, 1) & "┃")
                sw.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛")
                sw.Close()
            Catch ex As Exception
                MsgBox("选择的文件夹或者文件内容有问题，文件将被忽略，处理继续。")
            End Try
            '视图模式
        ElseIf rbView.Checked Then

            ' Create three items and three sets of subitems for each item.
            Dim item1 As New ListViewItem("合计", 0)
            ' Place a check mark next to the item.
            item1.SubItems.Add("")

            item1.SubItems.Add("")
            item1.SubItems.Add("")
            item1.SubItems.Add("")
            item1.SubItems.Add(totallines.ToString)
            item1.SubItems.Add(totalcodelines.ToString)
            item1.SubItems.Add(totalcommentlines.ToString)
            item1.SubItems.Add(totalblanklines.ToString)
            item1.SubItems.Add(totalsize.ToString)
            'Add the items to the ListView.
            FormView.ListView1.Items.AddRange(New ListViewItem() {item1})

            FormView.Show()
        End If
        Me.btnStart.Enabled = True
        Me.btnReset.Enabled = True
        Me.btnSelPath.Enabled = True

        MsgBox("统计成功！")
    End Sub

    ''' <summary>
    ''' 点击退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 退出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 退出ToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class