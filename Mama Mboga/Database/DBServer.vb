Imports System.Data
Imports System.Data.SqlClient
Module DBServer
    Public conn As New SqlConnection("Data Source=MALEK\SQLEXPRESS;Initial Catalog=Mama Mboga;Integrated Security=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public ds As New DataSet
    Public dt As DataTable
    Public qr As String
    Public i As Integer

    Public Function searchData(ByVal qr As String) As DataSet
        da = New SqlDataAdapter(qr, conn)
        ds = New DataSet
        da.Fill(ds)
        Return ds
    End Function

    Public Function insertData(ByVal qr As String) As Integer
        cmd = New SqlCommand(qr, conn)
        conn.Open()
        i = cmd.ExecuteNonQuery()
        conn.Close()
        Return i
    End Function

End Module
