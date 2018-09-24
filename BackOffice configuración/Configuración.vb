Public Class Configuración
    Dim FN As New BackOffice_servicios.Funciones
    Dim Arg() As String = Split(Command$(), "/")

    Private Sub Configuración_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Arg(0) = "True" Then RibbonControl.Enabled = True Else RibbonControl.Enabled = False
    End Sub

    Private Sub BBI_Grupo_de_empresas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Grupo_de_empresas.ItemClick
        FN.Abrir_formulario(Me, Grupo_de_empresas)
    End Sub

    Private Sub BBI_Empresa_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Empresa.ItemClick
        FN.Abrir_formulario(Me, Empresa)
    End Sub

    Private Sub BBI_Sub_empresa_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Sub_empresa.ItemClick
        FN.Abrir_formulario(Me, Sub_empresa)
    End Sub

    Private Sub BBI_Tipos_de_mercaderia_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Tipos_de_mercaderia.ItemClick
        FN.Abrir_formulario(Me, Tipos_de_mercaderia)
    End Sub

    Private Sub BBI_Tipos_de_moneda_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Tipos_de_moneda.ItemClick
        FN.Abrir_formulario(Me, Tipos_de_moneda)
    End Sub

    Private Sub BBI_Complementos_del_puesto_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Complementos_del_puesto.ItemClick
        FN.Abrir_formulario(Me, Complementos_del_puesto)
    End Sub

    Private Sub BBI_Perfil_del_puesto_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Perfil_del_puesto.ItemClick
        FN.Abrir_formulario(Me, Perfil_del_puesto)
    End Sub

    Private Sub BBI_Usuario_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Usuario.ItemClick
        Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Mostrar"}
        SEG.ShowDialog()
        If SEG.Resultado = True Then
            Dim Usuario As New BackOffice_servicios.Usuario With {.Apertura = False}
            FN.Abrir_formulario(Me, Usuario)
        End If
    End Sub

    Private Sub BBI_Directorios_matrices_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Directorios_matrices.ItemClick
        FN.Abrir_formulario(Me, Directorios_matrices)
    End Sub

    Private Sub BBI_Directorios_para_adjuntos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Directorios_para_adjuntos.ItemClick
        FN.Abrir_formulario(Me, Directorio_para_adjuntos)
    End Sub

    Private Sub BBI_seguimientos_y_correos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_seguimientos_y_correos.ItemClick
        FN.Abrir_formulario(Me, Seguimientos_y_correos)
    End Sub

    Private Sub BBI_Contraseñas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Contraseñas.ItemClick
        Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Mostrar"}
        SEG.ShowDialog()
        If SEG.Resultado = True Then
            FN.Abrir_formulario(Me, Contraseñas)
        End If
    End Sub
End Class