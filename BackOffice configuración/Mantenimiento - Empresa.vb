Public Class Mantenimiento_Empresa
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Dim ID As Integer, Edicion As Boolean
    Private Sub Empresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_grupo_de_empresas()
        BBI_Cancelar_ItemClick(sender, Nothing)
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub Cargar_grupo_de_empresas()
        With LUE_Grupo_de_empresas.Properties
            .DataSource = SQL.Tabla_de_datos("Select * From Grupo_de_empresas")
            .ValueMember = "Id_grupo_empresas"
            .DisplayMember = "Grupo"
            .PopulateColumns()
            .Columns("Id_grupo_empresas").Visible = False
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
    End Sub

    Private Sub LUE_Grupo_de_empresas_KeyDown(sender As Object, e As KeyEventArgs) Handles LUE_Grupo_de_empresas.KeyDown
        If (e.KeyData = Keys.Back OrElse e.KeyData = Keys.Delete) Then
            LUE_Grupo_de_empresas.EditValue = Nothing
        End If
    End Sub

    Private Sub TE_Nit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TE_Nit.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "-" And sender.Text.IndexOf("-") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "-" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub BBI_Nuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Nuevo.ItemClick
        FN.Limpiar_controles(Me) : FN.Habilitar_controles(Me)
        FN.Estado_del_menú("Guardar", BarManager)
        LUE_Grupo_de_empresas.Select()
        ValidateChildren()
    End Sub

    Private Sub BBI_Guardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar.ItemClick
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Try
                If SQL.Duplicados("Empresas", "Where Nit='" + TE_Nit.Text + "'") = False And Edicion = False Then
                    SQL.Insertar("Empresas", "Id_empresa,Nit,Literales,Razon_social,Razon_comercial,Domicilio_fiscal,Logo,RL_GE", SQL.Nuevo_ID("Id_empresa", "Empresas").ToString + "," + FN.Campo(TE_Nit) + "," + FN.Campo(TE_Literales) + "," + FN.Campo(TE_Razón_social) + "," + FN.Campo(TE_Razón_comercial) + "," + FN.Campo(TE_Domicilio_fiscal) + ",@Imágen," + FN.Campo(LUE_Grupo_de_empresas), FN.Imágen_a_Bytes(PE_Imágen.Image))
                ElseIf Edicion = True Then
                    SQL.Actualizar("Empresas", "Nit=" + FN.Campo(TE_Nit) + ",Literales=" + FN.Campo(TE_Literales) + ",Razon_social=" + FN.Campo(TE_Razón_social) + ",Razon_comercial=" + FN.Campo(TE_Razón_comercial) + ",Domicilio_fiscal=" + FN.Campo(TE_Domicilio_fiscal) + ",Logo=@Imágen,RL_GE=" + FN.Campo(LUE_Grupo_de_empresas), "Id_empresa=" + ID.ToString, FN.Imágen_a_Bytes(PE_Imágen.Image))
                Else
                    MsgBox("La empresa que intentas registrar ya existe", MsgBoxStyle.Critical, "Crear empresa")
                End If
                BBI_Cancelar_ItemClick(sender, Nothing)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Crear empresa")
            End Try
        Else
            MsgBox("Por favor valida los campos o datos obligatorios", MsgBoxStyle.Critical, "Crear empresa")
        End If
    End Sub

    Private Sub BBI_Cancelar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cancelar.ItemClick
        FN.Limpiar_controles(Me) : FN.Deshabilitar_controles(Me)
        ID = Nothing : Edicion = False
        DxErrorProvider.Dispose()
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub BBI_Editar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Editar.ItemClick
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Editar empresa"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                Edicion = True
                FN.Habilitar_controles(Me)
                FN.Estado_del_menú("Guardar", BarManager)
                TE_Nit.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub BBI_Eliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Eliminar.ItemClick
        If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar empresa"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    SQL.Eliminar("Empresas", "Id_empresa=" + ID.ToString)
                    BBI_Cancelar_ItemClick(sender, Nothing)
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar empresa")
            End Try
        End If
    End Sub

    Private Sub BBI_Buscar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Buscar.ItemClick
        Dim BSQ As New BackOffice_servicios.Busqueda With {.Consulta = "Select Id_empresa,Nit,Razon_social,Razon_comercial,Domicilio_fiscal From Empresas", .Columna_ID = "Id_empresa", .Alinear = "Nit"}
        BSQ.ShowDialog()
        If BSQ.ID_resultado <> 0 Then ID = BSQ.ID_resultado : Datos_consulta() : BSQ.Dispose()
    End Sub

    Private Sub Datos_consulta()
        FN.Limpiar_controles(Me)
        FN.Estado_del_menú("Buscar", BarManager)
        Dim DT As DataTable = SQL.Tabla_de_datos("Select * From Empresas Where Id_empresa=" + ID.ToString)
        LUE_Grupo_de_empresas.EditValue = FN.Valor(DT.Rows(0)("RL_GE"))
        TE_Nit.EditValue = FN.Valor(DT.Rows(0)("Nit"))
        TE_Literales.EditValue = FN.Valor(DT.Rows(0)("Literales"))
        TE_Razón_social.EditValue = FN.Valor(DT.Rows(0)("Razon_social"))
        TE_Razón_comercial.EditValue = FN.Valor(DT.Rows(0)("Razon_comercial"))
        TE_Domicilio_fiscal.EditValue = FN.Valor(DT.Rows(0)("Domicilio_fiscal"))

        If Not IsDBNull(DT.Rows(0)("Logo")) Then
            PE_Imágen.EditValue = FN.Bytes_a_Imágen(DirectCast(DT.Rows(0)("Logo"), Byte()))
        End If

    End Sub

    Private Sub LUE_Grupo_de_empresas_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Grupo_de_empresas.Validating
        FN.Validar_campos(sender, "Debes asignar un grupo de empresas", DxErrorProvider)
    End Sub

    Private Sub TE_Nit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Nit.Validating
        FN.Validar_campos(sender, "Debes ingresar un número de Nit", DxErrorProvider)
    End Sub

    Private Sub TE_Razón_comercial_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Razón_comercial.Validating
        FN.Validar_campos(sender, "Debes ingresar la razón comercial de la empresa", DxErrorProvider)
    End Sub

    Private Sub PE_Imágen_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PE_Imágen.Validating
        FN.Validar_campos(sender, "Debes asignar un logo o imágen", DxErrorProvider)
    End Sub

    Private Sub Empresa_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F3 And BBI_Buscar.Enabled = True Then
            BBI_Buscar_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.N And BBI_Nuevo.Enabled = True Then
            BBI_Nuevo_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.G And BBI_Guardar.Enabled = True Then
            BBI_Guardar_ItemClick(sender, Nothing)
        End If
    End Sub

End Class