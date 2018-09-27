<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguimientos_Envió_de_costeos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguimientos_Envió_de_costeos))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.BBI_Generar_información = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Envió_de_costeos = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.TE_SE = New DevExpress.XtraEditors.TextEdit()
        Me.LC_SE = New DevExpress.XtraEditors.LabelControl()
        Me.LUE_Tipo_de_mercadería = New DevExpress.XtraEditors.LookUpEdit()
        Me.LUE_Sub_empresa = New DevExpress.XtraEditors.LookUpEdit()
        Me.LUE_Empresa = New DevExpress.XtraEditors.LookUpEdit()
        Me.DE_Fecha_final = New DevExpress.XtraEditors.DateEdit()
        Me.LC_Tipo_de_mercadería = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Sub_Empresa = New DevExpress.XtraEditors.LabelControl()
        Me.DE_Fecha_inicial = New DevExpress.XtraEditors.DateEdit()
        Me.LC_Empresa = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Fecha_final = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Fecha_inicial = New DevExpress.XtraEditors.LabelControl()
        Me.DxErrorProvider = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC_Parametros.SuspendLayout()
        CType(Me.TE_SE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUE_Tipo_de_mercadería.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUE_Sub_empresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUE_Empresa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_final.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_final.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_inicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DE_Fecha_inicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Envió_de_costeos, Me.BBI_Generar_información})
        Me.BarManager.MainMenu = Me.Menú
        Me.BarManager.MaxItemId = 21
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Envió_de_costeos, True)})
        Me.Menú.OptionsBar.UseWholeRow = True
        Me.Menú.Text = "Menú"
        '
        'BBI_Generar_información
        '
        Me.BBI_Generar_información.Caption = "Generar información"
        Me.BBI_Generar_información.Id = 20
        Me.BBI_Generar_información.ImageOptions.Image = CType(resources.GetObject("BBI_Generar_información.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Generar_información.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Generar_información.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Generar_información.Name = "BBI_Generar_información"
        '
        'BBI_Envió_de_costeos
        '
        Me.BBI_Envió_de_costeos.Caption = "Envió de costeos"
        Me.BBI_Envió_de_costeos.Id = 18
        Me.BBI_Envió_de_costeos.ImageOptions.Image = CType(resources.GetObject("BBI_Envió_de_costeos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Envió_de_costeos.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Envió_de_costeos.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Envió_de_costeos.Name = "BBI_Envió_de_costeos"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(952, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 318)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(952, 0)
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
        Me.barDockControlRight.Location = New System.Drawing.Point(952, 26)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 292)
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.Location = New System.Drawing.Point(0, 85)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(952, 233)
        Me.GridControl.TabIndex = 1
        Me.GridControl.UseEmbeddedNavigator = True
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsSelection.MultiSelect = True
        Me.GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView.OptionsView.ShowFooter = True
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'PC_Parametros
        '
        Me.PC_Parametros.Controls.Add(Me.TE_SE)
        Me.PC_Parametros.Controls.Add(Me.LC_SE)
        Me.PC_Parametros.Controls.Add(Me.LUE_Tipo_de_mercadería)
        Me.PC_Parametros.Controls.Add(Me.LUE_Sub_empresa)
        Me.PC_Parametros.Controls.Add(Me.LUE_Empresa)
        Me.PC_Parametros.Controls.Add(Me.DE_Fecha_final)
        Me.PC_Parametros.Controls.Add(Me.LC_Tipo_de_mercadería)
        Me.PC_Parametros.Controls.Add(Me.LC_Sub_Empresa)
        Me.PC_Parametros.Controls.Add(Me.DE_Fecha_inicial)
        Me.PC_Parametros.Controls.Add(Me.LC_Empresa)
        Me.PC_Parametros.Controls.Add(Me.LC_Fecha_final)
        Me.PC_Parametros.Controls.Add(Me.LC_Fecha_inicial)
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(0, 26)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(952, 59)
        Me.PC_Parametros.TabIndex = 0
        '
        'TE_SE
        '
        Me.TE_SE.Location = New System.Drawing.Point(687, 26)
        Me.TE_SE.Name = "TE_SE"
        Me.TE_SE.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.TE_SE.Properties.Appearance.Options.UseBackColor = True
        Me.TE_SE.Properties.Appearance.Options.UseTextOptions = True
        Me.TE_SE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TE_SE.Properties.NullValuePrompt = "SE"
        Me.TE_SE.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_SE.Properties.ReadOnly = True
        Me.TE_SE.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_SE.Size = New System.Drawing.Size(50, 20)
        Me.TE_SE.TabIndex = 9
        Me.TE_SE.TabStop = False
        '
        'LC_SE
        '
        Me.LC_SE.Location = New System.Drawing.Point(687, 7)
        Me.LC_SE.Name = "LC_SE"
        Me.LC_SE.Size = New System.Drawing.Size(12, 13)
        Me.LC_SE.TabIndex = 8
        Me.LC_SE.Text = "SE"
        '
        'LUE_Tipo_de_mercadería
        '
        Me.LUE_Tipo_de_mercadería.Location = New System.Drawing.Point(531, 26)
        Me.LUE_Tipo_de_mercadería.Name = "LUE_Tipo_de_mercadería"
        Me.LUE_Tipo_de_mercadería.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Tipo_de_mercadería.Properties.NullText = ""
        Me.LUE_Tipo_de_mercadería.Properties.NullValuePrompt = "Tipo de mercaderia"
        Me.LUE_Tipo_de_mercadería.Properties.NullValuePromptShowForEmptyValue = True
        Me.LUE_Tipo_de_mercadería.Properties.ShowNullValuePromptWhenFocused = True
        Me.LUE_Tipo_de_mercadería.Size = New System.Drawing.Size(150, 20)
        Me.LUE_Tipo_de_mercadería.TabIndex = 7
        '
        'LUE_Sub_empresa
        '
        Me.LUE_Sub_empresa.Location = New System.Drawing.Point(743, 26)
        Me.LUE_Sub_empresa.Name = "LUE_Sub_empresa"
        Me.LUE_Sub_empresa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Sub_empresa.Properties.NullText = ""
        Me.LUE_Sub_empresa.Properties.NullValuePrompt = "Sub empresa"
        Me.LUE_Sub_empresa.Properties.NullValuePromptShowForEmptyValue = True
        Me.LUE_Sub_empresa.Properties.ShowNullValuePromptWhenFocused = True
        Me.LUE_Sub_empresa.Size = New System.Drawing.Size(200, 20)
        Me.LUE_Sub_empresa.TabIndex = 11
        '
        'LUE_Empresa
        '
        Me.LUE_Empresa.Location = New System.Drawing.Point(325, 26)
        Me.LUE_Empresa.MenuManager = Me.BarManager
        Me.LUE_Empresa.Name = "LUE_Empresa"
        Me.LUE_Empresa.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Empresa.Properties.NullText = ""
        Me.LUE_Empresa.Properties.NullValuePrompt = "Empresa"
        Me.LUE_Empresa.Properties.NullValuePromptShowForEmptyValue = True
        Me.LUE_Empresa.Properties.ShowNullValuePromptWhenFocused = True
        Me.LUE_Empresa.Size = New System.Drawing.Size(200, 20)
        Me.LUE_Empresa.TabIndex = 5
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
        'LC_Tipo_de_mercadería
        '
        Me.LC_Tipo_de_mercadería.Location = New System.Drawing.Point(531, 5)
        Me.LC_Tipo_de_mercadería.Name = "LC_Tipo_de_mercadería"
        Me.LC_Tipo_de_mercadería.Size = New System.Drawing.Size(91, 13)
        Me.LC_Tipo_de_mercadería.TabIndex = 6
        Me.LC_Tipo_de_mercadería.Text = "Tipo de mercadería"
        '
        'LC_Sub_Empresa
        '
        Me.LC_Sub_Empresa.Location = New System.Drawing.Point(743, 5)
        Me.LC_Sub_Empresa.Name = "LC_Sub_Empresa"
        Me.LC_Sub_Empresa.Size = New System.Drawing.Size(62, 13)
        Me.LC_Sub_Empresa.TabIndex = 10
        Me.LC_Sub_Empresa.Text = "Sub empresa"
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
        'LC_Empresa
        '
        Me.LC_Empresa.Location = New System.Drawing.Point(325, 5)
        Me.LC_Empresa.Name = "LC_Empresa"
        Me.LC_Empresa.Size = New System.Drawing.Size(41, 13)
        Me.LC_Empresa.TabIndex = 4
        Me.LC_Empresa.Text = "Empresa"
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
        'DxErrorProvider
        '
        Me.DxErrorProvider.ContainerControl = Me
        '
        'Seguimientos_Envió_de_costeos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 318)
        Me.Controls.Add(Me.GridControl)
        Me.Controls.Add(Me.PC_Parametros)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Seguimientos_Envió_de_costeos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguimientos - Envió de costeos"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC_Parametros.ResumeLayout(False)
        Me.PC_Parametros.PerformLayout()
        CType(Me.TE_SE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUE_Tipo_de_mercadería.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUE_Sub_empresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUE_Empresa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_final.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_final.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_inicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DE_Fecha_inicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Menú As DevExpress.XtraBars.Bar
    Friend WithEvents BBI_Envió_de_costeos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BBI_Generar_información As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PC_Parametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DE_Fecha_final As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DE_Fecha_inicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LC_Fecha_final As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Fecha_inicial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LUE_Tipo_de_mercadería As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LUE_Empresa As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LC_Tipo_de_mercadería As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Empresa As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TE_SE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LC_SE As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LUE_Sub_empresa As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LC_Sub_Empresa As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DxErrorProvider As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
End Class
