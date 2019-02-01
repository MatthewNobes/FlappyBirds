Public Class Form1
    Dim score As Byte = 0
    Dim message As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tmrOne.Enabled = True
    End Sub

    Private Sub tmrOne_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrOne.Tick

        picBird.Left = picBird.Left + 2
        picBird.Top = picBird.Top + 4
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Up
                picBird.Top -= 10
        End Select

        If CollidesWithPipe(picBird) = True Then
            tmrOne.Enabled = False
            tmrTwo.Enabled = True

            Select Case picBird.Left
                Case Is < 200
                    score = 0
                    message = "yr crap!"
                Case Is < 300
                    score = 2
                    message = "meh"
                Case Else
                    score = 4
                    message = "well done!"
            End Select
            picBird.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            MessageBox.Show(message & vbCr & " you scored " & score & " points")
        End If

    End Sub
    Private Function CollidesWithPipe(ByVal Pic As PictureBox) As Boolean
        Dim ctl As Control
        For Each ctl In Me.Controls
            If ctl Is picTube0 Or ctl Is picTube1 Or ctl Is picTube2 Or ctl Is picTube3 Or ctl Is picTube4 Or ctl Is picTube5 Or ctl Is picTube6 Or ctl Is picTube7 Or ctl Is picTube8 Or ctl Is picTube9 Then
                If ctl.Bounds.IntersectsWith(Pic.Bounds) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub tmrTwo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTwo.Tick
        picBird.Top = picBird.Top + 2
        If picBird.Top > 250 Then
            picBird.Top = 250
        End If
    End Sub
End Class

