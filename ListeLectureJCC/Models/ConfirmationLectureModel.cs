using System;

namespace ListeLectureJCC.Models
{
    public class ConfirmationLectureModel
    {
        public string Titre { get; private set; }
        public DateTime DateFinDeLecture { get; private set; }

        public ConfirmationLectureModel(string titre, DateTime dateFinDeLecture)
        {
            Titre = titre;
            DateFinDeLecture = dateFinDeLecture;
        }
    }
}