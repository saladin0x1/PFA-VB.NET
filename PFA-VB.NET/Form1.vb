Public Class Form1

    ' Définir les variables pour stocker les notes et les informations des étudiants
    Private Const MaxEtudiants As Integer = 100 ' Nombre maximum d'étudiants
    Private notes(MaxEtudiants - 1) As Double
    Private infosEtudiants(MaxEtudiants - 1)() As String
    Private nbEtudiants As Integer = 0

    ' Bouton pour ajouter la note de l'étudiant
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Stocker les informations de l'étudiant
        Dim nom As String = TextBox1.Text
        Dim prenom As String = TextBox2.Text
        Dim note As Double

        ' Assigner directement la valeur du TextBox3.Text à la variable 'note'
        If Double.TryParse(TextBox3.Text, note) AndAlso note >= 0 AndAlso note <= 20 Then
            ' Ajouter les informations de l'étudiant s'il y a de la place disponible
            If nbEtudiants < MaxEtudiants Then
                notes(nbEtudiants) = note
                infosEtudiants(nbEtudiants) = {nom, prenom}

                nbEtudiants += 1
                Label7.Text = nbEtudiants.ToString() & " étudiant(s) sont enregistré(s)."
            Else
                MessageBox.Show("Le nombre maximum d'étudiants est atteint.", "Erreur")
            End If
        Else
            MessageBox.Show("Veuillez saisir une note valide entre 0 et 20.", "Erreur de saisie")
        End If
    End Sub

    ' Bouton pour calculer la moyenne des notes
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Calculer la moyenne des notes
        If nbEtudiants > 0 Then
            Dim somme As Double = 0
            For i As Integer = 0 To nbEtudiants - 1
                somme += notes(i)
            Next
            Dim moyenne As Double = somme / nbEtudiants
            Label1.Text = "La moyenne des notes est : " & moyenne.ToString()
        Else
            Label1.Text = "Aucune note enregistrée."
        End If
    End Sub

    ' Bouton pour trouver la note maximale
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Trouver la note maximale
        If nbEtudiants > 0 Then
            Dim noteMax As Double = notes(0)
            Dim index As Integer = 0
            For i As Integer = 1 To nbEtudiants - 1
                If notes(i) > noteMax Then
                    noteMax = notes(i)
                    index = i
                End If
            Next
            Dim infos() As String = infosEtudiants(index)
            Label2.Text = "La note maximale est : " & noteMax.ToString() & " (obtenue par " & infos(0) & " " & infos(1) & ")"
        Else
            Label2.Text = "Aucune note enregistrée."
        End If
    End Sub

    ' Bouton pour trouver la note minimale
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Trouver la note minimale
        If nbEtudiants > 0 Then
            Dim noteMin As Double = notes(0)
            Dim index As Integer = 0
            For i As Integer = 1 To nbEtudiants - 1
                If notes(i) < noteMin Then
                    noteMin = notes(i)
                    index = i
                End If
            Next
            Dim infos() As String = infosEtudiants(index)
            Label3.Text = "La note minimale est : " & noteMin.ToString() & " (obtenue par " & infos(0) & " " & infos(1) & ")"
        Else
            Label3.Text = "Aucune note enregistrée."
        End If
    End Sub

    ' Bouton pour effacer la liste des notes
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Réinitialiser le nombre d'étudiants à 0
        nbEtudiants = 0
        Label7.Text = "0 étudiant(s) sont enregistré(s)."
        Label1.Text = " "
        Label2.Text = " "
        Label3.Text = " "
    End Sub

    ' Événement Load du formulaire
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialiser les tableaux
        For i As Integer = 0 To MaxEtudiants - 1
            infosEtudiants(i) = New String(1) {}
        Next
    End Sub

    ' Événement KeyPress pour TextBox3 pour valider la saisie
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        ' Autoriser uniquement les caractères numériques et le point décimal
        If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "." OrElse e.KeyChar = Convert.ToChar(Keys.Back)) Then
            e.Handled = True
        End If
    End Sub

    ' Événement KeyPress pour TextBox1 (Nom) et TextBox2 (Prénom)
    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
        ' Autoriser uniquement les lettres, les espaces, les tirets et les apostrophes
        If Not (Char.IsLetter(e.KeyChar) OrElse e.KeyChar = " "c OrElse e.KeyChar = "-"c OrElse e.KeyChar = "'"c OrElse e.KeyChar = Convert.ToChar(Keys.Back)) Then
            e.Handled = True
        End If
    End Sub
End Class
