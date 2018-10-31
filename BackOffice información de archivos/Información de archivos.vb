Public Class Información_de_archivos
    Dim WithEvents FSW As New FileSystemWatcher, DI As DirectoryInfo
    Dim SQL As New BackOffice_datos.SQL

    Private Sub Información_de_archivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BE_Directorio.EditValue = My.Settings.Directorio
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
                .EnableRaisingEvents = CK_Activar_monitoreo_de_archivos.Checked
                If CK_Activar_monitoreo_de_archivos.Checked = True Then
                    BE_Directorio.Enabled = False
                    AddHandler .Created, AddressOf OnChanged
                    AddHandler .Changed, AddressOf OnChanged
                    AddHandler .Deleted, AddressOf OnChanged
                    AddHandler .Renamed, AddressOf OnRenamed
                Else
                    BE_Directorio.Enabled = True
                End If
            End With
        End If

    End Sub

    Private Sub OnChanged(sender As Object, e As FileSystemEventArgs)
        Dim FI As New FileInfo(e.FullPath)
        Select Case e.ChangeType

            Case WatcherChangeTypes.Created
                If FI.Exists And FI.Name.IndexOf("-") > 0 Then
                    Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")
                    Dim FS As FileSecurity = FI.GetAccessControl
                    Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
                    Dim Datos_propietario() As String = Propietario.ToString.Split("\")

                    SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName + "'", "(Elaborado<>'True' Or Elaborado Is Null) And Ingreso_a_bodega='" + TDoc(1) + "'")

                End If

            Case WatcherChangeTypes.Changed
                If FI.Exists And FI.Name.IndexOf("-") > 0 Then
                    Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")
                    Dim FS As FileSecurity = FI.GetAccessControl
                    Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
                    Dim Datos_propietario() As String = Propietario.ToString.Split("\")

                    SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName + "'", "(Elaborado<>'True' Or Elaborado Is Null) And Ingreso_a_bodega='" + TDoc(1) + "'")

                End If

            Case WatcherChangeTypes.Deleted
                If Not FI.Exists And FI.Name.IndexOf("-") > 0 Then
                    Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")

                    SQL.Actualizar("Costeos", "Compra=NULL,Elaborado='False',Fecha_de_elaboracion=NULL,Usuario_que_elabora=NULL,Archivo=NULL", "Compra='" + TDoc(0) + "' And Ingreso_a_bodega='" + TDoc(1) + "'")

                End If

        End Select
    End Sub
    Private Sub OnRenamed(sender As Object, e As RenamedEventArgs)
        Dim FI As New FileInfo(e.FullPath)
        If FI.Exists And FI.Name.IndexOf("-") > 0 Then
            Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")
            Dim FS As FileSecurity = FI.GetAccessControl
            Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
            Dim Datos_propietario() As String = Propietario.ToString.Split("\")

            SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName + "'", "(Elaborado<>'True' Or Elaborado Is Null) And Ingreso_a_bodega='" + TDoc(1) + "'")

        End If
    End Sub

    Private Sub Información_de_archivos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Hide()
    End Sub
End Class