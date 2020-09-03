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
        private readonly ConserveContext _context;
        private static Member oriMember;

        public MembersController(ConserveContext context)
        {
            _context = context;
        }

        // GET: Member/Metric
        public async Task<IActionResult> Metric()
        {
            //var members = from m in _context.Member
            //              select m;

            //var final = await members.ToListAsync();
            //foreach(Member target in final) //checking mvc strategy
            //{
            //    Console.Write(target.Name + " : ");
            //    Console.WriteLine(target.StartDate);
            //}

            var validHireDates = from d in _context.Members
                             where d.StartDate.Date >= DateTime.Today.AddDays(-7)
                             && d.StartDate.Date <= DateTime.Today
                             select d; //determines today to minus 7 days new hires inclusive

            var final = await validHireDates.ToListAsync();

            var terminationDates = from t in _context.Members
                                   where t.EndDate.Date >= DateTime.Today.AddYears(-1)
                                   && t.EndDate.Date <= DateTime.Today
                                   && t.EmploymentStatus == "Terminated"
                                   select t; //determines today to a year terminations

            var final2 = await terminationDates.ToListAsync();

            Dictionary<string, int> counter = new Dictionary<string, int>(); //determines department/manager count
            foreach(var deptMan in _context.Members)
            {
                //Console.WriteLine(deptMan.Department + "/" + deptMan.Manager);
                if(!counter.ContainsKey(deptMan.Department + "/" + deptMan.Manager))
                {
                    counter.Add(deptMan.Department + "/" + deptMan.Manager, 1);
                }
                else
                {
                    var count = counter.GetValueOrDefault(deptMan.Department + "/" + deptMan.Manager);
                    count++;
                    counter[deptMan.Department + "/" + deptMan.Manager] = count;
                }
            }

            ViewData["Manager"] = counter;

            //Console.WriteLine(DateTime.Today.AddDays(-7) + " : " + DateTime.Today); //Determines a week range for hire
            //Console.WriteLine(final.Count);
            int newHireC = final.Count;
            //foreach (Member target in final2)
            //{
            //    newHireC++;
            //    Console.Write(target.Name + " : ");
            //    Console.WriteLine(target.StartDate);
            //}

            int terminatedC = final2.Count;
            if (newHireC > 1)
            {
                ViewData["NewHire"] = newHireC + " new hires from " + DateTime.Today.AddDays(-7) + " to " + DateTime.Today;
            }
            else
            {
                ViewData["NewHire"] = newHireC + " new hire from " + DateTime.Today.AddDays(-7) + " to " + DateTime.Today;
            }

            if (terminatedC > 1)
            {
                ViewData["Terminated"] = terminatedC + " terminations from " + DateTime.Today.AddYears(-1) + " to " + DateTime.Today;
            }
            else
            {
                ViewData["Terminated"] = terminatedC + " termination from " + DateTime.Today.AddYears(-1) + " to " + DateTime.Today;
            }

            List<String> look = Startup.aLog; //log for activity since startup
            return View(Startup.aLog);
        }

        // GET: Member
        public async Task<IActionResult> Index(string employmentStatus, string searchString, string sortOrder)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asce" : "";

            // Use LINQ to get list of employment status.
            IQueryable<string> statusQuery = from m in _context.Members
                                             orderby m.EmploymentStatus
                                            select m.EmploymentStatus;

            var members = from m in _context.Members
                         select m;

            switch (sortOrder)
            {
                case "name_asce":
                    members = members.OrderBy(m => m.Name);
                    break;
                default:
                    break;
            }

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

            var member = await _context.Members
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
            var departmentHolder = from depart in _context.Departments
                                   select depart;

            Dictionary<string, List<string>> departmentPairs = new Dictionary<string, List<string>>(); //creates a dictionary for dropdowns
            foreach(Department target in departmentHolder)
            {
                Console.WriteLine(target.departmentName + target.position);
                if(departmentPairs.ContainsKey(target.departmentName))
                {
                    departmentPairs[target.departmentName].Add(target.position);
                }
                else
                {
                    departmentPairs.Add(target.departmentName, new List<string> { target.position });
                }
            }

            //Console.WriteLine(departmentPairs.Count);
            ViewData["Jobs"] = departmentPairs;
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
                //member.EmploymentStatus = "Employed";
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

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            var departmentHolder = from depart in _context.Departments
                                   select depart;

            Dictionary<string, List<string>> departmentPairs = new Dictionary<string, List<string>>(); //creates a dictionary for dropdowns
            foreach (Department target in departmentHolder)
            {
                Console.WriteLine(target.departmentName + target.position);
                if (departmentPairs.ContainsKey(target.departmentName))
                {
                    departmentPairs[target.departmentName].Add(target.position);
                }
                else
                {
                    departmentPairs.Add(target.departmentName, new List<string> { target.position });
                }
            }

            //Console.WriteLine(departmentPairs.Count);
            ViewData["Jobs"] = departmentPairs;

            oriMember = member; //Saving the original record of member for comparison
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

                    if(oriMember.Manager != member.Manager) //Checking for changes for activity log
                    {
                        //Console.WriteLine(oriMember.Name + " manager: " + oriMember.Manager +
                        //    " has changed to " + member.Manager);
                        Startup.aLog.Add(DateTime.Now + ": " + oriMember.Name + " manager: " + oriMember.Manager + " has changed to " + member.Manager);
                    }

                    if(oriMember.Position != member.Position)
                    {
                        //Console.WriteLine(oriMember.Name + " position: " + oriMember.Position +
                        //    " has changed to " + member.Position);
                        Startup.aLog.Add(DateTime.Now + ": " + oriMember.Name + " position: " + oriMember.Position + " has changed to " + member.Position);
                    }
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

            var member = await _context.Members
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
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
