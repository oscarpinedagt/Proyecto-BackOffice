Public Class Movimientos_Elaboración_de_costeos
    Dim SQL As New BackOffice_datos.SQL, SQL_DE As New BackOffice_datos.SQL, SQL_DL As New BackOffice_datos.SQL, SQL_SG As New BackOffice_datos.SQL, SQL_CF As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Dim CT As Costeo
    Dim Edicion As Boolean, Editables As String, Descripción_contable As String
    Public Property ID As Integer

    Private Sub Elaboración_y_seguimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        BBI_Cancelar_ItemClick(sender, Nothing)
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

#Region "Carga de datos"

    Private Sub Cargar_datos()

        With LUE_Empresa.Properties
            .DataSource = SQL.Tabla_de_datos("Select Empresa From Directorios_y_correos Group By Empresa")
            .ValueMember = "Empresa"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Tipo_de_costeo.Properties
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_costeo From Tipos_de_costeo")
            .ValueMember = "Tipo_de_costeo"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Estado.Properties
            .DataSource = SQL.Tabla_de_datos("Select Estado,Información From Estados")
            .ValueMember = "Estado"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Tipo_de_importación.Properties
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_importacion From Tipos_de_importacion")
            .ValueMember = "Tipo_de_importacion"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Incoterm.Properties
            .DataSource = SQL.Tabla_de_datos("Select Incoterm From Incoterms")
            .ValueMember = "Incoterm"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Moneda_de_negociación.Properties
            .DataSource = SQL.Tabla_de_datos("Select Moneda From Tipos_de_moneda Order By Moneda")
            .ValueMember = "Moneda"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Shipper_Carrier.Properties
            .DataSource = SQL.Tabla_de_datos("Select Razon_comercial From Shipper_Carrier Order By Razon_comercial")
            .ValueMember = "Razon_comercial"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Moneda.Properties
            .DataSource = SQL.Tabla_de_datos("Select Moneda From Tipos_de_moneda Order By Moneda")
            .ValueMember = "Moneda"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Régimen.Properties
            .DataSource = SQL.Tabla_de_datos("Select Modalidad From Tipos_de_modalidades_DUA_GT Order By Modalidad")
            .ValueMember = "Modalidad"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Costeo_asignado_a.Properties
            .DataSource = SQL.Tabla_de_datos("Select a.Nombres+' '+a.Apellidos As Nombre From Usuarios a,Complementos_del_puesto b Where a.Id_usuario<>0 AND a.RL_CP=b.Id_CP AND b.Division='Costos e Importaciones'")
            .ValueMember = "Nombre"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

#End Region

    Private Sub LUE_Empresa_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Empresa.EditValueChanged

        LUE_Tipo_de_mercadería.EditValue = Nothing
        LUE_Sub_empresa.EditValue = Nothing
        LUE_Proveedor.EditValue = Nothing
        LUE_Marca.EditValue = Nothing

        With LUE_Tipo_de_mercadería.Properties
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_mercaderia From Directorios_y_correos Where Empresa='" + LUE_Empresa.EditValue + "' Group By Tipo_de_mercaderia")
            .ValueMember = "Tipo_de_mercaderia"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Tipo_de_mercadería_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Tipo_de_mercadería.EditValueChanged

        LUE_Sub_empresa.EditValue = Nothing
        LUE_Proveedor.EditValue = Nothing

        If LUE_Empresa.EditValue <> Nothing And LUE_Tipo_de_mercadería.EditValue = "Repuestos" And ID = 0 Then
            Dim Fecha As DateTime = Now
            Dim Literales As String = Convert.ToString(SQL.Extraer_informacion_de_columna("a.Literales", "Empresas a, Grupo_de_empresas b", "Where a.RL_GE = b.Id_grupo_empresas and a.Razon_comercial='" + LUE_Empresa.EditValue + "'"))
            Dim ID_Ingreso As Integer = SQL.Nuevo_ID_alfanumerico("Ingreso_a_bodega", (Len("TRN" + Literales + Fecha.ToString("yyMM")) + 1).ToString + ",Len(Ingreso_a_bodega)", "Costeos", "Where Empresa='" + LUE_Empresa.EditValue + "' And SubString(Ingreso_a_bodega,1," + Len("TRN" + Literales + Fecha.ToString("yyMM")).ToString + ")='TRN" + Literales + Fecha.ToString("yyMM") + "'")

            TE_Ingreso_a_bodega.EditValue = "TRN" + Literales + Fecha.ToString("yyMM") + StrDup(13 - (Len("TRN" + Literales + Fecha.ToString("yyMM")) + Len(ID_Ingreso.ToString)), "0") + ID_Ingreso.ToString
            TE_Fecha_de_ingreso_a_bodega.EditValue = Fecha
            LUE_Estado.EditValue = "En transito"
            FN.Validar_controles(GC_Datos_de_ingreso_a_bodega)
        End If

        With LUE_Sub_empresa.Properties
            .DataSource = SQL.Tabla_de_datos("Select SE,Sub_empresa From Directorios_y_correos Where Empresa='" + LUE_Empresa.EditValue + "' And Tipo_de_mercaderia='" + LUE_Tipo_de_mercadería.EditValue + "' Group By SE,Sub_empresa")
            .ValueMember = "SE"
            .DisplayMember = "Sub_empresa"
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Proveedor.Properties
            .DataSource = SQL.Tabla_de_datos("Select Empresa,Proveedor From Proveedores_cuentas_y_complementos Where Empresa='" + LUE_Empresa.EditValue + "' And Tipo_de_mercaderia='" + LUE_Tipo_de_mercadería.EditValue + "' Group By Empresa,Proveedor")
            .ValueMember = "Proveedor"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Proveedor_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Proveedor.EditValueChanged

        LUE_Marca.EditValue = Nothing

        With LUE_Marca.Properties
            .DataSource = SQL.Tabla_de_datos("Select Marca,País_de_procedencia From Proveedores_cuentas_y_complementos Where Empresa='" + LUE_Empresa.EditValue + "' And Proveedor='" + LUE_Proveedor.EditValue + "' Group By Marca,País_de_procedencia")
            .ValueMember = "País_de_procedencia"
            .DisplayMember = "Marca"
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Sub_empresa_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Sub_empresa.EditValueChanged
        If LUE_Sub_empresa.EditValue <> Nothing Then
            TE_SE.Text = LUE_Sub_empresa.EditValue
        ElseIf LUE_Sub_empresa.Text <> "" Then
            TE_SE.Text = LUE_Sub_empresa.EditValue
        Else
            TE_SE.Text = Nothing
        End If
    End Sub

    Private Sub LUE_Marca_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Marca.EditValueChanged
        If LUE_Marca.EditValue <> Nothing Then
            TE_País_de_procedencia.Text = LUE_Marca.EditValue
        ElseIf LUE_Marca.Text <> "" Then
            TE_País_de_procedencia.Text = LUE_Marca.EditValue
        Else
            TE_País_de_procedencia.Text = Nothing
        End If
    End Sub

    Private Sub LUE_Incoterm_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Incoterm.EditValueChanged
        Total_general()
    End Sub

    Private Sub Valores_poliza(sender As Object, e As EventArgs) Handles TE_Factor_de_cambio_GTQ.EditValueChanged, TE_FOB_USD.EditValueChanged, TE_Flete_USD.EditValueChanged, TE_Seguro_USD.EditValueChanged, TE_Seguro_USD.EditValueChanged, TE_Otros_USD.EditValueChanged
        TE_Total_USD.EditValue = Val(TE_FOB_USD.EditValue) + Val(TE_Flete_USD.EditValue) + Val(TE_Seguro_USD.EditValue) + Val(TE_Otros_USD.EditValue)
        TE_Total_GTQ.EditValue = Val(TE_Total_USD.EditValue) * Val(TE_Factor_de_cambio_GTQ.EditValue)
    End Sub

    Private Sub Valores_DAI_IVA(sender As Object, e As EventArgs) Handles TE_DAI.EditValueChanged, TE_IVA.EditValueChanged
        TE_DAI_IVA.EditValue = Val(TE_DAI.EditValue) + Val(TE_IVA.EditValue)
        Total_general()
    End Sub

    Private Sub CK_Rectificación_CheckedChanged(sender As Object, e As EventArgs) Handles CK_Rectificación.CheckedChanged
        If CK_Rectificación.Checked = True Then
            GC_Rectificación.Visible = True
        Else
            GC_Rectificación.Visible = False
        End If
    End Sub

    Private Sub Valores_DAI_IVA_rectificación(sender As Object, e As EventArgs) Handles TE_R_DAI.EditValueChanged, TE_R_IVA.EditValueChanged
        TE_R_DAI_IVA.EditValue = Val(TE_R_DAI.EditValue) + Val(TE_R_IVA.EditValue)
        Total_general()
    End Sub

    Private Sub LUE_Empresa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Empresa.Validating
        FN.Validar_campos(LUE_Empresa, "Debes asignar una empresa", DxErrorProvider)
    End Sub

    Private Sub LUE_Tipo_de_mercaderia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Tipo_de_mercadería.Validating
        FN.Validar_campos(LUE_Tipo_de_mercadería, "Debes asignar un tipo de mercaderia", DxErrorProvider)
    End Sub

    Private Sub LUE_Sub_empresa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Sub_empresa.Validating
        FN.Validar_campos(LUE_Sub_empresa, "Debes asignar una sub empresa", DxErrorProvider)
    End Sub

    Private Sub TE_Ingreso_a_bodega_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Ingreso_a_bodega.Validating
        FN.Validar_campos(TE_Ingreso_a_bodega, "Debes ingresar un número de ingreso a bodega", DxErrorProvider)
    End Sub

    Private Sub TE_Fecha_de_ingreso_a_bodega_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Fecha_de_ingreso_a_bodega.Validating
        FN.Validar_campos(TE_Fecha_de_ingreso_a_bodega, "Debes ingresar una fecha", DxErrorProvider)
        FN.Validar_fechas(sender, e)
    End Sub

    Private Sub Fecha_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Fecha_de_Guia_BL_Carta_de_porte.Validating, TE_Fecha_de_arribo.Validating, TE_Fecha_de_Dua_Fauca_Face.Validating
        FN.Validar_fechas(sender, e)
    End Sub

