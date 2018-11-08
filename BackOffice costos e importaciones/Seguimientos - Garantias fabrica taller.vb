Public Class Seguimientos_Garantias_fabrica_taller
    Dim SQL As New BackOffice_datos.SQL, SQL_FC As New BackOffice_datos.SQL, SQL_LQ As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub GC_Facturación_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Facturación.CustomButtonClick
        Select Case e.Button.Properties.Caption

            Case "Cargar facturación"
                Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx;*.xlsm"}
                If File.ShowDialog() = DialogResult.OK Then

                    Dim Dt_Uniauto As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Uniauto$]")
                    For Each Dr As DataRow In Dt_Uniauto.Rows
                        If Dr("Tipo_de_orden").ToString = "Garantia de Fábrica - T" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden ='UNIAUTO, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_facturación", "Id_facturación,Empresa,Factura,Fecha_de_factura,No_de_orden,Tipo_de_orden,Total_bruto,Descuento,IVA,Total_neto,Tipo_de_liquidación", Now.ToString("yyMMddHHmmssfff") + ",'UNIAUTO, S.A.'," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("Tipo_de_orden")) + "," + FN.Campo_tabla(Dr("Total_bruto")) + "," + FN.Campo_tabla(Dr("Descuento")) + "," + FN.Campo_tabla(Dr("IVA")) + "," + FN.Campo_tabla(Dr("Total_neto")) + "," + FN.Campo_tabla(Dr("Tipo_de_liquidación")))
                            End If
                        End If
                    Next

                    Dim Dt_Didea As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Didea$]")
                    For Each Dr As DataRow In Dt_Didea.Rows
                        If Dr("Tipo_de_orden").ToString = "Garantia de Fábrica - T" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden ='DIDEA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_facturación", "Id_facturación,Empresa,Factura,Fecha_de_factura,No_de_orden,Tipo_de_orden,Total_bruto,Descuento,IVA,Total_neto,Tipo_de_liquidación", Now.ToString("yyMMddHHmmssfff") + ",'DIDEA, S.A.'," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("Tipo_de_orden")) + "," + FN.Campo_tabla(Dr("Total_bruto")) + "," + FN.Campo_tabla(Dr("Descuento")) + "," + FN.Campo_tabla(Dr("IVA")) + "," + FN.Campo_tabla(Dr("Total_neto")) + "," + FN.Campo_tabla(Dr("Tipo_de_liquidación")))
                            End If
                        End If
                    Next

                    Dim Dt_Autos_Europa As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Autos Europa$]")
                    For Each Dr As DataRow In Dt_Autos_Europa.Rows
                        If Dr("Tipo_de_orden").ToString = "Garantia de Fábrica - T" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden ='AUTOS EUROPA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_facturación", "Id_facturación,Empresa,Factura,Fecha_de_factura,No_de_orden,Tipo_de_orden,Total_bruto,Descuento,IVA,Total_neto,Tipo_de_liquidación", Now.ToString("yyMMddHHmmssfff") + ",'AUTOS EUROPA, S.A.'," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("Tipo_de_orden")) + "," + FN.Campo_tabla(Dr("Total_bruto")) + "," + FN.Campo_tabla(Dr("Descuento")) + "," + FN.Campo_tabla(Dr("IVA")) + "," + FN.Campo_tabla(Dr("Total_neto")) + "," + FN.Campo_tabla(Dr("Tipo_de_liquidación")))
                            End If
                        End If
                    Next

                End If

            Case "Saldos detalle"
                Cargar_saldos_detalle_facturación()

            Case "Saldo cero detalle"
                Cargar_saldo_cero_detalle_facturación()

            Case "Saldo por factura"
                Cargar_saldo_por_factura()

        End Select

    End Sub

    Private Sub Cargar_saldos_detalle_facturación()

        Dim DS As New DataSet

        DS.Tables.Add(SQL_FC.Tabla_con_actualización_de_datos("Select a.Id_facturación,a.Empresa,a.Factura,a.Fecha_de_factura,a.No_de_orden,a.Total_bruto,a.Descuento,a.IVA,a.Total_neto,a.Tipo_de_liquidación,IsNull(b.Valor_fabrica_GTQ,0) As Valor_fabrica_GTQ,IsNull(c.Valor_a_liquidar,0)-IsNull(b.Valor_fabrica_GTQ,0) As Diferencia From Garantias_fabrica_taller_facturación a Left Join (Select Empresa,Factura,No_de_orden,Sum(Valor_fabrica_GTQ) As Valor_fabrica_GTQ From Garantias_fabrica_taller_liquidación Group By Empresa,Factura,No_de_orden) b On a.Empresa=b.Empresa And a.Factura=b.Factura And a.No_de_orden=b.No_de_orden Left Join (Select Empresa,Factura,No_de_orden,IIF(Tipo_de_liquidación='Bruto',Total_bruto,Total_neto) As Valor_a_liquidar From Garantias_fabrica_taller_facturación) c On a.Empresa=c.Empresa And a.Factura=c.Factura And a.No_de_orden=c.No_de_orden where (IsNull(c.Valor_a_liquidar,0)-IsNull(b.Valor_fabrica_GTQ,0))<>0"))
        DS.Tables.Add(SQL_LQ.Tabla_con_actualización_de_datos("Select Id_liquidación,RL_Id_facturación,Transferencia,Fecha_de_transferencia,Valor_fabrica,Factor_de_cambio_USD,Factor_de_cambio_GTQ,Valor_fabrica_GTQ,Comentarios From Garantias_fabrica_taller_liquidación"))

        Dim KeyCol As DataColumn = DS.Tables(0).Columns("Id_facturación")
        Dim ForeIngKeyCol As DataColumn = DS.Tables(1).Columns("RL_Id_facturación")
        DS.Relations.Add("Liquidaciones", KeyCol, ForeIngKeyCol, False)

        GridControl_FC.DataSource = DS.Tables(0)
        GridControl_FC.ForceInitialize()

        Dim GridView_LQ As New DevExpress.XtraGrid.Views.Grid.GridView(GridControl_FC)
        GridControl_FC.LevelTree.Nodes.Add("Liquidaciones", GridView_LQ)

        With GridView_FC
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                Select Case CL.FieldName
                    Case "Id_facturación"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Total_bruto", "Descuento", "IVA", "Total_neto", "Diferencia"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"
                End Select

            Next
            AddHandler GridView_FC.RowCellStyle, Sub(s, e)
                                                     Dim CL As String = e.Column.FieldName
                                                     If CL = "Diferencia" Then
                                                         Select Case GridView_FC.GetRowCellValue(e.RowHandle, CL)
                                                             Case > 0
                                                                 e.Appearance.ForeColor = Color.Red
                                                             Case <= 0
                                                                 e.Appearance.ForeColor = Color.Green
                                                         End Select
                                                     End If
                                                 End Sub
            .OptionsBehavior.Editable = False
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

        With GridView_LQ
            .PopulateColumns(DS.Tables(1))
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                Select Case CL.FieldName
                    Case "Id_liquidación", "RL_Id_facturación", "Comentarios"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Comentarios"
                        .PreviewFieldName = CL.FieldName
                        .OptionsView.ShowPreview = True
                        .OptionsView.AutoCalcPreviewLineCount = True
                End Select

                Select Case CL.FieldName
                    Case "Valor_fabrica_USD", "Valor_fabrica_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

                Select Case CL.FieldName
                    Case "Factor_de_cambio_USD", "Factor_de_cambio_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n6"
                End Select

            Next
            AddHandler GridView_LQ.CustomDrawRowPreview, Sub(s, e)
                                                             e.Appearance.ForeColor = Color.Green
                                                         End Sub
            .OptionsBehavior.Editable = False
            .OptionsView.ShowGroupPanel = False
            .OptionsView.ShowFooter = True
            .OptionsSelection.MultiSelect = True
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
        Columna_tipo_de_liquidación()
    End Sub

    Private Sub Columna_tipo_de_liquidación()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim DT_TDL As New DataTable
        DT_TDL.Columns.Add("Tipo_de_liquidación")
        DT_TDL.Rows.Add("Bruto")
        DT_TDL.Rows.Add("Neto")

        With Item
            .DataSource = DT_TDL
            .ValueMember = "Tipo_de_liquidación"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_FC.Columns("Tipo_de_liquidación").ColumnEdit = Item
    End Sub


    Private Sub Cargar_saldo_cero_detalle_facturación()

        Dim DS As New DataSet

        DS.Tables.Add(SQL_FC.Tabla_con_actualización_de_datos("Select a.Id_facturación,a.Empresa,a.Factura,a.Fecha_de_factura,a.No_de_orden,a.Total_bruto,a.Descuento,a.IVA,a.Total_neto,a.Tipo_de_liquidación,IsNull(b.Valor_fabrica_GTQ,0) As Valor_fabrica_GTQ,IsNull(c.Valor_a_liquidar,0)-IsNull(b.Valor_fabrica_GTQ,0) As Diferencia From Garantias_fabrica_taller_facturación a Left Join (Select Empresa,Factura,No_de_orden,Sum(Valor_fabrica_GTQ) As Valor_fabrica_GTQ From Garantias_fabrica_taller_liquidación Group By Empresa,Factura,No_de_orden) b On a.Empresa=b.Empresa And a.Factura=b.Factura And a.No_de_orden=b.No_de_orden Left Join (Select Empresa,Factura,No_de_orden,IIF(Tipo_de_liquidación='Bruto',Total_bruto,Total_neto) As Valor_a_liquidar From Garantias_fabrica_taller_facturación) c On a.Empresa=c.Empresa And a.Factura=c.Factura And a.No_de_orden=c.No_de_orden where (IsNull(c.Valor_a_liquidar,0)-IsNull(b.Valor_fabrica_GTQ,0))=0"))
        DS.Tables.Add(SQL_LQ.Tabla_con_actualización_de_datos("Select Id_liquidación,RL_Id_facturación,Transferencia,Fecha_de_transferencia,Valor_fabrica,Factor_de_cambio_USD,Factor_de_cambio_GTQ,Valor_fabrica_GTQ,Comentarios From Garantias_fabrica_taller_liquidación"))

        Dim KeyCol As DataColumn = DS.Tables(0).Columns("Id_facturación")
        Dim ForeIngKeyCol As DataColumn = DS.Tables(1).Columns("RL_Id_facturación")
        DS.Relations.Add("Liquidaciones", KeyCol, ForeIngKeyCol, False)

        GridControl_FC.DataSource = DS.Tables(0)
        GridControl_FC.ForceInitialize()

        Dim GridView_LQ As New DevExpress.XtraGrid.Views.Grid.GridView(GridControl_FC)
        GridControl_FC.LevelTree.Nodes.Add("Liquidaciones", GridView_LQ)

        With GridView_FC
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                Select Case CL.FieldName
                    Case "Id_facturación"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Total_bruto", "Descuento", "IVA", "Total_neto", "Diferencia"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"
                End Select

            Next
            AddHandler GridView_FC.RowCellStyle, Sub(s, e)
                                                     Dim CL As String = e.Column.FieldName
                                                     If CL = "Diferencia" Then
                                                         Select Case GridView_FC.GetRowCellValue(e.RowHandle, CL)
                                                             Case > 0
                                                                 e.Appearance.ForeColor = Color.Red
                                                             Case <= 0
                                                                 e.Appearance.ForeColor = Color.Green
                                                         End Select
                                                     End If
                                                 End Sub
            .OptionsBehavior.Editable = False
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

        With GridView_LQ
            .PopulateColumns(DS.Tables(1))
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                Select Case CL.FieldName
                    Case "Id_liquidación", "RL_Id_facturación", "Comentarios"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Comentarios"
                        .PreviewFieldName = CL.FieldName
                        .OptionsView.ShowPreview = True
                        .OptionsView.AutoCalcPreviewLineCount = True
                End Select

                Select Case CL.FieldName
                    Case "Valor_fabrica_USD", "Valor_fabrica_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

                Select Case CL.FieldName
                    Case "Factor_de_cambio_USD", "Factor_de_cambio_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n6"
                End Select

            Next
            AddHandler GridView_LQ.CustomDrawRowPreview, Sub(s, e)
                                                             e.Appearance.ForeColor = Color.Green
                                                         End Sub
            .OptionsBehavior.Editable = False
            .OptionsView.ShowGroupPanel = False
            .OptionsView.ShowFooter = True
            .OptionsSelection.MultiSelect = True
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub

    Private Sub Cargar_saldo_por_factura()

        GridControl_FC.DataSource = SQL_FC.Tabla_de_datos("Select a.Empresa,a.Factura,a.Fecha_de_factura,SUM(a.Total_bruto) as Total_bruto,Sum(a.Descuento) as Descuento,Sum(a.IVA) as IVA,Sum(a.Total_neto) as Total_neto,a.Tipo_de_liquidación,IsNull(b.Valor_fabrica_GTQ,0) As Valor_fabrica_GTQ,IsNull(c.Valor_a_liquidar,0)-IsNull(b.Valor_fabrica_GTQ,0) As Diferencia From Garantias_fabrica_taller_facturación a Left Join (Select Empresa,Factura,IsNull(Sum(Valor_fabrica_GTQ),0) As Valor_fabrica_GTQ From Garantias_fabrica_taller_liquidación Group By Empresa,Factura) b On a.Empresa=b.Empresa And a.Factura=b.Factura Left Join (Select Empresa,Factura,IIF(Tipo_de_liquidación='Bruto',Sum(Total_bruto),Sum(Total_neto)) As Valor_a_liquidar From Garantias_fabrica_taller_facturación Group by Empresa,Factura,Tipo_de_liquidación) c On a.Empresa=c.Empresa And a.Factura=c.Factura Group by a.Empresa,a.Factura,a.Fecha_de_factura,a.Tipo_de_liquidación,b.Valor_fabrica_GTQ,c.Valor_a_liquidar")

        With GridView_FC
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If

                Select Case CL.FieldName
                    Case "Id_facturación"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Total_bruto", "Descuento", "IVA", "Total_neto", "Diferencia"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"
                End Select

            Next
            AddHandler GridView_FC.RowCellStyle, Sub(s, e)
                                                     Dim CL As String = e.Column.FieldName
                                                     If CL = "Diferencia" Then
                                                         Select Case GridView_FC.GetRowCellValue(e.RowHandle, CL)
                                                             Case > 0
                                                                 e.Appearance.ForeColor = Color.Red
                                                             Case <= 0
                                                                 e.Appearance.ForeColor = Color.Green
                                                         End Select
                                                     End If
                                                 End Sub
            .OptionsBehavior.Editable = False
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub

    Private Sub GridView_FC_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView_FC.RowUpdated
        SQL_FC.Actualizar_tabla()
    End Sub

    Private Sub GridView_FC_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView_FC.RowDeleted
        SQL_FC.Actualizar_tabla()
    End Sub

    Private Sub GridView_FC_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_FC.KeyDown
        If e.KeyData = Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    GridView_FC.DeleteRow(GridView_FC.FocusedRowHandle)
                End If
            End If
        End If
    End Sub

    Private Sub GC_Liquidación_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Liquidación.CustomButtonClick
        Select Case e.Button.Properties.Caption

            Case "Cargar liquidación"
                Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx;*.xlsm"}
                If File.ShowDialog() = DialogResult.OK Then

                    Dim Dt_Uniauto As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Uniauto$]")
                    For Each Dr As DataRow In Dt_Uniauto.Rows
                        If Dr("Transferencia").ToString <> "" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_liquidación", "Where Empresa+Factura+No_de_orden+Transferencia ='UNIAUTO, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + Dr("Transferencia").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_liquidación", "Id_liquidación,RL_Id_facturación,Empresa,Transferencia,Fecha_de_transferencia,Factura,Fecha_de_factura,No_de_orden,VIN,Valor_fabrica,Factor_de_cambio_USD,Factor_de_cambio_GTQ,Valor_fabrica_GTQ,Comentarios", Now.ToString("yyMMddHHmmssfff") + "," + FN.Campo_tabla(SQL.Extraer_informacion_de_columna("Id_facturación", "Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden='UNIAUTO, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'")) + ",'UNIAUTO, S.A.'," + FN.Campo_tabla(Dr("Transferencia")) + "," + FN.Campo_tabla(Dr("Fecha_de_transferencia")) + "," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha_de_factura")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("VIN")) + "," + FN.Campo_tabla(Dr("Valor_fabrica")) + "," + FN.Campo_tabla(Dr("Factor_de_cambio_USD")) + "," + FN.Campo_tabla(Dr("Factor_de_cambio_GTQ")) + "," + FN.Campo_tabla(Dr("Valor_fabrica_GTQ")) + "," + FN.Campo_tabla(Dr("Comentarios")))
                            End If
                        End If
                    Next

                    Dim Dt_Didea As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Didea$]")
                    For Each Dr As DataRow In Dt_Didea.Rows
                        If Dr("Transferencia").ToString <> "" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_liquidación", "Where Empresa+Factura+No_de_orden+Transferencia ='DIDEA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + Dr("Transferencia").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_liquidación", "Id_liquidación,RL_Id_facturación,Empresa,Transferencia,Fecha_de_transferencia,Factura,Fecha_de_factura,No_de_orden,VIN,Valor_fabrica,Factor_de_cambio_USD,Factor_de_cambio_GTQ,Valor_fabrica_GTQ,Comentarios", Now.ToString("yyMMddHHmmssfff") + "," + FN.Campo_tabla(SQL.Extraer_informacion_de_columna("Id_facturación", "Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden='DIDEA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'")) + ",'DIDEA, S.A.'," + FN.Campo_tabla(Dr("Transferencia")) + "," + FN.Campo_tabla(Dr("Fecha_de_transferencia")) + "," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha_de_factura")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("VIN")) + "," + FN.Campo_tabla(Dr("Valor_fabrica")) + "," + FN.Campo_tabla(Dr("Factor_de_cambio_USD")) + "," + FN.Campo_tabla(Dr("Factor_de_cambio_GTQ")) + "," + FN.Campo_tabla(Dr("Valor_fabrica_GTQ")) + "," + FN.Campo_tabla(Dr("Comentarios")))
                            End If
                        End If
                    Next

                    Dim Dt_Autos_Europa As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Autos Europa$]")
                    For Each Dr As DataRow In Dt_Autos_Europa.Rows
                        If Dr("Transferencia").ToString <> "" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_liquidación", "Where Empresa+Factura+No_de_orden+Transferencia ='AUTOS EUROPA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + Dr("Transferencia").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_liquidación", "Id_liquidación,RL_Id_facturación,Empresa,Transferencia,Fecha_de_transferencia,Factura,Fecha_de_factura,No_de_orden,VIN,Valor_fabrica,Factor_de_cambio_USD,Factor_de_cambio_GTQ,Valor_fabrica_GTQ,Comentarios", Now.ToString("yyMMddHHmmssfff") + "," + FN.Campo_tabla(SQL.Extraer_informacion_de_columna("Id_facturación", "Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden='AUTOS EUROPA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'")) + ",'AUTOS EUROPA, S.A.'," + FN.Campo_tabla(Dr("Transferencia")) + "," + FN.Campo_tabla(Dr("Fecha_de_transferencia")) + "," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha_de_factura")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("VIN")) + "," + FN.Campo_tabla(Dr("Valor_fabrica")) + "," + FN.Campo_tabla(Dr("Factor_de_cambio_USD")) + "," + FN.Campo_tabla(Dr("Factor_de_cambio_GTQ")) + "," + FN.Campo_tabla(Dr("Valor_fabrica_GTQ")) + "," + FN.Campo_tabla(Dr("Comentarios")))
                            End If
                        End If
                    Next

                End If

            Case "Saldos"


        End Select

    End Sub

End Class