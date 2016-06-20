using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS.Models;
using CSS.ViewModels;

namespace CSS.Controllers
{
    public class VolumeController : Controller
    {
        private CSSEntities1 db = new CSSEntities1();

        /// get all banding of volume(volumeId)
        /// volumeId: id of Volume
        /// return: view RetroBanding(List banding)
        [ChildActionOnly]
        public ActionResult GetListBanding(int? volumeId)
        {
            if (volumeId == null)
            {
                ViewBag.errorMessage = "Cannot find bandings of this volume.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
            else
            {
                var bandings = db.Bandings.Where(b => b.VolumeId == volumeId);
                return PartialView("RetroBanding", bandings.ToArray<Banding>());
            }
        }

        /// call view AddBanding
        /// volumeId: id of Volume
        /// return view AddBanding
        public ActionResult CreateBanding(int? volumeId)
        {
            if (volumeId == null)
            {
                ViewBag.errorMessage = "Cannot find bandings of this volume.";
                return View("~/Views/Shared/Warning.cshtml");
            }
            else
            {
                //banding value from = last banding value to + 1
                Banding banding = new Banding();
                var lastBanding = db.Bandings.Where(b => b.VolumeId == volumeId).ToList().LastOrDefault();
                if (lastBanding != null)
                    banding.Min = lastBanding.Max + 1;
                banding.VolumeId = volumeId;
                return View("AddBanding", banding);
            }
        }

        /// Add new banding
        /// 
        /// reload list banding after adding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBanding()
        {
            Banding banding = new Banding();
            if (TryUpdateModel(banding))
            {
                var volume = db.Volumes.Find(banding.VolumeId);
                if (volume == null)
                {
                    ViewBag.errorMessage = "Cannot fine volume of banding. ";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }

                //save to database
                try
                {
                    volume.Bandings.Add(banding);
                    db.Entry(volume).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Cannot save banding. " + ex.Message;
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
                return GetListBanding(banding.VolumeId);
            }
            else
            {
                ViewBag.errorMessage = "Cannot receive input.";
                return View("~/Views/Shared/Warning.cshtml");
            }
        }

        /// call view EditBanding
        /// bandingId: id of Banding
        /// return view EditBanding
        public ActionResult EditBanding(int? bandingId)
        {
            var banding = db.Bandings.Find(bandingId);
            if (banding == null)
            {
                ViewBag.errorMessage = "Cannot find banding.";
                return View("~/Views/Shared/Warning.cshtml");
            }
            else
            {
                return View("EditBanding", banding);
            }
        }

        /// call function EditBanding
        /// banding: object Banding
        /// return view EditBanding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBanding()
        {
            Banding newBanding = new Banding();
            if (TryUpdateModel(newBanding))
            {
                var oldBanding = db.Bandings.Find(newBanding.BandingId);
                if (oldBanding == null || oldBanding.Volume == null)
                {
                    ViewBag.errorMessage = "Banding not found.";
                    return View("~/Views/Shared/Warning.cshtml");
                }
                if (newBanding.Max > oldBanding.Max)
                {
                    int d1 = oldBanding.Max - oldBanding.Min;
                    int d2 = newBanding.Max - newBanding.Min;
                    int d = d2 - d1;
                    var listbandings = oldBanding.Volume.Bandings.Where(b => b.Min > oldBanding.Max);
                    foreach (var banding in listbandings)
                    {
                        banding.Min += d;
                        banding.Max += d;
                        db.Entry(banding).State = System.Data.Entity.EntityState.Modified;
                    }
                    oldBanding.Max = newBanding.Max;
                    db.Entry(oldBanding).State = System.Data.Entity.EntityState.Modified;
                }
                else if (newBanding.Max < oldBanding.Max)
                {
                    int d1 = oldBanding.Max - oldBanding.Min;
                    int d2 = newBanding.Max - newBanding.Min;
                    int d = d1 - d2;
                    var listbandings = oldBanding.Volume.Bandings.Where(b => b.Min > oldBanding.Max);
                    foreach (var banding in listbandings)
                    {
                        banding.Min -= d;
                        banding.Max -= d;
                        db.Entry(banding).State = System.Data.Entity.EntityState.Modified;
                    }
                    oldBanding.Max = newBanding.Max;
                    db.Entry(oldBanding).State = System.Data.Entity.EntityState.Modified;
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Cannot edit banding. " + ex.Message;
                    return View("~/Views/Shared/Warning.cshtml");
                }
                return GetListBanding(newBanding.VolumeId);
            }
            else
            {
                ViewBag.errorMessage = "Cannot edit banding.";
                return View("~/Views/Shared/Warning.cshtml");
            }
        }

        /// call view DeleteBanding
        /// bandingId: id of Banding
        /// return view DeleteBanding
        public ActionResult DeleteBanding(int? bandingId)
        {
            var banding = db.Bandings.Find(bandingId);
            if (banding == null)
            {
                ViewBag.errorMessage = "Cannot find banding.";
                return View("~/Views/Shared/Warning.cshtml");
            }
            else
            {
                return View("DeleteBanding", banding);
            }
        }

        /// call action DeleteBanding
        /// banding: object Banding
        /// reload list banding after delete
        [HttpPost, ActionName("DeleteBanding")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteBanding(int? bandingId)
        {
            var bandingDelete = db.Bandings.Find(bandingId);
            if (bandingDelete != null)
            {
                if (bandingDelete.Volume == null)
                {
                    ViewBag.errorMessage = "Cannot find the volume of this banding.";
                    return View("~/Views/Shared/Warning.cshtml");
                }
                var listbandings = bandingDelete.Volume.Bandings.Where(b => b.Min > bandingDelete.Max);
                int d = bandingDelete.Max - bandingDelete.Min;
                foreach (var banding in listbandings)
                {
                    banding.Min = banding.Min - d - 1;
                    banding.Max = banding.Max - d - 1;
                    db.Entry(banding).State = System.Data.Entity.EntityState.Modified;
                }
                //save volumeId before delete banding
                int volumeId = bandingDelete.Volume.VolumeId;

                //save to database
                try
                {
                    db.Bandings.Remove(bandingDelete);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Cannot delete banding. " + ex.Message;
                    return View("~/Views/Shared/Warning.cshtml");
                }

                return GetListBanding(volumeId);
            }
            else
            {
                ViewBag.errorMessage = "Cannot find banding.";
                return View("~/Views/Shared/Warning.cshtml");
            }
        }

        /// Function save volume banding
        /// volumeModel: volume info
        /// return an alert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveVolumeBanding()
        {
            VolumeBandingModel volumeModel = new VolumeBandingModel();
            if (TryUpdateModel(volumeModel))
            {
                var volume = db.Volumes.Find(volumeModel.VolumeId);
                if (volume == null)
                {
                    ViewBag.errorMessage = "Volume not found.";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
                volume.TriggerCredit = volumeModel.TriggerCredit;
                volume.PaymentTo = volumeModel.PayableTo;
                try
                {
                    db.Entry(volume).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Cannot save volume banding. " + ex.Message;
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
                return PartialView("~/Views/Shared/Alert.cshtml");
            }
            else
            {
                ViewBag.errorMessage = "Cannot receive input values.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
        }
    }
}
