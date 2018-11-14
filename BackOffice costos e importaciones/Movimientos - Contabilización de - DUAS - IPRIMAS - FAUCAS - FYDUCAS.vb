Public Class Movimientos_Contabilización_de_DUAS_IPRIMAS_FAUCAS_FYDUCAS
    Dim SQL As New BackOffice_datos.SQL, SQL_Proveedores As New BackOffice_datos.SQL, SQL_Cuentas_y_complementos As New BackOffice_datos.SQL, SQL_Países As New BackOffice_datos.SQL, SQL_Aduanas As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Dim Edicion As Boolean, MT As String, Descripción_contable As String

    Private Sub Movimientos_Contabilización_de_DUAS_IPRIMAS_FAUCAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        BBI_Cancelar_ItemClick(sender, Nothing)
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub Cargar_datos()

        With LUE_Empresa.Properties
            .DataSource = SQL.Tabla_de_datos("Select Empresa From DUAS_IPRIMAS_FAUCAS_Cuentas_y_complementos Group By Empresa")
            .ValueMember = "Empresa"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Empresa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Empresa.Validating
        FN.Validar_campos(LUE_Empresa, "Debes asignar una empresa", DxErrorProvider)
    End Sub

    Private Sub BBI_Nuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Nuevo.ItemClick
        FN.Limpiar_controles(GC_Datos_de_registro) : FN.Habilitar_controles(GC_Datos_de_registro)
        TE_Lote_No.EditValue = Now.ToString("yyMMddHHmmssfff")
        Duas_Iprimas_Faucas("Where RL_Lote_No =" + Val(TE_Lote_No.EditValue).ToString) : GridView_DC.OptionsBehavior.Editable = True
        Cargar_contabilidad() : GridView_CT.OptionsBehavior.Editable = False
        ValidateChildren()
        FN.Estado_del_menú("Guardar", BarManager)
    End Sub

    Private Sub BBI_Guardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar.ItemClick
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Try
                If Edicion = False Then
                    SQL.Insertar("DUAS_IPRIMAS_FAUCAS_Registro", "Lote_No,Empresa", TE_Lote_No.EditValue.ToString + "," + FN.Campo(LUE_Empresa))

                    If GridView_DC.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DC.DataRowCount - 1
                            GridView_DC.PostEditor()
                            GridView_DC.UpdateCurrentRow()
                        Next
                    End If

                    SQL.Actualizar_tabla()
                    FN.Deshabilitar_controles(GC_Datos_de_registro)
                    GridView_DC.OptionsBehavior.Editable = False
                    FN.Estado_del_menú("Buscar", BarManager)

                ElseIf Edicion = True Then

                    SQL.Actualizar("DUAS_IPRIMAS_FAUCAS_Registro", "Empresa=" + FN.Campo(LUE_Empresa), "Lote_No=" + Val(TE_Lote_No.EditValue).ToString)

                    If GridView_DC.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DC.DataRowCount - 1
                            GridView_DC.PostEditor()
                            GridView_DC.UpdateCurrentRow()
                        Next
                    End If

                    SQL.Actualizar_tabla()
                    FN.Deshabilitar_controles(GC_Datos_de_registro)
                    GridView_DC.OptionsBehavior.Editable = False
                    FN.Estado_del_menú("Buscar", BarManager)

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Recepción de costeos")
            End Try
        Else
            MsgBox("Por favor valida los campos o datos obligatorios", MsgBoxStyle.Critical, "Recepción de costeos")
        End If
    End Sub

    Private Sub BBI_Cancelar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cancelar.ItemClick
        FN.Limpiar_controles(GC_Datos_de_registro) : FN.Deshabilitar_controles(GC_Datos_de_registro)
        Duas_Iprimas_Faucas("Where RL_Lote_No =" + Val(TE_Lote_No.EditValue).ToString) : GridView_DC.OptionsBehavior.Editable = False
        Cargar_contabilidad() : GridView_CT.OptionsBehavior.Editable = False
        ValidateChildren()
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub BBI_Editar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Editar.ItemClick
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Editar"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                Edicion = True
                GridView_DC.OptionsBehavior.Editable = True
                FN.Estado_del_menú("Guardar", BarManager)
            End If
        End If
    End Sub

    Private Sub BBI_Eliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Eliminar.ItemClick
        If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    SQL.Eliminar("DUAS_IPRIMAS_FAUCAS_Registro", "Lote_No=" + TE_Lote_No.ToString)
                    SQL.Eliminar("DUAS_IPRIMAS_FAUCAS", "RL_Lote_No=" + TE_Lote_No.ToString)
                    BBI_Cancelar_ItemClick(sender, Nothing)
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar usuario")
            End Try
        End If
    End Sub

    Private Sub BBI_Buscar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Buscar.ItemClick
        Dim BSQ As New BackOffice_servicios.Busqueda With {.Consulta = "Select Empresa,Lote_No,RL_Lote_No,Régimen,Documento,Fecha,Aduana_de_despacho+'-'+No_de_DUA as DUA,País_de_procedencia,Pedido,Proveedor  From DUAS_IPRIMAS_FAUCAS INNER JOIN DUAS_IPRIMAS_FAUCAS_Registro ON RL_Lote_No = Lote_No", .Columna_ID = "RL_Lote_No", .Alinear = ""}
        BSQ.ShowDialog()
        If BSQ.ID_resultado <> 0 Then TE_Lote_No.EditValue = BSQ.ID_resultado : FN.Estado_del_menú("Buscar", BarManager) : Datos_consulta() : BSQ.Dispose()
    End Sub

    Public Sub Datos_consulta()

        Dim Dt As DataTable = SQL.Tabla_de_datos("Select * From DUAS_IPRIMAS_FAUCAS_Registro Where Lote_No =" + TE_Lote_No.EditValue.ToString)

        'Datos de registro
        FN.Limpiar_controles(GC_Datos_de_registro)
        TE_Lote_No.EditValue = FN.Valor(Dt.Rows(0)("Lote_No"))
        LUE_Empresa.EditValue = FN.Valor(Dt.Rows(0)("Empresa"))

        'Datos documentos
        Duas_Iprimas_Faucas("Where RL_Lote_No =" + Val(TE_Lote_No.EditValue).ToString)

        'Contabilidad
        Cargar_contabilidad()

    End Sub


