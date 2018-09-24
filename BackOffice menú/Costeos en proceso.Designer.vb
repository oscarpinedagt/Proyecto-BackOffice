<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Costeos_en_proceso
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Costeos_en_proceso))
        Me.RTBX_Costeos_en_proceso = New System.Windows.Forms.RichTextBox()
        Me.TMR_Cerrar_notificación = New System.Windows.Forms.Timer()
        Me.SuspendLayout()
        '
        'RTBX_Costeos_en_proceso
        '
        Me.RTBX_Costeos_en_proceso.BackColor = System.Drawing.SystemColors.Window
        Me.RTBX_Costeos_en_proceso.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RTBX_Costeos_en_proceso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RTBX_Costeos_en_proceso.Location = New System.Drawing.Point(15, 0)
        Me.RTBX_Costeos_en_proceso.Name = "RTBX_Costeos_en_proceso"
        Me.RTBX_Costeos_en_proceso.ReadOnly = True
        Me.RTBX_Costeos_en_proceso.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RTBX_Costeos_en_proceso.Size = New System.Drawing.Size(693, 513)
        Me.RTBX_Costeos_en_proceso.TabIndex = 0
        Me.RTBX_Costeos_en_proceso.Text = ""
        '
        'TMR_Cerrar_notificación
        '
        Me.TMR_Cerrar_notificación.Enabled = True
        Me.TMR_Cerrar_notificación.Interval = 1500000
        '
        'Costeos_en_proceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 528)
        Me.Controls.Add(Me.RTBX_Costeos_en_proceso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Costeos_en_proceso"
        Me.Padding = New System.Windows.Forms.Padding(15, 0, 0, 15)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costeos en proceso de elaboración y envió"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RTBX_Costeos_en_proceso As RichTextBox
    Friend WithEvents TMR_Cerrar_notificación As Timer
End Class
