Public Class Publicar
    Private Sub Publicar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BE_Directorio.EditValue = My.Settings.Directorio
        CK_Recordar_directorio.Checked = My.Settings.Recordar_directorio
    End Sub

    Private Sub BE_Directorio_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BE_Directorio.Properties.ButtonClick
        Dim FBD As New FolderBrowserDialog
        If FBD.ShowDialog = DialogResult.OK Then
            BE_Directorio.EditValue = FBD.SelectedPath
        End If
    End Sub

    Private Sub CK_Recordar_directorio_CheckedChanged(sender As Object, e As EventArgs) Handles CK_Recordar_directorio.CheckedChanged
        If CK_Recordar_directorio.Checked = True Then
            My.Settings.Directorio = BE_Directorio.Text
        Else
            My.Settings.Directorio = Nothing
        End If
        My.Settings.Recordar_directorio = CK_Recordar_directorio.Checked
        My.Settings.Save()
    End Sub

    Public Sub Actualizar_ejecutables(DirO As DirectoryInfo, DirD As DirectoryInfo)
        If Not DirD.Exists Then DirD.Create()
        Dim Ext As New List(Of String) From {"*.exe", "*.dll", "*.txt", "*.xlsx"}
        For Each FileO In My.Computer.FileSystem.GetFiles(DirO.FullName, FileIO.SearchOption.SearchAllSubDirectories, Ext.ToArray)
            If FileO <> Application.ExecutablePath Then
                Dim FileD As String = DirD.FullName & "\" & FileO.Remove(0, DirO.FullName.Length + 1)
                My.Computer.FileSystem.CopyFile(FileO, FileD, True)
            End If
        Next
    End Sub

    Private Sub SB_Publicar_Click(sender As Object, e As EventArgs) Handles SB_Publicar.Click
        ValidateChildren()
        Dim DirO As New DirectoryInfo(Application.StartupPath)
        Dim DirD As New DirectoryInfo(BE_Directorio.EditValue)
        CK_Recordar_directorio_CheckedChanged(Nothing, Nothing)
        Try
            Actualizar_ejecutables(DirO, DirD)
            MsgBox("Publicación exitosa", MsgBoxStyle.Information, "Publicación de aplicaciones")
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Publicación de aplicaciones")
        End Try
    End Sub
End Class