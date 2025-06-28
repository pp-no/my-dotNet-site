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

        // �ꗗ�\��
        public IActionResult Index()
        {
            ViewData["Title"] = "���i�ꗗ�y�[�W";
            ViewData["Description"] = "���i�̈ꗗ���Љ�Ă��܂�";
            ViewData["OGTitle"] = "���i�ꗗ | �T�C�g��";
            var products = _context.Products.ToList();
            return View(products);
        }

        // �o�^��ʕ\��
        public IActionResult Create()
        {
            return View();
        }

        // �o�^����
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);  // ���̓G���[���͍ĕ\��
        }

        // �ҏW��ʕ\��
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // �ҏW����
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

        // �폜����
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
