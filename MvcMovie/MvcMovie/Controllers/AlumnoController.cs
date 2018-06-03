﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
	public class AlumnoController : Controller
	{
		private readonly MvcMovieContext _context;

		public AlumnoController(MvcMovieContext context)
		{
			_context = context;
		}

		// GET: Alumno
		public async Task<IActionResult> Index()
		{
			return View(await _context.Alumno.ToListAsync());
		}

		// GET: Alumno/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var alumno = await _context.Alumno
				.SingleOrDefaultAsync(m => m.ID == id);
			if (alumno == null)
			{
				return NotFound();
			}

			return View(alumno);
		}

		// GET: Alumno/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Alumno/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,firstName,lastName,birthDate")] Alumno alumno)
		{
			if (ModelState.IsValid)
			{
				_context.Add(alumno);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(alumno);
		}

		// GET: Alumno/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var alumno = await _context.Alumno.SingleOrDefaultAsync(m => m.ID == id);
			if (alumno == null)
			{
				return NotFound();
			}
			return View(alumno);
		}

		// POST: Alumno/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,firstName,lastName,birthDate")] Alumno alumno)
		{
			if (id != alumno.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(alumno);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AlumnoExists(alumno.ID))
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
			return View(alumno);
		}

		// GET: Alumno/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var alumno = await _context.Alumno
				.SingleOrDefaultAsync(m => m.ID == id);
			if (alumno == null)
			{
				return NotFound();
			}

			return View(alumno);
		}

		// POST: Alumno/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var alumno = await _context.Alumno.SingleOrDefaultAsync(m => m.ID == id);
			_context.Alumno.Remove(alumno);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AlumnoExists(int id)
		{
			return _context.Alumno.Any(e => e.ID == id);
		}
	}
}
