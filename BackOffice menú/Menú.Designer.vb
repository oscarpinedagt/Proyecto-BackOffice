<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menú
    Inherits DevExpress.XtraWaitForm.WaitForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menú))
        Me.progressPanel = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.CMS_BackOffice_menú = New System.Windows.Forms.ContextMenuStrip()
        Me.MI_Costos_e_Importaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.MI_Configuración = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MI_Información_de_archivos = New System.Windows.Forms.ToolStripMenuItem()
        Me.MI_Salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.NTI_BackOffice_menú = New System.Windows.Forms.NotifyIcon()
        Me.TMR_BackOffice_menú = New System.Windows.Forms.Timer()
        Me.TRM_Costeos_en_proceso = New System.Windows.Forms.Timer()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.CMS_BackOffice_menú.SuspendLayout()
        Me.SuspendLayout()
        '
        'progressPanel
        '
        Me.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.progressPanel.Appearance.Options.UseBackColor = True
        Me.progressPanel.AppearanceCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.progressPanel.AppearanceCaption.Options.UseFont = True
        Me.progressPanel.AppearanceDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.progressPanel.AppearanceDescription.Options.UseFont = True
        Me.progressPanel.BarAnimationElementThickness = 2
        Me.progressPanel.Caption = "Por favor espere"
        Me.progressPanel.Description = "Cargando menú..."
        Me.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.progressPanel.ImageHorzOffset = 20
        Me.progressPanel.Location = New System.Drawing.Point(0, 17)
        Me.progressPanel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.progressPanel.Name = "progressPanel"
        Me.progressPanel.Size = New System.Drawing.Size(246, 39)
        Me.progressPanel.TabIndex = 0
        Me.progressPanel.Text = "progressPanel1"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.AutoSize = True
        Me.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.progressPanel, 0, 0)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 14, 0, 14)
        Me.tableLayoutPanel1.RowCount = 1
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(246, 73)
        Me.tableLayoutPanel1.TabIndex = 1
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'CMS_BackOffice_menú
        '
        Me.CMS_BackOffice_menú.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.CMS_BackOffice_menú.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.CMS_BackOffice_menú.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MI_Costos_e_Importaciones, Me.MI_Configuración, Me.TSS_1, Me.MI_Información_de_archivos, Me.MI_Salir})
        Me.CMS_BackOffice_menú.Name = "CMS_BackOffice"
        Me.CMS_BackOffice_menú.Size = New System.Drawing.Size(192, 106)
        Me.CMS_BackOffice_menú.Text = "BackOffice"
        '
        'MI_Costos_e_Importaciones
        '
        Me.MI_Costos_e_Importaciones.Image = CType(resources.GetObject("MI_Costos_e_Importaciones.Image"), System.Drawing.Image)
        Me.MI_Costos_e_Importaciones.Name = "MI_Costos_e_Importaciones"
        Me.MI_Costos_e_Importaciones.Size = New System.Drawing.Size(191, 24)
        Me.MI_Costos_e_Importaciones.Text = "Costos e Importaciones"
        '
        'MI_Configuración
        '
        Me.MI_Configuración.Image = CType(resources.GetObject("MI_Configuración.Image"), System.Drawing.Image)
        Me.MI_Configuración.Name = "MI_Configuración"
        Me.MI_Configuración.Size = New System.Drawing.Size(191, 24)
        Me.MI_Configuración.Text = "Configuración"
        '
        'TSS_1
        '
        Me.TSS_1.Name = "TSS_1"
        Me.TSS_1.Size = New System.Drawing.Size(188, 6)
        '
        'MI_Información_de_archivos
        '
        Me.MI_Información_de_archivos.Image = CType(resources.GetObject("MI_Información_de_archivos.Image"), System.Drawing.Image)
        Me.MI_Información_de_archivos.Name = "MI_Información_de_archivos"
        Me.MI_Información_de_archivos.Size = New System.Drawing.Size(191, 24)
        Me.MI_Información_de_archivos.Text = "Información de archivos"
        '
        'MI_Salir
        '
        Me.MI_Salir.Image = CType(resources.GetObject("MI_Salir.Image"), System.Drawing.Image)
        Me.MI_Salir.Name = "MI_Salir"
        Me.MI_Salir.Size = New System.Drawing.Size(191, 24)
        Me.MI_Salir.Text = "Salir"
        '
        'NTI_BackOffice_menú
        '
        Me.NTI_BackOffice_menú.ContextMenuStrip = Me.CMS_BackOffice_menú
        Me.NTI_BackOffice_menú.Icon = CType(resources.GetObject("NTI_BackOffice_menú.Icon"), System.Drawing.Icon)
        Me.NTI_BackOffice_menú.Text = "BackOffice"
        '
        'TMR_BackOffice_menú
        '
        Me.TMR_BackOffice_menú.Enabled = True
        Me.TMR_BackOffice_menú.Interval = 5000
        '
        'TRM_Costeos_en_proceso
        '
        Me.TRM_Costeos_en_proceso.Enabled = True
        Me.TRM_Costeos_en_proceso.Interval = 1800000
        '
        'Menú
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(246, 73)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menú"
        Me.Text = "Menú"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.CMS_BackOffice_menú.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents progressPanel As DevExpress.XtraWaitForm.ProgressPanel
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents CMS_BackOffice_menú As ContextMenuStrip
    Friend WithEvents MI_Costos_e_Importaciones As ToolStripMenuItem
    Friend WithEvents MI_Configuración As ToolStripMenuItem
    Friend WithEvents TSS_1 As ToolStripSeparator
    Friend WithEvents MI_Salir As ToolStripMenuItem
    Friend WithEvents NTI_BackOffice_menú As NotifyIcon
    Friend WithEvents TMR_BackOffice_menú As Timer
    Friend WithEvents TRM_Costeos_en_proceso As Timer
    Friend WithEvents MI_Información_de_archivos As ToolStripMenuItem
End Class
