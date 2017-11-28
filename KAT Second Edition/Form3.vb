' Copyright to KP'S TV,Inc
' Build By : Kaustubh Patange (KP)
' Deprecated Codes !

' Original Tool : https://kpstvhub.com/blog/2017/03/07/kat/

Public Class Form3
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://kpstvhub.com/blog/2017/04/12/prop-tweaker/")
    End Sub



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        If My.Computer.FileSystem.FileExists("Files\Buildprop.cf") Then
            MaterialCheckBox1.Checked = True
        Else
            MaterialCheckBox1.Checked = False
        End If
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
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        Timer2.Start()
    End Sub
    Public Sub SavefromResource(ByVal filepath As String, ByVal File As Object)
        Dim Fbyte() As Byte = File
        My.Computer.FileSystem.WriteAllBytes(filepath, Fbyte, True)
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        If MaterialCheckBox1.Checked = True Then
            Form1.Delay(1)
            IO.File.WriteAllText("Files\Buildprop.cf", "Lisence Accepted!")
            If Not My.Computer.FileSystem.FileExists("Prop-Tweaker.exe") Then
                SavefromResource("Prop-Tweaker.exe", My.Resources.Prop_Tweaker)
            End If
            Process.Start("Prop-Tweaker.exe")
            Timer2.Start()
        End If
    End Sub

    Private Sub MaterialCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialCheckBox1.CheckedChanged
        If MaterialCheckBox1.Checked = True Then
            MaterialRaisedButton1.Enabled = True
        Else
            MaterialRaisedButton1.Enabled = False
        End If
    End Sub
End Class