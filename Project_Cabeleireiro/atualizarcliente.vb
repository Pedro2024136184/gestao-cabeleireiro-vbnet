Imports System.Data.SqlClient
Public Class atualizarcliente
    Dim a, b, c, d, ee, f, g As String
    Private Sub atualizarcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        Dim con As New SqlConnection(cs)
        con.Open()
        Dim sql As String = "select nome from clientes"
        Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita

        Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela


        ComboBox1.Items.Clear()

        Dim n As Integer = dr.FieldCount ' para saber quantos campos / colunas preciso

        Dim i As Integer = 0
        While dr.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            ComboBox1.Items.Add(dr.Item(0)) ' acrescenta uma linha à listbox
        End While
        con.Close()
        ComboBox1.SelectedIndex = 0
        RadioButton1.Checked = True
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.SelectedItem
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            a = MaskedTextBox1.Text
            b = TextBox2.Text
            c = MaskedTextBox2.Text
            d = TextBox3.Text
            ee = MaskedTextBox3.Text
            If RadioButton1.Checked Then f = "M"
            If RadioButton2.Checked Then f = "F"
            Dim sql As String = "Update clientes SET  nome='" & TextBox1.Text & "' , nif='" & a & "', email='" & b & "', telefone='" & c & "', endereco='" & d & "', codigo_postal='" & ee & "', sexo='" & f & "' WHERE nome='" & ComboBox1.SelectedItem & "'"
            Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
            InputBox("", "", sql)
            Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
            ComboBox1.SelectedIndex = 0
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            MaskedTextBox1.Text = ""
            MaskedTextBox2.Text = ""
            MaskedTextBox3.Text = ""
            RadioButton1.Checked = True

        Catch ex As Exception
            MsgBox("Dados mal introduzidos !", vbOKOnly, "Erro")
        End Try
    End Sub
End Class