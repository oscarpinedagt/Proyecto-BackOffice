Public Class Seguimientos_Mercadería_en_transito
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Seguimiento_Mercadería_en_transito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
    End Sub

    Private Sub Cargar_datos()
        GridControl.DataSource = SQL.Tabla_de_datos("Select a.Id_costeo,a.Ingreso_a_bodega, a.Empresa,a.Tipo_de_importacion,a.[Guia|BL|Carta_de_porte],a.[Shipper|Carrier], STUFF((Select ', '+ b.documento from Documentos_del_exterior b where b.RL_id_costeo=a.Id_costeo for xml path('')),1,1,'') as Documentos,a.Moneda_de_negociación, (Select  sum(c.Total) from Documentos_del_exterior c Where a.Id_costeo = c.RL_id_costeo group by c.RL_id_costeo) Valor_documentos, a.Fecha_de_arribo, a.[Dua|Fauca|Face],a.[Fecha_de_Dua|Fauca|Face],a.Comentarios  from Costeos a Where a.Estado = 'En transito'")
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                End If

                Select Case CL.FieldName
                    Case "Id_costeo", "Comentarios"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Comentarios"
                        .PreviewFieldName = CL.FieldName
                        .OptionsView.ShowPreview = True
                        .OptionsView.AutoCalcPreviewLineCount = True
                End Select

                Select Case CL.FieldName
                    Case "Valor_documentos"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"
                End Select

            Next

            AddHandler GridView.CustomDrawRowPreview, Sub(s, e)
                                                          e.Appearance.ForeColor = Color.Green
                                                      End Sub
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Enter Then
            GridControl_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub GridControl_DoubleClick(sender As Object, e As EventArgs) Handles GridControl.DoubleClick

        FN.Abrir_formulario(Costos_e_Importaciones, Movimientos_Elaboración_de_costeos)
        With Movimientos_Elaboración_de_costeos
            .Estado_busqueda()
            .ID = GridView.GetRowCellValue(GridView.FocusedRowHandle, "Id_costeo")
            .Datos_consulta()
        End With

    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        Cargar_datos()
    End Sub

    Private Sub BBI_Generar_información_desde_informe_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_a_Excel.ItemClick
        If GridView.RowCount > 0 Then
            GridView.Columns("Comentarios").Visible = True
            FN.Exportar_GridControl_a_Excel(GridControl, "Mercadería en transito al " + Replace(Convert.ToDateTime(Now).ToShortDateString, "/", ""))
            GridView.Columns("Comentarios").Visible = False
        End If
    End Sub

End Class