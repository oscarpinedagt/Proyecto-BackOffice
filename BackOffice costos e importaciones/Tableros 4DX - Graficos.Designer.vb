<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tableros_4DX_Graficos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tableros_4DX_Graficos))
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim ChartTitle2 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim ChartTitle3 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim ChartTitle4 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.BBI_Generar_información = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Imprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.LC_Mes = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Grupo_de_empresas = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Meta = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Año = New DevExpress.XtraEditors.LabelControl()
        Me.LUE_Mes = New DevExpress.XtraEditors.LookUpEdit()
        Me.TE_Meta = New DevExpress.XtraEditors.TextEdit()
        Me.TE_Año = New DevExpress.XtraEditors.TextEdit()
        Me.LUE_Grupo_de_empresas = New DevExpress.XtraEditors.LookUpEdit()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl = New DevExpress.XtraLayout.LayoutControl()
        Me.LC_Cumplimiento = New DevExpress.XtraEditors.LabelControl()
        Me.Chart_Progreso = New DevExpress.XtraCharts.ChartControl()
        Me.Chart_Unidades_costeadas = New DevExpress.XtraCharts.ChartControl()
        Me.Chart_Estadia_por_semana = New DevExpress.XtraCharts.ChartControl()
        Me.Chart_Estadia_por_mes = New DevExpress.XtraCharts.ChartControl()
        Me.LayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TMR_Auto_actualizar = New System.Windows.Forms.Timer(Me.components)
        Me.CKE_Auto_actualizar = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC_Parametros.SuspendLayout()
        CType(Me.LUE_Mes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Meta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Año.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUE_Grupo_de_empresas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl.SuspendLayout()
        CType(Me.Chart_Progreso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_Unidades_costeadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_Estadia_por_semana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart_Estadia_por_mes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CKE_Auto_actualizar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Generar_información, Me.BBI_Imprimir})
        Me.BarManager.MainMenu = Me.Menú
        Me.BarManager.MaxItemId = 25
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Imprimir, True)})
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
        'BBI_Imprimir
        '
        Me.BBI_Imprimir.Caption = "Imprimir"
        Me.BBI_Imprimir.Id = 23
        Me.BBI_Imprimir.ImageOptions.Image = CType(resources.GetObject("BBI_Imprimir.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Imprimir.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Imprimir.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Imprimir.Name = "BBI_Imprimir"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(898, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 568)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(898, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 542)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(898, 26)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 542)
        '
        'PC_Parametros
        '
        Me.PC_Parametros.Controls.Add(Me.CKE_Auto_actualizar)
        Me.PC_Parametros.Controls.Add(Me.LC_Mes)
        Me.PC_Parametros.Controls.Add(Me.LC_Grupo_de_empresas)
        Me.PC_Parametros.Controls.Add(Me.LC_Meta)
        Me.PC_Parametros.Controls.Add(Me.LC_Año)
        Me.PC_Parametros.Controls.Add(Me.LUE_Mes)
        Me.PC_Parametros.Controls.Add(Me.TE_Meta)
        Me.PC_Parametros.Controls.Add(Me.TE_Año)
        Me.PC_Parametros.Controls.Add(Me.LUE_Grupo_de_empresas)
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(0, 26)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(898, 59)
        Me.PC_Parametros.TabIndex = 0
        '
        'LC_Mes
        '
        Me.LC_Mes.Location = New System.Drawing.Point(274, 6)
        Me.LC_Mes.Name = "LC_Mes"
        Me.LC_Mes.Size = New System.Drawing.Size(19, 13)
        Me.LC_Mes.TabIndex = 4
        Me.LC_Mes.Text = "Mes"
        '
        'LC_Grupo_de_empresas
        '
        Me.LC_Grupo_de_empresas.Location = New System.Drawing.Point(12, 6)
        Me.LC_Grupo_de_empresas.Name = "LC_Grupo_de_empresas"
        Me.LC_Grupo_de_empresas.Size = New System.Drawing.Size(93, 13)
        Me.LC_Grupo_de_empresas.TabIndex = 0
        Me.LC_Grupo_de_empresas.Text = "Grupo de empresas"
        '
        'LC_Meta
        '
        Me.LC_Meta.Location = New System.Drawing.Point(430, 6)
        Me.LC_Meta.Name = "LC_Meta"
        Me.LC_Meta.Size = New System.Drawing.Size(24, 13)
        Me.LC_Meta.TabIndex = 6
        Me.LC_Meta.Text = "Meta"
        '
        'LC_Año
        '
        Me.LC_Año.Location = New System.Drawing.Point(168, 6)
        Me.LC_Año.Name = "LC_Año"
        Me.LC_Año.Size = New System.Drawing.Size(19, 13)
        Me.LC_Año.TabIndex = 2
        Me.LC_Año.Text = "Año"
        '
        'LUE_Mes
        '
        Me.LUE_Mes.Location = New System.Drawing.Point(274, 26)
        Me.LUE_Mes.Name = "LUE_Mes"
        Me.LUE_Mes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Mes.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LUE_Mes.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LUE_Mes.Properties.NullText = ""
        Me.LUE_Mes.Size = New System.Drawing.Size(150, 20)
        Me.LUE_Mes.TabIndex = 5
        '
        'TE_Meta
        '
        Me.TE_Meta.Location = New System.Drawing.Point(430, 26)
        Me.TE_Meta.Name = "TE_Meta"
        Me.TE_Meta.Properties.Appearance.Options.UseTextOptions = True
        Me.TE_Meta.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TE_Meta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TE_Meta.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TE_Meta.Properties.Mask.EditMask = "p"
        Me.TE_Meta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TE_Meta.Size = New System.Drawing.Size(100, 20)
        Me.TE_Meta.TabIndex = 7
        '
        'TE_Año
        '
        Me.TE_Año.Location = New System.Drawing.Point(168, 26)
        Me.TE_Año.MenuManager = Me.BarManager
        Me.TE_Año.Name = "TE_Año"
        Me.TE_Año.Properties.Appearance.Options.UseTextOptions = True
        Me.TE_Año.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TE_Año.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TE_Año.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TE_Año.Properties.Mask.EditMask = "0000"
        Me.TE_Año.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TE_Año.Size = New System.Drawing.Size(100, 20)
        Me.TE_Año.TabIndex = 3
        '
        'LUE_Grupo_de_empresas
        '
        Me.LUE_Grupo_de_empresas.Location = New System.Drawing.Point(12, 26)
        Me.LUE_Grupo_de_empresas.Name = "LUE_Grupo_de_empresas"
        Me.LUE_Grupo_de_empresas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Grupo_de_empresas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LUE_Grupo_de_empresas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LUE_Grupo_de_empresas.Properties.NullText = ""
        Me.LUE_Grupo_de_empresas.Size = New System.Drawing.Size(150, 20)
        Me.LUE_Grupo_de_empresas.TabIndex = 1
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl1.Manager = Me.BarManager
        Me.BarDockControl1.Size = New System.Drawing.Size(898, 0)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl2.Manager = Me.BarManager
        Me.BarDockControl2.Size = New System.Drawing.Size(898, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl3.Manager = Me.BarManager
        Me.BarDockControl3.Size = New System.Drawing.Size(898, 0)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl4.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl4.Manager = Me.BarManager
        Me.BarDockControl4.Size = New System.Drawing.Size(898, 0)
        '
        'LayoutControl
        '
        Me.LayoutControl.Controls.Add(Me.LC_Cumplimiento)
        Me.LayoutControl.Controls.Add(Me.Chart_Progreso)
        Me.LayoutControl.Controls.Add(Me.Chart_Unidades_costeadas)
        Me.LayoutControl.Controls.Add(Me.Chart_Estadia_por_semana)
        Me.LayoutControl.Controls.Add(Me.Chart_Estadia_por_mes)
        Me.LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl.Location = New System.Drawing.Point(0, 85)
        Me.LayoutControl.Name = "LayoutControl"
        Me.LayoutControl.Root = Me.LayoutControlGroup
        Me.LayoutControl.Size = New System.Drawing.Size(898, 483)
        Me.LayoutControl.TabIndex = 1
        Me.LayoutControl.Text = "LayoutControl1"
        '
        'LC_Cumplimiento
        '
        Me.LC_Cumplimiento.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LC_Cumplimiento.Appearance.Options.UseFont = True
        Me.LC_Cumplimiento.Appearance.Options.UseTextOptions = True
        Me.LC_Cumplimiento.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LC_Cumplimiento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LC_Cumplimiento.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LC_Cumplimiento.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LC_Cumplimiento.LineVisible = True
        Me.LC_Cumplimiento.Location = New System.Drawing.Point(12, 12)
        Me.LC_Cumplimiento.Name = "LC_Cumplimiento"
        Me.LC_Cumplimiento.Size = New System.Drawing.Size(874, 22)
        Me.LC_Cumplimiento.StyleController = Me.LayoutControl
        Me.LC_Cumplimiento.TabIndex = 0
        '
        'Chart_Progreso
        '
        Me.Chart_Progreso.Legend.Name = "Default Legend"
        Me.Chart_Progreso.Location = New System.Drawing.Point(451, 38)
        Me.Chart_Progreso.Name = "Chart_Progreso"
        Me.Chart_Progreso.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.Chart_Progreso.Size = New System.Drawing.Size(435, 214)
        Me.Chart_Progreso.TabIndex = 2
        ChartTitle1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        ChartTitle1.Indent = 0
        ChartTitle1.Text = "Cumplimiento mensual"
        Me.Chart_Progreso.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'Chart_Unidades_costeadas
        '
        Me.Chart_Unidades_costeadas.Legend.Name = "Default Legend"
        Me.Chart_Unidades_costeadas.Location = New System.Drawing.Point(12, 38)
        Me.Chart_Unidades_costeadas.Name = "Chart_Unidades_costeadas"
        Me.Chart_Unidades_costeadas.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.Chart_Unidades_costeadas.Size = New System.Drawing.Size(435, 214)
        Me.Chart_Unidades_costeadas.TabIndex = 1
        ChartTitle2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        ChartTitle2.Indent = 0
        ChartTitle2.Text = "Unidades recibidas por mes"
        Me.Chart_Unidades_costeadas.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle2})
        '
        'Chart_Estadia_por_semana
        '
        Me.Chart_Estadia_por_semana.Legend.Name = "Default Legend"
        Me.Chart_Estadia_por_semana.Location = New System.Drawing.Point(451, 256)
        Me.Chart_Estadia_por_semana.Name = "Chart_Estadia_por_semana"
        Me.Chart_Estadia_por_semana.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.Chart_Estadia_por_semana.Size = New System.Drawing.Size(435, 215)
        Me.Chart_Estadia_por_semana.TabIndex = 4
        ChartTitle3.Font = New System.Drawing.Font("Tahoma", 12.0!)
        ChartTitle3.Indent = 0
        ChartTitle3.Text = "Estadia de costeos por semana"
        Me.Chart_Estadia_por_semana.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle3})
        '
        'Chart_Estadia_por_mes
        '
        Me.Chart_Estadia_por_mes.Legend.Name = "Default Legend"
        Me.Chart_Estadia_por_mes.Location = New System.Drawing.Point(12, 256)
        Me.Chart_Estadia_por_mes.Name = "Chart_Estadia_por_mes"
        Me.Chart_Estadia_por_mes.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.Chart_Estadia_por_mes.Size = New System.Drawing.Size(435, 215)
        Me.Chart_Estadia_por_mes.TabIndex = 3
        ChartTitle4.Font = New System.Drawing.Font("Tahoma", 12.0!)
        ChartTitle4.Indent = 0
        ChartTitle4.Text = "Estadia de costeos por mes"
        Me.Chart_Estadia_por_mes.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle4})
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup.GroupBordersVisible = False
        Me.LayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem5})
        Me.LayoutControlGroup.Name = "LayoutControlGroup"
        Me.LayoutControlGroup.Size = New System.Drawing.Size(898, 483)
        Me.LayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.Chart_Progreso
        Me.LayoutControlItem4.Location = New System.Drawing.Point(439, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(104, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(439, 218)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.Chart_Estadia_por_semana
        Me.LayoutControlItem2.Location = New System.Drawing.Point(439, 244)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(104, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(439, 219)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.Chart_Unidades_costeadas
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(439, 218)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Chart_Estadia_por_mes
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 244)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(439, 219)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LC_Cumplimiento
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(70, 17)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(878, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'TMR_Auto_actualizar
        '
        Me.TMR_Auto_actualizar.Interval = 60000
        '
        'CKE_Auto_actualizar
        '
        Me.CKE_Auto_actualizar.Location = New System.Drawing.Point(537, 29)
        Me.CKE_Auto_actualizar.MenuManager = Me.BarManager
        Me.CKE_Auto_actualizar.Name = "CKE_Auto_actualizar"
        Me.CKE_Auto_actualizar.Properties.Caption = "Auto-Actualizar"
        Me.CKE_Auto_actualizar.Size = New System.Drawing.Size(99, 19)
        Me.CKE_Auto_actualizar.TabIndex = 8
        '
        'Tableros_4DX_Graficos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 568)
        Me.Controls.Add(Me.LayoutControl)
        Me.Controls.Add(Me.PC_Parametros)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tableros_4DX_Graficos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tableros 4DX - Graficos"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC_Parametros.ResumeLayout(False)
        Me.PC_Parametros.PerformLayout()
        CType(Me.LUE_Mes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Meta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Año.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUE_Grupo_de_empresas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl.ResumeLayout(False)
        CType(Me.Chart_Progreso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_Unidades_costeadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_Estadia_por_semana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart_Estadia_por_mes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CKE_Auto_actualizar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Menú As DevExpress.XtraBars.Bar
    Friend WithEvents BBI_Generar_información As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Imprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PC_Parametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LC_Grupo_de_empresas As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Año As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TE_Año As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LUE_Grupo_de_empresas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LayoutControl As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Chart_Estadia_por_semana As DevExpress.XtraCharts.ChartControl
    Friend WithEvents Chart_Estadia_por_mes As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LC_Mes As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LUE_Mes As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Chart_Unidades_costeadas As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LC_Meta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TE_Meta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Chart_Progreso As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LC_Cumplimiento As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CKE_Auto_actualizar As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TMR_Auto_actualizar As Windows.Forms.Timer
End Class
