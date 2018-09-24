Public Class Usuario
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New Funciones
    Dim ID As Integer, Edicion As Boolean, CP As Integer

    Public Property Apertura As Boolean

    Private Sub Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Formato_de_apertura()
        Cargar_complementos_del_puesto()
        Cargar_perfil()
        BBI_Cancelar_ItemClick(sender, Nothing)
    End Sub

    Private Sub Formato_de_apertura()
        If Apertura = True Then
            FN.Habilitar_controles(Me)
            TE_Código_usuario.Text = Format(SQL.Nuevo_ID("Id_usuario", "Usuarios"), "00000")
            TE_Usuario.Text = FN.Usuario
            BE_Contraseña.Select()
            FN.Estado_del_menú("Guardar y Cancelar", BarManager)
        Else
            FN.Estado_del_menú("Nuevo", BarManager)
        End If
    End Sub

    Private Sub BE_Contraseña_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BE_Contraseña.Properties.ButtonClick
        If BE_Contraseña.Properties.UseSystemPasswordChar = True Then
            BE_Contraseña.Properties.UseSystemPasswordChar = False
        Else
            BE_Contraseña.Properties.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub SB_Complementos_del_puesto_Click(sender As Object, e As EventArgs) Handles SB_Complementos_del_puesto.Click
        If Tv_Complementos_del_puesto.Height = 1 Then
            Height = 580
            SB_Complementos_del_puesto.Text = "[ - ]"
            Tv_Complementos_del_puesto.Height = 154
            Tv_Complementos_del_puesto.Select()
        Else
            Height = 530
            SB_Complementos_del_puesto.Text = "[ + ]"
            Tv_Complementos_del_puesto.Height = 1
        End If
    End Sub

    Private Sub Cargar_complementos_del_puesto()
        For Each Dr As DataRow In SQL.Tabla_de_datos("Select * From Complementos_del_puesto").Rows
            If Not IsDBNull(Dr("Ruta")) Then
                FN.Cargar_nodos(Tv_Complementos_del_puesto, Dr("Ruta"))
            End If
        Next
        Tv_Complementos_del_puesto.ExpandAll()
    End Sub

    Private Sub Tv_Complementos_del_puesto_DoubleClick(sender As Object, e As EventArgs) Handles Tv_Complementos_del_puesto.DoubleClick
        Dim Ruta As String = Tv_Complementos_del_puesto.SelectedNode.FullPath
        Dim DT As DataTable = SQL.Tabla_de_datos("Select * From Complementos_del_puesto Where Ruta='" + Ruta + "'")
        Dim Nivel() As String = Ruta.Split("\")
        Dim i As Integer = Nivel.Length
        If Ruta <> "" Then
            CP = DT.Rows(0)("Id_CP")
            Select Case i
                Case 1
                    TE_DP.Text = DT.Rows(0)("Id_departamento").ToString
                    TE_Departamento.Text = DT.Rows(0)("Departamento").ToString
                    TE_DV.Text = Nothing
                    TE_División.Text = Nothing
                    TE_AR.Text = Nothing
                    TE_Area.Text = Nothing
                Case 2
                    TE_DP.Text = DT.Rows(0)("Id_departamento").ToString
                    TE_Departamento.Text = DT.Rows(0)("Departamento").ToString
                    TE_DV.Text = DT.Rows(0)("Id_division").ToString
                    TE_División.Text = DT.Rows(0)("Division").ToString
                    TE_AR.Text = Nothing
                    TE_Area.Text = Nothing
                Case 3
                    TE_DP.Text = DT.Rows(0)("Id_departamento").ToString
                    TE_Departamento.Text = DT.Rows(0)("Departamento").ToString
                    TE_DV.Text = DT.Rows(0)("Id_division").ToString
                    TE_División.Text = DT.Rows(0)("Division").ToString
                    TE_AR.Text = DT.Rows(0)("Id_area").ToString
                    TE_Area.Text = DT.Rows(0)("Area").ToString
            End Select
        Else
            CP = Nothing
        End If
        SB_Complementos_del_puesto_Click(sender, Nothing)
        LUE_Perfil.Select()
    End Sub

    Private Sub Tv_Complementos_del_puesto_KeyDown(sender As Object, e As KeyEventArgs) Handles Tv_Complementos_del_puesto.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Space Then
            Tv_Complementos_del_puesto_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub Cargar_perfil()
        With LUE_Perfil.Properties
            .DataSource = SQL.Tabla_de_datos("Select * From Perfil_del_puesto")
            .ValueMember = "Id_perfil_del_puesto"
            .DisplayMember = "Perfil_del_puesto"
            .PopulateColumns()
            .Columns("Id_perfil_del_puesto").Visible = False
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
    End Sub

    Private Sub LUE_Perfil_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Perfil.EditValueChanged
        If LUE_Perfil.EditValue <> Nothing Then
            TE_PF.Text = LUE_Perfil.EditValue
        Else
            TE_PF.Text = Nothing
        End If
    End Sub

    Private Sub LUE_Perfil_KeyDown(sender As Object, e As KeyEventArgs) Handles LUE_Perfil.KeyDown
        If (e.KeyData = Keys.Back OrElse e.KeyData = Keys.Delete) Then
            LUE_Perfil.EditValue = Nothing
        End If
    End Sub

    Private Sub BBI_Nuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Nuevo.ItemClick
        FN.Limpiar_controles(Me) : FN.Habilitar_controles(Me)
        FN.Estado_del_menú("Guardar", BarManager)
        TE_Código_usuario.Text = Format(SQL.Nuevo_ID("Id_usuario", "Usuarios"), "00000")
        TE_Usuario.Select()
        ValidateChildren()
    End Sub

    Private Sub BBI_Guardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar.ItemClick
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Try
                If SQL.Duplicados("Usuarios", "Where Usuario='" + TE_Usuario.Text + "'") = False And Edicion = False Then
                    SQL.Insertar("Usuarios", "Id_usuario,Usuario,Contraseña,Nombres,Apellidos,No_de_carnet,No_de_celular,Correo_electronico,Imagen,RL_CP,RL_PF", SQL.Nuevo_ID("Id_Usuario", "Usuarios").ToString + "," + FN.Campo(TE_Usuario) + "," + FN.Campo(BE_Contraseña) + "," + FN.Campo(TE_Nombres) + "," + FN.Campo(TE_Apellidos) + "," + FN.Campo(TE_No_de_carnet) + "," + FN.Campo(TE_No_de_celular) + "," + FN.Campo(TE_Correo_electrónico) + ",@Imágen," + CP.ToString + "," + FN.Campo(LUE_Perfil), True, FN.Imágen_a_Bytes(PE_Imágen.Image))
                ElseIf Edicion = True Then
                    SQL.Actualizar("Usuarios", "Contraseña =" + FN.Campo(BE_Contraseña) + ", Nombres =" + FN.Campo(TE_Nombres) + ", Apellidos =" + FN.Campo(TE_Apellidos) + ", No_de_celular =" + FN.Campo(TE_No_de_celular) + ", No_de_carnet =" + FN.Campo(TE_No_de_carnet) + ", Correo_electronico =" + FN.Campo(TE_Correo_electrónico) + ", Imagen = @Imágen, RL_CP=" + CP.ToString + ", RL_PF=" + FN.Campo(LUE_Perfil), "Id_usuario=" + ID.ToString, True, FN.Imágen_a_Bytes(PE_Imágen.Image))
                Else
                    MsgBox("La empresa que intentas registrar ya existe", MsgBoxStyle.Critical, "Crear empresa")
                End If
                BBI_Cancelar_ItemClick(sender, Nothing)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Crear usuario")
            End Try
        Else
            MsgBox("Por favor valida los campos o datos obligatorios", MsgBoxStyle.Critical, "Crear usuario")
        End If
    End Sub

    Private Sub BBI_Cancelar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cancelar.ItemClick
        If Apertura = True Then
            Dispose()
        Else
            FN.Limpiar_controles(Me) : FN.Deshabilitar_controles(Me)
            ID = Nothing : CP = Nothing : Edicion = False
            DxErrorProvider.Dispose()
            FN.Estado_del_menú("Nuevo", BarManager)
        End If
    End Sub

    Private Sub BBI_Editar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Editar.ItemClick
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New Contraseña With {.Nombre_de_contraseña = "Editar usuario"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                Edicion = True
                FN.Habilitar_controles(Me)
                FN.Estado_del_menú("Guardar", BarManager)
                TE_Usuario.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub BBI_Eliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Eliminar.ItemClick
        If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim SEG As New Contraseña With {.Nombre_de_contraseña = "Eliminar usuario"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    SQL.Eliminar("Usuarios", "Id_Usuario=" + ID.ToString)
                    BBI_Cancelar_ItemClick(sender, Nothing)
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar usuario")
            End Try
        End If
    End Sub

    Private Sub BBI_Buscar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Buscar.ItemClick
        Dim BSQ As New Busqueda With {.Consulta = "Select Id_usuario,Usuario,Nombres,Apellidos,No_de_celular,No_de_carnet,Correo_electronico From Usuarios Where Id_usuario <> 0", .Columna_ID = "Id_usuario", .Alinear = "No_de_celular,No_de_carnet"}
        BSQ.ShowDialog()
        If BSQ.ID_resultado <> 0 Then ID = BSQ.ID_resultado : Datos_consulta() : BSQ.Dispose()
    End Sub

    Public Sub Datos_consulta()
        FN.Limpiar_controles(Me)
        FN.Estado_del_menú("Buscar", BarManager)
        Dim DT As DataTable = SQL.Tabla_de_datos("Select * From Usuarios Where Id_usuario=" + ID.ToString)
        TE_Código_usuario.EditValue = FN.Valor(Format(DT.Rows(0)("Id_usuario"), "00000"))
        TE_Usuario.EditValue = FN.Valor(DT.Rows(0)("Usuario"))
        BE_Contraseña.EditValue = FN.Valor(DT.Rows(0)("Contraseña"))
        TE_Nombres.EditValue = FN.Valor(DT.Rows(0)("Nombres"))
        TE_Apellidos.EditValue = FN.Valor(DT.Rows(0)("Apellidos"))
        TE_No_de_celular.EditValue = FN.Valor(DT.Rows(0)("No_de_celular"))
        TE_No_de_carnet.EditValue = FN.Valor(DT.Rows(0)("No_de_carnet"))
        TE_Correo_electrónico.EditValue = FN.Valor(DT.Rows(0)("Correo_electronico"))

        If Not IsDBNull(DT.Rows(0)("Imagen")) Then
            PE_Imágen.EditValue = FN.Bytes_a_Imágen(DirectCast(DT.Rows(0)("Imagen"), Byte()))
        End If

        CP = DT.Rows(0)("RL_CP")
        Dim DTCP As DataTable = SQL.Tabla_de_datos("Select * From Complementos_del_puesto Where Id_CP=" + CP.ToString)
        TE_DP.EditValue = FN.Valor(DTCP.Rows(0)("Id_departamento"))
        TE_Departamento.EditValue = FN.Valor(DTCP.Rows(0)("Departamento"))
        TE_DV.EditValue = FN.Valor(DTCP.Rows(0)("Id_division"))
        TE_División.EditValue = FN.Valor(DTCP.Rows(0)("Division"))
        TE_AR.EditValue = FN.Valor(DTCP.Rows(0)("Id_area"))
        TE_Area.EditValue = FN.Valor(DTCP.Rows(0)("Area"))

        LUE_Perfil.EditValue = FN.Valor(DT.Rows(0)("RL_PF"))

    End Sub

    Private Sub TE_Usuario_Validating(sender As Object, e As CancelEventArgs) Handles TE_Usuario.Validating
        FN.Validar_campos(sender, "Debes asignar un usuario", DxErrorProvider)
    End Sub

    Private Sub BE_Contraseña_Validating(sender As Object, e As CancelEventArgs) Handles BE_Contraseña.Validating
        FN.Validar_campos(sender, "Debes asignar una contraseña", DxErrorProvider)
    End Sub

    Private Sub TE_Nombres_Validating(sender As Object, e As CancelEventArgs) Handles TE_Nombres.Validating
        FN.Validar_campos(sender, "Debes asignar tus nombres", DxErrorProvider)
    End Sub

    Private Sub TE_Apellidos_Validating(sender As Object, e As CancelEventArgs) Handles TE_Apellidos.Validating
        FN.Validar_campos(sender, "Debes asignar tus apellidos", DxErrorProvider)
    End Sub

    Private Sub PE_Imágen_Validating(sender As Object, e As CancelEventArgs) Handles PE_Imágen.Validating
        FN.Validar_campos(sender, "Debes asignar un logo o imágen", DxErrorProvider)
    End Sub

    Private Sub LUE_Perfil_Validating(sender As Object, e As CancelEventArgs) Handles LUE_Perfil.Validating
        FN.Validar_campos(sender, "Debes asignar un perfil", DxErrorProvider)
    End Sub

    Private Sub Usuario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F3 And BBI_Buscar.Enabled = True Then
            BBI_Buscar_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.N And BBI_Nuevo.Enabled = True Then
            BBI_Nuevo_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.G And BBI_Guardar.Enabled = True Then
            BBI_Guardar_ItemClick(sender, Nothing)
        End If
    End Sub

End Class