#Region "Documentos del exterior"

    Private Sub Cargar_documentos_del_exterior(Condición As String)

        GridControl_DE.DataSource = SQL_DE.Tabla_con_actualización_de_datos("Select * From Documentos_del_exterior " + Condición)
        Configurar_documentos_del_exterior()

    End Sub

    Private Sub Configurar_documentos_del_exterior()

        With GridView_DE

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Id_documento_del_exterior", "RL_id_costeo"
                        CL.Visible = False
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
                End Select

                Select Case CL.FieldName
                    Case "FOB", "Flete", "Seguro", "Otros", "Total", "Total_USD", "Total_GTQ", "Total_provisión_USD", "Total_provisión_GTQ", "Diferencial_USD", "Diferencial_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

                Select Case CL.FieldName
                    Case "Factor_de_cambio_USD", "Factor_de_cambio_GTQ", "Factor_de_provisión_USD", "Factor_de_provisión_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n6"
                End Select

                Select Case CL.FieldName
                    Case "Total", "Total_USD", "Total_GTQ", "Total_provisión_USD", "Total_provisión_GTQ"
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
                        CL.AppearanceCell.BackColor = Color.Beige
                End Select

            Next

            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()

        End With

        Columna_tipo_de_documento_DE()
        Columna_documento_DE()
        Columna_fecha_DE()
        Columna_Moneda_DE()

    End Sub

    Private Sub Columna_tipo_de_documento_DE()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_documento From Tipos_de_documento Where Tipo='Exterior'")
            .ValueMember = "Tipo_de_documento"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DE.Columns("Tipo_de_documento").ColumnEdit = Item
    End Sub

    Private Sub Columna_documento_DE()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .CharacterCasing = CharacterCasing.Upper
        End With
        GridView_DE.Columns("Documento").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha_DE()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "d"
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            .Mask.UseMaskAsDisplayFormat = True
        End With
        GridView_DE.Columns("Fecha").ColumnEdit = Item
    End Sub

    Private Sub Columna_moneda_DE()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Moneda From Tipos_de_moneda Order By Moneda")
            .ValueMember = "Moneda"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DE.Columns("Moneda").ColumnEdit = Item
    End Sub

    Private Sub GridView_DE_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView_DE.InitNewRow

        GridView_DE.SetRowCellValue(e.RowHandle, "Id_documento_del_exterior", Now.ToString("yyMMddHHmmssfff"))
        GridView_DE.SetRowCellValue(e.RowHandle, "RL_id_costeo", ID)

        If LUE_Moneda.EditValue <> Nothing Then
            GridView_DE.SetRowCellValue(e.RowHandle, "Moneda", LUE_Moneda.EditValue)
        Else
            GridView_DE.SetRowCellValue(e.RowHandle, "Moneda", LUE_Moneda_de_negociación.EditValue)
        End If

        If GridView_DE.GetRowCellValue(e.RowHandle, "Moneda").ToString = "" Or GridView_DE.GetRowCellValue(e.RowHandle, "Moneda").ToString = "USD" Then
            GridView_DE.SetRowCellValue(e.RowHandle, "Factor_de_cambio_USD", 1)
            GridView_DE.SetRowCellValue(e.RowHandle, "Factor_de_cambio_GTQ", Val(TE_Factor_de_cambio_GTQ.EditValue))
        Else
            GridView_DE.SetRowCellValue(e.RowHandle, "Factor_de_cambio_USD", Val(TE_Factor_de_cambio_USD.EditValue))
            GridView_DE.SetRowCellValue(e.RowHandle, "Factor_de_cambio_GTQ", Val(TE_Factor_de_cambio_GTQ.EditValue))
        End If

    End Sub

    Private Sub GridView_DE_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView_DE.ValidateRow
        Dim i As Integer = e.RowHandle
        If GridView_DE.GetRowCellValue(i, "Tipo_de_documento").ToString <> "" And GridView_DE.GetRowCellValue(i, "Documento").ToString <> "" And GridView_DE.GetRowCellValue(i, "Fecha").ToString <> "" And GridView_DE.GetRowCellValue(i, "Moneda").ToString <> "" And GridView_DE.GetRowCellValue(i, "Factor_de_cambio_USD").ToString <> "" And GridView_DE.GetRowCellValue(i, "Factor_de_cambio_GTQ").ToString <> "" Then
            GridView_DE.PostEditor()
            GridView_DE.UpdateCurrentRow()
            e.Valid = True
        Else
            e.ErrorText = "Todos los campos son requeridos"
            e.Valid = False
        End If
    End Sub

    Private Sub GridView_DE_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GridView_DE.BeforeLeaveRow
        Total_general()
    End Sub

    Private Sub GridView_DE_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView_DE.CellValueChanged
        Dim CL As String = e.Column.FieldName, i As Integer = e.RowHandle
        If CL = "FOB" Or CL = "Flete" Or CL = "Seguro" Or CL = "Otros" Or CL = "Moneda" Or CL = "Factor_de_cambio_USD" Or CL = "Factor_de_cambio_GTQ" Or CL = "Factor_de_provisión_USD" Or CL = "Factor_de_provisión_GTQ" Then

            GridView_DE.SetRowCellValue(i, "Total", Val(GridView_DE.GetRowCellValue(i, "FOB").ToString) + Val(GridView_DE.GetRowCellValue(i, "Flete").ToString) + Val(GridView_DE.GetRowCellValue(i, "Seguro").ToString) + Val(GridView_DE.GetRowCellValue(i, "Otros").ToString))

            If CL = "Moneda" Then
                If GridView_DE.GetRowCellValue(i, "Moneda").ToString = "USD" Then
                    GridView_DE.SetRowCellValue(i, "Factor_de_cambio_USD", 1)
                Else
                    GridView_DE.SetRowCellValue(i, "Factor_de_cambio_USD", Val(TE_Factor_de_cambio_USD.EditValue))
                    GridView_DE.SetRowCellValue(i, "Factor_de_cambio_GTQ", Val(TE_Factor_de_cambio_GTQ.EditValue))
                End If
            End If

            Select Case SQL.Extraer_informacion_de_columna("Comparativo_moneda_USD", "Tipos_de_moneda", "Where Moneda='" + GridView_DE.GetRowCellValue(i, "Moneda").ToString + "'")

                Case "Apreciada"

                    GridView_DE.SetRowCellValue(i, "Total_USD", Math.Round(Val(GridView_DE.GetRowCellValue(i, "Total").ToString) * Val(GridView_DE.GetRowCellValue(i, "Factor_de_cambio_USD").ToString), 2))
                    GridView_DE.SetRowCellValue(i, "Total_provisión_USD", Math.Round(Val(GridView_DE.GetRowCellValue(i, "Total").ToString) * Val(GridView_DE.GetRowCellValue(i, "Factor_de_provisión_USD").ToString), 2))

                Case "Depreciada"

                    If Val(GridView_DE.GetRowCellValue(i, "Factor_de_cambio_USD").ToString) <> 0 Then
                        GridView_DE.SetRowCellValue(i, "Total_USD", Math.Round(Val(GridView_DE.GetRowCellValue(i, "Total").ToString) / Val(GridView_DE.GetRowCellValue(i, "Factor_de_cambio_USD").ToString), 2))
                    Else
                        GridView_DE.SetRowCellValue(i, "Total_USD", 0)
                    End If

                    If Val(GridView_DE.GetRowCellValue(i, "Factor_de_provisión_USD").ToString) <> 0 Then
                        GridView_DE.SetRowCellValue(i, "Total_provisión_USD", Math.Round(Val(GridView_DE.GetRowCellValue(i, "Total").ToString) / Val(GridView_DE.GetRowCellValue(i, "Factor_de_provisión_USD").ToString), 2))
                    Else
                        GridView_DE.SetRowCellValue(i, "Total_provisión_USD", 0)
                    End If

            End Select

            GridView_DE.SetRowCellValue(i, "Total_GTQ", Math.Round(Val(GridView_DE.GetRowCellValue(i, "Total_USD").ToString) * Val(GridView_DE.GetRowCellValue(i, "Factor_de_cambio_GTQ").ToString), 2))
            GridView_DE.SetRowCellValue(i, "Total_provisión_GTQ", Math.Round(Val(GridView_DE.GetRowCellValue(i, "Total_provisión_USD").ToString) * Val(GridView_DE.GetRowCellValue(i, "Factor_de_provisión_GTQ").ToString), 2))

            If Val(GridView_DE.GetRowCellValue(i, "Factor_de_provisión_USD").ToString) <> 0 Then
                GridView_DE.SetRowCellValue(i, "Diferencial_USD", Val(GridView_DE.GetRowCellValue(i, "Total_USD").ToString) - Val(GridView_DE.GetRowCellValue(i, "Total_provisión_USD").ToString))
            Else
                GridView_DE.SetRowCellValue(i, "Diferencial_USD", 0)
            End If

            If Val(GridView_DE.GetRowCellValue(i, "Factor_de_provisión_GTQ").ToString) <> 0 Then
                GridView_DE.SetRowCellValue(i, "Diferencial_GTQ", Val(GridView_DE.GetRowCellValue(i, "Total_GTQ").ToString) - Val(GridView_DE.GetRowCellValue(i, "Total_provisión_GTQ").ToString))
            Else
                GridView_DE.SetRowCellValue(i, "Diferencial_GTQ", 0)
            End If
        End If

    End Sub

    Private Sub LUE_Moneda_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Moneda.EditValueChanged

        If LUE_Moneda.EditValue = "USD" Then
            TE_Factor_de_cambio_USD.Text = 1
        Else
            TE_Factor_de_cambio_USD.Text = 0
        End If

        If GridView_DE.RowCount > 0 Then
            For i As Integer = 0 To GridView_DE.DataRowCount - 1
                GridView_DE.SetRowCellValue(i, "Moneda", LUE_Moneda.EditValue)
            Next
            Total_general()
        End If

    End Sub

    Private Sub TE_Factor_de_cambio_USD_EditValueChanged(sender As Object, e As EventArgs) Handles TE_Factor_de_cambio_USD.EditValueChanged
        If GridView_DE.RowCount > 0 Then
            For i As Integer = 0 To GridView_DE.DataRowCount - 1
                GridView_DE.SetRowCellValue(i, "Factor_de_cambio_USD", TE_Factor_de_cambio_USD.EditValue)
            Next
            Total_general()
        End If
    End Sub

    Private Sub TE_Factor_de_cambio_GTQ_EditValueChanged(sender As Object, e As EventArgs) Handles TE_Factor_de_cambio_GTQ.EditValueChanged
        If GridView_DE.RowCount > 0 Then
            For i As Integer = 0 To GridView_DE.DataRowCount - 1
                GridView_DE.SetRowCellValue(i, "Factor_de_cambio_GTQ", TE_Factor_de_cambio_GTQ.EditValue)
            Next
            Total_general()
        End If
    End Sub

    Private Sub GridView_DE_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_DE.KeyDown
        If e.KeyData = Keys.Shift + Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                GridView_DE.DeleteRow(GridView_DE.FocusedRowHandle)
                Total_general()
            End If
        ElseIf e.KeyData = Keys.Delete Then
            GridView_DE.SetRowCellValue(GridView_DE.FocusedRowHandle, GridView_DE.FocusedColumn, Nothing)
        End If
    End Sub

#End Region

#Region "Recepción de documentos"

    Private Sub CK_Recibido_CheckedChanged(sender As Object, e As EventArgs) Handles CK_Recibido.CheckedChanged

        If CK_Recibido.Checked = True Then

            If LUE_Empresa.EditValue <> Nothing And LUE_Tipo_de_mercadería.EditValue = "Repuestos" Then

                Dim Fecha As DateTime = Now
                Dim Literales As String = Convert.ToString(SQL.Extraer_informacion_de_columna("a.Literales", "Empresas a, Grupo_de_empresas b", "Where a.RL_GE = b.Id_grupo_empresas and a.Razon_comercial='" + LUE_Empresa.EditValue + "'"))
                Dim ID_Compra As Integer = SQL.Nuevo_ID_alfanumerico("Compra", (Len(Literales) + 1).ToString + ",Len(Compra)", "Costeos", "Where Empresa='" + LUE_Empresa.EditValue + "' And SubString(Compra,1," + Len(Literales).ToString + ")='" + Literales + "'")
                Dim ID_Ingreso As Integer = SQL.Nuevo_ID_alfanumerico("Ingreso_a_bodega", (Len("ING" + Literales + Fecha.ToString("yyMM")) + 1).ToString + ",Len(Ingreso_a_bodega)", "Costeos", "Where Empresa='" + LUE_Empresa.EditValue + "' And SubString(Ingreso_a_bodega,1," + Len("ING" + Literales + Fecha.ToString("yyMM")).ToString + ")='ING" + Literales + Fecha.ToString("yyMM") + "'")

                TE_Compra.EditValue = Literales + StrDup(13 - (Len(Literales) + Len(ID_Compra.ToString)), "0") + ID_Compra.ToString
                TE_Ingreso_a_bodega.EditValue = "ING" + Literales + Fecha.ToString("yyMM") + StrDup(13 - (Len("ING" + Literales + Fecha.ToString("yyMM")) + Len(ID_Ingreso.ToString)), "0") + ID_Ingreso.ToString
                TE_Fecha_de_ingreso_a_bodega.EditValue = Fecha
                LUE_Estado.EditValue = "Completo"
                FN.Validar_controles(GC_Datos_de_ingreso_a_bodega)

            End If

            TE_Usuario_que_recibe.EditValue = Costos_e_Importaciones.Usuario
            TE_Fecha_de_recepción.EditValue = Now
            LUE_Costeo_asignado_a.Select()

        ElseIf CK_Recibido.Checked = False Then

            LUE_Estado.EditValue = "En transito"
            TE_Usuario_que_recibe.EditValue = Nothing
            TE_Fecha_de_recepción.EditValue = Nothing
            LUE_Costeo_asignado_a.EditValue = Nothing

        End If

        FN.Validar_controles(GC_Datos_de_ingreso_a_bodega)
        FN.Validar_controles(NP_Recolección_de_documentos)

    End Sub

#End Region

