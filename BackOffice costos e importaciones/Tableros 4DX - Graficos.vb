Public Class Tableros_4DX_Graficos
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Tableros_4DX_Graficos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cargar_grupo_de_empresas()
        TE_Año.EditValue = Now.ToString("yyyy")
        TE_Meta.EditValue = 0.85
        Cargar_mes()
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

        DT.Columns.Add("Mes")
        For i As Integer = 1 To 12
            DT.Rows.Add(StrConv(MonthName(i), VbStrConv.ProperCase))
        Next

        With LUE_Mes.Properties
            .DataSource = DT
            .ValueMember = "Mes"
            .DisplayMember = "Mes"
            .BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            LUE_Mes.EditValue = .GetKeyValueByDisplayText(StrConv(Now.ToString("MMMM"), VbStrConv.ProperCase))
        End With

    End Sub

    Private Sub Cargar_unidades_recibidas_por_mes(Condicion As String)
        With Chart_Unidades_costeadas
            .DataSource = SQL.Tabla_de_datos("Select a.Costeos,a.Mes,Sum(a.Ingresos) as Ingresos 
                                              From (Select Grupo_de_empresas,'Costeos' as Costeos,Recibido,Estadia_Rec_Env as Estadia,Estado,DateName(Year,Fecha_de_recepcion) as Año,DateName(Month,Fecha_de_recepcion) as Mes,DatePart(Month,Fecha_de_recepcion) as Orden_mes,'Semana '+Format(Semana_recepcion,'00') as Semana,Count(Ingreso_a_bodega) as Ingresos From Costeos Group By Grupo_de_empresas,Recibido,Estadia_Rec_Env,Estado,Fecha_de_recepcion,Semana_recepcion) a 
                                              Where " + Condicion + " 
                                              Group By a.Costeos,a.Mes,a.Orden_mes 
                                              Order By a.Orden_mes")

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
            .SeriesTemplate.Label.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop
            .SeriesTemplate.View = New DevExpress.XtraCharts.LineSeriesView With {.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True}

        End With
    End Sub

    Private Sub Cargar_cumplimiento_mensual(Condicion As String)
        With Chart_Progreso
            .DataSource = SQL.Tabla_de_datos("Select * from
                                             (Select a.Costeos,a.Mes,a.Orden_mes,Round((Convert(float,sum(a.Ingresos_Dr))/Convert(float,Sum(a.Ingresos)))*100,0) as Cumplimiento
                                              From (Select Grupo_de_empresas,'Cumplimiento' as Costeos,Recibido,Estadia_Rec_Env as Estadia,Estado,DateName(Year,Fecha_de_recepcion) as Año,DateName(Month,Fecha_de_recepcion) as Mes,DatePart(Month,Fecha_de_recepcion) as Orden_mes,'Semana '+Format(Semana_recepcion,'00') as Semana,Count(Ingreso_a_bodega) as Ingresos,iif(Estadia_Rec_Env='Dentro de rango', Count(Ingreso_a_bodega),0) as Ingresos_Dr From Costeos Group By Grupo_de_empresas,Recibido,Estadia_Rec_Env,Estado,Fecha_de_recepcion,Semana_recepcion) a 
											  Where " + Condicion + " 
                                              Group By a.Costeos,a.Mes,a.Orden_mes)a
                                              
                                              Union all 										  

                                             (Select a.Costeos,a.Mes,a.Orden_mes,Round(" + TE_Meta.EditValue.ToString + "*100,0) as Cumplimiento
                                              From (Select Grupo_de_empresas,'Meta' as Costeos,Recibido,Estadia_Rec_Env as Estadia,Estado,DateName(Year,Fecha_de_recepcion) as Año,DateName(Month,Fecha_de_recepcion) as Mes,DatePart(Month,Fecha_de_recepcion) as Orden_mes,'Semana '+Format(Semana_recepcion,'00') as Semana,Count(Ingreso_a_bodega) as Ingresos,iif(Estadia_Rec_Env='Dentro de rango', Count(Ingreso_a_bodega),0) as Ingresos_Dr From Costeos Group By Grupo_de_empresas,Recibido,Estadia_Rec_Env,Estado,Fecha_de_recepcion,Semana_recepcion) a 
											  Where " + Condicion + " 
                                              Group By a.Costeos,a.Mes,a.Orden_mes)
											  Order by Orden_mes")

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
            .SeriesTemplate.Label.TextOrientation = DevExpress.XtraCharts.TextOrientation.BottomToTop
            .SeriesTemplate.View = New DevExpress.XtraCharts.LineSeriesView With {.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True}


        End With
    End Sub

    Private Sub Cargar_cumplimiento_anual(Condicion As String)
        Dim DT As DataTable = SQL.Tabla_de_datos("Select Convert(float, sum(a.Ingresos_Dr)) / Convert(float, Sum(a.Ingresos)) As Cumplimiento
                                                  From(Select Grupo_de_empresas,'Costeos cumplimiento' as Costeos,Recibido,Estadia_Rec_Env as Estadia,Estado,DateName(Year,Fecha_de_recepcion) as Año,DateName(Month,Fecha_de_recepcion) as Mes,DatePart(Month,Fecha_de_recepcion) as Orden_mes,'Semana '+Format(Semana_recepcion,'00') as Semana,Count(Ingreso_a_bodega) as Ingresos,iif(Estadia_Rec_Env='Dentro de rango', Count(Ingreso_a_bodega),0) as Ingresos_Dr From Costeos Group By Grupo_de_empresas,Recibido,Estadia_Rec_Env,Estado,Fecha_de_recepcion,Semana_recepcion) a 
                                                  Where " + Condicion + " 
                                                  Group By a.Costeos")
        LC_Cumplimiento.Text = "Meta anual " + Format(TE_Meta.EditValue, "0.00%") + " cumplimiento " + Format(DT.Rows(0)("Cumplimiento"), "0.00%")
    End Sub

    Private Sub Cargar_estadia_por_mes(Condicion As String)
        With Chart_Estadia_por_mes
            .DataSource = SQL.Tabla_de_datos("Select a.Estadia,a.Mes,Sum(a.Ingresos) as Ingresos 
                                              From (Select Grupo_de_empresas,Recibido,Estadia_Rec_Env as Estadia,Estado,DateName(Year,Fecha_de_recepcion) as Año,DateName(Month,Fecha_de_recepcion) as Mes,DatePart(Month,Fecha_de_recepcion) as Orden_mes,'Semana '+Format(Semana_recepcion,'00') as Semana,Count(Ingreso_a_bodega) as Ingresos From Costeos Group By Grupo_de_empresas,Recibido,Estadia_Rec_Env,Estado,Fecha_de_recepcion,Semana_recepcion) a 
                                              Where " + Condicion + " 
                                              Group By a.Estadia,a.Mes,a.Orden_mes 
                                              Order By a.Orden_mes ")

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
            .DataSource = SQL.Tabla_de_datos("Select a.Estadia,a.Semana,Sum(a.Ingresos) as Ingresos 
                                              From (Select Grupo_de_empresas,Recibido,Estadia_Rec_Env as Estadia,Estado,DateName(Year,Fecha_de_recepcion) as Año,DateName(Month,Fecha_de_recepcion) as Mes,DatePart(Month,Fecha_de_recepcion) as Orden_mes,'Semana '+Format(Semana_recepcion,'00') as Semana,Count(Ingreso_a_bodega) as Ingresos From Costeos Group By Grupo_de_empresas,Recibido,Estadia_Rec_Env,Estado,Fecha_de_recepcion,Semana_recepcion) a 
                                              Where " + Condicion + " 
                                              Group By a.Estadia,a.Semana")



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