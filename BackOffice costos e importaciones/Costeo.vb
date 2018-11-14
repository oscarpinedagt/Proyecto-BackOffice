Public Class Costeo

    Public Property Id_costeo As String

    Private Sub Costeo_DataSourceDemanded(sender As Object, e As EventArgs) Handles MyBase.DataSourceDemanded
        TA_Costeos.GetData(Id_costeo)
        TA_Documentos_del_exterior.GetData(Id_costeo)
        TA_Documentos_locales.GetData(Id_costeo)
        TA_Seguro.GetData(Id_costeo)
        Parameters("ID").Value = Id_costeo
    End Sub

End Class