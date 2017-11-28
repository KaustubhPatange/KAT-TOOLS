<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialRaisedButton2 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.MaterialCheckBox1 = New MaterialSkin.Controls.MaterialCheckBox()
        Me.MaterialCheckBox2 = New MaterialSkin.Controls.MaterialCheckBox()
        Me.MaterialCheckBox3 = New MaterialSkin.Controls.MaterialCheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 37)
        Me.Panel1.TabIndex = 0
        '
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.AutoSize = True
        Me.MaterialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MaterialRaisedButton1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Icon = Nothing
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(166, 137)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(75, 36)
        Me.MaterialRaisedButton1.TabIndex = 1
        Me.MaterialRaisedButton1.Text = "Install"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = False
        '
        'MaterialRaisedButton2
        '
        Me.MaterialRaisedButton2.AutoSize = True
        Me.MaterialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MaterialRaisedButton2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.MaterialRaisedButton2.Depth = 0
        Me.MaterialRaisedButton2.Icon = Nothing
        Me.MaterialRaisedButton2.Location = New System.Drawing.Point(9, 137)
        Me.MaterialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton2.Name = "MaterialRaisedButton2"
        Me.MaterialRaisedButton2.Primary = True
        Me.MaterialRaisedButton2.Size = New System.Drawing.Size(73, 36)
        Me.MaterialRaisedButton2.TabIndex = 2
        Me.MaterialRaisedButton2.Text = "Cancel"
        Me.MaterialRaisedButton2.UseVisualStyleBackColor = False
        '
        'MaterialCheckBox1
        '
        Me.MaterialCheckBox1.AutoSize = True
        Me.MaterialCheckBox1.Depth = 0
        Me.MaterialCheckBox1.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.MaterialCheckBox1.Location = New System.Drawing.Point(9, 40)
        Me.MaterialCheckBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.MaterialCheckBox1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.MaterialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCheckBox1.Name = "MaterialCheckBox1"
        Me.MaterialCheckBox1.Ripple = True
        Me.MaterialCheckBox1.Size = New System.Drawing.Size(150, 30)
        Me.MaterialCheckBox1.TabIndex = 3
        Me.MaterialCheckBox1.Text = "Google USB Drivers"
        Me.MaterialCheckBox1.UseVisualStyleBackColor = True
        '
        'MaterialCheckBox2
        '
        Me.MaterialCheckBox2.AutoSize = True
        Me.MaterialCheckBox2.Depth = 0
        Me.MaterialCheckBox2.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.MaterialCheckBox2.Location = New System.Drawing.Point(9, 70)
        Me.MaterialCheckBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.MaterialCheckBox2.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.MaterialCheckBox2.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCheckBox2.Name = "MaterialCheckBox2"
        Me.MaterialCheckBox2.Ripple = True
        Me.MaterialCheckBox2.Size = New System.Drawing.Size(122, 30)
        Me.MaterialCheckBox2.TabIndex = 4
        Me.MaterialCheckBox2.Text = "PdaNet Drivers"
        Me.MaterialCheckBox2.UseVisualStyleBackColor = True
        '
        'MaterialCheckBox3
        '
        Me.MaterialCheckBox3.AutoSize = True
        Me.MaterialCheckBox3.Depth = 0
        Me.MaterialCheckBox3.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.MaterialCheckBox3.Location = New System.Drawing.Point(9, 100)
        Me.MaterialCheckBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.MaterialCheckBox3.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.MaterialCheckBox3.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialCheckBox3.Name = "MaterialCheckBox3"
        Me.MaterialCheckBox3.Ripple = True
        Me.MaterialCheckBox3.Size = New System.Drawing.Size(157, 30)
        Me.MaterialCheckBox3.TabIndex = 5
        Me.MaterialCheckBox3.Text = "Coolpad USB Drivers"
        Me.MaterialCheckBox3.UseVisualStyleBackColor = True
        Me.MaterialCheckBox3.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 40
        '
        'Timer2
        '
        Me.Timer2.Interval = 30
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(253, 182)
        Me.Controls.Add(Me.MaterialCheckBox3)
        Me.Controls.Add(Me.MaterialCheckBox2)
        Me.Controls.Add(Me.MaterialCheckBox1)
        Me.Controls.Add(Me.MaterialRaisedButton2)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form2"
        Me.Opacity = 0.01R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialRaisedButton2 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents MaterialCheckBox1 As MaterialSkin.Controls.MaterialCheckBox
    Friend WithEvents MaterialCheckBox2 As MaterialSkin.Controls.MaterialCheckBox
    Friend WithEvents MaterialCheckBox3 As MaterialSkin.Controls.MaterialCheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
End Class
