using System;

namespace ListeLectureJCC.Models
{
    public class DetailModel
    {
        public string Titre { get; private set; }
        public string Auteur { get; private set; }
        public DateTime DateDeDebutDeLecture { get; private set; }
        public DateTime? DateDeFinDeLecture { get; private set; }
        public short? Note { get; private set; }
        public int ID { get; private set; }

        public DetailModel(string titre, string auteur, DateTime dateDeDebutDeLecture, DateTime? dateDeFinDeLecture, short? note, int id)
        {
            Titre = titre;
            Auteur = auteur;
            DateDeDebutDeLecture = dateDeDebutDeLecture;
            DateDeFinDeLecture = dateDeFinDeLecture;
            Note = note;
            ID = id;
        }
    }
}