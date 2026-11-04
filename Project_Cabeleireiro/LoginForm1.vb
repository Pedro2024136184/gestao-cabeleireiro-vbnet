Imports System.Data.SqlClient
Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim con As New SqlConnection(cs)

        con.Open()





        UsernameTextBox.Text = Replace(UsernameTextBox.Text, "'", "´")
        PasswordTextBox.Text = Replace(PasswordTextBox.Text, "'", "´")

        UsernameTextBox.Text = Replace(UsernameTextBox.Text, ",", ".")
        PasswordTextBox.Text = Replace(PasswordTextBox.Text, ",", ".")

        Dim sql As String = "select * from Funcionarios where UserName='" & UsernameTextBox.Text & "' and Password='" & PasswordTextBox.Text & "'"

        Dim sqlcom As New SqlCommand(sql, con) ' Executa o SQL na ligação à BD que tenho feita
        Dim dr As SqlDataReader = sqlcom.ExecuteReader() ' recebo no dr todos os registos da tabela



        If dr.Read() Then
            username = dr.Item(1)
            nome = dr.Item(4)
            nivel = dr.Item(3)
            MDIParent2.Show()
            Me.Close()
        Else
            MsgBox("A sua password ou nome de utilizador estão incorretos !", vbOK, "Erro")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        username = "admin"
        nome = "Pedro Costa"
        nivel = "2"
        MDIParent2.Show()
        Me.Close()
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged

    End Sub
End Class