#Region "Gastos locales"

    Private Sub Cargar_documentos_locales(Condición As String)

        GridControl_DL.DataSource = SQL_DL.Tabla_con_actualización_de_datos("Select * From Documentos_locales " + Condición)
        Configurar_documentos_locales()

    End Sub

    Private Sub Configurar_documentos_locales()

        With GridView_DL

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatString = "g"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Id_documento_local", "RL_id_costeo"
                        CL.Visible = False
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
                End Select

                Select Case CL.FieldName
                    Case "Valor", "Valor_sin_IVA"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                        Select Case CL.FieldName
                            Case "Valor_sin_IVA"
                                CL.OptionsColumn.AllowEdit = False
                                CL.OptionsColumn.AllowFocus = False
                                CL.AppearanceCell.BackColor = Color.Beige
                        End Select

                End Select

            Next

            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()

        End With

        Columna_tipo_de_documento_DL()
        Columna_documento_DL()
        Columna_fecha_DL()
        Columna_de_proveedor_DL()
        Columna_tipo_de_gasto_DL()

    End Sub

    Private Sub Columna_tipo_de_documento_DL()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_documento From Tipos_de_documento Where Tipo='Local' Order By Tipo_de_documento")
            .ValueMember = "Tipo_de_documento"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DL.Columns("Tipo_de_documento").ColumnEdit = Item
    End Sub

    Private Sub Columna_documento_DL()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .CharacterCasing = CharacterCasing.Upper
        End With
        GridView_DL.Columns("Documento").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha_DL()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "d"
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            .Mask.UseMaskAsDisplayFormat = True
        End With
        GridView_DL.Columns("Fecha").ColumnEdit = Item
    End Sub

    Private Sub Columna_de_proveedor_DL()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Razon_comercial From Proveedores_locales Order By Razon_comercial")
            .Name = "Proveedor"
            .ValueMember = "Razon_comercial"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DL.Columns("Proveedor").ColumnEdit = Item
    End Sub

    Private Sub Columna_tipo_de_gasto_DL()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_gasto From Tipos_de_gasto Order By Tipo_de_gasto")
            .Name = "Tipo_de_gasto"
            .ValueMember = "Tipo_de_gasto"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_DL.Columns("Tipo_de_gasto").ColumnEdit = Item
    End Sub

    Private Sub GridView_DL_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView_DL.InitNewRow
        GridView_DL.SetRowCellValue(e.RowHandle, "Id_documento_local", Format(Now, "yyMMddHHmmssfff"))
        GridView_DL.SetRowCellValue(e.RowHandle, "RL_id_costeo", ID)
    End Sub

    Private Sub GridView_DL_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView_DL.ValidateRow
        Dim i As Integer = e.RowHandle
        If GridView_DL.GetRowCellValue(i, "Tipo_de_documento").ToString <> "" And GridView_DL.GetRowCellValue(i, "Documento").ToString <> "" And GridView_DL.GetRowCellValue(i, "Fecha").ToString <> "" And GridView_DL.GetRowCellValue(i, "Valor").ToString <> "" Then
            e.Valid = True
        Else
            e.ErrorText = "Todos los campos son requeridos"
            e.Valid = False
        End If
    End Sub

    Private Sub GridView_DL_CustomRowCellEditForEditing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView_DL.CustomRowCellEditForEditing
        If e.RepositoryItem.Name = "Proveedor" Then
            Columna_de_proveedor_DL()
        End If
        If e.RepositoryItem.Name = "Tipo_de_gasto" Then
            Columna_tipo_de_gasto_DL()
        End If
    End Sub

    Private Sub GridView_DL_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GridView_DL.BeforeLeaveRow
        Total_general()
    End Sub

    Private Sub GridView_DL_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView_DL.CellValueChanged
        Dim CL As String = e.Column.FieldName, i As Integer = e.RowHandle
        If CL = "Tipo_de_documento" Or CL = "Valor" Then
            Select Case SQL.Extraer_informacion_de_columna("Afecta_IVA", "Tipos_de_documento", "Where Tipo_de_documento='" + GridView_DL.GetRowCellValue(i, "Tipo_de_documento").ToString + "'")
                Case "True"
                    Dim Factor_de_IVA As Double = Val(SQL.Extraer_informacion_de_columna("Factor_de_IVA", "Tipos_de_documento", "Where Tipo_de_documento='" + GridView_DL.GetRowCellValue(i, "Tipo_de_documento").ToString + "'")) + 1
                    GridView_DL.SetRowCellValue(i, "Valor_sin_IVA", Math.Round(Val(GridView_DL.GetRowCellValue(i, "Valor").ToString) / Factor_de_IVA, 2))
                Case "False"
                    GridView_DL.SetRowCellValue(i, "Valor_sin_IVA", Val(GridView_DL.GetRowCellValue(i, "Valor").ToString))
            End Select
        End If
    End Sub

    Private Sub GridView_DL_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_DL.KeyDown
        If e.KeyData = Keys.Shift + Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                GridView_DL.DeleteRow(GridView_DL.FocusedRowHandle)
                Total_general()
            End If
        ElseIf e.KeyData = Keys.Delete Then
            GridView_DL.SetRowCellValue(GridView_DL.FocusedRowHandle, GridView_DL.FocusedColumn, Nothing)
        End If
    End Sub

#End Region

#Region "Seguro"

    Private Sub Cargar_Seguro(Condición As String)

        GridControl_SG.DataSource = SQL_SG.Tabla_con_actualización_de_datos("Select * From Seguro " + Condición)
        Configurar_Seguro()

    End Sub

    Private Sub Configurar_Seguro()

        With GridView_SG
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
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
                End Select

                Select Case CL.FieldName
                    Case "Valor_costo", "Gastos_comprobables", "Total_costos_y_gastos", "Prima", "Gastos_de_emisión", "Total_seguro_USD", "Total_seguro_GTQ"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

                Select Case CL.FieldName
                    Case "Factor_de_cambio_GTQ", "Factor_prima", "Factor_gastos_de_emisión"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n6"
                End Select

            Next

            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()

        End With

    End Sub

    Private Function Provisiona_seguro() As Boolean
        Dim Seguro As Boolean = False
        For i As Integer = 0 To GridView_DE.DataRowCount - 1
            If GridView_DE.GetRowCellValue(i, "Tipo_de_documento").ToString.Contains("Seguro") Or GridView_DE.GetRowCellValue(i, "Tipo_de_documento").ToString.Contains("seguro") Or GridView_DE.GetRowCellValue(i, "Tipo_de_documento").ToString.Contains("SEGURO") Then
                Seguro = True
            End If
        Next
        Return Seguro
    End Function


    Private Sub Seguro()
        If Provisiona_seguro() = False Then
            If CK_Recibido.EditValue = True And LUE_Incoterm.EditValue <> Nothing And TE_Factor_de_cambio_GTQ.EditValue <> Nothing Then
                Dim Documentos_USD As Double = GridView_DE.Columns("Total_USD").SummaryItem.SummaryValue
                Dim Gastos_USD As Double = Val(TE_DAI.EditValue + TE_R_DAI.EditValue + GridView_DL.Columns("Valor_sin_IVA").SummaryItem.SummaryValue) / Val(TE_Factor_de_cambio_GTQ.EditValue)

                If GridView_SG.RowCount = 0 Then
                    GridView_SG.AddNewRow()
                    Dim i As Integer = GridView_SG.GetRowHandle(GridView_SG.DataRowCount)
                    If GridView_SG.IsNewItemRow(i) Then
                        GridView_SG.SetRowCellValue(i, "Id_seguro", Format(Now, "yyMMddHHmmssfff"))
                        GridView_SG.SetRowCellValue(i, "RL_id_costeo", ID)
                        If TE_Fecha_de_recepción.EditValue <> Nothing Then GridView_SG.SetRowCellValue(i, "Fecha_de_provisión", Convert.ToDateTime(TE_Fecha_de_recepción.EditValue).ToShortDateString)
                        GridView_SG.SetRowCellValue(i, "Empresa", LUE_Empresa.EditValue)
                        GridView_SG.SetRowCellValue(i, "Póliza_de_seguro", SQL.Extraer_informacion_de_columna("Poliza_de_seguro", "Incoterms", "Where Incoterm='" + LUE_Incoterm.EditValue + "'"))
                        GridView_SG.SetRowCellValue(i, "Guia|BL|Carta_de_porte", TE_Guia_BL_Carta_de_porte.EditValue)
                        If TE_Fecha_de_Guia_BL_Carta_de_porte.EditValue <> Nothing Then GridView_SG.SetRowCellValue(i, "Fecha_de_Guia|BL|Carta_de_porte", Convert.ToDateTime(TE_Fecha_de_Guia_BL_Carta_de_porte.EditValue).ToShortDateString)
                        GridView_SG.SetRowCellValue(i, "Shipper|Carrier", LUE_Shipper_Carrier.EditValue)

                        Dim SB As New StringBuilder()
                        Dim Separador As String = Nothing
                        For F As Integer = 0 To GridView_DE.RowCount - 2
                            If Not GridView_DE.IsNewItemRow(F) Then
                                SB.Append(Separador).Append(GridView_DE.GetRowCellValue(F, "Documento"))
                                Separador = "\"
                            End If
                        Next

                        GridView_SG.SetRowCellValue(i, "Documentos", SB.ToString)
                        GridView_SG.SetRowCellValue(i, "Contenedores_o_bultos", TE_Contenedores_o_bultos.EditValue)
                        GridView_SG.SetRowCellValue(i, "Tipo_de_mercaderia", LUE_Tipo_de_mercadería.EditValue + " marca " + LUE_Marca.Text)
                        GridView_SG.SetRowCellValue(i, "País_de_procedencia", TE_País_de_procedencia.EditValue)
                        GridView_SG.SetRowCellValue(i, "Tipo_de_importacion", LUE_Tipo_de_importación.EditValue)
                        GridView_SG.SetRowCellValue(i, "Factor_de_cambio_GTQ", TE_Factor_de_cambio_GTQ.EditValue)
                        GridView_SG.SetRowCellValue(i, "Valor_costo", Documentos_USD)
                        GridView_SG.SetRowCellValue(i, "Gastos_comprobables", Gastos_USD)
                        GridView_SG.SetRowCellValue(i, "Total_costos_y_gastos", Documentos_USD + Gastos_USD)

                        GridView_SG.SetRowCellValue(i, "Factor_prima", Val(SQL.Extraer_informacion_de_columna("Prima_de_seguro", "Incoterms", "Where Incoterm='" + LUE_Incoterm.EditValue + "'")))
                        GridView_SG.SetRowCellValue(i, "Prima", Val(GridView_SG.GetRowCellValue(i, "Total_costos_y_gastos").ToString) * Val(GridView_SG.GetRowCellValue(i, "Factor_prima").ToString))

                        GridView_SG.SetRowCellValue(i, "Factor_gastos_de_emisión", Val(SQL.Extraer_informacion_de_columna("[%_gastos_de_emisión]", "Incoterms", "Where Incoterm='" + LUE_Incoterm.EditValue + "'")))
                        GridView_SG.SetRowCellValue(i, "Gastos_de_emisión", Val(GridView_SG.GetRowCellValue(i, "Prima").ToString) * Val(GridView_SG.GetRowCellValue(i, "Factor_gastos_de_emisión").ToString))

                        GridView_SG.SetRowCellValue(i, "Total_seguro_USD", Val(GridView_SG.GetRowCellValue(i, "Prima").ToString) + Val(GridView_SG.GetRowCellValue(i, "Gastos_de_emisión").ToString))

                        GridView_SG.SetRowCellValue(i, "Total_seguro_GTQ", Val(GridView_SG.GetRowCellValue(i, "Total_seguro_USD").ToString) * Val(GridView_SG.GetRowCellValue(i, "Factor_de_cambio_GTQ").ToString))

                    End If

                Else

                    If TE_Fecha_de_recepción.EditValue <> Nothing Then GridView_SG.SetRowCellValue(0, "Fecha_de_provisión", Convert.ToDateTime(TE_Fecha_de_recepción.EditValue).ToShortDateString)
                    GridView_SG.SetRowCellValue(0, "Empresa", LUE_Empresa.EditValue)
                    GridView_SG.SetRowCellValue(0, "Póliza_de_seguro", SQL.Extraer_informacion_de_columna("Poliza_de_seguro", "Incoterms", "Where Incoterm='" + LUE_Incoterm.EditValue + "'"))
                    GridView_SG.SetRowCellValue(0, "Guia|BL|Carta_de_porte", TE_Guia_BL_Carta_de_porte.EditValue)
                    If TE_Fecha_de_Guia_BL_Carta_de_porte.EditValue <> Nothing Then GridView_SG.SetRowCellValue(0, "Fecha_de_Guia|BL|Carta_de_porte", Convert.ToDateTime(TE_Fecha_de_Guia_BL_Carta_de_porte.EditValue).ToShortDateString)
                    GridView_SG.SetRowCellValue(0, "Shipper|Carrier", LUE_Shipper_Carrier.EditValue)

                    Dim SB As New StringBuilder()
                    Dim Separador As String = Nothing
                    For F As Integer = 0 To GridView_DE.RowCount - 2
                        If Not GridView_DE.IsNewItemRow(F) Then
                            SB.Append(Separador).Append(GridView_DE.GetRowCellValue(F, "Documento"))
                            Separador = "\"
                        End If
                    Next

                    GridView_SG.SetRowCellValue(0, "Documentos", SB.ToString)
                    GridView_SG.SetRowCellValue(0, "Contenedores_o_bultos", TE_Contenedores_o_bultos.EditValue)
                    GridView_SG.SetRowCellValue(0, "Tipo_de_mercaderia", LUE_Tipo_de_mercadería.EditValue + " marca " + LUE_Marca.Text)
                    GridView_SG.SetRowCellValue(0, "País_de_procedencia", TE_País_de_procedencia.EditValue)
                    GridView_SG.SetRowCellValue(0, "Tipo_de_importacion", LUE_Tipo_de_importación.EditValue)
                    GridView_SG.SetRowCellValue(0, "Factor_de_cambio_GTQ", TE_Factor_de_cambio_GTQ.EditValue)
                    GridView_SG.SetRowCellValue(0, "Valor_costo", Documentos_USD)
                    GridView_SG.SetRowCellValue(0, "Gastos_comprobables", Gastos_USD)
                    GridView_SG.SetRowCellValue(0, "Total_costos_y_gastos", Documentos_USD + Gastos_USD)

                    GridView_SG.SetRowCellValue(0, "Factor_prima", Val(SQL.Extraer_informacion_de_columna("Prima_de_seguro", "Incoterms", "Where Incoterm='" + LUE_Incoterm.EditValue + "'")))
                    GridView_SG.SetRowCellValue(0, "Prima", Val(GridView_SG.GetRowCellValue(0, "Total_costos_y_gastos").ToString) * Val(GridView_SG.GetRowCellValue(0, "Factor_prima").ToString))

                    GridView_SG.SetRowCellValue(0, "Factor_gastos_de_emisión", Val(SQL.Extraer_informacion_de_columna("[%_gastos_de_emisión]", "Incoterms", "Where Incoterm='" + LUE_Incoterm.EditValue + "'")))
                    GridView_SG.SetRowCellValue(0, "Gastos_de_emisión", Val(GridView_SG.GetRowCellValue(0, "Prima").ToString) * Val(GridView_SG.GetRowCellValue(0, "Factor_gastos_de_emisión").ToString))

                    GridView_SG.SetRowCellValue(0, "Total_seguro_USD", Val(GridView_SG.GetRowCellValue(0, "Prima").ToString) + Val(GridView_SG.GetRowCellValue(0, "Gastos_de_emisión").ToString))

                    GridView_SG.SetRowCellValue(0, "Total_seguro_GTQ", Val(GridView_SG.GetRowCellValue(0, "Total_seguro_USD").ToString) * Val(GridView_SG.GetRowCellValue(0, "Factor_de_cambio_GTQ").ToString))

                End If

                GridView_SG.PostEditor()
                GridView_SG.UpdateCurrentRow()
            End If
            GridView_SG.UpdateSummary()
        Else

            For i As Integer = 0 To GridView_SG.DataRowCount - 1
                GridView_SG.DeleteRow(i)
            Next

        End If
    End Sub

