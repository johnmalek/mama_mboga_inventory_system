Public Class LoginWelcomeForm
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        LoginForm.Show()
        LoginForm.txtUsername.Clear()
        LoginForm.txtPassword.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DashboardForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
End Class