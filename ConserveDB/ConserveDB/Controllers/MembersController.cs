using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConserveDB.Data;
using ConserveDB.Models;

namespace ConserveDB.Controllers
{
    public class MembersController : Controller
    {
        private readonly MemberContext _context;

        public MembersController(MemberContext context)
        {
            _context = context;
        }

        // GET: Members
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Member.ToListAsync());
        //}

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var members = from m in _context.Member
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        members = members.Where(s => s.Name.Contains(searchString));
        //    }

        //    return View(await members.ToListAsync());
        //}

        // GET: Movies
        public async Task<IActionResult> Index(string employmentStatus, string searchString)
        {
            // Use LINQ to get list of employment status.
            IQueryable<string> statusQuery = from m in _context.Member
                                             orderby m.EmploymentStatus
                                            select m.EmploymentStatus;

            var members = from m in _context.Member
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                members = members.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(employmentStatus))
            {
                members = members.Where(x => x.EmploymentStatus == employmentStatus);
            }

            var memberStatusVM = new MemberEmploymentViewModel
            {
                EmploymentStatus = new SelectList(await statusQuery.Distinct().ToListAsync()),
                Members = await members.ToListAsync()
            };

            return View(memberStatusVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,EmailAddress,PreferredContactPhoneNumber,Position,Department,StartDate,EndDate,EmploymentStatus,Shift,Manager,TeamMemberPhoto,FavoriteColor")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,EmailAddress,PreferredContactPhoneNumber,Position,Department,StartDate,EndDate,EmploymentStatus,Shift,Manager,TeamMemberPhoto,FavoriteColor")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.Id == id);
        }
    }
}
