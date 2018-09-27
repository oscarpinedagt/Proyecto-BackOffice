Public Class Seguimientos_Recepción_de_costeos
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones
    Private Sub Recepción_y_seguimiento_de_costeos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_datos("Where Id_costeo = 0")
        DE_Fecha_inicial.DateTime = Format(Now, "01/MM/yyyy")
        DE_Fecha_final.DateTime = Format(Now, "dd/MM/yyyy")
    End Sub

    Private Sub Cargar_datos(Condicion As String)
        GridControl.DataSource = SQL.Tabla_de_datos("Select Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Tipo_de_importacion,[Shipper|Carrier],[Guia|BL|Carta_de_porte],[Fecha_de_Guia|BL|Carta_de_porte],Fecha_de_arribo,[Dua|Fauca|Face],[Fecha_de_Dua|Fauca|Face],Recibido,Usuario_que_recibe,Fecha_de_recepcion,Dif_Ing_Rec,Costeo_asignado_a From Costeos " + Condicion)
        GridControl.RefreshDataSource()
        Configurar_GridControl()
    End Sub

    Private Sub Configurar_GridControl()
        With GridView

            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns

                If CL.FieldName.ToString.Contains("Fecha") And CL.FieldName <> "Fecha_de_arribo" Then
                    CL.Caption = "Fecha"
                    CL.DisplayFormat.FormatString = "g"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Fecha_de_arribo"
                        CL.DisplayFormat.FormatString = "g"
                End Select

                Select Case CL.FieldName
                    Case "Id_costeo"
                        CL.Visible = False
                End Select

                Select Case CL.FieldName
                    Case "Dif_Ing_Rec"
                        CL.Caption = "Tiempo en Hrs Ing-Rec"
                        CL.ToolTip = "Ing-Rec = Ingresado a bodega - Recibido"
                End Select

                Select Case CL.FieldName
                    Case "Grupo_de_empresas", "Empresa", "Tipo_de_mercaderia", "Recibido"
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

    Private Sub BBI_Fecha_de_ingreso_a_bodega_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Fecha_de_ingreso_a_bodega.ItemClick
        Dim CF As String = "Fecha_de_ingreso_a_bodega"
        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        Dim FF As DateTime = Convert.ToDateTime(DE_Fecha_final.DateTime.ToShortDateString + " 23:59:59")
        If FF >= FI Then
            Cargar_datos("Where (" + CF + " Between '" + FI.ToString + "' And '" + FF.ToString + "') Or " + CF + " Is Null Or " + CF + "='' Order By " + CF)
        End If
    End Sub

    Private Sub BBI_Fecha_de_recepción_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Fecha_de_recepción.ItemClick
        Dim CF As String = "Fecha_de_recepcion"
        Dim FI As DateTime = Convert.ToDateTime(DE_Fecha_inicial.DateTime.ToShortDateString + " 00:00:01")
        Dim FF As DateTime = Convert.ToDateTime(DE_Fecha_final.DateTime.ToShortDateString + " 23:59:59")
        If FF >= FI Then
            Cargar_datos("Where (" + CF + " Between '" + FI.ToString + "' And '" + FF.ToString + "') Order By " + CF)
        End If
    End Sub

    Private Sub BBI_Envió_de_seguimiento_de_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Envió_de_seguimiento_de_costeos.ItemClick
        If GridView.RowCount > 0 Then
            Dim MyString As New Text.StringBuilder()

            MyString.AppendLine("<html><body><tt><font face='calibri,arial narrow'>")

            MyString.AppendLine("<p>Buen día, adjunto seguimiento de costeos Tecun y afiliadas al " & Now & ".<br/><br/>")
            MyString.AppendLine("Agradecemos sus comentarios, valioso apoyo y colaboración con el traslado de la papelería.</p>")

            MyString.AppendLine("<left><table border='1' cellpadding='0' cellspacing='1'>")
            MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr bgcolor='#AEB6BF'>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='100'> Compra </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Fecha de ingreso </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='160'> Días hábiles transcurridos  </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='050'> SE </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='150'> Sub empresa </th>")
            MyString.AppendLine("<th align='center' valign='middle' width='250'> Comentarios </th>")
            MyString.AppendLine("</tr></font></tt>")

            For i As Integer = 0 To GridView.DataRowCount - 1
                If GridView.GetRowCellValue(i, "Recibido").ToString = "False" And GridView.GetRowCellValue(i, "Grupo_de_empresas").ToString = "Grupo Tecun" And GridView.GetRowCellValue(i, "Estado").ToString <> "Anulado" Then
                    MyString.AppendLine("<tt><font face='calibri,arial narrow'><tr>")
                    MyString.AppendLine("<td align='left' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Empresa") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Compra") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + Format(GridView.GetRowCellValue(i, "Fecha_de_ingreso_a_bodega"), "dd/MM/yyyy") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + Format((GridView.GetRowCellValue(i, "Dif_Ing_Rec") / 10) - 1, "00") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='center' valign='middle'> &nbsp;" + Format(GridView.GetRowCellValue(i, "SE"), "000") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='left' valign='middle'> &nbsp;" + GridView.GetRowCellValue(i, "Sub_empresa") + "&nbsp;</td>")
                    MyString.AppendLine("<td align='right' valign='middle'> &nbsp;" + Nothing + " </td>")
                    MyString.AppendLine("</tr></font></tt>")
                End If
            Next

            MyString.AppendLine("</table></left>")
            MyString.AppendLine("</font></tt></body></html>")

            Dim Dt_correo As DataTable = SQL.Tabla_de_datos("Select * From Seguimientos_y_correos Where Id_seguimientos_y_correos = 1")
            FN.Enviar_correo(, Dt_correo.Rows(0)("Correo_electronico_para").ToString, Dt_correo.Rows(0)("Correo_electronico_cc").ToString, Dt_correo.Rows(0)("Correo_electronico_cco").ToString, "Seguimiento de costeos Tecun y afiliadas", MyString.ToString)
        End If
    End Sub

    Private Sub BBI_Cargar_costeos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Cargar_costeos.ItemClick
        Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx"}
        If File.ShowDialog() = DialogResult.OK Then

            Dim Dt_Tecun As DataTable = SQL.Tabla_de_datos_Excel(File.FileName, "Select * From [TECUN, S.A.$]")
            For Each Dr As DataRow In Dt_Tecun.Rows
                If Dr("Compra").ToString <> "" Then
                    If SQL.Duplicados("Costeos", "Where Empresa+Compra ='TECUN, S.A." + Dr("Compra").ToString + "'") = False And Dr("Depto") <> 9 Then
                        Dim TM As String = Nothing
                        If SQL.Extraer_informacion_de_columna("SE", "DP_auxiliar", "Where DP='" + Dr("Depto").ToString + "'") <> 0 Then TM = "Productos" Else TM = "Repuestos"
                        SQL.Insertar("Costeos", "Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Recibido", SQL.Nuevo_ID("Id_costeo", "Costeos").ToString + ",'" + SQL.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b ", "Where a.Razon_comercial='TECUN, S.A.' And a.RL_GE=b.Id_grupo_empresas") + "','TECUN, S.A.','" + TM + "'," + SQL.Extraer_informacion_de_columna("SE", "DP_auxiliar", "Where DP=" + Dr("Depto").ToString).ToString + ",'" + SQL.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE=" + SQL.Extraer_informacion_de_columna("SE", "DP_auxiliar", "Where DP=" + Dr("Depto").ToString).ToString) + "','" + Dr("Compra").ToString + "','P" + Dr("Compra").ToString + "','" + Convert.ToDateTime(Dr("Fecha") + " 08:00").ToString + "','False'")
                    End If
                End If
            Next

            Dim Dt_Insectrol As DataTable = SQL.Tabla_de_datos_Excel(File.FileName, "Select * From [INSECTROL, S.A.$]")
            For Each Dr As DataRow In Dt_Insectrol.Rows
                If Dr("Compra").ToString <> "" Then
                    If SQL.Duplicados("Costeos", "Where Empresa+Compra ='INSECTROL, S.A." + Dr("Compra").ToString + "'") = False And Dr("Depto") <> 9 Then
                        Dim TM As String = Nothing
                        If SQL.Extraer_informacion_de_columna("SE", "DP_auxiliar", "Where DP='" + Dr("Depto").ToString + "'") <> 0 Then TM = "Productos" Else TM = "Repuestos"
                        SQL.Insertar("Costeos", "Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Recibido", SQL.Nuevo_ID("Id_costeo", "Costeos").ToString + ",'" + SQL.Extraer_informacion_de_columna("b.Grupo", "Empresas a, Grupo_de_empresas b ", "Where a.Razon_comercial='INSECTROL, S.A.' And a.RL_GE=b.Id_grupo_empresas") + "','INSECTROL, S.A.','" + TM + "'," + SQL.Extraer_informacion_de_columna("SE", "DP_auxiliar", "Where DP=" + Dr("Depto").ToString).ToString + ",'" + SQL.Extraer_informacion_de_columna("Sub_empresa", "Sub_empresas", "Where SE=" + SQL.Extraer_informacion_de_columna("SE", "DP_auxiliar", "Where DP=" + Dr("Depto").ToString).ToString) + "','" + Dr("Compra").ToString + "','P" + Dr("Compra").ToString + "','" + Convert.ToDateTime(Dr("Fecha") + " 08:00").ToString + "','False'")
                    End If
                End If
            Next

            Dim Dt_Vehiculos As DataTable = SQL.Tabla_de_datos_Excel(File.FileName, "Select * From [VEHICULOS$]")
            For Each Dr As DataRow In Dt_Vehiculos.Rows
                If Dr("Ingreso_a_bodega").ToString <> "" Then
                    If SQL.Duplicados("Costeos", "Where Empresa+Compra+Ingreso_a_bodega ='" + Dr("Empresa").ToString + Dr("Compra").ToString + Dr("Ingreso_a_bodega").ToString + "'") = False Then
                        SQL.Insertar("Costeos", "Id_costeo,Grupo_de_empresas,Empresa,Tipo_de_mercaderia,SE,Sub_empresa,Compra,Ingreso_a_bodega,Fecha_de_ingreso_a_bodega,Tipo_de_costeo,Estado,Proveedor,Marca,País_de_procedencia,Tipo_de_importacion,Incoterm,[Shipper|Carrier],[Guia|BL|Carta_de_porte],[Fecha_de_Guia|BL|Carta_de_porte],Fecha_de_arribo,Régimen,[Dua|Fauca|Face],[Fecha_de_Dua|Fauca|Face],Moneda,Factor_de_cambio_USD,Factor_de_cambio_GTQ,FOB_USD,Flete_USD,Seguro_USD,Otros_USD,Total_USD,Total_GTQ,Contenedores_o_bultos,DAI,IVA,DAI_e_IVA,Recibido,Usuario_que_recibe,Fecha_de_recepcion,Costeo_asignado_a,Elaborado,Usuario_que_elabora,Fecha_de_elaboracion", SQL.Nuevo_ID("Id_costeo", "Costeos").ToString + ",'" + Dr("Grupo_de_empresas").ToString + "','" + Dr("Empresa").ToString + "','" + Dr("Tipo_de_mercaderia").ToString + "','" + Dr("SE").ToString + "','" + Dr("Sub_empresa").ToString + "','" + Dr("Compra").ToString + "','" + Dr("Ingreso_a_bodega").ToString + "','" + Convert.ToDateTime(Dr("Fecha_de_ingreso_a_bodega")).ToString + "','" + Dr("Tipo_de_costeo").ToString + "','" + Dr("Estado").ToString + "','" + Dr("Proveedor").ToString + "','" + Dr("Marca").ToString + "','" + Dr("País_de_procedencia").ToString + "','" + Dr("Tipo_de_importacion").ToString + "','" + Dr("Incoterm").ToString + "','" + Dr("Shipper|Carrier").ToString + "','" + Dr("Guia|BL|Carta_de_porte").ToString + "','" + Convert.ToDateTime(Dr("Fecha_de_Guia|BL|Carta_de_porte")).ToString + "','" + Convert.ToDateTime(Dr("Fecha_de_arribo")).ToString + "','" + Dr("Régimen").ToString + "','" + Dr("Dua|Fauca|Face").ToString + "','" + Convert.ToDateTime(Dr("Fecha_de_Dua|Fauca|Face")).ToString + "','" + Dr("Moneda").ToString + "','" + Val(Dr("Factor_de_cambio_USD")).ToString + "','" + Val(Dr("Factor_de_cambio_GTQ")).ToString + "','" + Val(Dr("FOB_USD")).ToString + "','" + Val(Dr("Flete_USD")).ToString + "','" + Val(Dr("Seguro_USD")).ToString + "','" + Val(Dr("Otros_USD")).ToString + "','" + Val(Dr("Total_USD")).ToString + "','" + Val(Dr("Total_GTQ")).ToString + "','" + Val(Dr("Contenedores_o_bultos")).ToString + "','" + Val(Dr("DAI")).ToString + "','" + Val(Dr("IVA")).ToString + "','" + Val(Dr("DAI_e_IVA")).ToString + "','" + Dr("Recibido").ToString + "','" + Dr("Usuario_que_recibe").ToString + "','" + Convert.ToDateTime(Dr("Fecha_de_recepcion")).ToString + "','" + Dr("Costeo_asignado_a").ToString + "','" + Dr("Elaborado").ToString + "','" + Dr("Usuario_que_elabora").ToString + "','" + Convert.ToDateTime(Dr("Fecha_de_elaboracion")).ToString + "'")
                    End If
                End If
            Next

            BBI_Fecha_de_ingreso_a_bodega_ItemClick(sender, Nothing)

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