#End Region

#Region "Comentarios"

    Private Sub GC_Comentarios_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Comentarios.CustomButtonClick
        If ID <> 0 Then

            Select Case e.Button.Properties.Caption

                Case "Nuevo comentario"

                    Dim MyString As New Text.StringBuilder()
                    Dim MSG As New BackOffice_servicios.Comentario
                    MSG.ShowDialog()
                    If MSG.Guardar = True Then
                        If RTBX_Comentarios.TextLength > 0 Then
                            MyString.AppendLine(RTBX_Comentarios.Text)
                            MyString.AppendLine(StrDup(165, "-"))
                        End If
                        MyString.AppendLine("[ " & UCase(Costos_e_Importaciones.Usuario) & " - " & Now & " - " & MSG.Tipo_de_comentario & " ]")
                        MyString.AppendLine(MSG.Comentario)
                        RTBX_Comentarios.Text = Regex.Replace(MyString.ToString, "^\r|\n\r|\n$", "")

                        If ID <> 0 Then
                            SQL.Actualizar("Costeos", "Comentarios='" + RTBX_Comentarios.Text + "'", "Id_costeo=" + ID.ToString)
                        End If
                    End If
                    MSG.Dispose()

                Case "Envió de comentarios"

                    Dim MyString As New Text.StringBuilder()
                    MyString.AppendLine("<html><body><tt><font face='calibri,arial narrow'>")
                    MyString.AppendLine("<p>Buen día <br/><br/>Envió comentarios según ingreso a bodega " & TE_Ingreso_a_bodega.Text & "<br/></p>")

                    For i As Integer = 0 To RTBX_Comentarios.Lines.Length - 1
                        MyString.AppendLine("<tt><font face='calibri,arial narrow'>" + RTBX_Comentarios.Lines(i) + "</font></tt><br/>")
                    Next

                    MyString.AppendLine("</font></tt></body></html>")
                    FN.Enviar_correo(Asunto:="Envió de comentarios según ingreso a bodega " & TE_Ingreso_a_bodega.Text, Cuerpo_del_correo:=MyString.ToString)

            End Select

        End If

    End Sub

#End Region

#Region "Certificaciones"

    Private Sub Cargar_certificaciones(Condición As String)

        GridControl_CF.DataSource = SQL_CF.Tabla_con_actualización_de_datos("Select * From Certificaciones " + Condición)
        Configurar_certificaciones()

    End Sub

    Private Sub Configurar_certificaciones()

        With GridView_CF

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")

                Select Case CL.FieldName
                    Case "Id_certificación", "RL_id_costeo"
                        CL.Visible = False
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
                End Select

                Select Case CL.FieldName
                    Case "Tipo_de_certificación"
                        CL.Width = 300
                    Case "Imágen"
                        CL.Width = 150
                End Select

            Next
            .RowHeight = 100
            .OptionsView.ColumnAutoWidth = False
            '.BestFitColumns()

        End With

        Columna_tipo_de_certificacion_CF()
        Columna_imágen_CF()

    End Sub

    Private Sub Columna_tipo_de_certificacion_CF()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

        Dim DT As New DataTable
        DT.Columns.Add("Tipo_de_certificación")
        DT.Rows.Add("Fecha de ingreso a bodega")
        DT.Rows.Add("Fecha de AWB - BL - Carta de porte")
        DT.Rows.Add("Fecha de arribo")
        DT.Rows.Add("Fecha de DUA - FAUCA - FACE")
        DT.Rows.Add("Fecha de recepción documentos locales")

        Dim DV As DataView = New DataView(DT)

        With Item
            .DataSource = DV
            .ValueMember = "Tipo_de_certificación"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView_CF.Columns("Tipo_de_certificación").ColumnEdit = Item
    End Sub

    Private Sub Columna_imágen_CF()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
        With Item
            .Name = "Imágen"
            .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
            Dim Expandir As New DevExpress.Utils.ContextButton With {.Caption = "Expandir", .Name = "Expandir"}
            Expandir.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/zoom/zoom2_16x16.png")
            .ContextButtons.Add(Expandir)
        End With

        AddHandler Item.ContextButtonClick, Sub(s, e)
                                                Dim VI As New BackOffice_servicios.Visor_de_imágenes
                                                If e.Item.Name = "Expandir" Then
                                                    GridView_CF.PostEditor()
                                                    GridView_CF.UpdateCurrentRow()
                                                    VI.Text = VI.Text + " - " + GridView_CF.GetRowCellValue(GridView_CF.FocusedRowHandle, "Tipo_de_certificación")
                                                    VI.PictureEdit.EditValue = GridView_CF.GetRowCellValue(GridView_CF.FocusedRowHandle, GridView_CF.FocusedColumn)
                                                    VI.StartPosition = FormStartPosition.CenterScreen
                                                    VI.Show()
                                                End If
                                            End Sub

        GridView_CF.Columns("Imágen").ColumnEdit = Item
    End Sub

    Private Sub GridView_CF_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView_CF.InitNewRow
        GridView_CF.SetRowCellValue(e.RowHandle, "Id_certificación", Format(Now, "yyMMddHHmmssfff"))
        GridView_CF.SetRowCellValue(e.RowHandle, "RL_id_costeo", ID)
    End Sub

    Private Sub GridView_CF_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView_CF.KeyDown
        If e.KeyData = Keys.Shift + Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                GridView_CF.DeleteRow(GridView_CF.FocusedRowHandle)
            End If
        ElseIf e.KeyData = Keys.Delete Then
            GridView_CF.SetRowCellValue(GridView_CF.FocusedRowHandle, GridView_CF.FocusedColumn, Nothing)
        End If
    End Sub



#End Region

