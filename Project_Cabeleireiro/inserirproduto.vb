Imports System.Data.SqlClient
Public Class inserirproduto
    Dim a, b, c, d, ee, f, g, h As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con As New SqlConnection(cs)

            con.Open()


            TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            TextBox2.Text = Replace(TextBox2.Text, "'", "´")
            a = TextBox1.Text
            b = TextBox2.Text
            c = MaskedTextBox3.Text
            d = ComboBox1.SelectedItem
            ee = ComboBox2.SelectedItem
            f = MaskedTextBox1.Text
            g = MaskedTextBox2.Text





            '-----------------------------------------------------
            If (a <> "") And (b <> "") And (c <> "") And (ee <> "") And (f <> "") And (g <> "") Then
                Try
                    Dim sql As String = "INSERT INTO produtos (Nome, descricao, pvp, categoria, fornecedor, quantidade, stock_minimo) VALUES ('" & a & "', '" & b & "', '" & c & "', '" & d & "', '" & ee & "', '" & f & "', '" & g & "')"

                    Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita 

                    Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    MaskedTextBox3.Text = "0"
                    MaskedTextBox2.Text = "0"
                    MaskedTextBox1.Text = "0000.00"
                    ComboBox1.SelectedIndex = 0
                    ComboBox2.SelectedIndex = 0
                Catch ex As Exception
                    MsgBox(ex.Message, vbOKOnly, "Erro1")
                End Try
            Else
                MsgBox("Dados mal introduzidos", vbOKOnly, "Erro2")
            End If
        Catch ex As Exception
            MsgBox("Dados mal introduzidos", vbOKOnly, "Erro2")

        End Try
    End Sub

    Private Sub inserirproduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        categoriaa()
        funcionarioss()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
      
    End Sub

    Public Sub categoriaa()



        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from categorias"
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

    End Sub

    Public Sub funcionarioss()


        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from fornecedores "
        Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita

        Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela


        ComboBox2.Items.Clear()

        Dim n As Integer = dr.FieldCount ' para saber quantos campos / colunas preciso

        Dim i As Integer = 0
        While dr.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            ComboBox2.Items.Add(dr.Item(0)) ' acrescenta uma linha à listbox
        End While
        con.Close()

    End Sub
End Class