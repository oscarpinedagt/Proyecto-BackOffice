<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Publicar
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Publicar))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.BE_Directorio = New DevExpress.XtraEditors.ButtonEdit()
        Me.SB_Publicar = New DevExpress.XtraEditors.SimpleButton()
        Me.LC_Publicar_aplicación = New DevExpress.XtraEditors.LabelControl()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.CK_Recordar_directorio = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.BE_Directorio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CK_Recordar_directorio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BE_Directorio
        '
        Me.BE_Directorio.Location = New System.Drawing.Point(11, 41)
        Me.BE_Directorio.Name = "BE_Directorio"
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        SerializableAppearanceObject1.Options.UseImage = True
        Me.BE_Directorio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.BE_Directorio.Size = New System.Drawing.Size(609, 22)
        Me.BE_Directorio.TabIndex = 0
        '
        'SB_Publicar
        '
        Me.SB_Publicar.Location = New System.Drawing.Point(500, 67)
        Me.SB_Publicar.Name = "SB_Publicar"
        Me.SB_Publicar.Size = New System.Drawing.Size(120, 23)
        Me.SB_Publicar.TabIndex = 1
        Me.SB_Publicar.Text = "Publicar"
        '
        'LC_Publicar_aplicación
        '
        Me.LC_Publicar_aplicación.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.LC_Publicar_aplicación.Appearance.Options.UseFont = True
        Me.LC_Publicar_aplicación.Location = New System.Drawing.Point(12, 12)
        Me.LC_Publicar_aplicación.Name = "LC_Publicar_aplicación"
        Me.LC_Publicar_aplicación.Size = New System.Drawing.Size(154, 23)
        Me.LC_Publicar_aplicación.TabIndex = 2
        Me.LC_Publicar_aplicación.Text = "Publicar aplicación"
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'CK_Recordar_directorio
        '
        Me.CK_Recordar_directorio.Location = New System.Drawing.Point(11, 71)
        Me.CK_Recordar_directorio.Name = "CK_Recordar_directorio"
        Me.CK_Recordar_directorio.Properties.Caption = "Recordar directorio"
        Me.CK_Recordar_directorio.Size = New System.Drawing.Size(120, 19)
        Me.CK_Recordar_directorio.TabIndex = 7
        '
        'Publicar
        '
        Me.AcceptButton = Me.SB_Publicar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 109)
        Me.Controls.Add(Me.CK_Recordar_directorio)
        Me.Controls.Add(Me.LC_Publicar_aplicación)
        Me.Controls.Add(Me.SB_Publicar)
        Me.Controls.Add(Me.BE_Directorio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Publicar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Publicar"
        CType(Me.BE_Directorio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CK_Recordar_directorio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BE_Directorio As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents SB_Publicar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LC_Publicar_aplicación As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents CK_Recordar_directorio As DevExpress.XtraEditors.CheckEdit
End Class
