Imports RegawMOD.Android

Public Class Mssgbox5
    Private Sub MaterialFlatButton2_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton2.Click
        Form1.Delay(1)
        Me.Close()
    End Sub

    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click
        Form1.Delay(1)
        Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot"))
    End Sub
End Class