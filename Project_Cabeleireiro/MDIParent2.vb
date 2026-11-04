Imports System.Windows.Forms

Public Class MDIParent2

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    '-------------------------------------------------------------------------------------------------------------
 
    Private Sub MDIParent2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = nome & " tem sessão iniciada - Nivel : " & nivel
        If nivel = 2 Then
            ListasDeDadosToolStripMenuItem.Visible = True
            AtualizarFuncionarioToolStripMenuItem.Visible = True
            InserirDadosToolStripMenuItem.Visible = True
            ApagarToolStripMenuItem1.Visible = True
        End If
    End Sub


    Private Sub ListasDeDadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListasDeDadosToolStripMenuItem.Click
        Listar.Show()
    End Sub

    Private Sub ApagarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ApagarToolStripMenuItem1.Click

    End Sub

    Private Sub InserirClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirClienteToolStripMenuItem.Click
        inserircliente.Show()
    End Sub

    Private Sub InserirFuncionarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirFuncionarioToolStripMenuItem.Click
        inserirfuncionario.Show()
    End Sub

    Private Sub InserirFornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirFornecedorToolStripMenuItem.Click
        inserirfornecedor.Show()
    End Sub

    Private Sub InserirProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirProdutoToolStripMenuItem.Click
        inserirproduto.Show()
    End Sub

    Private Sub InserirServiçoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirServiçoToolStripMenuItem.Click
        inserirservico.Show()
    End Sub

    Private Sub InserirAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirAreaToolStripMenuItem.Click
        inserirarea.Show()
    End Sub

    Private Sub InserirCategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirCategoriaToolStripMenuItem.Click
        inserircategoria.Show()
    End Sub

    Private Sub ApagarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarClienteToolStripMenuItem.Click
        apagarcliente.Show()
    End Sub

    Private Sub ApagarFuncionarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarFuncionarioToolStripMenuItem.Click
        apagarfuncionario.Show()
    End Sub

    Private Sub ApagarFornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarFornecedorToolStripMenuItem.Click
        apagarfornecedor.Show()
    End Sub

    Private Sub ApagarProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarProdutoToolStripMenuItem.Click
        apagarproduto.Show()
    End Sub

    Private Sub ApagarServiçoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarServiçoToolStripMenuItem.Click
        apagarservico.Show()
    End Sub

    Private Sub ApagarAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarAreaToolStripMenuItem.Click
        apagararea.Show()
    End Sub

    Private Sub ApagarCategoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApagarCategoriaToolStripMenuItem.Click
        apagarcategoria.Show()
    End Sub

    Private Sub AtualizarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtualizarClienteToolStripMenuItem.Click
        atualizarcliente.Show()
    End Sub

    Private Sub AtualizarFuncionarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtualizarFuncionarioToolStripMenuItem.Click
        atualizarfuncionario.Show()
    End Sub

    Private Sub ProcurarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcurarClienteToolStripMenuItem.Click
        procurarcliente.Show()
    End Sub

    Private Sub ProcurarFuncionarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcurarFuncionarioToolStripMenuItem.Click
        procurarfuncionario.Show()
    End Sub

    Private Sub ProcurarFornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcurarFornecedorToolStripMenuItem.Click
        procurarfornecedor.Show()
    End Sub

    Private Sub ProcurarProdutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcurarProdutoToolStripMenuItem.Click
        procurarproduto.Show()
    End Sub

    Private Sub ProcurarServiçoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcurarServiçoToolStripMenuItem.Click
        procurarservico.Show()
    End Sub



    Private Sub AgendarServiçoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendarServiçoToolStripMenuItem.Click
        agendarservico.Show()
    End Sub

    Private Sub VerAgendaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerAgendaToolStripMenuItem.Click
        veragenda.Show()
    End Sub

    Private Sub MarcaçõesParaHojeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcaçõesParaHojeToolStripMenuItem.Click
        marcacoeshoje.Show()
    End Sub

    Private Sub QualOProximoClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QualOProximoClienteToolStripMenuItem.Click
        proximocliente.Show()
    End Sub

    Private Sub VenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem.Click
        saidaprodutos.Show()
    End Sub

    Private Sub EntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradaToolStripMenuItem.Click
        entradaprodutos.Show()
    End Sub

    Private Sub ProdutosVendidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdutosVendidosToolStripMenuItem.Click
        produtosvendidos.Show()
    End Sub

    Private Sub ProdutosEmStockMinimoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdutosEmStockMinimoToolStripMenuItem.Click
        produtosstockminimo.Show()
    End Sub

    Private Sub GraficosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GraficosToolStripMenuItem.Click

    End Sub

    Private Sub ProdutosMaisVendidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdutosMaisVendidosToolStripMenuItem.Click
        ProdutosMaisVendidos.show()
    End Sub

    Private Sub EditMenu_Click(sender As Object, e As EventArgs) Handles EditMenu.Click

    End Sub
End Class
