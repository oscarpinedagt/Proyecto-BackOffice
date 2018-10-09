Public Class Reportes_seguro
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Seguro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos("Where Id_seguro = 0")
        DE_Fecha_inicial.DateTime = Format(Now, "01/MM/yyyy")
        DE_Fecha_final.DateTime = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos("Select * From Seguro " + Condicion)
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Id_seguro", "RL_id_costeo"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Empresa", "Póliza_de_seguro"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Valor_costo", "Gastos_comprobables", "Total_costos_y_gastos", "Prima", "Gastos_de_emisión", "Total_seguro_USD", "Total_seguro_GTQ"

                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        Dim Item As New DevExpress.XtraGrid.GridGroupSummaryItem With {.ShowInGroupColumnFooterName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = CL}
                        .GroupSummary.Add(Item)

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

            Next
            .ExpandAllGroups()
            .OptionsBehavior.Editable = False
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        Dim CF As String = "Fecha_de_provisión"
        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        Dim FF As DateTime = Convert.ToDateTime(DE_Fecha_final.DateTime.ToShortDateString + " 23:59:59")
        If FF >= FI Then
            Cargar_datos("Where (" + CF + " Between '" + FI.ToString + "' And '" + FF.ToString + "') Or " + CF + " Is Null Or " + CF + "='' Order By " + CF)
        End If
    End Sub

    Private Sub BBI_Generar_a_Excel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_a_Excel.ItemClick
        If GridView.RowCount > 0 Then
            FN.Exportar_GridControl_a_Excel(GridControl, "Seguro del " + Replace(DE_Fecha_inicial.DateTime.ToShortDateString, "/", "") + " al " + Replace(DE_Fecha_final.DateTime.ToShortDateString, "/", ""))
        End If
    End Sub

    Private Sub GridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView.RowDeleted
        SQL.Actualizar_tabla()
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    GridView.DeleteRow(GridView.FocusedRowHandle)
                End If
            End If
        End If
    End Sub

End Class