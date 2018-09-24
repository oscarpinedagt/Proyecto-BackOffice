<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Empresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Empresa))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Menú = New DevExpress.XtraBars.Bar()
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
        Me.LC_Grupo_de_empresas = New DevExpress.XtraEditors.LabelControl()
        Me.PE_Imágen = New DevExpress.XtraEditors.PictureEdit()
        Me.LC_Imágen = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Nit = New DevExpress.XtraEditors.LabelControl()
        Me.LC_Literales = New DevExpress.XtraEditors.LabelControl()
        Me.TE_Nit = New DevExpress.XtraEditors.TextEdit()
        Me.TE_Literales = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Razón_social = New DevExpress.XtraEditors.LabelControl()
        Me.TE_Razón_social = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Razón_comercial = New DevExpress.XtraEditors.LabelControl()
        Me.TE_Razón_comercial = New DevExpress.XtraEditors.TextEdit()
        Me.LC_Domicilio_fiscal = New DevExpress.XtraEditors.LabelControl()
        Me.TE_Domicilio_fiscal = New DevExpress.XtraEditors.TextEdit()
        Me.LUE_Grupo_de_empresas = New DevExpress.XtraEditors.LookUpEdit()
        Me.DxErrorProvider = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PE_Imágen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Nit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Literales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Razón_social.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Razón_comercial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TE_Domicilio_fiscal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUE_Grupo_de_empresas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBI_Nuevo, Me.BBI_Guardar, Me.BBI_Cancelar, Me.BBI_Editar, Me.BBI_Eliminar, Me.BBI_Buscar})
        Me.BarManager.MainMenu = Me.Menú
        Me.BarManager.MaxItemId = 14
        '
        'Menú
        '
        Me.Menú.BarName = "Menú"
        Me.Menú.DockCol = 0
        Me.Menú.DockRow = 0
        Me.Menú.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Menú.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Nuevo, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Guardar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Cancelar), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Editar, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Eliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.BBI_Buscar, True)})
        Me.Menú.OptionsBar.UseWholeRow = True
        Me.Menú.Text = "Menú"
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
        Me.barDockControlTop.Size = New System.Drawing.Size(639, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 282)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(639, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 256)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(639, 26)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 256)
        '
        'LC_Grupo_de_empresas
        '
        Me.LC_Grupo_de_empresas.Location = New System.Drawing.Point(12, 41)
        Me.LC_Grupo_de_empresas.Name = "LC_Grupo_de_empresas"
        Me.LC_Grupo_de_empresas.Size = New System.Drawing.Size(93, 13)
        Me.LC_Grupo_de_empresas.TabIndex = 0
        Me.LC_Grupo_de_empresas.Text = "Grupo de empresas"
        '
        'PE_Imágen
        '
        Me.PE_Imágen.Location = New System.Drawing.Point(316, 60)
        Me.PE_Imágen.MenuManager = Me.BarManager
        Me.PE_Imágen.Name = "PE_Imágen"
        Me.PE_Imágen.Properties.NullText = "Sin imágen"
        Me.PE_Imágen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PE_Imágen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PE_Imágen.Size = New System.Drawing.Size(311, 204)
        Me.PE_Imágen.TabIndex = 13
        '
        'LC_Imágen
        '
        Me.LC_Imágen.Location = New System.Drawing.Point(316, 41)
        Me.LC_Imágen.Name = "LC_Imágen"
        Me.LC_Imágen.Size = New System.Drawing.Size(36, 13)
        Me.LC_Imágen.TabIndex = 12
        Me.LC_Imágen.Text = "Imágen"
        '
        'LC_Nit
        '
        Me.LC_Nit.Location = New System.Drawing.Point(12, 86)
        Me.LC_Nit.Name = "LC_Nit"
        Me.LC_Nit.Size = New System.Drawing.Size(13, 13)
        Me.LC_Nit.TabIndex = 2
        Me.LC_Nit.Text = "Nit"
        '
        'LC_Literales
        '
        Me.LC_Literales.Location = New System.Drawing.Point(169, 86)
        Me.LC_Literales.Name = "LC_Literales"
        Me.LC_Literales.Size = New System.Drawing.Size(40, 13)
        Me.LC_Literales.TabIndex = 4
        Me.LC_Literales.Text = "Literales"
        '
        'TE_Nit
        '
        Me.TE_Nit.Location = New System.Drawing.Point(12, 106)
        Me.TE_Nit.MenuManager = Me.BarManager
        Me.TE_Nit.Name = "TE_Nit"
        Me.TE_Nit.Properties.Appearance.Options.UseTextOptions = True
        Me.TE_Nit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TE_Nit.Properties.NullValuePrompt = "Nit"
        Me.TE_Nit.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Nit.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Nit.Size = New System.Drawing.Size(151, 20)
        Me.TE_Nit.TabIndex = 3
        '
        'TE_Literales
        '
        Me.TE_Literales.Location = New System.Drawing.Point(169, 106)
        Me.TE_Literales.MenuManager = Me.BarManager
        Me.TE_Literales.Name = "TE_Literales"
        Me.TE_Literales.Properties.NullValuePrompt = "Literales"
        Me.TE_Literales.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Literales.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Literales.Size = New System.Drawing.Size(141, 20)
        Me.TE_Literales.TabIndex = 5
        '
        'LC_Razón_social
        '
        Me.LC_Razón_social.Location = New System.Drawing.Point(13, 132)
        Me.LC_Razón_social.Name = "LC_Razón_social"
        Me.LC_Razón_social.Size = New System.Drawing.Size(59, 13)
        Me.LC_Razón_social.TabIndex = 6
        Me.LC_Razón_social.Text = "Razón social"
        '
        'TE_Razón_social
        '
        Me.TE_Razón_social.Location = New System.Drawing.Point(12, 152)
        Me.TE_Razón_social.Name = "TE_Razón_social"
        Me.TE_Razón_social.Properties.NullValuePrompt = "Razón social"
        Me.TE_Razón_social.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Razón_social.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Razón_social.Size = New System.Drawing.Size(298, 20)
        Me.TE_Razón_social.TabIndex = 7
        '
        'LC_Razón_comercial
        '
        Me.LC_Razón_comercial.Location = New System.Drawing.Point(13, 178)
        Me.LC_Razón_comercial.Name = "LC_Razón_comercial"
        Me.LC_Razón_comercial.Size = New System.Drawing.Size(77, 13)
        Me.LC_Razón_comercial.TabIndex = 8
        Me.LC_Razón_comercial.Text = "Razón comercial"
        '
        'TE_Razón_comercial
        '
        Me.TE_Razón_comercial.Location = New System.Drawing.Point(12, 198)
        Me.TE_Razón_comercial.Name = "TE_Razón_comercial"
        Me.TE_Razón_comercial.Properties.NullValuePrompt = "Razón comercial"
        Me.TE_Razón_comercial.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Razón_comercial.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Razón_comercial.Size = New System.Drawing.Size(298, 20)
        Me.TE_Razón_comercial.TabIndex = 9
        '
        'LC_Domicilio_fiscal
        '
        Me.LC_Domicilio_fiscal.Location = New System.Drawing.Point(14, 224)
        Me.LC_Domicilio_fiscal.Name = "LC_Domicilio_fiscal"
        Me.LC_Domicilio_fiscal.Size = New System.Drawing.Size(67, 13)
        Me.LC_Domicilio_fiscal.TabIndex = 10
        Me.LC_Domicilio_fiscal.Text = "Domicilio fiscal"
        '
        'TE_Domicilio_fiscal
        '
        Me.TE_Domicilio_fiscal.Location = New System.Drawing.Point(12, 244)
        Me.TE_Domicilio_fiscal.Name = "TE_Domicilio_fiscal"
        Me.TE_Domicilio_fiscal.Properties.NullValuePrompt = "Domicilio fiscal"
        Me.TE_Domicilio_fiscal.Properties.NullValuePromptShowForEmptyValue = True
        Me.TE_Domicilio_fiscal.Properties.ShowNullValuePromptWhenFocused = True
        Me.TE_Domicilio_fiscal.Size = New System.Drawing.Size(298, 20)
        Me.TE_Domicilio_fiscal.TabIndex = 11
        '
        'LUE_Grupo_de_empresas
        '
        Me.LUE_Grupo_de_empresas.Location = New System.Drawing.Point(12, 61)
        Me.LUE_Grupo_de_empresas.MenuManager = Me.BarManager
        Me.LUE_Grupo_de_empresas.Name = "LUE_Grupo_de_empresas"
        Me.LUE_Grupo_de_empresas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LUE_Grupo_de_empresas.Properties.NullText = ""
        Me.LUE_Grupo_de_empresas.Properties.NullValuePrompt = "Grupo de empresas"
        Me.LUE_Grupo_de_empresas.Properties.NullValuePromptShowForEmptyValue = True
        Me.LUE_Grupo_de_empresas.Properties.ShowNullValuePromptWhenFocused = True
        Me.LUE_Grupo_de_empresas.Size = New System.Drawing.Size(298, 20)
        Me.LUE_Grupo_de_empresas.TabIndex = 1
        '
        'DxErrorProvider
        '
        Me.DxErrorProvider.ContainerControl = Me
        '
        'Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 282)
        Me.Controls.Add(Me.LUE_Grupo_de_empresas)
        Me.Controls.Add(Me.TE_Literales)
        Me.Controls.Add(Me.TE_Domicilio_fiscal)
        Me.Controls.Add(Me.TE_Razón_comercial)
        Me.Controls.Add(Me.TE_Razón_social)
        Me.Controls.Add(Me.TE_Nit)
        Me.Controls.Add(Me.LC_Literales)
        Me.Controls.Add(Me.LC_Domicilio_fiscal)
        Me.Controls.Add(Me.LC_Razón_comercial)
        Me.Controls.Add(Me.LC_Razón_social)
        Me.Controls.Add(Me.LC_Nit)
        Me.Controls.Add(Me.LC_Imágen)
        Me.Controls.Add(Me.PE_Imágen)
        Me.Controls.Add(Me.LC_Grupo_de_empresas)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Empresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresa"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PE_Imágen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Nit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Literales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Razón_social.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Razón_comercial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TE_Domicilio_fiscal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUE_Grupo_de_empresas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Menú As DevExpress.XtraBars.Bar
    Friend WithEvents BBI_Nuevo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Guardar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Cancelar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Editar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Eliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Buscar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TE_Literales As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Domicilio_fiscal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Razón_comercial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Razón_social As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TE_Nit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LC_Literales As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Domicilio_fiscal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Razón_comercial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Razón_social As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Nit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LC_Imágen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PE_Imágen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LC_Grupo_de_empresas As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LUE_Grupo_de_empresas As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DxErrorProvider As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
End Class
