using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TomeVacina.App.Data;
using TomeVacina.App.ViewModels;

namespace TomeVacina.App.Controllers
{
    public class PostoAtendimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostoAtendimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostoAtendimentoViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostoAtendimentoViewModel.ToListAsync());
        }

        // GET: PostoAtendimentoViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoAtendimentoViewModel = await _context.PostoAtendimentoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postoAtendimentoViewModel == null)
            {
                return NotFound();
            }

            return View(postoAtendimentoViewModel);
        }

        // GET: PostoAtendimentoViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostoAtendimentoViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,QtdVacina,TipoPostoAtendimento")] PostoAtendimentoViewModel postoAtendimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                postoAtendimentoViewModel.Id = Guid.NewGuid();
                _context.Add(postoAtendimentoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postoAtendimentoViewModel);
        }

        // GET: PostoAtendimentoViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoAtendimentoViewModel = await _context.PostoAtendimentoViewModel.FindAsync(id);
            if (postoAtendimentoViewModel == null)
            {
                return NotFound();
            }
            return View(postoAtendimentoViewModel);
        }

        // POST: PostoAtendimentoViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,QtdVacina,TipoPostoAtendimento")] PostoAtendimentoViewModel postoAtendimentoViewModel)
        {
            if (id != postoAtendimentoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postoAtendimentoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoAtendimentoViewModelExists(postoAtendimentoViewModel.Id))
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
            return View(postoAtendimentoViewModel);
        }

        // GET: PostoAtendimentoViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postoAtendimentoViewModel = await _context.PostoAtendimentoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postoAtendimentoViewModel == null)
            {
                return NotFound();
            }

            return View(postoAtendimentoViewModel);
        }

        // POST: PostoAtendimentoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postoAtendimentoViewModel = await _context.PostoAtendimentoViewModel.FindAsync(id);
            _context.PostoAtendimentoViewModel.Remove(postoAtendimentoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostoAtendimentoViewModelExists(Guid id)
        {
            return _context.PostoAtendimentoViewModel.Any(e => e.Id == id);
        }
    }
}
