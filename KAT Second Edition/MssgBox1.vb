Imports KPMod
Public Class MssgBox1
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        Form1.Delay(1)
        If PictureBox1.BackColor = Color.Blue Then
            mfastboot.Reboot_continue()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub MaterialFlatButton2_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton2.Click
        Form1.Delay(1)
        Me.Close()
    End Sub
End Class