#Region "Costeo"

    Private Sub GC_Costeo_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Costeo.CustomButtonClick
        If ID <> 0 Then

            Select Case e.Button.Properties.Caption

                Case "Generar PDF"

                    If DocumentViewer.Status <> "El documento no contiene ninguna página." Then
                        CT.ExportToPdf(SQL.Extraer_informacion_de_columna("Directorio", "Directorios_y_correos", "Where Empresa+'-'+Tipo_de_mercaderia+'-'+Convert(nvarchar,SE)='" + SQL.Extraer_informacion_de_columna("Empresa+'-'+Tipo_de_mercaderia+'-'+Convert(nvarchar,SE)", "Costeos", "Where Id_costeo=" + ID.ToString) + "'") + "\" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue + ".pdf")
                        MsgBox("Generación exitosa", MsgBoxStyle.Information, "Generar PDF")
                    End If

                Case "Imprimir"

                    If DocumentViewer.Status <> "El documento no contiene ninguna página." Then
                        Dim printTool As New DevExpress.XtraReports.UI.ReportPrintTool(CT)
                        printTool.PrintDialog()
                    End If

            End Select

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

    Private Sub GC_Contabilidad_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Contabilidad.CustomButtonClick
        Dim Dt As DataTable = SQL.Tabla_de_datos("Select * From Proveedores_cuentas_y_complementos Where Empresa+'-'+Tipo_de_mercaderia+'-'+Proveedor+'-'+Marca='" + LUE_Empresa.EditValue + "-" + LUE_Tipo_de_mercadería.EditValue + "-" + LUE_Proveedor.EditValue + "-" + LUE_Marca.Text + "'")
        Dim Ref_moneda As String = Nothing

        If LUE_Moneda.EditValue <> Nothing Then
            If LUE_Moneda.EditValue = "USD" Then
                Ref_moneda = LUE_Moneda.EditValue + " " + TE_Factor_de_cambio_GTQ.EditValue.ToString
            Else
                Ref_moneda = LUE_Moneda.EditValue + " " + TE_Factor_de_cambio_USD.EditValue.ToString + " USD " + TE_Factor_de_cambio_GTQ.EditValue.ToString
            End If
        End If

        Select Case e.Button.Properties.Caption

            Case "Partida MT"

                Cargar_contabilidad()
                Descripción_contable = "Registro de mercadería en transito tipo " + LUE_Tipo_de_importación.EditValue + " de " + LUE_Proveedor.EditValue + " " + LUE_Tipo_de_mercadería.EditValue + " marca " + LUE_Marca.Text + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda

                If GridView_DE.RowCount > 0 Then
                    For i As Integer = 0 To GridView_DE.DataRowCount - 1

                        If GridView_DE.GetRowCellValue(i, "Total_GTQ") <> 0 Then

                            If GridView_DE.GetRowCellValue(i, "Tipo_de_documento").ToString.Contains("Provisión") Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                End If

                                            Case 2

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvNeg"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvNeg"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvNeg"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvNeg"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvNeg"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next

                            Else

                                For X As Integer = 1 To 3

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                End If

                                            Case 2

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvExt"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvExt"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvExt"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvExt"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvExt"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_USD") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_USD"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_USD"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                            Case 3

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_DifCamb"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_DifCamb"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_DifCamb"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_DifCamb"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_DifCamb"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_USD") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ") - GridView_DE.GetRowCellValue(i, "Total_USD"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ") - GridView_DE.GetRowCellValue(i, "Total_USD"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        End If
                    Next
                End If

            Case "Partida INV"

                Cargar_contabilidad()
                Descripción_contable = "Registro de mercadería en transito al inventario tipo " + LUE_Tipo_de_importación.EditValue + " de " + LUE_Proveedor.EditValue + " " + LUE_Tipo_de_mercadería.EditValue + " marca " + LUE_Marca.Text + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda

                If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" Then

                    'Documentos del exterior
                    If GridView_DE.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DE.DataRowCount - 1

                            If GridView_DE.GetRowCellValue(i, "Total_GTQ") <> 0 Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                End If

                                            Case 2

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        Next
                    End If

                    'DAI
                    If TE_DAI.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " DAI " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_DAI.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                        End If

                    End If

                    'IVA
                    If TE_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " IVA " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_IVA.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                            GridView_CT.SetRowCellValue(Dr, "TRN_IVA", Dt.Rows(0)("TRN_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Proveedor_IVA", Dt.Rows(0)("Prov_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Fecha_IVA", CDate(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString)
                        End If

                    End If

                    'DAI e IVA
                    If TE_DAI_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Liquidación DUA " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                            GridView_CT.SetRowCellValue(Dr, "Haber", TE_DAI_IVA.EditValue)

                        End If

                    End If

                    'DAI rectificación
                    If TE_R_DAI.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_R_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " DAI " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_R_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_R_DAI.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                        End If

                    End If

                    'IVA rectificación
                    If TE_R_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_R_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " IVA " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_R_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_R_IVA.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                            GridView_CT.SetRowCellValue(Dr, "TRN_IVA", Dt.Rows(0)("TRN_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Proveedor_IVA", Dt.Rows(0)("Prov_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Fecha_IVA", CDate(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString)

                        End If

                    End If

                    'DAI e IVA rectificación
                    If TE_R_DAI_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_R_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Liquidación DUA " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_R_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                            GridView_CT.SetRowCellValue(Dr, "Haber", TE_R_DAI_IVA.EditValue)

                        End If

                    End If

                    'Perdida o ganancia cambiaria
                    If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" And GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue <> 0 Then
                        For X As Integer = 1 To 2
                            GridView_CT.AddNewRow()
                            Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                            If GridView_CT.IsNewItemRow(Dr) Then
                                Select Case X
                                    Case 1

                                        If GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue < 0 Then
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Perdida cambiaria " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                        Else
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Ganancia cambiaria " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                        End If

                                    Case 2

                                        If GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue < 0 Then
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Perdida cambiaria " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                        Else
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Ganancia cambiaria " + " VH-" + TE_Contenedores_o_bultos.EditValue.ToString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                        End If

                                End Select


                            End If
                        Next
                    End If

                    'Documentos locales
                    If GridView_DL.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DL.DataRowCount - 1

                            If GridView_DL.GetRowCellValue(i, "Valor_sin_IVA") <> 0 Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DL.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DL.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DL.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + GridView_DL.GetRowCellValue(i, "Proveedor") + " " + GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                                If GridView_DL.GetRowCellValue(i, "Valor_sin_IVA") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                End If

                                            Case 2

                                                If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" And GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") = "Iprima" Then
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvNeg"))
                                                ElseIf LUE_Tipo_de_mercadería.EditValue = "Vehiculos" And GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") = "Gastos bancarios" Then
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvPos"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvPos"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvPos"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvPos"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvPos"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_GtsLoc"))
                                                End If

                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DL.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DL.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DL.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + GridView_DL.GetRowCellValue(i, "Proveedor") + " " + GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                                If GridView_DL.GetRowCellValue(i, "Valor_sin_IVA") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        Next
                    End If

                    'Seguro
                    If GridView_SG.RowCount > 0 Then
                        For i As Integer = 0 To GridView_SG.DataRowCount - 1

                            If GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ") <> 0 Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", "Póliza de seguro " + GridView_SG.GetRowCellValue(i, "Póliza_de_seguro") + " " + Convert.ToDateTime(GridView_SG.GetRowCellValue(i, "Fecha_de_provisión")).ToShortDateString + " " + GridView_SG.GetRowCellValue(i, "Tipo_de_mercaderia") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                                If GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                End If

                                            Case 2

                                                If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" Then
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvNeg"))
                                                End If
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", "Póliza de seguro " + GridView_SG.GetRowCellValue(i, "Póliza_de_seguro") + " " + Convert.ToDateTime(GridView_SG.GetRowCellValue(i, "Fecha_de_provisión")).ToShortDateString + " " + GridView_SG.GetRowCellValue(i, "Tipo_de_mercaderia") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                                                If GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        Next
                    End If

                Else

                    'Documentos del exterior
                    If GridView_DE.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DE.DataRowCount - 1

                            If GridView_DE.GetRowCellValue(i, "Total_GTQ") <> 0 Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                End If

                                            Case 2

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DE.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DE.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DE.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DE.GetRowCellValue(i, "Total_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DE.GetRowCellValue(i, "Total_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        Next
                    End If

                    'DAI
                    If TE_DAI.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " DAI " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_DAI.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                        End If

                    End If

                    'IVA
                    If TE_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " IVA " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_IVA.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                            GridView_CT.SetRowCellValue(Dr, "TRN_IVA", Dt.Rows(0)("TRN_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Proveedor_IVA", Dt.Rows(0)("Prov_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Fecha_IVA", CDate(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString)

                        End If

                    End If

                    'DAI e IVA
                    If TE_DAI_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Liquidación DUA " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                            GridView_CT.SetRowCellValue(Dr, "Haber", TE_DAI_IVA.EditValue)

                        End If

                    End If

                    'DAI rectificación
                    If TE_R_DAI.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_R_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " DAI " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_R_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_R_DAI.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                        End If

                    End If

                    'IVA rectificación
                    If TE_R_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_R_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " IVA " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_R_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", TE_R_IVA.EditValue)
                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)

                            GridView_CT.SetRowCellValue(Dr, "TRN_IVA", Dt.Rows(0)("TRN_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Proveedor_IVA", Dt.Rows(0)("Prov_IVA"))
                            GridView_CT.SetRowCellValue(Dr, "Fecha_IVA", CDate(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString)

                        End If

                    End If

                    'DAI e IVA rectificación
                    If TE_R_DAI_IVA.EditValue <> Nothing Then

                        GridView_CT.AddNewRow()
                        Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                        If GridView_CT.IsNewItemRow(Dr) Then

                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Antpos"))
                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_R_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_R_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Liquidación DUA " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_R_Dua_Fauca_Face.EditValue, 13))

                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                            GridView_CT.SetRowCellValue(Dr, "Haber", TE_R_DAI_IVA.EditValue)

                        End If

                    End If

                    'Perdida o ganancia cambiaria
                    If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" And GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue <> 0 Then
                        For X As Integer = 1 To 2
                            GridView_CT.AddNewRow()
                            Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                            If GridView_CT.IsNewItemRow(Dr) Then
                                Select Case X
                                    Case 1

                                        If GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue < 0 Then
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_PerCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Perdida cambiaria " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                        Else
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Ganancia cambiaria " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                            GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                        End If

                                    Case 2

                                        If GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue < 0 Then
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Perdida cambiaria " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                        Else
                                            GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_GanCamb"))
                                            GridView_CT.SetRowCellValue(Dr, "Descripción", LUE_Régimen.EditValue + " " + TE_Dua_Fauca_Face.EditValue + " " + Convert.ToDateTime(TE_Fecha_de_Dua_Fauca_Face.EditValue).ToShortDateString + " Ganancia cambiaria " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                            GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                            GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                            GridView_CT.SetRowCellValue(Dr, "Haber", Math.Abs(GridView_DE.Columns("Diferencial_GTQ").SummaryItem.SummaryValue))
                                        End If

                                End Select


                            End If
                        Next
                    End If

                    'Documentos locales
                    If GridView_DL.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DL.DataRowCount - 1

                            If GridView_DL.GetRowCellValue(i, "Valor_sin_IVA") <> 0 Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DL.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DL.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DL.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + GridView_DL.GetRowCellValue(i, "Proveedor") + " " + GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_DL.GetRowCellValue(i, "Valor_sin_IVA") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                End If

                                            Case 2

                                                If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" And GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") = "Iprima" Then
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvNeg"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_GtsLoc"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_GtsLoc"))
                                                End If

                                                GridView_CT.SetRowCellValue(Dr, "Descripción", GridView_DL.GetRowCellValue(i, "Tipo_de_documento") + " " + GridView_DL.GetRowCellValue(i, "Documento") + " " + Convert.ToDateTime(GridView_DL.GetRowCellValue(i, "Fecha")).ToShortDateString + " " + GridView_DL.GetRowCellValue(i, "Proveedor") + " " + GridView_DL.GetRowCellValue(i, "Tipo_de_gasto") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(GridView_DL.GetRowCellValue(i, "Documento"), 13))

                                                If GridView_DL.GetRowCellValue(i, "Valor_sin_IVA") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_DL.GetRowCellValue(i, "Valor_sin_IVA"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        Next
                    End If

                    'Seguro
                    If GridView_SG.RowCount > 0 Then
                        For i As Integer = 0 To GridView_SG.DataRowCount - 1

                            If GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ") <> 0 Then

                                For X As Integer = 1 To 2

                                    GridView_CT.AddNewRow()
                                    Dim Dr As Integer = GridView_CT.GetRowHandle(GridView_CT.DataRowCount)
                                    If GridView_CT.IsNewItemRow(Dr) Then

                                        Select Case X
                                            Case 1

                                                GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_Inv"))
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", "Póliza de seguro " + GridView_SG.GetRowCellValue(i, "Póliza_de_seguro") + " " + Convert.ToDateTime(GridView_SG.GetRowCellValue(i, "Fecha_de_provisión")).ToShortDateString + " " + GridView_SG.GetRowCellValue(i, "Tipo_de_mercaderia") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                End If

                                            Case 2

                                                If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" Then
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_MercTran"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_MercTran"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Alterno", Dt.Rows(0)("CT_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SE", Dt.Rows(0)("SE_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "DP", Dt.Rows(0)("DP_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "SC", Dt.Rows(0)("SC_ProvNeg"))
                                                    GridView_CT.SetRowCellValue(Dr, "CC", Dt.Rows(0)("CC_ProvNeg"))
                                                End If
                                                GridView_CT.SetRowCellValue(Dr, "Descripción", "Póliza de seguro " + GridView_SG.GetRowCellValue(i, "Póliza_de_seguro") + " " + Convert.ToDateTime(GridView_SG.GetRowCellValue(i, "Fecha_de_provisión")).ToShortDateString + " " + GridView_SG.GetRowCellValue(i, "Tipo_de_mercaderia") + " " + LUE_Shipper_Carrier.EditValue + " " + TE_Guia_BL_Carta_de_porte.EditValue + " " + Ref_moneda)
                                                GridView_CT.SetRowCellValue(Dr, "Documento", Strings.Right(TE_Guia_BL_Carta_de_porte.EditValue, 13))

                                                If GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ") > 0 Then
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", 0)
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                Else
                                                    GridView_CT.SetRowCellValue(Dr, "Debe", GridView_SG.GetRowCellValue(i, "Total_seguro_GTQ"))
                                                    GridView_CT.SetRowCellValue(Dr, "Haber", 0)
                                                End If

                                        End Select

                                    End If

                                    GridView_CT.PostEditor()
                                    GridView_CT.UpdateCurrentRow()

                                Next
                            End If
                        Next
                    End If


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
                        SendKeys.Send("{TAB 3}")

                        If GridView_CT.GetRowCellValue(i, "Alterno") = 10081 Then
                            SendKeys.Send(GridView_CT.GetRowCellValue(i, "TRN_IVA"))
                            SendKeys.Send("{TAB}")
                            SendKeys.Send(GridView_CT.GetRowCellValue(i, "Proveedor_IVA"))
                            SendKeys.Send("{TAB 2}")
                            SendKeys.Send("N")
                            SendKeys.Send("Normal")
                            SendKeys.Send("{TAB}")
                            SendKeys.Send(Replace(TE_Dua_Fauca_Face.EditValue, "-", ""))
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
                        End If

                    Next

                End If

        End Select

    End Sub

#End Region

    Private Sub BBI_Nuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Nuevo.ItemClick
        FN.Limpiar_controles(GC_Datos_de_ingreso_a_bodega) : FN.Habilitar_controles(GC_Datos_de_ingreso_a_bodega)
        FN.Limpiar_controles(NP_Datos_de_importación) : FN.Habilitar_controles(NP_Datos_de_importación)
        Cargar_documentos_del_exterior("Where RL_id_costeo = 0") : GridView_DE.OptionsBehavior.Editable = True
        FN.Limpiar_controles(NP_Declaración_aduanal) : FN.Habilitar_controles(NP_Declaración_aduanal)
        FN.Limpiar_controles(NP_Recolección_de_documentos) : FN.Habilitar_controles(NP_Recolección_de_documentos)
        Cargar_documentos_locales("Where RL_id_costeo = 0") : GridView_DL.OptionsBehavior.Editable = True
        Cargar_certificaciones("Where RL_id_costeo = 0") : GridView_CF.OptionsBehavior.ReadOnly = False
        Cargar_Seguro("Where RL_id_costeo = 0") : GridView_SG.OptionsBehavior.Editable = False
        FN.Limpiar_controles(GC_Comentarios)
        DocumentViewer.DocumentSource = "(none)" : DocumentViewer.Status = "El documento no contiene ninguna página."
        Cargar_contabilidad() : GridView_CT.OptionsBehavior.Editable = False
        ID = Nothing : Edicion = False
        ValidateChildren()
        FN.Validar_controles(NP_Datos_de_importación)
        FN.Validar_controles(NP_Declaración_aduanal)
        FN.Validar_controles(NP_Recolección_de_documentos)
        Total_general()
        FN.Estado_del_menú("Guardar", BarManager)
        LUE_Empresa.Focus()
    End Sub

    Private Sub BBI_Cargar_datos_costeo_vehiculos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cargar_datos_costeo_vehiculos.ItemClick
        If LUE_Tipo_de_mercadería.EditValue = "Vehiculos" Then
            Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx;*.xlsm"}
            If File.ShowDialog() = DialogResult.OK Then

                Dim Dt_BL As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select BL,Fecha_de_arribo From [Costeo$] Group By BL,Fecha_de_arribo")

                If Dt_BL(0)("BL").ToString <> "" Then
                    TE_Guia_BL_Carta_de_porte.EditValue = Dt_BL(0)("BL")
                    TE_Fecha_de_arribo.EditValue = Convert.ToDateTime(CDate(Dt_BL(0)("Fecha_de_arribo")).ToShortDateString + " 08:00:00")
                End If

                Dim Dt_PLZ As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select Poliza,Tasa_DUA,Count(No_de_Inv) As VH From [Costeo$] Group By Poliza,Tasa_DUA")
                If Dt_PLZ(0)("Poliza").ToString <> "" Then
                    Dim PLZ() As String = Split(Dt_PLZ(0)("Poliza"), "-")
                    TE_Compra.EditValue = PLZ(0)
                    TE_Ingreso_a_bodega.EditValue = PLZ(1)
                    TE_Fecha_de_ingreso_a_bodega.EditValue = Now
                    LUE_Tipo_de_costeo.EditValue = "Normal"
                    LUE_Estado.EditValue = "Completo"
                    LUE_Moneda_de_negociación.EditValue = "USD"
                    LUE_Moneda.EditValue = "USD"
                    TE_Dua_Fauca_Face.EditValue = Dt_PLZ(0)("Poliza")
                    TE_Factor_de_cambio_GTQ.EditValue = Dt_PLZ(0)("Tasa_DUA")
                    TE_Contenedores_o_bultos.EditValue = Dt_PLZ(0)("VH")
                End If

                ValidateChildren()
                FN.Validar_controles(NP_Datos_de_importación)
                FN.Validar_controles(NP_Declaración_aduanal)

                Dim Dt_DOC As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select Pedido,Factura,Tasa,Count(No_de_Inv) As VH,Sum(Fob) As FOB,Sum(Flete) As Flete,Sum(Seguro) As Seguro,Sum(Arancel) As Arancel,Sum(Gastos_bancarios) As Gastos_bancarios,Sum(Agente)+Sum(Terrestre)+Sum(Muellaje)+Sum(Oirsa)+Sum(Otros) As Gastos From [Costeo$] Group By Pedido,Factura,Tasa")
                For Each Dr As DataRow In Dt_DOC.Rows
                    If Dr("Factura").ToString <> "" Then
                        'Documento
                        GridView_DE.AddNewRow()
                        Dim Dr_DE As Integer = GridView_DE.GetRowHandle(GridView_DE.DataRowCount)
                        If GridView_DE.IsNewItemRow(Dr_DE) Then
                            GridView_DE.SetRowCellValue(Dr_DE, "Tipo_de_documento", "Invoice")
                            GridView_DE.SetRowCellValue(Dr_DE, "Documento", Dr("Factura").ToString + "-VH-" + Dr("VH").ToString + "-" + Dr("Pedido").ToString)
                            GridView_DE.SetRowCellValue(Dr_DE, "Fecha", CDate(TE_Fecha_de_arribo.EditValue).ToShortDateString)
                            GridView_DE.SetRowCellValue(Dr_DE, "FOB", Dr("FOB"))
                            GridView_DE.SetRowCellValue(Dr_DE, "Flete", Dr("Flete"))
                            GridView_DE.SetRowCellValue(Dr_DE, "Factor_de_provisión_USD", 1)
                            GridView_DE.SetRowCellValue(Dr_DE, "Factor_de_provisión_GTQ", Dr("Tasa"))
                            GridView_DE.PostEditor()
                            GridView_DE.UpdateCurrentRow()
                        End If

                        'Seguro
                        GridView_DE.AddNewRow()
                        Dr_DE = GridView_DE.GetRowHandle(GridView_DE.DataRowCount)
                        If GridView_DE.IsNewItemRow(Dr_DE) Then
                            GridView_DE.SetRowCellValue(Dr_DE, "Tipo_de_documento", "Provisión seguro")
                            GridView_DE.SetRowCellValue(Dr_DE, "Documento", Dr("Factura").ToString + "-VH-" + Dr("VH").ToString + "-" + Dr("Pedido").ToString)
                            GridView_DE.SetRowCellValue(Dr_DE, "Fecha", CDate(TE_Fecha_de_arribo.EditValue).ToShortDateString)
                            GridView_DE.SetRowCellValue(Dr_DE, "Seguro", Dr("Seguro"))
                            GridView_DE.SetRowCellValue(Dr_DE, "Factor_de_provisión_USD", 1)
                            GridView_DE.SetRowCellValue(Dr_DE, "Factor_de_provisión_GTQ", Dr("Tasa"))
                            GridView_DE.PostEditor()
                            GridView_DE.UpdateCurrentRow()
                        End If
                    End If

                    For x As Integer = 1 To 3

                        If x <> 2 Then
                            GridView_DL.AddNewRow()
                        ElseIf x = 2 And Val(Dr("Gastos_bancarios").ToString) > 0 Then
                            GridView_DL.AddNewRow()
                        End If

                        Dim Dr_DL As Integer = GridView_DL.GetRowHandle(GridView_DL.DataRowCount)
                        If GridView_DE.IsNewItemRow(Dr_DL) Then
                            Select Case x
                                Case 1
                                    GridView_DL.SetRowCellValue(Dr_DL, "Tipo_de_documento", "Provisión IPRIMA")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Documento", TE_Dua_Fauca_Face.EditValue + "-VH-" + Dr("VH").ToString + "-" + Dr("Pedido").ToString)
                                    GridView_DL.SetRowCellValue(Dr_DL, "Fecha", CDate(TE_Fecha_de_arribo.EditValue).ToShortDateString)
                                    GridView_DL.SetRowCellValue(Dr_DL, "Proveedor", "SAT")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Tipo_de_gasto", "Iprima")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Valor", Dr("Arancel"))
                                Case 2
                                    GridView_DL.SetRowCellValue(Dr_DL, "Tipo_de_documento", "GTS")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Documento", TE_Dua_Fauca_Face.EditValue + "-VH-" + Dr("VH").ToString + "-" + Dr("Pedido").ToString)
                                    GridView_DL.SetRowCellValue(Dr_DL, "Fecha", CDate(TE_Fecha_de_arribo.EditValue).ToShortDateString)
                                    GridView_DL.SetRowCellValue(Dr_DL, "Proveedor", "GENERAL")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Tipo_de_gasto", "Gastos bancarios")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Valor", Dr("Gastos_bancarios"))
                                Case 3
                                    GridView_DL.SetRowCellValue(Dr_DL, "Tipo_de_documento", "GTS")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Documento", TE_Dua_Fauca_Face.EditValue + "-VH-" + Dr("VH").ToString + "-" + Dr("Pedido").ToString)
                                    GridView_DL.SetRowCellValue(Dr_DL, "Fecha", CDate(TE_Fecha_de_arribo.EditValue).ToShortDateString)
                                    GridView_DL.SetRowCellValue(Dr_DL, "Proveedor", "GENERAL")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Tipo_de_gasto", "Gastos de importación")
                                    GridView_DL.SetRowCellValue(Dr_DL, "Valor", Dr("Gastos"))
                            End Select
                        End If
                        GridView_DL.PostEditor()
                        GridView_DL.UpdateCurrentRow()
                    Next

                Next

            End If
        End If
    End Sub

    Private Sub Guardar(Instrucción As String)
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Try
                If SQL.Duplicados("Costeos", "Where Empresa+'-'+IsNull(Compra,'')+'-'+IsNull(Ingreso_a_bodega,'')='" + LUE_Empresa.EditValue + "-" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue + "'") = False And Edicion = False Then
                    Dim ID_GN As Integer = SQL.Nuevo_ID("Id_costeo", "Costeos")

                    SQL.Insertar("Costeos", "Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Proveedor,Marca,País_de_procedencia,Tipo_de_importacion,Incoterm,Moneda_de_negociación,[Shipper|Carrier],[Guia|BL|Carta_de_porte],[Fecha_de_Guia|BL|Carta_de_porte],Fecha_de_arribo,Régimen,[Dua|Fauca|Face],[Fecha_de_Dua|Fauca|Face],Contenedores_o_bultos,Moneda,Factor_de_cambio_USD,Factor_de_cambio_GTQ,FOB_USD,Flete_USD,Seguro_USD,Otros_USD,Total_USD,Total_GTQ,DAI,IVA,DAI_e_IVA,Rectificación,[R_Dua|Fauca|Face],[R_Fecha_de_Dua|Fauca|Face],R_DAI,R_IVA,R_DAI_e_IVA,Recibido,Usuario_que_recibe,Fecha_de_recepcion,Costeo_asignado_a,Comentarios", ID_GN.ToString + ",'" + SQL.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b", "Where a.Razon_comercial='" + LUE_Empresa.Text + "' And a.RL_GE=b.Id_grupo_empresas") + "'," + FN.Campo(LUE_Empresa) + "," + FN.Campo(LUE_Tipo_de_mercadería) + "," + FN.Campo(TE_SE) + ",'" + SQL.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE='" + TE_SE.Text + "'") + "'," + FN.Campo(TE_Compra) + "," + FN.Campo(TE_Ingreso_a_bodega) + "," + FN.Campo(TE_Fecha_de_ingreso_a_bodega) + "," + FN.Campo(LUE_Tipo_de_costeo) + "," + FN.Campo(LUE_Estado) + "," + FN.Campo(LUE_Proveedor) + ",'" + LUE_Marca.Text + "'," + FN.Campo(TE_País_de_procedencia) + "," + FN.Campo(LUE_Tipo_de_importación) + "," + FN.Campo(LUE_Incoterm) + "," + FN.Campo(LUE_Moneda_de_negociación) + "," + FN.Campo(LUE_Shipper_Carrier) + "," + FN.Campo(TE_Guia_BL_Carta_de_porte) + "," + FN.Campo(TE_Fecha_de_Guia_BL_Carta_de_porte) + "," + FN.Campo(TE_Fecha_de_arribo) + "," + FN.Campo(LUE_Régimen) + "," + FN.Campo(TE_Dua_Fauca_Face) + "," + FN.Campo(TE_Fecha_de_Dua_Fauca_Face) + "," + FN.Campo(TE_Contenedores_o_bultos) + "," + FN.Campo(LUE_Moneda) + "," + FN.Campo(TE_Factor_de_cambio_USD) + "," + FN.Campo(TE_Factor_de_cambio_GTQ) + "," + FN.Campo(TE_FOB_USD) + "," + FN.Campo(TE_Flete_USD) + "," + FN.Campo(TE_Seguro_USD) + "," + FN.Campo(TE_Otros_USD) + "," + FN.Campo(TE_Total_USD) + "," + FN.Campo(TE_Total_GTQ) + "," + FN.Campo(TE_DAI) + "," + FN.Campo(TE_IVA) + "," + FN.Campo(TE_DAI_IVA) + ",'" + CK_Rectificación.Checked.ToString + "'," + FN.Campo(TE_R_Dua_Fauca_Face) + "," + FN.Campo(TE_R_Fecha_de_Dua_Fauca_Face) + "," + FN.Campo(TE_R_DAI) + "," + FN.Campo(TE_R_IVA) + "," + FN.Campo(TE_R_DAI_IVA) + ",'" + CK_Recibido.Checked.ToString + "'," + FN.Campo(TE_Usuario_que_recibe) + "," + FN.Campo(TE_Fecha_de_recepción) + "," + FN.Campo(LUE_Costeo_asignado_a) + ",'" + RTBX_Comentarios.Text + "'")

                    If GridView_DE.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DE.DataRowCount - 1
                            GridView_DE.SetRowCellValue(i, "RL_id_costeo", ID_GN)
                            GridView_DE.PostEditor()
                            GridView_DE.UpdateCurrentRow()
                        Next
                    End If

                    SQL_DE.Actualizar_tabla()

                    If GridView_DL.RowCount > 0 Then
                        For i As Integer = 0 To GridView_DL.DataRowCount - 1
                            GridView_DL.SetRowCellValue(i, "RL_id_costeo", ID_GN)
                            GridView_DL.PostEditor()
                            GridView_DL.UpdateCurrentRow()
                        Next
                    End If

                    SQL_DL.Actualizar_tabla()

                    If GridView_SG.RowCount > 0 Then
                        For i As Integer = 0 To GridView_SG.DataRowCount - 1
                            GridView_SG.SetRowCellValue(i, "RL_id_costeo", ID_GN)
                            GridView_SG.PostEditor()
                            GridView_SG.UpdateCurrentRow()
                        Next
                    End If

                    SQL_SG.Actualizar_tabla()

                    If GridView_CF.RowCount > 0 Then
                        For i As Integer = 0 To GridView_CF.DataRowCount - 1
                            GridView_CF.SetRowCellValue(i, "RL_id_costeo", ID_GN)
                            GridView_CF.PostEditor()
                            GridView_CF.UpdateCurrentRow()
                        Next
                    End If

                    SQL_CF.Actualizar_tabla()

                    ID = ID_GN

                ElseIf Edicion = True And LUE_Estado.Text <> "Anulado" Then
                    If Editables = LUE_Empresa.EditValue + "-" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue Then

                        SQL.Actualizar("Costeos", "Grupo_de_empresas='" + SQL.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b ", "Where a.Razon_comercial='" + LUE_Empresa.EditValue + "' And a.RL_GE=b.Id_grupo_empresas") + "',Empresa=" + FN.Campo(LUE_Empresa) + ",Tipo_de_mercaderia=" + FN.Campo(LUE_Tipo_de_mercadería) + ",SE=" + FN.Campo(TE_SE) + ",Sub_empresa='" + SQL.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE='" + TE_SE.EditValue.ToString + "'") + "',Compra=" + FN.Campo(TE_Compra) + ",Ingreso_a_bodega=" + FN.Campo(TE_Ingreso_a_bodega) + ",Fecha_de_ingreso_a_bodega=" + FN.Campo(TE_Fecha_de_ingreso_a_bodega) + ",Tipo_de_costeo=" + FN.Campo(LUE_Tipo_de_costeo) + ",Estado=" + FN.Campo(LUE_Estado) + ",Proveedor=" + FN.Campo(LUE_Proveedor) + ",Marca='" + LUE_Marca.Text + "',País_de_procedencia=" + FN.Campo(TE_País_de_procedencia) + ",Tipo_de_importacion=" + FN.Campo(LUE_Tipo_de_importación) + ",Incoterm=" + FN.Campo(LUE_Incoterm) + ",Moneda_de_negociación=" + FN.Campo(LUE_Moneda_de_negociación) + ",[Shipper|Carrier]=" + FN.Campo(LUE_Shipper_Carrier) + ",[Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Guia_BL_Carta_de_porte) + ",[Fecha_de_Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Fecha_de_Guia_BL_Carta_de_porte) + ",Fecha_de_arribo=" + FN.Campo(TE_Fecha_de_arribo) + ",Régimen=" + FN.Campo(LUE_Régimen) + ",[Dua|Fauca|Face]=" + FN.Campo(TE_Dua_Fauca_Face) + ",[Fecha_de_Dua|Fauca|Face]=" + FN.Campo(TE_Fecha_de_Dua_Fauca_Face) + ",Contenedores_o_bultos=" + FN.Campo(TE_Contenedores_o_bultos) + ",Moneda=" + FN.Campo(LUE_Moneda) + ",Factor_de_cambio_USD=" + FN.Campo(TE_Factor_de_cambio_USD) + ",Factor_de_cambio_GTQ=" + FN.Campo(TE_Factor_de_cambio_GTQ) + ",FOB_USD=" + FN.Campo(TE_FOB_USD) + ",Flete_USD=" + FN.Campo(TE_Flete_USD) + ",Seguro_USD=" + FN.Campo(TE_Seguro_USD) + ",Otros_USD=" + FN.Campo(TE_Otros_USD) + ",Total_USD=" + FN.Campo(TE_Total_USD) + ",Total_GTQ=" + FN.Campo(TE_Total_GTQ) + ",DAI=" + FN.Campo(TE_DAI) + ",IVA=" + FN.Campo(TE_IVA) + ",DAI_e_IVA=" + FN.Campo(TE_DAI_IVA) + ",Rectificación='" + CK_Rectificación.Checked.ToString + "',[R_Dua|Fauca|Face]=" + FN.Campo(TE_R_Dua_Fauca_Face) + ",[R_Fecha_de_Dua|Fauca|Face]=" + FN.Campo(TE_R_Fecha_de_Dua_Fauca_Face) + ",R_DAI=" + FN.Campo(TE_R_DAI) + ",R_IVA=" + FN.Campo(TE_R_IVA) + ",R_DAI_e_IVA=" + FN.Campo(TE_R_DAI_IVA) + ",Recibido='" + CK_Recibido.Checked.ToString + "',Usuario_que_recibe=" + FN.Campo(TE_Usuario_que_recibe) + ",Fecha_de_recepcion=" + FN.Campo(TE_Fecha_de_recepción) + ",Costeo_asignado_a=" + FN.Campo(LUE_Costeo_asignado_a) + ",Comentarios='" + RTBX_Comentarios.Text + "'", "Id_costeo=" + ID.ToString)

                        If GridView_DE.RowCount > 0 Then
                            For i As Integer = 0 To GridView_DE.DataRowCount - 1
                                GridView_DE.PostEditor()
                                GridView_DE.UpdateCurrentRow()
                            Next
                        End If

                        SQL_DE.Actualizar_tabla()

                        If GridView_DL.RowCount > 0 Then
                            For i As Integer = 0 To GridView_DL.DataRowCount - 1
                                GridView_DL.PostEditor()
                                GridView_DL.UpdateCurrentRow()
                            Next
                        End If

                        SQL_DL.Actualizar_tabla()

                        If GridView_SG.RowCount > 0 Then
                            For i As Integer = 0 To GridView_SG.DataRowCount - 1
                                GridView_SG.PostEditor()
                                GridView_SG.UpdateCurrentRow()
                            Next
                        End If

                        SQL_SG.Actualizar_tabla()

                        If GridView_CF.RowCount > 0 Then
                            For i As Integer = 0 To GridView_CF.DataRowCount - 1
                                GridView_CF.PostEditor()
                                GridView_CF.UpdateCurrentRow()
                            Next
                        End If

                        SQL_CF.Actualizar_tabla()

                    Else
                        If SQL.Duplicados("Costeos", "Where Empresa+'-'+IsNull(Compra,'')+'-'+IsNull(Ingreso_a_bodega,'')='" + LUE_Empresa.EditValue + "-" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue + "'") = False Then

                            SQL.Actualizar("Costeos", "Grupo_de_empresas='" + SQL.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b ", "Where a.Razon_comercial='" + LUE_Empresa.EditValue + "' And a.RL_GE=b.Id_grupo_empresas") + "',Empresa=" + FN.Campo(LUE_Empresa) + ",Tipo_de_mercaderia=" + FN.Campo(LUE_Tipo_de_mercadería) + ",SE=" + FN.Campo(TE_SE) + ",Sub_empresa='" + SQL.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE='" + TE_SE.EditValue.ToString + "'") + "',Compra=" + FN.Campo(TE_Compra) + ",Ingreso_a_bodega=" + FN.Campo(TE_Ingreso_a_bodega) + ",Fecha_de_ingreso_a_bodega=" + FN.Campo(TE_Fecha_de_ingreso_a_bodega) + ",Tipo_de_costeo=" + FN.Campo(LUE_Tipo_de_costeo) + ",Estado=" + FN.Campo(LUE_Estado) + ",Proveedor=" + FN.Campo(LUE_Proveedor) + ",Marca='" + LUE_Marca.Text + "',País_de_procedencia=" + FN.Campo(TE_País_de_procedencia) + ",Tipo_de_importacion=" + FN.Campo(LUE_Tipo_de_importación) + ",Incoterm=" + FN.Campo(LUE_Incoterm) + ",Moneda_de_negociación=" + FN.Campo(LUE_Moneda_de_negociación) + ",[Shipper|Carrier]=" + FN.Campo(LUE_Shipper_Carrier) + ",[Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Guia_BL_Carta_de_porte) + ",[Fecha_de_Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Fecha_de_Guia_BL_Carta_de_porte) + ",Fecha_de_arribo=" + FN.Campo(TE_Fecha_de_arribo) + ",Régimen=" + FN.Campo(LUE_Régimen) + ",[Dua|Fauca|Face]=" + FN.Campo(TE_Dua_Fauca_Face) + ",[Fecha_de_Dua|Fauca|Face]=" + FN.Campo(TE_Fecha_de_Dua_Fauca_Face) + ",Contenedores_o_bultos=" + FN.Campo(TE_Contenedores_o_bultos) + ",Moneda=" + FN.Campo(LUE_Moneda) + ",Factor_de_cambio_USD=" + FN.Campo(TE_Factor_de_cambio_USD) + ",Factor_de_cambio_GTQ=" + FN.Campo(TE_Factor_de_cambio_GTQ) + ",FOB_USD=" + FN.Campo(TE_FOB_USD) + ",Flete_USD=" + FN.Campo(TE_Flete_USD) + ",Seguro_USD=" + FN.Campo(TE_Seguro_USD) + ",Otros_USD=" + FN.Campo(TE_Otros_USD) + ",Total_USD=" + FN.Campo(TE_Total_USD) + ",Total_GTQ=" + FN.Campo(TE_Total_GTQ) + ",DAI=" + FN.Campo(TE_DAI) + ",IVA=" + FN.Campo(TE_IVA) + ",DAI_e_IVA=" + FN.Campo(TE_DAI_IVA) + ",Rectificación='" + CK_Rectificación.Checked.ToString + "',[R_Dua|Fauca|Face]=" + FN.Campo(TE_R_Dua_Fauca_Face) + ",[R_Fecha_de_Dua|Fauca|Face]=" + FN.Campo(TE_R_Fecha_de_Dua_Fauca_Face) + ",R_DAI=" + FN.Campo(TE_R_DAI) + ",R_IVA=" + FN.Campo(TE_R_IVA) + ",R_DAI_e_IVA=" + FN.Campo(TE_R_DAI_IVA) + ",Recibido='" + CK_Recibido.Checked.ToString + "',Usuario_que_recibe=" + FN.Campo(TE_Usuario_que_recibe) + ",Fecha_de_recepcion=" + FN.Campo(TE_Fecha_de_recepción) + ",Costeo_asignado_a=" + FN.Campo(LUE_Costeo_asignado_a) + ",Comentarios='" + RTBX_Comentarios.Text + "'", "Id_costeo=" + ID.ToString)

                            If GridView_DE.RowCount > 0 Then
                                For i As Integer = 0 To GridView_DE.DataRowCount - 1
                                    GridView_DE.PostEditor()
                                    GridView_DE.UpdateCurrentRow()
                                Next
                            End If

                            SQL_DE.Actualizar_tabla()

                            If GridView_DL.RowCount > 0 Then
                                For i As Integer = 0 To GridView_DL.DataRowCount - 1
                                    GridView_DL.PostEditor()
                                    GridView_DL.UpdateCurrentRow()
                                Next
                            End If

                            SQL_DL.Actualizar_tabla()

                            If GridView_SG.RowCount > 0 Then
                                For i As Integer = 0 To GridView_SG.DataRowCount - 1
                                    GridView_SG.PostEditor()
                                    GridView_SG.UpdateCurrentRow()
                                Next
                            End If

                            SQL_SG.Actualizar_tabla()

                            If GridView_CF.RowCount > 0 Then
                                For i As Integer = 0 To GridView_CF.DataRowCount - 1
                                    GridView_CF.PostEditor()
                                    GridView_CF.UpdateCurrentRow()
                                Next
                            End If

                            SQL_CF.Actualizar_tabla()

                        Else
                            MsgBox("El ingreso que intentas actualizar ya existe", MsgBoxStyle.Critical, "Recepción de costeos")
                        End If
                    End If
                ElseIf Edicion = True And LUE_Estado.EditValue = "Anulado" Then
                    SQL.Actualizar("Costeos", "Estado='" + LUE_Estado.EditValue + "',Recibido='False',Usuario_que_recibe=NULL,Fecha_de_recepcion=NULL,Costeo_asignado_a=NULL,Elaborado='False',Fecha_de_elaboracion=NULL,Usuario_que_elabora=NULL,Archivo=NULL", "Id_costeo=" + ID.ToString)
                    SQL.Eliminar("Seguro", "RL_id_costeo=" + ID.ToString)
                Else
                    MsgBox("El ingreso que intentas registrar ya existe", MsgBoxStyle.Critical, "Recepción de costeos")
                End If

                If Instrucción = "Guardar y seguir" Then

                    If ID <> 0 Then
                        FN.Estado_del_menú("Guardar", BarManager)
                        Datos_consulta()
                        Edicion = True
                    End If

                ElseIf Instrucción = "Guardar y limpiar" Then

                    BBI_Cancelar_ItemClick(Nothing, Nothing)

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Recepción de costeos")
            End Try
        Else
            MsgBox("Por favor valida los campos o datos obligatorios", MsgBoxStyle.Critical, "Recepción de costeos")
        End If
    End Sub

    Private Sub BBI_Guardar_y_seguir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar_y_seguir.ItemClick
        Guardar("Guardar y seguir")
    End Sub

    Private Sub BBI_Guardar_y_limpiar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar_y_limpiar.ItemClick
        Guardar("Guardar y limpiar")
    End Sub

    Private Sub BBI_Cancelar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cancelar.ItemClick
        FN.Limpiar_controles(GC_Datos_de_ingreso_a_bodega) : FN.Deshabilitar_controles(GC_Datos_de_ingreso_a_bodega)
        FN.Limpiar_controles(NP_Datos_de_importación) : FN.Deshabilitar_controles(NP_Datos_de_importación)
        Cargar_documentos_del_exterior("Where RL_id_costeo = 0") : GridView_DE.OptionsBehavior.Editable = False
        FN.Limpiar_controles(NP_Declaración_aduanal) : FN.Deshabilitar_controles(NP_Declaración_aduanal)
        FN.Limpiar_controles(GC_Rectificación) : FN.Deshabilitar_controles(GC_Rectificación)
        FN.Limpiar_controles(NP_Recolección_de_documentos) : FN.Deshabilitar_controles(NP_Recolección_de_documentos)
        Cargar_documentos_locales("Where RL_id_costeo = 0") : GridView_DL.OptionsBehavior.Editable = False
        Cargar_certificaciones("Where RL_id_costeo = 0") : GridView_CF.OptionsBehavior.ReadOnly = True
        Cargar_Seguro("Where RL_id_costeo = 0") : GridView_SG.OptionsBehavior.Editable = False
        FN.Limpiar_controles(GC_Comentarios)
        DocumentViewer.DocumentSource = "(none)" : DocumentViewer.Status = "El documento no contiene ninguna página."
        Cargar_contabilidad() : GridView_CT.OptionsBehavior.Editable = False
        ID = Nothing : Edicion = False
        ValidateChildren()
        FN.Validar_controles(NP_Datos_de_importación)
        FN.Validar_controles(NP_Declaración_aduanal)
        FN.Validar_controles(NP_Recolección_de_documentos)
        Total_general()
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub BBI_Editar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Editar.ItemClick
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Editar"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                Edicion = True
                FN.Habilitar_controles(GC_Datos_de_ingreso_a_bodega)
                FN.Habilitar_controles(NP_Datos_de_importación)
                FN.Habilitar_controles(NP_Declaración_aduanal)
                FN.Habilitar_controles(GC_Rectificación)
                FN.Habilitar_controles(NP_Recolección_de_documentos)
                GridView_DE.OptionsBehavior.Editable = True : GridView_DL.OptionsBehavior.Editable = True : GridView_CF.OptionsBehavior.ReadOnly = False
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
                    SQL.Eliminar("Costeos", "Id_costeo=" + ID.ToString)
                    SQL.Eliminar("Documentos_del_exterior", "RL_id_costeo=" + ID.ToString)
                    SQL.Eliminar("Documentos_locales", "RL_id_costeo=" + ID.ToString)
                    SQL.Eliminar("Seguro", "RL_id_costeo=" + ID.ToString)
                    SQL.Eliminar("Certificaciones", "RL_id_costeo=" + ID.ToString)
                    BBI_Cancelar_ItemClick(sender, Nothing)
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar usuario")
            End Try
        End If
    End Sub

    Private Sub BBI_Buscar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Buscar.ItemClick
        Dim BSQ As New BackOffice_servicios.Busqueda With {.Consulta = "Select Id_costeo,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Tipo_de_importacion,[Guia|BL|Carta_de_porte],[Dua|Fauca|Face],Usuario_que_recibe,Fecha_de_recepcion,Costeo_asignado_a,Dif_Ing_Rec From Costeos", .Columna_ID = "Id_costeo", .Alinear = ""}
        BSQ.ShowDialog()
        If BSQ.ID_resultado <> 0 Then ID = BSQ.ID_resultado : FN.Estado_del_menú("Buscar", BarManager) : Datos_consulta() : BSQ.Dispose()
    End Sub

    Public Sub Datos_consulta()

        Dim Dt As DataTable = SQL.Tabla_de_datos("Select * From Costeos Where Id_costeo=" + ID.ToString)

        'Datos de ingreso a bodega
        FN.Limpiar_controles(GC_Datos_de_ingreso_a_bodega)
        Editables = FN.Valor(Dt.Rows(0)("Empresa")) + "-" + FN.Valor(Dt.Rows(0)("Compra")) + "-" + FN.Valor(Dt.Rows(0)("Ingreso_a_bodega"))
        LUE_Empresa.EditValue = FN.Valor(Dt.Rows(0)("Empresa"))
        LUE_Tipo_de_mercadería.EditValue = FN.Valor(Dt.Rows(0)("Tipo_de_mercaderia"))
        LUE_Sub_empresa.EditValue = FN.Valor(Dt.Rows(0)("SE"))
        TE_Compra.EditValue = FN.Valor(Dt.Rows(0)("Compra"))
        TE_Ingreso_a_bodega.EditValue = FN.Valor(Dt.Rows(0)("Ingreso_a_bodega"))
        TE_Fecha_de_ingreso_a_bodega.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_ingreso_a_bodega"))
        LUE_Tipo_de_costeo.EditValue = FN.Valor(Dt.Rows(0)("Tipo_de_costeo"))
        LUE_Estado.EditValue = FN.Valor(Dt.Rows(0)("Estado"))

        'Datos de importación
        FN.Limpiar_controles(NP_Datos_de_importación)
        LUE_Proveedor.EditValue = FN.Valor(Dt.Rows(0)("Proveedor"))
        LUE_Marca.EditValue = FN.Valor(Dt.Rows(0)("País_de_procedencia"))
        LUE_Tipo_de_importación.EditValue = FN.Valor(Dt.Rows(0)("Tipo_de_importacion"))
        LUE_Incoterm.EditValue = FN.Valor(Dt.Rows(0)("Incoterm"))
        LUE_Moneda_de_negociación.EditValue = FN.Valor(Dt.Rows(0)("Moneda_de_negociación"))
        LUE_Shipper_Carrier.EditValue = FN.Valor(Dt.Rows(0)("Shipper|Carrier"))
        TE_Guia_BL_Carta_de_porte.EditValue = FN.Valor(Dt.Rows(0)("Guia|BL|Carta_de_porte"))
        TE_Fecha_de_Guia_BL_Carta_de_porte.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_Guia|BL|Carta_de_porte"))
        TE_Fecha_de_arribo.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_arribo"))

        'Datos documentos del exterior
        Cargar_documentos_del_exterior("Where RL_id_costeo = " + ID.ToString)

        'Datos de declaración aduanal
        FN.Limpiar_controles(NP_Declaración_aduanal)
        LUE_Régimen.EditValue = FN.Valor(Dt.Rows(0)("Régimen"))
        TE_Dua_Fauca_Face.EditValue = FN.Valor(Dt.Rows(0)("Dua|Fauca|Face"))
        TE_Fecha_de_Dua_Fauca_Face.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_Dua|Fauca|Face"))
        TE_Contenedores_o_bultos.EditValue = FN.Valor(Dt.Rows(0)("Contenedores_o_bultos"))
        LUE_Moneda.EditValue = FN.Valor(Dt.Rows(0)("Moneda"))
        TE_Factor_de_cambio_USD.EditValue = FN.Valor(Dt.Rows(0)("Factor_de_cambio_USD"))
        TE_Factor_de_cambio_GTQ.EditValue = FN.Valor(Dt.Rows(0)("Factor_de_cambio_GTQ"))
        TE_FOB_USD.EditValue = FN.Valor(Dt.Rows(0)("FOB_USD"))
        TE_Flete_USD.EditValue = FN.Valor(Dt.Rows(0)("Flete_USD"))
        TE_Seguro_USD.EditValue = FN.Valor(Dt.Rows(0)("Seguro_USD"))
        TE_Otros_USD.EditValue = FN.Valor(Dt.Rows(0)("Otros_USD"))
        TE_Total_USD.EditValue = FN.Valor(Dt.Rows(0)("Total_USD"))
        TE_Total_GTQ.EditValue = FN.Valor(Dt.Rows(0)("Total_GTQ"))
        TE_DAI.EditValue = FN.Valor(Dt.Rows(0)("DAI"))
        TE_IVA.EditValue = FN.Valor(Dt.Rows(0)("IVA"))
        TE_DAI_IVA.EditValue = FN.Valor(Dt.Rows(0)("DAI_e_IVA"))

        'Datos de declaración aduanal rectificación
        CK_Rectificación.EditValue = FN.Valor(Dt.Rows(0)("Rectificación"))
        TE_R_Dua_Fauca_Face.EditValue = FN.Valor(Dt.Rows(0)("R_Dua|Fauca|Face"))
        TE_R_Fecha_de_Dua_Fauca_Face.EditValue = FN.Valor(Dt.Rows(0)("R_Fecha_de_Dua|Fauca|Face"))
        TE_R_DAI.EditValue = FN.Valor(Dt.Rows(0)("R_DAI"))
        TE_R_IVA.EditValue = FN.Valor(Dt.Rows(0)("R_IVA"))
        TE_R_DAI_IVA.EditValue = FN.Valor(Dt.Rows(0)("R_DAI_e_IVA"))

        'Datos de recolección de documentos
        RemoveHandler CK_Recibido.CheckedChanged, AddressOf CK_Recibido_CheckedChanged
        FN.Limpiar_controles(NP_Recolección_de_documentos)
        CK_Recibido.EditValue = FN.Valor(Dt.Rows(0)("Recibido"))
        TE_Usuario_que_recibe.EditValue = FN.Valor(Dt.Rows(0)("Usuario_que_recibe"))
        TE_Fecha_de_recepción.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_recepcion"))
        LUE_Costeo_asignado_a.EditValue = FN.Valor(Dt.Rows(0)("Costeo_asignado_a"))
        AddHandler CK_Recibido.CheckedChanged, AddressOf CK_Recibido_CheckedChanged

        'Datos documentos locales
        Cargar_documentos_locales("Where RL_id_costeo = " + ID.ToString)

        'Datos documentos locales
        Cargar_Seguro("Where RL_id_costeo = " + ID.ToString)

        'Certificaciones
        Cargar_certificaciones("Where RL_id_costeo = " + ID.ToString)

        'Comentarios
        FN.Limpiar_controles(GC_Comentarios)
        RTBX_Comentarios.Text = Dt.Rows(0)("Comentarios").ToString

        'Costeo
        CT = New Costeo With {.Id_costeo = ID}
        CT.CreateDocument()
        DocumentViewer.DocumentSource = CT

        'Contabilidad
        Cargar_contabilidad()

        Total_general()

    End Sub

    Private Sub Recepción_de_costeos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F3 And BBI_Buscar.Enabled = True Then
            BBI_Buscar_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.N And BBI_Nuevo.Enabled = True Then
            BBI_Nuevo_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.G And BBI_Guardar_y_seguir.Enabled = True Then
            BBI_Guardar_y_seguir_ItemClick(sender, Nothing)
        End If
    End Sub

    Private Sub Total_general()

        GridView_DE.UpdateSummary()
        GridView_DL.UpdateSummary()

        Seguro()

        Dim Total As Double = Val(GridView_DE.Columns("Total_GTQ").SummaryItem.SummaryValue) + Val(TE_DAI.EditValue) + Val(TE_R_DAI.EditValue) + Val(GridView_DL.Columns("Valor_sin_IVA").SummaryItem.SummaryValue) + Val(GridView_SG.Columns("Total_seguro_GTQ").SummaryItem.SummaryValue)

        If Total <> 0 Then

            TE_Total_general.EditValue = Total

            Select Case SQL.Extraer_informacion_de_columna("Comparativo_moneda_USD", "Tipos_de_moneda", "Where Moneda='" + LUE_Moneda.EditValue + "'")

                Case "Apreciada"

                    TE_Factor_USD.EditValue = TE_Total_general.EditValue / Math.Round(GridView_DE.Columns("FOB").SummaryItem.SummaryValue * TE_Factor_de_cambio_USD.EditValue, 2)

                Case "Depreciada"

                    TE_Factor_USD.EditValue = TE_Total_general.EditValue / Math.Round(GridView_DE.Columns("FOB").SummaryItem.SummaryValue / TE_Factor_de_cambio_USD.EditValue, 2)

            End Select
        Else
            TE_Total_general.EditValue = Nothing
            TE_Factor_USD.EditValue = Nothing
        End If

    End Sub

    Public Sub Estado_busqueda()
        BBI_Cancelar_ItemClick(Nothing, Nothing)
        FN.Estado_del_menú("Buscar", BarManager)
    End Sub

End Class