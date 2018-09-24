Public Class Contraseña
    Dim SQL As New BackOffice_datos.SQL
    Public Property Nombre_de_contraseña As String : Property Resultado As Boolean

    Private Sub Contraseña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = Text & " - [ " & Nombre_de_contraseña & " ]"
    End Sub

    Private Sub SB_Aceptar_Click(sender As Object, e As EventArgs) Handles SB_Aceptar.Click
        If SQL.Seguridad(Nombre_de_contraseña, TE_Contraseña.Text, "Contraseñas", "Nombre_contraseña") = True Then Resultado = True : Close() Else MsgBox("Contraseña invalida") : TE_Contraseña.Text = Nothing
    End Sub

    Private Sub Contraseña_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SB_Aceptar_Click(sender, e)
        ElseIf e.KeyData = Keys.Escape Then
            Dispose()
        End If
    End Sub

End Class