<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inicio_de_sesión
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inicio_de_sesión))
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        Me.HL_Cambiar_contraseña = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.HL_Registrar_usuario = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.CK_Recordar_usuario = New DevExpress.XtraEditors.CheckEdit()
        Me.SB_Ingresar = New DevExpress.XtraEditors.SimpleButton()
        Me.TE_Contraseña = New DevExpress.XtraEditors.TextEdit()
        Me.TE_Usuario = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Contraseña = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Usuario = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CK_Recordar_usuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Contraseña.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'HL_Cambiar_contraseña
        '
        Me.HL_Cambiar_contraseña.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HL_Cambiar_contraseña.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HL_Cambiar_contraseña.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.HL_Cambiar_contraseña.Location = New System.Drawing.Point(260, 126)
        Me.HL_Cambiar_contraseña.Name = "HL_Cambiar_contraseña"
        Me.HL_Cambiar_contraseña.Size = New System.Drawing.Size(96, 13)
        Me.HL_Cambiar_contraseña.TabIndex = 5
        Me.HL_Cambiar_contraseña.Text = "Cambiar contraseña"
        '
        'HL_Registrar_usuario
        '
        Me.HL_Registrar_usuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HL_Registrar_usuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HL_Registrar_usuario.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.HL_Registrar_usuario.Location = New System.Drawing.Point(12, 206)
        Me.HL_Registrar_usuario.Name = "HL_Registrar_usuario"
        Me.HL_Registrar_usuario.Size = New System.Drawing.Size(82, 13)
        Me.HL_Registrar_usuario.TabIndex = 7
        Me.HL_Registrar_usuario.Text = "Registrar usuario"
        '
        'CK_Recordar_usuario
        '
        Me.CK_Recordar_usuario.Location = New System.Drawing.Point(12, 172)
        Me.CK_Recordar_usuario.Name = "CK_Recordar_usuario"
        Me.CK_Recordar_usuario.Properties.Caption = "Recordar usuario"
        Me.CK_Recordar_usuario.Size = New System.Drawing.Size(111, 19)
        Me.CK_Recordar_usuario.TabIndex = 6
        '
        'SB_Ingresar
        '
        Me.SB_Ingresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SB_Ingresar.Location = New System.Drawing.Point(256, 202)
        Me.SB_Ingresar.Name = "SB_Ingresar"
        Me.SB_Ingresar.Size = New System.Drawing.Size(100, 25)
        Me.SB_Ingresar.TabIndex = 8
        Me.SB_Ingresar.Text = "Ingresar"
        '
        'TE_Contraseña
        '
        Me.TE_Contraseña.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TE_Contraseña.Location = New System.Drawing.Point(12, 145)
        Me.TE_Contraseña.Name = "TE_Contraseña"
        Me.TE_Contraseña.Properties.UseSystemPasswordChar = True
        Me.TE_Contraseña.Size = New System.Drawing.Size(344, 20)
        Me.TE_Contraseña.TabIndex = 4
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
        'LC_Contraseña
        '
        Me.LC_Contraseña.Location = New System.Drawing.Point(12, 126)
        Me.LC_Contraseña.Name = "LC_Contraseña"
        Me.LC_Contraseña.Size = New System.Drawing.Size(56, 13)
        Me.LC_Contraseña.TabIndex = 3
        Me.LC_Contraseña.Text = "Contraseña"
        '
        'LC_Usuario
        '
        Me.LC_Usuario.Location = New System.Drawing.Point(12, 81)
        Me.LC_Usuario.Name = "LC_Usuario"
        Me.LC_Usuario.Size = New System.Drawing.Size(36, 13)
        Me.LC_Usuario.TabIndex = 1
        Me.LC_Usuario.Text = "Usuario"
        '
        'Inicio_de_sesión
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 239)
        Me.Controls.Add(Me.HL_Cambiar_contraseña)
        Me.Controls.Add(Me.HL_Registrar_usuario)
        Me.Controls.Add(Me.CK_Recordar_usuario)
        Me.Controls.Add(Me.SB_Ingresar)
        Me.Controls.Add(Me.TE_Contraseña)
        Me.Controls.Add(Me.TE_Usuario)
        Me.Controls.Add(Me.LC_Contraseña)
        Me.Controls.Add(Me.LC_Usuario)
        Me.Controls.Add(Me.PictureEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inicio_de_sesión"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de sesión"
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CK_Recordar_usuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Contraseña.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Usuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents HL_Cambiar_contraseña As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents HL_Registrar_usuario As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents CK_Recordar_usuario As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SB_Ingresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TE_Contraseña As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Usuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LC_Contraseña As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Usuario As DevExpress.XtraEditors.LabelControl
End Class
