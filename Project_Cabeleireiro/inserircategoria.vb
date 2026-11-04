Imports System.Data.SqlClient
Public Class inserircategoria
    Dim a, b As String
    Private Sub inserircategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try


            Dim con As New SqlConnection(cs)

            con.Open()


            TextBox1.Text = Replace(TextBox1.Text, "'", "´")

            TextBox2.Text = Replace(TextBox2.Text, "'", "´")
            a = TextBox1.Text
            b = TextBox2.Text


            '-----------------------------------------------------
            If (a <> "") And (b <> "") Then
                Try
                    Dim sql As String = "INSERT INTO Categorias (Nome, Descricao) VALUES ('" & a & "', '" & b & "')"

                    Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita 

                    Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""
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