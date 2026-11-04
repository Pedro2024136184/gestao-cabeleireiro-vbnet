Imports System.Data.SqlClient
Public Class inserircliente
    Dim a, b, c, d, ee, f, g As String
    Private Sub inserircliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        RadioButton1.Checked = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub MaskedTextBox2_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles MaskedTextBox2.MaskInputRejected

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con As New SqlConnection(cs)

            con.Open()


            TextBox1.Text = Replace(TextBox1.Text, "'", "´")

            TextBox2.Text = Replace(TextBox2.Text, "'", "´")

            TextBox3.Text = Replace(TextBox3.Text, "'", "´")
            a = TextBox1.Text
            b = MaskedTextBox1.Text
            c = TextBox2.Text
            d = MaskedTextBox2.Text
            ee = TextBox3.Text
            f = MaskedTextBox3.Text

            If RadioButton1.Checked Then g = "M"
            If RadioButton2.Checked Then g = "F"

            '-----------------------------------------------------
            If (a <> "") And (b <> "") And (c <> "") And (d <> "") And (ee <> "") And (f <> "") Then
                Try
                    Dim sql As String = "INSERT INTO Clientes (Nome, Nif, Email, Telefone, Endereco, Codigo_postal, Sexo) VALUES ('" & a & "', '" & b & "', '" & c & "', '" & d & "', '" & ee & "', '" & f & "', '" & g & "')"

                    Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita 

                    Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    MaskedTextBox1.Text = ""
                    MaskedTextBox2.Text = ""
                    MaskedTextBox3.Text = ""
                    RadioButton1.Checked = True
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