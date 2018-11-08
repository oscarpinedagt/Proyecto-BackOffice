<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Costeos_en_proceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Costeos_en_proceso))
        Me.TMR_Cerrar_notificación = New System.Windows.Forms.Timer()
        Me.GC_DUAS_IPRIMAS_FAUCAS = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GC_DUAS_IPRIMAS_FAUCAS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GC_DUAS_IPRIMAS_FAUCAS.SuspendLayout()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TMR_Cerrar_notificación
        '
        Me.TMR_Cerrar_notificación.Enabled = True
        Me.TMR_Cerrar_notificación.Interval = 1500000
        '
        'GC_DUAS_IPRIMAS_FAUCAS
        '
        Me.GC_DUAS_IPRIMAS_FAUCAS.Controls.Add(Me.GridControl)
        Me.GC_DUAS_IPRIMAS_FAUCAS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_DUAS_IPRIMAS_FAUCAS.Location = New System.Drawing.Point(14, 0)
        Me.GC_DUAS_IPRIMAS_FAUCAS.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GC_DUAS_IPRIMAS_FAUCAS.Name = "GC_DUAS_IPRIMAS_FAUCAS"
        Me.GC_DUAS_IPRIMAS_FAUCAS.Size = New System.Drawing.Size(934, 513)
        Me.GC_DUAS_IPRIMAS_FAUCAS.TabIndex = 1
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GridControl.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridControl.Location = New System.Drawing.Point(2, 21)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(930, 490)
        Me.GridControl.TabIndex = 1
        Me.GridControl.UseEmbeddedNavigator = True
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.DetailHeight = 296
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsBehavior.Editable = False
        Me.GridView.OptionsSelection.MultiSelect = True
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'Costeos_en_proceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 528)
        Me.Controls.Add(Me.GC_DUAS_IPRIMAS_FAUCAS)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "Costeos_en_proceso"
        Me.Padding = New System.Windows.Forms.Padding(14, 0, 0, 15)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costeos en proceso de elaboración y envío"
        CType(Me.GC_DUAS_IPRIMAS_FAUCAS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GC_DUAS_IPRIMAS_FAUCAS.ResumeLayout(False)
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TMR_Cerrar_notificación As Timer
    Friend WithEvents GC_DUAS_IPRIMAS_FAUCAS As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Public WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
