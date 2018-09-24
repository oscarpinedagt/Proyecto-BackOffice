Public Class Comentario
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New Funciones

    Public Property Guardar As Boolean : Property Tipo_de_comentario As String : Property Comentario As String
    Private Sub Comentario_Load(sender As Object, e As EventArgs) Handles Me.Load

        With LUE_Tipo_de_comentario.Properties
            .DataSource = SQL.Tabla_de_datos("Select * From Tipos_de_comentario")
            .ValueMember = "Id_tipos_de_comentario"
            .DisplayMember = "Tipo_de_comentario"
            .PopulateColumns()
            .Columns.Item("Id_tipos_de_comentario").Visible = False
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub SB_Guardar_comentario_Click(sender As Object, e As EventArgs) Handles SB_Guardar_comentario.Click
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Tipo_de_comentario = "Tipo de comentario: " & LUE_Tipo_de_comentario.Text
            If RTBX_Comentario.Text <> "" Then
                Comentario = RTBX_Comentario.Text
            Else
                Comentario = "/*"
            End If
            Guardar = True
            Close()
        End If
    End Sub

    Private Sub Comentario_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Control + Keys.G Then
            SB_Guardar_comentario_Click(sender, Nothing)
        ElseIf e.KeyData = Keys.Escape Then
            Dispose()
        End If
    End Sub

    Private Sub Validar_información()
        FN.Validar_campos(LUE_Tipo_de_comentario, "Debes asignar un tipo de comentario", DxErrorProvider)
    End Sub

    Private Sub LUE_Tipo_de_comentario_Validating(sender As Object, e As CancelEventArgs) Handles LUE_Tipo_de_comentario.Validating
        FN.Validar_campos(LUE_Tipo_de_comentario, "Debes asignar un tipo de comentario", DxErrorProvider)
    End Sub

End Class