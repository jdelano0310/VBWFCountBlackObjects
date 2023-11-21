<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pbSelectedImage = New PictureBox()
        btnSelectImage = New Button()
        btnAskOpenAI = New Button()
        ofDialog = New OpenFileDialog()
        txtResponse = New TextBox()
        CType(pbSelectedImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pbSelectedImage
        ' 
        pbSelectedImage.Location = New Point(148, 16)
        pbSelectedImage.Name = "pbSelectedImage"
        pbSelectedImage.Size = New Size(511, 346)
        pbSelectedImage.TabIndex = 0
        pbSelectedImage.TabStop = False
        ' 
        ' btnSelectImage
        ' 
        btnSelectImage.Location = New Point(12, 16)
        btnSelectImage.Name = "btnSelectImage"
        btnSelectImage.Size = New Size(112, 34)
        btnSelectImage.TabIndex = 1
        btnSelectImage.Text = "Select Image"
        btnSelectImage.UseVisualStyleBackColor = True
        ' 
        ' btnAskOpenAI
        ' 
        btnAskOpenAI.Location = New Point(12, 66)
        btnAskOpenAI.Name = "btnAskOpenAI"
        btnAskOpenAI.Size = New Size(112, 34)
        btnAskOpenAI.TabIndex = 2
        btnAskOpenAI.Text = "Ask Open AI"
        btnAskOpenAI.UseVisualStyleBackColor = True
        ' 
        ' txtResponse
        ' 
        txtResponse.Location = New Point(149, 378)
        txtResponse.Name = "txtResponse"
        txtResponse.Size = New Size(508, 23)
        txtResponse.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(667, 428)
        Controls.Add(txtResponse)
        Controls.Add(btnAskOpenAI)
        Controls.Add(btnSelectImage)
        Controls.Add(pbSelectedImage)
        Name = "Form1"
        Text = "Form1"
        CType(pbSelectedImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pbSelectedImage As PictureBox
    Friend WithEvents btnSelectImage As Button
    Friend WithEvents btnAskOpenAI As Button
    Friend WithEvents ofDialog As OpenFileDialog
    Friend WithEvents txtResponse As TextBox

End Class
