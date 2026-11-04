Imports System.Data.SqlClient
Imports System.IO

Module Module1
    Public username As String
    Public nome As String
    Public nivel As Integer

    ''' <summary>
    ''' String de ligação dinâmica e portável à base de dados SQL Server (LocalDB).
    ''' Resolve o caminho do ficheiro MDF relativamente ao diretório da aplicação,
    ''' permitindo executar o projeto em qualquer computador sem caminhos fixos (hardcoded).
    ''' </summary>
    Public ReadOnly Property cs As String
        Get
            Dim appPath As String = AppDomain.CurrentDomain.BaseDirectory
            Dim dbPath As String = Path.Combine(appPath, "BDcabeleireiro.mdf")

            ' Se existir ficheiro no diretório do executável
            If File.Exists(dbPath) Then
                Return String.Format("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='{0}';Integrated Security=True;Connect Timeout=30", dbPath)
            End If

            ' Fallback para instância LocalDB ou ligação padrão
            Return "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BDcabeleireiro.mdf;Integrated Security=True;Connect Timeout=30"
        End Get
    End Property
End Module
