﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prepaid_Mobile_Topup_Core_Web_App.BusinessModel;
using Prepaid_Mobile_Topup_Core_Web_App.Models;

namespace Prepaid_Mobile_Topup_Core_Web_App.Pages.PrepaidCustomers
{
    public class DeleteModel : PageModel
    {
        private readonly Prepaid_Mobile_Topup_Core_Web_App.Models.Prepaid_Mobile_Topup_DataContext _context;

        public DeleteModel(Prepaid_Mobile_Topup_Core_Web_App.Models.Prepaid_Mobile_Topup_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PrepaidCustomer PrepaidCustomer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrepaidCustomer = await _context.PrepaidCustomer.FirstOrDefaultAsync(m => m.Id == id);

            if (PrepaidCustomer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrepaidCustomer = await _context.PrepaidCustomer.FindAsync(id);

            if (PrepaidCustomer != null)
            {
                _context.PrepaidCustomer.Remove(PrepaidCustomer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
