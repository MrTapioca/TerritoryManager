Imports System.Windows.Forms

Public Class frmEditTerrInfo

    Dim Loading As Boolean

    ' KEY PRESS ON TERR NUM AND ZIP
    Private Sub txtTerrZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTerrZip.KeyPress
        ' Cancel the keypress if the character entered is not a number
        If Char.IsLetter(e.KeyChar) = True Or _
        Char.IsPunctuation(e.KeyChar) = True Or _
        Char.IsSymbol(e.KeyChar) = True Or _
        Char.IsWhiteSpace(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTerrNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTerrNum.KeyPress
        ' Cancel the keypress if the character entered is not a number
        If Char.IsLetter(e.KeyChar) = True Or _
        Char.IsPunctuation(e.KeyChar) = True Or _
        Char.IsSymbol(e.KeyChar) = True Or _
        Char.IsWhiteSpace(e.KeyChar) = True Then
            e.Handled = True
        End If
    End Sub

    ' SAVE
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtTerrName.Text.Trim = "" Then
            MsgBox("El territorio debe tener un nombre.")

            ' Set focus on name TextBox and select all (spaces)
            txtTerrName.Focus()
            txtTerrName.SelectAll()

            ' Cancel save
            Exit Sub
        End If

        ' Save territory info on DB
        If txtTerrNum.Text = "" Then txtTerrNum.Text = "0"
        MainInfo.P0_intTerrNum = CInt(txtTerrNum.Text)
        MainInfo.P1_strName = txtTerrName.Text
        MainInfo.P2_strNote = txtTerrNote.Text
        MainInfo.P3_strZipCode = txtTerrZip.Text

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    ' CANCEL
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' LOAD
    Private Sub frmEditTerrInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Loading = True

        ' Load the territory info on the form
        txtTerrNum.Text = MainInfo.P0_intTerrNum.ToString
        txtTerrName.Text = MainInfo.P1_strName
        txtTerrNote.Text = MainInfo.P2_strNote
        txtTerrZip.Text = MainInfo.P3_strZipCode

        Loading = False
    End Sub

    Private Sub txtTerrName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerrName.TextChanged
        If Loading = False Then btnSave.Enabled = True
    End Sub

    Private Sub txtTerrNote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerrNote.TextChanged
        If Loading = False Then btnSave.Enabled = True
    End Sub

    Private Sub txtTerrNum_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerrNum.TextChanged
        If Loading = False Then btnSave.Enabled = True
    End Sub

    Private Sub txtTerrZip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerrZip.TextChanged
        If Loading = False Then btnSave.Enabled = True
    End Sub
End Class
