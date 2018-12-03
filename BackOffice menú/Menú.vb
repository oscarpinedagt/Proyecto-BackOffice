Public Class Menú
    Dim WithEvents FSW As New FileSystemWatcher
    Dim SQL As New BackOffice_datos.SQL
    Dim Arg() As String = Command$().Split("/"), DI As DirectoryInfo
    Dim IDF As New BackOffice_información_de_archivos.Información_de_archivos

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

            DI = New DirectoryInfo(Arg(0))

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
        Dim CEP As New BackOffice_servicios.Costeos_en_proceso
        Dim DT As DataTable = SQL.Tabla_de_datos("SELECT Costeo_asignado_a,Empresa,Tipo_de_mercaderia,Sub_empresa,Tipo_de_importacion,Compra,Ingreso_a_bodega,Fecha_de_recepcion,Elaborado,Dif_Rec_Ela,Enviado,Dif_Rec_Env,Comentarios From Costeos Where Recibido='True' And ((Elaborado='False' or Elaborado Is Null) Or (Enviado='False' or Enviado Is Null)) And (Fecha_de_ingreso_a_bodega>= GETDATE()-60) Order By Ingreso_a_bodega")
        If DT.Rows.Count > 0 Then
            CEP.GridControl.DataSource = DT
            CEP.Show()
        End If
    End Sub

    Private Function Listar_procesos(Directorio As String) As Integer
        Dim i As Integer = 0

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

    Private Sub MI_Información_de_archivos_Click(sender As Object, e As EventArgs) Handles MI_Información_de_archivos.Click
        Dim SEG As New BackOffice_servicios.Contraseña With {.Nombre_de_contraseña = "Información de archivos"}
        SEG.ShowDialog()
        If SEG.Resultado = True Then
            IDF.Show()
        End If
        SEG.Dispose()
    End Sub
End Class
