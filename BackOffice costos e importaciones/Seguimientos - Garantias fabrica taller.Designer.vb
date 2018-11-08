<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seguimientos_Garantias_fabrica_taller
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
        Dim ButtonImageOptions1 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Seguimientos_Garantias_fabrica_taller))
        Dim ButtonImageOptions2 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim ButtonImageOptions3 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim ButtonImageOptions4 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim ButtonImageOptions5 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim ButtonImageOptions6 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Me.DxErrorProvider = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.NP_Datos = New DevExpress.XtraBars.Navigation.NavigationPane()
        Me.NP_Facturación = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.GC_Facturación = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl_FC = New DevExpress.XtraGrid.GridControl()
        Me.GridView_FC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NP_Liquidación = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.GC_Liquidación = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl_CT = New DevExpress.XtraGrid.GridControl()
        Me.GridView_CT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NP_Datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NP_Datos.SuspendLayout()
        Me.NP_Facturación.SuspendLayout()
        CType(Me.GC_Facturación, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GC_Facturación.SuspendLayout()
        CType(Me.GridControl_FC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_FC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NP_Liquidación.SuspendLayout()
        CType(Me.GC_Liquidación, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GC_Liquidación.SuspendLayout()
        CType(Me.GridControl_CT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_CT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DxErrorProvider
        '
        Me.DxErrorProvider.ContainerControl = Me
        '
        'NP_Datos
        '
        Me.NP_Datos.Controls.Add(Me.NP_Facturación)
        Me.NP_Datos.Controls.Add(Me.NP_Liquidación)
        Me.NP_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NP_Datos.Location = New System.Drawing.Point(0, 0)
        Me.NP_Datos.Name = "NP_Datos"
        Me.NP_Datos.PageProperties.AllowHtmlDraw = False
        Me.NP_Datos.PageProperties.ShowCollapseButton = False
        Me.NP_Datos.PageProperties.ShowExpandButton = False
        Me.NP_Datos.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NP_Facturación, Me.NP_Liquidación})
        Me.NP_Datos.RegularSize = New System.Drawing.Size(1018, 528)
        Me.NP_Datos.SelectedPage = Me.NP_Facturación
        Me.NP_Datos.Size = New System.Drawing.Size(1018, 528)
        Me.NP_Datos.TabIndex = 8
        Me.NP_Datos.Text = "Datos"
        '
        'NP_Facturación
        '
        Me.NP_Facturación.Caption = "01 - Facturación"
        Me.NP_Facturación.Controls.Add(Me.GC_Facturación)
        Me.NP_Facturación.Name = "NP_Facturación"
        Me.NP_Facturación.Size = New System.Drawing.Size(901, 482)
        '
        'GC_Facturación
        '
        Me.GC_Facturación.Controls.Add(Me.GridControl_FC)
        ButtonImageOptions1.Image = CType(resources.GetObject("ButtonImageOptions1.Image"), System.Drawing.Image)
        ButtonImageOptions2.Image = CType(resources.GetObject("ButtonImageOptions2.Image"), System.Drawing.Image)
        ButtonImageOptions3.Image = CType(resources.GetObject("ButtonImageOptions3.Image"), System.Drawing.Image)
        ButtonImageOptions4.Image = CType(resources.GetObject("ButtonImageOptions4.Image"), System.Drawing.Image)
        Me.GC_Facturación.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Cargar facturación", True, ButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, Nothing, -1), New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Saldos detalle", True, ButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, Nothing, -1), New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Saldo cero detalle", True, ButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, Nothing, -1), New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Saldo por factura", True, ButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, Nothing, -1)})
        Me.GC_Facturación.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_Facturación.Location = New System.Drawing.Point(0, 0)
        Me.GC_Facturación.Name = "GC_Facturación"
        Me.GC_Facturación.Size = New System.Drawing.Size(901, 482)
        Me.GC_Facturación.TabIndex = 0
        '
        'GridControl_FC
        '
        Me.GridControl_FC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl_FC.Location = New System.Drawing.Point(2, 21)
        Me.GridControl_FC.MainView = Me.GridView_FC
        Me.GridControl_FC.Name = "GridControl_FC"
        Me.GridControl_FC.Size = New System.Drawing.Size(897, 459)
        Me.GridControl_FC.TabIndex = 1
        Me.GridControl_FC.UseEmbeddedNavigator = True
        Me.GridControl_FC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_FC})
        '
        'GridView_FC
        '
        Me.GridView_FC.GridControl = Me.GridControl_FC
        Me.GridView_FC.Name = "GridView_FC"
        Me.GridView_FC.OptionsSelection.MultiSelect = True
        Me.GridView_FC.OptionsView.ShowFooter = True
        Me.GridView_FC.OptionsView.ShowGroupPanel = False
        '
        'NP_Liquidación
        '
        Me.NP_Liquidación.Caption = "02 - Liquidación"
        Me.NP_Liquidación.Controls.Add(Me.GC_Liquidación)
        Me.NP_Liquidación.Name = "NP_Liquidación"
        Me.NP_Liquidación.Size = New System.Drawing.Size(901, 482)
        '
        'GC_Liquidación
        '
        Me.GC_Liquidación.Controls.Add(Me.GridControl_CT)
        ButtonImageOptions5.Image = CType(resources.GetObject("ButtonImageOptions5.Image"), System.Drawing.Image)
        ButtonImageOptions6.Image = CType(resources.GetObject("ButtonImageOptions6.Image"), System.Drawing.Image)
        Me.GC_Liquidación.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Cargar liquidación", True, ButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, Nothing, -1), New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Contabilizar", True, ButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, Nothing, -1)})
        Me.GC_Liquidación.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GC_Liquidación.Location = New System.Drawing.Point(0, 0)
        Me.GC_Liquidación.Name = "GC_Liquidación"
        Me.GC_Liquidación.Size = New System.Drawing.Size(901, 482)
        Me.GC_Liquidación.TabIndex = 0
        '
        'GridControl_CT
        '
        Me.GridControl_CT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl_CT.Location = New System.Drawing.Point(2, 21)
        Me.GridControl_CT.MainView = Me.GridView_CT
        Me.GridControl_CT.Name = "GridControl_CT"
        Me.GridControl_CT.Size = New System.Drawing.Size(897, 459)
        Me.GridControl_CT.TabIndex = 2
        Me.GridControl_CT.UseEmbeddedNavigator = True
        Me.GridControl_CT.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_CT})
        '
        'GridView_CT
        '
        Me.GridView_CT.GridControl = Me.GridControl_CT
        Me.GridView_CT.Name = "GridView_CT"
        Me.GridView_CT.OptionsSelection.MultiSelect = True
        Me.GridView_CT.OptionsView.ShowFooter = True
        Me.GridView_CT.OptionsView.ShowGroupPanel = False
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Manager = Nothing
        Me.BarDockControl1.Size = New System.Drawing.Size(1018, 0)
        '
        'Seguimientos_Garantias_fabrica_taller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 528)
        Me.Controls.Add(Me.NP_Datos)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Seguimientos_Garantias_fabrica_taller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguimientos - Garantias fabrica taller"
        CType(Me.DxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NP_Datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NP_Datos.ResumeLayout(False)
        Me.NP_Facturación.ResumeLayout(False)
        CType(Me.GC_Facturación, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GC_Facturación.ResumeLayout(False)
        CType(Me.GridControl_FC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_FC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NP_Liquidación.ResumeLayout(False)
        CType(Me.GC_Liquidación, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GC_Liquidación.ResumeLayout(False)
        CType(Me.GridControl_CT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_CT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DxErrorProvider As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents NP_Datos As DevExpress.XtraBars.Navigation.NavigationPane
    Friend WithEvents NP_Facturación As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents GC_Facturación As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl_FC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView_FC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NP_Liquidación As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents GC_Liquidación As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl_CT As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView_CT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
End Class
