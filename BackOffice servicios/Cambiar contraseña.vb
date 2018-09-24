Public Class Cambiar_contraseña
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Private Sub SB_Cambiar_contraseña_Click(sender As Object, e As EventArgs) Handles SB_Cambiar_contraseña.Click
        If SQL.Seguridad(TE_Usuario.Text, TE_Contraseña_actual.Text, "Usuarios", "Usuario") = True Then
            If TE_Nueva_contraseña.Text <> "" Then
                If SQL.Actualizar("Usuarios", "Contraseña=" + FN.Campo(TE_Nueva_contraseña), "Usuario='" + TE_Usuario.Text + "'") Then
                    MsgBox("Cambio realizado con exito", MsgBoxStyle.Information, "Cambio de contraseña")
                    Dispose()
                End If
            Else
                MsgBox("Tienes que ingresar tu nueva contraseña", MsgBoxStyle.Critical, "Cambio de contraseña")
            End If
        Else
            MsgBox("Usuario o contraseña invalidos", MsgBoxStyle.Critical, "Cambio de contraseña")
        End If
    End Sub

    Private Sub Cambiar_contraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SB_Cambiar_contraseña_Click(sender, e)
        ElseIf e.KeyData = Keys.Escape Then
            Dispose()
        End If
    End Sub
End Class