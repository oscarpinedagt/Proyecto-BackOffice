<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Complementos_del_puesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Complementos_del_puesto))
        Me.Menú = New DevExpress.XtraBars.Bar()
        Me.DxErrorProvider = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.TE_Código = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Código = New DevExpress.XtraEditors.LabelControl()
        Me.TE_Descripción = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Descripción = New DevExpress.XtraEditors.LabelControl()
        Me.Tv_Complementos = New System.Windows.Forms.TreeView()
        Me.Cms_Complementos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mi_Crear_principal = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mi_Crear_siguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tss_3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Mi_Editar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mi_Eliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BBI_Nuevo = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Guardar = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Cancelar = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Editar = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Eliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Buscar = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Código.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Descripción.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Complementos.SuspendLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DxErrorProvider
        '
        Me.DxErrorProvider.ContainerControl = Me
        '
        'TE_Código
        '
        Me.TE_Código.Location = New System.Drawing.Point(12, 52)
        Me.TE_Código.Name = "TE_Código"
        Me.TE_Código.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.TE_Código.Properties.Appearance.Options.UseBackColor = True
        Me.TE_Código.Properties.Appearance.Options.UseTextOptions = True
        Me.TE_Código.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TE_Código.Properties.NullValuePrompt = "Código"
        Me.TE_Código.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Código.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Código.Size = New System.Drawing.Size(151, 20)
        Me.TE_Código.TabIndex = 1
        '
        'LC_Código
        '
        Me.LC_Código.Location = New System.Drawing.Point(12, 32)
        Me.LC_Código.Name = "LC_Código"
        Me.LC_Código.Size = New System.Drawing.Size(33, 13)
        Me.LC_Código.TabIndex = 0
        Me.LC_Código.Text = "Código"
        '
        'TE_Descripción
        '
        Me.TE_Descripción.Location = New System.Drawing.Point(169, 52)
        Me.TE_Descripción.Name = "TE_Descripción"
        Me.TE_Descripción.Properties.NullValuePrompt = "Descripción"
        Me.TE_Descripción.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Descripción.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Descripción.Size = New System.Drawing.Size(467, 20)
        Me.TE_Descripción.TabIndex = 3
        '
        'LC_Descripción
        '
        Me.LC_Descripción.Location = New System.Drawing.Point(170, 32)
        Me.LC_Descripción.Name = "LC_Descripción"
        Me.LC_Descripción.Size = New System.Drawing.Size(54, 13)
        Me.LC_Descripción.TabIndex = 2
        Me.LC_Descripción.Text = "Descripción"
        '
        'Tv_Complementos
        '
        Me.Tv_Complementos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tv_Complementos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tv_Complementos.ContextMenuStrip = Me.Cms_Complementos
        Me.Tv_Complementos.Location = New System.Drawing.Point(12, 78)
        Me.Tv_Complementos.Name = "Tv_Complementos"
        Me.Tv_Complementos.Size = New System.Drawing.Size(624, 328)
        Me.Tv_Complementos.TabIndex = 4
        '
        'Cms_Complementos
        '
        Me.Cms_Complementos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mi_Crear_principal, Me.Mi_Crear_siguiente, Me.Tss_3, Me.Mi_Editar, Me.Mi_Eliminar})
        Me.Cms_Complementos.Name = "Cms_Complementos"
        Me.Cms_Complementos.Size = New System.Drawing.Size(154, 98)
        Me.Cms_Complementos.Text = "Complementos"
        '
        'Mi_Crear_principal
        '
        Me.Mi_Crear_principal.Name = "Mi_Crear_principal"
        Me.Mi_Crear_principal.Size = New System.Drawing.Size(153, 22)
        Me.Mi_Crear_principal.Text = "Crear principal"
        '
        'Mi_Crear_siguiente
        '
        Me.Mi_Crear_siguiente.Name = "Mi_Crear_siguiente"
        Me.Mi_Crear_siguiente.Size = New System.Drawing.Size(153, 22)
        Me.Mi_Crear_siguiente.Text = "Crear siguiente"
        '
        'Tss_3
        '
        Me.Tss_3.Name = "Tss_3"
        Me.Tss_3.Size = New System.Drawing.Size(150, 6)
        '
        'Mi_Editar
        '
        Me.Mi_Editar.Name = "Mi_Editar"
        Me.Mi_Editar.Size = New System.Drawing.Size(153, 22)
        Me.Mi_Editar.Text = "Editar"
        '
        'Mi_Eliminar
        '
        Me.Mi_Eliminar.Name = "Mi_Eliminar"
        Me.Mi_Eliminar.Size = New System.Drawing.Size(153, 22)
        Me.Mi_Eliminar.Text = "Eliminar"
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Nuevo, Me.BBI_Guardar, Me.BBI_Cancelar, Me.BBI_Editar, Me.BBI_Eliminar, Me.BBI_Buscar})
        Me.BarManager.MainMenu = Me.Bar1
        Me.BarManager.MaxItemId = 14
        '
        'Bar1
        '
        Me.Bar1.BarName = "Menú"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Nuevo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Guardar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Cancelar), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Editar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Eliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Buscar, True)})
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Menú"
        '
        'BBI_Nuevo
        '
        Me.BBI_Nuevo.Caption = "Nuevo"
        Me.BBI_Nuevo.Id = 8
        Me.BBI_Nuevo.ImageOptions.Image = CType(resources.GetObject("BBI_Nuevo.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Nuevo.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Nuevo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Nuevo.Name = "BBI_Nuevo"
        '
        'BBI_Guardar
        '
        Me.BBI_Guardar.Caption = "Guardar"
        Me.BBI_Guardar.Id = 9
        Me.BBI_Guardar.ImageOptions.Image = CType(resources.GetObject("BBI_Guardar.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Guardar.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Guardar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Guardar.Name = "BBI_Guardar"
        '
        'BBI_Cancelar
        '
        Me.BBI_Cancelar.Caption = "Cancelar"
        Me.BBI_Cancelar.Id = 10
        Me.BBI_Cancelar.ImageOptions.Image = CType(resources.GetObject("BBI_Cancelar.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Cancelar.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Cancelar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Cancelar.Name = "BBI_Cancelar"
        '
        'BBI_Editar
        '
        Me.BBI_Editar.Caption = "Editar"
        Me.BBI_Editar.Id = 11
        Me.BBI_Editar.ImageOptions.Image = CType(resources.GetObject("BBI_Editar.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Editar.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Editar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Editar.Name = "BBI_Editar"
        '
        'BBI_Eliminar
        '
        Me.BBI_Eliminar.Caption = "Eliminar"
        Me.BBI_Eliminar.Id = 12
        Me.BBI_Eliminar.ImageOptions.Image = CType(resources.GetObject("BBI_Eliminar.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Eliminar.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Eliminar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Eliminar.Name = "BBI_Eliminar"
        '
        'BBI_Buscar
        '
        Me.BBI_Buscar.Caption = "Buscar"
        Me.BBI_Buscar.Id = 13
        Me.BBI_Buscar.ImageOptions.Image = CType(resources.GetObject("BBI_Buscar.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Buscar.ImageOptions.LargeImage = CType(resources.GetObject("BBI_Buscar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_Buscar.Name = "BBI_Buscar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(648, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 418)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(648, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 392)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(648, 26)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 392)
        '
        'Complementos_del_puesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 418)
        Me.Controls.Add(Me.Tv_Complementos)
        Me.Controls.Add(Me.TE_Descripción)
        Me.Controls.Add(Me.LC_Descripción)
        Me.Controls.Add(Me.TE_Código)
        Me.Controls.Add(Me.LC_Código)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Complementos_del_puesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Complementos del puesto"
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Código.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Descripción.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Complementos.ResumeLayout(False)
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Menú As DevExpress.XtraBars.Bar
    Friend WithEvents DxErrorProvider As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents TE_Código As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LC_Código As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TE_Descripción As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LC_Descripción As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Tv_Complementos As TreeView
    Friend WithEvents Cms_Complementos As ContextMenuStrip
    Friend WithEvents Mi_Crear_principal As ToolStripMenuItem
    Friend WithEvents Mi_Crear_siguiente As ToolStripMenuItem
    Friend WithEvents Tss_3 As ToolStripSeparator
    Friend WithEvents Mi_Editar As ToolStripMenuItem
    Friend WithEvents Mi_Eliminar As ToolStripMenuItem
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BBI_Nuevo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Guardar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Cancelar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Editar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Eliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Buscar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
End Class
