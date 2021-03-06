﻿Imports System.IO
Imports System.Text
Imports MHF_QuestTextEditor.DamienG.Security.Cryptography
Imports MHF_QuestTextEditor.QuestInfo
Imports Microsoft.Office.Interop
Imports System.Net.Http
Imports System.Web.Script.Serialization
Imports GoogleTranslateFreeApi
Imports System.Text.RegularExpressions

Public Class Form1
    Dim QuestFolder
    Dim GoogleTranslateAvaliable As Boolean = False
    Dim Filetoload
    Dim brInput
    '-----------AUTO STUFF-----------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Filetoload = ComboBox1.GetItemText(ComboBox1.SelectedItem)
        Dim p = Path.GetExtension(Filetoload)
        If p = ".bin" Then
            ClearFields()
            LoadTextfromQuestFile(Filetoload)
        ElseIf p = ".txt" Then
            ClearFields()
            LoadQuestfromtxtFile(Filetoload)
        End If
    End Sub


    '---------BUTTONS----------
    Private Sub btnQuestFolder_Click(sender As Object, e As EventArgs) Handles btnQuestFolder.Click
        Try
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                QuestFolder = FolderBrowserDialog1.SelectedPath
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(QuestFolder)
                    ComboBox1.Items.Add(foundFile)
                Next
                ComboBox1.SelectedIndex = 0
                btnGoogleTranslate.Enabled = True
                btnNext.Enabled = True
                btnPrevious.Enabled = True
                btnSaveAlltoTxt.Enabled = True
                btnSaveExcel.Enabled = True
                'btnWritetoORGFile.Enabled = True      broken working on this
                btnTranslateDictionary.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error Selecting Folder")
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            ComboBox1.SelectedIndex = ComboBox1.SelectedIndex - 1
        Catch ex As Exception

        End Try

    End Sub

    Private Async Sub btnGoogleTranslate_Click(sender As Object, e As EventArgs) Handles btnGoogleTranslate.Click
        Try
            Dim translator = New GoogleTranslator()
            Dim from As Language = Language.Auto
            Dim [to] As Language = Language.English

            Dim JPlist As New List(Of String)
            JPlist.Add(txtDelivery.Text)
            JPlist.Add(txtQuestType.Text)
            JPlist.Add(txtMainObj.Text)
            JPlist.Add(txtSubA.Text)
            JPlist.Add(txtSubB.Text)
            JPlist.Add(txtClear.Text)
            JPlist.Add(txtFail.Text)
            JPlist.Add(txtHirer.Text)
            JPlist.Add(rtfDescription.Text)

            For Each i In JPlist
                Dim result As TranslationResult = Await translator.TranslateLiteAsync(i, from, [to])
                Dim resultMerged As String = result.MergedTranslation
                If i = txtDelivery.Text Then
                    txtEDelivery.Text = resultMerged
                ElseIf i = txtQuestType.Text Then
                    txtEQuestType.Text = resultMerged
                ElseIf i = txtMainObj.Text Then
                    txtEMainObj.Text = resultMerged
                ElseIf i = txtSubA.Text Then
                    txtESubA.Text = resultMerged
                ElseIf i = txtSubB.Text Then
                    If resultMerged = Nothing Then
                        txtESubB.Text = "None"
                    Else
                        txtESubB.Text = resultMerged
                    End If
                ElseIf i = txtClear.Text Then
                    txtEClear.Text = resultMerged
                ElseIf i = txtFail.Text Then
                    txtEFail.Text = resultMerged
                ElseIf i = txtHirer.Text Then
                    txtEHirer.Text = resultMerged
                ElseIf i = rtfDescription.Text Then
                    rtfEDescription.Text = resultMerged
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error Translating (might be rated limited) Try again later")
        End Try
    End Sub

    Private Sub btnSaveExcel_Click(sender As Object, e As EventArgs) Handles btnSaveExcel.Click
        Try
            Dim strExist As Boolean = False
            Dim ExcelFile = "\MHFQuestTranslation1.xlsx"
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet
            xls.Workbooks.Open(My.Application.Info.DirectoryPath + ExcelFile)
            book = xls.ActiveWorkbook
            sheet = book.Sheets(1)

            For i = 1 To sheet.UsedRange.Rows.Count + 1
                If sheet.Cells(i, 2).Value = txtQuestType.Text Then
                    'JP Data
                    sheet.Cells(i, 1).value = txtDelivery.Text
                    sheet.Cells(i, 2).value = txtQuestType.Text
                    sheet.Cells(i, 3).value = txtMainObj.Text
                    sheet.Cells(i, 4).value = txtSubA.Text
                    sheet.Cells(i, 5).value = txtSubB.Text
                    sheet.Cells(i, 6).value = txtClear.Text
                    sheet.Cells(i, 7).value = txtFail.Text
                    sheet.Cells(i, 8).value = txtHirer.Text
                    sheet.Cells(i, 9).value = rtfDescription.Text
                    'Eng Data
                    sheet.Cells(i, 10).value = txtEDelivery.Text
                    sheet.Cells(i, 11).value = txtEQuestType.Text
                    sheet.Cells(i, 12).value = txtEMainObj.Text
                    sheet.Cells(i, 13).value = txtESubA.Text
                    sheet.Cells(i, 14).value = txtESubB.Text
                    sheet.Cells(i, 15).value = txtEClear.Text
                    sheet.Cells(i, 16).value = txtEFail.Text
                    sheet.Cells(i, 17).value = txtEHirer.Text
                    sheet.Cells(i, 18).value = rtfEDescription.Text
                    strExist = True
                End If
            Next i

            If strExist = False Then
                'Insert Data
                sheet.Rows(sheet.UsedRange.Rows.Count + 1).Insert()
                'JP Data
                sheet.Cells(sheet.UsedRange.Rows.Count, 1).value = txtDelivery.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 2).value = txtQuestType.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 3).value = txtMainObj.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 4).value = txtSubA.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 5).value = txtSubB.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 6).value = txtClear.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 7).value = txtFail.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 8).value = txtHirer.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 9).value = rtfDescription.Text
                'Eng Data
                sheet.Cells(sheet.UsedRange.Rows.Count, 10).value = txtEDelivery.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 11).value = txtEQuestType.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 12).value = txtEMainObj.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 13).value = txtESubA.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 14).value = txtESubB.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 15).value = txtEClear.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 16).value = txtEFail.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 17).value = txtEHirer.Text
                sheet.Cells(sheet.UsedRange.Rows.Count, 18).value = rtfEDescription.Text
            End If
            book.Save()
            book.Close()
            xls.Quit()

            MessageBox.Show("Saved Successfully")
        Catch ex As Exception
            MessageBox.Show("Error Saving to Excel")
        End Try
    End Sub

    Private Sub btnWritetoORGFile_Click(sender As Object, e As EventArgs) Handles btnWritetoORGFile.Click
        Dim StringtoWrite = GetByteStringWrite(txtEMainObj.Text)
        Dim StringtoRead = GetByteStringRead(txtMainObj.Text)

        'Find Hex
        Dim matchBytes As Byte() = StringToByteArray(StringtoRead)
        Dim Found = False
        Dim startposition
        Dim endposition
        Try
            Using fs = New FileStream(Filetoload, FileMode.Open)
                Dim i As Integer = 0
                Dim readByte As Integer

                While (CSharpImpl.__Assign(readByte, fs.ReadByte())) <> -1
                    If matchBytes(i) = readByte Then
                        i += 1
                    Else
                        i = 0
                    End If

                    If i = matchBytes.Length Then
                        startposition = fs.Position - matchBytes.Length
                        endposition = fs.Position
                        'MessageBox.Show("Found " + Hex(startposition).ToString + " and " + Hex(fs.Position).ToString)
                        Found = True
                        Exit While
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error Finding Location", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If Found = True Then
                Dim writeBytes As Byte() = StringToByteArray(StringtoWrite)
                Using stream = New FileStream("test.bin", FileMode.Open, FileAccess.Write)
                    Dim bw As New BinaryWriter(stream)
                    stream.Position = startposition
                    bw.Write(writeBytes, 0, writeBytes.Length)
                    bw.Close()
                End Using
            Else
                MessageBox.Show("Unable to write")
            End If
        Catch ex As Exception
        End Try


        'inputArray.Reverse()

        'Dim BWriter As BinaryWriter = New BinaryWriter(File.OpenWrite("test.bin"))
        'Dim questStringsStart As Integer = BitConverter.ToInt32(inputArray, 48)
        'Dim readPointer As Integer = BitConverter.ToInt32(inputArray, questStringsStart)
        'BWriter.Write(StringtoWrite, readPointer, 2)
        'BWriter.Close()
        'MessageBox.Show("Wrote successfully")
    End Sub

    Private Sub btnSaveAlltoTxt_Click(sender As Object, e As EventArgs) Handles btnSaveAlltoTxt.Click
        If My.Computer.FileSystem.DirectoryExists("ExportedQuest") Then
            SaveAllToTXT()
        Else
            My.Computer.FileSystem.CreateDirectory("ExportedQuest")
            SaveAllToTXT()
        End If
    End Sub

    '----------FUNCTIONS--------------------
    Public Function ClearFields()
        Try
            txtDelivery.Text = ""
            txtQuestType.Text = ""
            txtMainObj.Text = ""
            txtSubA.Text = ""
            txtSubB.Text = ""
            txtClear.Text = ""
            txtFail.Text = ""
            txtHirer.Text = ""
            rtfDescription.Text = ""
            txtEDelivery.Text = ""
            txtEQuestType.Text = ""
            txtEMainObj.Text = ""
            txtESubA.Text = ""
            txtESubB.Text = ""
            txtEClear.Text = ""
            txtEFail.Text = ""
            txtEHirer.Text = ""
            rtfEDescription.Text = ""
        Catch ex As Exception
            MessageBox.Show("Error Clearing Fields")
        End Try

    End Function

    Public Function LoadTextfromQuestFile(ByVal QuestInfoFile As String) As Structs.QuestInfo
        Try
            'Get CRC
            Dim crc32 = New Crc32()
            Dim hash = String.Empty
            Dim fs = File.Open(QuestInfoFile, FileMode.Open)
            For Each b As Byte In crc32.ComputeHash(fs)
                hash += b.ToString("x2").ToLower()
            Next
            fs.Close()

            Dim inputArray As Byte() = File.ReadAllBytes(QuestInfoFile)
            inputArray.Reverse()

            brInput = New BinaryReader(New FileStream(QuestInfoFile, FileMode.Open))

            'Gets Text
            Dim questStringsStart As Integer = BitConverter.ToInt32(inputArray, 48)
            Dim readPointer As Integer = BitConverter.ToInt32(inputArray, questStringsStart)
            brInput.BaseStream.Seek(readPointer, SeekOrigin.Begin)
            Dim DeliverString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Type
            questStringsStart = BitConverter.ToInt32(inputArray, 232)
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim QuestTypeName = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'OBJ
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ObjMainString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'SUB A
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ObjAString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'SUB B
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ObjBString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Clear
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ClearReqString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Fail
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim FailReqString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Hirer
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim HirerString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Description
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim DescriptionString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")

            'Print Text
            txtDelivery.Text = DeliverString
            txtQuestType.Text = QuestTypeName
            txtMainObj.Text = ObjMainString
            txtSubA.Text = ObjAString
            txtSubB.Text = ObjBString
            txtClear.Text = ClearReqString
            txtFail.Text = FailReqString
            txtHirer.Text = HirerString
            rtfDescription.Text = DescriptionString

            fs.Close()
            brInput.Close()
        Catch ex As Exception
            MessageBox.Show("Error Loading Quest File")
        End Try
    End Function

    Public Function LoadQuestfromtxtFile(ByVal QuestInfoFile As String)

    End Function

    Public Shared Function ReadNullterminatedString(ByVal brInput As BinaryReader, ByVal encoding As Encoding) As String
        Dim charByteList = New List(Of Byte)()
        Dim str As String = ""

        If brInput.BaseStream.Position = brInput.BaseStream.Length Then
            Dim charByteArray As Byte() = charByteList.ToArray()
            str = encoding.GetString(charByteArray)
            Return str
        End If

        Dim b As Byte = brInput.ReadByte()

        While (b <> &H0) AndAlso (brInput.BaseStream.Position <> brInput.BaseStream.Length)
            charByteList.Add(b)
            b = brInput.ReadByte()
        End While

        Dim char_bytes As Byte() = charByteList.ToArray()
        str = encoding.GetString(char_bytes)
        Return str
    End Function

    Public Shared Function StringToByteArray(ByVal hex As String) As Byte()
        Dim NumberChars As Integer = hex.Length
        Dim bytes As Byte() = New Byte(NumberChars / 2 - 1) {}

        For i As Integer = 0 To NumberChars - 1 Step 2
            bytes(i / 2) = Convert.ToByte(hex.Substring(i, 2), 16)
        Next

        Return bytes
    End Function

    Private Function StringToBytes(ByVal str As String) As Byte()
        Return System.Text.Encoding.UTF32.GetBytes(str)
    End Function

    Private Function GetByteStringWrite(Source As String) As String
        Dim b As Byte() = System.Text.Encoding.UTF8.GetBytes(Source)
        Return BitConverter.ToString(b).Replace("-", "")
    End Function

    Private Function GetByteStringRead(Source As String) As String
        Dim b As Byte() = System.Text.Encoding.GetEncoding(932).GetBytes(Source)
        Return BitConverter.ToString(b).Replace("-", "")
    End Function

    Private Class CSharpImpl
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Public Function SaveAllToTXT()
        Dim swfile As System.IO.StreamWriter
        Dim p
        For Each i In ComboBox1.Items
            If ComboBox1.SelectedIndex = ComboBox1.Items.Count - 1 Then

            Else
                ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
            End If

            'START GET DATA (IM NOT PROUD OF THIS METHOD)
            'Get CRC
            Dim crc32 = New Crc32()
            Dim hash = String.Empty
            Dim fs = File.Open(i, FileMode.Open)
            For Each b As Byte In crc32.ComputeHash(fs)
                hash += b.ToString("x2").ToLower()
            Next
            fs.Close()

            Dim inputArray As Byte() = File.ReadAllBytes(i)
            inputArray.Reverse()

            brInput = New BinaryReader(New FileStream(i, FileMode.Open))

            'Gets Text
            Dim questStringsStart As Integer = BitConverter.ToInt32(inputArray, 48)
            Dim readPointer As Integer = BitConverter.ToInt32(inputArray, questStringsStart)
            brInput.BaseStream.Seek(readPointer, SeekOrigin.Begin)
            Dim DeliverString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Type
            questStringsStart = BitConverter.ToInt32(inputArray, 232)
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim QuestTypeName = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'OBJ
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ObjMainString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'SUB A
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ObjAString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'SUB B
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ObjBString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Clear
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim ClearReqString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Fail
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim FailReqString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Hirer
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim HirerString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")
            'Description
            questStringsStart += 4
            brInput.BaseStream.Seek(BitConverter.ToInt32(inputArray, questStringsStart), SeekOrigin.Begin)
            Dim DescriptionString = ReadNullterminatedString(brInput, Encoding.GetEncoding("shift-jis")).Replace("\n", "<NLINE>")

            'Write to TXT File
            p = Path.GetFileNameWithoutExtension(i)
            swfile = My.Computer.FileSystem.OpenTextFileWriter("ExportedQuest\" + p + ".txt", True)
            swfile.WriteLine("Delivery: " + DeliverString)
            swfile.WriteLine("")
            swfile.WriteLine("Quest Name / Type: " + QuestTypeName)
            swfile.WriteLine("")
            swfile.WriteLine("Main Objective: " + ObjMainString)
            swfile.WriteLine("")
            swfile.WriteLine("Sub A: " + ObjAString)
            swfile.WriteLine("")
            swfile.WriteLine("Sub B: " + ObjBString)
            swfile.WriteLine("")
            swfile.WriteLine("Clear Condition: " + ClearReqString)
            swfile.WriteLine("")
            swfile.WriteLine("Fail Condition: " + FailReqString)
            swfile.WriteLine("")
            swfile.WriteLine("Hirer: " + HirerString)
            swfile.WriteLine("")
            swfile.WriteLine("Description: " + DescriptionString)
            swfile.Close()
            fs.Close()
            brInput.Close()
        Next
        MessageBox.Show("Successfuly Wrote all Quest Files into .txt")
    End Function

    Private Sub btnTranslateDictionary_Click(sender As Object, e As EventArgs) Handles btnTranslateDictionary.Click
        Try
            For Each k In CommonTerms.Terms.Keys
                If String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtDelivery.Text.Contains(k) Then
                        Dim input As String = txtDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtEDelivery.Text.Contains(k) Then
                        Dim input As String = txtEDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtQuestType.Text.Contains(k) Then
                        Dim input As String = txtQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtEQuestType.Text.Contains(k) Then
                        Dim input As String = txtEQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtMainObj.Text.Contains(k) Then
                        Dim input As String = txtMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtEMainObj.Text.Contains(k) Then
                        Dim input As String = txtEMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtSubA.Text.Contains(k) Then
                        Dim input As String = txtSubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtESubA.Text.Contains(k) Then
                        Dim input As String = txtESubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtSubB.Text.Contains(k) Then
                        Dim input As String = txtSubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtESubB.Text.Contains(k) Then
                        Dim input As String = txtESubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtClear.Text.Contains(k) Then
                        Dim input As String = txtClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtEClear.Text.Contains(k) Then
                        Dim input As String = txtEClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtFail.Text.Contains(k) Then
                        Dim input As String = txtFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEFail.text) Then
                    If txtEFail.Text.Contains(k) Then
                        Dim input As String = txtEFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtHirer.Text.Contains(k) Then
                        Dim input As String = txtHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtEHirer.Text.Contains(k) Then
                        Dim input As String = txtEHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfDescription.Text.Contains(k) Then
                        Dim input As String = rtfDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If

                ElseIf Not String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfEDescription.Text.Contains(k) Then
                        Dim input As String = rtfEDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = CommonTerms.Terms.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Failed to lookup Common Terms")
        End Try

        Try
            For Each k In MonsterName.Monster.Keys
                If String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtDelivery.Text.Contains(k) Then
                        Dim input As String = txtDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtEDelivery.Text.Contains(k) Then
                        Dim input As String = txtEDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtQuestType.Text.Contains(k) Then
                        Dim input As String = txtQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtEQuestType.Text.Contains(k) Then
                        Dim input As String = txtEQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtMainObj.Text.Contains(k) Then
                        Dim input As String = txtMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtEMainObj.Text.Contains("Hunt 1") Then
                        If txtEMainObj.Text.Contains(k) Then
                            txtEMainObj.Text = "Hunt 1 " + MonsterName.Monster.Item(k)
                        End If
                    ElseIf txtEMainObj.Text.Contains("Hunt 2") Then
                        If txtEMainObj.Text.Contains(k) Then
                            txtEMainObj.Text = "Hunt 2 " + MonsterName.Monster.Item(k)
                        End If
                    ElseIf txtEMainObj.Text.Contains("Hunt 3") Then
                        If txtEMainObj.Text.Contains(k) Then
                            txtEMainObj.Text = "Hunt 3 " + MonsterName.Monster.Item(k)
                        End If
                    ElseIf txtEMainObj.Text.Contains("Hunt 4") Then
                        If txtEMainObj.Text.Contains(k) Then
                            txtEMainObj.Text = "Hunt 4 " + MonsterName.Monster.Item(k)
                        End If

                    ElseIf txtEMainObj.Text.Contains(k) Then
                        Dim input As String = txtEMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtSubA.Text.Contains(k) Then
                        Dim input As String = txtSubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtESubA.Text.Contains(k) Then
                        Dim input As String = txtESubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtSubB.Text.Contains(k) Then
                        Dim input As String = txtSubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtESubB.Text.Contains(k) Then
                        Dim input As String = txtESubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtClear.Text.Contains(k) Then
                        Dim input As String = txtClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtEClear.Text.Contains(k) Then
                        Dim input As String = txtEClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtFail.Text.Contains(k) Then
                        Dim input As String = txtFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtEFail.Text.Contains(k) Then
                        Dim input As String = txtEFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtHirer.Text.Contains(k) Then
                        Dim input As String = txtHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtEHirer.Text.Contains(k) Then
                        Dim input As String = txtEHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfDescription.Text.Contains(k) Then
                        Dim input As String = rtfDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If

                ElseIf Not String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfEDescription.Text.Contains(k) Then
                        Dim input As String = rtfEDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = MonsterName.Monster.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Failed to lookup Monster Names")
        End Try

        Try
            For Each k In FieldName.Field.Keys
                If String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtDelivery.Text.Contains(k) Then
                        Dim input As String = txtDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtEDelivery.Text.Contains(k) Then
                        Dim input As String = txtEDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtQuestType.Text.Contains(k) Then
                        Dim input As String = txtQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtEQuestType.Text.Contains(k) Then
                        Dim input As String = txtEQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtMainObj.Text.Contains(k) Then
                        Dim input As String = txtMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtEMainObj.Text.Contains(k) Then
                        Dim input As String = txtEMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtSubA.Text.Contains(k) Then
                        Dim input As String = txtSubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtESubA.Text.Contains(k) Then
                        Dim input As String = txtESubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtSubB.Text.Contains(k) Then
                        Dim input As String = txtSubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtESubB.Text.Contains(k) Then
                        Dim input As String = txtESubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtClear.Text.Contains(k) Then
                        Dim input As String = txtClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtEClear.Text.Contains(k) Then
                        Dim input As String = txtEClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtFail.Text.Contains(k) Then
                        Dim input As String = txtFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtEFail.Text.Contains(k) Then
                        Dim input As String = txtEFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtHirer.Text.Contains(k) Then
                        Dim input As String = txtHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtEHirer.Text.Contains(k) Then
                        Dim input As String = txtEHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfDescription.Text.Contains(k) Then
                        Dim input As String = rtfDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If

                ElseIf Not String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfEDescription.Text.Contains(k) Then
                        Dim input As String = rtfEDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = FieldName.Field.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Failed to lookup Field Names")
        End Try

        Try
            For Each k In ItemName.Items.Keys
                If String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtDelivery.Text.Contains(k) Then
                        Dim input As String = txtDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEDelivery.Text) Then
                    If txtEDelivery.Text.Contains(k) Then
                        Dim input As String = txtEDelivery.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEDelivery.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtQuestType.Text.Contains(k) Then
                        Dim input As String = txtQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEQuestType.Text) Then
                    If txtEQuestType.Text.Contains(k) Then
                        Dim input As String = txtEQuestType.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEQuestType.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtMainObj.Text.Contains(k) Then
                        Dim input As String = txtMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEMainObj.Text) Then
                    If txtEMainObj.Text.Contains(k) Then
                        Dim input As String = txtEMainObj.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEMainObj.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtSubA.Text.Contains(k) Then
                        Dim input As String = txtSubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubA.Text) Then
                    If txtESubA.Text.Contains(k) Then
                        Dim input As String = txtESubA.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubA.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtSubB.Text.Contains(k) Then
                        Dim input As String = txtSubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtESubB.Text) Then
                    If txtESubB.Text.Contains(k) Then
                        Dim input As String = txtESubB.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtESubB.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtClear.Text.Contains(k) Then
                        Dim input As String = txtClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEClear.Text) Then
                    If txtEClear.Text.Contains(k) Then
                        Dim input As String = txtEClear.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEClear.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtFail.Text.Contains(k) Then
                        Dim input As String = txtFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEFail.Text) Then
                    If txtEFail.Text.Contains(k) Then
                        Dim input As String = txtEFail.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEFail.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtHirer.Text.Contains(k) Then
                        Dim input As String = txtHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                ElseIf Not String.IsNullOrEmpty(txtEHirer.Text) Then
                    If txtEHirer.Text.Contains(k) Then
                        Dim input As String = txtEHirer.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        txtEHirer.Text = result
                    End If
                End If

                If String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfDescription.Text.Contains(k) Then
                        Dim input As String = rtfDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If

                ElseIf Not String.IsNullOrEmpty(rtfEDescription.Text) Then
                    If rtfEDescription.Text.Contains(k) Then
                        Dim input As String = rtfEDescription.Text
                        Dim pattern As String = "(" + k + ")"
                        Dim replace As String = ItemName.Items.Item(k)
                        Dim result As String = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase)
                        rtfEDescription.Text = result
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Failed to lookup Items Names")
        End Try
    End Sub

End Class
