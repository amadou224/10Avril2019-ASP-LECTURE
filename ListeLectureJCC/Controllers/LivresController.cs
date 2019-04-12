using ListeLectureJCC.Models;
using System.Web.Mvc;

namespace ListeLectureJCC.Controllers
{
    public class LivresController : Controller
    {
        public ActionResult Accueil()
        {
            return View();
        }

        public ActionResult Detail(int idLivre)
        {
            DetailModel model = DataAccess.ChargerDetailDepuisBDD(idLivre);
            return View(model);
        }

       // public ActionResult EtatLivreJson(int idLivre)
        //{
         //   return
       // }


        public ActionResult TerminerLivre(int idLivre)
        {
            DataAccess.MettreAJourDateDeFinDeLecture(idLivre);
            return RedirectToAction("ConfirmationLecture", new { idLivre = idLivre });
        }

        public ActionResult ConfirmationLecture(int idLivre)
        {
            ConfirmationLectureModel model = DataAccess.ChargerConfirmationLectureDepuisBDD(idLivre);
            return View(model);
        }

        public ActionResult ConfirmationNotation()
        {
            return View();
        }

        public ActionResult FormulaireCreation()
        {
            return View();
        }

        public ActionResult CreerLeLivre(string titre, string auteur)
        {
            int idLivreeCree = DataAccess.CreerNouveauLivre(titre, auteur);

            return RedirectToAction("Detail", new { idLivre= idLivreeCree });
        }

        public ActionResult AfficherFormulaireModificationLivre(int idLivre)
        {
            Livre livreCourant = DataAccess.ChargerLivreDepuisBDD(idLivre);

            FormulaireModificationModel model = new FormulaireModificationModel(livreCourant);

            return View(model);
        }

        public ActionResult MettreAJourLivre(int idLivre, string titre, string auteur)
        {
            DataAccess.MettreAJouerTitreEtAuteur(idLivre, titre, auteur);         // PAGE VOTE RECUP  
            return RedirectToAction("Detail", new { idLivre = idLivre });
        }
    }
}