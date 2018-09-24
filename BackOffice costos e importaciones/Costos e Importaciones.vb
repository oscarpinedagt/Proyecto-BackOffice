Public Class Costos_e_Importaciones
    Dim FN As New BackOffice_servicios.Funciones
    Dim Arg() As String = Split(Command$(), "/")
    Public Usuario As String = UCase(Arg(1))
    Dim DPA As New BackOffice_configuración.Directorio_para_adjuntos
    Dim SYC As New BackOffice_configuración.Seguimientos_y_correos

    Private Sub Costos_e_Importaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Arg(0) = True Then RibbonControl.Enabled = True Else RibbonControl.Enabled = False
    End Sub

    Private Sub BBI_Envió_de_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Envió_de_costeos.ItemClick
        FN.Abrir_formulario(Me, DPA)
        With DPA.GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                Select Case CL.FieldName
                    Case "Directorio_matriz", "Crear_directorio", "Estado"
                        CL.Visible = False
                End Select
                Select Case CL.FieldName
                    Case "Empresa", "Tipo_de_mercaderia", "SE"
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
                End Select
                .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Next
        End With
    End Sub

    Private Sub BBI_Seguimiento_de_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Seguimiento_de_costeos.ItemClick
        FN.Abrir_formulario(Me, SYC)
        SYC.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub BBI_Tipos_de_costeo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Tipos_de_costeo.ItemClick
        FN.Abrir_formulario(Me, Tipos_de_costeo)
    End Sub

    Private Sub BBI_Proveedores_cuentas_y_complementos_contables_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Proveedores_cuentas_y_complementos_contables.ItemClick
        FN.Abrir_formulario(Me, Proveedores_cuentas_y_complementos_contables)
    End Sub

    Private Sub BBI_Incoterms_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Incoterms.ItemClick
        FN.Abrir_formulario(Me, Incoterms)
    End Sub

    Private Sub BBI_MOV_Recepción_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MOV_Recepción.ItemClick
        FN.Abrir_formulario(Me, Recepción_de_costeos)
    End Sub

    Private Sub BBI_Elaboración_y_seguimiento_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Elaboración_y_seguimiento.ItemClick
        FN.Abrir_formulario(Me, Elaboración_y_seguimiento)
    End Sub

    Private Sub BBI_SEG_Recepción_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Recepción.ItemClick
        FN.Abrir_formulario(Me, Recepción_y_seguimiento_de_costeos)
    End Sub

    Private Sub BBI_SEG_Elaboración_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Elaboración.ItemClick
        FN.Abrir_formulario(Me, Elaboración_y_seguimiento_de_costeos)
    End Sub

    Private Sub BBI_SEG_Envió_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Envió.ItemClick
        FN.Abrir_formulario(Me, Envió_y_seguimiento_de_costeos)
    End Sub

    Private Sub BBI_Shipper_Carrier_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Shipper_Carrier.ItemClick
        FN.Abrir_formulario(Me, Shipper_o_Carrier)
    End Sub

    Private Sub BBI_Proveedores_locales_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Proveedores_locales.ItemClick
        FN.Abrir_formulario(Me, Proveedores_locales)
    End Sub
End Class