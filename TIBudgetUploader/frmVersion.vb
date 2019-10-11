Public Class frmVersion

    Private Sub frmVersion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim version As Version = assembly.GetName().Version        

        lblVersion.Text = version.ToString()
        lblMajor.Text = version.MajorRevision.ToString()
        lblMinor.Text = version.MinorRevision.ToString()
        lblBuild.Text = version.Build.ToString()
        lblRevision.Text = version.Revision.ToString()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class