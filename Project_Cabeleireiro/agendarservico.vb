Imports System.Data.SqlClient
Public Class agendarservico
    Dim a, b, c, d As String
    Dim ee As String
    Private Sub agendarservico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from servicos"
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from servicos where id='" & ComboBox1.SelectedItem & "'"
        Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita

        Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela

        Dim i As Integer = 0
        While dr.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            TextBox4.Text = dr.Item(1) ' acrescenta uma linha à textbox
        End While
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            TextBox2.Text = Replace(TextBox2.Text, "'", "´")
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select id from clientes where nome='" & TextBox1.Text & "'"
            Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
            Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr.Read()
            Dim idcliente As Integer = dr.Item(0)
            'MsgBox(idcliente, vbOKOnly, "ok")
            dr.Close()
            Dim sql2 As String = "select id from funcionarios where nome='" & TextBox2.Text & "'"
            Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho feita
            Dim dr2 As SqlDataReader = sqlcom2.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr2.Read()
            Dim idfuncionario As Integer = dr2.Item(0)
            ' MsgBox(idfuncionario, vbOKOnly, "ok")
            dr2.Close()



            a = idcliente
            b = idfuncionario
            c = ComboBox1.SelectedItem
            d = TextBox3.Text
            ee = MaskedTextBox1.Text

            If (a <> "") And (b <> "") And (d <> "") And (ee <> "01/01/1900 00:00") Then
                Try
                    Dim sql3 As String = "INSERT INTO agendamentos (Cliente, Funcionario, Servico, Descricao, Data, Diasemana) VALUES ('" & a & "', '" & b & "', '" & c & "', '" & d & "', '" & ee & "', '" & Weekday(ee) & "')"

                    Dim sqlcom3 As New SqlCommand(sql3, con) ' Executa o SQL na ligação à BD que tenho feita 

                    Dim dr3 As Integer = sqlcom3.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    MaskedTextBox1.Text = ""
                    ComboBox1.SelectedIndex = 0

                Catch ex As Exception
                    MsgBox("Dados mal introduzidos !", vbOKOnly, "Erro")
                End Try
            Else
                MsgBox("Dados mal introduzidos !", vbOKOnly, "Erro")
            End If
        Catch ex As Exception
            MsgBox("Dados mal introduzidos !", vbOKOnly, "Erro")
        End Try


    End Sub
End Class