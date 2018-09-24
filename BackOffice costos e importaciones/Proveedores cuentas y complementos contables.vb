Public Class Proveedores_cuentas_y_complementos_contables
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Proveedores_cuentas_y_complementos_contables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        Configurar_GridControl()
    End Sub

    Private Sub Cargar_datos()
        SQL.Tabla_con_actualización_de_datos("Select * From Proveedores_cuentas_y_complementos")
        GridControl.DataSource = SQL.DT
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                Select Case CL.FieldName
                    Case "Id_prov_cts_comp"
                        CL.Visible = False
                End Select
                Select Case CL.FieldName
                    Case "CT_MercTran", "CT_ProvExt", "CT_DifCamb", "CT_Inv", "CT_GtsLoc", "CT_Antpos", "CT_ProvPos", "CT_ProvNeg", "CT_IVA"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "00000"
                        CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        CL.AppearanceCell.BackColor = Color.FromArgb(214, 219, 223)
                End Select
                Select Case CL.FieldName
                    Case "SE_MercTran", "DP_MercTran", "SC_MercTran", "CC_MercTran",
                         "SE_ProvExt", "DP_ProvExt", "SC_ProvExt", "CC_ProvExt",
                         "SE_DifCamb", "DP_DifCamb", "SC_DifCamb", "CC_DifCamb",
                         "SE_Inv", "DP_Inv", "SC_Inv", "CC_Inv",
                         "SE_GtsLoc", "DP_GtsLoc", "SC_GtsLoc", "CC_GtsLoc",
                         "SE_Antpos", "DP_Antpos", "SC_Antpos", "CC_Antpos",
                         "SE_ProvPos", "DP_ProvPos", "SC_ProvPos", "CC_ProvPos",
                         "SE_ProvNeg", "DP_ProvNeg", "SC_ProvNeg", "CC_ProvNeg",
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
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
        Columna_empresa()
        Columna_tipo_de_mercaderia()
    End Sub

    Private Sub Columna_empresa()
        Dim Item_Empresa As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item_Empresa
            .DataSource = SQL.Tabla_de_datos("Select Razon_comercial From Empresas")
            .ValueMember = "Razon_comercial"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = "Empresa"
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridControl.RepositoryItems.Add(Item_Empresa)
        GridView.Columns("Empresa").ColumnEdit = Item_Empresa
    End Sub

    Private Sub Columna_tipo_de_mercaderia()
        Dim Item_tipo_de_mercaderia As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item_tipo_de_mercaderia
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_mercaderia From Tipos_de_mercaderia")
            .ValueMember = "Tipo_de_mercaderia"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridControl.RepositoryItems.Add(Item_tipo_de_mercaderia)
        GridView.Columns("Tipo_de_mercaderia").ColumnEdit = Item_tipo_de_mercaderia
    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_prov_cts_comp", SQL.Nuevo_ID("Id_prov_cts_comp", "Proveedores_cuentas_y_complementos"))
    End Sub

    Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        If GridView.GetRowCellValue(e.RowHandle, "Empresa").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Proveedor").ToString <> "" Then
            e.Valid = True
        Else
            e.ErrorText = "Todos los campos son requeridos"
            e.Valid = False
        End If
    End Sub

    Private Sub GridView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView.RowUpdated
        Sql.Actualizar_tabla()
    End Sub

    Private Sub GridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView.RowDeleted
        Sql.Actualizar_tabla()
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