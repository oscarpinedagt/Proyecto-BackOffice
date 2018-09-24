<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cambiar_contraseña
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cambiar_contraseña))
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        Me.SB_Cambiar_contraseña = New DevExpress.XtraEditors.SimpleButton()
        Me.TE_Nueva_contraseña = New DevExpress.XtraEditors.TextEdit()
        Me.TE_Contraseña_actual = New DevExpress.XtraEditors.TextEdit()
        Me.TE_Usuario = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Nueva_contraseña = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Contraseña_actual = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Usuario = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Nueva_contraseña.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Contraseña_actual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Usuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEdit
        '
        Me.PictureEdit.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureEdit.EditValue = CType(resources.GetObject("PictureEdit.EditValue"), Object)
        Me.PictureEdit.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit.Name = "PictureEdit"
        Me.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEdit.Size = New System.Drawing.Size(368, 66)
        Me.PictureEdit.TabIndex = 0
        '
        'SB_Cambiar_contraseña
        '
        Me.SB_Cambiar_contraseña.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SB_Cambiar_contraseña.Location = New System.Drawing.Point(231, 231)
        Me.SB_Cambiar_contraseña.Name = "SB_Cambiar_contraseña"
        Me.SB_Cambiar_contraseña.Size = New System.Drawing.Size(125, 25)
        Me.SB_Cambiar_contraseña.TabIndex = 7
        Me.SB_Cambiar_contraseña.Text = "Cambiar contraseña"
        '
        'TE_Nueva_contraseña
        '
        Me.TE_Nueva_contraseña.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TE_Nueva_contraseña.Location = New System.Drawing.Point(12, 190)
        Me.TE_Nueva_contraseña.Name = "TE_Nueva_contraseña"
        Me.TE_Nueva_contraseña.Properties.UseSystemPasswordChar = True
        Me.TE_Nueva_contraseña.Size = New System.Drawing.Size(344, 20)
        Me.TE_Nueva_contraseña.TabIndex = 6
        '
        'TE_Contraseña_actual
        '
        Me.TE_Contraseña_actual.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TE_Contraseña_actual.Location = New System.Drawing.Point(12, 145)
        Me.TE_Contraseña_actual.Name = "TE_Contraseña_actual"
        Me.TE_Contraseña_actual.Properties.UseSystemPasswordChar = True
        Me.TE_Contraseña_actual.Size = New System.Drawing.Size(344, 20)
        Me.TE_Contraseña_actual.TabIndex = 4
        '
        'TE_Usuario
        '
        Me.TE_Usuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TE_Usuario.Location = New System.Drawing.Point(12, 100)
        Me.TE_Usuario.Name = "TE_Usuario"
        Me.TE_Usuario.Size = New System.Drawing.Size(344, 20)
        Me.TE_Usuario.TabIndex = 2
        '
        'LC_Nueva_contraseña
        '
        Me.LC_Nueva_contraseña.Location = New System.Drawing.Point(12, 171)
        Me.LC_Nueva_contraseña.Name = "LC_Nueva_contraseña"
        Me.LC_Nueva_contraseña.Size = New System.Drawing.Size(88, 13)
        Me.LC_Nueva_contraseña.TabIndex = 5
        Me.LC_Nueva_contraseña.Text = "Nueva contraseña"
        '
        'LC_Contraseña_actual
        '
        Me.LC_Contraseña_actual.Location = New System.Drawing.Point(12, 126)
        Me.LC_Contraseña_actual.Name = "LC_Contraseña_actual"
        Me.LC_Contraseña_actual.Size = New System.Drawing.Size(88, 13)
        Me.LC_Contraseña_actual.TabIndex = 3
        Me.LC_Contraseña_actual.Text = "Contraseña actual"
        '
        'LC_Usuario
        '
        Me.LC_Usuario.Location = New System.Drawing.Point(12, 81)
        Me.LC_Usuario.Name = "LC_Usuario"
        Me.LC_Usuario.Size = New System.Drawing.Size(36, 13)
        Me.LC_Usuario.TabIndex = 1
        Me.LC_Usuario.Text = "Usuario"
        '
        'Cambiar_contraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 268)
        Me.Controls.Add(Me.SB_Cambiar_contraseña)
        Me.Controls.Add(Me.TE_Nueva_contraseña)
        Me.Controls.Add(Me.TE_Contraseña_actual)
        Me.Controls.Add(Me.TE_Usuario)
        Me.Controls.Add(Me.LC_Nueva_contraseña)
        Me.Controls.Add(Me.LC_Contraseña_actual)
        Me.Controls.Add(Me.LC_Usuario)
        Me.Controls.Add(Me.PictureEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cambiar_contraseña"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar contraseña"
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Nueva_contraseña.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Contraseña_actual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Usuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents SB_Cambiar_contraseña As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TE_Nueva_contraseña As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Contraseña_actual As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Usuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LC_Nueva_contraseña As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Contraseña_actual As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Usuario As DevExpress.XtraEditors.LabelControl
End Class
