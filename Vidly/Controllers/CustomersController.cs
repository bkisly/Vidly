using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vidly.Models;
using Vidly.Models.DataTransferObjects;
using Vidly.ViewModels;
using Vidly.Services;
using Vidly.Helpers;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersDataService _service;

        public CustomersController(ICustomersDataService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(Constants.StoreManagerRoleName))
                return View("CustomersList");

            return View("CustomersReadOnlyList");
        }

        public async Task<IActionResult> Details(int id = 1)
        {
            var customer = await _service.GetItemByIdAsync(id);
            return customer != null ? View(customer) : NotFound();
        }

        [Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> New()
        {
            var membershipTypes = await _service.GetMembershipTypesAsync();
            return View("CustomerForm", new CustomerFormViewModel { MembershipTypes = membershipTypes });
        }

        [Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            Customer? customer = await _service.GetItemByIdAsync(id);
            if(customer == null) return NotFound();

            CustomerFormViewModel viewModel = new() 
            { 
                Customer = CustomerDto.ConvertToDto(customer), 
                MembershipTypes = await _service.GetMembershipTypesAsync() 
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> Save(CustomerDto customer)
        {      
            if(!ModelState.IsValid)
            {
                CustomerFormViewModel viewModel = new() { Customer = customer, MembershipTypes = await _service.GetMembershipTypesAsync() };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0) await _service.AddItemAsync(customer.ConvertToModel());
            else await _service.UpdateItemAsync(customer.Id, customer.ConvertToModel());
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete, Authorize(Roles = Constants.StoreManagerRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
