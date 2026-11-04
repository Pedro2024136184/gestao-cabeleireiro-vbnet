Imports System.Data.SqlClient
Public Class inserirfornecedor
    Dim a, b, c, d, ee As String
    Private Sub inserirfornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
      
        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from categorias"
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
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0




    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

        Dim con As New SqlConnection(cs)

        con.Open()


        TextBox1.Text = Replace(TextBox1.Text, "'", "´")
        TextBox2.Text = Replace(TextBox2.Text, "'", "´")
        a = TextBox1.Text
        b = TextBox2.Text
        c = maskedTextBox1.Text
        d = ComboBox1.SelectedItem
        ee = ComboBox2.SelectedItem

       

        '-----------------------------------------------------
        If (a <> "") And (b <> "") And (c <> "") Then
            Try
                Dim sql As String = "INSERT INTO fornecedores (Nome, Morada, Telefone, Termo_Pag, Categoria) VALUES ('" & a & "', '" & b & "', '" & c & "', '" & d & "', '" & ee & "')"

                Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita 

                Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox2.Text = ""
                MaskedTextBox1.Text = ""

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
End Class