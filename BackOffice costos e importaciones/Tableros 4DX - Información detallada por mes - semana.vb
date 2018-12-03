Public Class Tableros_4DX_Información_detallada_por_mes_semana
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Tableros_4DX_Unidades_y_tiempos_por_mes_semana_estadia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TE_Año.EditValue = Now.ToString("yyyy")
        Cargar_grupo_de_empresas()
        Cargar_datos("Where Id_costeo = 0")
    End Sub

    Private Sub Cargar_grupo_de_empresas()

        Dim DT As New DataTable
        DT.Columns.Add("Grupo")
        DT.Columns.Add("Grupo_de_empresas")
        DT.Rows.Add("", "Todos")

        For Each dr As DataRow In SQL.Tabla_de_datos("Select Grupo From Grupo_de_empresas Group By Grupo").Rows
            DT.Rows.Add(dr("Grupo"), dr("Grupo"))
        Next

        With LUE_Grupo_de_empresas.Properties
            .DataSource = DT
            .ValueMember = "Grupo"
            .DisplayMember = "Grupo_de_empresas"
            .PopulateColumns()
            .Columns(.ValueMember).Visible = False
            .Columns(.DisplayMember).Caption = Replace(.DisplayMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            LUE_Grupo_de_empresas.EditValue = .GetKeyValueByDisplayText("Todos")
        End With

    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos("Select Id_costeo,Format(Month(Fecha_de_recepcion),'00')+' - '+Mes_recepcion As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Proveedor,Marca,País_de_procedencia,Tipo_de_importacion,Incoterm,Moneda_de_negociación,[Shipper|Carrier],[Guia|BL|Carta_de_porte],[Fecha_de_Guia|BL|Carta_de_porte],Fecha_de_arribo,Régimen,[Dua|Fauca|Face],[Fecha_de_Dua|Fauca|Face],Contenedores_o_bultos,Recibido,Usuario_que_recibe,Fecha_de_recepcion,Dif_Ing_Rec,Costeo_asignado_a,Tiempo_de_estadia,Elaborado,Usuario_que_elabora,Fecha_de_elaboracion,Dif_Rec_Ela,Estadia_Rec_Ela,Enviado,Usuario_que_envia,Fecha_de_envio,Dif_Rec_Env,Estadia_Rec_Env,Comentarios   
                                                                       From Costeos " + Condicion)
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                CL.UnGroup()
                CL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                Select Case CL.FieldName
                    Case "Id_costeo"
                        CL.Visible = False
                End Select

                If LUE_Grupo_de_empresas.EditValue.ToString = "" Then
                    Select Case CL.FieldName
                        Case "Mes", "Semana", "Grupo_de_empresas"
                            CL.Group()
                    End Select
                Else
                    Select Case CL.FieldName
                        Case "Mes", "Semana" '
                            CL.Group()
                    End Select

                    Select Case CL.FieldName
                        Case "Grupo_de_empresas"
                            CL.Visible = False
                    End Select

                End If

                If CL.FieldName = "Mes" Or CL.FieldName = "Semana" Or CL.FieldName = "Grupo_de_empresas" Then
                    CL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                End If

                Select Case CL.FieldName
                    Case "Dif_Ing_Rec"
                        CL.Caption = "Ingreso - Recepción Hrs"
                    Case "Dif_Rec_Ela"
                        CL.Caption = "Recibido - Elaborado Hrs"
                    Case "Estadia_Rec_Ela"
                        CL.Caption = "Estadia Recibido - Elaborado"
                    Case "Dif_Rec_Env"
                        CL.Caption = "Recibido - Enviado Hrs"
                    Case "Estadia_Rec_Env"
                        CL.Caption = "Estadia Recibido - Enviado"
                End Select

                If CL.FieldName.Contains("Ingreso_a_bodega") Then
                    Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Count, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName), .DisplayFormat = "{0:n0}"}
                    .GroupSummary.Add(Item)

                    With CL.SummaryItem
                        .SummaryType = DevExpress.Data.SummaryItemType.Count
                        .FieldName = CL.FieldName
                        .DisplayFormat = "{0:n0}"
                    End With

                End If

                If CL.FieldName.Contains("Dif_") Then
                    Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Average, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName), .DisplayFormat = "{0:n2}"}
                    .GroupSummary.Add(Item)

                    With CL.SummaryItem
                        .SummaryType = DevExpress.Data.SummaryItemType.Average
                        .FieldName = CL.FieldName
                        .DisplayFormat = "{0:n2}"
                    End With

                End If

                Select Case CL.FieldName
                    Case "Comentarios"
                        CL.Visible = False
                        .PreviewFieldName = CL.FieldName
                        .OptionsView.ShowPreview = CKE_Ver_comentarios.Checked
                        .OptionsView.AutoCalcPreviewLineCount = True
                End Select

            Next

            AddHandler GridView.CustomDrawRowPreview, Sub(s, e)
                                                          e.Appearance.ForeColor = Color.Green
                                                      End Sub

            AddHandler GridView.GroupLevelStyle, Sub(s, e)
                                                     Select Case e.Level
                                                         Case 0
                                                             e.LevelAppearance.ForeColor = Color.WhiteSmoke
                                                             e.LevelAppearance.BackColor = Color.LightSlateGray
                                                     End Select
                                                 End Sub

            AddHandler GridView.RowCellStyle, Sub(s, e)
                                                  Dim CL As String = e.Column.FieldName
                                                  If CL = "Dif_Rec_Ela" Or CL = "Dif_Rec_Env" Then
                                                      Select Case GridView.GetRowCellValue(e.RowHandle, CL)
                                                          Case 0 To 4
                                                              e.Appearance.BackColor = Color.LightGreen
                                                          Case 4 To 6
                                                              e.Appearance.BackColor = Color.LightYellow
                                                          Case 6 To 8
                                                              e.Appearance.BackColor = Color.LightSalmon
                                                          Case > 8
                                                              e.Appearance.BackColor = Color.LightCoral
                                                      End Select
                                                  End If
                                              End Sub

            Dim Fuente As Font = New Font("Tahoma", 7)
            .Appearance.HeaderPanel.Font = Fuente
            .Appearance.GroupRow.Font = New Font(Fuente, FontStyle.Bold)
            .Appearance.FooterPanel.Font = Fuente
            .Appearance.GroupFooter.Font = Fuente
            .Appearance.Row.Font = Fuente

            BBI_Editar.Enabled = True
            .OptionsBehavior.Editable = False
            .OptionsBehavior.ReadOnly = True
            .OptionsBehavior.SummariesIgnoreNullValues = True
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.AllowCellMerge = True
            If LUE_Grupo_de_empresas.EditValue.ToString = "" Then
                .ExpandGroupLevel(0)
                .ExpandGroupLevel(1)
            Else
                .ExpandGroupLevel(0)
            End If
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()

        End With

    End Sub

    Private Sub Columna_fecha_y_hora()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "g"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha_de_ingreso_a_bodega").ColumnEdit = Item
        GridView.Columns("Fecha_de_Guia|BL|Carta_de_porte").ColumnEdit = Item
        GridView.Columns("Fecha_de_arribo").ColumnEdit = Item
        GridView.Columns("Fecha_de_Dua|Fauca|Face").ColumnEdit = Item
        GridView.Columns("Fecha_de_recepcion").ColumnEdit = Item
        GridView.Columns("Fecha_de_elaboracion").ColumnEdit = Item
        'GridView.Columns("Fecha_de_revision").ColumnEdit = Item
        GridView.Columns("Fecha_de_envio").ColumnEdit = Item

    End Sub

    Private Sub Columna_usuario()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Usuario From Usuarios a,Complementos_del_puesto b Where a.Id_usuario<>0 AND a.RL_CP=b.Id_CP AND b.Division='Costos e Importaciones'")
            .ValueMember = "Usuario"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Usuario_que_recibe").ColumnEdit = Item
        GridView.Columns("Usuario_que_elabora").ColumnEdit = Item
        'GridView.Columns("Usuario_que_revisa").ColumnEdit = Item
        GridView.Columns("Usuario_que_envia").ColumnEdit = Item

    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        If TE_Año.EditValue <> Nothing Then
            Cargar_datos("Where Recibido='True' And Estado<>'Anulado' And Año_recepcion = " + TE_Año.EditValue.ToString + " And Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%'")
        End If
    End Sub

    Private Sub BBI_Imprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Imprimir.ItemClick
        If GridControl.IsPrintingAvailable Then
            Dim Fuente As Font = New Font("Tahoma", 5)

            GridView.AppearancePrint.HeaderPanel.Font = Fuente
            GridView.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView.AppearancePrint.GroupRow.Font = New Font(Fuente, FontStyle.Bold)
            GridView.AppearancePrint.Row.Font = Fuente
            GridView.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView.AppearancePrint.GroupFooter.Font = Fuente
            GridView.OptionsPrint.UsePrintStyles = True
            GridControl.ShowPrintPreview()
        End If
    End Sub

    Private Sub GridView_PrintInitialize(sender As Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView.PrintInitialize
        Dim PSB As DevExpress.XtraPrinting.PrintingSystemBase = CType(e.PrintingSystem, DevExpress.XtraPrinting.PrintingSystemBase)
        PSB.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter

        PSB.Document.AutoFitToPagesWidth = 1

        PSB.PageSettings.Landscape = True
        PSB.PageSettings.TopMargin = 50
        PSB.PageSettings.LeftMargin = 0
        PSB.PageSettings.RightMargin = 0
        PSB.PageSettings.BottomMargin = 35

        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.Content.AddRange(New String() {"", "Tablero 4DX [Unidades y Tiempos]\[Semana - Mes - Rango]", "Año " + TE_Año.EditValue.ToString})
        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.LineAlignment = DevExpress.XtraPrinting.BrickAlignment.Far
        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.Font = New Font("Tahoma", 8, FontStyle.Bold)

        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Content.AddRange(New String() {"Grupo de empresas = " + LUE_Grupo_de_empresas.Text, "", "Página: [Page #] de [Páginas #]"})
        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Font = New Font("Tahoma", 6)

    End Sub

    Private Sub CKE_Ver_comentarios_CheckedChanged(sender As Object, e As EventArgs) Handles CKE_Ver_comentarios.CheckedChanged
        GridView.OptionsView.ShowPreview = CKE_Ver_comentarios.Checked
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

    Private Sub GridView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView.RowUpdated
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            SQL.Actualizar_tabla()
        End If
    End Sub

    Private Sub GridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView.RowDeleted
        If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                SQL.Actualizar_tabla()
            End If
        End If
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If GridView.OptionsBehavior.Editable = True Then
            If e.KeyData = Keys.Shift + Keys.Delete Then
                If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                    SEG.ShowDialog()
                    If SEG.Resultado = True Then
                        GridView.DeleteRow(GridView.FocusedRowHandle)
                    End If
                End If
            ElseIf e.KeyData = Keys.Delete Then
                GridView.SetRowCellValue(GridView.FocusedRowHandle, GridView.FocusedColumn, Nothing)
            End If
        End If
    End Sub

    Private Sub BBI_Editar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Editar.ItemClick
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Editar 4DX - Información a detalle"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                BBI_Editar.Enabled = False
                GridView.OptionsBehavior.Editable = True
                GridView.OptionsBehavior.ReadOnly = False
                Columna_fecha_y_hora()
                Columna_usuario()
            End If
        End If
    End Sub

End Class