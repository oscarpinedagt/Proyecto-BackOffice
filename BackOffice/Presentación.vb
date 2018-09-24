Public Class Presentación
    Sub New()
        InitializeComponent()
        Dim Fecha() As String = Split(FormatDateTime(Now, vbLongDate), ",")
        Text = RegionInfo.CurrentRegion.NativeName & ", " & Fecha(1)
        Registrar_programa()
        TMR_Presentación.Enabled = True
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub Registrar_programa()
        Try
            Dim RK As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", True)
            If RK Is Nothing Then
                Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run")
            End If
            If RK.OpenSubKey("BackOffice.exe") Is Nothing Then
                RK.SetValue("BackOffice.exe", Application.ExecutablePath, RegistryValueKind.String)
            ElseIf RK.OpenSubKey("BackOffice.exe").Name <> Application.ExecutablePath Then
                RK.SetValue("BackOffice.exe", Application.ExecutablePath, RegistryValueKind.String)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Registro de programa")
        End Try
    End Sub

    Private Sub Actualizar_programa()
        Dim DirO As New DirectoryInfo(Application.StartupPath)
        Dim DirD As String = "C:\BackOffice"
        Try
            Actualizar_ejecutables(DirO.FullName, DirD)
            Dim FI As New FileInfo(DirD & "\BackOffice menú.exe")
            If FI.Exists Then
                Process.Start(FI.FullName, DirO.FullName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Ejecutar menú")
        End Try
    End Sub

    Private Sub Depurar_carpeta_local_BackOffice()
        Dim DI As New DirectoryInfo("C:\BackOffice")
        Dim FA As DateTime = Now.ToShortDateString
        For Each D As DirectoryInfo In DI.GetDirectories
            Dim FC As DateTime = D.CreationTime.ToShortDateString
            If DateDiff(DateInterval.Day, FC, FA) >= 2 Then
                Try
                    D.Delete(True)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Depuración de ejecutables")
                End Try
            End If
        Next
    End Sub

    Public Sub Actualizar_ejecutables(DirO As String, DirD As String)
        Dim DI As New DirectoryInfo(DirD)
        If Not DI.Exists Then DI.Create()
        Dim Ext As New List(Of String) From {"*.*"}
        For Each FileO In My.Computer.FileSystem.GetFiles(DirO, FileIO.SearchOption.SearchAllSubDirectories, Ext.ToArray)
            If FileO <> Application.ExecutablePath Then
                Dim FileD As String = DirD & "\" & FileO.Remove(0, DirO.Length + 1)
                My.Computer.FileSystem.CopyFile(FileO, FileD, True)
            End If
        Next
    End Sub

    Private Sub TMR_Presentación_Tick(sender As Object, e As EventArgs) Handles TMR_Presentación.Tick
        Actualizar_programa()
        Depurar_carpeta_local_BackOffice()
        End
    End Sub

End Class
