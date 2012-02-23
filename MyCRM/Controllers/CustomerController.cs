using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCRM.Model;
using MyCRM.Ninject;
using MyCRM.Repositories;

namespace MyCRM.Controllers
{
    public class CustomerController : Controller
    {
        public IPagedSortableRepository<Customer,int> CustomerRepository { get; set; }

        public ActionResult Index()
        {
            return View(CustomerRepository.FindAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            CustomerRepository.Save(customer);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(CustomerRepository.Get(id));
        }
        public ActionResult Delete(int id)
        {
            return View(CustomerRepository.Get(id));
        }
        [HttpPost]
        public ActionResult Delete(int id,Customer customer)
        {
            CustomerRepository.Delete(CustomerRepository.Get(id));
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(CustomerRepository.Get(id));
        }
        [HttpPost]
        [UnitOfWork]
        public ActionResult Edit(int id, Customer customer)
        {

            customer.Id = id;
            CustomerRepository.Update(customer);
            return RedirectToAction("Index");
        }

    }
}
