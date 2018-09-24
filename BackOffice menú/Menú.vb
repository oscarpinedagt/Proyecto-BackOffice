Public Class Menú
    Dim SQL As New BackOffice_datos.SQL
    Dim WithEvents FSW As New FileSystemWatcher
    Dim Arg() As String = Split(Command$(), "/")
    Dim Info As New BackOffice_información_de_archivos.Información_de_archivos

    Sub New()
        InitializeComponent()
        Me.progressPanel.AutoHeight = True
        Monitor_de_actualizaciones()
    End Sub

    Public Overrides Sub SetCaption(ByVal caption As String)
        MyBase.SetCaption(caption)
        Me.progressPanel.Caption = caption
    End Sub

    Public Overrides Sub SetDescription(ByVal description As String)
        MyBase.SetDescription(description)
        Me.progressPanel.Description = description
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum WaitFormCommand
        SomeCommandId
    End Enum

    Sub Monitor_de_actualizaciones()
        If Arg(0) <> "" Then
            Dim DI As New DirectoryInfo(Arg(0))
            With FSW
                .Path = DI.FullName
                .IncludeSubdirectories = True
                .Filter = "*.*"
                .EnableRaisingEvents = True
                AddHandler .Created, AddressOf OnChanged
                AddHandler .Changed, AddressOf OnChanged
                AddHandler .Deleted, AddressOf OnChanged
                AddHandler .Renamed, AddressOf OnRenamed
            End With
        End If
    End Sub

    Private Sub OnChanged(sender As Object, e As FileSystemEventArgs)
        My.Settings.Actualizaciones += 1
    End Sub

    Private Sub OnRenamed(sender As Object, e As RenamedEventArgs)
        My.Settings.Actualizaciones += 1
    End Sub

    Private Sub TMR_BackOffice_menú_Tick(sender As Object, e As EventArgs) Handles TMR_BackOffice_menú.Tick
        Hide()
        NTI_BackOffice_menú.Visible = True
        TMR_BackOffice_menú.Dispose()
    End Sub

    Private Sub CMS_BackOffice_menú_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMS_BackOffice_menú.Opening
        If My.Settings.Actualizaciones > 0 Then
            If MsgBox("Hay actualizaciones disponibles, deseas instalarlas", MsgBoxStyle.YesNo, "Actualizaciones BackOffice") = MsgBoxResult.Yes Then
                If Listar_procesos("C:\BackOffice") = 0 Then
                    NTI_BackOffice_menú.Dispose()
                    If Arg(0) <> "" Then
                        Dim DI As New DirectoryInfo(Arg(0))
                        Process.Start(DI.FullName + "\BackOffice.exe")
                    End If
                    My.Settings.Actualizaciones = 0
                    End
                Else
                    MsgBox("Verifica tu trabajo y cierra las aplicaciones abiertas para completar la actualización", MsgBoxStyle.Information, "Actualizaciones BackOffice")
                End If
            End If
        End If
    End Sub
    Private Sub MI_Salir_Click(sender As Object, e As EventArgs) Handles MI_Salir.Click
        End
    End Sub
    Private Sub MI_Configuración_Click(sender As Object, e As EventArgs) Handles MI_Configuración.Click
        Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Configuración"}
        SEG.ShowDialog()
        If SEG.Resultado = True Then
            Dim FI As New FileInfo(Application.StartupPath + "\BackOffice configuración.exe")
            If FI.Exists Then
                Process.Start(FI.FullName, "True")
            End If
            SEG.Dispose()
        End If
    End Sub
    Private Sub MI_Costos_e_Importaciones_Click(sender As Object, e As EventArgs) Handles MI_Costos_e_Importaciones.Click
        Dim IDS As New BackOffice_servicios.Inicio_de_sesión
        IDS.ShowDialog()
        If IDS.Resultado = True Then
            Dim FI As New FileInfo(Application.StartupPath + "\BackOffice costos e importaciones.exe")
            If FI.Exists Then
                Process.Start(FI.FullName, "True/" + IDS.Usuario)
            End If
            IDS.Dispose()
        End If
    End Sub
    Private Sub TRM_Costeos_en_proceso_Tick(sender As Object, e As EventArgs) Handles TRM_Costeos_en_proceso.Tick
        Costeos_pendientes()
    End Sub

    Private Function Listar_procesos(Directorio As String) As Int32
        Dim i As Int32 = 0

        Dim Ext As New List(Of String) From {"*.exe", "*.dll", "*.txt", "*.xlsx"}
        For Each File In My.Computer.FileSystem.GetFiles(Directorio, FileIO.SearchOption.SearchAllSubDirectories, Ext.ToArray)
            Dim FI As New FileInfo(File)
            Dim Proceso As Process() = Process.GetProcessesByName(Replace(FI.Name, FI.Extension, ""))
            If Proceso.Length > 0 And Replace(FI.Name, FI.Extension, "") <> "BackOffice menú" Then
                i += 1
            End If
        Next

        Return i
    End Function

    Private Sub Costeos_pendientes()
        Dim MyString As New StringBuilder()
        Dim DT_usuario As DataTable = Sql.Tabla_de_datos("SELECT Costeo_asignado_a From Costeos Where Recibido='True' And (Elaborado='False' or Elaborado Is Null) GROUP BY Costeo_asignado_a")
        If DT_usuario.Rows.Count > 0 Then
            For Each DR_usuario As DataRow In DT_usuario.Rows
                MyString.AppendLine(StrDup(165, "-"))
                MyString.AppendLine("[ " + DR_usuario("Costeo_asignado_a").ToString + " ]")
                Dim DT_datos As DataTable = SQL.Tabla_de_datos("Select Empresa,Tipo_de_mercaderia,Sub_empresa,COUNT(ISNULL(Sub_empresa,0)) AS No_Elaborados From Costeos Where Costeo_asignado_a='" + DR_usuario("Costeo_asignado_a").ToString + "' And  Recibido='True' And (Elaborado='False' Or Elaborado Is Null) GROUP BY Empresa,Tipo_de_mercaderia,Sub_empresa")
                For Each DR_datos As DataRow In DT_datos.Rows
                    MyString.AppendLine("[ " + DR_datos("Empresa").ToString + " | " + DR_datos("Tipo_de_mercaderia").ToString + " | " + DR_datos("Sub_empresa").ToString + " ]")
                    MyString.AppendLine("[ No elaborados: " + String.Format("{0:#,#00}", DR_datos("No_Elaborados").ToString) + " ]")
                    Dim DT_detalle As DataTable = SQL.Tabla_de_datos("SELECT Ingreso_a_bodega,Dif_Rec_Ela From Costeos Where Costeo_asignado_a='" + DR_usuario("Costeo_asignado_a").ToString + "' And Empresa='" + DR_datos("Empresa").ToString + "' And Tipo_de_mercaderia ='" + DR_datos("Tipo_de_mercaderia").ToString + "' And Sub_empresa='" + DR_datos("Sub_empresa").ToString + "' And Recibido='True' And (Elaborado='False' Or Elaborado Is Null)")
                    For Each DR_detalle As DataRow In DT_detalle.Rows
                        MyString.AppendLine("[ Ingreso a bodega: " + DR_detalle("Ingreso_a_bodega").ToString + " | Tiempo transcurrido: " + String.Format("{0:#,#00.00}", DR_detalle("Dif_Rec_Ela").ToString) + " Hrs. ]")
                    Next
                Next
                MyString.AppendLine(StrDup(165, "-"))
            Next
        End If

        If MyString.Length > 0 Then
            Costeos_en_proceso.RTBX_Costeos_en_proceso.Text = MyString.ToString
            Costeos_en_proceso.Show()
        End If

    End Sub

    Private Sub MI_Información_de_archivos_Click(sender As Object, e As EventArgs) Handles MI_Información_de_archivos.Click
        Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Información de archivos"}
        SEG.ShowDialog()
        If SEG.Resultado = True Then
            Info.Show()
        End If
        SEG.Dispose()
    End Sub
End Class
