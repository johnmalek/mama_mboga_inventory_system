Imports System.Data.SqlClient
Public Class LoginForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        isValidForm()

        conn.Open()

        Dim stmt As String = "SELECT * FROM Users WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'"
        cmd = New SqlCommand(stmt, conn)

        Dim reader As SqlDataReader = cmd.ExecuteReader
        If reader.Read Then
            MessageBox.Show("You have logged in succesfully")
            Me.Hide()
            LoginWelcomeForm.Show()
        Else
            MessageBox.Show("Invalid login details")
            txtPassword.Clear()
            txtUsername.Clear()
        End If
        conn.Close()
    End Sub

    Private Function isValidForm() As Boolean
        If (txtUsername.Text.Trim = String.Empty) Then
            MsgBox("Username cannot be Empty", MsgBoxStyle.Critical)
            txtUsername.Clear()
            txtPassword.Clear()
            Return False
        End If

        If (txtPassword.Text.Trim = String.Empty) Then
            MsgBox("Password cannot be Empty", MsgBoxStyle.Critical)
            txtPassword.Clear()
            txtPassword.Clear()
            Return False
        End If

        Return True
    End Function



End Class