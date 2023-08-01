using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly UygulamaDbContext _uygulamaDbContext;
        public KitapTuruController (UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList  = _uygulamaDbContext.KitapTurleri.ToList();
            return View(objKitapTuruList);
        }

        public IActionResult Ekle() {
             return View();
        }
        [HttpPost]
		public IActionResult Ekle(KitapTuru KitapTuru)
		{

			
			 if (ModelState.IsValid)
			  {
				  _uygulamaDbContext.KitapTurleri.Add(KitapTuru);
				  _uygulamaDbContext.SaveChanges();//ave changes yapılmazsa bilgiler veri tabanına eklenmez!!!!
				  return RedirectToAction("Index");
			  }


				  return View();


		}
		public IActionResult Guncelle(int? id)
		{
			if(id==null || id == 0)
			{
				return NotFound();
			}
			KitapTuru? kitapTuruVt=_uygulamaDbContext.KitapTurleri.Find(id);
			if (kitapTuruVt == null)
			{
				return NotFound();
			}

			return View(kitapTuruVt);
		}
		[HttpPost]
		public IActionResult Guncelle(KitapTuru KitapTuru)
		{


			if (ModelState.IsValid)
			{
				_uygulamaDbContext.KitapTurleri.Update(KitapTuru);
				_uygulamaDbContext.SaveChanges();//save changes yapılmazsa bilgiler veri tabanına eklenmez!!!!
				return RedirectToAction("Index");
			}


			return View();


		}
		//get action .cshtml dosyasını getirir.
		public IActionResult Sil(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);
			if (kitapTuruVt == null)
			{
				return NotFound();
			}

			return View(kitapTuruVt);
		}
		//post action.asıl yapılmasını istediğimiz işlemi yapar.
		[HttpPost,ActionName("Sil")]
		public IActionResult SilPOST(int? id)
		{


			if (ModelState.IsValid)
			{
				KitapTuru? KitapTuru =_uygulamaDbContext.KitapTurleri.Find(id);
				if(KitapTuru==null)
				{
					return NotFound();
				}
				_uygulamaDbContext.KitapTurleri.Remove(KitapTuru);
				_uygulamaDbContext.SaveChanges();
				return RedirectToAction("Index");
			}


			return View();


		}
	}
}
