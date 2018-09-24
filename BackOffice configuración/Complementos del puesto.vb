Public Class Complementos_del_puesto
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Dim Edicion As Boolean, i As Integer, Id_CP, Id_DP As Integer, Id_DV As Integer, Id_AR As Integer
    Dim Ruta As String, Codigo As String, Cd_DP As String, Cd_DV As String, Cd_AR As String, Ds_DP As String, Ds_DV As String, Ds_AR As String

    Private Sub Complementos_del_puesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos()
        FN.Estado_del_menú("Guardar y Cancelar", BarManager)
        BBI_Cancelar_ItemClick(sender, Nothing)
    End Sub

    Private Sub Cargar_datos()
        Tv_Complementos.Nodes.Clear()
        For Each Dr As DataRow In Sql.Tabla_de_datos("Select * From Complementos_del_puesto").Rows
            If Not IsDBNull(Dr("Ruta")) Then
                FN.Cargar_nodos(Tv_Complementos, Dr("Ruta"))
            End If
        Next
        Tv_Complementos.ExpandAll()
    End Sub

    Private Sub Tv_Complementos_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tv_Complementos.AfterSelect
        Ruta = e.Node.FullPath
        Dim Nivel() As String = Ruta.Split("\")
        i = Nivel.Length
    End Sub

    Private Sub Mi_Crear_principal_Click(sender As Object, e As EventArgs) Handles Mi_Crear_principal.Click
        FN.Estado_del_menú("Guardar", BarManager)
        TE_Código.Text = Format(SQL.Nuevo_ID("Id_departamento", "Complementos_del_puesto"), "00") & ".00.00"
        TE_Descripción.Select()
        TE_Descripción.ReadOnly = False
        i = 1
    End Sub

    Private Sub Mi_Crear_siguiente_Click(sender As Object, e As EventArgs) Handles Mi_Crear_siguiente.Click
        Dim DT As DataTable = SQL.Tabla_de_datos("Select * From Complementos_del_puesto Where Ruta='" & Ruta & "'")
        Select Case i
            Case 1
                Id_DP = DT.Rows(0)("Id_departamento")
                Cd_DP = DT.Rows(0)("Cd_departamento")
                Ds_DP = DT.Rows(0)("Departamento")
                Id_DV = SQL.Nuevo_ID("Id_division", "Complementos_del_puesto", "Where Id_departamento=" & Id_DP)
                TE_Código.Text = Format(Id_DP, "00") & "." & Format(Id_DV, "00") & ".00"
                TE_Descripción.Select()
                TE_Descripción.ReadOnly = False
                i = i + 1
                FN.Estado_del_menú("Guardar", BarManager)
            Case 2
                Id_DP = DT.Rows(0)("Id_departamento")
                Cd_DP = DT.Rows(0)("Cd_departamento")
                Ds_DP = DT.Rows(0)("Departamento")
                Id_DV = DT.Rows(0)("Id_division")
                Cd_DV = DT.Rows(0)("Cd_division")
                Ds_DV = DT.Rows(0)("Division")
                Id_AR = SQL.Nuevo_ID("Id_Area", "Complementos_del_puesto", "Where Id_departamento=" & Id_DP & " And Id_division=" & Id_DV)
                TE_Código.Text = Format(Id_DP, "00") & "." & Format(Id_DV, "00") & "." & Format(Id_AR, "00")
                TE_Descripción.Select()
                TE_Descripción.ReadOnly = False
                i = i + 1
                FN.Estado_del_menú("Guardar", BarManager)
        End Select
    End Sub

    Private Sub BBI_Guardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Guardar.ItemClick
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Try
                If Edicion = False Then
                    Id_CP = SQL.Nuevo_ID("Id_CP", "Complementos_del_puesto")
                    If i = 1 Then
                        Id_DP = SQL.Nuevo_ID("Id_departamento", "Complementos_del_puesto")
                        Codigo = Format(Id_DP, "00") & ".00.00"
                        SQL.Insertar("Complementos_del_puesto", "Id_CP,Id_departamento,Cd_departamento,Departamento", Id_CP.ToString + "," + Id_DP.ToString + ",'" + Codigo + "','" + TE_Descripción.Text + "'")
                    ElseIf i = 2 Then
                        Id_DV = SQL.Nuevo_ID("Id_division", "Complementos_del_puesto", "Where Id_departamento=" + Id_DP.ToString)
                        Codigo = Format(Id_DP, "00") & "." & Format(Id_DV, "00") & ".00"
                        SQL.Insertar("Complementos_del_puesto", "Id_CP,Id_departamento,Cd_departamento,Departamento,Id_division,Cd_division,Division", Id_CP.ToString + "," + Id_DP.ToString + ",'" + Cd_DP + "','" + Ds_DP + "'" + "," + Id_DV.ToString + ",'" + Codigo + "','" + TE_Descripción.Text + "'")
                    ElseIf i = 3 Then
                        Id_AR = SQL.Nuevo_ID("Id_area", "Complementos_del_puesto", "Where Id_departamento=" + Id_DP.ToString + " And Id_division=" + Id_DV.ToString)
                        Codigo = Format(Id_DP, "00") & "." & Format(Id_DV, "00") & "." & Format(Id_AR, "00")
                        SQL.Insertar("Complementos_del_puesto", "Id_CP,Id_departamento,Cd_departamento,Departamento,Id_division,Cd_division,Division,Id_Area,Cd_area,Area", Id_CP.ToString + "," + Id_DP.ToString + ",'" + Cd_DP + "','" + Ds_DP + "'" + "," + Id_DV.ToString + ",'" + Cd_DV + "','" + Ds_DV + "'" + "," + Id_AR.ToString + ",'" + Codigo + "','" + TE_Descripción.Text + "'")
                    End If
                    BBI_Cancelar_ItemClick(sender, Nothing)
                ElseIf Edicion = True Then
                    If i = 1 Then
                        SQL.Actualizar("Complementos_del_puesto", "Departamento='" + TE_Descripción.Text + "'", "Cd_departamento='" + Cd_DP.ToString + "'")
                    ElseIf i = 2 Then
                        SQL.Actualizar("Complementos_del_puesto", "Division='" + TE_Descripción.Text + "'", "Cd_departamento='" + Cd_DP.ToString + "' And Cd_division='" + Cd_DV.ToString + "'")
                    ElseIf i = 3 Then
                        SQL.Actualizar("Complementos_del_puesto", "Area='" + TE_Descripción.Text + "'", "Cd_departamento='" + Cd_DP.ToString + "' And Cd_division='" + Cd_DV.ToString + "' And Cd_area='" + Cd_AR.ToString + "'")
                    End If
                    BBI_Cancelar_ItemClick(sender, Nothing)
                End If
                Cargar_datos()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Complementos del puesto")
            End Try
        Else
            MsgBox("Por favor valida los campos o datos obligatorios", MsgBoxStyle.Critical, "Complementos del puesto")
        End If
    End Sub

    Private Sub BBI_Cancelar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cancelar.ItemClick
        FN.Limpiar_controles(Me) : FN.Deshabilitar_controles(Me)
        Edicion = False
        FN.Estado_del_menú("Nuevo", BarManager)
        DxErrorProvider.Dispose()
    End Sub

    Private Sub Mi_Editar_Click(sender As Object, e As EventArgs) Handles Mi_Editar.Click
        If MsgBox("Esta seguro de editar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Editar"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                FN.Estado_del_menú("Guardar", BarManager)
                Dim DT As DataTable = SQL.Tabla_de_datos("Select * From Complementos_del_puesto Where Ruta='" + Ruta + "'")
                Select Case i
                    Case 1
                        Cd_DP = DT.Rows(0)("Cd_departamento")
                        Ds_DP = DT.Rows(0)("Departamento")
                        TE_Código.EditValue = Cd_DP
                        TE_Descripción.EditValue = Ds_DP
                        TE_Descripción.ReadOnly = False
                        Edicion = True
                    Case 2
                        Cd_DP = DT.Rows(0)("Cd_departamento")
                        Ds_DP = DT.Rows(0)("Departamento")
                        Cd_DV = DT.Rows(0)("Cd_division")
                        Ds_DV = DT.Rows(0)("Division")
                        TE_Código.EditValue = Cd_DV
                        TE_Descripción.EditValue = Ds_DV
                        TE_Descripción.ReadOnly = False
                        Edicion = True
                    Case 3
                        Cd_DP = DT.Rows(0)("Cd_departamento")
                        Ds_DP = DT.Rows(0)("Departamento")
                        Cd_DV = DT.Rows(0)("Cd_division")
                        Ds_DV = DT.Rows(0)("Division")
                        Cd_AR = DT.Rows(0)("Cd_area")
                        Ds_AR = DT.Rows(0)("Area")
                        TE_Código.EditValue = Cd_AR
                        TE_Descripción.EditValue = Ds_AR
                        TE_Descripción.ReadOnly = False
                        Edicion = True
                End Select
            End If
        End If
    End Sub

    Private Sub Mi_Eliminar_Click(sender As Object, e As EventArgs) Handles Mi_Eliminar.Click
        If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
            SEG.ShowDialog()
            If SEG.Resultado = True Then
                Dim DT As DataTable = SQL.Tabla_de_datos("Select * From Complementos_del_puesto Where Ruta='" + Ruta + "'")
                Try
                    Select Case i
                        Case 1
                            Cd_DP = DT.Rows(0)("Cd_departamento")
                            SQL.Eliminar("Complementos_del_puesto", "Cd_departamento='" + Cd_DP.ToString + "'")
                        Case 2
                            Cd_DP = DT.Rows(0)("Cd_departamento")
                            Cd_DV = DT.Rows(0)("Cd_division")
                            SQL.Eliminar("Complementos_del_puesto", "Cd_departamento='" + Cd_DP.ToString + "' And Cd_division='" + Cd_DV.ToString + "'")
                        Case 3
                            Cd_DP = DT.Rows(0)("Cd_departamento")
                            Cd_DV = DT.Rows(0)("Cd_division")
                            Cd_AR = DT.Rows(0)("Cd_area")
                            SQL.Eliminar("Complementos_del_puesto", "Cd_departamento='" + Cd_DP.ToString + "' And Cd_division='" + Cd_DV.ToString + "' And Cd_area='" + Cd_AR.ToString + "'")
                    End Select
                    Cargar_datos()
                    BBI_Cancelar_ItemClick(sender, Nothing)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar complemento")
                End Try
            End If
        End If
    End Sub

    Private Sub Tv_Complementos_MouseClick(sender As Object, e As MouseEventArgs) Handles Tv_Complementos.MouseClick
        If e.Button = MouseButtons.Right Then
            Dim Nodo As TreeViewHitTestInfo = Tv_Complementos.HitTest(e.X, e.Y)
            Tv_Complementos.SelectedNode = Nodo.Node
        End If
    End Sub

    Private Sub TE_Descripción_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TE_Descripción.Validating
        FN.Validar_campos(sender, "Debes asignar una descripción", DxErrorProvider)
    End Sub

    Private Sub Complementos_del_puesto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Control + Keys.G Then
            BBI_Guardar_ItemClick(sender, Nothing)
        End If
    End Sub

End Class