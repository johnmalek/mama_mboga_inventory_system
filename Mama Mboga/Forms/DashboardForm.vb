Public Class DashboardForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoginForm.Show()
        LoginForm.txtUsername.Clear()
        LoginForm.txtPassword.Clear()
        Me.Hide()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        isValidForm()
        qr = "INSERT INTO Products VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')"
        Dim loginCorrect As Boolean = Convert.ToBoolean(insertData(qr))
        If (loginCorrect) Then
            bindGD()
            MsgBox("Product added successfully", MsgBoxStyle.Information)
            clear()
        Else
            MsgBox("Product not added", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Function isValidForm() As Boolean
        If (TextBox1.Text.Trim = String.Empty) Then
            MsgBox("Product Name cannot be Empty", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Return False
        End If

        If (TextBox2.Text.Trim = String.Empty) Then
            MsgBox("Product Price cannot be Empty", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Return False
        End If

        If (TextBox4.Text.Trim = String.Empty) Then
            MsgBox("Supplier Name cannot be Empty", MsgBoxStyle.Critical)
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            Return False
        End If

        Return True
    End Function

    Public Sub bindGD()
        qr = "SELECT * FROM Products"
        ds = searchData(qr)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("Record not found", MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        LoginWelcomeForm.show()
        Me.Hide()
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bindGD()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        i = DataGridView1.CurrentRow.Index

        If (i >= 0) Then
            Me.TextBox1.Text = DataGridView1.Item(0, i).Value
            Me.TextBox2.Text = DataGridView1.Item(1, i).Value
            Me.TextBox3.Text = DataGridView1.Item(2, i).Value
            Me.TextBox4.Text = DataGridView1.Item(3, i).Value
            Me.TextBox5.Text = DataGridView1.Item(4, i).Value
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If (isValidForm()) Then
            Try
                qr = "UPDATE Products SET ProductName = '" + TextBox1.Text + "', ProductPrice = '" + TextBox2.Text + "', ProductDescription = '" + TextBox3.Text + "', SupplierName = '" + TextBox4.Text + "', Quantity = '" + TextBox5.Text + "' WHERE ProductName = '" + TextBox1.Text + "'"
                Dim isUpdatedTrue As Boolean = Convert.ToBoolean(insertData(qr))
                If (isUpdatedTrue) Then
                    bindGD()
                    MsgBox("Product updated successfully", MsgBoxStyle.Information)
                    clear()
                Else
                    MsgBox("Product not updated", MsgBoxStyle.Critical)
                    clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message(), MsgBoxStyle.Information)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim result As Integer = MsgBox("Are you sure you want to do delete this record?", MsgBoxStyle.YesNo)
        If result = DialogResult.No Then
        ElseIf result = DialogResult.Yes Then
            If (isValidForm2()) Then
                qr = "DELETE FROM Products WHERE ProductName = '" + TextBox1.Text + "'"
                Dim deleteAction As Boolean = Convert.ToBoolean(insertData(qr))
                If (deleteAction) Then
                    bindGD()
                    MsgBox("Product deleted succesfully", MsgBoxStyle.Information)
                    clear()
                Else
                    MsgBox("Product not deleted", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Function isValidForm2() As Boolean
        If (TextBox1.Text.Trim = String.Empty) Then
            MsgBox("Product Name cannot be Empty", MsgBoxStyle.Critical)
        End If
        Return True
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        qr = "SELECT * FROM Products WHERE ProductName = '" + txtSearch.Text + "'"
        ds = searchData(qr)
        If (ds.Tables(0).Rows.Count > 0) Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            MsgBox("Record not found", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ReportsForm.Show()
    End Sub
End Class