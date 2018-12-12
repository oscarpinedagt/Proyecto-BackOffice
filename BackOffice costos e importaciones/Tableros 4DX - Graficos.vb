Public Class Tableros_4DX_Graficos
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Tableros_4DX_Graficos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cargar_grupo_de_empresas()
        TE_Año.EditValue = Now.ToString("yyyy")
        TE_Meta.EditValue = 0.85
        Cargar_mes()
        Cargar_datos_sobre()
    End Sub

    Private Sub Cargar_grupo_de_empresas()

        Dim DT As New DataTable
        DT.Columns.Add("Grupo")
        DT.Columns.Add("Grupo_de_empresas")
        DT.Rows.Add("", "Todos")

        For Each dr As DataRow In SQL.Tabla_de_datos("Select Grupo From Grupo_de_empresas Group By Grupo").Rows
            DT.Rows.Add(dr("Grupo"), dr("Grupo"))
        Next

        With LUE_Grupo_de_empresas.Properties
            .DataSource = DT
            .ValueMember = "Grupo"
            .DisplayMember = "Grupo_de_empresas"
            .PopulateColumns()
            .Columns(.ValueMember).Visible = False
            .Columns(.DisplayMember).Caption = Replace(.DisplayMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            LUE_Grupo_de_empresas.EditValue = .GetKeyValueByDisplayText("Todos")
        End With

    End Sub

    Private Sub Cargar_mes()

        Dim DT As New DataTable

        DT.Columns.Add("Num_y_Mes")
        DT.Columns.Add("Mes")
        For i As Integer = 1 To 12
            DT.Rows.Add(i.ToString("00") + "-" + Strings.Left(StrConv(MonthName(i), VbStrConv.ProperCase), 3), StrConv(MonthName(i), VbStrConv.ProperCase))
        Next

        With LUE_Mes.Properties
            .DataSource = DT
            .ValueMember = "Num_y_Mes"
            .DisplayMember = "Mes"
            .PopulateColumns()
            .Columns(.ValueMember).Visible = False
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            LUE_Mes.EditValue = .GetKeyValueByDisplayText(StrConv(Now.ToString("MMMM"), VbStrConv.ProperCase))
        End With

    End Sub

    Private Sub Cargar_datos_sobre()

        Dim DT As New DataTable
        DT.Columns.Add("DS")
        DT.Columns.Add("Datos_sobre")
        DT.Rows.Add("Rec_Ela", "Recibido - Elaborado")
        DT.Rows.Add("Rec_Env", "Recibido - Enviado")

        With LUE_Datos_sobre.Properties
            .DataSource = DT
            .ValueMember = "DS"
            .DisplayMember = "Datos_sobre"
            .PopulateColumns()
            .Columns(.ValueMember).Visible = False
            .Columns(.DisplayMember).Caption = Replace(.DisplayMember, "_", " ")
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            LUE_Datos_sobre.EditValue = .GetKeyValueByDisplayText("Recibido - Elaborado")
        End With

    End Sub

    Private Sub Cargar_unidades_recibidas_por_mes(Condicion As String)
        With Chart_Unidades_costeadas
            .DataSource = SQL.Tabla_de_datos("Select * From 
                                             (Select a.Costeos,a.Mes,COUNT(a.Ingreso_a_bodega) As Ingresos From
                                             (Select Grupo_de_empresas,Recibido,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " as Estadia,Estado,Año_recepcion As Año,Format(No_mes_recepcion,'00')+'-'+Left(Mes_recepcion,3) As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Ingreso_a_bodega,'Costeos' As Costeos From Costeos)a
                                              Where " + Condicion + "
                                              Group By a.Costeos,a.Mes)b")

            .SeriesTemplate.SeriesDataMember = "Costeos"
            .SeriesTemplate.ArgumentDataMember = "Mes"
            .SeriesTemplate.ValueDataMembers.AddRange(New String() {"Ingresos"})
            .SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto

            .Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
            .Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
            .Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox
            .Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
            .Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside

            .SeriesTemplate.LabelsVisibility = True
            .SeriesTemplate.Label.TextAlignment = StringAlignment.Far
            .SeriesTemplate.Label.TextOrientation = DevExpress.XtraCharts.TextOrientation.Horizontal
            .SeriesTemplate.View = New DevExpress.XtraCharts.LineSeriesView With {.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True}

        End With
    End Sub

    Private Sub Cargar_cumplimiento_mensual(Condicion As String)
        With Chart_Progreso
            .DataSource = SQL.Tabla_de_datos("Select * From 
                                             (Select b.Costeos,b.Mes,Round((Convert(Float,Sum(b.Ingresos_DR),0))/Convert(Float,Sum(b.Ingresos))*100,0) As Cumplimiento From
                                             (Select a.Costeos,a.Mes,a.Estadia,Count(a.Ingreso_a_bodega) as Ingresos,Iif(a.Estadia ='Dentro de rango', Count(a.Ingreso_a_bodega),0) as Ingresos_DR From
                                             (Select Grupo_de_empresas,Recibido,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " as Estadia,Estado,Año_recepcion As Año,Format(No_mes_recepcion,'00')+'-'+Left(Mes_recepcion,3) As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Ingreso_a_bodega,'Cumplimiento' As Costeos From Costeos)a
                                              Where " + Condicion + " 
                                              Group By a.Costeos,a.Mes,a.Estadia)b
                                              Group By b.Costeos,b.Mes)c

                                             Union all

                                             (Select a.Costeos,a.Mes,Round(" + TE_Meta.EditValue.ToString + "*100,0) As Cumplimiento From
                                             (Select Grupo_de_empresas,Recibido,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " as Estadia,Estado,Año_recepcion As Año,Format(No_mes_recepcion,'00')+'-'+Left(Mes_recepcion,3) As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Ingreso_a_bodega,'Meta' As Costeos From Costeos)a
                                              Where " + Condicion + " 
                                              Group By a.Costeos,a.Mes)")

            .SeriesTemplate.SeriesDataMember = "Costeos"
            .SeriesTemplate.ArgumentDataMember = "Mes"
            .SeriesTemplate.ValueDataMembers.AddRange(New String() {"Cumplimiento"})
            .SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto

            .Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
            .Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
            .Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox
            .Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
            .Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside

            .SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
            .SeriesTemplate.Label.LineLength = 15
            .SeriesTemplate.Label.TextAlignment = StringAlignment.Far
            .SeriesTemplate.Label.TextOrientation = DevExpress.XtraCharts.TextOrientation.Horizontal
            .SeriesTemplate.View = New DevExpress.XtraCharts.LineSeriesView With {.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True}


        End With
    End Sub

    Private Sub Cargar_cumplimiento_anual(Condicion As String)
        Dim DT As DataTable = SQL.Tabla_de_datos("Select * From 
                                                 (Select Convert(Float,Sum(b.Ingresos_DR),0)/Convert(Float,Sum(b.Ingresos)) As Cumplimiento From
                                                 (Select a.Costeos,a.Mes,a.Estadia,Count(a.Ingreso_a_bodega) as Ingresos,Iif(a.Estadia ='Dentro de rango', Count(a.Ingreso_a_bodega),0) as Ingresos_DR From
                                                 (Select Grupo_de_empresas,Recibido,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " as Estadia,Estado,Año_recepcion As Año,Format(No_mes_recepcion,'00')+'-'+Left(Mes_recepcion,3) As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Ingreso_a_bodega,'Cumplimiento' As Costeos From Costeos)a
                                                  Where " + Condicion + " 
                                                  Group By a.Costeos,a.Mes,a.Estadia)b)c")
        LC_Cumplimiento.Text = "Meta anual " + Format(TE_Meta.EditValue, "0.00%") + " cumplimiento " + Format(DT.Rows(0)("Cumplimiento"), "0.00%")
    End Sub

    Private Sub Cargar_estadia_por_mes(Condicion As String)
        With Chart_Estadia_por_mes
            .DataSource = SQL.Tabla_de_datos("Select * From
                                             (Select a.Mes,a.Estadia,Count(a.Ingreso_a_bodega) Ingresos From
                                             (Select Grupo_de_empresas,Recibido,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " as Estadia,Estado,Año_recepcion As Año,Format(No_mes_recepcion,'00')+'-'+Left(Mes_recepcion,3) As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Ingreso_a_bodega From Costeos)a
                                              Where " + Condicion + " 
                                              Group By a.Mes,a.Estadia)b")

            .SeriesTemplate.SeriesDataMember = "Estadia"
            .SeriesTemplate.ArgumentDataMember = "Mes"
            .SeriesTemplate.ValueDataMembers.AddRange(New String() {"Ingresos"})
            .SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto

            .Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
            .Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
            .Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox
            .Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
            .Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside

            .SeriesTemplate.LabelsVisibility = True
            .SeriesTemplate.Label.TextAlignment = StringAlignment.Far
            .SeriesTemplate.Label.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop
            CType(.SeriesTemplate.Label, DevExpress.XtraCharts.SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top


        End With
    End Sub

    Private Sub Cargar_estadia_por_semana(Condicion As String)
        With Chart_Estadia_por_semana
            .DataSource = SQL.Tabla_de_datos("Select * From
                                             (Select a.Semana,a.Estadia,Count(a.Ingreso_a_bodega) Ingresos From
                                             (Select Grupo_de_empresas,Recibido,Estadia_" + LUE_Datos_sobre.EditValue.ToString + " as Estadia,Estado,Año_recepcion As Año,Format(No_mes_recepcion,'00')+'-'+Left(Mes_recepcion,3) As Mes,'Semana - '+Format(Semana_recepcion,'00') As Semana,Ingreso_a_bodega From Costeos)a
                                              Where " + Condicion + " 
                                              Group By a.Semana,a.Estadia)b")

            .SeriesTemplate.SeriesDataMember = "Estadia"
            .SeriesTemplate.ArgumentDataMember = "Semana"
            .SeriesTemplate.ValueDataMembers.AddRange(New String() {"Ingresos"})
            .SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Auto

            .Legend.Visibility = DevExpress.Utils.DefaultBoolean.True
            .Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
            .Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBox
            .Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
            .Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside

            .SeriesTemplate.LabelsVisibility = True
            .SeriesTemplate.Label.TextAlignment = StringAlignment.Far
            .SeriesTemplate.Label.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop
            CType(.SeriesTemplate.Label, DevExpress.XtraCharts.SideBySideBarSeriesLabel).Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top

        End With
    End Sub

    Private Sub BBI_Generar_información_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Generar_información.ItemClick
        Cargar_unidades_recibidas_por_mes("a.Recibido ='True' And a.Estado<>'Anulado' And a.Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%' And a.Año = " + TE_Año.EditValue.ToString)
        Cargar_cumplimiento_mensual("a.Recibido ='True' And a.Estado<>'Anulado' And a.Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%' And a.Año = " + TE_Año.EditValue.ToString)
        Cargar_cumplimiento_anual("a.Recibido ='True' And a.Estado<>'Anulado' And a.Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%' And a.Año = " + TE_Año.EditValue.ToString)
        Cargar_estadia_por_mes("a.Recibido ='True' And a.Estado<>'Anulado' And a.Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%' And a.Año = " + TE_Año.EditValue.ToString)
        Cargar_estadia_por_semana("a.Recibido ='True' And a.Estado<>'Anulado' And a.Grupo_de_empresas Like '%" + LUE_Grupo_de_empresas.EditValue.ToString + "%' And a.Año = " + TE_Año.EditValue.ToString + " And a.Mes Like '%" + LUE_Mes.EditValue.ToString + "%'")
    End Sub

    Private Sub BBI_Imprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBI_Imprimir.ItemClick

        Dim PSB As New DevExpress.XtraPrinting.PrintingSystem
        Dim CLK As New DevExpress.XtraPrinting.PrintableComponentLink(PSB)

        CLK.Component = LayoutControl
        CLK.Margins = New System.Drawing.Printing.Margins(0, 0, 50, 35)

        CType(CLK.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.Content.AddRange(New String() {"", "Tablero 4DX Costos e Importaciones ", "Año " + TE_Año.EditValue.ToString})
        CType(CLK.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.LineAlignment = DevExpress.XtraPrinting.BrickAlignment.Far
        CType(CLK.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Header.Font = New Font("Tahoma", 12, FontStyle.Bold)

        CType(CLK.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Content.AddRange(New String() {"Grupo de empresas = " + LUE_Grupo_de_empresas.Text, "", "Página: [Page #] de [Páginas #]"})
        CType(CLK.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter).Footer.Font = New Font("Tahoma", 6)

        CLK.CreateDocument()

        PSB.Document.AutoFitToPagesWidth = 1
        PSB.PageSettings.Landscape = False
        PSB.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter

        CLK.ShowPreview()

    End Sub

    Private Sub CKE_Auto_actualizar_CheckedChanged(sender As Object, e As EventArgs) Handles CKE_Auto_actualizar.CheckedChanged
        TMR_Auto_actualizar.Enabled = CKE_Auto_actualizar.Checked
    End Sub

    Private Sub TMR_Auto_actualizar_Tick(sender As Object, e As EventArgs) Handles TMR_Auto_actualizar.Tick
        BBI_Generar_información_ItemClick(Nothing, Nothing)
    End Sub
End Class