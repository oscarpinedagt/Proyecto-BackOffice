<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Seguimientos_Control_de_IPRIMA
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguimientos_Control_de_IPRIMA))
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar = New DevExpress.XtraBars.Bar()
        Me.BBI_Generar_información = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu_Generación = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBI_Disponibles = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Solicitados = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Liquidados = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Cargar_reporte_de_polizas = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Cargar_facturación = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Envió_a_tesorería = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.BBI_Generar_a_Excel = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu_Generación, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.OptionsBar.UseWholeRow = True
        Me.Menú.Text = "Menú"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Generar_información, Me.BBI_Cargar_facturación, Me.BBI_Cargar_reporte_de_polizas, Me.BBI_Disponibles, Me.BBI_Solicitados, Me.BBI_Liquidados, Me.BBI_Envió_a_tesorería, Me.BBI_Generar_a_Excel})
        Me.BarManager.MainMenu = Me.Bar
        Me.BarManager.MaxItemId = 33
        '
        'Bar
        '
        Me.Bar.BarName = "Menú"
        Me.Bar.DockCol = 0
        Me.Bar.DockRow = 0
        Me.Bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BBI_Cargar_reporte_de_polizas, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BBI_Cargar_facturación, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Envió_a_tesorería), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_a_Excel)})
        Me.Bar.OptionsBar.UseWholeRow = True
        Me.Bar.Text = "Menú"
        '
        'BBI_Generar_información
        '
        Me.BBI_Generar_información.ActAsDropDown = True
        Me.BBI_Generar_información.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BBI_Generar_información.Caption = "Generar información"
        Me.BBI_Generar_información.DropDownControl = Me.PopupMenu_Generación
        Me.BBI_Generar_información.Id = 15
        Me.BBI_Generar_información.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_información.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_información.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_información.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_información.Name = "BBI_Generar_información"
        '
        'PopupMenu_Generación
        '
        Me.PopupMenu_Generación.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Disponibles), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Solicitados), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Liquidados)})
        Me.PopupMenu_Generación.Manager = Me.BarManager
        Me.PopupMenu_Generación.Name = "PopupMenu_Generación"
        '
        'BBI_Disponibles
        '
        Me.BBI_Disponibles.Caption = "Disponibles"
        Me.BBI_Disponibles.Id = 26
        Me.BBI_Disponibles.Name = "BBI_Disponibles"
        '
        'BBI_Solicitados
        '
        Me.BBI_Solicitados.Caption = "Solicitados"
        Me.BBI_Solicitados.Id = 27
        Me.BBI_Solicitados.Name = "BBI_Solicitados"
        '
        'BBI_Liquidados
        '
        Me.BBI_Liquidados.Caption = "Liquidados"
        Me.BBI_Liquidados.Id = 28
        Me.BBI_Liquidados.Name = "BBI_Liquidados"
        '
        'BBI_Cargar_reporte_de_polizas
        '
        Me.BBI_Cargar_reporte_de_polizas.Caption = "Cargar reporte de pólizas"
        Me.BBI_Cargar_reporte_de_polizas.Id = 19
        Me.BBI_Cargar_reporte_de_polizas.ImageOptions.Image = CType(resources.GetObject("BBI_Cargar_reporte_de_polizas.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Cargar_reporte_de_polizas.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Cargar_reporte_de_polizas.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Cargar_reporte_de_polizas.Name = "BBI_Cargar_reporte_de_polizas"
        '
        'BBI_Cargar_facturación
        '
        Me.BBI_Cargar_facturación.Caption = "Cargar facturación"
        Me.BBI_Cargar_facturación.Id = 18
        Me.BBI_Cargar_facturación.ImageOptions.Image = CType(resources.GetObject("BBI_Cargar_facturación.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Cargar_facturación.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Cargar_facturación.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Cargar_facturación.Name = "BBI_Cargar_facturación"
        '
        'BBI_Envió_a_tesorería
        '
        Me.BBI_Envió_a_tesorería.ActAsDropDown = True
        Me.BBI_Envió_a_tesorería.Caption = "Envió a tesorería"
        Me.BBI_Envió_a_tesorería.Id = 29
        Me.BBI_Envió_a_tesorería.ImageOptions.Image = CType(resources.GetObject("BBI_Envió_a_tesorería.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Envió_a_tesorería.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Envió_a_tesorería.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Envió_a_tesorería.Name = "BBI_Envió_a_tesorería"
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
        Me.GridControl.Location = New System.Drawing.Point(0, 36)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(498, 282)
        Me.GridControl.TabIndex = 5
        Me.GridControl.UseEmbeddedNavigator = True
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsFind.AlwaysVisible = True
        Me.GridView.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView.OptionsView.ShowFooter = True
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'PC_Parametros
        '
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(0, 26)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(498, 10)
        Me.PC_Parametros.TabIndex = 4
        '
        'BBI_Generar_a_Excel
        '
        Me.BBI_Generar_a_Excel.Caption = "Trasladar a Exel"
        Me.BBI_Generar_a_Excel.Id = 32
        Me.BBI_Generar_a_Excel.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_a_Excel.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_a_Excel.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_a_Excel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_a_Excel.Name = "BBI_Generar_a_Excel"
        '
        'Seguimientos_Control_de_IPRIMA
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
        Me.Name = "Seguimientos_Control_de_IPRIMA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguimientos - Control de IPRIMA"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu_Generación, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Menú As DevExpress.XtraBars.Bar
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar As DevExpress.XtraBars.Bar
    Friend WithEvents BBI_Generar_información As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Cargar_reporte_de_polizas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Cargar_facturación As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PopupMenu_Generación As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBI_Disponibles As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Solicitados As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Liquidados As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PC_Parametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BBI_Envió_a_tesorería As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Generar_a_Excel As DevExpress.XtraBars.BarButtonItem
End Class
