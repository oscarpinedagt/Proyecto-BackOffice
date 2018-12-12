Public Class Reportes_Pago_de_impuestos_Tesorería

    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Seguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DE_Fecha_inicial.DateTime = Now.ToString("01/MM/yyyy")
        DE_Fecha_final.DateTime = Now.ToString("dd/MM/yyyy")
        Cargar_datos("Select Empresa,Documento,Formulario,Valor_SAT,'Pago de ' as Solicitud,Fecha_de_solicitud_de_pago,Fecha_de_confirmación_de_pago,Tiempo_de_pago_en_HRS From Solicitud_de_pago_de_impuestos_Tesorería Where Id_solicitud = 0")
    End Sub

    Private Sub Cargar_datos(Consulta)
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos(Consulta)
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                End If

                Select Case CL.FieldName
                    Case "Id_solicitud"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Valor_SAT"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName), .DisplayFormat = "{0:n2}"}
                        .GroupSummary.Add(Item)

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

                Select Case CL.FieldName
                    Case "Tiempo_de_pago_en_HRS"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Average, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName), .DisplayFormat = "{0:n2}"}
                        .GroupSummary.Add(Item)

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Average
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

            Next
            '.ExpandAllGroups()
            .OptionsBehavior.Editable = False
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        Dim CF As String = "Fecha_de_solicitud_de_pago"
        Dim FI As Date = DE_Fecha_inicial.DateTime.ToString("dd/MM/yyyy 00:00:01")
        Dim FF As Date = DE_Fecha_final.DateTime.ToString("dd/MM/yyyy 23:59:59")

        If FF >= FI Then

            Cargar_datos("Select Empresa,DUA as Documento,Formulario_IPRIMA as Formulario,Sum(Valor_IPRIMA_SAT) as Valor_SAT,'Pago de IPRIMA'as Solicitud,Fecha_de_solicitud_de_pago,Fecha_de_confirmación_de_pago,Avg(Tiempo_de_pago_en_HRS) as Tiempo_de_pago_en_HRS From Control_de_iprima Where " + CF + " Between '" + FI.ToString + "' And '" + FF.ToString + "' Group By Empresa,DUA,Formulario_IPRIMA,Fecha_de_solicitud_de_pago,Fecha_de_confirmación_de_pago
                          Union All
                          Select Empresa,Documento,Formulario,Sum(Valor_SAT) as Valor_SAT,'Pago de '+Tipo_de_documento+' - '+Tipo_de_mercaderia as Solicitud,Fecha_de_solicitud_de_pago,Fecha_de_confirmación_de_pago,Avg(Tiempo_de_pago_en_HRS) as Tiempo_de_pago_en_HRS From Solicitud_de_pago_de_impuestos_Tesorería Where " + CF + " Between '" + FI.ToString + "' And '" + FF.ToString + "' Group By Empresa,Documento,Formulario,Tipo_de_documento,Tipo_de_mercaderia,Fecha_de_solicitud_de_pago,Fecha_de_confirmación_de_pago
                          Order By " + CF)
        End If
    End Sub

    Private Sub BBI_Generar_a_Excel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_a_Excel.ItemClick
        If GridView.RowCount > 0 Then
            FN.Exportar_GridControl_a_Excel(GridControl, "Solicitud de pagos a Tesorería del " + Replace(DE_Fecha_inicial.DateTime.ToShortDateString, "/", "-") + " al " + Replace(DE_Fecha_final.DateTime.ToShortDateString, "/", "-"))
        End If
    End Sub


End Class