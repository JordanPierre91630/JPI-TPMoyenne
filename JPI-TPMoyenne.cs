using System;

using System.Collections.Generic;

using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace TPMoyennes
{
    class Eleve
    {
        public String prenom;
        public String nom;
        public List<Note> notes = new List<Note>(); 

        public void ajouterNote(Note note)
        {
            notes.Add(note);
        }

        public float moyenneMatiere(int M)
        {
            float Sum = 0;
            float Tally = 0;

            foreach (Note note in notes) 
            {
                if (note.matiere == M)
                {
                    Sum =+ note.note;
                    Tally =+ 1;
                }
            }
            return Sum / Tally;
        }
        public float moyenneGeneral()
        {
            float Sum = 0;
            float Tally = 0;
            foreach (Note note in notes)
            {
                Sum += moyenneMatiere(note.matiere);
                Tally += 1;
            }
            return Sum / Tally;
        }



    }
    
    class Classe
    {
        public String nomClasse;
        public List<Eleve> eleves = new List<Eleve>();
        public List<String> matieres = new List<String>();
        
        public Classe(String Nom) 
        {
            this.nomClasse = Nom;
        }
        public void ajouterEleve(String Fname, String Lname)
        {
            Eleve eleve = new Eleve();
            eleve.nom = Lname;
            eleve.prenom = Fname;
            eleves.Add(eleve);
        }
        public void ajouterMatiere(String matiere)
        {
            matieres.Add(matiere);
        }
        public float moyenneMatiere(int M)
        {
            float Sum = 0;
            float Tally = 0;
            foreach (Eleve eleve in eleves)
            {
                Sum += eleve.moyenneMatiere(M);
                Tally += 1;
            }
            return Sum / Tally;
        }
        public float moyenneGeneral()
        {
            float Sum = 0;
            float Tally = 0;
            foreach (String matiere in matieres)
            {
                Sum += moyenneMatiere(matieres.IndexOf(matiere));
                Tally += 1;
            }
            return Sum / Tally;

        }
        
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.ajouterEleve("Jean", "RAGE");
            sixiemeA.ajouterEleve("Paul", "HAAR");
            sixiemeA.ajouterEleve("Sibylle", "BOQUET");
            sixiemeA.ajouterEleve("Annie", "CROCHE");
            sixiemeA.ajouterEleve("Alain", "PROVISTE");
            sixiemeA.ajouterEleve("Justin", "TYDERNIER");
            sixiemeA.ajouterEleve("Sacha", "TOUILLE");
            sixiemeA.ajouterEleve("Cesar", "TICHO");
            sixiemeA.ajouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.ajouterMatiere("Francais");
            sixiemeA.ajouterMatiere("Anglais");
            sixiemeA.ajouterMatiere("Physique/Chimie");
            sixiemeA.ajouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].ajouterNote(new Note(matiere, (float)((6.5 +
                       random.NextDouble() * 34)) / 2.0f));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.moyenneMatiere(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.moyenneGeneral() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.moyenneMatiere(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.moyenneGeneral() + "\n");
            Console.Read();
        }
    }
}



