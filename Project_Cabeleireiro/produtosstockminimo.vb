Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class produtosstockminimo

    Private Sub produtosstockminimo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MDIParent2
        Dim con As New SqlConnection(cs)
        con.Open()
        Dim sql As String = "select id,nome,pvp,fornecedor,quantidade,stock_minimo from produtos where quantidade <= stock_minimo"
        Dim sqlcom As New SqlCommand(sql, con)

        ' Preenchendo a DataGridView
        Using dr As SqlDataReader = sqlcom.ExecuteReader()
            DataGridView1.Columns.Clear()
            Dim n As Integer = dr.FieldCount
            For k As Integer = 0 To n - 1
                Dim campo As String = dr.GetName(k)
                DataGridView1.Columns.Add(campo, campo)
            Next

            While dr.Read()
                Dim rowIndex As Integer = DataGridView1.Rows.Add()
                For a As Integer = 0 To n - 1
                    DataGridView1.Rows(rowIndex).Cells(a).Value = dr(a)
                Next
            End While
        End Using

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog() = DialogResult.OK Then
            Dim printDocument As New Printing.PrintDocument()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
            printDocument.DefaultPageSettings.Landscape = True ' Orientação paisagem
            printDocument.Print()
        End If
    End Sub

    Private Sub PrintDocument_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim dgv As DataGridView = DataGridView1
        Dim printArea As Rectangle = e.MarginBounds
        Dim scaleFactor As Single = 0.8F ' Fator de escala para reduzir o tamanho da impressão
        Dim scaledWidth As Integer = CInt(dgv.Width * scaleFactor)
        Dim scaledHeight As Integer = CInt(dgv.Height * scaleFactor)
        Dim bitmap As New Bitmap(scaledWidth, scaledHeight)
        dgv.DrawToBitmap(bitmap, New Rectangle(0, 0, scaledWidth, scaledHeight))
        e.Graphics.DrawImage(bitmap, printArea.Left, printArea.Top, printArea.Width, printArea.Height)
    End Sub
End Class
