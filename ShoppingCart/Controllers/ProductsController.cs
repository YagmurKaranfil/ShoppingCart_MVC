using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;
using ShoppingCart.Models;
using System.Runtime.ConstrainedExecution;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {

        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index(string categorySlug="" , int p=1)
        {
            int pageSize = 3;
            //ViewBag Controller üzerinden View'a veri taşımak için kullanılır. 
            ViewBag.PageNumber = p;
            //sayfa aralığı
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;


            if(categorySlug =="")
            {
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);
           
            //Çoktan aza sırala
           // OrderByDescending(p => p.Id): Koleksiyonun öğelerini Id özelliğine göre azalan sırada sıralar. p => p.Id ifadesi,
           //     nher bir koleksiyon öğesinin Id özelliğine erişimini sağlar.

           // Skip((p - 1) * pageSize): Belirli bir sayfa numarasına(p) ve sayfa boyutuna(pageSize) dayanarak, 
           //     atlanacak öğe sayısını belirler. Skip işlemi, belirtilen sayfa numarasına göre atlanacak öğelerin 
           //     sayısını hesaplar.Örneğin, ilk sayfa için atlanacak öğe sayısı 0 olacaktır, ikinci sayfa için atlanacak
           //     öğe sayısı pageSize olacaktır ve bu şekilde devam eder.

           //Take(pageSize): Belirli bir sayfa boyutunda(pageSize) öğeleri alır. Take işlemi, belirtilen sayfa 
           //     boyutuna göre öğelerin alınmasını sağlar.

           //ToListAsync(): Sorgu sonucunu bir List nesnesine dönüştürür ve asenkron bir şekilde döndürür.Bu, veritabanı 
           //     veya uzak bir veri kaynağı üzerinde çalışırken verileri almak için kullanışlıdır.


            return View(await _context.Products.OrderByDescending(p=>p.Id).Skip((p-1)*pageSize).Take(pageSize).ToListAsync());
        }

            //Belirli bir koşulu karşılayan bir dizinin ilk öğesini veya böyle bir öğe bulunamazsa varsayılan 
            //değeri zaman uyumsuz olarak döndürür.

            Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null)

                //Eylem adını, denetleyici adını ve yol değerlerini kullanarak belirtilen eyleme yeniden yönlendirir.
                return RedirectToAction("Index");


            var productsByCategory = _context.Products.Where(p => p.CategoryId == category.Id);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)productsByCategory.Count() / pageSize);

            return View(await productsByCategory.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());

        }
    }
}