#Region "DUAS - IPRIMAS - FAUCAS - FYDUCAS"

    Private Sub Duas_Iprimas_Faucas(Condición As String)
        GridControl_DC.DataSource = SQL.Tabla_con_actualización_de_datos("Select * From DUAS_IPRIMAS_FAUCAS " + Condición)
        Configurar_Duas_Iprimas_Faucas()
    End Sub

    Private Sub Configurar_Duas_Iprimas_Faucas()
        With GridView_DC
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "d"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Id_documento", "RL_Lote_No"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Total_pago", "DAI", "IVA", "Diferencia"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

                Select Case CL.FieldName
                    Case "Diferencia"
                        CL.OptionsColumn.ReadOnly = True
                End Select

            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
        Columna_tipo_de_documento()
        Columna_régimen()
        Columna_fecha()
        Columna_aduana()
        Columna_país()
        Columna_proveedor()
    End Sub

    Private Sub GridView_DC_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView_DC.InitNewRow

        GridView_DC.SetRowCellValue(e.RowHandle, "Id_documento", Format(Now, "yyMMddHHmmssfff"))
        GridView_DC.SetRowCellValue(e.RowHandle, "RL_Lote_No", TE_Lote_No.EditValue)

    End Sub

    Private Sub GridView_DC_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView_DC.ValidateRow
        Dim i As Integer = e.RowHandle

        If GridView_DC.GetRowCellValue(i, "Tipo_de_documento").ToString <> "" And Val(GridView_DC.GetRowCellValue(i, "Diferencia").ToString) = 0 Then
            e.Valid = True
        Else
            e.ErrorText = "Valida los campos tipo de ducumento y diferencia"
            e.Valid = False
        End If

    End Sub

    Private Sub Columna_tipo_de_documento()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim DT_TDC As New DataTable
        DT_TDC.Columns.Add("Tipo_de_documento")
        DT_TDC.Columns.Add("Descripción")
        DT_TDC.Rows.Add("DUA", "Declaración Única Aduanera")
        DT_TDC.Rows.Add("IPRIMA", "Impuesto a la Primera Matrícula")
        DT_TDC.Rows.Add("FAUCA", "Formulario Aduanero Único Centroamericano")
        DT_TDC.Rows.Add("FYDUCA", "Factura y Declaración Única Centroamericana")

        With Item
            .DataSource = DT_TDC
            .ValueMember = "Tipo_de_documento"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DC.Columns("Tipo_de_documento").ColumnEdit = Item
    End Sub

    Private Sub Columna_régimen()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Modalidad From Tipos_de_modalidades_DUA_GT Order By Modalidad")
            .ValueMember = "Modalidad"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DC.Columns("Régimen").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "d"
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            .Mask.UseMaskAsDisplayFormat = True
        End With
        GridView_DC.Columns("Fecha").ColumnEdit = Item
    End Sub

    Private Sub Columna_aduana()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Código,Aduana From DUAS_IPRIMAS_FAUCAS_Aduanas Order By Código")
            .Name = "Aduana"
            .ValueMember = "Código"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DC.Columns("Aduana_de_despacho").ColumnEdit = Item
    End Sub

    Private Sub Columna_país()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select [ISO-3166-1-Alfa2],Pais From DUAS_IPRIMAS_FAUCAS_Clasificación_de_países Order By [ISO-3166-1-Alfa2]")
            .ValueMember = "ISO-3166-1-Alfa2"
            .Name = "País"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DC.Columns("País_de_procedencia").ColumnEdit = Item
    End Sub

    Private Sub Columna_proveedor()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Proveedor From DUAS_IPRIMAS_FAUCAS_Proveedores Order By Proveedor")
            .ValueMember = "Proveedor"
            .Name = "Proveedor"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DC.Columns("Proveedor").ColumnEdit = Item
    End Sub

    Private Sub GridView_DC_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView_DC.CellValueChanged
        Dim CL As String = e.Column.FieldName, i As Integer = e.RowHandle
        If CL = "Total_pago" Or CL = "DAI" Or CL = "IVA" Then
            GridView_DC.SetRowCellValue(i, "Diferencia", Math.Round(Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString) - Val(GridView_DC.GetRowCellValue(i, "DAI").ToString) - Val(GridView_DC.GetRowCellValue(i, "IVA").ToString), 2))
        End If
    End Sub

    Private Sub GridView_DC_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView_DC.CustomRowCellEditForEditing
        If e.RepositoryItem.Name = "Aduana" Then
            Columna_aduana()
        End If
        If e.RepositoryItem.Name = "País" Then
            Columna_país()
        End If
        If e.RepositoryItem.Name = "Proveedor" Then
            Columna_proveedor()
        End If
    End Sub

    Private Sub GC_DUAS_IPRIMAS_FAUCAS_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_DUAS_IPRIMAS_FAUCAS.CustomButtonClick

        Select Case e.Button.Properties.Caption

            Case "Imprimir"
                If GridControl_DC.IsPrintingAvailable Then
                    GridView_DC.OptionsPrint.UsePrintStyles = True
                    GridView_DC.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 6)
                    GridView_DC.AppearancePrint.Row.Font = New Font("Tahoma", 6)
                    GridView_DC.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 6)
                    GridControl_DC.ShowPrintPreview()
                End If
        End Select

    End Sub

    Private Sub GridView_DC_PrintInitialize(sender As Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView_DC.PrintInitialize
        Dim PSB As DevExpress.XtraPrinting.PrintingSystemBase = CType(e.PrintingSystem, DevExpress.XtraPrinting.PrintingSystemBase)
        PSB.PageSettings.Landscape = True
        PSB.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter



        PSB.PageSettings.TopMargin = 100
        PSB.PageSettings.LeftMargin = 0
        PSB.PageSettings.RightMargin = 0
        PSB.PageSettings.BottomMargin = 100


        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.Content.AddRange(New String() {"", "Contabilización de DUAS - IPRIMAS - FAUCAS " + LUE_Empresa.EditValue, ""})
        CType(e.Link.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Content.AddRange(New String() {"", "", "Pages: [Page # of Pages #]"})

    End Sub

    Private Sub GridView_DC_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_DC.KeyDown
        If e.KeyData = Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                GridView_MT.DeleteRow(GridView_MT.FocusedRowHandle)

            End If
        ElseIf e.KeyData = Keys.Control + Keys.Delete Then
            GridView_DC.SetRowCellValue(GridView_DC.FocusedRowHandle, GridView_DC.FocusedColumn, Nothing)
        End If


    End Sub

#End Region

#Region "Contabilidad"

    Private Function Tabla_contabilidad() As DataTable
        Dim DT As New DataTable
        DT.Columns.Add("Alterno", GetType(Integer))
        DT.Columns.Add("SE", GetType(Integer))
        DT.Columns.Add("DP", GetType(Integer))
        DT.Columns.Add("SC", GetType(Integer))
        DT.Columns.Add("CC", GetType(Integer))
        DT.Columns.Add("Descripción", GetType(String))
        DT.Columns.Add("Documento", GetType(String))
        DT.Columns.Add("Debe", GetType(Double))
        DT.Columns.Add("Haber", GetType(Double))
        DT.Columns.Add("Agrupador", GetType(Integer))
        DT.Columns.Add("Empleado_ISR", GetType(Integer))
        DT.Columns.Add("TRN_IVA", GetType(Integer))
        DT.Columns.Add("Proveedor_IVA", GetType(Integer))
        DT.Columns.Add("Fecha_IVA", GetType(Date))
        Return DT
    End Function

    Private Sub Cargar_contabilidad()
        GridControl_CT.DataSource = Tabla_contabilidad()
        Configurar_contabilidad()
    End Sub

    Private Sub Configurar_contabilidad()

        With GridView_CT

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                CL.Caption = Replace(CL.FieldName, "_", " ")

                Select Case CL.FieldName
                    Case "Alterno", "SE", "DP", "SC", "CC"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "0"
                End Select

                Select Case CL.FieldName
                    Case "Alterno"
                        CL.Width = 40
                    Case "SE", "DP", "SC", "CC"
                        CL.Width = 30
                    Case "Descripción"
                        CL.Width = 280
                    Case "Documento"
                        CL.Width = 75
                    Case "Agrupador", "Empleado_ISR", "TRN_IVA", "Proveedor_IVA", "Fecha_IVA"
                        CL.Width = 40
                End Select

                Select Case CL.FieldName
                    Case "Debe", "Haber"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"
                        CL.Width = 75

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

            Next

        End With

    End Sub

    Public Function Texto(Tx As String, Información As Object, Optional Es_fecha As Boolean = False) As String

        If IsDBNull(Información) Then
            Return Nothing
        ElseIf Es_fecha = True Then
            Return UCase(Tx + CDate(Información).ToShortDateString)
        Else
            Return UCase(Tx + Información.ToString)
        End If

    End Function


    Private Sub GC_Contabilidad_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Contabilidad.CustomButtonClick
        Dim Dt As DataTable = SQL.Tabla_de_datos("Select * From DUAS_IPRIMAS_FAUCAS_Cuentas_y_complementos Where Empresa='" + LUE_Empresa.EditValue + "'")

        Select Case e.Button.Properties.Caption

            Case "Generar partida"

                Cargar_contabilidad()
                Descripción_contable = "Liquidación VGC impuestos de importación RF " + TE_Lote_No.EditValue.ToString

                If GridView_DC.RowCount > 0 Then
                    For i As Integer = 0 To GridView_DC.DataRowCount - 1

                        If GridView_DC.GetRowCellValue(i, "Total_pago") <> 0 Then

                            Select Case GridView_DC.GetRowCellValue(i, "Tipo_de_documento").ToString

                                Case "DUA"

                                    'DAI
                                    If Val(GridView_DC.GetRowCellValue(i, "DAI").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + " DAI " + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Val(GridView_DC.GetRowCellValue(i, "DAI").ToString))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                                        End If

                                    End If

                                    'IVA
                                    If Val(GridView_DC.GetRowCellValue(i, "IVA").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + " IVA " + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Val(GridView_DC.GetRowCellValue(i, "IVA").ToString))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)


                                            GridView_CT.SetRowCellValue(Dr, "Agrupador", SQL.Extraer_informacion_de_columna("Clasificación", "DUAS_IPRIMAS_FAUCAS_Clasificación_de_países", " Where [ISO-3166-1-Alfa2] = '" + GridView_DC.GetRowCellValue(i, "País_de_procedencia").ToString + "'"))
                                            GridView_CT.SetRowCellValue(Dr, "TRN_IVA", Dt.Rows(0)("TRN_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "Proveedor_IVA", Dt.Rows(0)("Prov_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "Fecha_IVA", GridView_DC.GetRowCellValue(i, "Fecha").ToString)

                                        End If

                                    End If

                                    'Total pago
                                    If Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + Texto(" Liquidación ", GridView_DC.GetRowCellValue(i, "Tipo_de_documento")) + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString))

                                        End If

                                    End If

                                Case "IPRIMA"

                                    'DAI
                                    If Val(GridView_DC.GetRowCellValue(i, "DAI").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_DAI"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Tipo_de_documento")) + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Val(GridView_DC.GetRowCellValue(i, "DAI").ToString))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                                        End If

                                    End If

                                    'Total pago
                                    If Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + Texto(" Liquidación ", GridView_DC.GetRowCellValue(i, "Tipo_de_documento")) + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString))

                                        End If

                                    End If

                                Case "FAUCA", "FYDUCA"

                                    'IVA
                                    If Val(GridView_DC.GetRowCellValue(i, "IVA").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + " IVA " + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Val(GridView_DC.GetRowCellValue(i, "IVA").ToString))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)


                                            GridView_CT.SetRowCellValue(Dr, "Agrupador", SQL.Extraer_informacion_de_columna("Clasificación", "DUAS_IPRIMAS_FAUCAS_Clasificación_de_países", " Where [ISO-3166-1-Alfa2] = '" + GridView_DC.GetRowCellValue(i, "País_de_procedencia").ToString + "'"))
                                            GridView_CT.SetRowCellValue(Dr, "TRN_IVA", Dt.Rows(0)("TRN_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "Proveedor_IVA", Dt.Rows(0)("Prov_IVA"))
                                            GridView_CT.SetRowCellValue(Dr, "Fecha_IVA", GridView_DC.GetRowCellValue(i, "Fecha").ToString)

                                        End If

                                    End If

                                    'Total pago
                                    If Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString) <> 0 Then

                                        GridView_CT.AddNewRow()
                                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                        If GridView_CT.IsNewItemRow(Dr) Then

                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_CLI"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", FN.Quitar_espacios_innecesarios(Texto("", GridView_DC.GetRowCellValue(i, "Régimen")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Documento")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Fecha"), True) + Texto(" ", GridView_DC.GetRowCellValue(i, "Aduana_de_despacho")) + Texto("-", GridView_DC.GetRowCellValue(i, "No_de_DUA")) + Texto(" Liquidación ", GridView_DC.GetRowCellValue(i, "Tipo_de_documento")) + Texto(" Pedido ", GridView_DC.GetRowCellValue(i, "Pedido")) + Texto(" Proveedor ", GridView_DC.GetRowCellValue(i, "Proveedor")) + Texto(" ", GridView_DC.GetRowCellValue(i, "Descripción"))))
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(Replace(GridView_DC.GetRowCellValue(i, "Documento").ToString, "-", ""), 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Val(GridView_DC.GetRowCellValue(i, "Total_pago").ToString))

                                        End If

                                    End If

                            End Select
                            GridView_CT.PostEditor()
                            GridView_CT.UpdateCurrentRow()
                        End If
                    Next
                End If


            Case "Contabilizar"

                If GridView_CT.RowCount > 0 Then

                    AppActivate("Menu Principal Contabilidad")

                    SendKeys.Send(Descripción_contable)
                    SendKeys.Send("{TAB 2}")

                    For i As Integer = 0 To GridView_CT.RowCount - 1

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "Alterno"))
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "SE"))
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "DP"))
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "SC"))
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "CC"))
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "Descripción"))
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(GridView_CT.GetRowCellValue(i, "Documento"))
                        SendKeys.Send("{TAB}")

                        If GridView_CT.GetRowCellValue(i, "Debe") - GridView_CT.GetRowCellValue(i, "Haber") >= 0 Then SendKeys.Send("D") Else SendKeys.Send("H")
                        SendKeys.Send("{TAB}")

                        SendKeys.Send(Math.Abs(GridView_CT.GetRowCellValue(i, "Debe") - GridView_CT.GetRowCellValue(i, "Haber")))
                        SendKeys.Send("{TAB}")

                        If GridView_CT.GetRowCellValue(i, "Alterno") = 10081 Then
                            SendKeys.Send(GridView_CT.GetRowCellValue(i, "Agrupador").ToString)
                            SendKeys.Send("{TAB 2}")
                            SendKeys.Send(GridView_CT.GetRowCellValue(i, "TRN_IVA"))
                            SendKeys.Send("{TAB}")
                            SendKeys.Send(GridView_CT.GetRowCellValue(i, "Proveedor_IVA"))
                            SendKeys.Send("{TAB 2}")
                            SendKeys.Send("N")
                            SendKeys.Send("Normal")
                            SendKeys.Send("{TAB}")
                            SendKeys.Send(Replace(GridView_CT.GetRowCellValue(i, "Documento").ToString, "-", ""))
                            SendKeys.Send("{TAB}")
                            SendKeys.Send("{ENTER}")
                            SendKeys.Send("{TAB 2}")
                            If CDate(GridView_CT.GetRowCellValue(i, "Fecha_IVA")).ToString("dd") = 31 Then
                                SendKeys.Send(CDate(GridView_CT.GetRowCellValue(i, "Fecha_IVA")).ToString("/MM/yyyy/"))
                                SendKeys.Send(CDate(GridView_CT.GetRowCellValue(i, "Fecha_IVA")).ToShortDateString)
                            Else
                                SendKeys.Send(CDate(GridView_CT.GetRowCellValue(i, "Fecha_IVA")).ToShortDateString)
                            End If
                            SendKeys.Send("{TAB 11}")
                            SendKeys.Send(Math.Abs(GridView_CT.GetRowCellValue(i, "Debe") - GridView_CT.GetRowCellValue(i, "Haber")))
                            SendKeys.Send("{TAB 2}")
                            SendKeys.Send("^g")
                        Else
                            SendKeys.Send("{TAB 2}")
                        End If

                    Next

                End If

        End Select

    End Sub

