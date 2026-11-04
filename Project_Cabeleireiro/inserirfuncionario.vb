Imports System.Data.SqlClient
Public Class inserirfuncionario
    Dim a, b, c, d, ee, f, g, h, i As String
    Private Sub inserirfuncionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        RadioButton1.Checked = True

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim con As New SqlConnection(cs)

            con.Open()


            TextBox1.Text = Replace(TextBox1.Text, "'", "´")
            TextBox2.Text = Replace(TextBox2.Text, "'", "´")
            TextBox3.Text = Replace(TextBox3.Text, "'", "´")
            TextBox4.Text = Replace(TextBox4.Text, "'", "´")
            TextBox5.Text = Replace(TextBox5.Text, "'", "´")
            a = TextBox1.Text
            b = TextBox2.Text
            c = MaskedTextBox1.Text
            d = TextBox3.Text
            ee = TextBox4.Text
            f = MaskedTextBox2.Text
            g = TextBox5.Text
            If RadioButton1.Checked Then h = "M"
            If RadioButton2.Checked Then h = "F"
            i = ComboBox1.SelectedItem



            '-----------------------------------------------------
            If (a <> "") And (b <> "") And (c <> "") And (d <> "") And (ee <> "") And (f <> "") And (g <> "") Then
                Try
                    Dim sql As String = "INSERT INTO funcionarios (UserName, Password, Nivel, Nome, Email, Telefone, Cargo, Sexo, Area) VALUES ('" & a & "', '" & b & "', '" & c & "', '" & d & "', '" & ee & "', '" & f & "', '" & g & "', '" & h & "', '" & i & "')"

                    Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita 

                    Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    MaskedTextBox1.Text = ""
                    MaskedTextBox2.Text = ""
                    RadioButton1.Checked = True
                    ComboBox1.SelectedIndex = 0

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