<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Información_de_archivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Información_de_archivos))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.CK_Activar_monitoreo_de_archivos = New DevExpress.XtraEditors.CheckEdit()
        Me.LC_Directorio_a_validar = New DevExpress.XtraEditors.LabelControl()
        Me.BE_Directorio = New DevExpress.XtraEditors.ButtonEdit()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        CType(Me.CK_Activar_monitoreo_de_archivos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BE_Directorio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CK_Activar_monitoreo_de_archivos
        '
        Me.CK_Activar_monitoreo_de_archivos.Location = New System.Drawing.Point(12, 74)
        Me.CK_Activar_monitoreo_de_archivos.Name = "CK_Activar_monitoreo_de_archivos"
        Me.CK_Activar_monitoreo_de_archivos.Properties.Caption = "Activar monitoreo de archivos"
        Me.CK_Activar_monitoreo_de_archivos.Size = New System.Drawing.Size(181, 19)
        Me.CK_Activar_monitoreo_de_archivos.TabIndex = 11
        '
        'LC_Directorio_a_validar
        '
        Me.LC_Directorio_a_validar.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.LC_Directorio_a_validar.Appearance.Options.UseFont = True
        Me.LC_Directorio_a_validar.Location = New System.Drawing.Point(13, 15)
        Me.LC_Directorio_a_validar.Name = "LC_Directorio_a_validar"
        Me.LC_Directorio_a_validar.Size = New System.Drawing.Size(157, 23)
        Me.LC_Directorio_a_validar.TabIndex = 10
        Me.LC_Directorio_a_validar.Text = "Directorio a validar"
        '
        'BE_Directorio
        '
        Me.BE_Directorio.Location = New System.Drawing.Point(12, 44)
        Me.BE_Directorio.Name = "BE_Directorio"
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        SerializableAppearanceObject1.Options.UseImage = True
        Me.BE_Directorio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.BE_Directorio.Size = New System.Drawing.Size(609, 22)
        Me.BE_Directorio.TabIndex = 8
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'Información_de_archivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 109)
        Me.Controls.Add(Me.CK_Activar_monitoreo_de_archivos)
        Me.Controls.Add(Me.LC_Directorio_a_validar)
        Me.Controls.Add(Me.BE_Directorio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Información_de_archivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información de archivos"
        CType(Me.CK_Activar_monitoreo_de_archivos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BE_Directorio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CK_Activar_monitoreo_de_archivos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LC_Directorio_a_validar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BE_Directorio As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
