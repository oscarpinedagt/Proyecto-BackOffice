<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tableros_4DX_Información_detallada_por_mes_semana
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tableros_4DX_Información_detallada_por_mes_semana))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.BBI_Generar_información = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Imprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Editar = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PC_Parametros = New DevExpress.XtraEditors.PanelControl()
        Me.CKE_Ver_comentarios = New DevExpress.XtraEditors.CheckEdit()
        Me.LC_Grupo_de_empresas = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Año = New DevExpress.XtraEditors.LabelControl()
        Me.TE_Año = New DevExpress.XtraEditors.TextEdit()
        Me.LUE_Grupo_de_empresas = New DevExpress.XtraEditors.LookUpEdit()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PC_Parametros.SuspendLayout()
        CType(Me.CKE_Ver_comentarios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Año.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUE_Grupo_de_empresas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Generar_información, Me.BBI_Imprimir, Me.BBI_Editar})
        Me.BarManager.MainMenu = Me.Menú
        Me.BarManager.MaxItemId = 25
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Generar_información), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Imprimir, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Editar, True)})
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
        'BBI_Editar
        '
        Me.BBI_Editar.Caption = "Editar"
        Me.BBI_Editar.Id = 24
        Me.BBI_Editar.ImageOptions.Image = CType(resources.GetObject("BBI_Editar.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Editar.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Editar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Editar.Name = "BBI_Editar"
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
        Me.GridControl.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.GridControl.Location = New System.Drawing.Point(0, 85)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(498, 233)
        Me.GridControl.TabIndex = 17
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
        Me.PC_Parametros.Controls.Add(Me.LC_Grupo_de_empresas)
        Me.PC_Parametros.Controls.Add(Me.LC_Año)
        Me.PC_Parametros.Controls.Add(Me.TE_Año)
        Me.PC_Parametros.Controls.Add(Me.LUE_Grupo_de_empresas)
        Me.PC_Parametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PC_Parametros.Location = New System.Drawing.Point(0, 26)
        Me.PC_Parametros.Name = "PC_Parametros"
        Me.PC_Parametros.Size = New System.Drawing.Size(498, 59)
        Me.PC_Parametros.TabIndex = 16
        '
        'CKE_Ver_comentarios
        '
        Me.CKE_Ver_comentarios.Location = New System.Drawing.Point(275, 27)
        Me.CKE_Ver_comentarios.MenuManager = Me.BarManager
        Me.CKE_Ver_comentarios.Name = "CKE_Ver_comentarios"
        Me.CKE_Ver_comentarios.Properties.Caption = "Ver comentarios"
        Me.CKE_Ver_comentarios.Size = New System.Drawing.Size(109, 19)
        Me.CKE_Ver_comentarios.TabIndex = 4
        '
        'LC_Grupo_de_empresas
        '
        Me.LC_Grupo_de_empresas.Location = New System.Drawing.Point(119, 6)
        Me.LC_Grupo_de_empresas.Name = "LC_Grupo_de_empresas"
        Me.LC_Grupo_de_empresas.Size = New System.Drawing.Size(93, 13)
        Me.LC_Grupo_de_empresas.TabIndex = 2
        Me.LC_Grupo_de_empresas.Text = "Grupo de empresas"
        '
        'LC_Año
        '
        Me.LC_Año.Location = New System.Drawing.Point(13, 6)
        Me.LC_Año.Name = "LC_Año"
        Me.LC_Año.Size = New System.Drawing.Size(19, 13)
        Me.LC_Año.TabIndex = 0
        Me.LC_Año.Text = "Año"
        '
        'TE_Año
        '
        Me.TE_Año.Location = New System.Drawing.Point(13, 26)
        Me.TE_Año.MenuManager = Me.BarManager
        Me.TE_Año.Name = "TE_Año"
        Me.TE_Año.Properties.Appearance.Options.UseTextOptions = True
        Me.TE_Año.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TE_Año.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TE_Año.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TE_Año.Properties.Mask.EditMask = "0000"
        Me.TE_Año.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TE_Año.Size = New System.Drawing.Size(100, 20)
        Me.TE_Año.TabIndex = 1
        '
        'LUE_Grupo_de_empresas
        '
        Me.LUE_Grupo_de_empresas.Location = New System.Drawing.Point(119, 26)
        Me.LUE_Grupo_de_empresas.Name = "LUE_Grupo_de_empresas"
        Me.LUE_Grupo_de_empresas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Grupo_de_empresas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LUE_Grupo_de_empresas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.LUE_Grupo_de_empresas.Properties.NullText = ""
        Me.LUE_Grupo_de_empresas.Size = New System.Drawing.Size(150, 20)
        Me.LUE_Grupo_de_empresas.TabIndex = 3
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl1.Manager = Me.BarManager
        Me.BarDockControl1.Size = New System.Drawing.Size(498, 0)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl2.Manager = Me.BarManager
        Me.BarDockControl2.Size = New System.Drawing.Size(498, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 26)
        Me.BarDockControl3.Manager = Me.BarManager
        Me.BarDockControl3.Size = New System.Drawing.Size(498, 0)
        '
        'Tableros_4DX_Información_detallada_por_mes_semana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 318)
        Me.Controls.Add(Me.GridControl)
        Me.Controls.Add(Me.PC_Parametros)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tableros_4DX_Información_detallada_por_mes_semana"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tableros 4DX - [Información detallada]\[mes - semana]"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PC_Parametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PC_Parametros.ResumeLayout(False)
        Me.PC_Parametros.PerformLayout()
        CType(Me.CKE_Ver_comentarios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Año.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUE_Grupo_de_empresas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PC_Parametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LC_Grupo_de_empresas As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Año As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TE_Año As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LUE_Grupo_de_empresas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents CKE_Ver_comentarios As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BBI_Editar As DevExpress.XtraBars.BarButtonItem
End Class
