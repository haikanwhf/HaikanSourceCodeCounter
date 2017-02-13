<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form
    Public fso As New Scripting.FileSystemObject
    Public drvs As Scripting.Drives
    Public drv As Scripting.Drive
    Public fldr As Scripting.Folder
    Public fldrs As Scripting.Folders
    Public fldrs2 As Scripting.Folders
    Public fldr2 As Scripting.Folder
    Public fl As Scripting.File
    Public fls As Scripting.Files
    Public nd As TreeNode

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnSelPath = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbView = New System.Windows.Forms.RadioButton()
        Me.rbCSV = New System.Windows.Forms.RadioButton()
        Me.rbTXT = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.tvList = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.lvSelected = New System.Windows.Forms.ListView()
        Me.序号 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.文件夹路径 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.支持网站ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.关于ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Controls.Add(Me.btnSelPath)
        Me.Panel1.Controls.Add(Me.txtFilePath)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(345, 196)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(398, 276)
        Me.Panel1.TabIndex = 6
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReset.Location = New System.Drawing.Point(182, 227)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(93, 30)
        Me.btnReset.TabIndex = 22
        Me.btnReset.Text = "重 置"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(88, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(173, 12)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "(没有选择的情况下,默认在C:\)"
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.MenuBar
        Me.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Cyan
        Me.btnStart.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnStart.ImageKey = "(なし)"
        Me.btnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnStart.Location = New System.Drawing.Point(295, 227)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(93, 30)
        Me.btnStart.TabIndex = 18
        Me.btnStart.Text = "统计开始"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnSelPath
        '
        Me.btnSelPath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSelPath.Location = New System.Drawing.Point(313, 137)
        Me.btnSelPath.Name = "btnSelPath"
        Me.btnSelPath.Size = New System.Drawing.Size(75, 23)
        Me.btnSelPath.TabIndex = 17
        Me.btnSelPath.Text = "选择路径"
        Me.btnSelPath.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Font = New System.Drawing.Font("宋体", 10.5!)
        Me.txtFilePath.Location = New System.Drawing.Point(7, 108)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(381, 23)
        Me.txtFilePath.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(3, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 19)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "生成文件路径"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.rbView)
        Me.GroupBox1.Controls.Add(Me.rbCSV)
        Me.GroupBox1.Controls.Add(Me.rbTXT)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(6, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(382, 39)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'rbView
        '
        Me.rbView.AutoSize = True
        Me.rbView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbView.Location = New System.Drawing.Point(245, 17)
        Me.rbView.Name = "rbView"
        Me.rbView.Size = New System.Drawing.Size(47, 16)
        Me.rbView.TabIndex = 2
        Me.rbView.TabStop = True
        Me.rbView.Text = "视图"
        Me.rbView.UseVisualStyleBackColor = True
        '
        'rbCSV
        '
        Me.rbCSV.AutoSize = True
        Me.rbCSV.Checked = True
        Me.rbCSV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbCSV.Location = New System.Drawing.Point(11, 17)
        Me.rbCSV.Name = "rbCSV"
        Me.rbCSV.Size = New System.Drawing.Size(65, 16)
        Me.rbCSV.TabIndex = 0
        Me.rbCSV.TabStop = True
        Me.rbCSV.Text = "CSV文件"
        Me.rbCSV.UseVisualStyleBackColor = True
        '
        'rbTXT
        '
        Me.rbTXT.AutoSize = True
        Me.rbTXT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbTXT.Location = New System.Drawing.Point(124, 17)
        Me.rbTXT.Name = "rbTXT"
        Me.rbTXT.Size = New System.Drawing.Size(65, 16)
        Me.rbTXT.TabIndex = 1
        Me.rbTXT.Text = "TXT文件"
        Me.rbTXT.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "生成文件格式"
        '
        'tvList
        '
        Me.tvList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvList.CheckBoxes = True
        Me.tvList.ImageIndex = 0
        Me.tvList.ImageList = Me.ImageList1
        Me.tvList.Location = New System.Drawing.Point(6, 27)
        Me.tvList.Name = "tvList"
        Me.tvList.SelectedImageIndex = 6
        Me.tvList.Size = New System.Drawing.Size(335, 442)
        Me.tvList.StateImageList = Me.ImageList2
        Me.tvList.TabIndex = 7
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.YellowGreen
        Me.ImageList1.Images.SetKeyName(0, "folder_cyan.ico")
        Me.ImageList1.Images.SetKeyName(1, "desktop.ico")
        Me.ImageList1.Images.SetKeyName(2, "folder_cyan_open.ico")
        Me.ImageList1.Images.SetKeyName(3, "BassDrive.ico")
        Me.ImageList1.Images.SetKeyName(4, "BIN.ico")
        Me.ImageList1.Images.SetKeyName(5, "Computer.ico")
        Me.ImageList1.Images.SetKeyName(6, "DVD.ico")
        Me.ImageList1.Images.SetKeyName(7, "CD.ico")
        Me.ImageList1.Images.SetKeyName(8, "Documents 2.ico")
        Me.ImageList1.Images.SetKeyName(9, "Folder.ico")
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "选择框1.GIF")
        Me.ImageList2.Images.SetKeyName(1, "选择框2.GIF")
        Me.ImageList2.Images.SetKeyName(2, "选择框2.GIF")
        '
        'lvSelected
        '
        Me.lvSelected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvSelected.BackColor = System.Drawing.SystemColors.Window
        Me.lvSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvSelected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.序号, Me.文件夹路径})
        Me.lvSelected.FullRowSelect = True
        Me.lvSelected.GridLines = True
        Me.lvSelected.Location = New System.Drawing.Point(345, 27)
        Me.lvSelected.Name = "lvSelected"
        Me.lvSelected.Size = New System.Drawing.Size(398, 163)
        Me.lvSelected.TabIndex = 8
        Me.lvSelected.UseCompatibleStateImageBehavior = False
        Me.lvSelected.View = System.Windows.Forms.View.Details
        '
        '序号
        '
        Me.序号.Text = "序号"
        Me.序号.Width = 44
        '
        '文件夹路径
        '
        Me.文件夹路径.Text = "文件夹路径"
        Me.文件夹路径.Width = 350
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(750, 25)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.退出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.支持网站ToolStripMenuItem, Me.ToolStripMenuItem1, Me.关于ToolStripMenuItem1})
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        '支持网站ToolStripMenuItem
        '
        Me.支持网站ToolStripMenuItem.Name = "支持网站ToolStripMenuItem"
        Me.支持网站ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.支持网站ToolStripMenuItem.Text = "支持网站"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(121, 6)
        '
        '关于ToolStripMenuItem1
        '
        Me.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1"
        Me.关于ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.关于ToolStripMenuItem1.Text = "关于"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(750, 478)
        Me.Controls.Add(Me.lvSelected)
        Me.Controls.Add(Me.tvList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "海看源代码统计工具 http://www.haikan.com.cn"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCSV As System.Windows.Forms.RadioButton
    Friend WithEvents rbTXT As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnSelPath As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tvList As System.Windows.Forms.TreeView
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents lvSelected As System.Windows.Forms.ListView
    Friend WithEvents 序号 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 文件夹路径 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents rbView As System.Windows.Forms.RadioButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 支持网站ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 关于ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
