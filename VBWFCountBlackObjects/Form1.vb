Imports System.IO
Imports System.Net.Http
Imports System.Security.Policy
Imports System.Text

Public Class Form1
    Dim image_path As String

    Public Function ImageToBase64() As String
        Using ms As New MemoryStream()
            ' Convert Image to byte[]
            Dim image As Image = Bitmap.FromFile(image_path)
            Dim format As System.Drawing.Imaging.ImageFormat = Imaging.ImageFormat.Bmp

            Select Case image_path.Substring(image_path.Length - 4)
                Case ".png"
                    format = Imaging.ImageFormat.Png
                Case ".jpg"
                    format = Imaging.ImageFormat.Jpeg

            End Select

            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray() ' Convert byte[] to Base64 String
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function

    Private Async Function SendToOpenAI() As Task(Of String)

        Dim openAIkey = "********* YOUR OPEN AI KEY GOES HERE ********************"
        Dim base64_image As String = ImageToBase64()
        Dim url = "https://api.openai.com/v1/chat/completions"
        Dim responseContent

        Using client As HttpClient = New HttpClient()
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAIkey}")

            Dim payload = New With
            {
                .model = "gpt-4-vision-preview",
                .messages =
                {
                    New With
                    {
                        .role = "user",
                        .content =
                        {
                            New With
                            {
                                .type = "text",
                                .text = "How many black spots are in this image?"
                            },
                            New With
                            {
                                .type = "image_url",
                                .image_url = New With
                                {
                                    .url = $"data:image/jpeg;base64,{base64_image}"
                                }
                            }
                        }
                    }
                },
                .max_tokens = 300
            }

            Dim jsonPayload = New StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
            Dim response = Await client.PostAsync(url, jsonPayload)
            responseContent = Await response.Content.ReadAsStringAsync()

        End Using

        Return responseContent

    End Function
    Private Sub btnSelectImage_Click(sender As Object, e As EventArgs) Handles btnSelectImage.Click

        ' ask for the image file
        If ofDialog.ShowDialog() = DialogResult.OK Then
            image_path = ofDialog.FileName
            pbSelectedImage.Load(ofDialog.FileName)
        End If

    End Sub

    Private Async Sub btnAskOpenAI_Click(sender As Object, e As EventArgs) Handles btnAskOpenAI.Click

        ' post the image to Open AI and ask it how many black objects there are
        txtResponse.Text = "Asking Open AI"
        Application.DoEvents()

        txtResponse.Text = Await SendToOpenAI()

    End Sub
End Class
