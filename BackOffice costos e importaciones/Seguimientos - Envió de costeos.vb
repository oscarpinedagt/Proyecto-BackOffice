Public Class Seguimientos_Envió_de_costeos
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Private Sub Envió_y_seguimiento_de_costeos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos("Where Id_costeo = 0")
        DE_Fecha_inicial.DateTime = Format(Now, "01/MM/yyyy")
        DE_Fecha_final.DateTime = Format(Now, "dd/MM/yyyy")
        Cargar_empresa()
        Validar_información()
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_de_datos("Select Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Tipo_de_costeo,Estado,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Recibido,Usuario_que_recibe,Fecha_de_recepcion,Elaborado,Usuario_que_elabora,Fecha_de_elaboracion,Enviado,Usuario_que_envia,Fecha_de_envio,Archivo From Costeos " + Condicion)
        GridControl.RefreshDataSource()
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatString = "g"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Id_costeo", "Archivo"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Enviado"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Ingreso_a_bodega"
                        Dim Item As New DevExpress.XtraGrid.GridGroupSummaryItem With {.ShowInGroupColumnFooterName = "Ingresos", .SummaryType = DevExpress.Data.SummaryItemType.Count, .ShowInGroupColumnFooter = CL}
                        .GroupSummary.Add(Item)
                End Select

            Next
            .ExpandAllGroups()
            .OptionsBehavior.Editable = False
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
    End Sub

    Private Sub Cargar_empresa()

        With LUE_Empresa.Properties
            .DataSource = SQL.Tabla_de_datos("Select Empresa From Directorios_y_correos Group By Empresa")
            .ValueMember = "Empresa"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Empresa_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Empresa.EditValueChanged
        LUE_Tipo_de_mercadería.EditValue = Nothing
        LUE_Sub_empresa.EditValue = Nothing
        Cargar_datos("Where Id_costeo = 0")

        With LUE_Tipo_de_mercadería.Properties
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_mercaderia From Directorios_y_correos Where Empresa='" + LUE_Empresa.Text + "' Group By Tipo_de_mercaderia")
            .ValueMember = "Tipo_de_mercaderia"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Tipo_de_mercaderia_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Tipo_de_mercadería.EditValueChanged
        LUE_Sub_empresa.EditValue = Nothing
        Cargar_datos("Where Id_costeo = 0")

        With LUE_Sub_empresa.Properties
            .DataSource = SQL.Tabla_de_datos("Select SE,Sub_empresa From Directorios_y_correos Where Empresa='" + LUE_Empresa.Text + "' And Tipo_de_mercaderia='" + LUE_Tipo_de_mercadería.Text + "' Group By SE,Sub_empresa")
            .ValueMember = "SE"
            .DisplayMember = "Sub_empresa"
            .PopulateColumns()
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With

    End Sub

    Private Sub LUE_Sub_empresa_EditValueChanged(sender As Object, e As EventArgs) Handles LUE_Sub_empresa.EditValueChanged
        Cargar_datos("Where Id_costeo = 0")
        If LUE_Sub_empresa.EditValue <> Nothing Then
            TE_SE.Text = LUE_Sub_empresa.EditValue
        ElseIf LUE_Sub_empresa.Text <> "" Then
            TE_SE.Text = LUE_Sub_empresa.EditValue
        Else
            TE_SE.Text = Nothing
        End If
    End Sub

    Private Sub Validar_información()
        FN.Validar_campos(LUE_Empresa, "Debes asignar una empresa", DxErrorProvider)
        FN.Validar_campos(LUE_Tipo_de_mercadería, "Debes asignar un tipo de mercaderia", DxErrorProvider)
        FN.Validar_campos(LUE_Sub_empresa, "Debes asignar una sub empresa", DxErrorProvider)
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

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        ValidateChildren()
        If Not DxErrorProvider.HasErrors Then
            Dim CF As String = "Fecha_de_elaboracion"
            Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
            Dim FF As DateTime = Convert.ToDateTime(DE_Fecha_final.DateTime.ToShortDateString + " 23:59:59")
            If FF >= FI Then
                Cargar_datos("Where Empresa='" + LUE_Empresa.Text + "' And  Tipo_de_mercaderia='" + LUE_Tipo_de_mercadería.Text + "' And  SE='" + TE_SE.Text + "' And  (" + CF + " Between '" + FI.ToString + "' And '" + FF.ToString + "') Order By " + CF)
            End If
        End If
    End Sub

    Private Sub BBI_Envió_de_seguimiento_de_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Envió_de_costeos.ItemClick
        Dim Costeos As Integer = 0
        For i As Integer = 0 To GridView.DataRowCount - 1
            If CBool(GridView.GetRowCellValue(i, "DX$CheckboxSelectorColumn")) = True Then
                Costeos += 1
            End If
        Next

        If Costeos > 0 Then
            Dim MyString As New Text.StringBuilder()

            MyString.AppendLine("<html><body><tt><font face='calibri,arial narrow'>")

            MyString.AppendLine("<p>Buen día <br/><br/>")

            If Costeos = 1 Then MyString.AppendLine("Adjunto envío 01 costeo SE " + TE_SE.Text + " - " + LUE_Sub_empresa.Text + ".<br/><p/>")
            If Costeos > 1 Then MyString.AppendLine("Adjunto envío " + Costeos.ToString + " costeos SE " + TE_SE.Text + " - " + LUE_Sub_empresa.Text + ".<br/><p/>")

            MyString.AppendLine("<left><table border='1' cellpadding='0' cellspacing='1'>")
            MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr bgcolor='#AEB6BF'>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Tipo de mercadería </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='050'> SE </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='170'> Sub empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='100'> Compra </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Ingreso a bodega </th>")
            MyString.AppendLine("</tr></font></tt>")

            Dim Archivos As New List(Of String)
            For i As Integer = 0 To GridView.DataRowCount - 1
                If CBool(GridView.GetRowCellValue(i, "DX$CheckboxSelectorColumn")) = True Then
                    MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                    MyString.AppendLine("<td align='left' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Empresa") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='left' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Tipo_de_mercaderia") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + Format(GridView.GetRowCellValue(i, "SE"), "00") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='left' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Sub_empresa") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Compra") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Ingreso_a_bodega") + "&nbsp;</td>")
                    MyString.AppendLine("</tr></font></tt>")
                    Archivos.Add(GridView.GetRowCellValue(i, "Archivo"))
                End If
            Next

            MyString.AppendLine("</table></left>")

            MyString.AppendLine("""Recuerda que trabajar en equipo y confiar en la capacidad de este, forma parte del éxito.""")
            MyString.AppendLine("</font></tt></body></html>")

            Dim Dt_correo As DataTable = SQL.Tabla_de_datos("Select * From Directorios_y_correos Where Empresa+Tipo_de_mercaderia+Sub_empresa ='" & LUE_Empresa.EditValue + LUE_Tipo_de_mercadería.EditValue + LUE_Sub_empresa.Text & "'")
            FN.Enviar_correo(, Dt_correo.Rows(0)("Correo_electronico_para").ToString, Dt_correo.Rows(0)("Correo_electronico_cc").ToString, Dt_correo.Rows(0)("Correo_electronico_cco").ToString, "Envió de costeos SE " & TE_SE.Text & " - " & LUE_Sub_empresa.Text, MyString.ToString, Archivos)

            Dim Fecha As DateTime = Now
            For i As Integer = 0 To GridView.DataRowCount - 1
                If CBool(GridView.GetRowCellValue(i, "DX$CheckboxSelectorColumn")) = True Then
                    SQL.Actualizar("Costeos", "Enviado='True',Usuario_que_envia='" + UCase(Costos_e_Importaciones.Usuario) + "',Fecha_de_envio='" + Fecha.ToString + "'", "Id_costeo=" + GridView.GetRowCellValue(i, "Id_costeo").ToString)
                End If
            Next

            BBI_Generar_información_ItemClick(sender, Nothing)

        End If
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Enter Then
            GridControl_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub GridControl_DoubleClick(sender As Object, e As EventArgs) Handles GridControl.DoubleClick
        If GridView.GetRowCellValue(GridView.FocusedRowHandle, "Grupo_de_empresas") = "Grupo Automotriz" Then
            FN.Abrir_formulario(Costos_e_Importaciones, Movimientos_Elaboración_de_costeos)
            With Movimientos_Elaboración_de_costeos
                .ID = GridView.GetRowCellValue(GridView.FocusedRowHandle, "Id_costeo")
                .Datos_consulta()
            End With
        Else
            FN.Abrir_formulario(Costos_e_Importaciones, Movimientos_Recepción_de_costeos)
            With Movimientos_Recepción_de_costeos
                .ID = GridView.GetRowCellValue(GridView.FocusedRowHandle, "Id_costeo")
                .Datos_consulta()
            End With
        End If
    End Sub

End Class