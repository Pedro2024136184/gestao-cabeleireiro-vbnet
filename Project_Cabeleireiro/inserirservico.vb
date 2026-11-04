Imports System.Data.SqlClient
Public Class inserirservico
    Dim a, b, c, ee, f As String
    Dim d As Date
    Private Sub inserirservico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = MDIParent2

        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from areas"
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

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim con As New SqlConnection(cs)

            con.Open()


            TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            TextBox2.Text = Replace(TextBox2.Text, "'", "´")
            a = TextBox1.Text
            b = TextBox2.Text
            c = MaskedTextBox3.Text
            d = MaskedTextBox1.Text
            ee = ComboBox1.SelectedItem





            '-----------------------------------------------------
            If (a <> "") And (b <> "") And (c <> "") Then
                Try
                    Dim sql As String = "INSERT INTO servicos (Nome, descricao, pvp, duracao, area) VALUES ('" & a & "', '" & b & "', '" & c & "', '" & d & "', '" & ee & "')"

                    Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita 

                    Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    MaskedTextBox1.Text = "0"
                    MaskedTextBox3.Text = "0000.00"
                    ComboBox1.SelectedIndex = 0

                Catch ex As Exception
                    MsgBox("Dados mal introduzidos !", vbOKOnly, "Erro")
                End Try
            Else
                MsgBox("Dados mal introduzidos", vbOKOnly, "Erro")
            End If
        Catch ex As Exception
            MsgBox("Dados mal introduzidos", vbOKOnly, "Erro")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub

    Private Sub MaskedTextBox3_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox3.MaskInputRejected

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class