Public Class Funciones
    Dim SQL As New BackOffice_datos.SQL

    Public Usuario As String = Environment.UserName
    Public IDPC As String = My.Computer.Name
    Public IP As String = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString

    Public Function Imágen_a_Bytes(Imágen As Image) As Byte()
        Dim Ancho As Integer = 100, Alto As Integer = Math.Floor((100 / Imágen.Width) * Imágen.Height)
        Dim BM As New Bitmap(Ancho, Alto)
        Dim GPS As Graphics = Graphics.FromImage(BM)
        GPS.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        GPS.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        GPS.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        Dim RTG As New Rectangle(0, 0, Ancho, Alto)
        GPS.DrawImage(Imágen, RTG)
        Dim MS As New MemoryStream()
        Imágen.Save(MS, ImageFormat.Png)
        Return MS.GetBuffer
    End Function

    Public Function Bytes_a_Imágen(Bytes As Byte()) As Image
        Dim MS As New MemoryStream(Bytes)
        Return Image.FromStream(MS)
    End Function

    Public Sub Abrir_formulario(Formulario_contenedor As Form, Formulario As Form)
        Dim Abierto As Boolean = False
        For Each FRM As Form In Application.OpenForms
            If Formulario.Name = FRM.Name Then Abierto = True
        Next
        If Abierto = True Then
            Formulario.Activate()
        Else
            Formulario.MdiParent = Formulario_contenedor
            Formulario.Show()
        End If
    End Sub

    Public Sub Crear_archivo_txt(Nombre_de_archivo As String, Texto As String)
        Dim FS As FileStream = File.Create(Nombre_de_archivo & ".txt")
        Dim TXT As Byte() = New UTF8Encoding(True).GetBytes(Texto)
        FS.Write(TXT, 0, TXT.Length)
        FS.Dispose()
    End Sub

    Public Function Leer_archivo_txt(Nombre_de_archivo As String, Buscar_texto As String)
        Dim Resultado As String = ""
        Dim SR As New StreamReader(Nombre_de_archivo & ".txt")
        Dim Texto As String = ""
        Do While SR.Peek() <> -1
            Texto = SR.ReadLine()
            If Texto.Contains(Buscar_texto) Then
                Resultado = Texto
            End If
        Loop
        SR.Dispose()
        Return Resultado
    End Function

    Public Sub Estado_del_menú(Estado As String, Control As DevExpress.XtraBars.BarManager)
        For Each CTRL As DevExpress.XtraBars.BarButtonItem In Control.Items
            Select Case Estado
                Case "Nuevo"
                    If CTRL.Name = "BBI_Nuevo" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Cargar_datos_costeo_vehiculos" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Guardar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Guardar_y_seguir" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Guardar_y_limpiar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Cancelar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Editar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Eliminar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Buscar" Then CTRL.Enabled = True
                Case "Guardar"
                    If CTRL.Name = "BBI_Nuevo" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Cargar_datos_costeo_vehiculos" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Guardar" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Guardar_y_seguir" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Guardar_y_limpiar" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Cancelar" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Editar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Eliminar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Buscar" Then CTRL.Enabled = False
                Case "Guardar y Cancelar"
                    If CTRL.Name = "BBI_Nuevo" Then CTRL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    If CTRL.Name = "BBI_Guardar" Then CTRL.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    If CTRL.Name = "BBI_Cancelar" Then CTRL.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    If CTRL.Name = "BBI_Editar" Then CTRL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    If CTRL.Name = "BBI_Eliminar" Then CTRL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    If CTRL.Name = "BBI_Buscar" Then CTRL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                Case "Buscar"
                    If CTRL.Name = "BBI_Nuevo" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Cargar_datos_costeo_vehiculos" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Guardar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Guardar_y_seguir" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Guardar_y_limpiar" Then CTRL.Enabled = False
                    If CTRL.Name = "BBI_Cancelar" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Editar" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Eliminar" Then CTRL.Enabled = True
                    If CTRL.Name = "BBI_Buscar" Then CTRL.Enabled = True
            End Select
        Next
    End Sub

    Public Sub Limpiar_controles(Control As Control)
        For Each CTRL As Control In Control.Controls
            If TypeOf CTRL Is DevExpress.XtraEditors.BaseEdit Then
                Dim CL As DevExpress.XtraEditors.BaseEdit = DirectCast(CTRL, DevExpress.XtraEditors.BaseEdit)
                CL.EditValue = Nothing
            ElseIf TypeOf CTRL Is RichTextBox Then
                Dim CL As RichTextBox = DirectCast(CTRL, RichTextBox)
                CL.Clear()
            End If
        Next
    End Sub

    Public Sub Deshabilitar_controles(Control As Control)
        For Each CTRL As Control In Control.Controls
            If TypeOf CTRL Is DevExpress.XtraEditors.BaseEdit Then
                Dim CL As DevExpress.XtraEditors.BaseEdit = DirectCast(CTRL, DevExpress.XtraEditors.BaseEdit)
                CL.ReadOnly = True
            ElseIf TypeOf CTRL Is DevExpress.XtraEditors.SimpleButton Then
                Dim CL As DevExpress.XtraEditors.SimpleButton = DirectCast(CTRL, DevExpress.XtraEditors.SimpleButton)
                CL.Enabled = False
            ElseIf TypeOf CTRL Is RichTextBox Then
                Dim CL As RichTextBox = DirectCast(CTRL, RichTextBox)
                CL.ReadOnly = True
            End If
        Next
    End Sub

    Public Sub Habilitar_controles(Control As Control)
        For Each CTRL As Control In Control.Controls
            If TypeOf CTRL Is DevExpress.XtraEditors.BaseEdit Then
                Dim CL As DevExpress.XtraEditors.BaseEdit = DirectCast(CTRL, DevExpress.XtraEditors.BaseEdit)
                If CL.BackColor.Name <> "Info" Then CL.ReadOnly = False
            ElseIf TypeOf CTRL Is DevExpress.XtraEditors.SimpleButton Then
                Dim CL As DevExpress.XtraEditors.SimpleButton = DirectCast(CTRL, DevExpress.XtraEditors.SimpleButton)
                CL.Enabled = True
            ElseIf TypeOf CTRL Is RichTextBox Then
                Dim CL As RichTextBox = DirectCast(CTRL, RichTextBox)
                CL.ReadOnly = False
            End If
        Next
    End Sub

    Public Sub Validar_controles(Control As Control)
        For Each CTRL As Control In Control.Controls
            If TypeOf CTRL Is DevExpress.XtraEditors.BaseEdit Then
                Dim CL As DevExpress.XtraEditors.BaseEdit = DirectCast(CTRL, DevExpress.XtraEditors.BaseEdit)
                CL.IsModified = True
                CL.DoValidate()
            End If
        Next
    End Sub

    Public Sub Validar_campos(ByVal Control As DevExpress.XtraEditors.BaseEdit, Texto As String, EP As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider)
        If (Control.EditValue Is Nothing OrElse Control.Text.Trim().Length = 0) And Control.ReadOnly = False Then
            EP.SetError(Control, Texto, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information)
        Else
            EP.SetError(Control, Nothing)
        End If
    End Sub

    Public Sub Validar_fechas(sender As Object, e As CancelEventArgs)
        Dim TE As DevExpress.XtraEditors.TextEdit = sender

        If TE.Text = "" Then
            e.Cancel = False
        ElseIf IsDate(Left(TE.Text, 10)) And Right(TE.Text, 5) = "00:00" Then
            e.Cancel = False
            TE.EditValue = Convert.ToDateTime(Left(TE.Text, 10) + " 08:00")
        ElseIf IsDate(TE.Text) Then
            e.Cancel = False
        Else
            e.Cancel = True
            MsgBox("Ingresa una fecha y hora valida")
            TE.EditValue = Nothing
        End If

    End Sub

    Public Function Cargar_nodos(TreeList As TreeView, Ruta As String) As Boolean
        Dim Nivel() As String = Ruta.Split("\")
        Dim NodoPrincipal As TreeNode = Nothing
        Dim Recorrer As String = Nivel(0)
        For NodoIndice As Integer = 0 To (Nivel.Length - 1)
            If NodoPrincipal IsNot Nothing Then
                Recorrer = NodoPrincipal.FullPath & "\" & Nivel(NodoIndice)
            End If
            Dim NodoExistente() As TreeNode = TreeList.Nodes.Find(Recorrer, True)
            If NodoExistente.Length <= 0 Then
                Dim NodoRuta = New TreeNode(Nivel(NodoIndice))
                If NodoPrincipal Is Nothing Then
                    NodoPrincipal = TreeList.Nodes.Add(Recorrer, Nivel(NodoIndice))
                Else
                    NodoPrincipal = NodoPrincipal.Nodes.Add(Recorrer, Nivel(NodoIndice))
                End If
            Else
                NodoPrincipal = NodoExistente(0)
            End If
        Next
        Return True
    End Function

    Public Function Quitar_espacios_innecesarios(Texto As String)
        Texto = Regex.Replace(Texto, " {2,}", " ")
        Texto = Trim(Texto)
        Return Texto
    End Function

    Public Sub Propiedades_de_archivos(Directorio As String, Fecha As DateTime, Generar_archivo As Boolean)
        Try
            Dim SB As New StringBuilder()
            If Generar_archivo = True Then
                SB.Append("").Append("""" + "Compra" + """")
                SB.Append(",").Append("""" + "Ingreso a bodega" + """")
                SB.Append(",").Append("""" + "Usuario" + """")
                SB.Append(",").Append("""" + "Fecha de modificación" + """")
                SB.Append(Environment.NewLine)
            End If
            Dim Extension As New List(Of String) From {"*.pdf", "*.xls", "*.xlsx", "*.xlsm"}
            For Each Archivo In My.Computer.FileSystem.GetFiles(Directorio, FileIO.SearchOption.SearchAllSubDirectories, Extension.ToArray)
                Dim FI As New FileInfo(Archivo)
                Dim FS As FileSecurity = FI.GetAccessControl
                Dim Propietario As NTAccount = CType(FS.GetOwner(GetType(NTAccount)), NTAccount)
                Dim Datos_propietario() As String = Propietario.ToString.Split("\")
                Dim TDoc() As String = Replace(FI.Name, FI.Extension, "").Split("-")

                If FI.Name.IndexOf("-") > 0 And FI.LastWriteTime >= Fecha Then
                    If Generar_archivo = True Then
                        SB.Append("").Append("""" + TDoc(0) + """")
                        SB.Append(",").Append("""" + TDoc(1) + """")
                        SB.Append(",").Append("""" + UCase(Datos_propietario(1)) + """")
                        SB.Append(",").Append("""" + FI.LastWriteTime + """")
                        SB.Append(Environment.NewLine)
                    ElseIf Generar_archivo = False Then
                        SQL.Actualizar("Costeos", "Compra='" + TDoc(0) + "',Elaborado='True',Usuario_que_elabora='" + UCase(Datos_propietario(1)) + "',Archivo='" + FI.FullName.ToString + "'", "Ingreso_a_bodega='" + TDoc(1) + "' And Estado<>'Anulado' And (Elaborado<>'True' Or Elaborado Is Null)")
                        SQL.Actualizar("Costeos", "Fecha_de_elaboracion='" + FI.LastWriteTime.ToString + "'", "Ingreso_a_bodega='" + TDoc(1) + "' And Estado<>'Anulado'")
                    End If
                End If
            Next

            If Generar_archivo = True And SB.Length > 63 Then
                Dim SFD As New SaveFileDialog With {.Filter = "Exportar formato CSV|*.csv", .FileName = "Información de archivos"}
                If SFD.ShowDialog = DialogResult.OK Then
                    Dim SW As New StreamWriter(SFD.OpenFile, Encoding.GetEncoding(1252))
                    SW.WriteLine(SB)
                    SW.Dispose()
                    If MsgBox("Desea abrir el archivo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Process.Start(SFD.FileName, vbMaximizedFocus)
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al extraer la información")
        End Try

    End Sub

    Public Sub Enviar_correo(Optional Cuenta As String = Nothing, Optional Para As String = Nothing, Optional Con_copia As String = Nothing, Optional Con_copia_oculta As String = Nothing, Optional Asunto As String = Nothing, Optional Cuerpo_del_correo As String = Nothing, Optional Adjuntos As List(Of String) = Nothing)
        Dim AppOutlook As New Outlook.Application
        Try
            Dim Correo As Outlook.MailItem = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            If Cuenta <> Nothing Then
                Dim Cuentas As Outlook.Accounts = AppOutlook.Session.Accounts
                For Each CTRL As Outlook.Account In Cuentas
                    If CTRL.SmtpAddress = Cuenta Then
                        Correo.SendUsingAccount = CTRL
                    End If
                Next
            End If

            Correo.To = Para
            Correo.CC = Con_copia
            Correo.BCC = Con_copia_oculta

            Correo.Subject = Asunto
            Correo.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
            Correo.HTMLBody = Cuerpo_del_correo
            If Not IsNothing(Adjuntos) Then
                For Each Adjunto As String In Adjuntos
                    Correo.Attachments.Add(Adjunto, Outlook.OlAttachmentType.olByValue)
                Next
            End If
            Correo.Display()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al crear correo")
        Finally
            Eliminar_referencias(AppOutlook)
        End Try
    End Sub

    Private Sub Eliminar_referencias(Referencias As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(Referencias)
            Referencias = Nothing
        Catch ex As Exception
            Referencias = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Function Campo(Información As DevExpress.XtraEditors.BaseEdit) As String

        If Información.EditValue <> Nothing Then
            Return "'" + Información.EditValue.ToString + "'"
        Else
            Return "Null"
        End If

    End Function

    Public Function Valor(Información As Object)

        If IsDBNull(Información) Then
            Return Nothing
        Else
            Return Información
        End If

    End Function

    Public Function Campo_tabla(Información As Object)

        If IsDBNull(Información) Then
            Return "Null"
        Else
            Return "'" + Información.ToString + "'"
        End If

    End Function

    Public Sub Exportar_GridControl_a_Excel(GC As DevExpress.XtraGrid.GridControl, Nombre As String)
        Dim SFD As New SaveFileDialog With {.Filter = "Exportar formato Excel|*.xlsx", .FileName = Nombre}
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            GC.ExportToXlsx(SFD.FileName)
            If MsgBox("Desea abrir el archivo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(SFD.FileName, vbMaximizedFocus)
            End If
        End If
    End Sub

    '*****************************



    Public Sub Validar_valores_en_TBX(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And sender.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Sub Formato_de_valor_en_TBX_N2(sender As Object, e As EventArgs)
        sender.Text = String.Format("{0:N2}", Val(Replace(sender.Text, ",", "")))
    End Sub
    Public Sub Formato_de_valor_en_TBX_N6(sender As Object, e As EventArgs)
        sender.Text = String.Format("{0:N6}", Val(Replace(sender.Text, ",", "")))
    End Sub

    Public Sub Exportar_DataGridView_a_CSV(DataGridView As DataGridView, Nombre As String)
        Dim SFD As New SaveFileDialog With {.Filter = "Exportar formato CSV|*.csv", .FileName = Nombre}
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim SB As New StringBuilder()
                Dim Separador As String = Nothing
                For i As Integer = 1 To DataGridView.ColumnCount
                    SB.Append(Separador).Append(DataGridView.Columns(i - 1).HeaderText)
                    Separador = ","
                Next
                SB.Append(Environment.NewLine)
                For Fila As Integer = 0 To DataGridView.RowCount - 1
                    Separador = Nothing
                    For Columna As Integer = 0 To DataGridView.ColumnCount - 1
                        SB.Append(Separador).Append("""" & DataGridView.Item(Columna, Fila).Value & """")
                        Separador = ","
                    Next
                    SB.Append(Environment.NewLine)
                Next

                Dim SW As New StreamWriter(SFD.OpenFile, Encoding.GetEncoding(1252))
                SW.WriteLine(SB)
                SW.Dispose()
                If MsgBox("Desea abrir el archivo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Process.Start(SFD.FileName, vbMaximizedFocus)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a CSV")
            End Try
        End If
    End Sub
    Public Sub Exportar_DataGridView_a_Excel(DataGridView As DataGridView, Nombre As String)
        Dim SFD As New SaveFileDialog With {.Filter = "Exportar formato Excel|*.xlsx", .FileName = Nombre}
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim AppExcel As New Excel.Application
            Try
                Dim WB As Excel.Workbook
                Dim WS As Excel.Worksheet
                WB = AppExcel.Workbooks.Add
                WS = WB.Sheets(1)
                Dim Iniciar_en_fila As Integer = 3

                For i As Integer = 1 To DataGridView.ColumnCount
                    WS.Cells.Item(Iniciar_en_fila, i).Font.Bold = 1
                    WS.Cells.Item(Iniciar_en_fila, i) = DataGridView.Columns(i - 1).HeaderText
                Next
                For Fila As Integer = 0 To DataGridView.RowCount - 1
                    For Columna As Integer = 0 To DataGridView.ColumnCount - 1
                        If IsNumeric(DataGridView.Item(Columna, Fila).Value) Then
                            WS.Cells.Item(Fila + Iniciar_en_fila + 1, Columna + 1).NumberFormat = "0"
                            WS.Cells.Item(Fila + Iniciar_en_fila + 1, Columna + 1) = DataGridView.Item(Columna, Fila).Value
                        Else
                            WS.Cells.Item(Fila + Iniciar_en_fila + 1, Columna + 1) = DataGridView.Item(Columna, Fila).Value
                        End If
                    Next
                Next
                WS.Columns.AutoFit()
                WB.SaveAs(SFD.FileName)
                WB.Close()
                AppExcel.Quit()
                Eliminar_referencias(AppExcel)
                If MsgBox("Desea abrir el archivo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Process.Start(SFD.FileName, vbMaximizedFocus)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            Finally
                Eliminar_referencias(AppExcel)
            End Try
        End If
    End Sub



End Class
