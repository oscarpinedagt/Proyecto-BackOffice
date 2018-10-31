Public Class Seguimientos_Control_de_IPRIMA
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub Seguimientos_Control_de_Iprima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos("Where Id_iprima = 0")
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos("Select * From Control_de_iprima " + Condicion)
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                    CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    Select Case CL.FieldName
                        Case "Fecha_DUA", "Fecha_formulario_IPRIMA"
                            CL.DisplayFormat.FormatString = "d"
                    End Select
                End If

                Select Case CL.FieldName
                    Case "Id_iprima"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Inventario", "DUA"
                        CL.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                End Select

                Select Case CL.FieldName
                    Case "Formulario_IPRIMA", "No_de_acceso_formulario_IPRIMA", "No_de_contingencia_formulario_IPRIMA"
                        CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End Select

                Select Case CL.FieldName
                    Case "Fecha_de_inicio_de_tramite", "Fecha_en_que_finaliza_el_tramite", "Fecha_de_retiro", "Fecha_formulario_IPRIMA", "Formulario_IPRIMA", "Valor_IPRIMA_SAT", "No_de_acceso_formulario_IPRIMA", "No_de_contingencia_formulario_IPRIMA", "Fecha_de_solicitud_de_pago", "Fecha_de_confirmación_de_pago"
                        CL.AppearanceCell.BackColor = Color.FromArgb(213, 245, 227)
                End Select

                Select Case CL.FieldName
                    Case "Empresa", "Pedido", "Factura", "Inventario", "Linea", "Color", "Motor", "Chasis", "Fecha_DUA", "Régimen", "DUA", "CIF_DUA", "TC_DUA", "Valor_IPRIMA_sistema", "%_IPRIMA_sobre_valor_CIF_DUA", "Tiempo_de_tramite_en_HRS", "Documentos", "Tiempo_de_pago_en_HRS"
                        CL.OptionsColumn.ReadOnly = True
                End Select

                Select Case CL.FieldName
                    Case "Empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "CIF_DUA", "Valor_IPRIMA_sistema", "Valor_IPRIMA_SAT"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

            Next
            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With
        Columna_fecha_y_hora()
    End Sub

    Private Sub Columna_fecha_y_hora()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "g"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha_de_inicio_de_tramite").ColumnEdit = Item
        GridView.Columns("Fecha_en_que_finaliza_el_tramite").ColumnEdit = Item
        GridView.Columns("Fecha_de_retiro").ColumnEdit = Item
        GridView.Columns("Fecha_de_solicitud_de_pago").ColumnEdit = Item
        GridView.Columns("Fecha_de_confirmación_de_pago").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "d"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha_formulario_IPRIMA").ColumnEdit = Item
    End Sub

    Private Sub Formato_condicional()
        Dim Condición As DevExpress.XtraGrid.GridFormatRule = GridView.FormatRules.AddUniqueDuplicateRule(GridView.Columns("DUA"), New DevExpress.Utils.AppearanceDefault() With {.BackColor = Color.FromArgb(196, 215, 155), .FontStyleDelta = FontStyle.Bold}, DevExpress.XtraEditors.FormatConditionUniqueDuplicateType.Duplicate)
        Condición.ApplyToRow = True
    End Sub

    Private Sub BBI_Disponibles_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Disponibles.ItemClick
        GridView.FormatRules.Clear()
        GridView.OptionsSelection.MultiSelect = False
        Cargar_datos("Where ((Documentos is null or Documentos = '') And (Formulario_IPRIMA is null or Formulario_IPRIMA = '')) or ((Documentos is null or Documentos = '') And (Formulario_IPRIMA is not null or Formulario_IPRIMA <> '')) Order By Fecha_DUA")
    End Sub

    Private Sub BBI_Solicitados_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Solicitados.ItemClick
        Formato_condicional()
        GridView.OptionsSelection.MultiSelect = True
        GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Cargar_datos("Where (Documentos is not null or Documentos <> '') And (Fecha_de_confirmación_de_pago is null or Fecha_de_confirmación_de_pago = '')  Order By DUA,Documentos")
    End Sub

    Private Sub BBI_Liquidados_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Liquidados.ItemClick
        GridView.FormatRules.Clear()
        GridView.OptionsSelection.MultiSelect = False
        Cargar_datos("Where (Formulario_IPRIMA is not null or Formulario_IPRIMA <> '') And (Documentos is not null or Documentos <> '') And (Fecha_de_confirmación_de_pago is not null or Fecha_de_confirmación_de_pago <> '') Order By DUA,Documentos")
    End Sub

    Private Sub BBI_Cargar_reporte_de_polizas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cargar_reporte_de_polizas.ItemClick
        Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx;*.xlsm"}
        If File.ShowDialog() = DialogResult.OK Then

            Dim Dt_Uniauto As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Uniauto$]")
            For Each Dr As DataRow In Dt_Uniauto.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+Chasis ='UNIAUTO, S.A." + Dr("Chasis").ToString + "'") = False Then
                    SQL.Insertar("Control_de_iprima", "Id_iprima,Empresa,Pedido,Factura,Inventario,Linea,Color,Motor,Chasis,Fecha_DUA,Régimen,DUA,CIF_DUA,TC_DUA,Valor_IPRIMA_sistema", SQL.Nuevo_ID("Id_iprima", "Control_de_iprima").ToString + ",'UNIAUTO, S.A.'," + FN.Campo_tabla(Dr("Pedido")) + "," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Inventario")) + "," + FN.Campo_tabla(Dr("Linea")) + "," + FN.Campo_tabla(Dr("Color")) + "," + FN.Campo_tabla(Dr("Motor")) + "," + FN.Campo_tabla(Dr("Chasis")) + "," + FN.Campo_tabla(FN.Quitar_espacios_innecesarios(Dr("Fecha"))) + "," + FN.Campo_tabla(Dr("Tipo")) + "," + FN.Campo_tabla(Dr("Poliza")) + "," + FN.Campo_tabla(Dr("CIF")) + "," + FN.Campo_tabla(Dr("TC_Poliza")) + "," + FN.Campo_tabla(Dr("IPRIMA")))
                End If
            Next

            Dim Dt_Didea As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Didea$]")
            For Each Dr As DataRow In Dt_Didea.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+Chasis ='DIDEA, S.A." + Dr("Chasis").ToString + "'") = False Then
                    SQL.Insertar("Control_de_iprima", "Id_iprima,Empresa,Pedido,Factura,Inventario,Linea,Color,Motor,Chasis,Fecha_DUA,Régimen,DUA,CIF_DUA,TC_DUA,Valor_IPRIMA_sistema", SQL.Nuevo_ID("Id_iprima", "Control_de_iprima").ToString + ",'DIDEA, S.A.'," + FN.Campo_tabla(Dr("Pedido")) + "," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Inventario")) + "," + FN.Campo_tabla(Dr("Linea")) + "," + FN.Campo_tabla(Dr("Color")) + "," + FN.Campo_tabla(Dr("Motor")) + "," + FN.Campo_tabla(Dr("Chasis")) + "," + FN.Campo_tabla(FN.Quitar_espacios_innecesarios(Dr("Fecha"))) + "," + FN.Campo_tabla(Dr("Tipo")) + "," + FN.Campo_tabla(Dr("Poliza")) + "," + FN.Campo_tabla(Dr("CIF")) + "," + FN.Campo_tabla(Dr("TC_Poliza")) + "," + FN.Campo_tabla(Dr("IPRIMA")))
                End If
            Next

            Dim Dt_Autos_Europa As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Autos Europa$]")
            For Each Dr As DataRow In Dt_Autos_Europa.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+Chasis ='AUTOS EUROPA, S.A." + Dr("Chasis").ToString + "'") = False Then
                    SQL.Insertar("Control_de_iprima", "Id_iprima,Empresa,Pedido,Factura,Inventario,Linea,Color,Motor,Chasis,Fecha_DUA,Régimen,DUA,CIF_DUA,TC_DUA,Valor_IPRIMA_sistema", SQL.Nuevo_ID("Id_iprima", "Control_de_iprima").ToString + ",'AUTOS EUROPA, S.A.'," + FN.Campo_tabla(Dr("Pedido")) + "," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Inventario")) + "," + FN.Campo_tabla(Dr("Linea")) + "," + FN.Campo_tabla(Dr("Color")) + "," + FN.Campo_tabla(Dr("Motor")) + "," + FN.Campo_tabla(Dr("Chasis")) + "," + FN.Campo_tabla(FN.Quitar_espacios_innecesarios(Dr("Fecha"))) + "," + FN.Campo_tabla(Dr("Tipo")) + "," + FN.Campo_tabla(Dr("Poliza")) + "," + FN.Campo_tabla(Dr("CIF")) + "," + FN.Campo_tabla(Dr("TC_Poliza")) + "," + FN.Campo_tabla(Dr("IPRIMA")))
                End If
            Next

            BBI_Disponibles_ItemClick(Nothing, Nothing)

        End If
    End Sub

    Private Sub BBI_Cargar_facturación_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cargar_facturación.ItemClick
        Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx;*.xlsm"}
        If File.ShowDialog() = DialogResult.OK Then

            Dim Dt_Uniauto As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Uniauto$]")
            For Each Dr As DataRow In Dt_Uniauto.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+Chasis+DUA ='UNIAUTO, S.A." + Dr("Chasis").ToString + Dr("Poliza").ToString + "'") = True Then
                    If SQL.Duplicados("Facturación_vehiculos", "Where Chasis+DUA+Factura ='" + Dr("Chasis").ToString + Dr("Poliza").ToString + Dr("No_Factura").ToString + "'") = False Then
                        SQL.Insertar("Facturación_vehiculos", "Id_factura,Empresa,Chasis,DUA,Minuta,Factura,Fecha_de_factura,Cliente", SQL.Nuevo_ID("Id_factura", "Facturación_vehiculos").ToString + ",'UNIAUTO, S.A.'," + FN.Campo_tabla(Dr("Chasis")) + "," + FN.Campo_tabla(Dr("Poliza")) + "," + FN.Campo_tabla(Dr("Minuta")) + "," + FN.Campo_tabla(Dr("No_Factura")) + "," + FN.Campo_tabla(Dr("Fecha_Factura")) + "," + FN.Campo_tabla(Dr("Nombre_Cliente")))
                    End If
                End If
            Next

            Dim Dt_Didea As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Didea$]")
            For Each Dr As DataRow In Dt_Didea.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+Chasis+DUA ='DIDEA, S.A." + Dr("Chasis").ToString + Dr("Poliza").ToString + "'") = True Then
                    If SQL.Duplicados("Facturación_vehiculos", "Where Chasis+DUA+Factura ='" + Dr("Chasis").ToString + Dr("Poliza").ToString + Dr("No_Factura").ToString + "'") = False Then
                        SQL.Insertar("Facturación_vehiculos", "Id_factura,Empresa,Chasis,DUA,Minuta,Factura,Fecha_de_factura,Cliente", SQL.Nuevo_ID("Id_factura", "Facturación_vehiculos").ToString + ",'DIDEA, S.A.'," + FN.Campo_tabla(Dr("Chasis")) + "," + FN.Campo_tabla(Dr("Poliza")) + "," + FN.Campo_tabla(Dr("Minuta")) + "," + FN.Campo_tabla(Dr("No_Factura")) + "," + FN.Campo_tabla(Dr("Fecha_Factura")) + "," + FN.Campo_tabla(Dr("Nombre_Cliente")))
                    End If
                End If
            Next

            Dim Dt_Autos_Europa As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Autos Europa$]")
            For Each Dr As DataRow In Dt_Autos_Europa.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+Chasis+DUA ='AUTOS EUROPA, S.A." + Dr("Chasis").ToString + Dr("Poliza").ToString + "'") = True Then
                    If SQL.Duplicados("Facturación_vehiculos", "Where Chasis+DUA+Factura ='" + Dr("Chasis").ToString + Dr("Poliza").ToString + Dr("No_Factura").ToString + "'") = False Then
                        SQL.Insertar("Facturación_vehiculos", "Id_factura,Empresa,Chasis,DUA,Minuta,Factura,Fecha_de_factura,Cliente", SQL.Nuevo_ID("Id_factura", "Facturación_vehiculos").ToString + ",'AUTOS EUROPA, S.A.'," + FN.Campo_tabla(Dr("Chasis")) + "," + FN.Campo_tabla(Dr("Poliza")) + "," + FN.Campo_tabla(Dr("Minuta")) + "," + FN.Campo_tabla(Dr("No_Factura")) + "," + FN.Campo_tabla(Dr("Fecha_Factura")) + "," + FN.Campo_tabla(Dr("Nombre_Cliente")))
                    End If
                End If
            Next

            Dim DT_DOCS As DataTable = SQL.Tabla_de_datos("Select a.Empresa,a.Chasis,a.DUA, STUFF((Select ', '+'['+ b.Factura+' - '+convert(nvarchar,b.Fecha_de_factura,103)+' - '+b.Cliente+']' from Facturación_vehiculos b where a.Chasis=b.Chasis and a.DUA=b.DUA For xml Path('')),1,1,'') As Documentos From Facturación_vehiculos a Group By a.Empresa,a.Chasis, a.DUA")
            For Each Dr As DataRow In DT_DOCS.Rows
                If SQL.Duplicados("Control_de_iprima", "Where Empresa+DUA+Chasis+IsNull(Documentos,'')='" + Dr("Empresa").ToString + Dr("DUA").ToString + Dr("Chasis").ToString + Dr("Documentos").ToString + "'") = False Then
                    SQL.Actualizar("Control_de_iprima", "Documentos=" + FN.Campo_tabla(Dr("Documentos")), "Empresa+Chasis+DUA='" + Dr("Empresa").ToString + Dr("Chasis").ToString + Dr("DUA").ToString + "'")
                End If
            Next

            BBI_Solicitados_ItemClick(Nothing, Nothing)

        End If
    End Sub

    Private Sub GridView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView.RowUpdated
        SQL.Actualizar_tabla()
    End Sub

    Private Sub GridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView.RowDeleted
        SQL.Actualizar_tabla()
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    GridView.DeleteRow(GridView.FocusedRowHandle)
                End If
            End If
        End If
    End Sub

    Private Sub BBI_Envió_a_tesorería_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Envió_a_tesorería.ItemClick

        Dim Fecha As DateTime = Now
        Dim MyString As New Text.StringBuilder()

        MyString.AppendLine("<html><body><tt><font face='calibri,arial narrow'>")

        MyString.AppendLine("<p>Buen día <br/><br/>")

        MyString.AppendLine("Por favor proceder con los siguientes pagos de IPRIMA.</p>")

        Dim DT As DataTable = GridControl.DataSource

        Dim Uniauto = From R In DT Where R("Empresa") = "UNIAUTO, S.A." And R("Formulario_IPRIMA").ToString <> "" Group R By Empresa = R("Empresa").ToString, Póliza = R("DUA").ToString, Boleta = R("Formulario_IPRIMA").ToString, No_de_contingencia = R("No_de_contingencia_formulario_IPRIMA").ToString Into Group
                      Select New With {Empresa, Póliza, Boleta, .Valor = Group.Sum(Function(x) Decimal.Parse(IIf(x("Valor_IPRIMA_SAT") Is DBNull.Value, 0, x("Valor_IPRIMA_SAT")))), No_de_contingencia}

        If Uniauto.Count.ToString > 0 Then

            MyString.AppendLine("<p><b><big>Uniauto</big></b></p>")

            MyString.AppendLine("<left><table border='1' cellpadding='0' cellspacing='1'>")
            MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr bgcolor='#AEB6BF'>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Póliza </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='100'> Boleta</th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Valor </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='200'> No. de contingencia </th>")

            MyString.AppendLine("</tr></font></tt>")

            For Each i In Uniauto
                MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Empresa + "&nbsp;</td>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Póliza + "&nbsp;</td>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.Boleta) + "&nbsp;</td>")
                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + i.Valor.ToString("n2") + "&nbsp;</td>")
                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.No_de_contingencia) + "&nbsp;</td>")
                MyString.AppendLine("</tr></font></tt>")
            Next

            MyString.AppendLine("</table></left>")

        End If

        Dim Didea = From R In DT Where R("Empresa") = "DIDEA, S.A." And R("Formulario_IPRIMA").ToString <> "" Group R By Empresa = R("Empresa").ToString, Póliza = R("DUA").ToString, Boleta = R("Formulario_IPRIMA").ToString, No_de_contingencia = R("No_de_contingencia_formulario_IPRIMA").ToString Into Group
                    Select New With {Empresa, Póliza, Boleta, .Valor = Group.Sum(Function(x) Decimal.Parse(IIf(x("Valor_IPRIMA_SAT") Is DBNull.Value, 0, x("Valor_IPRIMA_SAT")))), No_de_contingencia}

        If Didea.Count.ToString > 0 Then

            MyString.AppendLine("<p><b><big>Didea</big></b></p>")

            MyString.AppendLine("<left><table border='1' cellpadding='0' cellspacing='1'>")
            MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr bgcolor='#AEB6BF'>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Póliza </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='100'> Boleta</th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Valor </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='200'> No. de contingencia </th>")

            MyString.AppendLine("</tr></font></tt>")

            For Each i In Didea
                MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Empresa + "&nbsp;</td>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Póliza + "&nbsp;</td>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.Boleta) + "&nbsp;</td>")
                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + i.Valor.ToString("n2") + "&nbsp;</td>")
                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.No_de_contingencia) + "&nbsp;</td>")
                MyString.AppendLine("</tr></font></tt>")
            Next

            MyString.AppendLine("</table></left>")

        End If

        Dim AutosEuropa = From R In DT Where R("Empresa") = "AUTOS EUROPA, S.A." And R("Formulario_IPRIMA").ToString <> "" Group R By Empresa = R("Empresa").ToString, Póliza = R("DUA").ToString, Boleta = R("Formulario_IPRIMA").ToString, No_de_contingencia = R("No_de_contingencia_formulario_IPRIMA").ToString Into Group
                          Select New With {Empresa, Póliza, Boleta, .Valor = Group.Sum(Function(x) Decimal.Parse(IIf(x("Valor_IPRIMA_SAT") Is DBNull.Value, 0, x("Valor_IPRIMA_SAT")))), No_de_contingencia}

        If AutosEuropa.Count.ToString > 0 Then

            MyString.AppendLine("<p><b><big>Autos Europa</big></b></p>")

            MyString.AppendLine("<left><table border='1' cellpadding='0' cellspacing='1'>")
            MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr bgcolor='#AEB6BF'>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Póliza </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='100'> Boleta</th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Valor </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='200'> No. de contingencia </th>")

            MyString.AppendLine("</tr></font></tt>")

            For Each i In AutosEuropa
                MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Empresa + "&nbsp;</td>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Póliza + "&nbsp;</td>")
                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.Boleta) + "&nbsp;</td>")
                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + i.Valor.ToString("n2") + "&nbsp;</td>")
                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.No_de_contingencia) + "&nbsp;</td>")
                MyString.AppendLine("</tr></font></tt>")
            Next

            MyString.AppendLine("</table></left>")

        End If

        MyString.AppendLine("<p>""Recuerda que trabajar en equipo y confiar en la capacidad de este, forma parte del éxito.""</p>")
        MyString.AppendLine("</font></tt></body></html>")

        Dim Dt_correo As DataTable = SQL.Tabla_de_datos("Select * From Seguimientos_y_correos Where Tipo_de_seguimiento ='Pagos Tesorería'")
        FN.Enviar_correo(, Dt_correo.Rows(0)("Correo_electronico_para").ToString, Dt_correo.Rows(0)("Correo_electronico_cc").ToString, Dt_correo.Rows(0)("Correo_electronico_cco").ToString, "Pago de IPRIMAS " & Fecha, MyString.ToString, )

    End Sub

End Class