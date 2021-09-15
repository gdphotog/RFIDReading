Imports forms

Class MainWindow


  Public rfidraw As String
  Public rfidCorrected As String
  Public LongFolio As Long = 0


  Private Sub txtRFIDInput_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtRFIDInput.KeyDown
    If e.Key = Key.Enter Then

      rfidraw = txtRFIDInput.Text.ToString
      txtRFIDInput.Clear()
      LblRawHEX.Content = rfidraw

      'Flip the HEX Data so it can be decoded.
      ConvertRFID()
      LblDecodedHEX.Content = rfidCorrected

      'Convert HEX to Folio
      LongFolio = Convert.ToInt64(rfidCorrected, 16)
      Lbl16DigitFolio.Content = LongFolio
      rfidraw = ""
      rfidCorrected = ""
      LongFolio = 0
      txtRFIDInput.Clear()
    End If

  End Sub

  Sub ConvertRFID()
    While Len(rfidraw) > 0
      rfidCorrected = rfidCorrected + Right(rfidraw, 2)
      rfidraw = rfidraw.Trim().Remove(rfidraw.Length - 2)
      Debug.WriteLine(rfidCorrected)
    End While
  End Sub
End Class
