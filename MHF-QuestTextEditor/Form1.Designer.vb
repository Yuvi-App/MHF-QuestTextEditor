<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnSaveExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGoogleTranslate = New System.Windows.Forms.Button()
        Me.btnQuestFolder = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnWritetoORGFile = New System.Windows.Forms.Button()
        Me.txtEQuestType = New System.Windows.Forms.TextBox()
        Me.txtEMainObj = New System.Windows.Forms.TextBox()
        Me.txtESubA = New System.Windows.Forms.TextBox()
        Me.txtESubB = New System.Windows.Forms.TextBox()
        Me.txtEClear = New System.Windows.Forms.TextBox()
        Me.txtEFail = New System.Windows.Forms.TextBox()
        Me.txtEHirer = New System.Windows.Forms.TextBox()
        Me.rtfEDescription = New System.Windows.Forms.RichTextBox()
        Me.rtfDescription = New System.Windows.Forms.RichTextBox()
        Me.txtQuestType = New System.Windows.Forms.TextBox()
        Me.txtMainObj = New System.Windows.Forms.TextBox()
        Me.txtSubA = New System.Windows.Forms.TextBox()
        Me.txtSubB = New System.Windows.Forms.TextBox()
        Me.txtClear = New System.Windows.Forms.TextBox()
        Me.txtFail = New System.Windows.Forms.TextBox()
        Me.txtHirer = New System.Windows.Forms.TextBox()
        Me.txtDelivery = New System.Windows.Forms.TextBox()
        Me.txtEDelivery = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnSaveAlltoTxt = New System.Windows.Forms.Button()
        Me.btnTranslateDictionary = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSaveExcel
        '
        Me.btnSaveExcel.Enabled = False
        Me.btnSaveExcel.Location = New System.Drawing.Point(440, 103)
        Me.btnSaveExcel.Name = "btnSaveExcel"
        Me.btnSaveExcel.Size = New System.Drawing.Size(77, 41)
        Me.btnSaveExcel.TabIndex = 2
        Me.btnSaveExcel.Text = "Save to Excel"
        Me.btnSaveExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Original"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(663, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Edited / Translated"
        '
        'btnGoogleTranslate
        '
        Me.btnGoogleTranslate.Enabled = False
        Me.btnGoogleTranslate.Location = New System.Drawing.Point(441, 466)
        Me.btnGoogleTranslate.Name = "btnGoogleTranslate"
        Me.btnGoogleTranslate.Size = New System.Drawing.Size(77, 42)
        Me.btnGoogleTranslate.TabIndex = 4
        Me.btnGoogleTranslate.Text = "Google Translate"
        Me.btnGoogleTranslate.UseVisualStyleBackColor = True
        '
        'btnQuestFolder
        '
        Me.btnQuestFolder.Location = New System.Drawing.Point(357, 61)
        Me.btnQuestFolder.Name = "btnQuestFolder"
        Me.btnQuestFolder.Size = New System.Drawing.Size(225, 23)
        Me.btnQuestFolder.TabIndex = 5
        Me.btnQuestFolder.Text = "Select Quest Folder"
        Me.btnQuestFolder.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 34)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(855, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(792, 61)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Enabled = False
        Me.btnPrevious.Location = New System.Drawing.Point(12, 61)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.btnPrevious.TabIndex = 7
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(795, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Write line for line"
        '
        'btnWritetoORGFile
        '
        Me.btnWritetoORGFile.Enabled = False
        Me.btnWritetoORGFile.Location = New System.Drawing.Point(441, 276)
        Me.btnWritetoORGFile.Name = "btnWritetoORGFile"
        Me.btnWritetoORGFile.Size = New System.Drawing.Size(77, 39)
        Me.btnWritetoORGFile.TabIndex = 2
        Me.btnWritetoORGFile.Text = "Write to Org. File"
        Me.btnWritetoORGFile.UseVisualStyleBackColor = True
        '
        'txtEQuestType
        '
        Me.txtEQuestType.Location = New System.Drawing.Point(524, 130)
        Me.txtEQuestType.Name = "txtEQuestType"
        Me.txtEQuestType.Size = New System.Drawing.Size(343, 20)
        Me.txtEQuestType.TabIndex = 9
        '
        'txtEMainObj
        '
        Me.txtEMainObj.Location = New System.Drawing.Point(524, 156)
        Me.txtEMainObj.Name = "txtEMainObj"
        Me.txtEMainObj.Size = New System.Drawing.Size(343, 20)
        Me.txtEMainObj.TabIndex = 9
        '
        'txtESubA
        '
        Me.txtESubA.Location = New System.Drawing.Point(524, 182)
        Me.txtESubA.Name = "txtESubA"
        Me.txtESubA.Size = New System.Drawing.Size(343, 20)
        Me.txtESubA.TabIndex = 9
        '
        'txtESubB
        '
        Me.txtESubB.Location = New System.Drawing.Point(524, 208)
        Me.txtESubB.Name = "txtESubB"
        Me.txtESubB.Size = New System.Drawing.Size(343, 20)
        Me.txtESubB.TabIndex = 9
        '
        'txtEClear
        '
        Me.txtEClear.Location = New System.Drawing.Point(524, 234)
        Me.txtEClear.Name = "txtEClear"
        Me.txtEClear.Size = New System.Drawing.Size(343, 20)
        Me.txtEClear.TabIndex = 9
        '
        'txtEFail
        '
        Me.txtEFail.Location = New System.Drawing.Point(524, 260)
        Me.txtEFail.Name = "txtEFail"
        Me.txtEFail.Size = New System.Drawing.Size(343, 20)
        Me.txtEFail.TabIndex = 9
        '
        'txtEHirer
        '
        Me.txtEHirer.Location = New System.Drawing.Point(524, 286)
        Me.txtEHirer.Name = "txtEHirer"
        Me.txtEHirer.Size = New System.Drawing.Size(343, 20)
        Me.txtEHirer.TabIndex = 9
        '
        'rtfEDescription
        '
        Me.rtfEDescription.Location = New System.Drawing.Point(524, 312)
        Me.rtfEDescription.Name = "rtfEDescription"
        Me.rtfEDescription.Size = New System.Drawing.Size(343, 196)
        Me.rtfEDescription.TabIndex = 1
        Me.rtfEDescription.Text = ""
        '
        'rtfDescription
        '
        Me.rtfDescription.Location = New System.Drawing.Point(92, 311)
        Me.rtfDescription.Name = "rtfDescription"
        Me.rtfDescription.Size = New System.Drawing.Size(343, 197)
        Me.rtfDescription.TabIndex = 1
        Me.rtfDescription.Text = ""
        '
        'txtQuestType
        '
        Me.txtQuestType.Location = New System.Drawing.Point(92, 130)
        Me.txtQuestType.Name = "txtQuestType"
        Me.txtQuestType.Size = New System.Drawing.Size(343, 20)
        Me.txtQuestType.TabIndex = 9
        '
        'txtMainObj
        '
        Me.txtMainObj.Location = New System.Drawing.Point(92, 156)
        Me.txtMainObj.Name = "txtMainObj"
        Me.txtMainObj.Size = New System.Drawing.Size(343, 20)
        Me.txtMainObj.TabIndex = 9
        '
        'txtSubA
        '
        Me.txtSubA.Location = New System.Drawing.Point(92, 182)
        Me.txtSubA.Name = "txtSubA"
        Me.txtSubA.Size = New System.Drawing.Size(343, 20)
        Me.txtSubA.TabIndex = 9
        '
        'txtSubB
        '
        Me.txtSubB.Location = New System.Drawing.Point(92, 208)
        Me.txtSubB.Name = "txtSubB"
        Me.txtSubB.Size = New System.Drawing.Size(343, 20)
        Me.txtSubB.TabIndex = 9
        '
        'txtClear
        '
        Me.txtClear.Location = New System.Drawing.Point(92, 234)
        Me.txtClear.Name = "txtClear"
        Me.txtClear.Size = New System.Drawing.Size(343, 20)
        Me.txtClear.TabIndex = 9
        '
        'txtFail
        '
        Me.txtFail.Location = New System.Drawing.Point(92, 260)
        Me.txtFail.Name = "txtFail"
        Me.txtFail.Size = New System.Drawing.Size(343, 20)
        Me.txtFail.TabIndex = 9
        '
        'txtHirer
        '
        Me.txtHirer.Location = New System.Drawing.Point(92, 286)
        Me.txtHirer.Name = "txtHirer"
        Me.txtHirer.Size = New System.Drawing.Size(343, 20)
        Me.txtHirer.TabIndex = 9
        '
        'txtDelivery
        '
        Me.txtDelivery.Location = New System.Drawing.Point(91, 103)
        Me.txtDelivery.Name = "txtDelivery"
        Me.txtDelivery.Size = New System.Drawing.Size(343, 20)
        Me.txtDelivery.TabIndex = 9
        '
        'txtEDelivery
        '
        Me.txtEDelivery.Location = New System.Drawing.Point(524, 104)
        Me.txtEDelivery.Name = "txtEDelivery"
        Me.txtEDelivery.Size = New System.Drawing.Size(343, 20)
        Me.txtEDelivery.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Delivery"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Quest Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Main Objective"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Sub A Obj"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 211)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Sub B Obj"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 263)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Fail Condition"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 289)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Hirer"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 237)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Clear Condition"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 404)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Quest Desc."
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(855, 23)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Monster Hunter Frontier Quest Text Editor"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(874, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 499)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'btnSaveAlltoTxt
        '
        Me.btnSaveAlltoTxt.Enabled = False
        Me.btnSaveAlltoTxt.Location = New System.Drawing.Point(633, 61)
        Me.btnSaveAlltoTxt.Name = "btnSaveAlltoTxt"
        Me.btnSaveAlltoTxt.Size = New System.Drawing.Size(128, 23)
        Me.btnSaveAlltoTxt.TabIndex = 2
        Me.btnSaveAlltoTxt.Text = "Save all Quest to .TXT"
        Me.btnSaveAlltoTxt.UseVisualStyleBackColor = True
        '
        'btnTranslateDictionary
        '
        Me.btnTranslateDictionary.Enabled = False
        Me.btnTranslateDictionary.Location = New System.Drawing.Point(443, 415)
        Me.btnTranslateDictionary.Name = "btnTranslateDictionary"
        Me.btnTranslateDictionary.Size = New System.Drawing.Size(75, 45)
        Me.btnTranslateDictionary.TabIndex = 13
        Me.btnTranslateDictionary.Text = "Dictionary Translate"
        Me.btnTranslateDictionary.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 513)
        Me.Controls.Add(Me.btnTranslateDictionary)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEDelivery)
        Me.Controls.Add(Me.txtDelivery)
        Me.Controls.Add(Me.txtHirer)
        Me.Controls.Add(Me.txtEHirer)
        Me.Controls.Add(Me.txtFail)
        Me.Controls.Add(Me.txtEFail)
        Me.Controls.Add(Me.txtClear)
        Me.Controls.Add(Me.txtEClear)
        Me.Controls.Add(Me.txtSubB)
        Me.Controls.Add(Me.txtESubB)
        Me.Controls.Add(Me.txtSubA)
        Me.Controls.Add(Me.txtESubA)
        Me.Controls.Add(Me.txtMainObj)
        Me.Controls.Add(Me.txtEMainObj)
        Me.Controls.Add(Me.txtQuestType)
        Me.Controls.Add(Me.txtEQuestType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnQuestFolder)
        Me.Controls.Add(Me.btnGoogleTranslate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSaveAlltoTxt)
        Me.Controls.Add(Me.btnWritetoORGFile)
        Me.Controls.Add(Me.rtfDescription)
        Me.Controls.Add(Me.btnSaveExcel)
        Me.Controls.Add(Me.rtfEDescription)
        Me.Name = "Form1"
        Me.Text = "Monster Hunter Frontier Quest Text Editor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnSaveExcel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGoogleTranslate As Button
    Friend WithEvents btnQuestFolder As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnWritetoORGFile As Button
    Friend WithEvents txtEQuestType As TextBox
    Friend WithEvents txtEMainObj As TextBox
    Friend WithEvents txtESubA As TextBox
    Friend WithEvents txtESubB As TextBox
    Friend WithEvents txtEClear As TextBox
    Friend WithEvents txtEFail As TextBox
    Friend WithEvents txtEHirer As TextBox
    Friend WithEvents rtfEDescription As RichTextBox
    Friend WithEvents rtfDescription As RichTextBox
    Friend WithEvents txtQuestType As TextBox
    Friend WithEvents txtMainObj As TextBox
    Friend WithEvents txtSubA As TextBox
    Friend WithEvents txtSubB As TextBox
    Friend WithEvents txtClear As TextBox
    Friend WithEvents txtFail As TextBox
    Friend WithEvents txtHirer As TextBox
    Friend WithEvents txtDelivery As TextBox
    Friend WithEvents txtEDelivery As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnSaveAlltoTxt As Button
    Friend WithEvents btnTranslateDictionary As Button
End Class
