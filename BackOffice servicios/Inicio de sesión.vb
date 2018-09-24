Public Class Inicio_de_sesión
    Dim SQL As New BackOffice_datos.SQL
    Public Property Usuario As String : Property Resultado As Boolean

    Private Sub Inicio_de_sesión_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TE_Usuario.Text = My.Settings.Usuario
        CK_Recordar_usuario.Checked = My.Settings.Recordar_usuario
        Validar_registro_de_usuario()
        If TE_Usuario.Text = "" Then TE_Usuario.Select() Else TE_Contraseña.Select()
    End Sub

    Private Sub SB_Ingresar_Click(sender As Object, e As EventArgs) Handles SB_Ingresar.Click
        If SQL.Seguridad(TE_Usuario.Text, TE_Contraseña.Text, "Usuarios", "Usuario") = True Then
            Resultado = True
            Recordar_usuario()
            Usuario = TE_Usuario.Text
            Close()
        Else
            TE_Contraseña.Text = Nothing
            MsgBox("Usuario o contraseña invalidos", MsgBoxStyle.Critical, "Inicio de sesión")
        End If
    End Sub

    Private Sub Inicio_de_sesión_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Enter Then
            SB_Ingresar_Click(sender, e)
        ElseIf e.KeyData = Keys.Escape Then
            Dispose()
        End If
    End Sub

    Private Sub Recordar_usuario()
        If CK_Recordar_usuario.Checked = True Then
            My.Settings.Usuario = TE_Usuario.Text
        Else
            My.Settings.Usuario = Nothing
        End If
        My.Settings.Recordar_usuario = CK_Recordar_usuario.Checked
        My.Settings.Save()
    End Sub

    Private Sub Validar_registro_de_usuario()
        If SQL.Duplicados("Usuarios", "Where Usuario='" + Environment.UserName + "'") Then
            HL_Registrar_usuario.Visible = False
        Else
            HL_Registrar_usuario.Visible = True
        End If
    End Sub

    Private Sub HL_Registrar_usuario_Click(sender As Object, e As EventArgs) Handles HL_Registrar_usuario.Click
        Dim Usuario As New Usuario With {.Apertura = True}
        Usuario.Show()
        Dispose()
    End Sub

    Private Sub HL_Cambiar_contraseña_Click(sender As Object, e As EventArgs) Handles HL_Cambiar_contraseña.Click
        Dim CMC As New Cambiar_contraseña
        CMC.ShowDialog()
    End Sub

End Class