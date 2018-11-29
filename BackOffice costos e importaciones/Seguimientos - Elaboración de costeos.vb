Public Class Seguimientos_Elaboración_de_costeos
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Elaboración_y_seguimiento_de_costeos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos("Where Id_costeo = 0")
        Cargar_directorio()
        DE_Fecha_inicial.DateTime = Format(Now, "01/MM/yyyy")
        DE_Fecha_final.DateTime = Format(Now, "dd/MM/yyyy")
        LUE_Directorio_a_validar.EditValue = My.Settings.Directorio_información_de_archivos
    End Sub

    Private Sub Cargar_directorio()
        With LUE_Directorio_a_validar.Properties
            .DataSource = SQL.Tabla_de_datos("Select * From Directorios_matrices")
            .ValueMember = "Id_directorio_matriz"
            .DisplayMember = "Directorio_matriz"
            .PopulateColumns()
            .Columns("Id_directorio_matriz").Visible = False
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
    End Sub

    Private Sub LUE_Directorio_a_validar_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Directorio_a_validar.EditValueChanged
        My.Settings.Directorio_información_de_archivos = LUE_Directorio_a_validar.EditValue
        My.Settings.Save()
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_de_datos("Select Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Tipo_de_costeo,Estado,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Recibido,Usuario_que_recibe,Fecha_de_recepcion,Elaborado,Usuario_que_elabora,Fecha_de_elaboracion,Dif_Rec_Ela,Costeo_asignado_a From Costeos " + Condicion)
        GridControl.RefreshDataSource()
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.UnGroup()

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatString = "g"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Id_costeo"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Grupo_de_empresas", "Empresa", "Tipo_de_mercaderia", "Elaborado"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Ingreso_a_bodega"
                        Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Count, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName)}
                        .GroupSummary.Add(Item)
                End Select

                Select Case CL.FieldName
                    Case "Dif_Rec_Ela"
                        Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Average, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName), .DisplayFormat = "{0:n2}"}
                        .GroupSummary.Add(Item)
                        CL.Caption = "Tiempo en Hrs Rec-Ela"
                        CL.ToolTip = "Rec-Ela = Recibido - Elaborado"
                End Select

            Next

            AddHandler GridView.GroupLevelStyle, Sub(s, e)
                                                     Select Case e.Level
                                                         Case 0
                                                             e.LevelAppearance.ForeColor = Color.WhiteSmoke
                                                             e.LevelAppearance.BackColor = Color.LightSlateGray
                                                     End Select
                                                 End Sub

            Dim Fuente As Font = New Font("Tahoma", 7)
            .Appearance.HeaderPanel.Font = Fuente
            .Appearance.GroupRow.Font = New Font(Fuente, FontStyle.Bold)
            .Appearance.FooterPanel.Font = Fuente
            .Appearance.GroupFooter.Font = Fuente
            .Appearance.Row.Font = Fuente

            .ExpandAllGroups()
            .OptionsBehavior.Editable = False
            .OptionsBehavior.SummariesIgnoreNullValues = True
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
    End Sub

    Private Sub BBI_Generar_información_de_archivos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información_de_archivos.ItemClick
        Dim CF1 As String = "Fecha_de_ingreso_a_bodega"
        Dim CF2 As String = "Fecha_de_recepcion"

        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        Dim FF As DateTime = Convert.ToDateTime(DE_Fecha_final.DateTime.ToShortDateString + " 23:59:59")
        If FF >= FI Then
            Cargar_datos(" Where " + CF2 + " Between '" + FI.ToString + "' And '" + FF.ToString + "' Or (" + CF2 + " Is Null And " + CF1 + " Between '" + FI.ToString + "' And '" + FF.ToString + "') Or (" + CF2 + "='' And " + CF1 + " Between '" + FI.ToString + "' And '" + FF.ToString + "') Order By " & CF2)
        End If
    End Sub
    Private Sub BBI_Actualizar_información_de_archivos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Actualizar_información_de_archivos.ItemClick
        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        If LUE_Directorio_a_validar.Text <> "" Then
            FN.Propiedades_de_archivos(LUE_Directorio_a_validar.Text, FI, False)
            BBI_Generar_información_de_archivos_ItemClick(sender, Nothing)
        End If
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Enter Then
            GridView_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub GridView_DoubleClick(sender As Object, e As EventArgs) Handles GridView.DoubleClick
        Dim ea As DevExpress.Utils.DXMouseEventArgs = TryCast(e, DevExpress.Utils.DXMouseEventArgs)
        Dim Info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = GridView.CalcHitInfo(ea.Location)

        Dim i As Integer = GridView.GetRowCellValue(Info.RowHandle, "Id_costeo")

        If Info.InRow Or Info.InRowCell Then
            If i > 0 And i.ToString <> "" Then
                If GridView.GetRowCellValue(Info.RowHandle, "Grupo_de_empresas") = "Grupo Automotriz" Then
                    FN.Abrir_formulario(Costos_e_Importaciones, Movimientos_Elaboración_de_costeos)
                    With Movimientos_Elaboración_de_costeos
                        .ID = i
                        FN.Estado_del_menú("Buscar", .BarManager)
                        .Datos_consulta()
                    End With
                Else
                    FN.Abrir_formulario(Costos_e_Importaciones, Movimientos_Recepción_de_costeos)
                    With Movimientos_Recepción_de_costeos
                        .ID = i
                        FN.Estado_del_menú("Buscar", .BarManager)
                        .Datos_consulta()
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub BBI_Generar_información_desde_directorio_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información_desde_directorio.ItemClick
        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        If LUE_Directorio_a_validar.Text <> "" Then
            FN.Propiedades_de_archivos(LUE_Directorio_a_validar.Text, FI, True)
        End If
    End Sub

    Private Sub BBI_Generar_información_desde_informe_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información_desde_informe.ItemClick
        If GridView.RowCount > 0 Then
            FN.Exportar_GridControl_a_Excel(GridControl, "Costeos elaborados")
        End If
    End Sub

End Class