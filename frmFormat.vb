Public Class frmFormat

    Private Sub btnFormat1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormat1.Click
        ExportFormat = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnFormat2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormat2.Click
        ExportFormat = 2
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class