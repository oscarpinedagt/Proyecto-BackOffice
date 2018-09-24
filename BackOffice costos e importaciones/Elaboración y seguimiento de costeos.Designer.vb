<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Elaboración_y_seguimiento_de_costeos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Elaboración_y_seguimiento_de_costeos))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.BBI_Generar_información = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBI_Generar_información_de_archivos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Actualizar_información_de_archivos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Generar_archivo_de_información_de_archivos = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenuInfo = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BBI_Generar_información_desde_directorio = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Generar_información_desde_informe = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.LUE_Directorio_a_validar = New DevExpress.XtraEditors.LookUpEdit()
        Me.DE_Fecha_final = New DevExpress.XtraEditors.DateEdit()
        Me.DE_Fecha_inicial = New DevExpress.XtraEditors.DateEdit()
        Me.LC_Directorio_a_validar = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Fecha_final = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Fecha_inicial = New DevExpress.XtraEditors.LabelControl()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC_Parametros.SuspendLayout()
        CType(Me.LUE_Directorio_a_validar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Generar_información, Me.BBI_Generar_información_de_archivos, Me.BBI_Actualizar_información_de_archivos, Me.BBI_Generar_archivo_de_información_de_archivos, Me.BBI_Generar_información_desde_directorio, Me.BBI_Generar_información_desde_informe})
        Me.BarManager.MainMenu = Me.Menú
        Me.BarManager.MaxItemId = 23
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_archivo_de_información_de_archivos)})
        Me.Menú.OptionsBar.UseWholeRow = True
        Me.Menú.Text = "Menú"
        '
        'BBI_Generar_información
        '
        Me.BBI_Generar_información.ActAsDropDown = True
        Me.BBI_Generar_información.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BBI_Generar_información.Caption = "Generar información"
        Me.BBI_Generar_información.DropDownControl = Me.PopupMenu
        Me.BBI_Generar_información.Id = 15
        Me.BBI_Generar_información.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_información.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_información.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_información.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_información.Name = "BBI_Generar_información"
        '
        'PopupMenu
        '
        Me.PopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información_de_archivos), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Actualizar_información_de_archivos)})
        Me.PopupMenu.Manager = Me.BarManager
        Me.PopupMenu.Name = "PopupMenu"
        '
        'BBI_Generar_información_de_archivos
        '
        Me.BBI_Generar_información_de_archivos.Caption = "Generar información de archivos"
        Me.BBI_Generar_información_de_archivos.Id = 16
        Me.BBI_Generar_información_de_archivos.Name = "BBI_Generar_información_de_archivos"
        '
        'BBI_Actualizar_información_de_archivos
        '
        Me.BBI_Actualizar_información_de_archivos.Caption = "Actualizar información de archivos"
        Me.BBI_Actualizar_información_de_archivos.Id = 17
        Me.BBI_Actualizar_información_de_archivos.Name = "BBI_Actualizar_información_de_archivos"
        '
        'BBI_Generar_archivo_de_información_de_archivos
        '
        Me.BBI_Generar_archivo_de_información_de_archivos.ActAsDropDown = True
        Me.BBI_Generar_archivo_de_información_de_archivos.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.BBI_Generar_archivo_de_información_de_archivos.Caption = "Generar archivo de información de archivos"
        Me.BBI_Generar_archivo_de_información_de_archivos.DropDownControl = Me.PopupMenuInfo
        Me.BBI_Generar_archivo_de_información_de_archivos.Id = 20
        Me.BBI_Generar_archivo_de_información_de_archivos.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_archivo_de_información_de_archivos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_archivo_de_información_de_archivos.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_archivo_de_información_de_archivos.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_archivo_de_información_de_archivos.Name = "BBI_Generar_archivo_de_información_de_archivos"
        '
        'PopupMenuInfo
        '
        Me.PopupMenuInfo.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información_desde_directorio), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información_desde_informe)})
        Me.PopupMenuInfo.Manager = Me.BarManager
        Me.PopupMenuInfo.Name = "PopupMenuInfo"
        '
        'BBI_Generar_información_desde_directorio
        '
        Me.BBI_Generar_información_desde_directorio.Caption = "Desde directorio"
        Me.BBI_Generar_información_desde_directorio.Id = 21
        Me.BBI_Generar_información_desde_directorio.Name = "BBI_Generar_información_desde_directorio"
        '
        'BBI_Generar_información_desde_informe
        '
        Me.BBI_Generar_información_desde_informe.Caption = "Desde informe"
        Me.BBI_Generar_información_desde_informe.Id = 22
        Me.BBI_Generar_información_desde_informe.Name = "BBI_Generar_información_desde_informe"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(619, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 318)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(619, 0)
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
        Me.barDockControlRight.Location = New System.Drawing.Point(619, 26)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 292)
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.Location = New System.Drawing.Point(0, 85)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(619, 233)
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
        Me.PC_Parametros.Controls.Add(Me.LUE_Directorio_a_validar)
        Me.PC_Parametros.Controls.Add(Me.DE_Fecha_final)
        Me.PC_Parametros.Controls.Add(Me.DE_Fecha_inicial)
        Me.PC_Parametros.Controls.Add(Me.LC_Directorio_a_validar)
        Me.PC_Parametros.Controls.Add(Me.LC_Fecha_final)
        Me.PC_Parametros.Controls.Add(Me.LC_Fecha_inicial)
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(0, 26)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(619, 59)
        Me.PC_Parametros.TabIndex = 4
        '
        'LUE_Directorio_a_validar
        '
        Me.LUE_Directorio_a_validar.Location = New System.Drawing.Point(325, 26)
        Me.LUE_Directorio_a_validar.MenuManager = Me.BarManager
        Me.LUE_Directorio_a_validar.Name = "LUE_Directorio_a_validar"
        Me.LUE_Directorio_a_validar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Directorio_a_validar.Properties.NullText = ""
        Me.LUE_Directorio_a_validar.Properties.NullValuePrompt = "Directorio a validar"
        Me.LUE_Directorio_a_validar.Properties.NullValuePromptShowForEmptyValue = True
        Me.LUE_Directorio_a_validar.Properties.ShowNullValuePromptWhenFocused = True
        Me.LUE_Directorio_a_validar.Size = New System.Drawing.Size(282, 20)
        Me.LUE_Directorio_a_validar.TabIndex = 39
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
        'LC_Directorio_a_validar
        '
        Me.LC_Directorio_a_validar.Location = New System.Drawing.Point(325, 5)
        Me.LC_Directorio_a_validar.Name = "LC_Directorio_a_validar"
        Me.LC_Directorio_a_validar.Size = New System.Drawing.Size(90, 13)
        Me.LC_Directorio_a_validar.TabIndex = 2
        Me.LC_Directorio_a_validar.Text = "Directorio a validar"
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
        'Elaboración_y_seguimiento_de_costeos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 318)
        Me.Controls.Add(Me.GridControl)
        Me.Controls.Add(Me.PC_Parametros)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Elaboración_y_seguimiento_de_costeos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elaboración y seguimiento de costeos"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC_Parametros.ResumeLayout(False)
        Me.PC_Parametros.PerformLayout()
        CType(Me.LUE_Directorio_a_validar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBI_Generar_información_de_archivos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Actualizar_información_de_archivos As DevExpress.XtraBars.BarButtonItem
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
    Friend WithEvents BBI_Generar_archivo_de_información_de_archivos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LUE_Directorio_a_validar As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LC_Directorio_a_validar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PopupMenuInfo As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBI_Generar_información_desde_directorio As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Generar_información_desde_informe As DevExpress.XtraBars.BarButtonItem
End Class
