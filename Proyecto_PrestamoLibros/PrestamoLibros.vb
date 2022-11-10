Public Class PrestamoLibros

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub PrestamoLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxGenero.SelectedIndex = 0
        btnBuscar.Enabled = False
        dtpFechaDevolucion.MinDate = Date.Now
        dtpFechaPrestamo.MinDate = DateAdd(DateInterval.Day, -2, Now.Date)
        dtpFechaPrestamo.MaxDate = Now.Date

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim buscar As String
        buscar = txtID.Text
        Select Case buscar

            Case "L0001"
                lblNombre.Text = "Juan Torres"

            Case "L0002"
                lblNombre.Text = "María Davila"

            Case "L0003"
                lblNombre.Text = "Julio Pérez"

            Case "L0004"
                lblNombre.Text = "David Mendoza"

            Case "L0005"
                lblNombre.Text = "Angela Mariela"

            Case "L0006"
                lblNombre.Text = "Angel Monsalvo"

            Case Else
                MsgBox("Lo sentimos el usuario no pudo ser encontrado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Sistema")

        End Select
    End Sub

    Private Sub cbxGenero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGenero.SelectedIndexChanged
        Dim genero As Integer
        genero = cbxGenero.SelectedIndex

        Select Case (genero)
            Case 0
            Case 1 : llenarComedia()
            Case 2 : llenarTerror()
            Case 3 : llenarAventura()
        End Select
    End Sub

    Private Sub llenarComedia()
        cbxLibro.Items.Clear()
        cbxLibro.Items.Add("Mafalda")
        cbxLibro.Items.Add("Enterrado en Vida")
        cbxLibro.Items.Add("La Tía Mame")
        cbxLibro.Items.Add("Maldito KARMA")
        cbxLibro.Items.Add("El leñador")

    End Sub
    Private Sub llenarTerror()
        cbxLibro.Items.Clear()
        cbxLibro.Items.Add("El Gato Negro")
        cbxLibro.Items.Add("La Semilla del Diablo")
        cbxLibro.Items.Add("Drácula")
        cbxLibro.Items.Add("El resplandor")
        cbxLibro.Items.Add("Cuentos macabros")

    End Sub
    Private Sub llenarAventura()
        cbxLibro.Items.Clear()
        cbxLibro.Items.Add("La Isla del Tesoro")
        cbxLibro.Items.Add("Robin Crusoe")
        cbxLibro.Items.Add("Las Aventuras de Alexander")

    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        If (txtID.Text.Length = 5) Then
            btnBuscar.Enabled = True
        Else
            btnBuscar.Enabled = False
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim dias As Integer
        Dim pago As Double
        Dim Nveces As Integer

        If lblNombre.Text = "" Then
            MsgBox("Lector no encontrado!", MsgBoxStyle.Critical, "Sistema")
        ElseIf cbxGenero.SelectedIndex = 0 Then
            MsgBox("Falta seleccionar un libro!", MsgBoxStyle.Critical, "Sistema")
        Else
            For index = 0 To lbxLector.Items.Count - 1
                If lbxLector.Items(index).ToString.Equals(lblNombre.Text) Then
                    Nveces += 1
                End If
            Next
            If Nveces = 2 Then
                MsgBox("Capacidad alcanzada del lector", MsgBoxStyle.Information, "Sistema")
            Else
                dias = DateDiff(DateInterval.Day, dtpFechaPrestamo.Value, dtpFechaDevolucion.Value)
                lbxLector.Items.Add(lblNombre.Text)
                lbxLibro.Items.Add(cbxLibro.SelectedItem.ToString)
                lbxCantDias.Items.Add(dias)
                If dias <= 2 Then
                    pago = 0.0
                    lbxPago.Items.Add("S/. " & pago)
                Else
                    pago = (dias - 2) * 1.5
                    lbxPago.Items.Add("S/. " & pago)
                End If
                cbxGenero.SelectedIndex = 0
                cbxLibro.SelectedIndex = -1
                txtID.Clear()
                lblNombre.Text = ""
                txtID.Focus()
            End If
        End If

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        lbxLector.Items.Clear()
        lbxCantDias.Items.Clear()
        lbxPago.Items.Clear()
        lbxLibro.Items.Clear()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim i As Integer
        i = lbxLector.SelectedIndex()
        If (i >= 0) Then
            lbxLibro.Items.RemoveAt(i)
            lbxCantDias.Items.RemoveAt(i)
            lbxPago.Items.RemoveAt(i)
            lbxLector.Items.RemoveAt(i)
        End If
    End Sub

End Class
