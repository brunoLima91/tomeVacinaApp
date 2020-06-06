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
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsuarioViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioViewModel.ToListAsync());
        }

        // GET: UsuarioViewModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioViewModel = await _context.UsuarioViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        // GET: UsuarioViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Documento,DataNascimento,Prioridade")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioViewModel.Id = Guid.NewGuid();
                _context.Add(usuarioViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioViewModel);
        }

        // GET: UsuarioViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioViewModel = await _context.UsuarioViewModel.FindAsync(id);
            if (usuarioViewModel == null)
            {
                return NotFound();
            }
            return View(usuarioViewModel);
        }

        // POST: UsuarioViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Documento,DataNascimento,Prioridade")] UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioViewModelExists(usuarioViewModel.Id))
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
            return View(usuarioViewModel);
        }

        // GET: UsuarioViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioViewModel = await _context.UsuarioViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        // POST: UsuarioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var usuarioViewModel = await _context.UsuarioViewModel.FindAsync(id);
            _context.UsuarioViewModel.Remove(usuarioViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioViewModelExists(Guid id)
        {
            return _context.UsuarioViewModel.Any(e => e.Id == id);
        }
    }
}
