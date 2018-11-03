Public Class Seguimientos_Control_de_garantias_fabrica_taller
    Dim SQL As New BackOffice_datos.SQL
    Dim FN As New BackOffice_servicios.Funciones

    Private Sub GC_Facturación_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GC_Facturación.CustomButtonClick
        Select Case e.Button.Properties.Caption

            Case "Cargar facturación"
                Dim File As New OpenFileDialog() With {.Filter = "Excel|*.xlsx;*.xlsm"}
                If File.ShowDialog() = DialogResult.OK Then

                    Dim Dt_Uniauto As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Uniauto$]")
                    For Each Dr As DataRow In Dt_Uniauto.Rows
                        If Dr("Tipo_de_orden").ToString = "Garantia de Fábrica - T" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden ='UNIAUTO, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_facturación", "Id_documento,Empresa,Factura,Fecha,No_de_orden,Tipo_de_orden,Total_bruto,Descuento,IVA,Total_neto,Tipo_de_liquidación", Now.ToString("yyMMddHHmmssfff") + ",'UNIAUTO, S.A.'," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("Tipo_de_orden")) + "," + FN.Campo_tabla(Dr("Total_bruto")) + "," + FN.Campo_tabla(Dr("Descuento")) + "," + FN.Campo_tabla(Dr("IVA")) + "," + FN.Campo_tabla(Dr("Total_neto")) + "," + FN.Campo_tabla(Dr("Tipo_de_liquidación")))
                            End If
                        End If
                    Next

                    Dim Dt_Didea As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Didea$]")
                    For Each Dr As DataRow In Dt_Didea.Rows
                        If Dr("Tipo_de_orden").ToString = "Garantia de Fábrica - T" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden ='DIDEA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_facturación", "Id_documento,Empresa,Factura,Fecha,No_de_orden,Tipo_de_orden,Total_bruto,Descuento,IVA,Total_neto,Tipo_de_liquidación", Now.ToString("yyMMddHHmmssfff") + ",'DIDEA, S.A.'," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("Tipo_de_orden")) + "," + FN.Campo_tabla(Dr("Total_bruto")) + "," + FN.Campo_tabla(Dr("Descuento")) + "," + FN.Campo_tabla(Dr("IVA")) + "," + FN.Campo_tabla(Dr("Total_neto")) + "," + FN.Campo_tabla(Dr("Tipo_de_liquidación")))
                            End If
                        End If
                    Next

                    Dim Dt_Autos_Europa As DataTable = SQL.Tabla_de_datos_desde_Excel(File.FileName, "Select * From [Autos Europa$]")
                    For Each Dr As DataRow In Dt_Autos_Europa.Rows
                        If Dr("Tipo_de_orden").ToString = "Garantia de Fábrica - T" Then
                            If SQL.Duplicados("Garantias_fabrica_taller_facturación", "Where Empresa+Factura+No_de_orden ='AUTOS EUROPA, S.A." + Dr("Factura").ToString + Dr("No_de_orden").ToString + "'") = False Then
                                SQL.Insertar("Garantias_fabrica_taller_facturación", "Id_documento,Empresa,Factura,Fecha,No_de_orden,Tipo_de_orden,Total_bruto,Descuento,IVA,Total_neto,Tipo_de_liquidación", Now.ToString("yyMMddHHmmssfff") + ",'AUTOS EUROPA, S.A.'," + FN.Campo_tabla(Dr("Factura")) + "," + FN.Campo_tabla(Dr("Fecha")) + "," + FN.Campo_tabla(Dr("No_de_orden")) + "," + FN.Campo_tabla(Dr("Tipo_de_orden")) + "," + FN.Campo_tabla(Dr("Total_bruto")) + "," + FN.Campo_tabla(Dr("Descuento")) + "," + FN.Campo_tabla(Dr("IVA")) + "," + FN.Campo_tabla(Dr("Total_neto")) + "," + FN.Campo_tabla(Dr("Tipo_de_liquidación")))
                            End If
                        End If
                    Next

                End If
        End Select

    End Sub

End Class