Imports System.Data.SqlClient
Public Class proximocliente

    Private Sub proximocliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        Dim id As Integer
        Dim con As New SqlConnection(cs)

        con.Open()

        Dim sql As String = "select * from funcionarios"
        Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
        Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela
        ComboBox1.Items.Clear()
        Dim n As Integer = dr.FieldCount ' para saber quantos campos / colunas preciso
        Dim i As Integer = 0
        While dr.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            ComboBox1.Items.Add(dr.Item(0)) ' acrescenta uma linha à listbox
        End While
        dr.Close()
        Dim sql2 As String = "select id from funcionarios where username ='" & username & "'"
        Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho 
        Dim dr2 As SqlDataReader = sqlcom2.ExecuteReader() ' recebo no dr todos os registos da tabela
        dr2.Read()
        id = dr2.Item(0)
        '   MsgBox(id, vbOKOnly, "")
        ComboBox1.SelectedItem = id
        dr2.Close()
        con.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim con As New SqlConnection(cs)
            con.Open()

            Dim sql2 As String = "select cliente from agendamentos where funcionario ='" & ComboBox1.SelectedItem & "' and data>= '" & Now & "'"
            'InputBox("", "", sql2)
            Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho 
            Dim dr2 As SqlDataReader = sqlcom2.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr2.Read()
            Dim idcliente As Integer = dr2.Item(0)
            dr2.Close()
            '----------------------------------
            Dim sql As String = "select * from clientes where id='" & idcliente & "'"
            Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita"
            Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela
            DataGridView1.Columns.Clear()
            Dim n As Integer = dr.FieldCount ' para saber quantos campos / colunas preciso
            Dim campo As String
            Dim k As Integer
            For k = 0 To n - 1 ' Por exemplo, se tenho 3 colunas, são a coluna 0,1 e 2
                campo = dr.GetName(k) ' vai buscar o nome desse campo
                DataGridView1.Columns.Add(campo, campo) ' acrescento um coluna com o nome e título iguais ao campo da tabela
            Next
            Dim i As Integer = 0
            While dr.Read() ' enquanto houver registos na tabela para serem lidos ....
                Dim linha As New DataGridViewRow()
                DataGridView1.Rows.Add(linha) ' acrescenta uma linha à datagridview
                For a = 0 To n - 1
                    DataGridView1.Rows(i).Cells(a).Value = dr.Item(a) ' coloca o nº de processo
                Next
                i += 1
            End While
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            con.Close()
        Catch ex As Exception
            MsgBox("Não foi possivel localizar !", vbOKOnly, "Erro")
        End Try





    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class