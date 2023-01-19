﻿using Repositories;
using Repositories.IRepositories;
using Repositories.Repositories;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private UnitOfWork<CRUDDBEntities> unitOfWork = new UnitOfWork<CRUDDBEntities>();
        private GenericRepository<Employee> repository;
        private IEmployeeRepository employeeRepository;

               
        public EmployeesController()
        {
            //If you want to use Generic Repository with Unit of work
            repository = new GenericRepository<Employee>(unitOfWork);
            //If you want to use Specific Repository with Unit of work
            employeeRepository = new EmployeesRepository(unitOfWork);
        }

        // GET: api/Employees
        public IEnumerable<Employee> GetEmployees()
        {
            return repository.GetAll();
            //return db.Employees;
        }

        public IEnumerable<Employee> GetEmployeesByPosition(string position)
        {
            var res = employeeRepository.GetEmployeesByPosition("weq");
            return res.ToList();
        }
        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult GetEmployee(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employee);
        //}

        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEmployee(int id, Employee employee)
        //{
        //    if (id != employee.EmployeeID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult PostEmployee(Employee employee)
        //{
          
        //    db.Employees.Add(employee);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        //}

        //[ResponseType(typeof(Employee))]
        //public IHttpActionResult DeleteEmployee(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Employees.Remove(employee);
        //    db.SaveChanges();

        //    return Ok(employee);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return db.Employees.Count(e => e.EmployeeID == id) > 0;
        //}
    }
}