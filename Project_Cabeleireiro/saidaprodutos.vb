Imports System.Data.SqlClient
Public Class saidaprodutos
    Dim a As String = Format(Today, "yyyy/MM/d")
    Dim d As Integer
    Dim b, c As String
    Dim precoproduto As Single
    Private Sub saidaprodutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select quantidade,stock_minimo from produtos where nome='" & TextBox1.Text & "'"
            Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
            Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr.Read()
            Dim quantidadeproduto As Integer = dr.Item(0)
            Dim stockminimo As Integer = dr.Item(1)
            ' MsgBox(stockminimo, vbOK, "")
            dr.Close()




            Dim sql2 As String = "Update produtos SET quantidade='" & quantidadeproduto - Val(MaskedTextBox1.Text) & "' WHERE nome='" & TextBox1.Text & "'"
            Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho feita

            Dim dr2 As Integer = sqlcom2.ExecuteNonQuery() ' recebo no dr todos os registos da tabela


            TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            TextBox2.Text = Replace(TextBox2.Text, "'", "´")

            Dim sql4 As String = "select id from clientes where nome='" & TextBox2.Text & "'"
            Dim sqlcom4 As New SqlCommand(sql4, con) ' Executa o SQL na ligação à BD que tenho feita
            Dim dr4 As SqlDataReader = sqlcom4.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr4.Read()
            Dim idcliente As Integer = dr4.Item(0)
            'MsgBox(idcliente, vbOKOnly, "ok")
            dr4.Close()
            Dim sql3 As String = "select id from produtos where nome='" & TextBox1.Text & "'"
            Dim sqlcom3 As New SqlCommand(sql3, con) ' Executa o SQL na ligação à BD que tenho feita
            Dim dr3 As SqlDataReader = sqlcom3.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr3.Read()
            Dim idproduto As Integer = dr3.Item(0)
            ' MsgBox(idfuncionario, vbOKOnly, "ok")
            dr3.Close()






            b = TextBox3.Text
            c = TextBox4.Text
            d = MaskedTextBox1.Text






            '-----------------------------------------------------
            If (b <> "") And (c <> "") And (d <> 0) And (quantidadeproduto >= stockminimo) Then
                Try
                    Dim sql5 As String = "INSERT INTO vendas (DataVenda, cliente, produtovendido, metodopagamento, desconto, quantidade, total) VALUES ('" & a & "', '" & idcliente & "', '" & idproduto & "', '" & b & "', '" & c & "', '" & d & "', '" & Label6.Text & "')"

                    Dim sqlcom5 As New SqlCommand(sql5, con) ' Executa o SQL na ligação à BD que tenho feita 
                    InputBox("", "", sql5)
                    Dim dr5 As Integer = sqlcom5.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""

                    MaskedTextBox1.Text = ""



                Catch ex As Exception
                    'MsgBox(ex.Message, vbOKOnly, "Erro1")
                End Try
            Else
                If (quantidadeproduto >= stockminimo) Then
                    MsgBox("Quantidade minima excedida", vbOKOnly, "STOCK")
                Else
                    MsgBox("Dados mal introduzidos", vbOKOnly, "Erro")
                End If


            End If
            con.Close()











        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "")
        End Try
    End Sub


    Private Sub MaskedTextBox1_TextChanged(sender As Object, e As EventArgs) Handles MaskedTextBox1.TextChanged

        Dim con As New SqlConnection(cs)

        con.Open()
        Try
            If MaskedTextBox1.Text <> "" Then
                Dim sql6 As String = "select pvp from produtos where nome='" & TextBox1.Text & "'"
                Dim sqlcom6 As New SqlCommand(sql6, con) ' Executa o SQL na ligação à BD que tenho feita
                Dim dr6 As SqlDataReader = sqlcom6.ExecuteReader() ' recebo no dr todos os registos da tabela
                dr6.Read()
                precoproduto = dr6.Item(0)
                dr6.Close()

                Label6.Text = precoproduto * Val(MaskedTextBox1.Text)
            End If
            con.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class