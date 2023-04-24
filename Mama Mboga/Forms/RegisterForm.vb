Imports System.Data
Imports System.Data.SqlClient

Public Class RegisterForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As SqlConnection = New SqlConnection("Data Source=MALEK\SQLEXPRESS;Initial Catalog=Mama Mboga;Integrated Security=True")
        Dim cmd As SqlCommand = New SqlCommand("INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[Phone]
           ,[County]
           ,[Username]
           ,[Password])
     VALUES
           ('" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtPhone.Text + "', '" + txtCounty.Text + "', '" + txtUsernameReg.Text + "', '" + txtPasswordReg.Text + "')", conn)
        conn.Open()
        cmd.ExecuteNonQuery()
        MessageBox.Show("Succesfully Registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        conn.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        WelcomeForm.Show()
        Me.Hide()
    End Sub


End Class