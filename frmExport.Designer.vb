<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.prgProgress = New System.Windows.Forms.ProgressBar
        Me.wkrExport = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'prgProgress
        '
        Me.prgProgress.Location = New System.Drawing.Point(12, 12)
        Me.prgProgress.MarqueeAnimationSpeed = 25
        Me.prgProgress.Name = "prgProgress"
        Me.prgProgress.Size = New System.Drawing.Size(276, 23)
        Me.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.prgProgress.TabIndex = 0
        '
        'wkrExport
        '
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(300, 47)
        Me.ControlBox = False
        Me.Controls.Add(Me.prgProgress)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Exportando..."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents prgProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents wkrExport As System.ComponentModel.BackgroundWorker

End Class
