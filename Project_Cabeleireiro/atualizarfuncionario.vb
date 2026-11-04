Imports System.Data.SqlClient
Public Class atualizarfuncionario
    Dim a, b, c, d, ee, f, g, H As String
    Private Sub atualizarfuncionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ComboBox1.SelectedIndex = 0
        RadioButton1.Checked = True
        dr.Close()
        '--------------
        Dim sql2 As String = "select username from funcionarios"
        Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho feita

        Dim dr2 As SqlDataReader = sqlcom2.ExecuteReader() ' recebo no dr todos os registos da tabela


        ComboBox2.Items.Clear()

        n = dr2.FieldCount ' para saber quantos campos / colunas preciso

        i = 0
        While dr2.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            ComboBox2.Items.Add(dr2.Item(0)) ' acrescenta uma linha à listbox
        End While
        con.Close()
        ComboBox2.SelectedIndex = 0


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox1.Text = ComboBox2.SelectedItem
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

        
        Dim con As New SqlConnection(cs)
        con.Open()
        a = TextBox2.Text
        b = MaskedTextBox1.Text
        c = TextBox3.Text
        d = TextBox4.Text
        ee = MaskedTextBox2.Text
        f = TextBox5.Text

        If RadioButton1.Checked Then g = "M"
        If RadioButton2.Checked Then g = "F"
        H = ComboBox1.SelectedItem
        If (a <> "") And (b <> "") And (c <> "") And (d <> "") And (ee <> "") And (f <> "") And (g <> "") And (H <> "") Then

            Dim sql As String = "Update funcionarios SET  username='" & TextBox1.Text & "' , password='" & a & "', nivel='" & b & "', nome='" & c & "', email='" & d & "', telefone='" & ee & "', cargo='" & f & "', sexo='" & g & "', area='" & H & "' WHERE username='" & ComboBox2.SelectedItem & "'"
            Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita

            Dim dr As Integer = sqlcom.ExecuteNonQuery() ' recebo no dr todos os registos da tabela
            ComboBox1.SelectedIndex = 0
            ComboBox2.SelectedIndex = 0
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            MaskedTextBox1.Text = ""
            MaskedTextBox2.Text = ""
            RadioButton1.Checked = True
        Else
            MsgBox("Dados mal introduzidos", vbOKOnly, "Erro")
            End If
        Catch ex As Exception
            MsgBox("Dados mal introduzidos", vbOKOnly, "Erro")
        End Try
    End Sub
End Class