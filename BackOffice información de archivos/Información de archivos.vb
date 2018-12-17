Public Class Información_de_archivos
    Dim WithEvents FSW As New FileSystemWatcher, DI As DirectoryInfo
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Información_de_archivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BE_Directorio.EditValue = My.Settings.Directorio
        DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True
        Datos()
    End Sub

    Private Sub BE_Directorio_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BE_Directorio.Properties.ButtonClick
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog = DialogResult.OK Then
            BE_Directorio.EditValue = FBD.SelectedPath
        End If
    End Sub

    Private Sub CK_Activar_monitoreo_de_archivos_CheckedChanged(sender As Object, e As EventArgs) Handles CK_Activar_monitoreo_de_archivos.CheckedChanged
        ValidateChildren()
        DI = New DirectoryInfo(BE_Directorio.EditValue)
        If DI.Exists Then
            My.Settings.Directorio = DI.FullName
            My.Settings.Save()

            With FSW
                .Path = DI.FullName
                .IncludeSubdirectories = True
                .Filter = "*.PDF"
                If CK_Activar_monitoreo_de_archivos.Checked = True Then
                    BE_Directorio.Enabled = False
                    AddHandler .Created, AddressOf OnChanged
                    AddHandler .Changed, AddressOf OnChanged
                    AddHandler .Deleted, AddressOf OnChanged
                    AddHandler .Renamed, AddressOf OnRenamed
                Else
                    BE_Directorio.Enabled = True
                End If
                .EnableRaisingEvents = CK_Activar_monitoreo_de_archivos.Checked
            End With
        End If

    End Sub

    Private Sub OnChanged(sender As Object, e As FileSystemEventArgs)
        Dim FI As New FileInfo(e.FullPath)

        Try
            FSW.EnableRaisingEvents = False
            Select Case e.ChangeType

                Case WatcherChangeTypes.Created

                    If FI.Exists And FI.Name.IndexOf("-") > 0 Then
                        Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")
                        Dim FS As FileSecurity = FI.GetAccessControl
                        Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
                        Dim Datos_propietario() As String = Propietario.ToString.Split("\")

                        DTS(TDoc(0), TDoc(1), "Creado", FI.LastWriteTime.ToString, UCase(Datos_propietario(1)), FI.FullName)
                        SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName + "'", "(Elaborado<>'True' Or Elaborado Is Null) And Ingreso_a_bodega='" + TDoc(1) + "' And Estado<>'Anulado'")

                    End If

                Case WatcherChangeTypes.Changed

                    If FI.Exists And FI.Name.IndexOf("-") > 0 Then
                        Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")
                        Dim FS As FileSecurity = FI.GetAccessControl
                        Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
                        Dim Datos_propietario() As String = Propietario.ToString.Split("\")

                        DTS(TDoc(0), TDoc(1), "Cambio", FI.LastWriteTime.ToString, UCase(Datos_propietario(1)), FI.FullName)
                        SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName + "'", "(Elaborado<>'True' Or Elaborado Is Null) And Ingreso_a_bodega='" + TDoc(1) + "' And Estado<>'Anulado'")

                    End If

                Case WatcherChangeTypes.Deleted

                    If Not FI.Exists And FI.Name.IndexOf("-") > 0 Then
                        Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")

                        DTS(TDoc(0), TDoc(1), "Eliminado", Nothing, Nothing, FI.FullName)
                        SQL.Actualizar("Costeos", "Compra=NULL,Elaborado='False',Fecha_de_elaboracion=NULL,Usuario_que_elabora=NULL,Archivo=NULL", "Compra='" + TDoc(0) + "' And Ingreso_a_bodega='" + TDoc(1) + "'")

                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            FSW.EnableRaisingEvents = True
        End Try

    End Sub
    Private Sub OnRenamed(sender As Object, e As RenamedEventArgs)
        Dim FI As New FileInfo(e.FullPath)
        If FI.Exists And FI.Name.IndexOf("-") > 0 Then
            Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")
            Dim FS As FileSecurity = FI.GetAccessControl
            Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
            Dim Datos_propietario() As String = Propietario.ToString.Split("\")

            DTS(TDoc(0), TDoc(1), "Renombrado", FI.LastWriteTime.ToString, UCase(Datos_propietario(1)), FI.FullName)
            SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName + "'", "(Elaborado<>'True' Or Elaborado Is Null) And Ingreso_a_bodega='" + TDoc(1) + "' And Estado<>'Anulado'")

        End If
    End Sub

    Private Sub Información_de_archivos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Hide()
    End Sub


    Private Sub Datos()
        Dim DT As New DataTable
        DT.Columns.Add("Compra", GetType(String))
        DT.Columns.Add("Ingreso", GetType(String))
        DT.Columns.Add("Estado", GetType(String))
        DT.Columns.Add("Fecha_de_elaboracion", GetType(DateTime))
        DT.Columns.Add("Usuario_que_elabora", GetType(String))
        DT.Columns.Add("Archivo", GetType(String))

        GridControl.DataSource = DT

        With GridView
            For Each CL As DevExpress.XtraGrid.Columns.GridColumn In .Columns
                CL.Caption = Replace(CL.FieldName, "_", " ")

                If CL.FieldName.ToString.Contains("Fecha") Then
                    CL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    CL.DisplayFormat.FormatString = "g"
                End If

            Next
            .OptionsView.ColumnAutoWidth = False
            .BestFitColumns()
        End With

    End Sub


    Private Sub DTS(Dt1 As String, Dt2 As String, Dt3 As String, Dt4 As DateTime, Dt5 As String, Dt6 As String)
        GridView.AddNewRow()
        Dim Dr As Integer = GridView.GetRowHandle(GridView.DataRowCount)
        If GridView.IsNewItemRow(Dr) Then
            GridView.SetRowCellValue(Dr, "Compra", Dt1)
            GridView.SetRowCellValue(Dr, "Ingreso", Dt2)
            GridView.SetRowCellValue(Dr, "Estado", Dt3)
            GridView.SetRowCellValue(Dr, "Fecha_de_elaboracion", Dt4)
            GridView.SetRowCellValue(Dr, "Usuario_que_elabora", Dt5)
            GridView.SetRowCellValue(Dr, "Archivo", Dt6)
        End If
    End Sub

End Class