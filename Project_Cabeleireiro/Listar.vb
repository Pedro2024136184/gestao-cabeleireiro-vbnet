Imports System.Data.SqlClient
Public Class Listar

    Private Sub Listar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        ListBox1.SelectedIndex = 0
    End Sub

    Private Sub ListBox1_selectededIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = 0 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from agendamentos"
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
        End If

        If ListBox1.SelectedIndex = 1 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from areas"
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
        End If
        If ListBox1.SelectedIndex = 2 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from categorias"
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
        End If
        If ListBox1.SelectedIndex = 3 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from clientes"
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
        End If
        If ListBox1.SelectedIndex = 4 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from entradas"
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
        End If
        If ListBox1.SelectedIndex = 5 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from fornecedores"
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
        End If
        If ListBox1.SelectedIndex = 6 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from funcionarios"
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
        End If
        If ListBox1.SelectedIndex = 7 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from produtos"
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
        End If
        If ListBox1.SelectedIndex = 8 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from servicos"
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
        End If

        If ListBox1.SelectedIndex = 9 Then
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select * from vendas"
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
        End If

    End Sub
End Class