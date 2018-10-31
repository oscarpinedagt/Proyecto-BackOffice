Public Class Presentación

    Sub New()
        InitializeComponent()
        Dim Fecha() As String = Now.ToLongDateString.Split(",")
        LC_Información.Text = RegionInfo.CurrentRegion.NativeName & ", " & Fecha(1)
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
        Dim DirD As New DirectoryInfo("C:\BackOffice")
        Try
            Actualizar_ejecutables(DirO, DirD)
            Dim FI As New FileInfo(DirD.FullName & "\BackOffice menú.exe")
            If FI.Exists Then
                Process.Start(FI.FullName, DirO.FullName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Ejecutar menú")
        End Try
    End Sub

    Public Sub Actualizar_ejecutables(DirO As DirectoryInfo, DirD As DirectoryInfo)
        If Not DirD.Exists Then DirD.Create()
        Dim Ext As New List(Of String) From {"*.*"}
        For Each FileO In My.Computer.FileSystem.GetFiles(DirO.FullName, FileIO.SearchOption.SearchAllSubDirectories, Ext.ToArray)
            If FileO <> Application.ExecutablePath Then
                Dim FileD As String = DirD.FullName & "\" & FileO.Remove(0, DirO.FullName.Length + 1)
                My.Computer.FileSystem.CopyFile(FileO, FileD, True)
            End If
        Next
    End Sub

    Private Sub TMR_Presentación_Tick(sender As Object, e As EventArgs) Handles TMR_Presentación.Tick
        TMR_Presentación.Enabled = False
        Actualizar_programa()
        End
    End Sub

End Class
