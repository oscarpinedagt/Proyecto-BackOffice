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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Costeos_en_proceso))
        Me.TMR_Cerrar_notificación = New System.Windows.Forms.Timer(Me.components)
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.CKE_Ver_comentarios = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC_Parametros.SuspendLayout()
        CType(Me.CKE_Ver_comentarios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TMR_Cerrar_notificación
        '
        Me.TMR_Cerrar_notificación.Enabled = True
        Me.TMR_Cerrar_notificación.Interval = 1500000
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl.Location = New System.Drawing.Point(14, 26)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(934, 487)
        Me.GridControl.TabIndex = 19
        Me.GridControl.UseEmbeddedNavigator = True
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsView.ShowFooter = True
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'PC_Parametros
        '
        Me.PC_Parametros.Controls.Add(Me.CKE_Ver_comentarios)
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(14, 0)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(934, 26)
        Me.PC_Parametros.TabIndex = 18
        '
        'CKE_Ver_comentarios
        '
        Me.CKE_Ver_comentarios.Location = New System.Drawing.Point(6, 4)
        Me.CKE_Ver_comentarios.Name = "CKE_Ver_comentarios"
        Me.CKE_Ver_comentarios.Properties.Caption = "Ver comentarios"
        Me.CKE_Ver_comentarios.Size = New System.Drawing.Size(109, 19)
        Me.CKE_Ver_comentarios.TabIndex = 4
        '
        'Costeos_en_proceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 528)
        Me.Controls.Add(Me.GridControl)
        Me.Controls.Add(Me.PC_Parametros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "Costeos_en_proceso"
        Me.Padding = New System.Windows.Forms.Padding(14, 0, 0, 15)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costeos en proceso de elaboración y envío"
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC_Parametros.ResumeLayout(False)
        CType(Me.CKE_Ver_comentarios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TMR_Cerrar_notificación As Timer
    Friend WithEvents PC_Parametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CKE_Ver_comentarios As DevExpress.XtraEditors.CheckEdit
    Public WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Public WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
End Class
