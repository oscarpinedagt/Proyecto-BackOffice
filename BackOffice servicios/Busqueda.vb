Public Class Busqueda
    Dim SQL As New BackOffice_datos.SQL
    Public Property Consulta As String : Property Columna_ID As String : Property ID_resultado As String : Property Alinear As String
    Private Sub Busqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        Configurar_GridControl()
    End Sub

    Private Sub Cargar_datos()
        GridControl.DataSource = SQL.Tabla_de_datos(Consulta)
    End Sub

    Private Sub Configurar_GridControl()
        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatString = "g"
                End If
                CL.Caption = Replace(CL.FieldName, "_", " ")
                Select Case CL.FieldName
                    Case Columna_ID
                        CL.Visible = False
                End Select
                If Alinear.Contains(CL.FieldName) Then
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Enter Then
            GridView_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub GridView_DoubleClick(sender As Object, e As EventArgs) Handles GridView.DoubleClick
        Dim ea As DevExpress.Utils.DXMouseEventArgs = TryCast(e, DevExpress.Utils.DXMouseEventArgs)
        Dim Info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = GridView.CalcHitInfo(ea.Location)

        Dim i As Integer = GridView.GetRowCellValue(Info.RowHandle, Columna_ID)

        If Info.InRow Or Info.InRowCell Then
            If i > 0 And i.ToString <> "" Then
                ID_resultado = i
                Close()
            End If
        End If
    End Sub

    Private Sub Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Escape Then
            Dispose()
        End If
    End Sub

End Class