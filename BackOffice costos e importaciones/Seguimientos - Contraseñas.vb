Public Class Seguimientos_Contraseñas
    Dim SQL As New BackOffice_datos.SQL
    Private Sub Seguimientos_Contraseñas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DE_Fecha_inicial.DateTime = Format(Now, "01/MM/yyyy")
        DE_Fecha_final.DateTime = Format(Now, "dd/MM/yyyy")
        BBI_Generar_información_ItemClick(Nothing, Nothing)
        Configurar_GridControl()
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos("Select * From Seguimiento_contraseñas " + Condicion)
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    Select Case CL.FieldName
                        Case "Fecha_de_pago"
                            CL.DisplayFormat.FormatString = "d"
                            CL.OptionsColumn.AllowEdit = True
                            CL.OptionsColumn.AllowFocus = True
                    End Select
                End If

                Select Case CL.FieldName
                    Case "Id_contraseña"
                        CL.Visible = False
                End Select

            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
        Columna_empresa()
        Columna_asignado_a()
        Columna_fecha()
        Columna_fecha_y_hora()
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
        GridView.Columns("Empresa").ColumnEdit = Item
    End Sub

    Private Sub Columna_asignado_a()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select a.Nombres+' '+a.Apellidos As Nombre From Usuarios a,Complementos_del_puesto b Where a.Id_usuario<>0 AND a.RL_CP=b.Id_CP AND b.Division='Costos e Importaciones'")
            .ValueMember = "Nombre"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Asignado_a").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha_y_hora()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "g"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha_de_recepción").ColumnEdit = Item
        GridView.Columns("Fecha_de_asignación").ColumnEdit = Item
        GridView.Columns("Fecha_de_contabilización").ColumnEdit = Item
        GridView.Columns("Fecha_de_traslado_para_revisión").ColumnEdit = Item
        GridView.Columns("Fecha_de_revisión").ColumnEdit = Item
        GridView.Columns("Fecha_de_aprobación").ColumnEdit = Item
        GridView.Columns("Fecha_de_traslado_a_Tesorería").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "d"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha_de_pago").ColumnEdit = Item
    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        Dim CF1 As String = "Fecha_de_recepción"

        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        Dim FF As DateTime = Convert.ToDateTime(DE_Fecha_final.DateTime.ToShortDateString + " 23:59:59")
        If FF >= FI Then
            Cargar_datos(" Where " + CF1 + " Between '" + FI.ToString + "' And '" + FF.ToString + "' Order By " & CF1)
        End If
    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_contraseña", SQL.Nuevo_ID("Id_contraseña", "Seguimiento_contraseñas"))
    End Sub

    Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        If GridView.GetRowCellValue(e.RowHandle, "Empresa").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Contraseña").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Fecha_de_recepción").ToString <> "" Then
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

    Private Sub GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView.CellValueChanged
        Dim C As String = e.Column.FieldName, R As Integer = e.RowHandle
        If C = "Fecha_de_recepción" Then
            Dim Fecha As Date = DateAdd(DateInterval.Day, 30, GridView.GetRowCellValue(R, "Fecha_de_recepción"))

            While WeekdayName(Weekday(Fecha)) <> "viernes"
                Fecha = DateAdd(DateInterval.Day, 1, Fecha)
            End While

            GridView.SetRowCellValue(R, "Fecha_de_pago", Fecha)

        End If
    End Sub
End Class