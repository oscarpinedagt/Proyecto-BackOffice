Public Class Mantenimiento_Directorio_para_adjuntos
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Directorio_para_adjuntos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        Configurar_GridControl()
    End Sub

    Private Sub Cargar_datos()
        SQL.Tabla_con_actualización_de_datos("Select * From Directorios_y_correos")
        GridControl.DataSource = Sql.DT
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")
                Select Case CL.FieldName
                    Case "Id_directorio_y_correo"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "SE"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "00"
                End Select

                Select Case CL.FieldName
                    Case "Literales", "Sub_empresa", "Estado", "Directorio"
                        CL.OptionsColumn.AllowEdit = False
                        CL.OptionsColumn.AllowFocus = False
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
        Columna_directorio_matriz()
        Columna_empresa()
        Columna_tipo_de_mercaderia()
        Columna_SE()
    End Sub

    Private Sub Columna_directorio_matriz()
        Dim Item_directorio_matriz As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item_directorio_matriz
            .DataSource = SQL.Tabla_de_datos("Select Directorio_matriz From Directorios_matrices")
            .ValueMember = "Directorio_matriz"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Directorio_matriz").ColumnEdit = Item_directorio_matriz
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
        GridView.Columns("Tipo_de_mercaderia").ColumnEdit = Item_tipo_de_mercaderia
    End Sub

    Private Sub Columna_SE()
        Dim Item_SE As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item_SE
            .DataSource = SQL.Tabla_de_datos("Select SE,Sub_empresa From Sub_empresas")
            .ValueMember = "SE"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns("Sub_empresa").Caption = Replace("Sub_empresa", "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("SE").ColumnEdit = Item_SE
    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_directorio_y_correo", SQL.Nuevo_ID("Id_directorio_y_correo", "Directorios_y_correos"))
    End Sub

    Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        If GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Literales").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia").ToString <> "" And GridView.GetRowCellValue(e.RowHandle, "Sub_empresa").ToString <> "" Then
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

    Private Sub GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView.CellValueChanged

        If e.Column.FieldName = "Directorio_matriz" Then
            If GridView.GetRowCellValue(e.RowHandle, "Crear_directorio") = True Then
                If GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz") <> "" And GridView.GetRowCellValue(e.RowHandle, "Literales") <> "" And GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia") <> "" And GridView.GetRowCellValue(e.RowHandle, "Sub_empresa") <> "" Then
                    Dim DI As New DirectoryInfo(GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz") + "\" + GridView.GetRowCellValue(e.RowHandle, "Literales") + "\" + GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia") + "\" + Format(GridView.GetRowCellValue(e.RowHandle, "SE"), "000") + " - " + GridView.GetRowCellValue(e.RowHandle, "Sub_empresa"))
                    If Not DI.Exists() Then
                        DI.Create()
                        GridView.SetRowCellValue(e.RowHandle, "Directorio", DI.FullName)
                        GridView.SetRowCellValue(e.RowHandle, "Estado", "Creado")
                    Else
                        GridView.SetRowCellValue(e.RowHandle, "Directorio", DI.FullName)
                        GridView.SetRowCellValue(e.RowHandle, "Estado", "Creado")
                    End If
                End If
            End If
        End If


        If e.Column.FieldName = "Empresa" Then
            GridView.SetRowCellValue(e.RowHandle, "Literales", SQL.Extraer_informacion_de_columna("Literales", "Empresas", "Where Razon_comercial='" + GridView.GetRowCellValue(e.RowHandle, "Empresa") + "'"))
        End If

        If e.Column.FieldName = "SE" Then
            GridView.SetRowCellValue(e.RowHandle, "Sub_empresa", SQL.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE=" + GridView.GetRowCellValue(e.RowHandle, "SE").ToString))
        End If

        If e.Column.FieldName = "Crear_directorio" Then
            If e.Value = True Then
                If GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz") <> "" And GridView.GetRowCellValue(e.RowHandle, "Literales") <> "" And GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia") <> "" And GridView.GetRowCellValue(e.RowHandle, "Sub_empresa") <> "" Then
                    Dim DI As New DirectoryInfo(GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz") + "\" + GridView.GetRowCellValue(e.RowHandle, "Literales") + "\" + GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia") + "\" + Format(GridView.GetRowCellValue(e.RowHandle, "SE"), "000") + " - " + GridView.GetRowCellValue(e.RowHandle, "Sub_empresa"))
                    If Not DI.Exists() Then
                        DI.Create()
                        GridView.SetRowCellValue(e.RowHandle, "Directorio", DI.FullName)
                        GridView.SetRowCellValue(e.RowHandle, "Estado", "Creado")
                    End If
                End If
            Else
                If GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz") <> "" And GridView.GetRowCellValue(e.RowHandle, "Literales") <> "" And GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia") <> "" And GridView.GetRowCellValue(e.RowHandle, "Sub_empresa") <> "" Then
                    Dim DI As New DirectoryInfo(GridView.GetRowCellValue(e.RowHandle, "Directorio_matriz") + "\" + GridView.GetRowCellValue(e.RowHandle, "Literales") + "\" + GridView.GetRowCellValue(e.RowHandle, "Tipo_de_mercaderia") + "\" + Format(GridView.GetRowCellValue(e.RowHandle, "SE"), "000") + " - " + GridView.GetRowCellValue(e.RowHandle, "Sub_empresa"))
                    If DI.Exists() Then
                        DI.Delete()
                        GridView.SetRowCellValue(e.RowHandle, "Directorio", DI.FullName)
                        GridView.SetRowCellValue(e.RowHandle, "Estado", "Eliminado")
                    End If
                End If
            End If
        End If
    End Sub

End Class