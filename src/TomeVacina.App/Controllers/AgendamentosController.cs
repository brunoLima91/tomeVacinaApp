using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TomeVacina.App.Data;
using TomeVacina.App.ViewModels;
using TomeVacina.Business.Interfaces;
using TomeVacina.Business.Models;

namespace TomeVacina.App.Controllers
{
    [Authorize]
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IMapper _mapper;

        public AgendamentoController(IAgendamentoRepository agendamentoRepository, IAgendamentoService agendamentoService,
            IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _agendamentoService = agendamentoService;
            _mapper = mapper;
        }

        // GET: AgendamentoViewModels
        public async Task<IActionResult> Index()
        {            
            return View(_mapper.Map<IEnumerable<AgendamentoViewModel>>(await _agendamentoRepository.ObterTodos()));
        }

        // GET: AgendamentoViewModels/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(await _agendamentoRepository.ObterPorId(id));
            if (agendamentoViewModel == null)
            {
                return NotFound();
            }

            return View(agendamentoViewModel);
        }

        // GET: AgendamentoViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgendamentoViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Realizado")] AgendamentoViewModel agendamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var agendamento = _mapper.Map<Agendamento>(agendamentoViewModel);
                await _agendamentoService.Adicionar(agendamento);

                return RedirectToAction(nameof(Index));
            }
            return View(agendamentoViewModel);
        }

        // GET: AgendamentoViewModels/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(await _agendamentoRepository.ObterPorId(id));
            if (agendamentoViewModel == null)
            {
                return NotFound();
            }
            return View(agendamentoViewModel);
        }

        // POST: AgendamentoViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Realizado")] AgendamentoViewModel agendamentoViewModel)
        {
            if (id != agendamentoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var agendamento = _mapper.Map<Agendamento>(agendamentoViewModel);

                    await _agendamentoService.Atualizar(agendamento);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AgendamentoViewModelExists(agendamentoViewModel.Id))
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
            return View(agendamentoViewModel);
        }

        // GET: AgendamentoViewModels/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(await _agendamentoRepository.ObterPorId(id));
            if (agendamentoViewModel == null)
            {
                return NotFound();
            }

            await _agendamentoService.Remover(id);

            return View(agendamentoViewModel);
        }

        // POST: AgendamentoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var agendamentoViewModel = _mapper.Map<AgendamentoViewModel>(await _agendamentoRepository.ObterPorId(id));
            if (agendamentoViewModel == null)
            {
                return NotFound();
            }

            await _agendamentoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AgendamentoViewModelExists(Guid id)
        {
            var lAgenda =  _mapper.Map<AgendamentoViewModel>(await _agendamentoRepository.ObterPorId(id));
            return lAgenda != null;

            
        }
    }
}
