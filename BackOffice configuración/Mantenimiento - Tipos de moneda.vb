Public Class Mantenimiento_Tipos_de_moneda
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Tipos_de_moneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        Configurar_GridControl()
    End Sub

    Private Sub Cargar_datos()
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos("Select * From Tipos_de_moneda")
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                Select Case CL.FieldName
                    Case "Id_moneda"
                        CL.Visible = False
                End Select
            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

        Columna_comparativo_moneda_USD()

    End Sub

    Private Sub Columna_comparativo_moneda_USD()
        Dim DT As New DataTable
        DT.Columns.Add("Comparativo_moneda_USD", GetType(String))
        DT.Rows.Add("Apreciada") : DT.Rows.Add("Depreciada")
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = DT
            .ValueMember = "Comparativo_moneda_USD"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Comparativo_moneda_USD").ColumnEdit = Item
    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_moneda", SQL.Nuevo_ID("Id_moneda", "Tipos_de_moneda"))
    End Sub

        Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        If GridView.GetRowCellValue(e.RowHandle, "Moneda").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Comparativo_moneda_USD").ToString <> "" Then
            e.Valid = True
        Else
            e.ErrorText = "Todos los campos son requeridos"
                e.Valid = False
            End If
        End Sub

        Private Sub GridView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView.RowUpdated
            SQL.Actualizar_tabla()
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