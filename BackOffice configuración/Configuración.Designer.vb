<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Configuración
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuración))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BBI_Grupo_de_empresas = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Empresa = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Sub_empresa = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Complementos_del_puesto = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Perfil_del_puesto = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Tipos_de_mercaderia = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Usuario = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Directorios_matrices = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Directorios_para_adjuntos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_seguimientos_y_correos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Contraseñas = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Tipos_de_moneda = New DevExpress.XtraBars.BarButtonItem()
        Me.RP_Mantenimiento = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RP_Empresa = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Tipos_de_movimientos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Complementos_del_puesto = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Usuario = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Directorios = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPB_Seguimientos_y_correos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RP_Administrador = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_Administrador = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.DocumentManager = New DevExpress.XtraBars.Docking2010.DocumentManager()
        Me.TabbedView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BBI_Grupo_de_empresas, Me.BBI_Empresa, Me.BBI_Sub_empresa, Me.BBI_Complementos_del_puesto, Me.BBI_Perfil_del_puesto, Me.BBI_Tipos_de_mercaderia, Me.BBI_Usuario, Me.BBI_Directorios_matrices, Me.BBI_Directorios_para_adjuntos, Me.BBI_seguimientos_y_correos, Me.BBI_Contraseñas, Me.BBI_Tipos_de_moneda})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 15
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RP_Mantenimiento, Me.RP_Administrador})
        Me.RibbonControl.Size = New System.Drawing.Size(893, 146)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BBI_Grupo_de_empresas
        '
        Me.BBI_Grupo_de_empresas.Caption = "Grupo de empresas"
        Me.BBI_Grupo_de_empresas.Id = 1
        Me.BBI_Grupo_de_empresas.ImageOptions.Image = CType(resources.GetObject("BBI_Grupo_de_empresas.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Grupo_de_empresas.Name = "BBI_Grupo_de_empresas"
        '
        'BBI_Empresa
        '
        Me.BBI_Empresa.Caption = "Empresa"
        Me.BBI_Empresa.Id = 2
        Me.BBI_Empresa.ImageOptions.Image = CType(resources.GetObject("BBI_Empresa.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Empresa.Name = "BBI_Empresa"
        '
        'BBI_Sub_empresa
        '
        Me.BBI_Sub_empresa.Caption = "Sub empresa"
        Me.BBI_Sub_empresa.Id = 3
        Me.BBI_Sub_empresa.ImageOptions.Image = CType(resources.GetObject("BBI_Sub_empresa.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Sub_empresa.Name = "BBI_Sub_empresa"
        '
        'BBI_Complementos_del_puesto
        '
        Me.BBI_Complementos_del_puesto.Caption = "Complementos del puesto"
        Me.BBI_Complementos_del_puesto.Id = 4
        Me.BBI_Complementos_del_puesto.ImageOptions.Image = CType(resources.GetObject("BBI_Complementos_del_puesto.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Complementos_del_puesto.Name = "BBI_Complementos_del_puesto"
        '
        'BBI_Perfil_del_puesto
        '
        Me.BBI_Perfil_del_puesto.Caption = "Perfil del puesto"
        Me.BBI_Perfil_del_puesto.Id = 5
        Me.BBI_Perfil_del_puesto.ImageOptions.Image = CType(resources.GetObject("BBI_Perfil_del_puesto.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Perfil_del_puesto.Name = "BBI_Perfil_del_puesto"
        '
        'BBI_Tipos_de_mercaderia
        '
        Me.BBI_Tipos_de_mercaderia.Caption = "Tipos de mercaderia"
        Me.BBI_Tipos_de_mercaderia.Id = 6
        Me.BBI_Tipos_de_mercaderia.ImageOptions.Image = CType(resources.GetObject("BBI_Tipos_de_mercaderia.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Tipos_de_mercaderia.Name = "BBI_Tipos_de_mercaderia"
        '
        'BBI_Usuario
        '
        Me.BBI_Usuario.Caption = "Usuario"
        Me.BBI_Usuario.Id = 7
        Me.BBI_Usuario.ImageOptions.Image = CType(resources.GetObject("BBI_Usuario.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Usuario.Name = "BBI_Usuario"
        '
        'BBI_Directorios_matrices
        '
        Me.BBI_Directorios_matrices.Caption = "Directorios matrices"
        Me.BBI_Directorios_matrices.Id = 8
        Me.BBI_Directorios_matrices.ImageOptions.Image = CType(resources.GetObject("BBI_Directorios_matrices.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Directorios_matrices.Name = "BBI_Directorios_matrices"
        '
        'BBI_Directorios_para_adjuntos
        '
        Me.BBI_Directorios_para_adjuntos.Caption = "Directorios para adjuntos"
        Me.BBI_Directorios_para_adjuntos.Id = 9
        Me.BBI_Directorios_para_adjuntos.ImageOptions.Image = CType(resources.GetObject("BBI_Directorios_para_adjuntos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Directorios_para_adjuntos.Name = "BBI_Directorios_para_adjuntos"
        Me.BBI_Directorios_para_adjuntos.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'BBI_seguimientos_y_correos
        '
        Me.BBI_seguimientos_y_correos.Caption = "Seguimientos y correos"
        Me.BBI_seguimientos_y_correos.Id = 10
        Me.BBI_seguimientos_y_correos.ImageOptions.Image = CType(resources.GetObject("BBI_seguimientos_y_correos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_seguimientos_y_correos.Name = "BBI_seguimientos_y_correos"
        '
        'BBI_Contraseñas
        '
        Me.BBI_Contraseñas.Caption = "Contraseñas"
        Me.BBI_Contraseñas.Id = 11
        Me.BBI_Contraseñas.ImageOptions.Image = CType(resources.GetObject("BBI_Contraseñas.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Contraseñas.Name = "BBI_Contraseñas"
        '
        'BBI_Tipos_de_moneda
        '
        Me.BBI_Tipos_de_moneda.Caption = "Tipos de moneda"
        Me.BBI_Tipos_de_moneda.Id = 14
        Me.BBI_Tipos_de_moneda.ImageOptions.Image = CType(resources.GetObject("BBI_Tipos_de_moneda.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Tipos_de_moneda.Name = "BBI_Tipos_de_moneda"
        '
        'RP_Mantenimiento
        '
        Me.RP_Mantenimiento.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RP_Empresa, Me.RPG_Complementos_del_puesto, Me.RPG_Usuario, Me.RPG_Tipos_de_movimientos, Me.RPG_Directorios, Me.RPB_Seguimientos_y_correos})
        Me.RP_Mantenimiento.Name = "RP_Mantenimiento"
        Me.RP_Mantenimiento.Text = "Mantenimiento"
        '
        'RP_Empresa
        '
        Me.RP_Empresa.ItemLinks.Add(Me.BBI_Grupo_de_empresas)
        Me.RP_Empresa.ItemLinks.Add(Me.BBI_Empresa)
        Me.RP_Empresa.ItemLinks.Add(Me.BBI_Sub_empresa)
        Me.RP_Empresa.Name = "RP_Empresa"
        Me.RP_Empresa.Text = "Empresa"
        '
        'RPG_Tipos_de_movimientos
        '
        Me.RPG_Tipos_de_movimientos.ItemLinks.Add(Me.BBI_Tipos_de_mercaderia)
        Me.RPG_Tipos_de_movimientos.ItemLinks.Add(Me.BBI_Tipos_de_moneda)
        Me.RPG_Tipos_de_movimientos.Name = "RPG_Tipos_de_movimientos"
        Me.RPG_Tipos_de_movimientos.Text = "Tipos de movimientos"
        '
        'RPG_Complementos_del_puesto
        '
        Me.RPG_Complementos_del_puesto.ItemLinks.Add(Me.BBI_Complementos_del_puesto)
        Me.RPG_Complementos_del_puesto.ItemLinks.Add(Me.BBI_Perfil_del_puesto)
        Me.RPG_Complementos_del_puesto.Name = "RPG_Complementos_del_puesto"
        Me.RPG_Complementos_del_puesto.Text = "Complementos del puesto"
        '
        'RPG_Usuario
        '
        Me.RPG_Usuario.ItemLinks.Add(Me.BBI_Usuario)
        Me.RPG_Usuario.Name = "RPG_Usuario"
        Me.RPG_Usuario.Text = "Usuario"
        '
        'RPG_Directorios
        '
        Me.RPG_Directorios.ItemLinks.Add(Me.BBI_Directorios_matrices)
        Me.RPG_Directorios.ItemLinks.Add(Me.BBI_Directorios_para_adjuntos)
        Me.RPG_Directorios.Name = "RPG_Directorios"
        Me.RPG_Directorios.Text = "Directorios"
        '
        'RPB_Seguimientos_y_correos
        '
        Me.RPB_Seguimientos_y_correos.ItemLinks.Add(Me.BBI_seguimientos_y_correos)
        Me.RPB_Seguimientos_y_correos.Name = "RPB_Seguimientos_y_correos"
        Me.RPB_Seguimientos_y_correos.Text = "Seguimientos y correos"
        '
        'RP_Administrador
        '
        Me.RP_Administrador.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_Administrador})
        Me.RP_Administrador.Name = "RP_Administrador"
        Me.RP_Administrador.Text = "Administrador"
        '
        'RPG_Administrador
        '
        Me.RPG_Administrador.ItemLinks.Add(Me.BBI_Contraseñas)
        Me.RPG_Administrador.Name = "RPG_Administrador"
        Me.RPG_Administrador.Text = "Administrador"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 634)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(893, 21)
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'DocumentManager
        '
        Me.DocumentManager.MaxThumbnailCount = 25
        Me.DocumentManager.MdiParent = Me
        Me.DocumentManager.MenuManager = Me.RibbonControl
        Me.DocumentManager.View = Me.TabbedView
        Me.DocumentManager.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView})
        '
        'Configuración
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 655)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "Configuración"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Configuración"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RP_Mantenimiento As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RP_Empresa As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents BBI_Grupo_de_empresas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Empresa As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Sub_empresa As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Complementos_del_puesto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Perfil_del_puesto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Tipos_de_mercaderia As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Usuario As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Directorios_matrices As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Directorios_para_adjuntos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_seguimientos_y_correos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Contraseñas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_Tipos_de_movimientos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RPG_Complementos_del_puesto As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RPG_Usuario As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RPG_Directorios As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RPB_Seguimientos_y_correos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RP_Administrador As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_Administrador As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents DocumentManager As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabbedView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents BBI_Tipos_de_moneda As DevExpress.XtraBars.BarButtonItem
End Class
