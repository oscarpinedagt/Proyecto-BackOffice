<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Presentación
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Presentación))
        Me.PE_Imágen = New DevExpress.XtraEditors.PictureEdit()
        Me.LC_Información = New DevExpress.XtraEditors.LabelControl()
        Me.MPBC_Presentación = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.TMR_Presentación = New System.Windows.Forms.Timer(Me.components)
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.PE_Imágen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MPBC_Presentación.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PE_Imágen
        '
        Me.PE_Imágen.Cursor = System.Windows.Forms.Cursors.Default
        Me.PE_Imágen.EditValue = CType(resources.GetObject("PE_Imágen.EditValue"), Object)
        Me.PE_Imágen.Location = New System.Drawing.Point(12, 12)
        Me.PE_Imágen.Name = "PE_Imágen"
        Me.PE_Imágen.Properties.AllowFocused = False
        Me.PE_Imágen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PE_Imágen.Properties.Appearance.Options.UseBackColor = True
        Me.PE_Imágen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PE_Imágen.Properties.ShowMenu = False
        Me.PE_Imágen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PE_Imágen.Size = New System.Drawing.Size(426, 180)
        Me.PE_Imágen.TabIndex = 0
        '
        'LC_Información
        '
        Me.LC_Información.Appearance.Options.UseTextOptions = True
        Me.LC_Información.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LC_Información.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LC_Información.Location = New System.Drawing.Point(12, 198)
        Me.LC_Información.Name = "LC_Información"
        Me.LC_Información.Size = New System.Drawing.Size(426, 13)
        Me.LC_Información.TabIndex = 2
        Me.LC_Información.Text = "Iniciando..."
        '
        'MPBC_Presentación
        '
        Me.MPBC_Presentación.EditValue = 0
        Me.MPBC_Presentación.Location = New System.Drawing.Point(12, 180)
        Me.MPBC_Presentación.Name = "MPBC_Presentación"
        Me.MPBC_Presentación.Size = New System.Drawing.Size(426, 12)
        Me.MPBC_Presentación.TabIndex = 1
        '
        'TMR_Presentación
        '
        Me.TMR_Presentación.Interval = 5000
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'Presentación
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 232)
        Me.Controls.Add(Me.LC_Información)
        Me.Controls.Add(Me.MPBC_Presentación)
        Me.Controls.Add(Me.PE_Imágen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Presentación"
        Me.Text = "Presentación"
        CType(Me.PE_Imágen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MPBC_Presentación.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents PE_Imágen As DevExpress.XtraEditors.PictureEdit
    Private WithEvents LC_Información As DevExpress.XtraEditors.LabelControl
    Private WithEvents MPBC_Presentación As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents TMR_Presentación As Timer
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
End Class
