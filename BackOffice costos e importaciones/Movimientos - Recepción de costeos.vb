Public Class Movimientos_Recepción_de_costeos
    Dim SQl As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Dim Edicion As Boolean, Editables As String
    Public Property ID As Integer

    Private Sub Recepción_de_costeos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        BBI_Cancelar_ItemClick(sender, Nothing)
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub Cargar_datos()

        With LUE_Empresa.Properties
            .DataSource = SQl.Tabla_de_datos("Select Razon_comercial From Empresas Where RL_GE = '" + SQl.Extraer_informacion_de_columna("Id_grupo_empresas", "Grupo_de_empresas", "Where Grupo = 'Grupo Tecun' ") + "' Group By Razon_comercial")
            .ValueMember = "Razon_comercial"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Tipo_de_costeo.Properties
            .DataSource = SQl.Tabla_de_datos("Select Tipo_de_costeo From Tipos_de_costeo")
            .ValueMember = "Tipo_de_costeo"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Estado.Properties
            .DataSource = SQl.Tabla_de_datos("Select Estado,Información From Estados")
            .ValueMember = "Estado"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Tipo_de_importación.Properties
            .DataSource = SQl.Tabla_de_datos("Select Tipo_de_importacion From Tipos_de_importacion")
            .ValueMember = "Tipo_de_importacion"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

        With LUE_Costeo_asignado_a.Properties
            .DataSource = SQl.Tabla_de_datos("Select a.Nombres+' '+a.Apellidos As Nombre From Usuarios a,Complementos_del_puesto b Where a.Id_usuario<>0 AND a.RL_CP=b.Id_CP AND b.Division='Costos e Importaciones'")
            .ValueMember = "Nombre"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Empresa_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Empresa.EditValueChanged

        LUE_Tipo_de_mercadería.EditValue = Nothing
        LUE_Sub_empresa.EditValue = Nothing

        With LUE_Tipo_de_mercadería.Properties
            .DataSource = SQl.Tabla_de_datos("Select Tipo_de_mercaderia From Directorios_y_correos Where Empresa='" + LUE_Empresa.EditValue + "' Group By Tipo_de_mercaderia")
            .ValueMember = "Tipo_de_mercaderia"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Tipo_de_mercadería_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Tipo_de_mercadería.EditValueChanged

        LUE_Sub_empresa.EditValue = Nothing

        With LUE_Sub_empresa.Properties
            .DataSource = SQl.Tabla_de_datos("Select SE,Sub_empresa From Directorios_y_correos Where Empresa='" + LUE_Empresa.EditValue + "' And Tipo_de_mercaderia='" + LUE_Tipo_de_mercadería.EditValue + "' Group By SE,Sub_empresa")
            .ValueMember = "SE"
            .DisplayMember = "Sub_empresa"
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Sub_empresa_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Sub_empresa.EditValueChanged
        If LUE_Sub_empresa.EditValue <> Nothing Then
            TE_SE.Text = LUE_Sub_empresa.EditValue
        ElseIf LUE_Sub_empresa.Text <> "" Then
            TE_SE.Text = LUE_Sub_empresa.EditValue
        Else
            TE_SE.Text = Nothing
        End If
    End Sub

    Private Sub LUE_Empresa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Empresa.Validating
        FN.Validar_campos(LUE_Empresa, "Debes asignar una empresa", DxErrorProvider)
    End Sub

    Private Sub LUE_Tipo_de_mercaderia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Tipo_de_mercadería.Validating
        FN.Validar_campos(LUE_Tipo_de_mercadería, "Debes asignar un tipo de mercaderia", DxErrorProvider)
    End Sub

    Private Sub LUE_Sub_empresa_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LUE_Sub_empresa.Validating
        FN.Validar_campos(LUE_Sub_empresa, "Debes asignar una sub empresa", DxErrorProvider)
    End Sub

    Private Sub TE_Ingreso_a_bodega_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Ingreso_a_bodega.Validating
        FN.Validar_campos(TE_Ingreso_a_bodega, "Debes ingresar un número de ingreso a bodega", DxErrorProvider)
    End Sub

    Private Sub TE_Fecha_de_ingreso_a_bodega_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Fecha_de_ingreso_a_bodega.Validating
        FN.Validar_campos(TE_Fecha_de_ingreso_a_bodega, "Debes ingresar una fecha", DxErrorProvider)
        FN.Validar_fechas(sender, e)
    End Sub

    Private Sub Fecha_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Fecha_de_Guia_BL_Carta_de_porte.Validating, TE_Fecha_de_arribo.Validating, TE_Fecha_de_Dua_Fauca_Face.Validating, TE_Fecha_de_recepción.Validating
        FN.Validar_fechas(sender, e)
    End Sub

    Private Sub CK_Recibido_CheckedChanged(sender As Object, e As EventArgs) Handles CK_Recibido.CheckedChanged
        If CK_Recibido.Checked = True Then
            TE_Usuario_que_recibe.EditValue = Costos_e_Importaciones.Usuario
            TE_Fecha_de_recepción.EditValue = Now
            LUE_Costeo_asignado_a.Select()
        Else
            TE_Usuario_que_recibe.EditValue = Nothing
            TE_Fecha_de_recepción.EditValue = Nothing
            LUE_Costeo_asignado_a.EditValue = Nothing
        End If
        ValidateChildren()
    End Sub

    Private Sub GC_Comentarios_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Comentarios.CustomButtonClick
        Select Case e.Button.Properties.Caption

            Case "Nuevo comentario"

                Dim MyString As New Text.StringBuilder()
                Dim MSG As New BackOffice_servicios.Comentario
                MSG.ShowDialog()
                If MSG.Guardar = True Then
                    If RTBX_Comentarios.TextLength > 0 Then
                        MyString.AppendLine(RTBX_Comentarios.Text)
                        MyString.AppendLine(StrDup(165, "-"))
                    End If
                    MyString.AppendLine("[ " & UCase(Costos_e_Importaciones.Usuario) & " - " & Now & " - " & MSG.Tipo_de_comentario & " ]")
                    MyString.AppendLine(MSG.Comentario)
                    RTBX_Comentarios.Text = Regex.Replace(MyString.ToString, "^\r|\n\r|\n$", "")

                    If ID <> 0 Then
                        SQl.Actualizar("Costeos", "Comentarios='" + RTBX_Comentarios.Text + "'", "Id_costeo=" + ID.ToString)
                    End If
                End If
                MSG.Dispose()

            Case "Envió de comentarios"

                Dim MyString As New Text.StringBuilder()
                MyString.AppendLine("<html><body><tt><font face='calibri,arial narrow'>")
                MyString.AppendLine("<p>Buen día <br/><br/>Envió comentarios según ingreso a bodega " & TE_Ingreso_a_bodega.Text & "<br/></p>")

                For i As Integer = 0 To RTBX_Comentarios.Lines.Length - 1
                    MyString.AppendLine("<tt><font face='calibri,arial narrow'>" + RTBX_Comentarios.Lines(i) + "</font></tt><br/>")
                Next

                MyString.AppendLine("</font></tt></body></html>")
                FN.Enviar_correo(Asunto:="Envió de comentarios según ingreso a bodega " & TE_Ingreso_a_bodega.Text, Cuerpo_del_correo:=MyString.ToString)

        End Select

    End Sub

    Private Sub Limpiar_controles_datos_de_importación()
        If CK_Datos_de_importación_multiple.Checked = False Then
            FN.Limpiar_controles(GC_Datos_de_importación)
        End If
    End Sub
    Private Sub Limpiar_controles_datos_de_recepción()
        If CK_Datos_de_recepción_multiple.Checked = False Then
            FN.Limpiar_controles(GC_Datos_de_recepción)
        End If
    End Sub

    Private Sub BBI_Nuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Nuevo.ItemClick
        FN.Limpiar_controles(GC_Datos_de_ingreso_a_bodega) : FN.Habilitar_controles(GC_Datos_de_ingreso_a_bodega)
        Limpiar_controles_datos_de_importación() : FN.Habilitar_controles(GC_Datos_de_importación)
        Limpiar_controles_datos_de_recepción() : FN.Habilitar_controles(GC_Datos_de_recepción)
        FN.Limpiar_controles(GC_Comentarios) : GC_Comentarios.CustomHeaderButtons("Nuevo comentario").Properties.Enabled = True : GC_Comentarios.CustomHeaderButtons("Envió de comentarios").Properties.Enabled = True
        FN.Estado_del_menú("Guardar", BarManager)
        LUE_Empresa.Focus()
        ValidateChildren()
    End Sub

    Private Sub BBI_Guardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar.ItemClick
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Try
                If SQl.Duplicados("Costeos", "Where Empresa+'-'+IsNull(Compra,'')+'-'+IsNull(Ingreso_a_bodega,'')='" + LUE_Empresa.EditValue + "-" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue + "'") = False And Edicion = False Then

                    SQl.Insertar("Costeos", "Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Tipo_de_importacion,[Guia|BL|Carta_de_porte],[Fecha_de_Guia|BL|Carta_de_porte],Fecha_de_arribo,[Dua|Fauca|Face],[Fecha_de_Dua|Fauca|Face],Recibido,Usuario_que_recibe,Fecha_de_recepcion,Costeo_asignado_a,Comentarios", SQl.Nuevo_ID("Id_costeo", "Costeos").ToString + ",'" + SQl.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b", "Where a.Razon_comercial='" + LUE_Empresa.Text + "' And a.RL_GE=b.Id_grupo_empresas") + "'," + FN.Campo(LUE_Empresa) + "," + FN.Campo(LUE_Tipo_de_mercadería) + "," + FN.Campo(TE_SE) + ",'" + SQl.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE='" + TE_SE.Text + "'") + "'," + FN.Campo(TE_Compra) + "," + FN.Campo(TE_Ingreso_a_bodega) + "," + FN.Campo(TE_Fecha_de_ingreso_a_bodega) + "," + FN.Campo(LUE_Tipo_de_costeo) + "," + FN.Campo(LUE_Estado) + "," + FN.Campo(LUE_Tipo_de_importación) + "," + FN.Campo(TE_Guia_BL_Carta_de_porte) + "," + FN.Campo(TE_Fecha_de_Guia_BL_Carta_de_porte) + "," + FN.Campo(TE_Fecha_de_arribo) + "," + FN.Campo(TE_Dua_Fauca_Face) + "," + FN.Campo(TE_Fecha_de_Dua_Fauca_Face) + ",'" + CK_Recibido.Checked.ToString + "'," + FN.Campo(TE_Usuario_que_recibe) + "," + FN.Campo(TE_Fecha_de_recepción) + "," + FN.Campo(LUE_Costeo_asignado_a) + ",'" + RTBX_Comentarios.Text + "'")

                ElseIf Edicion = True And LUE_Estado.Text <> "Anulado" Then
                    If Editables = LUE_Empresa.EditValue + "-" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue Then

                        SQl.Actualizar("Costeos", "Grupo_de_empresas='" + SQl.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b ", "Where a.Razon_comercial='" + LUE_Empresa.EditValue + "' And a.RL_GE=b.Id_grupo_empresas") + "',Empresa=" + FN.Campo(LUE_Empresa) + ",Tipo_de_mercaderia=" + FN.Campo(LUE_Tipo_de_mercadería) + ",SE=" + FN.Campo(TE_SE) + ",Sub_empresa='" + SQl.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE='" + TE_SE.EditValue.ToString + "'") + "',Compra=" + FN.Campo(TE_Compra) + ",Ingreso_a_bodega=" + FN.Campo(TE_Ingreso_a_bodega) + ",Fecha_de_ingreso_a_bodega=" + FN.Campo(TE_Fecha_de_ingreso_a_bodega) + ",Tipo_de_costeo=" + FN.Campo(LUE_Tipo_de_costeo) + ",Estado=" + FN.Campo(LUE_Estado) + ",Tipo_de_importacion=" + FN.Campo(LUE_Tipo_de_importación) + ",[Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Guia_BL_Carta_de_porte) + ",[Fecha_de_Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Fecha_de_Guia_BL_Carta_de_porte) + ",Fecha_de_arribo=" + FN.Campo(TE_Fecha_de_arribo) + ",[Dua|Fauca|Face]=" + FN.Campo(TE_Dua_Fauca_Face) + ",[Fecha_de_Dua|Fauca|Face]=" + FN.Campo(TE_Fecha_de_Dua_Fauca_Face) + ",Recibido='" + CK_Recibido.Checked.ToString + "',Usuario_que_recibe=" + FN.Campo(TE_Usuario_que_recibe) + ",Fecha_de_recepcion=" + FN.Campo(TE_Fecha_de_recepción) + ",Costeo_asignado_a=" + FN.Campo(LUE_Costeo_asignado_a) + ",Comentarios='" + RTBX_Comentarios.Text + "'", "Id_costeo=" + ID.ToString)

                    Else
                        If SQl.Duplicados("Costeos", "Where Empresa+'-'+IsNull(Compra,'')+'-'+IsNull(Ingreso_a_bodega,'')='" + LUE_Empresa.EditValue + "-" + TE_Compra.EditValue + "-" + TE_Ingreso_a_bodega.EditValue + "'") = False Then

                            SQl.Actualizar("Costeos", "Grupo_de_empresas='" + SQl.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b ", "Where a.Razon_comercial='" + LUE_Empresa.EditValue + "' And a.RL_GE=b.Id_grupo_empresas") + "',Empresa=" + FN.Campo(LUE_Empresa) + ",Tipo_de_mercaderia=" + FN.Campo(LUE_Tipo_de_mercadería) + ",SE=" + FN.Campo(TE_SE) + ",Sub_empresa='" + SQl.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE='" + TE_SE.EditValue.ToString + "'") + "',Compra=" + FN.Campo(TE_Compra) + ",Ingreso_a_bodega=" + FN.Campo(TE_Ingreso_a_bodega) + ",Fecha_de_ingreso_a_bodega=" + FN.Campo(TE_Fecha_de_ingreso_a_bodega) + ",Tipo_de_costeo=" + FN.Campo(LUE_Tipo_de_costeo) + ",Estado=" + FN.Campo(LUE_Estado) + ",Tipo_de_importacion=" + FN.Campo(LUE_Tipo_de_importación) + ",[Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Guia_BL_Carta_de_porte) + ",[Fecha_de_Guia|BL|Carta_de_porte]=" + FN.Campo(TE_Fecha_de_Guia_BL_Carta_de_porte) + ",Fecha_de_arribo=" + FN.Campo(TE_Fecha_de_arribo) + ",[Dua|Fauca|Face]=" + FN.Campo(TE_Dua_Fauca_Face) + ",[Fecha_de_Dua|Fauca|Face]=" + FN.Campo(TE_Fecha_de_Dua_Fauca_Face) + ",Recibido='" + CK_Recibido.Checked.ToString + "',Usuario_que_recibe=" + FN.Campo(TE_Usuario_que_recibe) + ",Fecha_de_recepcion=" + FN.Campo(TE_Fecha_de_recepción) + ",Costeo_asignado_a=" + FN.Campo(LUE_Costeo_asignado_a) + ",Comentarios='" + RTBX_Comentarios.Text + "'", "Id_costeo=" + ID.ToString)

                        Else
                            MsgBox("El ingreso que intentas actualizar ya existe", MsgBoxStyle.Critical, "Recepción de costeos")
                        End If
                    End If
                ElseIf Edicion = True And LUE_Estado.EditValue = "Anulado" Then
                    SQl.Actualizar("Costeos", "Estado='" + LUE_Estado.EditValue + "',Recibido='False',Usuario_que_recibe=NULL,Fecha_de_recepcion=NULL,Costeo_asignado_a=NULL,Elaborado='False',Fecha_de_elaboracion=NULL,Usuario_que_elabora=NULL,Archivo=NULL", "Id_costeo=" + ID.ToString)
                Else
                    MsgBox("El ingreso que intentas registrar ya existe", MsgBoxStyle.Critical, "Recepción de costeos")
                End If
                BBI_Cancelar_ItemClick(sender, Nothing)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Recepción de costeos")
            End Try
        Else
            MsgBox("Por favor valida los campos o datos obligatorios", MsgBoxStyle.Critical, "Recepción de costeos")
        End If
    End Sub

    Private Sub BBI_Cancelar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cancelar.ItemClick
        FN.Limpiar_controles(GC_Datos_de_ingreso_a_bodega) : FN.Deshabilitar_controles(GC_Datos_de_ingreso_a_bodega)
        Limpiar_controles_datos_de_importación() : FN.Deshabilitar_controles(GC_Datos_de_importación)
        Limpiar_controles_datos_de_recepción() : FN.Deshabilitar_controles(GC_Datos_de_recepción)
        FN.Limpiar_controles(GC_Comentarios) : GC_Comentarios.CustomHeaderButtons("Nuevo comentario").Properties.Enabled = False : GC_Comentarios.CustomHeaderButtons("Envió de comentarios").Properties.Enabled = False
        ID = Nothing : Edicion = False
        ValidateChildren()
        FN.Estado_del_menú("Nuevo", BarManager)
    End Sub

    Private Sub BBI_Editar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Editar.ItemClick
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Editar"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                Edicion = True
                FN.Habilitar_controles(GC_Datos_de_ingreso_a_bodega)
                FN.Habilitar_controles(GC_Datos_de_importación)
                FN.Habilitar_controles(GC_Datos_de_recepción)
                GC_Comentarios.CustomHeaderButtons("Nuevo comentario").Properties.Enabled = True : GC_Comentarios.CustomHeaderButtons("Envió de comentarios").Properties.Enabled = True
                FN.Estado_del_menú("Guardar", BarManager)
            End If
        End If
    End Sub

    Private Sub BBI_Eliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Eliminar.ItemClick
        If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    SQl.Eliminar("Costeos", "Id_costeo=" + ID.ToString)
                    BBI_Cancelar_ItemClick(sender, Nothing)
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar usuario")
            End Try
        End If
    End Sub

    Private Sub BBI_Buscar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Buscar.ItemClick
        Dim BSQ As New BackOffice_servicios.Busqueda With {.Consulta = "Select Id_costeo,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Tipo_de_importacion,[Guia|BL|Carta_de_porte],[Dua|Fauca|Face],Usuario_que_recibe,Fecha_de_recepcion,Costeo_asignado_a,Dif_Ing_Rec From Costeos Where Grupo_de_empresas='Grupo Tecun'", .Columna_ID = "Id_costeo", .Alinear = ""}
        BSQ.ShowDialog()
        If BSQ.ID_resultado <> 0 Then ID = BSQ.ID_resultado : Datos_consulta() : BSQ.Dispose()
    End Sub

    Public Sub Datos_consulta()
        FN.Estado_del_menú("Buscar", BarManager)
        Dim Dt As DataTable = SQl.Tabla_de_datos("Select * From Costeos Where Id_costeo=" + ID.ToString)

        GC_Comentarios.CustomHeaderButtons("Nuevo comentario").Properties.Enabled = True
        GC_Comentarios.CustomHeaderButtons("Envió de comentarios").Properties.Enabled = True

        'Datos de ingreso a bodega
        FN.Limpiar_controles(GC_Datos_de_ingreso_a_bodega)
        Editables = Dt.Rows(0)("Empresa").ToString + Dt.Rows(0)("Compra").ToString + Dt.Rows(0)("Ingreso_a_bodega").ToString
        LUE_Empresa.EditValue = FN.Valor(Dt.Rows(0)("Empresa"))
        LUE_Tipo_de_mercadería.EditValue = FN.Valor(Dt.Rows(0)("Tipo_de_mercaderia"))
        LUE_Sub_empresa.EditValue = FN.Valor(Dt.Rows(0)("SE"))
        TE_Compra.EditValue = FN.Valor(Dt.Rows(0)("Compra"))
        TE_Ingreso_a_bodega.EditValue = FN.Valor(Dt.Rows(0)("Ingreso_a_bodega"))
        TE_Fecha_de_ingreso_a_bodega.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_ingreso_a_bodega"))
        LUE_Tipo_de_costeo.EditValue = FN.Valor(Dt.Rows(0)("Tipo_de_costeo"))
        LUE_Estado.EditValue = FN.Valor(Dt.Rows(0)("Estado"))

        'Datos de importación
        If CK_Datos_de_importación_multiple.Checked = True Then
            Limpiar_controles_datos_de_importación()
        Else
            LUE_Tipo_de_importación.EditValue = FN.Valor(Dt.Rows(0)("Tipo_de_importacion"))
            TE_Guia_BL_Carta_de_porte.EditValue = FN.Valor(Dt.Rows(0)("Guia|BL|Carta_de_porte"))
            TE_Fecha_de_Guia_BL_Carta_de_porte.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_Guia|BL|Carta_de_porte"))
            TE_Fecha_de_arribo.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_arribo"))
            TE_Dua_Fauca_Face.EditValue = FN.Valor(Dt.Rows(0)("Dua|Fauca|Face"))
            TE_Fecha_de_Dua_Fauca_Face.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_Dua|Fauca|Face"))
        End If

        'Datos de recepción
        If CK_Datos_de_recepción_multiple.Checked = True Then
            Limpiar_controles_datos_de_recepción()
        Else
            RemoveHandler CK_Recibido.CheckedChanged, AddressOf CK_Recibido_CheckedChanged
            CK_Recibido.EditValue = FN.Valor(Dt.Rows(0)("Recibido"))
            TE_Usuario_que_recibe.EditValue = FN.Valor(Dt.Rows(0)("Usuario_que_recibe"))
            TE_Fecha_de_recepción.EditValue = FN.Valor(Dt.Rows(0)("Fecha_de_recepcion"))
            LUE_Costeo_asignado_a.EditValue = FN.Valor(Dt.Rows(0)("Costeo_asignado_a"))
            AddHandler CK_Recibido.CheckedChanged, AddressOf CK_Recibido_CheckedChanged
        End If

        'Comentarios
        FN.Limpiar_controles(GC_Comentarios)
        RTBX_Comentarios.Text = Dt.Rows(0)("Comentarios").ToString

    End Sub

    Private Sub Recepción_de_costeos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F3 And BBI_Buscar.Enabled = True Then
            BBI_Buscar_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.N And BBI_Nuevo.Enabled = True Then
            BBI_Nuevo_ItemClick(sender, Nothing)
        ElseIf e.KeyData = Keys.Control + Keys.G And BBI_Guardar.Enabled = True Then
            BBI_Guardar_ItemClick(sender, Nothing)
        End If
    End Sub

End Class