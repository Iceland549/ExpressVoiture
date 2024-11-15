using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpressVoiture.Data;
using Microsoft.AspNetCore.Authorization;

namespace ExpressVoiture.Controllers
{
    public class VoituresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VoituresController> _logger;

        public VoituresController(ApplicationDbContext context, ILogger<VoituresController> logger)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Voitures
        public async Task<IActionResult> Index()
        {
            var listVoitures = await _context.Voitures
                .Include(v => v.Marque)
                .Include(v => v.Modele)
                .ToListAsync();

            return View(listVoitures);
        }

        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voitures/Inventaire
        public IActionResult Inventaire()
        {
            var voitures = _context.Voitures.ToList();
            return View(voitures); // Retourne la vue Inventaire avec la liste de voitures
        }


        // GET: Voitures/Create
        public IActionResult Create()
        {
            var marques = _context.Marques.ToList();
            marques.Add(new Marque { Id = -1, Nom = "-- Ajouter une nouvelle marque --" });
            ViewBag.Marques = new SelectList(marques, "Id", "Nom");
            ViewBag.Modeles = new SelectList(Enumerable.Empty<Modele>(), "Id", "Nom");
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodeVIN,Annee,MarqueId,ModeleId,Finition,DateAchat,PrixAchat,Reparations,CoutsReparations,DateDisponibilite,PrixVente,DateVente")] Voiture voiture, string newMarque, string newModele, IFormFile ImageFile)
        {
            if (!string.IsNullOrEmpty(newMarque) && !string.IsNullOrEmpty(newModele) &&
                newMarque.Equals(newModele, StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("", "La marque et le modèle ne peuvent pas être identiques.");
                PrepareViewBagForCreate(voiture);
                return View(voiture);
            }

            // Ajout de la marque si nécessaire
            if (voiture.MarqueId == -1)
            {
                if (!string.IsNullOrEmpty(newMarque))
                {
                    var marque = new Marque { Nom = newMarque };
                    _context.Marques.Add(marque);
                    await _context.SaveChangesAsync();
                    voiture.MarqueId = marque.Id;
                }
                else
                {
                    ModelState.AddModelError("MarqueId", "Veuillez entrer un nom pour la nouvelle marque.");
                }
            }

            // Ajout du modèle si nécessaire
            if (voiture.ModeleId == -1)
            {
                if (!string.IsNullOrEmpty(newModele))
                {
                    var modele = new Modele { Nom = newModele, MarqueId = voiture.MarqueId };
                    _context.Modeles.Add(modele);
                    await _context.SaveChangesAsync();
                    voiture.ModeleId = modele.Id;
                }
                else
                {
                    ModelState.AddModelError("ModeleId", "Veuillez entrer un nom pour le nouveau modèle.");
                }
            }

            // Vérification de la cohérence entre la marque et le modèle
            var selectedMarque = await _context.Marques.FindAsync(voiture.MarqueId);
            var selectedModele = await _context.Modeles.FindAsync(voiture.ModeleId);

            if (selectedMarque != null && selectedModele != null && selectedModele.MarqueId != selectedMarque.Id)
            {
                ModelState.AddModelError("", "Le modèle sélectionné ne correspond pas à la marque.");
                PrepareViewBagForCreate(voiture);
                return View(voiture);
            }

            // Si toutes les vérifications sont valides, on ajoute la voiture
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }
                    voiture.ImageUrl = "/images/" + fileName;
                }
                _context.Add(voiture);
                await _context.SaveChangesAsync();
                return RedirectToAction("ConfirmationAjout");
            }

            // Préparer les ViewBag pour les sélections de marques et modèles
            var marques = _context.Marques.ToList();
            marques.Add(new Marque { Id = -1, Nom = "-- Ajouter une nouvelle marque --" });
            ViewBag.Marques = new SelectList(marques, "Id", "Nom", voiture.MarqueId);

