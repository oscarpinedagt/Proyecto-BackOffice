﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Información_de_archivos))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.CK_Activar_monitoreo_de_archivos = New DevExpress.XtraEditors.CheckEdit()
        Me.LC_Directorio_a_validar = New DevExpress.XtraEditors.LabelControl()
        Me.BE_Directorio = New DevExpress.XtraEditors.ButtonEdit()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.CK_Activar_monitoreo_de_archivos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BE_Directorio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BE_Directorio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        'PanelControl1
        '
        Me.PanelControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl1.Controls.Add(Me.GridControl)
        Me.PanelControl1.Location = New System.Drawing.Point(12, 100)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(609, 276)
        Me.PanelControl1.TabIndex = 12
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.Location = New System.Drawing.Point(2, 2)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(605, 272)
        Me.GridControl.TabIndex = 0
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'Información_de_archivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 388)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.CK_Activar_monitoreo_de_archivos)
        Me.Controls.Add(Me.LC_Directorio_a_validar)
        Me.Controls.Add(Me.BE_Directorio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Información_de_archivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información de archivos"
        CType(Me.CK_Activar_monitoreo_de_archivos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BE_Directorio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CK_Activar_monitoreo_de_archivos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LC_Directorio_a_validar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BE_Directorio As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
