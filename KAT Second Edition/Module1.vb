Imports RegawMOD
Imports RegawMOD.Android
Module AdbDevice
    Dim android As AndroidController
    Dim device As Device
    Public Sub Adb_getValues()
        Dim serial, serial2 As String
        'Form1.label4.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.manufacturer"))
        'Form1.Label6.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.product.device"))
        'Form1.Label8.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.build.version.release"))
        ' Form1.Label10.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.board.platform"))
        ' Form1.Label12.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.secure"))
        ' Form1.Label14.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.crypto.state"))
        ' Form1.Label16.Text = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("shell getprop ro.bootloader"))
        Adb.ExecuteAdbCommandNoReturn(Adb.FormAdbCommand("pull /system/xbin/su"))
        serial2 = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("get-state"))
        If serial2 = "device" Then
            Form1.PictureBox1.BackColor = Color.Lime
            Form1.Label1.Text = "Device Found in Android ! Now Start Applying Stuff"
        ElseIf serial2 = "recovery" Then
            Form1.PictureBox1.BackColor = Color.Orange
            Form1.Label1.Text = "Device Found in Recovery Mode ! Do your Stuff now"
        ElseIf serial2 = "sideload" Then
            Form1.PictureBox1.BackColor = Color.GreenYellow
            Form1.Label1.Text = "Device Found in Sideload Mode ! Ready to Flash zips"
        ElseIf serial2 = "offline" Then
            Form1.PictureBox1.BackColor = Color.Red
            Form1.Label1.Text = "Device seems to Offline, try reinstalling drivers or changing usb cables"
        ElseIf serial2 = "unauthorized" Then
            Form1.PictureBox1.BackColor = Color.Red
            Form1.Label1.Text = "Device Not Authorized ! Look in your Phone and Accept the confirmation"
        End If
        If My.Computer.FileSystem.FileExists("su") Then
            IO.File.Delete("su")
            Form1.Label18.Text = "True"
        Else
            Form1.Label18.Text = "False"
        End If
    End Sub
    Public Sub Device_error()
        Dim serial3 As String
        Dim start_info As New ProcessStartInfo("dd.exe")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        Dim proc As New Process()
        proc.StartInfo = start_info
        '  proc.Start()
        If My.Computer.FileSystem.FileExists("temp.h") Then
            serial3 = Adb.ExecuteAdbCommand(Adb.FormAdbCommand("devices"))
            Form1.PictureBox1.BackColor = Color.Blue
            Form1.Label1.Text = "Device Found in Fastboot ! Ready to Flash Images"
            IO.File.Delete("temp.h")
        Else
            Form1.label4.Text = "---"
            Form1.Label6.Text = "---"
            Form1.Label8.Text = "---"
            Form1.Label10.Text = "---"
            Form1.Label12.Text = "---"
            Form1.Label14.Text = "---"
            Form1.Label16.Text = "---"
            Form1.Label18.Text = "---"
            Form1.Label1.Text = "Device Not Reliable or not Connected ! Waiting to Auto detect"
            Form1.PictureBox1.BackColor = Color.Red
        End If

    End Sub
End Module
