<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comentario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comentario))
        Me.LC_Descripción_para_comentario = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Sub_Empresa = New DevExpress.XtraEditors.LabelControl()
        Me.LUE_Tipo_de_comentario = New DevExpress.XtraEditors.LookUpEdit()
        Me.SB_Guardar_comentario = New DevExpress.XtraEditors.SimpleButton()
        Me.RTBX_Comentario = New System.Windows.Forms.RichTextBox()
        Me.DxErrorProvider = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.LUE_Tipo_de_comentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LC_Descripción_para_comentario
        '
        Me.LC_Descripción_para_comentario.Appearance.Options.UseTextOptions = True
        Me.LC_Descripción_para_comentario.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LC_Descripción_para_comentario.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LC_Descripción_para_comentario.Dock = System.Windows.Forms.DockStyle.Top
        Me.LC_Descripción_para_comentario.LineVisible = True
        Me.LC_Descripción_para_comentario.Location = New System.Drawing.Point(0, 0)
        Me.LC_Descripción_para_comentario.Name = "LC_Descripción_para_comentario"
        Me.LC_Descripción_para_comentario.Size = New System.Drawing.Size(498, 26)
        Me.LC_Descripción_para_comentario.TabIndex = 0
        Me.LC_Descripción_para_comentario.Text = "Tu comentario debe ser objetivo y especifico y tiene que estar relacionado a refe" &
    "rencias verídicas Ejemplo: números de ticket, correos electrónicos o documentos " &
    "físicos"
        '
        'LC_Sub_Empresa
        '
        Me.LC_Sub_Empresa.Location = New System.Drawing.Point(12, 35)
        Me.LC_Sub_Empresa.Name = "LC_Sub_Empresa"
        Me.LC_Sub_Empresa.Size = New System.Drawing.Size(91, 13)
        Me.LC_Sub_Empresa.TabIndex = 1
        Me.LC_Sub_Empresa.Text = "Tipo de comentario"
        '
        'LUE_Tipo_de_comentario
        '
        Me.LUE_Tipo_de_comentario.Location = New System.Drawing.Point(109, 32)
        Me.LUE_Tipo_de_comentario.Name = "LUE_Tipo_de_comentario"
        Me.LUE_Tipo_de_comentario.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Tipo_de_comentario.Properties.NullText = ""
        Me.LUE_Tipo_de_comentario.Properties.NullValuePrompt = "Tipo de comentario"
        Me.LUE_Tipo_de_comentario.Properties.NullValuePromptShowForEmptyValue = True
        Me.LUE_Tipo_de_comentario.Properties.ShowNullValuePromptWhenFocused = True
        Me.LUE_Tipo_de_comentario.Size = New System.Drawing.Size(247, 20)
        Me.LUE_Tipo_de_comentario.TabIndex = 2
        '
        'SB_Guardar_comentario
        '
        Me.SB_Guardar_comentario.Location = New System.Drawing.Point(363, 32)
        Me.SB_Guardar_comentario.Name = "SB_Guardar_comentario"
        Me.SB_Guardar_comentario.Size = New System.Drawing.Size(123, 20)
        Me.SB_Guardar_comentario.TabIndex = 3
        Me.SB_Guardar_comentario.Text = "Guardar comentario"
        '
        'RTBX_Comentario
        '
        Me.RTBX_Comentario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTBX_Comentario.BackColor = System.Drawing.SystemColors.Window
        Me.RTBX_Comentario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RTBX_Comentario.Location = New System.Drawing.Point(9, 58)
        Me.RTBX_Comentario.Margin = New System.Windows.Forms.Padding(0)
        Me.RTBX_Comentario.Name = "RTBX_Comentario"
        Me.RTBX_Comentario.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RTBX_Comentario.Size = New System.Drawing.Size(489, 251)
        Me.RTBX_Comentario.TabIndex = 4
        Me.RTBX_Comentario.Text = ""
        '
        'DxErrorProvider
        '
        Me.DxErrorProvider.ContainerControl = Me
        '
        'Comentario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 318)
        Me.Controls.Add(Me.RTBX_Comentario)
        Me.Controls.Add(Me.SB_Guardar_comentario)
        Me.Controls.Add(Me.LUE_Tipo_de_comentario)
        Me.Controls.Add(Me.LC_Sub_Empresa)
        Me.Controls.Add(Me.LC_Descripción_para_comentario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Comentario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comentario"
        CType(Me.LUE_Tipo_de_comentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LC_Descripción_para_comentario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Sub_Empresa As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LUE_Tipo_de_comentario As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SB_Guardar_comentario As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RTBX_Comentario As RichTextBox
    Friend WithEvents DxErrorProvider As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
End Class
