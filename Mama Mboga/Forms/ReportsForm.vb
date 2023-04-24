Imports System.Data
Imports System.Data.SqlClient
Public Class ReportsForm
    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showReport()
    End Sub
    Public Sub showReport()
        ds.Clear()
        conn.Close()
        conn.Open()
        qr = "SELECT * FROM Products"
        ds = searchData(qr)
        Dim adpt As New SqlDataAdapter(qr, conn)
        adpt.Fill(ds, "Products")
        DataGridViewReport.DataSource = ds.Tables(0)
        conn.Close()
    End Sub
End Class