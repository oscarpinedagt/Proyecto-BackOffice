Public Class Proveedores_locales
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Proveedores_locales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        Configurar_GridControl()
    End Sub


    Private Sub Cargar_datos()
        SQL.Tabla_con_actualización_de_datos("Select * From Proveedores_locales")
        GridControl.DataSource = Sql.DT
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                Select Case CL.FieldName
                    Case "Id_proveedor"
                        CL.Visible = False

                    Case "Nit"
                        CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End Select
            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_proveedor", SQL.Nuevo_ID("Id_proveedor", "Proveedores_locales"))
    End Sub

    Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        If GridView.GetRowCellValue(e.RowHandle, "Nit").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Razon_social").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Razon_comercial").ToString <> "" Then
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