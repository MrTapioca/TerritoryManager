Imports System.Windows.Forms

Public Class frmEditHeaderDoor

    Dim Loading As Boolean

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Select Case HeaderDoorChange

            Case 1 ' ADD HEADER

                TempSector(SelectedSector).P5_intHeaderCount += 1

                With TempHeader(SelectedSector, TempSector(SelectedSector).P5_intHeaderCount - 1)
                    .P1_strBuilding = txtNumber.Text
                    .P2_strStreet = txtStreet.Text
                    .P3_bytCensusStatus = 1
                    .P4_dteCensusDate = #1/1/2011#
                    .P5_bytOtherInfo = 0
                    .P6_strOtherInfoText = ""
                    .P7_intDoorCount = 0
                End With

            Case 2 ' EDIT HEADER

                With TempHeader(SelectedSector, SelectedHeader)
                    .P1_strBuilding = txtNumber.Text
                    .P2_strStreet = txtStreet.Text
                End With

            Case 3 ' ADD DOOR

                TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount += 1

                With TempDoor(SelectedSector, SelectedHeader, _
                              TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1)
                    .P0_strDoorNum = txtNumber.Text
                    .P1_bytInfoSelection = 1
                    .P2_strRV = ""
                    .P3_strRVOwner = ""
                    .P4_dteDoNotVisit = #1/1/2011#
                    .P5_dteCaution = #1/1/2011#
                    .P6_strPublisher = ""
                    .P7_bytAfternoons = 0
                    .P8_bytOtherInfo = 0
                    .P9_strOtherInfoText = ""
                End With

            Case 4 ' EDIT DOOR

                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum = txtNumber.Text

        End Select

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmEditHeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Loading = True

        Select Case HeaderDoorChange

            Case 1 ' ADD HEADER

                If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                    ' ADD Header: Houses

                    Me.Text = "Nueva Calle"

                    lblNumber.Visible = False
                    txtNumber.Visible = False

                    lblStreet.Left -= 76
                    txtStreet.Left -= 76
                    btnOK.Left -= 76
                    btnCancel.Left -= 76
                    Me.Width -= 76

                Else
                    ' ADD Header: Apartments

                    Me.Text = "Nuevo Edificio"
                    lblNumber.Text = "Edificio:"

                End If

            Case 2 ' EDIT HEADER

                If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                    ' EDIT Header: Houses

                    Me.Text = "Editar Calle"

                    lblNumber.Visible = False
                    txtNumber.Visible = False

                    lblStreet.Left -= 76
                    txtStreet.Left -= 76
                    btnOK.Left -= 76
                    btnCancel.Left -= 76
                    Me.Width -= 76

                Else
                    'EDIT Header: Apartments

                    Me.Text = "Editar Edificio"
                    lblNumber.Text = "Edificio:"

                End If

                txtNumber.Text = TempHeader(SelectedSector, SelectedHeader).P1_strBuilding
                txtStreet.Text = TempHeader(SelectedSector, SelectedHeader).P2_strStreet

            Case 3 ' ADD DOOR

                Me.Text = "Nueva Puerta"
                lblNumber.Text = "Puerta:"

                lblStreet.Visible = False
                txtStreet.Visible = False

                btnOK.Left -= 131
                btnCancel.Left -= 131
                Me.Width -= 131

            Case 4 ' EDIT DOOR
                Me.Text = "Editar Puerta"
                lblNumber.Text = "Puerta:"

                lblStreet.Visible = False
                txtStreet.Visible = False

                btnOK.Left -= 131
                btnCancel.Left -= 131
                Me.Width -= 131

                txtNumber.Text = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum

        End Select

        Loading = False

    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged

        If Loading = True Then Exit Sub

        If HeaderDoorChange = 1 Or HeaderDoorChange = 2 Then
            If TempSector(SelectedSector).P2_bytIsApt = 1 Then
                If txtNumber.Text.Trim = "" Then
                    btnOK.Enabled = False
                Else
                    btnOK.Enabled = True
                End If
            End If
        Else
            If txtNumber.Text.Trim = "" Then
                btnOK.Enabled = False
            Else
                btnOK.Enabled = True
            End If
        End If

    End Sub

    Private Sub txtStreet_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStreet.TextChanged

        If Loading = True Then Exit Sub

        If HeaderDoorChange = 1 Or HeaderDoorChange = 2 Then
            If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                If txtStreet.Text.Trim = "" Then
                    btnOK.Enabled = False
                Else
                    btnOK.Enabled = True
                End If
            Else
                If txtNumber.Text.Trim <> "" Then btnOK.Enabled = True
            End If
        End If

    End Sub
End Class
