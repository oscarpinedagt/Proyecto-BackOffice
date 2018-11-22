Public Class Tableros_4DX_Unidades_y_tiempos_por_mes_semana_estadia
    Dim SQL As New BackOffice_datos.SQL
    Private Sub Tableros_4DX_Unidades_y_tiempos_por_mes_semana_estadia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TE_Año.EditValue = Now.ToString("yyyy")
        Cargar_datos_sobre()
        Cargar_grupo_de_empresas()
        Cargar_datos("Where Ing.Id_costeo = 0")
    End Sub

    Private Sub Cargar_datos_sobre()

        Dim DT As New DataTable
        DT.Columns.Add("DS")
        DT.Columns.Add("Datos_sobre")
        DT.Rows.Add("Rec_Ela", "Recibido - Elaborado")
        DT.Rows.Add("Rec_Env", "Recibido - Enviado")

        With LUE_Datos_sobre.Properties
            .DataSource = DT
            .ValueMember = "DS"
            .DisplayMember = "Datos_sobre"
            .PopulateColumns()
            .Columns(.ValueMember).Visible = False
            .Columns(.DisplayMember).Caption = Replace(.DisplayMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            LUE_Datos_sobre.EditValue = .GetKeyValueByDisplayText("Recibido - Elaborado")
        End With

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
        GridControl.DataSource = SQL.Tabla_de_datos("Select Ing.Semana,Ing.Grupo_de_empresas,Ing.Tipo_de_mercaderia,Ing.Estadia,Sum(Ing.Enero)[Ene-Ingresos],Avg(Hrs.Enero)[Ene-Hrs Promedio],Sum(Ing.Febrero)[Feb-Ingresos],Avg(Hrs.Febrero)[Feb-Hrs Promedio],Sum(Ing.Marzo)[Mar-Ingresos],Avg(Hrs.Marzo)[Mar-Hrs Promedio],Sum(Ing.Abril)[Abr-Ingresos],Avg(Hrs.Abril)[Abr-Hrs Promedio],Sum(Ing.Mayo)[May-Ingresos],Avg(Hrs.Mayo)[May-Hrs Promedio],Sum(Ing.Junio)[Jun-Ingresos],Avg(Hrs.Junio)[Jun-Hrs Promedio],Sum(Ing.Julio)[Jul-Ingresos],Avg(Hrs.Julio)[Jul-Hrs Promedio],Sum(Ing.Agosto)[Ago-Ingresos],Avg(Hrs.Agosto)[Ago-Hrs Promedio],Sum(Ing.Septiembre)[Sep-Ingresos],Avg(Hrs.Septiembre)[Sep-Hrs Promedio],Sum(Ing.Octubre)[Oct-Ingresos],Avg(Hrs.Octubre)[Oct-Hrs Promedio],Sum(Ing.Noviembre)[Nov-Ingresos],Avg(Hrs.Noviembre)[Nov-Hrs Promedio],Sum(Ing.Diciembre)[Dic-Ingresos],Avg(Hrs.Diciembre)[Dic-Hrs Promedio]  
                                                    From 
                                                    (Select Id_costeo,Grupo_de_empresas,Tipo_de_mercaderia,Año_recepcion,'Semana - '+Convert(NvarChar,Semana_recepcion) As Semana,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " As Estadia,Recibido,Estado,Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre From
                                                    (Select Id_costeo,Grupo_de_empresas,Tipo_de_mercaderia,Año_recepcion,Mes_recepcion,Semana_recepcion,Estadia_" + LUE_Datos_sobre.EditValue.ToString + ",Recibido,Estado,Ingreso_a_bodega From Costeos)D 
                                                    Pivot (Count(Ingreso_a_bodega) For Mes_recepcion In (Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre))I)Ing
                                                    Inner Join
                                                    (Select Id_costeo,Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre From
                                                    (Select Id_costeo,Mes_recepcion,Dif_" + LUE_Datos_sobre.EditValue.ToString + " From Costeos)D 
                                                    Pivot (Avg(Dif_" + LUE_Datos_sobre.EditValue.ToString + ") For Mes_recepcion In (Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,Noviembre,Diciembre))H)Hrs 
                                                    On Ing.Id_costeo=Hrs.Id_costeo
                                                    " + Condicion + "
                                                    Group By Ing.Semana,Ing.Grupo_de_empresas,Ing.Tipo_de_mercaderia,Ing.Estadia")
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView



            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                CL.UnGroup()

                If CL.FieldName.ToString.Contains("Hrs") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    CL.DisplayFormat.FormatString = "n2"
                End If

                If LUE_Grupo_de_empresas.EditValue.ToString = "" Then
                    Select Case CL.FieldName
                        Case "Semana", "Grupo_de_empresas"
                            CL.Group()
                    End Select
                Else

                    Select Case CL.FieldName
                        Case "Semana"
                            CL.Group()
                    End Select

                    Select Case CL.FieldName
                        Case "Grupo_de_empresas"
                            CL.Visible = False
                    End Select

                End If

                Select Case CL.FieldName
                    Case "Semana", "Grupo_de_empresas", "Tipo_de_mercaderia", "Estadia"
                        CL.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                End Select

                If CL.FieldName.Contains("Ene") Or CL.FieldName.Contains("Mar") Or CL.FieldName.Contains("May") Or CL.FieldName.Contains("Jul") Or CL.FieldName.Contains("Sep") Or CL.FieldName.Contains("Nov") Then
                    CL.AppearanceCell.BackColor = Color.LightYellow
                End If

                If CL.FieldName = "Semana" Or CL.FieldName = "Grupo_de_empresas" Or CL.FieldName = "Tipo_de_mercaderia" Then
                    CL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Else
                    CL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                End If

                If CL.FieldName.Contains("Ingresos") Then
                    Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName)}
                    .GroupSummary.Add(Item)

                    With CL.SummaryItem
                        .SummaryType = DevExpress.Data.SummaryItemType.Sum
                        .FieldName = CL.FieldName
                        .DisplayFormat = "{0:n0}"
                    End With

                End If

                If CL.FieldName.Contains("Hrs") Then
                    Dim Item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem With {.FieldName = CL.FieldName, .SummaryType = DevExpress.Data.SummaryItemType.Average, .ShowInGroupColumnFooter = GridView.Columns(CL.FieldName), .DisplayFormat = "{0:n2}"}
                    .GroupSummary.Add(Item)

                    With CL.SummaryItem
                        .SummaryType = DevExpress.Data.SummaryItemType.Average
                        .FieldName = CL.FieldName
                        .DisplayFormat = "{0:n2}"
                    End With

                End If

            Next

            AddHandler GridView.RowStyle, Sub(s, e)
                                              e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                                              Select Case GridView.GetRowCellValue(e.RowHandle, "Estadia")
                                                  Case "Dentro de rango"
                                                      e.Appearance.ForeColor = Color.Green
                                                  Case "Fuera de rango"
                                                      e.Appearance.ForeColor = Color.Red
                                              End Select
                                          End Sub

            AddHandler GridView.RowCellStyle, Sub(s, e)
                                                  Dim CL As String = e.Column.FieldName
                                                  If CL = "Semana" Or CL = "Grupo_de_empresas" Or CL = "Tipo_de_mercaderia" Then
                                                      e.Appearance.ForeColor = Color.Black
                                                  End If
                                              End Sub

            AddHandler GridView.GroupLevelStyle, Sub(s, e)
                                                     Select Case e.Level
                                                         Case 0
                                                             e.LevelAppearance.ForeColor = Color.WhiteSmoke
                                                             e.LevelAppearance.BackColor = Color.LightSlateGray
                                                     End Select
                                                 End Sub

            '.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsBehavior.ReadOnly = True
            .OptionsBehavior.SummariesIgnoreNullValues = True
            .OptionsView.AllowCellMerge = True
            .ExpandAllGroups()
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()

        End With

    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        If TE_Año.EditValue <> Nothing Then
            Cargar_datos("Where Ing.Recibido='True' And Ing.Estado<>'Anulado' And Ing.Año_recepcion = " + TE_Año.EditValue.ToString + " And Ing.Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%'")
        End If
    End Sub

    Private Sub BBI_Imprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Imprimir.ItemClick
        If GridControl.IsPrintingAvailable Then
            GridView.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 6)
            GridView.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView.AppearancePrint.GroupRow.Font = New Font("Tahoma", 6, FontStyle.Bold)
            GridView.AppearancePrint.Row.Font = New Font("Tahoma", 6)
            GridView.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 6)
            GridView.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 6)
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

        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Content.AddRange(New String() {"Datos presentados sobre = " + LUE_Datos_sobre.Text + "\ Grupo de empresas = " + LUE_Grupo_de_empresas.Text, "", "Página: [Page #] de [Páginas #]"})
        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Font = New Font("Tahoma", 6)


    End Sub
End Class