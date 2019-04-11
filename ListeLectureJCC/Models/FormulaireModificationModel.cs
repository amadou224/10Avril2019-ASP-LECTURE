namespace ListeLectureJCC.Models
{
    public class FormulaireModificationModel
    {
        public Livre LivreEnCoursDeModification { get; private set; }

        public FormulaireModificationModel(Livre livreEnCoursDeModification)
        {
            this.LivreEnCoursDeModification = livreEnCoursDeModification;
        }
    }
}