Public Class Mantenimiento_Seguimientos_y_correos
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Seguimientos_y_correos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        Configurar_GridControl()
    End Sub

    Private Sub Cargar_datos()
        SQL.Tabla_con_actualización_de_datos("Select * From Seguimientos_y_correos")
        GridControl.DataSource = SQL.DT
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                Select Case CL.FieldName
                    Case "Id_seguimientos_y_correos"
                        CL.Visible = False
                End Select
                Select Case CL.FieldName
                    Case "Correo_electronico_para"
                        CL.Caption = "Correo Para"
                    Case "Correo_electronico_cc"
                        CL.Caption = "Correo CC"
                    Case "Correo_electronico_cco"
                        CL.Caption = "Correo CCO"
                End Select
            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_seguimientos_y_correos", SQL.Nuevo_ID("Id_seguimientos_y_correos", "Seguimientos_y_correos"))
    End Sub

    Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        If GridView.GetRowCellValue(e.RowHandle, "Tipo_de_seguimiento").ToString <> "" Then
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

    Private Sub GridView_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GridView.CustomRowCellEdit
        If e.Column.FieldName = "Correo_electronico_para" Or e.Column.FieldName = "Correo_electronico_cc" Or e.Column.FieldName = "Correo_electronico_cco" Then
            AddHandler e.RepositoryItem.KeyPress, AddressOf Validar_caracteres_de_correo
        End If
    End Sub

    Private Sub Validar_caracteres_de_correo(sender As Object, e As KeyPressEventArgs)
        Dim TE As DevExpress.XtraEditors.TextEdit = TryCast(sender, DevExpress.XtraEditors.TextEdit)
        If Char.IsSeparator(e.KeyChar) And TE.Text.Length > 0 Then
            Dim Caracter As String = Mid(TE.Text, TE.SelectionStart, 1)
            If Caracter <> " " And Caracter <> ";" Then
                Dim i As Integer = TE.SelectionStart
                TE.Text = TE.Text.Insert(i, ";")
                TE.Text = FN.Quitar_espacios_innecesarios(TE.Text)
                TE.SelectionStart = TE.Text.Length
            End If
        End If
    End Sub
End Class