#End Region

#Region "Mantenimiento"

    Private Sub GroupControl_MT_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GroupControl_MT.CustomButtonClick
        GridControl_MT.DataSource = Nothing
        GridView_MT.Columns.Clear()

        Select Case e.Button.Properties.Caption

            Case "Proveedores"
                MT = e.Button.Properties.Caption
                Mantenimiento(Nothing)

            Case "Cuentas y complementos"
                MT = e.Button.Properties.Caption
                Mantenimiento(Nothing)

            Case "Países"
                MT = e.Button.Properties.Caption
                Mantenimiento(Nothing)

            Case "Aduanas"
                MT = e.Button.Properties.Caption
                Mantenimiento(Nothing)

        End Select
    End Sub

    Private Sub Mantenimiento(Condición As String)

        Select Case MT

            Case "Proveedores"
                GridControl_MT.DataSource = SQL_Proveedores.Tabla_con_actualización_de_datos("Select * From DUAS_IPRIMAS_FAUCAS_Proveedores " + Condición)
                Configurar_mantenimiento()
            Case "Cuentas y complementos"
                GridControl_MT.DataSource = SQL_Cuentas_y_complementos.Tabla_con_actualización_de_datos("Select * From DUAS_IPRIMAS_FAUCAS_Cuentas_y_complementos " + Condición)
                Configurar_mantenimiento()
            Case "Países"
                GridControl_MT.DataSource = SQL_Países.Tabla_con_actualización_de_datos("Select * From DUAS_IPRIMAS_FAUCAS_Clasificación_de_países " + Condición)
                Configurar_mantenimiento()
            Case "Aduanas"
                GridControl_MT.DataSource = SQL_Aduanas.Tabla_con_actualización_de_datos("Select * From DUAS_IPRIMAS_FAUCAS_Aduanas " + Condición)
                Configurar_mantenimiento()
        End Select

    End Sub

    Private Sub Configurar_mantenimiento()
        With GridView_MT
            Select Case MT

                Case "Proveedores"
                    For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                        CL.Caption = Replace(CL.FieldName, "_", " ")
                        Select Case CL.FieldName
                            Case "Id_proveedor"
                                CL.Visible = False
                        End Select
                    Next

                Case "Cuentas y complementos"
                    For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                        CL.Caption = Replace(CL.FieldName, "_", " ")
                        Select Case CL.FieldName
                            Case "Id_cts_comp"
                                CL.Visible = False
                        End Select

                        Select Case CL.FieldName
                            Case "CT_DAI", "CT_CLI", "CT_IVA"
                                CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                CL.DisplayFormat.FormatString = "00000"
                                CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                                CL.AppearanceCell.BackColor = Color.FromArgb(214, 219, 223)
                        End Select

                        Select Case CL.FieldName
                            Case "SE_DAI", "DP_DAI", "SC_DAI", "CC_DAI",
                                 "SE_CLI", "DP_CLI", "SC_CLI", "CC_CLI",
                                 "SE_IVA", "DP_IVA", "SC_IVA", "CC_IVA"
                                CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                CL.DisplayFormat.FormatString = "00"
                                CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        End Select

                        Select Case CL.FieldName
                            Case "TRN_IVA", "Prov_IVA"
                                CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        End Select

                    Next

                    Columna_empresa()

                Case "Países"
                    For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                        CL.Caption = Replace(CL.FieldName, "_", " ")
                        Select Case CL.FieldName
                            Case "Id_país"
                                CL.Visible = False
                        End Select
                    Next

                Case "Aduanas"
                    For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                        CL.Caption = Replace(CL.FieldName, "_", " ")
                        Select Case CL.FieldName
                            Case "Id_aduana"
                                CL.Visible = False
                        End Select

                        Select Case CL.FieldName
                            Case "Código"
                                CL.OptionsColumn.ReadOnly = True
                        End Select

                    Next

            End Select
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
    End Sub

    Private Sub GridView_MT_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView_MT.InitNewRow

        Select Case MT

            Case "Proveedores"

                GridView_MT.SetRowCellValue(e.RowHandle, "Id_proveedor", SQL_Proveedores.Nuevo_ID("Id_proveedor", "DUAS_IPRIMAS_FAUCAS_Proveedores"))

            Case "Cuentas y complementos"

                GridView_MT.SetRowCellValue(e.RowHandle, "Id_cts_comp", SQL_Cuentas_y_complementos.Nuevo_ID("Id_cts_comp", "DUAS_IPRIMAS_FAUCAS_Cuentas_y_complementos"))

            Case "Países"

                GridView_MT.SetRowCellValue(e.RowHandle, "Id_país", SQL_Países.Nuevo_ID("Id_país", "DUAS_IPRIMAS_FAUCAS_Clasificación_de_países"))

            Case "Aduanas"

                GridView_MT.SetRowCellValue(e.RowHandle, "Id_aduana", SQL_Aduanas.Nuevo_ID("Id_aduana", "DUAS_IPRIMAS_FAUCAS_Aduanas"))

        End Select

    End Sub

    Private Sub GridView_MT_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView_MT.RowUpdated

        Select Case MT

            Case "Proveedores"

                SQL_Proveedores.Actualizar_tabla()

            Case "Cuentas y complementos"

                SQL_Cuentas_y_complementos.Actualizar_tabla()

            Case "Países"

                SQL_Países.Actualizar_tabla()

            Case "Aduanas"

                SQL_Aduanas.Actualizar_tabla()

        End Select

    End Sub

    Private Sub GridView_MT_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView_MT.RowDeleted

        Select Case MT

            Case "Proveedores"

                SQL_Proveedores.Actualizar_tabla()

            Case "Cuentas y complementos"

                SQL_Cuentas_y_complementos.Actualizar_tabla()

            Case "Países"

                SQL_Países.Actualizar_tabla()

            Case "Aduanas"

                SQL_Aduanas.Actualizar_tabla()

        End Select

    End Sub

    Private Sub GridView_MT_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_MT.KeyDown
        If e.KeyData = Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                GridView_MT.DeleteRow(GridView_MT.FocusedRowHandle)

            End If
        End If
    End Sub

    Private Sub Columna_empresa()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Empresa From Directorios_y_correos Group By Empresa")
            .ValueMember = "Empresa"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_MT.Columns("Empresa").ColumnEdit = Item
    End Sub

#End Region

    Private Sub Movimientos_Contabilización_de_DUAS_IPRIMAS_FAUCAS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F3 And BBI_Buscar.Enabled = True Then
            BBI_Buscar_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.N And BBI_Nuevo.Enabled = True Then
            BBI_Nuevo_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.G And BBI_Guardar.Enabled = True Then
            BBI_Guardar_ItemClick(sender, Nothing)
        End If
    End Sub

End Class