Imports System.Data.SqlClient
Public Class entradaprodutos

    Private Sub entradaprodutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            'TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select quantidade from produtos where nome='" & TextBox1.Text & "'"
            Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
            Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr.Read()
            Dim quantidadeproduto As Integer = dr.Item(0)
            dr.Close()

            Dim sql2 As String = "Update produtos SET quantidade='" & quantidadeproduto + Val(MaskedTextBox1.Text) & "' WHERE nome='" & TextBox1.Text & "'"
            Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho feita

            Dim dr2 As Integer = sqlcom2.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
            TextBox1.Text = ""
            MaskedTextBox1.Text = ""
            con.Close()
        Catch ex As Exception
            MsgBox("Dados mal introduzidos !", vbOKOnly, "")
        End Try
        
    End Sub
End Class