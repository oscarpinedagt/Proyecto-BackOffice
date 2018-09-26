<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguro))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.BBI_Generar_información = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.DE_Fecha_final = New DevExpress.XtraEditors.DateEdit()
        Me.DE_Fecha_inicial = New DevExpress.XtraEditors.DateEdit()
        Me.LC_Fecha_final = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Fecha_inicial = New DevExpress.XtraEditors.LabelControl()
        Me.BBI_Generar_a_Excel = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC_Parametros.SuspendLayout()
        CType(Me.DE_Fecha_final.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_final.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_inicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_inicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Menú})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Generar_información, Me.BBI_Generar_a_Excel})
        Me.BarManager.MainMenu = Me.Menú
        Me.BarManager.MaxItemId = 21
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_a_Excel)})
        Me.Menú.OptionsBar.UseWholeRow = True
        Me.Menú.Text = "Menú"
        '
        'BBI_Generar_información
        '
        Me.BBI_Generar_información.ActAsDropDown = True
        Me.BBI_Generar_información.Caption = "Generar información"
        Me.BBI_Generar_información.Id = 15
        Me.BBI_Generar_información.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_información.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_información.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_información.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_información.Name = "BBI_Generar_información"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(498, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 318)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(498, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 292)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(498, 26)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 292)
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.Location = New System.Drawing.Point(0, 85)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(498, 233)
        Me.GridControl.TabIndex = 5
        Me.GridControl.UseEmbeddedNavigator = True
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView.OptionsView.ShowFooter = True
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'PC_Parametros
        '
        Me.PC_Parametros.Controls.Add(Me.DE_Fecha_final)
        Me.PC_Parametros.Controls.Add(Me.DE_Fecha_inicial)
        Me.PC_Parametros.Controls.Add(Me.LC_Fecha_final)
        Me.PC_Parametros.Controls.Add(Me.LC_Fecha_inicial)
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(0, 26)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(498, 59)
        Me.PC_Parametros.TabIndex = 4
        '
        'DE_Fecha_final
        '
        Me.DE_Fecha_final.EditValue = Nothing
        Me.DE_Fecha_final.Location = New System.Drawing.Point(169, 26)
        Me.DE_Fecha_final.Name = "DE_Fecha_final"
        Me.DE_Fecha_final.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DE_Fecha_final.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DE_Fecha_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DE_Fecha_final.Size = New System.Drawing.Size(150, 20)
        Me.DE_Fecha_final.TabIndex = 3
        '
        'DE_Fecha_inicial
        '
        Me.DE_Fecha_inicial.EditValue = Nothing
        Me.DE_Fecha_inicial.Location = New System.Drawing.Point(13, 26)
        Me.DE_Fecha_inicial.MenuManager = Me.BarManager
        Me.DE_Fecha_inicial.Name = "DE_Fecha_inicial"
        Me.DE_Fecha_inicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DE_Fecha_inicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DE_Fecha_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DE_Fecha_inicial.Size = New System.Drawing.Size(150, 20)
        Me.DE_Fecha_inicial.TabIndex = 1
        '
        'LC_Fecha_final
        '
        Me.LC_Fecha_final.Location = New System.Drawing.Point(169, 5)
        Me.LC_Fecha_final.Name = "LC_Fecha_final"
        Me.LC_Fecha_final.Size = New System.Drawing.Size(52, 13)
        Me.LC_Fecha_final.TabIndex = 2
        Me.LC_Fecha_final.Text = "Fecha final"
        '
        'LC_Fecha_inicial
        '
        Me.LC_Fecha_inicial.Location = New System.Drawing.Point(13, 6)
        Me.LC_Fecha_inicial.Name = "LC_Fecha_inicial"
        Me.LC_Fecha_inicial.Size = New System.Drawing.Size(57, 13)
        Me.LC_Fecha_inicial.TabIndex = 0
        Me.LC_Fecha_inicial.Text = "Fecha inicial"
        '
        'BBI_Generar_a_Excel
        '
        Me.BBI_Generar_a_Excel.Caption = "Trasladar a Exel"
        Me.BBI_Generar_a_Excel.Id = 20
        Me.BBI_Generar_a_Excel.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_a_Excel.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_a_Excel.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_a_Excel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_a_Excel.Name = "BBI_Generar_a_Excel"
        '
        'Seguro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 318)
        Me.Controls.Add(Me.GridControl)
        Me.Controls.Add(Me.PC_Parametros)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Seguro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguro"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC_Parametros.ResumeLayout(False)
        Me.PC_Parametros.PerformLayout()
        CType(Me.DE_Fecha_final.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_final.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_inicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_inicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Menú As DevExpress.XtraBars.Bar
    Friend WithEvents BBI_Generar_información As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PC_Parametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DE_Fecha_final As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DE_Fecha_inicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LC_Fecha_final As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Fecha_inicial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BBI_Generar_a_Excel As DevExpress.XtraBars.BarButtonItem
End Class
