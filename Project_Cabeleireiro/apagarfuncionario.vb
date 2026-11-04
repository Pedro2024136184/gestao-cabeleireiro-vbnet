Imports System.Data.SqlClient
Public Class apagarfuncionario

    Private Sub apagarfuncionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim in1 As Long = MaskedTextBox1.Text
        Dim con As New SqlConnection(cs)
        con.Open()
        Try
            Dim a As Integer = MsgBox("Tem a certeza que quer apagar este dado ?", vbOKCancel, "Certificação")
            If a = 1 Then
                Dim sql As String = "delete from funcionarios where id=" & in1
                Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
                Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
            Else

            End If

        Catch ex As Exception
            MsgBox("Não foi possivel apagar este dado, provavelmente não existe ou tem outros registos a utilizar este dado !", vbOKOnly, "Erro")
        End Try

    End Sub
End Class