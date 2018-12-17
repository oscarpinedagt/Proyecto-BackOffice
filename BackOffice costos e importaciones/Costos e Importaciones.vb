Public Class Costos_e_Importaciones
    Dim FN As New BackOffice_servicios.Funciones
    Dim Arg() As String = Split(Command$(), "/")
    Public Usuario As String = UCase(Arg(1))
    Dim DPA As New BackOffice_configuración.Mantenimiento_Directorio_para_adjuntos
    Dim SYC As New BackOffice_configuración.Mantenimiento_Seguimientos_y_correos

    Private Sub Costos_e_Importaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Arg(0) = True Then RibbonControl.Enabled = True Else RibbonControl.Enabled = False
    End Sub

    Private Sub BBI_MAN_Envió_de_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Envió_de_costeos.ItemClick
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

    Private Sub BBI_MAN_Seguimiento_de_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Seguimientos_y_correos.ItemClick
        FN.Abrir_formulario(Me, SYC)
        SYC.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
    End Sub

    Private Sub BBI_MAN_Tipos_de_costeo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Tipos_de_costeo.ItemClick
        FN.Abrir_formulario(Me, Mantenimiento_Tipos_de_costeo)
    End Sub

    Private Sub BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Proveedores_del_exterior_cuentas_y_complementos_contables.ItemClick
        FN.Abrir_formulario(Me, Mantenimiento_Proveedores_del_exterior_cuentas_y_complementos_contables)
    End Sub

    Private Sub BBI_MAN_Incoterms_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Incoterms.ItemClick
        FN.Abrir_formulario(Me, Mantenimiento_Incoterms)
    End Sub

    Private Sub BBI_MOV_Recepción_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MOV_Recepción.ItemClick
        FN.Abrir_formulario(Me, Movimientos_Recepción_de_costeos)
    End Sub

    Private Sub BBI_MOV_Elaboración_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MOV_Elaboración.ItemClick
        FN.Abrir_formulario(Me, Movimientos_Elaboración_de_costeos)
    End Sub

    Private Sub BBI_SEG_Recepción_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Recepción.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Recepción_de_costeos)
    End Sub

    Private Sub BBI_SEG_Elaboración_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Elaboración.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Elaboración_de_costeos)
    End Sub

    Private Sub BBI_SEG_Envió_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Envió.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Envió_de_costeos)
    End Sub

    Private Sub BBI_MAN_Shipper_o_Carrier_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Shipper_o_Carrier.ItemClick
        FN.Abrir_formulario(Me, Mantenimiento_Shipper_o_Carrier)
    End Sub

    Private Sub BBI_MAN_Proveedores_localess_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Proveedores_locales.ItemClick
        FN.Abrir_formulario(Me, Mantenimiento_Proveedores_locales)
    End Sub

    Private Sub BBI_RP_Seguro_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_RP_Seguro.ItemClick
        FN.Abrir_formulario(Me, Reportes_seguro)
    End Sub

    Private Sub BBI_MAN_Tipos_de_gasto_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_MAN_Tipos_de_gasto.ItemClick
        FN.Abrir_formulario(Me, Mantenimiento_Tipos_de_gasto)
    End Sub

    Private Sub BBI_SEG_Mercadería_en_transito_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Mercadería_en_transito.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Mercadería_en_transito)
    End Sub

    Private Sub BBI_SEG_Control_de_IPRIMA_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Control_de_IPRIMA.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Control_de_IPRIMA)
    End Sub

    Private Sub BBI_Contraseñas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Contraseñas.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Contraseñas)
    End Sub

    Private Sub BBI_DUAS_IPRIMAS_FAUCAS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_DUAS_IPRIMAS_FAUCAS.ItemClick
        FN.Abrir_formulario(Me, Movimientos_Contabilización_de_DUAS_IPRIMAS_FAUCAS_FYDUCAS)
    End Sub

    Private Sub BBI_Garantias_fabrica_taller_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Garantias_fabrica_taller.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Garantias_fabrica_taller)
    End Sub

    Private Sub BBI_Resumen_de_unidades_y_tiempos_por_mes_semana_estadia_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Resumen_de_unidades_y_tiempos_por_mes_semana_estadia.ItemClick
        FN.Abrir_formulario(Me, Tableros_4DX_Resumen_de_unidades_y_tiempos_por_mes_semana_estadia)
    End Sub

    Private Sub BBI_Información_detallada_por_semana_mes_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Información_detallada_por_semana_mes.ItemClick
        FN.Abrir_formulario(Me, Tableros_4DX_Información_detallada_por_mes_semana)
    End Sub

    Private Sub BBI_DashBoard_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_DashBoard.ItemClick

    End Sub

    Private Sub BBI_SEG_Pago_de_impuestos_Tesorería_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_SEG_Pago_de_impuestos_Tesorería.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_Solicitud_de_pago_de_impuestos)
    End Sub

    Private Sub BBI_REP_Pago_de_impuestos_Tesorería_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_REP_Pago_de_impuestos_Tesorería.ItemClick
        FN.Abrir_formulario(Me, Reportes_Pago_de_impuestos_Tesorería)
    End Sub

    Private Sub BBI_Graficas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Graficas.ItemClick
        FN.Abrir_formulario(Me, Tableros_4DX_Graficos)
    End Sub
End Class