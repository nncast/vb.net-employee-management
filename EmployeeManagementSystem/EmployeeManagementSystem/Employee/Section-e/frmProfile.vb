Public Class frmProfile

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim oldPass As String = txtoldpass.Text.Trim()
        Dim newPass As String = txtnewpass.Text.Trim()
        Dim confirmNewPass As String = txtnewpass2.Text.Trim()

        If oldPass = "" Or newPass = "" Or confirmNewPass = "" Then
            MsgBox("Please fill in all the fields.", MsgBoxStyle.Exclamation, "Missing Information")
            Exit Sub
        End If

        GetQuery("SELECT password FROM tbllogin WHERE employeeid = @id", "tbllogin", P("@id", loggedinemployeeid))

        If ds.Tables("tbllogin").Rows.Count > 0 Then
            Dim currentPassword As String = ds.Tables("tbllogin").Rows(0)("password").ToString()

            If VerifyPassword(oldPass, currentPassword) Then
                If newPass = oldPass Then
                    MsgBox("The new password cannot be the same as the old password.", MsgBoxStyle.Critical, "Password Error")
                    Exit Sub
                End If

                If newPass.Length < MinPasswordLength Then
                    MsgBox("The new password must be at least " & MinPasswordLength & " characters.", MsgBoxStyle.Critical, "Password Error")
                    Exit Sub
                End If

                If newPass = confirmNewPass Then
                    If SetQuery("UPDATE tbllogin SET password = @p WHERE employeeid = @id", P("@p", HashPassword(newPass)), P("@id", loggedinemployeeid)) Then
                        clearfields()

                        MsgBox("Password changed successfully!", MsgBoxStyle.Information, "Success")
                    End If
                Else
                    MsgBox("The new password and confirmation do not match.", MsgBoxStyle.Critical, "Password Mismatch")
                End If
            Else
                MsgBox("Old password is incorrect. Please try again.", MsgBoxStyle.Critical, "Password Error")
            End If
        Else
            MsgBox("Employee not found. Please try again.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub clearfields()
        txtoldpass.Clear()
        txtnewpass.Clear()
        txtnewpass2.Clear()
    End Sub

End Class
