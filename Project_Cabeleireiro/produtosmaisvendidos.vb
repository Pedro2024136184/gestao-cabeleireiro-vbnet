Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class ProdutosMaisVendidos
    Private Sub ProdutosMaisVendidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        ' Conexão com o banco de dados
        Dim connectionString As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mattson\Desktop\PROJETO LP\BDcabeleireiro.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionString)

        ' Consulta SQL para obter os produtos mais vendidos e suas quantidades vendidas
        Dim query As String = "SELECT produtovendido, SUM(quantidade) AS total_vendas FROM vendas GROUP BY produtovendido ORDER BY total_vendas DESC"

        ' Comando SQL
        Dim command As New SqlCommand(query, connection)

        ' Abre a conexão com o banco de dados
        connection.Open()

        ' Cria um leitor de dados para ler os resultados da consulta
        Dim reader As SqlDataReader = command.ExecuteReader()

        ' Limpa os dados existentes no gráfico
        Chart1.Series.Clear()

        ' Remove todas as áreas de gráfico existentes
        Chart1.ChartAreas.Clear()

        ' Adiciona uma área de gráfico
        Dim chartArea As New ChartArea()
        Chart1.ChartAreas.Add(chartArea)

        ' Adiciona uma série ao gráfico
        Dim series As New Series()
        series.ChartType = SeriesChartType.Column ' Define o tipo de gráfico como colunas (vertical)
        series.Color = System.Drawing.Color.DarkGreen ' Define a cor das barras como verde escuro
        series.Name = "Produtos Mais Vendidos"

        ' Adiciona a série à área de gráfico
        Chart1.Series.Add(series)

        ' Loop através dos resultados da consulta
        While reader.Read()
            ' Adiciona os valores ao gráfico
            Dim produto As String = reader("produtovendido").ToString()
            Dim quantidade As Integer = CInt(reader("total_vendas"))
            series.Points.AddXY(produto, quantidade)
        End While

        ' Fecha a conexão com o banco de dados
        connection.Close()

        ' Define o título do eixo Y
        Chart1.ChartAreas(0).AxisY.Title = "Total de Vendas"

        ' Formata os valores no eixo Y como números inteiros
        Chart1.ChartAreas(0).AxisY.LabelStyle.Format = "N0" ' Formato de número inteiro sem casas decimais

        ' Exibe uma legenda no eixo X para os produtos
        Chart1.ChartAreas(0).AxisX.Title = "Produtos"

        ' Remove a legenda de cores
        Chart1.Legends.Clear()

        ' Ajusta o tamanho da área de gráfico para preencher todo o controle Chart
        Chart1.ChartAreas(0).Position.Auto = False
        Chart1.ChartAreas(0).Position.Width = 100 ' Largura de 100% do controle Chart
        Chart1.ChartAreas(0).Position.Height = 100 ' Altura de 100% do controle Chart
        Chart1.ChartAreas(0).Position.X = 0 ' Posição X inicial no controle Chart
        Chart1.ChartAreas(0).Position.Y = 0 ' Posição Y inicial no controle Chart
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Cria um objeto para impressão
        Dim printDialog As New PrintDialog()

        ' Define o objeto a ser impresso como o gráfico
        printDialog.Document = New Printing.PrintDocument()
        printDialog.Document.PrinterSettings = New Printing.PrinterSettings()

        ' Configuração do diálogo de impressão
        If printDialog.ShowDialog() = DialogResult.OK Then
            ' Imprime o gráfico
            Chart1.Printing.Print(True)
        End If
    End Sub
End Class
