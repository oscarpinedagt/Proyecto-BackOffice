Public Class Seguimientos_Solicitud_de_pago_de_impuestos
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Dim Tipo_de_reporte As String

    Private Sub Seguimientos_Control_de_Iprima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos("Where Id_solicitud = 0")
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_con_actualización_de_datos("Select * From Solicitud_de_pago_de_impuestos_Tesorería " + Condicion)
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
                        Case "Fecha", "Fecha_formulario"
                            CL.DisplayFormat.FormatString = "d"
                    End Select
                End If

                Select Case CL.FieldName
                    Case "Id_solicitud", "Usuario_que_solicita"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Formulario", "No_de_acceso_formulario", "No_de_contingencia_formulario"
                        CL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End Select

                Select Case CL.FieldName
                    Case "Tiempo_de_pago_en_HRS"
                        CL.OptionsColumn.ReadOnly = True
                End Select

                Select Case CL.FieldName
                    Case "Valor", "Valor_SAT"
                        CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        CL.DisplayFormat.FormatString = "n2"

                        With CL.SummaryItem
                            .SummaryType = DevExpress.Data.SummaryItemType.Sum
                            .FieldName = CL.FieldName
                            .DisplayFormat = "{0:n2}"
                        End With

                End Select

            Next

            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True
            .OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            .OptionsView.ColumnAutoWidth = False
            GridView.BestFitColumns()

        End With
        Columna_empresa()
        Columna_tipo_de_mercaderia()
        Columna_fecha()
        Columna_fecha_y_hora()
        Columna_tipo_de_documento()
        Columna_régimen()

    End Sub

    Private Sub Columna_empresa()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Empresa From Directorios_y_correos Group By Empresa")
            .ValueMember = "Empresa"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Empresa").ColumnEdit = Item
    End Sub

    Private Sub Columna_tipo_de_mercaderia()
        Dim Item_tipo_de_mercaderia As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item_tipo_de_mercaderia
            .DataSource = SQL.Tabla_de_datos("Select Tipo_de_mercaderia From Tipos_de_mercaderia")
            .ValueMember = "Tipo_de_mercaderia"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridControl.RepositoryItems.Add(Item_tipo_de_mercaderia)
        GridView.Columns("Tipo_de_mercaderia").ColumnEdit = Item_tipo_de_mercaderia
    End Sub

    Private Sub Columna_fecha()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "d"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha").ColumnEdit = Item
        GridView.Columns("Fecha_formulario").ColumnEdit = Item
    End Sub

    Private Sub Columna_fecha_y_hora()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        With Item
            .Mask.EditMask = "g"
            .Mask.UseMaskAsDisplayFormat = True
            .Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        End With
        GridView.Columns("Fecha_de_solicitud_de_pago").ColumnEdit = Item
        GridView.Columns("Fecha_de_confirmación_de_pago").ColumnEdit = Item
    End Sub

    Private Sub Columna_tipo_de_documento()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim DT_TDC As New DataTable
        DT_TDC.Columns.Add("Tipo_de_documento")
        DT_TDC.Columns.Add("Descripción")
        DT_TDC.Rows.Add("DUA", "Declaración Única Aduanera")
        'DT_TDC.Rows.Add("IPRIMA", "Impuesto a la Primera Matrícula")
        DT_TDC.Rows.Add("FAUCA", "Formulario Aduanero Único Centroamericano")
        DT_TDC.Rows.Add("FYDUCA", "Factura y Declaración Única Centroamericana")

        With Item
            .DataSource = DT_TDC
            .ValueMember = "Tipo_de_documento"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Tipo_de_documento").ColumnEdit = Item
    End Sub

    Private Sub Columna_régimen()
        Dim Item As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        With Item
            .DataSource = SQL.Tabla_de_datos("Select Modalidad From Tipos_de_modalidades_DUA_GT Order By Modalidad")
            .ValueMember = "Modalidad"
            .DisplayMember = .ValueMember
            .PopulateColumns()
            .Columns(.ValueMember).Caption = Replace(.ValueMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        End With
        GridView.Columns("Régimen").ColumnEdit = Item
    End Sub

    Private Sub BBI_Solicitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Solicitar.ItemClick
        GridView.FormatRules.Clear()
        GridView.OptionsSelection.MultiSelect = False
        Tipo_de_reporte = "Solicitar"
        Cargar_datos("Where (Formulario Is Null or Formulario = '') Order By Fecha")
        GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        GridView.Columns("Empresa").UnGroup()
    End Sub

    Private Sub BBI_Solicitados_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Solicitados.ItemClick
        GridView.FormatRules.Clear()
        GridView.OptionsSelection.MultiSelect = True
        'GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Tipo_de_reporte = "Solicitados"
        Cargar_datos("Where (Formulario Is Not Null And Formulario <> '') And (Fecha_de_confirmación_de_pago Is Null Or Fecha_de_confirmación_de_pago = '')  Order By Documento")
        GridView.Columns("Empresa").Group()
        GridView.ExpandAllGroups()
    End Sub

    Private Sub BBI_Liquidados_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Liquidados.ItemClick
        GridView.FormatRules.Clear()
        GridView.OptionsSelection.MultiSelect = False
        Tipo_de_reporte = "Liquidados"
        Cargar_datos("Where (Formulario Is Not Null And Formulario <> '') And (Fecha_de_solicitud_de_pago Is Not Null And Fecha_de_solicitud_de_pago <> '') And (Fecha_de_confirmación_de_pago Is Not Null And Fecha_de_confirmación_de_pago <> '') Order By Documento")
        GridView.Columns("Empresa").Group()
        GridView.ExpandAllGroups()
    End Sub

    Private Sub GridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView.InitNewRow
        GridView.SetRowCellValue(e.RowHandle, "Id_solicitud", Now.ToString("yyMMddHHmmssfff"))
        GridView.SetRowCellValue(e.RowHandle, "Usuario_que_solicita", Costos_e_Importaciones.Usuario)
    End Sub

    Private Sub GridView_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView.ValidateRow
        Dim i As Integer = e.RowHandle

        If GridView.GetRowCellValue(i, "Empresa").ToString <> "" And GridView.GetRowCellValue(i, "Tipo_de_mercaderia").ToString <> "" And GridView.GetRowCellValue(i, "Tipo_de_documento").ToString <> "" And GridView.GetRowCellValue(i, "Documento").ToString <> "" Then
            e.Valid = True
        Else
            e.ErrorText = "Valida los campos Empresa, tipo de mercaderia, tipo de documento y documento"
            e.Valid = False
        End If

    End Sub

    Private Sub GridView_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView.RowUpdated
        SQL.Actualizar_tabla()
    End Sub

    Private Sub GridView_RowDeleted(sender As Object, e As DevExpress.Data.RowDeletedEventArgs) Handles GridView.RowDeleted
        SQL.Actualizar_tabla()
    End Sub

    Private Sub GridView_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView.KeyDown
        If e.KeyData = Keys.Shift + Keys.Delete Then
            If MsgBox("Esta seguro de eliminar el contenido", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Eliminar"}
                SEG.ShowDialog()
                If SEG.Resultado = True Then
                    GridView.DeleteRow(GridView.FocusedRowHandle)
                End If
            End If
        ElseIf e.KeyData = Keys.Delete Then
            GridView.SetRowCellValue(GridView.FocusedRowHandle, GridView.FocusedColumn, Nothing)
        End If
    End Sub

    Private Sub BBI_Envió_a_tesorería_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Envió_a_tesorería.ItemClick

        If Tipo_de_reporte = "Solicitados" Then

            Dim Fecha As DateTime = Now
            Dim MyString As New Text.StringBuilder()

            MyString.AppendLine("<html><body><tt><font face='calibri,arial narrow'>")

            MyString.AppendLine("<p>Buen día <br/><br/>")

            MyString.AppendLine("Por favor proceder con los siguientes pagos.</p>")

            Dim DT As DataTable = GridControl.DataSource

            Dim Empresas = From R In DT Group R By Empresa = R("Empresa").ToString Into Group Select New With {Empresa}

            For Each Emp In Empresas

                Dim Datos = From R In DT Where R("Empresa") = Emp.Empresa And R("Formulario").ToString <> "" Group R By Empresa = R("Empresa").ToString, Documento = R("Documento").ToString, Boleta = R("Formulario").ToString, Fecha_solicitud = R("Fecha_de_solicitud_de_pago").ToString, No_de_contingencia = R("No_de_contingencia_formulario").ToString Into Group
                            Select New With {Empresa, Documento, Boleta, Fecha_solicitud, .Valor = Group.Sum(Function(x) Decimal.Parse(IIf(x("Valor_SAT") Is DBNull.Value, 0, x("Valor_SAT")))), No_de_contingencia}

                If Datos.Count.ToString > 0 Then

                    Dim Dts As Integer = 0
                    For Each i In Datos
                        If i.Fecha_solicitud.ToString = "" Then
                            Dts += 1
                        End If
                    Next

                    If Dts > 0 Then

                        MyString.AppendLine("<p><b><big>" + Emp.Empresa + "</big></b></p>")

                        MyString.AppendLine("<left><table border='1' cellpadding='0' cellspacing='1'>")
                        MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr bgcolor='#eca41c'>")
                        MyString.AppendLine("<th align='center' valign='middle' width='150'> Empresa </th>")
                        MyString.AppendLine("<th align='center' valign='middle' width='150'> Documento </th>")
                        MyString.AppendLine("<th align='center' valign='middle' width='100'> Boleta</th>")
                        MyString.AppendLine("<th align='center' valign='middle' width='200'> No. de contingencia </th>")
                        MyString.AppendLine("<th align='center' valign='middle' width='150'> Valor </th>")


                        MyString.AppendLine("</tr></font></tt>")

                        Dim Total As Double = 0
                        For Each i In Datos
                            If i.Fecha_solicitud.ToString = "" Then
                                MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Empresa + "&nbsp;</td>")
                                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + i.Documento + "&nbsp;</td>")
                                MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.Boleta) + "&nbsp;</td>")
                                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + FN.Quitar_espacios_innecesarios(i.No_de_contingencia) + "&nbsp;</td>")
                                MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + i.Valor.ToString("n2") + "&nbsp;</td>")
                                MyString.AppendLine("</tr></font></tt>")
                                Total += i.Valor
                            End If
                        Next

                        MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                        MyString.AppendLine("<td align='right' valign='middle' colspan=4><b> &nbsp; Total &nbsp;</b></td>")
                        MyString.AppendLine("<td align='right' valign='middle'><b> &nbsp;" + Total.ToString("n2") + "&nbsp;</b></td>")
                        MyString.AppendLine("</tr></font></tt>")

                        MyString.AppendLine("</table></left>")

                    End If
                End If
            Next

            MyString.AppendLine("<p>""Recuerda que trabajar en equipo y confiar en la capacidad de este, forma parte del éxito.""</p>")
            MyString.AppendLine("</font></tt></body></html>")

            Dim Dt_correo As DataTable = SQL.Tabla_de_datos("Select * From Seguimientos_y_correos Where Tipo_de_seguimiento ='Pagos Tesorería'")
            FN.Enviar_correo(, Dt_correo.Rows(0)("Correo_electronico_para").ToString, Dt_correo.Rows(0)("Correo_electronico_cc").ToString, Dt_correo.Rows(0)("Correo_electronico_cco").ToString, "Solicitud de pago de impuestos " & Fecha, MyString.ToString, )

        End If
    End Sub

    Private Sub BBI_Generar_a_Excel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_a_Excel.ItemClick
        If GridView.RowCount > 0 Then
            FN.Exportar_GridControl_a_Excel(GridControl, "Solicitud de pago de impuestos a Tesorería " + LCase(Tipo_de_reporte) + " al " + Replace(Now.ToShortDateString, "/", "-"))
        End If
    End Sub
End Class