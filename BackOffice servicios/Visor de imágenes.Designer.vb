<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Visor_de_imágenes
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Visor_de_imágenes))
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureEdit
        '
        Me.PictureEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit.Name = "PictureEdit"
        Me.PictureEdit.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.[True]
        Me.PictureEdit.Properties.AllowScrollViaMouseDrag = True
        Me.PictureEdit.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.[True]
        Me.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit.Properties.ShowScrollBars = True
        Me.PictureEdit.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.[True]
        Me.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.PictureEdit.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel
        Me.PictureEdit.Size = New System.Drawing.Size(798, 568)
        Me.PictureEdit.TabIndex = 0
        '
        'Visor_de_imágenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 568)
        Me.Controls.Add(Me.PictureEdit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Visor_de_imágenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visor de imágenes"
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
End Class
