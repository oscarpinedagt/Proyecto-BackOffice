Public Class Costeos_en_proceso
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Costeos_en_proceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = Text & " al " & Now
        Configurar_costeos_en_proceso()
    End Sub

    Private Sub TMR_Cerrar_notificación_Tick(sender As Object, e As EventArgs) Handles TMR_Cerrar_notificación.Tick
        Dispose()
    End Sub

    Private Sub Configurar_costeos_en_proceso()

        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                Else
                    CL.Caption = Replace(CL.FieldName, "_", " ")
                End If

                Select Case CL.FieldName
                    Case "Costeo_asignado_a", "Empresa", "Tipo_de_mercaderia", "Sub_empresa"
                        CL.Group()
                End Select

                Select Case CL.FieldName
                    Case "Dif_Rec_Ela", "Dif_Rec_Env"
                        CL.Caption = "Tiempo transcurrido en Hrs"
                End Select

                Select Case CL.FieldName
                    Case "Comentarios"
                        CL.Visible = False
                        .PreviewFieldName = CL.FieldName
                        .OptionsView.ShowPreview = True
                        .OptionsView.AutoCalcPreviewLineCount = True
                End Select

            Next
            AddHandler GridView.CustomDrawRowPreview, Sub(s, e)
                                                          e.Appearance.ForeColor = Color.Green
                                                      End Sub
            AddHandler GridView.RowCellStyle, Sub(s, e)
                                                  Dim CL As String = e.Column.FieldName
                                                  If CL = "Dif_Rec_Ela" Or CL = "Dif_Rec_Env" Then
                                                      Select Case GridView.GetRowCellValue(e.RowHandle, CL)
                                                          Case 0 To 4
                                                              e.Appearance.BackColor = Color.LightGreen
                                                          Case 4 To 6
                                                              e.Appearance.BackColor = Color.LightYellow
                                                          Case > 6
                                                              e.Appearance.BackColor = Color.LightCoral
                                                      End Select
                                                  End If
                                              End Sub
            AddHandler GridView.GroupLevelStyle, Sub(s, e)
                                                     Select Case e.Level
                                                         Case 0
                                                             e.LevelAppearance.ForeColor = Color.WhiteSmoke
                                                             e.LevelAppearance.BackColor = Color.LightSlateGray
                                                     End Select
                                                 End Sub

            .ExpandAllGroups()
            .OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.False
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub

End Class