﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Costos_e_Importaciones))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BBI_Envió_de_costeos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Seguimiento_de_costeos = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Tipos_de_costeo = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Proveedores_cuentas_y_complementos_contables = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Incoterms = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_MOV_Recepción = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Elaboración_y_seguimiento = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Recepción = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Elaboración = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_SEG_Envió = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Shipper_Carrier = New DevExpress.XtraBars.BarButtonItem()
        Me.BBI_Proveedores_locales = New DevExpress.XtraBars.BarButtonItem()
        Me.RP_Movimientos = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_MOV_Costeos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RP_Seguimientos = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_SEG_Costeos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RP_Mantenimiento = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RPG_Correos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_Proveedores = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RPG_MAN_Costeos = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.DocumentManager = New DevExpress.XtraBars.Docking2010.DocumentManager()
        Me.TabbedView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView()
        Me.NoDocumentsView1 = New DevExpress.XtraBars.Docking2010.Views.NoDocuments.NoDocumentsView()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoDocumentsView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BBI_Envió_de_costeos, Me.BBI_Seguimiento_de_costeos, Me.BBI_Tipos_de_costeo, Me.BBI_Proveedores_cuentas_y_complementos_contables, Me.BBI_Incoterms, Me.BBI_MOV_Recepción, Me.BBI_Elaboración_y_seguimiento, Me.BBI_SEG_Recepción, Me.BBI_SEG_Elaboración, Me.BBI_SEG_Envió, Me.BBI_Shipper_Carrier, Me.BBI_Proveedores_locales})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 13
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RP_Movimientos, Me.RP_Seguimientos, Me.RP_Mantenimiento})
        Me.RibbonControl.Size = New System.Drawing.Size(893, 146)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BBI_Envió_de_costeos
        '
        Me.BBI_Envió_de_costeos.Caption = "Envió de costeos"
        Me.BBI_Envió_de_costeos.Id = 1
        Me.BBI_Envió_de_costeos.ImageOptions.Image = CType(resources.GetObject("BBI_Envió_de_costeos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Envió_de_costeos.Name = "BBI_Envió_de_costeos"
        Me.BBI_Envió_de_costeos.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_Seguimiento_de_costeos
        '
        Me.BBI_Seguimiento_de_costeos.Caption = "Seguimiento de costeos"
        Me.BBI_Seguimiento_de_costeos.Id = 2
        Me.BBI_Seguimiento_de_costeos.ImageOptions.Image = CType(resources.GetObject("BBI_Seguimiento_de_costeos.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Seguimiento_de_costeos.Name = "BBI_Seguimiento_de_costeos"
        Me.BBI_Seguimiento_de_costeos.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_Tipos_de_costeo
        '
        Me.BBI_Tipos_de_costeo.Caption = "Tipos de costeo"
        Me.BBI_Tipos_de_costeo.Id = 3
        Me.BBI_Tipos_de_costeo.ImageOptions.Image = CType(resources.GetObject("BBI_Tipos_de_costeo.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Tipos_de_costeo.Name = "BBI_Tipos_de_costeo"
        '
        'BBI_Proveedores_cuentas_y_complementos_contables
        '
        Me.BBI_Proveedores_cuentas_y_complementos_contables.Caption = "Proveedores, cuentas y complementos contables"
        Me.BBI_Proveedores_cuentas_y_complementos_contables.Id = 4
        Me.BBI_Proveedores_cuentas_y_complementos_contables.ImageOptions.Image = CType(resources.GetObject("BBI_Proveedores_cuentas_y_complementos_contables.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Proveedores_cuentas_y_complementos_contables.Name = "BBI_Proveedores_cuentas_y_complementos_contables"
        Me.BBI_Proveedores_cuentas_y_complementos_contables.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
            Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BBI_Incoterms
        '
        Me.BBI_Incoterms.Caption = "Incoterms"
        Me.BBI_Incoterms.Id = 5
        Me.BBI_Incoterms.ImageOptions.Image = CType(resources.GetObject("BBI_Incoterms.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Incoterms.Name = "BBI_Incoterms"
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
        'BBI_Elaboración_y_seguimiento
        '
        Me.BBI_Elaboración_y_seguimiento.Caption = "Elaboración y seguimiento de costeos"
        Me.BBI_Elaboración_y_seguimiento.Id = 7
        Me.BBI_Elaboración_y_seguimiento.ImageOptions.Image = CType(resources.GetObject("BBI_Elaboración_y_seguimiento.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Elaboración_y_seguimiento.Name = "BBI_Elaboración_y_seguimiento"
        Me.BBI_Elaboración_y_seguimiento.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
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
        'BBI_Shipper_Carrier
        '
        Me.BBI_Shipper_Carrier.Caption = "Shipper o Carrier"
        Me.BBI_Shipper_Carrier.Id = 11
        Me.BBI_Shipper_Carrier.ImageOptions.Image = CType(resources.GetObject("BBI_Shipper_Carrier.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Shipper_Carrier.Name = "BBI_Shipper_Carrier"
        '
        'BBI_Proveedores_locales
        '
        Me.BBI_Proveedores_locales.Caption = "Proveedores locales"
        Me.BBI_Proveedores_locales.Id = 12
        Me.BBI_Proveedores_locales.ImageOptions.Image = CType(resources.GetObject("BBI_Proveedores_locales.ImageOptions.Image"), System.Drawing.Image)
        Me.BBI_Proveedores_locales.Name = "BBI_Proveedores_locales"
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
        Me.RPG_MOV_Costeos.ItemLinks.Add(Me.BBI_Elaboración_y_seguimiento)
        Me.RPG_MOV_Costeos.Name = "RPG_MOV_Costeos"
        Me.RPG_MOV_Costeos.Text = "Costeos"
        '
        'RP_Seguimientos
        '
        Me.RP_Seguimientos.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_SEG_Costeos})
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
        'RP_Mantenimiento
        '
        Me.RP_Mantenimiento.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RPG_Correos, Me.RPG_Proveedores, Me.RPG_MAN_Costeos})
        Me.RP_Mantenimiento.Name = "RP_Mantenimiento"
        Me.RP_Mantenimiento.Text = "Mantenimiento"
        '
        'RPG_Correos
        '
        Me.RPG_Correos.ItemLinks.Add(Me.BBI_Envió_de_costeos)
        Me.RPG_Correos.ItemLinks.Add(Me.BBI_Seguimiento_de_costeos)
        Me.RPG_Correos.Name = "RPG_Correos"
        Me.RPG_Correos.Text = "Correos"
        '
        'RPG_Proveedores
        '
        Me.RPG_Proveedores.ItemLinks.Add(Me.BBI_Shipper_Carrier)
        Me.RPG_Proveedores.ItemLinks.Add(Me.BBI_Proveedores_locales)
        Me.RPG_Proveedores.Name = "RPG_Proveedores"
        Me.RPG_Proveedores.Text = "Proveedores"
        '
        'RPG_MAN_Costeos
        '
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_Incoterms)
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_Tipos_de_costeo)
        Me.RPG_MAN_Costeos.ItemLinks.Add(Me.BBI_Proveedores_cuentas_y_complementos_contables)
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
    Friend WithEvents BBI_Envió_de_costeos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Seguimiento_de_costeos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_MAN_Costeos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_Tipos_de_costeo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Proveedores_cuentas_y_complementos_contables As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Incoterms As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RP_Movimientos As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_MOV_Costeos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_MOV_Recepción As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Elaboración_y_seguimiento As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Recepción As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Elaboración As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_SEG_Envió As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RP_Seguimientos As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RPG_SEG_Costeos As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BBI_Shipper_Carrier As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBI_Proveedores_locales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RPG_Proveedores As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class