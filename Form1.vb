Public Class Form1
    Private textDialog As Object

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        If TB1.Modified Then

            Dim a As MsgBoxResult
            a = MsgBox("Do You Want To Save changes ", MsgBoxStyle.YesNoCancel, "New Document")

            If a = MsgBoxResult.No Then
                TB1.Clear()
            ElseIf a = MsgBoxResult.Cancel Then
            ElseIf a = MsgBoxResult.Yes Then
                SaveFileDialog1.ShowDialog()
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TB1.Text, False)
                SaveFileDialog1.Filter = "Text Files|*.txt|Word Files|*.doc"
                TB1.Clear()


            End If
        Else
            TB1.Clear()

        End If


    End Sub



    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click
        If TB1.Modified Then
            Dim ask As MsgBoxResult

            ask = MsgBox("Do You Want To Save The File  ", MsgBoxStyle.YesNoCancel, "Open Document")

            If ask = MsgBoxResult.No Then
                OpenFileDialog1.ShowDialog()
                My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)

            ElseIf ask = MsgBoxResult.Cancel Then
            ElseIf ask = MsgBoxResult.Yes Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TB1.Text, False)


                TB1.Clear()

            End If
        Else
            OpenFileDialog1.ShowDialog()

            Try
                TB1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)

            Catch ex As Exception

            End Try


        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
        If My.Computer.FileSystem.FileExists(SaveFileDialog1.FileName) Then


            Dim ask As MsgBoxResult
            ask = MsgBox("File Alrady Existe, Would You Like To Replace it ?", MsgBoxStyle.YesNoCancel, "File existe")

            If ask = MsgBoxResult.No Then
                SaveFileDialog1.ShowDialog()
            ElseIf ask = MsgBoxResult.Yes Then

                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TB1.Text, False)

            End If
        Else
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TB1.Text, False)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        End

        Me.Close()

    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If TB1.CanUndo Then
            TB1.Undo()

        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        My.Computer.Clipboard.Clear()
        If TB1.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(TB1.SelectedText)
        End If

    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        My.Computer.Clipboard.Clear()
        If TB1.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(TB1.SelectedText)
        End If
        TB1.SelectedText = ""
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If My.Computer.Clipboard.ContainsText Then
            TB1.Paste()

        End If
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        Dim a As String
        Dim b As String
        a = InputBox("Enter the Text to be found")
        b = InStr(TB1.Text, a)
        If b Then
            TB1.Focus()
            TB1.SelectionStart = b - 1
            TB1.SelectionLength = Len(a)
        Else
            MsgBox("Text not found")


        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        TB1.SelectAll()

    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        FontDialog1.ShowDialog()
        TB1.Font = FontDialog1.Font

    End Sub

    Private Sub FiontColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiontColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        TB1.ForeColor = ColorDialog1.Color

    End Sub

    Private Sub BackColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackColorToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        TB1.BackColor = ColorDialog1.Color

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel1.Text = TimeOfDay.ToString("h:mm:ss tt")
        ToolStripStatusLabel2.Text = DateTime.Now.ToLongDateString()

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub

    Private Sub SendFeedbcakToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendFeedbcakToolStripMenuItem.Click
        MsgBox("please email me chethanvarfa10@gmail.com , to copy email clock on yes ", MsgBoxStyle.YesNo, "File existe")
        If MsgBoxResult.Yes Then
            My.Computer.Clipboard.SetText("chethanvarfa10@gmail.com")
        End If

    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        MsgBox("please email me chethanvarfa10@gmail.com , to copy email clock on yes ", MsgBoxStyle.YesNo, "File existe")
        If MsgBoxResult.Yes Then
            My.Computer.Clipboard.SetText("chethanvarfa10@gmail.com")
        End If
    End Sub

End Class
