Imports System.Data.SqlClient

Public Class veragenda
    Dim hoje As Date = Today.Year & "/" & Today.Month & "/" & Today.Day

    Dim iniciosemana As Date = hoje.AddDays(-Weekday(hoje) + 1)






    Private Sub veragenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        Dim con As New SqlConnection(cs)
        con.Open()

        Dim sql As String = "select data,cliente from agendamentos where data>='" & iniciosemana.Year & "/" & iniciosemana.Month & "/" & iniciosemana.Day & " 00:00' and diasemana='2'"
        'InputBox("", "", sql)
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
        dr.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sql2 As String = "select data,cliente from agendamentos where data>='" & iniciosemana.Year & "/" & iniciosemana.Month & "/" & iniciosemana.Day & " 00:00' and diasemana='3'"
        'InputBox("", "", sql)
        Dim sqlcom2 As New SqlCommand(sql2, con) ' Executa o SQL na ligação à BD que tenho feita"
        Dim dr2 As SqlDataReader = sqlcom2.ExecuteReader() ' recebo no dr todos os registos da tabela
        DataGridView2.Columns.Clear()
        n = dr2.FieldCount ' para saber quantos campos / colunas preciso

        For k = 0 To n - 1 ' Por exemplo, se tenho 3 colunas, são a coluna 0,1 e 2
            campo = dr2.GetName(k) ' vai buscar o nome desse campo
            DataGridView2.Columns.Add(campo, campo) ' acrescento um coluna com o nome e título iguais ao campo da tabela
        Next
        i = 0
        While dr2.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            DataGridView2.Rows.Add(linha) ' acrescenta uma linha à datagridview
            For a = 0 To n - 1
                DataGridView2.Rows(i).Cells(a).Value = dr2.Item(a) ' coloca o nº de processo
            Next
            i += 1
        End While
        dr2.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sql3 As String = "select data,cliente from agendamentos where data>='" & iniciosemana.Year & "/" & iniciosemana.Month & "/" & iniciosemana.Day & " 00:00' and diasemana='4'"
        'InputBox("", "", sql)
        Dim sqlcom3 As New SqlCommand(sql3, con) ' Executa o SQL na ligação à BD que tenho feita"
        Dim dr3 As SqlDataReader = sqlcom3.ExecuteReader() ' recebo no dr todos os registos da tabela
        DataGridView3.Columns.Clear()
        n = dr3.FieldCount ' para saber quantos campos / colunas preciso

        For k = 0 To n - 1 ' Por exemplo, se tenho 3 colunas, são a coluna 0,1 e 2
            campo = dr3.GetName(k) ' vai buscar o nome desse campo
            DataGridView3.Columns.Add(campo, campo) ' acrescento um coluna com o nome e título iguais ao campo da tabela
        Next
        i = 0
        While dr3.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            DataGridView3.Rows.Add(linha) ' acrescenta uma linha à datagridview
            For a = 0 To n - 1
                DataGridView3.Rows(i).Cells(a).Value = dr3.Item(a) ' coloca o nº de processo
            Next
            i += 1
        End While
        dr3.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sql4 As String = "select data,cliente from agendamentos where data>='" & iniciosemana.Year & "/" & iniciosemana.Month & "/" & iniciosemana.Day & " 00:00' and diasemana='5'"
        'InputBox("", "", sql)
        Dim sqlcom4 As New SqlCommand(sql4, con) ' Executa o SQL na ligação à BD que tenho feita"
        Dim dr4 As SqlDataReader = sqlcom4.ExecuteReader() ' recebo no dr todos os registos da tabela
        DataGridView4.Columns.Clear()
        n = dr4.FieldCount ' para saber quantos campos / colunas preciso

        For k = 0 To n - 1 ' Por exemplo, se tenho 3 colunas, são a coluna 0,1 e 2
            campo = dr4.GetName(k) ' vai buscar o nome desse campo
            DataGridView4.Columns.Add(campo, campo) ' acrescento um coluna com o nome e título iguais ao campo da tabela
        Next
        i = 0
        While dr4.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            DataGridView4.Rows.Add(linha) ' acrescenta uma linha à datagridview
            For a = 0 To n - 1
                DataGridView4.Rows(i).Cells(a).Value = dr4.Item(a) ' coloca o nº de processo
            Next
            i += 1
        End While
        dr4.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sql5 As String = "select data,cliente from agendamentos where data>='" & iniciosemana.Year & "/" & iniciosemana.Month & "/" & iniciosemana.Day & " 00:00' and diasemana='6'"
        'InputBox("", "", sql)
        Dim sqlcom5 As New SqlCommand(sql5, con) ' Executa o SQL na ligação à BD que tenho feita"
        Dim dr5 As SqlDataReader = sqlcom5.ExecuteReader() ' recebo no dr todos os registos da tabela
        DataGridView5.Columns.Clear()
        n = dr5.FieldCount ' para saber quantos campos / colunas preciso

        For k = 0 To n - 1 ' Por exemplo, se tenho 3 colunas, são a coluna 0,1 e 2
            campo = dr5.GetName(k) ' vai buscar o nome desse campo
            DataGridView5.Columns.Add(campo, campo) ' acrescento um coluna com o nome e título iguais ao campo da tabela
        Next
        i = 0
        While dr5.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            DataGridView5.Rows.Add(linha) ' acrescenta uma linha à datagridview
            For a = 0 To n - 1
                DataGridView5.Rows(i).Cells(a).Value = dr5.Item(a) ' coloca o nº de processo
            Next
            i += 1
        End While
        dr5.Close()
        '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim sql6 As String = "select data,cliente from agendamentos where data>='" & iniciosemana.Year & "/" & iniciosemana.Month & "/" & iniciosemana.Day & " 00:00' and diasemana='7'"
        'InputBox("", "", sql)
        Dim sqlcom6 As New SqlCommand(sql6, con) ' Executa o SQL na ligação à BD que tenho feita"
        Dim dr6 As SqlDataReader = sqlcom6.ExecuteReader() ' recebo no dr todos os registos da tabela
        DataGridView6.Columns.Clear()
        n = dr6.FieldCount ' para saber quantos campos / colunas preciso

        For k = 0 To n - 1 ' Por exemplo, se tenho 3 colunas, são a coluna 0,1 e 2
            campo = dr6.GetName(k) ' vai buscar o nome desse campo
            DataGridView6.Columns.Add(campo, campo) ' acrescento um coluna com o nome e título iguais ao campo da tabela
        Next
        i = 0
        While dr6.Read() ' enquanto houver registos na tabela para serem lidos ....
            Dim linha As New DataGridViewRow()
            DataGridView6.Rows.Add(linha) ' acrescenta uma linha à datagridview
            For a = 0 To n - 1
                DataGridView6.Rows(i).Cells(a).Value = dr6.Item(a) ' coloca o nº de processo
            Next
            i += 1
        End While
        dr6.Close()


































        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

       
        Dim con As New SqlConnection(cs)
        con.Open()
            Dim sql As String = "select nome from clientes where id='" & TextBox1.Text & "'"
        Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita"
        Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela
            dr.Read()
            If dr.Item(0) <> "" Then
                TextBox2.Text = dr.Item(0)
            End If

            con.Close()
        Catch ex As Exception
            MsgBox("Dados mal introduzidos ou o cliente não existe ! ", vbOKOnly, "Erro")
        End Try
    End Sub
End Class