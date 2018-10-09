<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Costos_e_Importaciones
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Costos_e_Importaciones))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BBI_MAN_Envió_de_costeos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Seguimiento_de_costeos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Tipos_de_costeo = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Incoterms = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MOV_Recepción = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MOV_Elaboración = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Recepción = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Elaboración = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Envió = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Shipper_o_Carrier = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Proveedores_locales = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_RP_Seguro = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MAN_Tipos_de_gasto = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Mercadería_en_transito = New DevExpress.XtraBars.BarButtonItem()
        Me.RP_Movimientos = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_MOV_Costeos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RP_Seguimientos = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_SEG_Costeos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Mercadería_en_transito = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RP_Reportes = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_Seguro = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RP_Mantenimiento = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_Correos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Proveedores = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_MAN_Costeos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.DocumentManager = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.TabbedView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.NoDocumentsView1 = New DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView(Me.components)
        Me.RPG_Control_de_IPRIMA = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BBI_SEG_Control_de_IPRIMA = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoDocumentsView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BBI_MAN_Envió_de_costeos, Me.BBI_MAN_Seguimiento_de_costeos, Me.BBI_MAN_Tipos_de_costeo, Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables, Me.BBI_MAN_Incoterms, Me.BBI_MOV_Recepción, Me.BBI_MOV_Elaboración, Me.BBI_SEG_Recepción, Me.BBI_SEG_Elaboración, Me.BBI_SEG_Envió, Me.BBI_MAN_Shipper_o_Carrier, Me.BBI_MAN_Proveedores_locales, Me.BBI_RP_Seguro, Me.BBI_MAN_Tipos_de_gasto, Me.BBI_SEG_Mercadería_en_transito, Me.BBI_SEG_Control_de_IPRIMA})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 17
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RP_Movimientos, Me.RP_Seguimientos, Me.RP_Reportes, Me.RP_Mantenimiento})
        Me.RibbonControl.Size = New System.Drawing.Size(893, 146)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BBI_MAN_Envió_de_costeos
        '
        Me.BBI_MAN_Envió_de_costeos.Caption = "Envió de costeos"
        Me.BBI_MAN_Envió_de_costeos.Id = 1
        Me.BBI_MAN_Envió_de_costeos.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Envió_de_costeos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Envió_de_costeos.Name = "BBI_MAN_Envió_de_costeos"
        Me.BBI_MAN_Envió_de_costeos.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_MAN_Seguimiento_de_costeos
        '
        Me.BBI_MAN_Seguimiento_de_costeos.Caption = "Seguimiento de costeos"
        Me.BBI_MAN_Seguimiento_de_costeos.Id = 2
        Me.BBI_MAN_Seguimiento_de_costeos.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Seguimiento_de_costeos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Seguimiento_de_costeos.Name = "BBI_MAN_Seguimiento_de_costeos"
        Me.BBI_MAN_Seguimiento_de_costeos.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_MAN_Tipos_de_costeo
        '
        Me.BBI_MAN_Tipos_de_costeo.Caption = "Tipos de costeo"
        Me.BBI_MAN_Tipos_de_costeo.Id = 3
        Me.BBI_MAN_Tipos_de_costeo.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Tipos_de_costeo.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Tipos_de_costeo.Name = "BBI_MAN_Tipos_de_costeo"
        '
        'BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables
        '
        Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.Caption = "Proveedores del exterior, cuentas y complementos contables"
        Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.Id = 4
        Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.ImageOptions.Im" &
        "age"), System.Drawing.Image)
        Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.Name = "BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables"
        Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_MAN_Incoterms
        '
        Me.BBI_MAN_Incoterms.Caption = "Incoterms"
        Me.BBI_MAN_Incoterms.Id = 5
        Me.BBI_MAN_Incoterms.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Incoterms.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Incoterms.Name = "BBI_MAN_Incoterms"
        '
        'BBI_MOV_Recepción
        '
        Me.BBI_MOV_Recepción.Caption = "Recepción"
        Me.BBI_MOV_Recepción.Id = 6
        Me.BBI_MOV_Recepción.ImageOptions.Image = CType(resources.GetObject("BBI_MOV_Recepción.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MOV_Recepción.Name = "BBI_MOV_Recepción"
        Me.BBI_MOV_Recepción.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_MOV_Elaboración
        '
        Me.BBI_MOV_Elaboración.Caption = "Elaboración"
        Me.BBI_MOV_Elaboración.Id = 7
        Me.BBI_MOV_Elaboración.ImageOptions.Image = CType(resources.GetObject("BBI_MOV_Elaboración.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MOV_Elaboración.Name = "BBI_MOV_Elaboración"
        Me.BBI_MOV_Elaboración.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_SEG_Recepción
        '
        Me.BBI_SEG_Recepción.Caption = "Recepción"
        Me.BBI_SEG_Recepción.Id = 8
        Me.BBI_SEG_Recepción.ImageOptions.Image = CType(resources.GetObject("BBI_SEG_Recepción.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_SEG_Recepción.Name = "BBI_SEG_Recepción"
        Me.BBI_SEG_Recepción.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_SEG_Elaboración
        '
        Me.BBI_SEG_Elaboración.Caption = "Elaboración"
        Me.BBI_SEG_Elaboración.Id = 9
        Me.BBI_SEG_Elaboración.ImageOptions.Image = CType(resources.GetObject("BBI_SEG_Elaboración.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_SEG_Elaboración.Name = "BBI_SEG_Elaboración"
        Me.BBI_SEG_Elaboración.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_SEG_Envió
        '
        Me.BBI_SEG_Envió.Caption = "Envió"
        Me.BBI_SEG_Envió.Id = 10
        Me.BBI_SEG_Envió.ImageOptions.Image = CType(resources.GetObject("BBI_SEG_Envió.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_SEG_Envió.Name = "BBI_SEG_Envió"
        Me.BBI_SEG_Envió.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_MAN_Shipper_o_Carrier
        '
        Me.BBI_MAN_Shipper_o_Carrier.Caption = "Shipper o Carrier"
        Me.BBI_MAN_Shipper_o_Carrier.Id = 11
        Me.BBI_MAN_Shipper_o_Carrier.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Shipper_o_Carrier.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Shipper_o_Carrier.Name = "BBI_MAN_Shipper_o_Carrier"
        '
        'BBI_MAN_Proveedores_locales
        '
        Me.BBI_MAN_Proveedores_locales.Caption = "Proveedores locales"
        Me.BBI_MAN_Proveedores_locales.Id = 12
        Me.BBI_MAN_Proveedores_locales.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Proveedores_locales.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Proveedores_locales.Name = "BBI_MAN_Proveedores_locales"
        '
        'BBI_RP_Seguro
        '
        Me.BBI_RP_Seguro.Caption = "Seguro"
        Me.BBI_RP_Seguro.Id = 13
        Me.BBI_RP_Seguro.ImageOptions.Image = CType(resources.GetObject("BBI_RP_Seguro.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_RP_Seguro.ImageOptions.LargeImage = CType(resources.GetObject("BBI_RP_Seguro.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_RP_Seguro.Name = "BBI_RP_Seguro"
        '
        'BBI_MAN_Tipos_de_gasto
        '
        Me.BBI_MAN_Tipos_de_gasto.Caption = "Tipos de gasto"
        Me.BBI_MAN_Tipos_de_gasto.Id = 14
        Me.BBI_MAN_Tipos_de_gasto.ImageOptions.Image = CType(resources.GetObject("BBI_MAN_Tipos_de_gasto.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_MAN_Tipos_de_gasto.Name = "BBI_MAN_Tipos_de_gasto"
        '
        'BBI_SEG_Mercadería_en_transito
        '
        Me.BBI_SEG_Mercadería_en_transito.Caption = "Mercadería en transito"
        Me.BBI_SEG_Mercadería_en_transito.Id = 15
        Me.BBI_SEG_Mercadería_en_transito.ImageOptions.Image = CType(resources.GetObject("BBI_SEG_Mercadería_en_transito.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_SEG_Mercadería_en_transito.ImageOptions.LargeImage = CType(resources.GetObject("BBI_SEG_Mercadería_en_transito.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_SEG_Mercadería_en_transito.Name = "BBI_SEG_Mercadería_en_transito"
        '
        'RP_Movimientos
        '
        Me.RP_Movimientos.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_MOV_Costeos})
        Me.RP_Movimientos.Name = "RP_Movimientos"
        Me.RP_Movimientos.Text = "Movimientos"
        '
        'RPG_MOV_Costeos
        '
        Me.RPG_MOV_Costeos.ItemLinks.Add(Me.BBI_MOV_Recepción)
        Me.RPG_MOV_Costeos.ItemLinks.Add(Me.BBI_MOV_Elaboración)
        Me.RPG_MOV_Costeos.Name = "RPG_MOV_Costeos"
        Me.RPG_MOV_Costeos.Text = "Costeos"
        '
        'RP_Seguimientos
        '
        Me.RP_Seguimientos.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_SEG_Costeos, Me.RPG_Mercadería_en_transito, Me.RPG_Control_de_IPRIMA})
        Me.RP_Seguimientos.Name = "RP_Seguimientos"
        Me.RP_Seguimientos.Text = "Seguimientos"
        '
        'RPG_SEG_Costeos
        '
        Me.RPG_SEG_Costeos.ItemLinks.Add(Me.BBI_SEG_Recepción)
        Me.RPG_SEG_Costeos.ItemLinks.Add(Me.BBI_SEG_Elaboración)
        Me.RPG_SEG_Costeos.ItemLinks.Add(Me.BBI_SEG_Envió)
        Me.RPG_SEG_Costeos.Name = "RPG_SEG_Costeos"
        Me.RPG_SEG_Costeos.Text = "Costeos"
        '
        'RPG_Mercadería_en_transito
        '
        Me.RPG_Mercadería_en_transito.AllowTextClipping = False
        Me.RPG_Mercadería_en_transito.ItemLinks.Add(Me.BBI_SEG_Mercadería_en_transito)
        Me.RPG_Mercadería_en_transito.Name = "RPG_Mercadería_en_transito"
        Me.RPG_Mercadería_en_transito.Text = "Mercadería en transito"
        '
        'RP_Reportes
        '
        Me.RP_Reportes.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_Seguro})
        Me.RP_Reportes.Name = "RP_Reportes"
        Me.RP_Reportes.Text = "Reportes"
        '
        'RPG_Seguro
        '
        Me.RPG_Seguro.AllowTextClipping = False
        Me.RPG_Seguro.ItemLinks.Add(Me.BBI_RP_Seguro)
        Me.RPG_Seguro.Name = "RPG_Seguro"
        Me.RPG_Seguro.Text = "Seguro"
        '
        'RP_Mantenimiento
        '
        Me.RP_Mantenimiento.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_Correos, Me.RPG_Proveedores, Me.RPG_MAN_Costeos})
        Me.RP_Mantenimiento.Name = "RP_Mantenimiento"
        Me.RP_Mantenimiento.Text = "Mantenimiento"
        '
        'RPG_Correos
        '
        Me.RPG_Correos.ItemLinks.Add(Me.BBI_MAN_Envió_de_costeos)
        Me.RPG_Correos.ItemLinks.Add(Me.BBI_MAN_Seguimiento_de_costeos)
        Me.RPG_Correos.Name = "RPG_Correos"
        Me.RPG_Correos.Text = "Correos"
        '
        'RPG_Proveedores
        '
        Me.RPG_Proveedores.ItemLinks.Add(Me.BBI_MAN_Shipper_o_Carrier)
        Me.RPG_Proveedores.ItemLinks.Add(Me.BBI_MAN_Proveedores_locales)
        Me.RPG_Proveedores.Name = "RPG_Proveedores"
        Me.RPG_Proveedores.Text = "Proveedores"
        '
        'RPG_MAN_Costeos
        '
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_MAN_Incoterms)
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_MAN_Tipos_de_costeo)
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_MAN_Tipos_de_gasto)
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables)
        Me.RPG_MAN_Costeos.Name = "RPG_MAN_Costeos"
        Me.RPG_MAN_Costeos.Text = "Costeos"
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
        Me.DocumentManager.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView, Me.NoDocumentsView1})
        '
        'RPG_Control_de_IPRIMA
        '
        Me.RPG_Control_de_IPRIMA.AllowTextClipping = False
        Me.RPG_Control_de_IPRIMA.ItemLinks.Add(Me.BBI_SEG_Control_de_IPRIMA)
        Me.RPG_Control_de_IPRIMA.Name = "RPG_Control_de_IPRIMA"
        Me.RPG_Control_de_IPRIMA.Text = "Control de IPRIMA"
        '
        'BBI_SEG_Control_de_IPRIMA
        '
        Me.BBI_SEG_Control_de_IPRIMA.Caption = "Control de IPRIMA"
        Me.BBI_SEG_Control_de_IPRIMA.Id = 16
        Me.BBI_SEG_Control_de_IPRIMA.ImageOptions.Image = CType(resources.GetObject("BBI_SEG_Control_de_IPRIMA.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_SEG_Control_de_IPRIMA.ImageOptions.LargeImage = CType(resources.GetObject("BBI_SEG_Control_de_IPRIMA.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BBI_SEG_Control_de_IPRIMA.Name = "BBI_SEG_Control_de_IPRIMA"
        '
        'Costos_e_Importaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 655)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Costos_e_Importaciones"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Costos e Importaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoDocumentsView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RP_Mantenimiento As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_Correos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents DocumentManager As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents NoDocumentsView1 As DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView
    Friend WithEvents TabbedView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents BBI_MAN_Envió_de_costeos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_MAN_Seguimiento_de_costeos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_MAN_Costeos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_MAN_Tipos_de_costeo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_MAN_Incoterms As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RP_Movimientos As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_MOV_Costeos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_MOV_Recepción As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_MOV_Elaboración As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Recepción As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Elaboración As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Envió As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RP_Seguimientos As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_SEG_Costeos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_MAN_Shipper_o_Carrier As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_MAN_Proveedores_locales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_Proveedores As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_RP_Seguro As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RP_Reportes As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_Seguro As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_MAN_Tipos_de_gasto As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_Mercadería_en_transito As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_SEG_Mercadería_en_transito As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Control_de_IPRIMA As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_Control_de_IPRIMA As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class
