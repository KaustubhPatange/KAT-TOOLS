' Copyright to KP'S TV,Inc
' Build By : Kaustubh Patange (KP)
' Deprecated Codes !

' Original Tool : https://kpstvhub.com/blog/2017/03/07/kat/


Imports MaterialSkin
Imports RegawMOD.Android
Imports KPMod
Imports XamlGeneratedNamespace
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports MaterialSkin.Animations
Imports System.Threading.Tasks
Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports System.Management
Imports System.Text.RegularExpressions

Public Class Form1
    Dim android As AndroidController
    Dim device As Device
    Delegate Sub UpdateTextBoxDelg(text As String)
    Public myDelegate As UpdateTextBoxDelg = New UpdateTextBoxDelg(AddressOf UpdateTextBox)
    Public Sub UpdateTextBox(text As String)
        TextBox1.AppendText(text & Environment.NewLine)
        TextBox1.SelectionStart = TextBox1.Text.Length
        TextBox1.ScrollToCaret()
    End Sub

    Public Sub proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(myDelegate, e.Data)
        Else
            UpdateTextBox(e.Data)
        End If
    End Sub
    Public Sub Delay(ByVal DelayInSeconds As Integer)
        Dim ts As TimeSpan
        Dim targetTime As DateTime = DateTime.Now.AddSeconds(DelayInSeconds)
        Do
            ts = targetTime.Subtract(DateTime.Now)
            Application.DoEvents() ' keep app responsive
            System.Threading.Thread.Sleep(50) ' reduce CPU usage
        Loop While ts.TotalSeconds > 0
    End Sub
    Private Sub Form1_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'ALWAYS remember to call this when you're done with AndroidController.  It removes the resources used by this library!
        '  android.Dispose()
        Timer4.Start()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Start()
        android = AndroidController.Instance
        Timer1.Start()

        Dim SkinManager As MaterialSkin.MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Green700, Accent.Green700, TextShade.WHITE)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (android.HasConnectedDevices) Then
            AdbDevice.Adb_getValues()
        Else
            AdbDevice.Device_error()
        End If
    End Sub
    Public Sub errorp()
        TextBox1.AppendText(Environment.NewLine & "No Device Connected..!!")
    End Sub
    Private Sub MaterialFlatButton1_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton1.Click

        TextBox1.AppendText(Environment.NewLine & "Checking Device State..")
        Delay(1)
        If PictureBox1.BackColor = Color.Lime Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot"))
        ElseIf PictureBox1.BackColor = Color.Blue Then
            TextBox1.AppendText(Environment.NewLine & "Fastboot Reboot..")
            mfastboot.Reboot_Normal()
        ElseIf PictureBox1.BackColor = Color.Orange Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting to System..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot"))
        ElseIf PictureBox1.BackColor = Color.GreenYellow Then
            TextBox1.AppendText(Environment.NewLine & "Close the Sideloading Then try")
        ElseIf PictureBox1.BackColor = Color.Red Then
            errorp()
        End If
        Delay(1)
        TextBox1.AppendText(Environment.NewLine & "Done")
    End Sub

    Private Sub MaterialFlatButton2_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton2.Click
        TextBox1.AppendText(Environment.NewLine & "Checking Device State..")
        Delay(1)
        If PictureBox1.BackColor = Color.Lime Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot recovery"))
        ElseIf PictureBox1.BackColor = Color.Blue Then
            TextBox1.AppendText(Environment.NewLine & "Fastboot Reboot Recovery..")
            mfastboot.Reboot_Normal()
            Delay(7)
            Do Until PictureBox1.BackColor = Color.Lime
                Delay(2)
                TextBox1.AppendText(Environment.NewLine & "Waiting to Detect Automatically.. Do not unplug!")
            Loop
            TextBox1.AppendText(Environment.NewLine & "Rebooting..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot recovery"))
        ElseIf PictureBox1.BackColor = Color.Orange Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting to Recovery..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot recovery"))
        ElseIf PictureBox1.BackColor = Color.GreenYellow Then
            TextBox1.AppendText(Environment.NewLine & "Close the Sideloading Then try")
        ElseIf PictureBox1.BackColor = Color.Red Then
            errorp()
        End If
        Delay(1)
        TextBox1.AppendText(Environment.NewLine & "Done")
    End Sub

    Private Sub MaterialFlatButton3_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton3.Click
        TextBox1.AppendText(Environment.NewLine & "Checking Device State..")
        Delay(1)
        If PictureBox1.BackColor = Color.Lime Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot bootloader"))
        ElseIf PictureBox1.BackColor = Color.Blue Then
            TextBox1.AppendText(Environment.NewLine & "Fastboot Rebooting..")
            mfastboot.Reboot_Bootloader()
        ElseIf PictureBox1.BackColor = Color.Orange Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting to Bootloader..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot bootloader"))
        ElseIf PictureBox1.BackColor = Color.GreenYellow Then
            TextBox1.AppendText(Environment.NewLine & "Close the Sideloading Then try")
        ElseIf PictureBox1.BackColor = Color.Red Then
            errorp()
        End If
        Delay(1)
        TextBox1.AppendText(Environment.NewLine & "Done")
    End Sub

    Private Sub MaterialFlatButton4_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton4.Click
        TextBox1.AppendText(Environment.NewLine & "Checking Device State..")
        Delay(1)
        If PictureBox1.BackColor = Color.Lime Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot download"))
        ElseIf PictureBox1.BackColor = Color.Orange Then
            TextBox1.AppendText(Environment.NewLine & "Rebooting to Download..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot download"))
        ElseIf PictureBox1.BackColor = Color.GreenYellow Then
            TextBox1.AppendText(Environment.NewLine & "Close the Sideloading Then try")
        ElseIf PictureBox1.BackColor = Color.Red Then
            errorp()
        End If
        Delay(1)
        TextBox1.AppendText(Environment.NewLine & "Done")
    End Sub

    Private Sub MaterialFlatButton5_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton5.Click
        TextBox1.AppendText(Environment.NewLine & "Checking Device State..")
        Delay(1)
        If PictureBox1.BackColor = Color.Lime Then
            TextBox1.AppendText(Environment.NewLine & "Swicthing Off..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("shell reboot -p"))
        ElseIf PictureBox1.BackColor = Color.Blue Then
            TextBox1.AppendText(Environment.NewLine & "Can't do in Fastboot Mode..")
        ElseIf PictureBox1.BackColor = Color.Orange Then
            TextBox1.AppendText(Environment.NewLine & "Switching Off..")
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("shell reboot -p"))
        ElseIf PictureBox1.BackColor = Color.GreenYellow Then
            TextBox1.AppendText(Environment.NewLine & "Close the Sideloading Then try")
        ElseIf PictureBox1.BackColor = Color.Red Then
            errorp()
        End If
        Delay(1)
        TextBox1.AppendText(Environment.NewLine & "Done")
    End Sub

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        Me.Opacity = 30.1
        Form2.Close()
        Form2.Show()
    End Sub
    Public Sub Unlockbootp()
        ProgressBar1.Value = 20
        TextBox1.AppendText(Environment.NewLine & "Sending Keys..")
        Delay(1)
        mfastboot.OEM_unlock()
        ProgressBar1.Value = 35
        TextBox1.AppendText(Environment.NewLine & "Unlocking..")
        Delay(1)
        mfastboot.OEM_unlock_go()
        ProgressBar1.Value = 45
        TextBox1.AppendText(Environment.NewLine & "Formatting userdata..")
        Delay(1)
        mfastboot.Format_userdata()
        ProgressBar1.Value = 70
        Delay(1)
        ProgressBar1.Value = 75
        Delay(1)
        ProgressBar1.Value = 80
        Delay(1)
        ProgressBar1.Value = 90
        Delay(1)
        ProgressBar1.Value = 100
        MssgBox1.Close()
        MssgBox1.Show()
        ProgressBar1.Value = 0
    End Sub
    Private Sub MaterialRaisedButton2_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton2.Click
        If MaterialRadioButton1.Checked = True Then
            If PictureBox1.BackColor = Color.Blue Then
                ProgressBar1.Value = 0
                TextBox1.AppendText(Environment.NewLine & "Unlocking..")
                Delay(1)
                Unlockbootp()
            ElseIf PictureBox1.BackColor = Color.Lime Then
                ProgressBar1.Value = 0
                Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot bootloader"))
                TextBox1.AppendText(Environment.NewLine & "Unlocking..")
                Delay(8)
                MssgBox2.Close()
                MssgBox2.Show()
                Delay(3)
                Unlockbootp()
            ElseIf PictureBox1.BackColor = Color.Orange Then
                ProgressBar1.Value = 0
                Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot bootloader"))
                TextBox1.AppendText(Environment.NewLine & "Unlocking..")
                Delay(8)
                MssgBox2.Close()
                MssgBox2.Show()
                Delay(3)
                Unlockbootp()
            Else
                TextBox1.AppendText(Environment.NewLine & "Your Device Is Not connected Or maybe offline Or unauthorized, check it And then do job")
            End If
        End If
    End Sub

    Private Sub MaterialFlatButton6_Click(sender As Object, e As EventArgs) Handles MaterialFlatButton6.Click
        If PictureBox1.BackColor = Color.Blue Then
            TextBox1.AppendText(Environment.NewLine)
            mfastboot.OEM_checkstate()
        Else
            Label1.Text = "Device Not Reliable or not Connected ! Waiting to Auto detect"
            PictureBox1.BackColor = Color.Red
            TextBox1.Text &= Environment.NewLine
            TextBox1.AppendText("Error - No Devices Connected in Bootloader")
        End If
    End Sub

    Private Sub MaterialRaisedButton5_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton5.Click
        If My.Computer.FileSystem.FileExists("Files\Buildprop.cf") Then
            If My.Computer.FileSystem.FileExists("Files\Buildprop.cf") Then
                Process.Start("Prop-Tweaker.exe")
            Else
                Form3.Close()
                Form3.Show()
            End If
        Else
                Form3.Close()
            Form3.Show()
        End If
    End Sub

    Private Sub MaterialRaisedButton4_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton4.Click
        If Not My.Computer.FileSystem.FileExists("Android Browser.exe") Then
            Form3.SavefromResource("Android Browser.exe", My.Resources.Android_Browser)
        End If
        Process.Start("Android Browser.exe")
    End Sub

    Private Sub MaterialRaisedButton6_Click(sender As Object, e As EventArgs)

    End Sub
    Public opt As String
    Private Sub MaterialRadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialRadioButton5.CheckedChanged
        MaterialRaisedButton7.Text = "Sideload"
        MaterialSingleLineTextField1.Text = " "
        MaterialLabel9.Enabled = False
        MetroComboBox1.Enabled = False
        opt = "Zip Files|*.zip"
    End Sub

    Private Sub MaterialRadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialRadioButton6.CheckedChanged
        MaterialRaisedButton7.Text = "Install"
        MaterialSingleLineTextField1.Text = " "
        MaterialLabel9.Enabled = False
        MetroComboBox1.Enabled = False
        opt = "Apk Files|*.apk|All Files|*.*"
    End Sub

    Private Sub MaterialRadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialRadioButton7.CheckedChanged
        MaterialRaisedButton7.Text = "Flash It"
        MaterialSingleLineTextField1.Text = " "
        MetroComboBox1.Text = "boot"
        MetroComboBox1.Enabled = True
        MaterialLabel9.Enabled = True
        opt = "Img Files|*.img|All Files|*.*"
    End Sub

    Private Sub MaterialRaisedButton6_Click_1(sender As Object, e As EventArgs) Handles MaterialRaisedButton6.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = opt
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            MaterialSingleLineTextField1.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub TimerStartbefore()

        Timer2.Stop()
        ProgressBar1.Value = 0
        Timer2.Interval = 70
        Timer2.Start()
    End Sub
    Private Sub Timerend()
        Timer2.Stop()
        ProgressBar1.Value = 100
        Delay(2)
        ProgressBar1.Value = 0
    End Sub
    Public passon As String
    Public Sub ComponentSideload_Flash()
        Do Until PictureBox1.BackColor = Color.GreenYellow
            Delay(2)
            TextBox1.AppendText(Environment.NewLine & "Waiting to Automatically Detect in Sideload!")
        Loop
        TimerStartbefore()
        Delay(2)
        'Realtimeretprocess("adb.exe", "sideload " + passon, "temp", TextBox1)
        Dim p As New Process()

        p.StartInfo.FileName = "adb.exe"
        p.StartInfo.Arguments = "sideload " + passon
        p.StartInfo.WorkingDirectory = "temp"
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.EnableRaisingEvents = True
        Application.DoEvents()
        AddHandler p.ErrorDataReceived, AddressOf proc_OutputDataReceived
        AddHandler p.OutputDataReceived, AddressOf proc_OutputDataReceived
        p.Start()
        p.BeginErrorReadLine()
        p.BeginOutputReadLine()

        Delay(3)
        TextBox1.AppendText(vbCrLf & "Done..")
        Timerend()
        Mssgbox5.Close()
        Mssgbox5.Show()
    End Sub
    Public Sub CompenentSideload()
        If PictureBox1.BackColor = Color.GreenYellow Then
            passon = """" + OpenFileDialog1.FileName + """"
            ComponentSideload_Flash()
        ElseIf PictureBox1.BackColor = Color.Orange Then
            passon = """" + OpenFileDialog1.FileName + """"
            Mssgbox6.Close()
            Mssgbox6.ShowDialog()
            Delay(2)
            ComponentSideload_Flash()
        ElseIf PictureBox1.BackColor = Color.Red Then
            TextBox1.AppendText(Environment.NewLine & "Did Not find any Connected Devices!")
        ElseIf PictureBox1.BackColor = Color.Lime Then
            passon = """" + OpenFileDialog1.FileName + """"
            TextBox1.Text &= Environment.NewLine & "Rebooting Recovery"
            TextBox1.Text &= Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot recovery"))
            Delay(7)
            Mssgbox6.Close()
            Mssgbox6.ShowDialog()
            Delay(2)
            ComponentSideload_Flash()
        ElseIf PictureBox1.BackColor = Color.Blue Then
            mfastboot.Reboot_Normal()
            ProgressBar1.Value = 0
            Delay(6)
            Do Until PictureBox1.BackColor = Color.Lime
                Delay(2)
                TextBox1.AppendText(Environment.NewLine & "Waiting for device.. Do not unplug it")
            Loop
            TextBox1.AppendText(Environment.NewLine & "Rebooting to recovery")
            Delay(1)
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot recovery"))
            Delay(6)
            Mssgbox6.Close()
            Mssgbox6.ShowDialog()
            Delay(2)
            ComponentSideload_Flash()
        End If
    End Sub
    Public Sub ComponentSideload_Install()
        Do Until PictureBox1.BackColor = Color.Lime
            Delay(2)
            TextBox1.AppendText(Environment.NewLine & "Waiting to Automatically Detect in Android!")
        Loop
        TimerStartbefore()
        Delay(2)
        Dim p As New Process()
        p.StartInfo.FileName = "adb.exe"
        p.StartInfo.Arguments = "install -r " + passon
        p.StartInfo.WorkingDirectory = "temp"
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.EnableRaisingEvents = True
        Application.DoEvents()
        AddHandler p.ErrorDataReceived, AddressOf proc_OutputDataReceived
        AddHandler p.OutputDataReceived, AddressOf proc_OutputDataReceived
        p.Start()
        p.BeginErrorReadLine()
        p.BeginOutputReadLine()
        Delay(3)
        TextBox1.AppendText(vbCrLf & "Done..")
        Timerend()
    End Sub
    Public Sub CompenentInstall()
        If PictureBox1.BackColor = Color.Orange Then
            TextBox1.AppendText(Environment.NewLine & "--Rebooting--")
            passon = """" + OpenFileDialog1.FileName + """"
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot"))
            Delay(5)
            ComponentSideload_Install()
        ElseIf PictureBox1.BackColor = Color.Red Then
            TextBox1.AppendText(Environment.NewLine & "Did Not find any Connected Devices!")
        ElseIf PictureBox1.BackColor = Color.Lime Then
            passon = """" + OpenFileDialog1.FileName + """"
            ComponentSideload_Install()
        ElseIf PictureBox1.BackColor = Color.Blue Then
            TextBox1.AppendText(Environment.NewLine & "--Rebooting--")
            Delay(1)
            mfastboot.Reboot_Normal()
            passon = """" + OpenFileDialog1.FileName + """"
            Delay(5)
            ComponentSideload_Install()
        End If
    End Sub
    Dim Refrence As String
    Public Sub ImgFlashNew()
        Do Until PictureBox1.BackColor = Color.Blue
            Delay(2)
            TextBox1.AppendText(Environment.NewLine & "Waiting to Automatically Detect in Fastboot!")
        Loop
        TimerStartbefore()
        Delay(2)
        Application.DoEvents()
        Dim p As New Process
        p.StartInfo.FileName = "fastboot"
        p.StartInfo.Arguments = "flash " + Refrence + " " + passon
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.EnableRaisingEvents = True
        Application.DoEvents()
        AddHandler p.ErrorDataReceived, AddressOf proc_OutputDataReceived
        AddHandler p.OutputDataReceived, AddressOf proc_OutputDataReceived
        p.Start()
        p.BeginErrorReadLine()
        p.BeginOutputReadLine()
        Do Until p.HasExited()
            Delay(2)
        Loop

        TextBox1.AppendText(vbCrLf & "Done..")
        Timerend()
        MssgBox1.Close()
        MssgBox1.Show()
    End Sub
    Public Sub CompenentFlash()
        If PictureBox1.BackColor = Color.Blue Then
            passon = """" + OpenFileDialog1.FileName + """"
            ProgressBar1.Value = 0
            TextBox1.AppendText(Environment.NewLine & "Hooking Resources..")
            Delay(1)
            ImgFlashNew()
        ElseIf PictureBox1.BackColor = Color.Lime Then
            passon = """" + OpenFileDialog1.FileName + """"
            ProgressBar1.Value = 0
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot bootloader"))
            TextBox1.AppendText(Environment.NewLine & "--Rebooting to Bootloader--")
            Delay(8)
            MssgBox2.Close()
            MssgBox2.ShowDialog()
            ImgFlashNew()
        ElseIf PictureBox1.BackColor = Color.Orange Then
            passon = """" + OpenFileDialog1.FileName + """"
            ProgressBar1.Value = 0
            Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot bootloader"))
            TextBox1.AppendText(Environment.NewLine & "--Rebooting to Bootloader--")
            Delay(8)
            MssgBox2.Close()
            MssgBox2.ShowDialog()
            ImgFlashNew()
        Else
            ImgFlashNew() ' Remove lATA
            TextBox1.AppendText(Environment.NewLine & Environment.NewLine & "Your Device Is Not connected Or maybe offline Or unauthorized, check it And then do job")
        End If
    End Sub
    Private Sub MaterialRaisedButton7_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton7.Click
        If My.Computer.FileSystem.FileExists(MaterialSingleLineTextField1.Text) Then
            Select Case MaterialRaisedButton7.Text
                Case "Sideload"
                    CompenentSideload()
                Case "Install"
                    CompenentInstall()
                Case "Flash It"
                    MssgBox4.Close()
                    MssgBox4.ShowDialog()
                    CompenentFlash()
                Case Else
                    TextBox1.AppendText(Environment.NewLine & "No Method found for this Action!")
            End Select
        Else
            TextBox1.AppendText(Environment.NewLine & "No File Found for Action!")
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ProgressBar1.Increment(1)
    End Sub

    Public Sub ComponentSideload_Normal()

        Do Until PictureBox1.BackColor = Color.GreenYellow
            Delay(2)
            TextBox1.AppendText(Environment.NewLine & "Waiting to Automatically Detect in Sideload!")
        Loop
        TimerStartbefore()
        Delay(2)
        'Realtimeretprocess("adb.exe", "sideload " + passon, "temp", TextBox1)
        Dim myprocess As Process = New Process
        myprocess.StartInfo.FileName = "adb"
        myprocess.StartInfo.Arguments = "sideload files\Original-SuperSU.zip"
        myprocess.StartInfo.UseShellExecute = False
        myprocess.StartInfo.CreateNoWindow = True
        myprocess.StartInfo.RedirectStandardInput = True
        myprocess.StartInfo.RedirectStandardOutput = True
        myprocess.StartInfo.RedirectStandardError = True
        myprocess.Start()
        While (myprocess.HasExited = False)
            Dim sLine As String = myprocess.StandardOutput.ReadLine
            If (Not String.IsNullOrEmpty(sLine)) Then
            End If
            TextBox1.AppendText(sLine & vbCrLf)
            Application.DoEvents()
        End While

        Delay(3)
        TextBox1.AppendText(vbCrLf & "Done..")
        Timerend()
        Mssgbox5.Close()
        Mssgbox5.Show()
    End Sub
    Public Sub ComponentSideload_Beta()
        Do Until PictureBox1.BackColor = Color.GreenYellow
            Delay(2)
            TextBox1.AppendText(Environment.NewLine & "Waiting to Automatically Detect in Sideload!")
        Loop
        TimerStartbefore()
        Delay(2)
        'Realtimeretprocess("adb.exe", "sideload " + passon, "temp", TextBox1)
        Dim myprocess As Process = New Process
        myprocess.StartInfo.FileName = "adb"
        myprocess.StartInfo.Arguments = "sideload files\BETA-SuperSU.zip"
        myprocess.StartInfo.UseShellExecute = False
        myprocess.StartInfo.CreateNoWindow = True
        myprocess.StartInfo.RedirectStandardInput = True
        myprocess.StartInfo.RedirectStandardOutput = True
        myprocess.StartInfo.RedirectStandardError = True
        myprocess.Start()
        While (myprocess.HasExited = False)
            Dim sLine As String = myprocess.StandardOutput.ReadLine
            If (Not String.IsNullOrEmpty(sLine)) Then
            End If
            TextBox1.AppendText(sLine & vbCrLf)
            Application.DoEvents()
        End While
        Delay(3)
        TextBox1.AppendText(vbCrLf & "Done..")
        Timerend()
        Mssgbox5.Close()
        Mssgbox5.Show()
    End Sub
    Private Sub MaterialRaisedButton3_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton3.Click
        If MaterialRadioButton3.Checked = True Then

            If PictureBox1.BackColor = Color.GreenYellow Then
                passon = """" + OpenFileDialog1.FileName + """"
                ComponentSideload_Beta()
            ElseIf PictureBox1.BackColor = Color.Orange Then
                passon = """" + OpenFileDialog1.FileName + """"
                Mssgbox6.Close()
                Mssgbox6.ShowDialog()
                Delay(2)
                ComponentSideload_Beta()
            ElseIf PictureBox1.BackColor = Color.Red Then
                TextBox1.AppendText(Environment.NewLine & "Did Not find any Connected Devices!")
            ElseIf PictureBox1.BackColor = Color.Lime Then
                passon = """" + OpenFileDialog1.FileName + """"
                TextBox1.Text &= Environment.NewLine & "Rebooting Recovery"
                TextBox1.Text &= Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot recovery"))
                Delay(7)
                Mssgbox6.Close()
                Mssgbox6.ShowDialog()
                Delay(2)
                ComponentSideload_Beta()
            ElseIf PictureBox1.BackColor = Color.Blue Then

                mfastboot.Reboot_Normal()
                ProgressBar1.Value = 0
                Delay(6)
                Do Until PictureBox1.BackColor = Color.Lime
                    Delay(2)
                    TextBox1.AppendText(Environment.NewLine & "Waiting for device.. Do not unplug it")
                Loop
                TextBox1.AppendText(Environment.NewLine & "Rebooting to recovery")
                Delay(1)
                Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot recovery"))
                Delay(6)
                Mssgbox6.Close()
                Mssgbox6.ShowDialog()
                Delay(2)
                ComponentSideload_Beta()
            End If
        End If
        If MaterialRadioButton4.Checked = True Then

            If PictureBox1.BackColor = Color.GreenYellow Then
                passon = """" + OpenFileDialog1.FileName + """"
                ComponentSideload_Normal()
            ElseIf PictureBox1.BackColor = Color.Orange Then
                passon = """" + OpenFileDialog1.FileName + """"
                Mssgbox6.Close()
                Mssgbox6.ShowDialog()
                Delay(2)
                ComponentSideload_Normal()
            ElseIf PictureBox1.BackColor = Color.Red Then
                TextBox1.AppendText(Environment.NewLine & "Did Not find any Connected Devices!")
            ElseIf PictureBox1.BackColor = Color.Lime Then
                passon = """" + OpenFileDialog1.FileName + """"
                TextBox1.Text &= Environment.NewLine & "Rebooting Recovery"
                TextBox1.Text &= Adb.ExecuteAdbCommand(Adb.FormAdbCommand("reboot recovery"))
                Delay(7)
                Mssgbox6.Close()
                Mssgbox6.ShowDialog()
                Delay(2)
                ComponentSideload_Normal()
            ElseIf PictureBox1.BackColor = Color.Blue Then
                mfastboot.Reboot_Normal()
                ProgressBar1.Value = 0
                Delay(6)
                Do Until PictureBox1.BackColor = Color.Lime
                    Delay(2)
                    TextBox1.AppendText(Environment.NewLine & "Waiting for device.. Do not unplug it")
                Loop
                TextBox1.AppendText(Environment.NewLine & "Rebooting to recovery")
                Delay(1)
                Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("reboot recovery"))
                Delay(6)
                Mssgbox6.Close()
                Mssgbox6.ShowDialog()
                Delay(2)
                ComponentSideload_Normal()
            End If
        End If
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedIndexChanged
        Select Case MetroComboBox1.SelectedItem
            Case "kernel"
                Refrence = "boot"
                TextBox1.AppendText(Environment.NewLine & "Partition As boot")
            Case "ramdisk"
                Refrence = "ramdisk"
                TextBox1.AppendText(Environment.NewLine & "Partition As boot")
            Case "--custom--"
                Refrence = InputBox("Enter Partition Name", "Input")
                TextBox1.AppendText(Environment.NewLine & "Custom Partition As " & Refrence)
            Case Else
                Refrence = MetroComboBox1.SelectedItem
                TextBox1.AppendText(Environment.NewLine & "Partition As " & Refrence)
        End Select
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Me.Opacity = Me.Opacity + 0.1
        If Me.Opacity >= 1.0 Then
            Me.Opacity = 1
            Timer3.Stop()
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Me.Opacity = Me.Opacity - 0.1
        If Me.Opacity < 0.1 Then
            Timer4.Stop()
            End
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Timer4.Start()
    End Sub

    Private Sub MaterialRadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialRadioButton9.CheckedChanged
        If MaterialRadioButton9.Checked = True Then
            MetroComboBox2.Visible = True
            MetroComboBox2.Text = "Complete Backup"
        Else
            MetroComboBox2.Visible = False
        End If
    End Sub

    Private Sub MetroComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox3.SelectedIndexChanged
        Select Case MetroComboBox3.Text
            Case "Complete Backup"
                Switch = "-all"
            Case "System Only"
                Switch = "-system"
            Case "Data Only"
                Switch = "-app"
            Case "Internal Storage Only"
                Switch = "-shared"
            Case Else
                TextBox1.AppendText("No method generated for this class!")
        End Select
    End Sub

    Private Sub MaterialRadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles MaterialRadioButton8.CheckedChanged
        If MaterialRadioButton8.Checked = True Then
            Info1.Close()
            Info1.Show()
            MetroComboBox3.Visible = True
            MetroComboBox3.Text = "Complete Backup"
        Else
            MetroComboBox3.Visible = False
        End If
    End Sub
    Public Switch As String
    Private Sub MaterialRaisedButton8_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton8.Click
        If MaterialRadioButton8.Checked = True Then
            SaveFileDialog1.Filter = "Bak Files|*.ab"
            SaveFileDialog1.FileName = ""
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                passon = """" + SaveFileDialog1.FileName + """"
                MsgBox("backup " + Switch + " -f " + passon)
                Dim p As New Process
                p.StartInfo.FileName = "adb"
                p.StartInfo.Arguments = "backup " + Switch + " -f " + SaveFileDialog1.FileName
                p.StartInfo.RedirectStandardError = True
                p.StartInfo.RedirectStandardOutput = True
                p.StartInfo.UseShellExecute = False
                p.StartInfo.CreateNoWindow = True
                p.EnableRaisingEvents = True
                Application.DoEvents()
                AddHandler p.ErrorDataReceived, AddressOf proc_OutputDataReceived
                AddHandler p.OutputDataReceived, AddressOf proc_OutputDataReceived
                p.Start()
                p.BeginErrorReadLine()
                p.BeginOutputReadLine()
                Do Until p.HasExited()
                    Delay(2)
                Loop
                TextBox1.AppendText(Environment.NewLine & "Done..")
            End If
        End If
    End Sub
End Class
