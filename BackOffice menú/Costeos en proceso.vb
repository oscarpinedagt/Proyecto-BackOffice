Public Class Costeos_en_proceso

    Private Sub Costeos_en_proceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = Text & " - " & Convert.ToDateTime(Now)
    End Sub

    Private Sub TMR_Cerrar_notificación_Tick(sender As Object, e As EventArgs) Handles TMR_Cerrar_notificación.Tick
        Dispose()
    End Sub

End Class