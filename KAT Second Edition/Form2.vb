' Copyright to KP'S TV,Inc
' Build By : Kaustubh Patange (KP)
' Deprecated Codes !

' Original Tool : https://kpstvhub.com/blog/2017/03/07/kat/

Public Class Form2
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Timer2.Start()

    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        If MaterialCheckBox1.Checked = True Then
            Process.Start("Files\adb-drivers.exe")
        End If
        If MaterialCheckBox2.Checked = True Then
            Process.Start("Files\PdaNetA4197.exe")
        End If
        If MaterialCheckBox2.Checked = True Then
            '' ANY Driver here bro
        End If
        If MaterialCheckBox1.Checked = False Then
            If MaterialCheckBox2.Checked = False Then
                If MaterialCheckBox3.Checked = False Then
                    Form1.TextBox1.AppendText(Environment.NewLine & "Please Select a Driver")
                End If
            End If
        End If
    End Sub

    Private Sub MaterialCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialCheckBox1.CheckedChanged
        If MaterialCheckBox1.Checked = True Then
            MaterialCheckBox2.Checked = False
            MaterialCheckBox3.Checked = False
        End If
    End Sub

    Private Sub MaterialCheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialCheckBox2.CheckedChanged
        If MaterialCheckBox2.Checked = True Then
            MaterialCheckBox1.Checked = False
            MaterialCheckBox3.Checked = False
        End If
    End Sub

    Private Sub MaterialCheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialCheckBox3.CheckedChanged
        If MaterialCheckBox3.Checked = True Then
            MaterialCheckBox2.Checked = False
            MaterialCheckBox1.Checked = False
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.1
        If Me.Opacity >= 1.0 Then
            Me.Opacity = 1
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Opacity = Me.Opacity - 0.1
        If Me.Opacity < 0.1 Then
            Timer2.Stop()
            Me.Close()
        End If
    End Sub
End Class