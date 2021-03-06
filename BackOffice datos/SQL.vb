﻿Public Class SQL
    Dim Conexion As New SqlConnection("Data Source=" + My.Settings.Servidor + ";Initial Catalog=" + My.Settings.Base_de_datos + ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Dim DA As SqlDataAdapter, CB As SqlCommandBuilder, DT As DataTable

    Public Function Insertar(Tabla As String, Campos As String, Valores As String, Optional Imágen_a_Byte As Byte() = Nothing) As Boolean
        Dim i As Integer
        Try
            Dim Insertar_datos As New SqlCommand("Insert InTo " + Tabla + " (" + Campos + ") Values (" + Valores + ")", Conexion)
            Conexion.Open()
            If Not IsNothing(Imágen_a_Byte) Then
                Insertar_datos.Parameters.Add("Imágen", SqlDbType.Image).Value = Imágen_a_Byte
            End If
            i = Insertar_datos.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Insertar datos")
        Finally
            Conexion.Close()
        End Try

        If i > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Actualizar(Tabla As String, Campos As String, Condición As String, Optional Imágen_a_Byte As Byte() = Nothing) As Boolean
        Dim i As Integer
        Try
            Dim Actualizar_datos As New SqlCommand("Update " + Tabla + " Set " + Campos + " Where " + Condición, Conexion)
            Conexion.Open()
            If Not IsNothing(Imágen_a_Byte) Then
                Actualizar_datos.Parameters.Add("Imágen", SqlDbType.Image).Value = Imágen_a_Byte
            End If
            i = Actualizar_datos.ExecuteNonQuery
        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Actualizar datos")
        Finally
            Conexion.Close()
        End Try

        If i > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Eliminar(Tabla As String, Condición As String) As Boolean
        Dim i As Integer
        Try
            Dim Eliminar_datos As New SqlCommand("Delete From " + Tabla + " Where " + Condición, Conexion)
            Conexion.Open()
            i = Eliminar_datos.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Eliminar datos")
        Finally
            Conexion.Close()
        End Try

        If i > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Tabla_de_datos(SQL_consulta As String) As DataTable
        Dim DA As New SqlDataAdapter(SQL_consulta, Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        Return DT
    End Function

    Public Function Tabla_con_actualización_de_datos(SQL_consulta As String) As DataTable
        DA = New SqlDataAdapter(SQL_consulta, Conexion)
        CB = New SqlCommandBuilder(DA) With {.ConflictOption = ConflictOption.OverwriteChanges}
        DT = New DataTable
        DA.Fill(DT)
        Return DT
    End Function

    Public Sub Actualizar_tabla()
        Try
            If DT.Rows.Count > 0 Then
                DA.Update(DT)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Actualización tabla de datos")
        End Try
    End Sub

    Public Function Tabla_de_datos_desde_Excel(Archivo As String, OLDB_consulta_V12 As String) As DataTable
        Dim Conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Archivo + "; Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1;""")
        Dim DA As New OleDbDataAdapter(OLDB_consulta_V12, Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        Return DT
    End Function

    Public Function Nuevo_ID(Nombre_de_columna_ID As String, Tabla As String, Optional Condición As String = Nothing) As Int32
        Dim DA As New SqlDataAdapter("Select IsNull(Max(" + Nombre_de_columna_ID + "),0)+1 As Nuevo_ID From " + Tabla + " " + Condición, Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        Return Convert.ToInt32(DT.Rows(0)("Nuevo_ID"))
    End Function

    Public Function Nuevo_ID_alfanumerico(Nombre_de_columna_ID As String, Extraer As String, Tabla As String, Optional Condición As String = Nothing) As Int32
        Dim DA As New SqlDataAdapter("Select IsNull(Max(CONVERT(INT,SubString(" + Nombre_de_columna_ID + "," + Extraer + "))),0)+1 As Nuevo_ID From " + Tabla + " " + Condición, Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        Return Convert.ToInt32(DT.Rows(0)("Nuevo_ID"))
    End Function

    Public Function Extraer_informacion_de_columna(Nombre_de_columna As String, Tabla As String, Optional Condicion As String = Nothing) As String
        Dim DA As New SqlDataAdapter("Select " + Nombre_de_columna + " As Selección From " + Tabla + " " + Condicion, Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            Return DT.Rows(0)("Selección").ToString
        Else
            Return Nothing
        End If
    End Function

    Public Function Seguridad(Nombre_de_contraseña As String, Contraseña As String, Tabla As String, Columna_condicion As String) As Boolean
        Dim DA As New SqlDataAdapter("Select IsNull(Count(*),0) As Validar From " + Tabla + " Where " + Columna_condicion + " = '" + Nombre_de_contraseña + "' And Contraseña='" + Contraseña + "' COLLATE SQL_Latin1_General_CP1_CS_AS", Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        If Convert.ToInt32(DT.Rows(0)("Validar")) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Duplicados(Tabla As String, Condición As String) As Boolean
        Dim DA As New SqlDataAdapter("Select IsNull(Count(*),0) As Validar From " + Tabla + " " + Condición, Conexion)
        Dim DT As New DataTable
        DA.Fill(DT)
        If Convert.ToInt32(DT.Rows(0)("Validar")) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function BackUpBD() As Boolean
        Dim i As Integer
        Try
            Dim Insertar_datos As New SqlCommand("BackUp DataBase BackOffice To Disk = 'C:\BackOffice BackUp BD\BackUp " + Now.ToString("yyMMddHHmm") + "'", Conexion)
            Conexion.Open()
            i = Insertar_datos.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Crear BackUp")
        Finally
            Conexion.Close()
        End Try

        If i > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