            var modeles = voiture.MarqueId != -1 ? _context.Modeles.Where(m => m.MarqueId == voiture.MarqueId).ToList() : new List<Modele>();
            modeles.Add(new Modele { Id = -1, Nom = "-- Ajouter un nouveau modèle --" });
            ViewBag.Modeles = new SelectList(modeles, "Id", "Nom", voiture.ModeleId);

            return View(voiture);
        }


        //public JsonResult GetModeles(int marqueId)
        //{
        //    var modeles = _context.Modeles
        //        .Where(m => m.MarqueId == marqueId)
        //        .Select(m => new { m.Id, m.Nom })
        //        .ToList();
        //    modeles.Add(new { Id = -1, Nom = "-- Ajouter un nouveau modèle --" });

        //    return Json(modeles);
        //}

        private void PrepareViewBagForCreate(Voiture voiture)
        {
            var marques = _context.Marques.ToList();
            marques.Add(new Marque { Id = -1, Nom = "-- Ajouter une nouvelle marque --" });
            ViewBag.Marques = new SelectList(marques, "Id", "Nom", voiture.MarqueId);

            var modeles = voiture.MarqueId != -1 ? _context.Modeles.Where(m => m.MarqueId == voiture.MarqueId).ToList() : new List<Modele>();
            modeles.Add(new Modele { Id = -1, Nom = "-- Ajouter un nouveau modèle --" });
            ViewBag.Modeles = new SelectList(modeles, "Id", "Nom", voiture.ModeleId);
        }

        // GET: Voitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }
            return View(voiture);
        }

        public IActionResult ConfirmationAjout()
        {
            return View();
        }


        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodeVIN,Annee,MarqueId,ModeleId,Finition,DateAchat,PrixAchat,Reparations,CoutsReparations,DateDisponibilite,PrixVente,DateVente")] Voiture voiture, IFormFile ImageFile)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);

                //// Afficher les erreurs dans la console ou un log
                //foreach (var erreur in erreurs)
                //{
                //    Console.WriteLine(erreur);
                //}
                try
                {
                    // Gestion de l'image si une nouvelle est uploadée
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        //// Supprimer l'ancienne image si elle existe
                        //if (!string.IsNullOrEmpty(voiture.ImageUrl))
                        //{
                        //    var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", voiture.ImageUrl.TrimStart('/'));
                        //    if (System.IO.File.Exists(oldImagePath))
                        //    {
                        //        System.IO.File.Delete(oldImagePath);
                        //    }
                        //}

                        //// Sauvegarder la nouvelle image
                        var fileName = Path.GetFileName(ImageFile.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(fileStream);
                        }

                        // Mettre à jour l'URL de l'image dans le modèle Voiture
                        voiture.ImageUrl = "/images/" + fileName;
                    }

                    // Mise à jour de la voiture
                    _context.Update(voiture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoitureExists(voiture.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture != null)
            {
                var marque = voiture.Marque;
                var modele = voiture.Modele;
                
                _context.Voitures.Remove(voiture);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Voiture supprimée avec succès, ID: {Id}", voiture.Id);
                var redirectUrl = Url.Action("ConfirmationSuppression", new { id = voiture.Id });
                _logger.LogInformation("Redirection vers : {Url}", redirectUrl);

                return RedirectToAction("ConfirmationSuppression", new { id = id, marque, modele });
            }
            _logger.LogWarning("Aucune voiture trouvée avec l'ID: {Id}", id);
            return RedirectToAction("Index"); 
        }

        public IActionResult ConfirmationSuppression(int id, string marque, string modele)
        {
            ViewBag.Marque = marque;
            ViewBag.Modele = modele;

            _logger.LogInformation("Tentative d'accès à ConfirmationSuppression avec ID : {Id}", id);

            //var voiture = _context.Voitures.Find(id);
            //if (voiture == null)
            //{
            //    _logger.LogWarning("Aucune voiture trouvée avec l'ID : {Id}", id);
            //    return NotFound();
            //}

            return View();
        }


        //public IActionResult SuppressionOk(Voiture voiture)
        //{
        //    return View(voiture);
        //}


        private bool VoitureExists(int id)
        {
            return _context.Voitures.Any(e => e.Id == id);
        }
    }
}
