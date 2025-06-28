using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Data;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // 一覧表示
        public IActionResult Index()
        {
            ViewData["Title"] = "商品一覧ページ";
            ViewData["Description"] = "商品の一覧を紹介しています";
            ViewData["OGTitle"] = "商品一覧 | サイト名";
            var products = _context.Products.ToList();
            return View(products);
        }

        // 登録画面表示
        public IActionResult Create()
        {
            return View();
        }

        // 登録処理
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);  // 入力エラー時は再表示
        }

        // 編集画面表示
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // 編集処理
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // 削除処理
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
