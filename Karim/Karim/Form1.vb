Imports System.Data.SqlClient
Imports System.IO

Public Class Form1

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Reset()
        If LblID.Text = "" Then
            LblID.Text = "1"
        Else
            AutoNumber()
        End If
        GetData()
    End Sub
    Sub AutoNumber()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select  top (1) id from Table_1 ORDER BY id DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()

            While (rdr.Read() = True)

                lblID.Text = rdr(0) + 1
            End While

            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()

    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  MasterID, Name, WorkAddress, HomeAddress, Phone1, Phone2, JobTitle, JobID, Email, Notes from TblMaster", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()

            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))

            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub Reset()
        TextName.Text = ""
        TextWorkAddress.Text = ""
        TextHomeAddress.Text = ""
        TextPhone1.Text = ""
        TextPhone2.Text = ""
        TextJobTitle.Text = ""
        TextJobID.Text = ""
        TextEmail.Text = ""
        TextNotes.Text = ""
        LblID.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Len(Trim(TextName.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل الاسم", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextName.Focus()
            Exit Sub
        End If

        If Len(Trim(TextWorkAddress.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل عنوان العمل", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextWorkAddress.Focus()
            Exit Sub
        End If

        If Len(Trim(TextHomeAddress.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل عنوان المنزل", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextHomeAddress.Focus()
            Exit Sub
        End If

        If Len(Trim(TextPhone1.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل رقم الهاتف 1", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextPhone1.Focus()
            Exit Sub
        End If

        If Len(Trim(TextPhone2.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل رقم الهاتف 2", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextPhone2.Focus()
            Exit Sub
        End If

        If Len(Trim(TextJobTitle.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل المسمي الوظيفي", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextJobTitle.Focus()
            Exit Sub
        End If

        If Len(Trim(TextJobID.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل الرقم الوظيفي", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextJobID.Focus()
            Exit Sub
        End If

        If Len(Trim(TextEmail.Text)) = 0 Then
            MessageBox.Show("منفضلك ادخل الايميل", "حقل اجباري", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEmail.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Insert into TblMaster(Name,WorkAddress,HomeAddress,Phone1,Phone2,JobTitle,JobID,Email,Notes)Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", TextName.Text)
            cmd.Parameters.AddWithValue("@d2", TextWorkAddress.Text)
            cmd.Parameters.AddWithValue("@d3", TextHomeAddress.Text)
            cmd.Parameters.AddWithValue("@d4", TextPhone1.Text)
            cmd.Parameters.AddWithValue("@d5", TextPhone2.Text)
            cmd.Parameters.AddWithValue("@d6", TextJobTitle.Text)
            cmd.Parameters.AddWithValue("@d7", TextJobID.Text)
            cmd.Parameters.AddWithValue("@d8", TextEmail.Text)
            cmd.Parameters.AddWithValue("@d9", TextNotes.Text)
            cmd.Connection = con
            Dim ms As New MemoryStream
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("تم الحفظ بنجاح")
            GetData()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LblID_Click(sender As Object, e As EventArgs) Handles LblID.Click

        '    LblID.Text = rdr(0) + 1

    End Sub

    Private Sub Values(p1 As Object, p2 As Object, p3 As Object, p4 As Object, p5 As Object, p6 As Object, p7 As Object, p8 As Object, p9 As Object, p10 As Object)
        Throw New NotImplementedException
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DeleteData()
    End Sub
    Sub DeleteData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("delete from TblMaster where MasterID=" & LblID.Text & "", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            con.Close()
            MessageBox.Show("تم الحذف بنجاح")
            GetData()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Reset()
        GetData()

    End Sub

    Private Sub LblID_TextChanged(sender As Object, e As EventArgs) Handles LblID.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw.CellClick
        Dim vr As DataGridViewRow = dgw.SelectedRows(0)
        LblID.Text = vr.Cells(0).Value.ToString
        TextName.Text = vr.Cells(1).Value.ToString
        TextWorkAddress.Text = vr.Cells(2).Value.ToString
        TextHomeAddress.Text = vr.Cells(3).Value.ToString
        TextPhone1.Text = vr.Cells(4).Value.ToString
        TextPhone2.Text = vr.Cells(5).Value.ToString
        TextJobTitle.Text = vr.Cells(6).Value.ToString
        TextJobID.Text = vr.Cells(7).Value.ToString
        TextEmail.Text = vr.Cells(8).Value.ToString
        TextNotes.Text = vr.Cells(9).Value.ToString
    End Sub

    Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgw.CellContentClick

    End Sub
End Class