<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contraseña
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contraseña))
        Me.SB_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.TE_Contraseña = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TE_Contraseña.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SB_Aceptar
        '
        Me.SB_Aceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SB_Aceptar.Location = New System.Drawing.Point(261, 41)
        Me.SB_Aceptar.Name = "SB_Aceptar"
        Me.SB_Aceptar.Size = New System.Drawing.Size(100, 25)
        Me.SB_Aceptar.TabIndex = 1
        Me.SB_Aceptar.Text = "Aceptar"
        '
        'TE_Contraseña
        '
        Me.TE_Contraseña.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TE_Contraseña.Location = New System.Drawing.Point(12, 12)
        Me.TE_Contraseña.Name = "TE_Contraseña"
        Me.TE_Contraseña.Properties.UseSystemPasswordChar = True
        Me.TE_Contraseña.Size = New System.Drawing.Size(349, 20)
        Me.TE_Contraseña.TabIndex = 0
        '
        'Contraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 78)
        Me.Controls.Add(Me.SB_Aceptar)
        Me.Controls.Add(Me.TE_Contraseña)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Contraseña"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contraseña"
        CType(Me.TE_Contraseña.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SB_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TE_Contraseña As DevExpress.XtraEditors.TextEdit
End Class
