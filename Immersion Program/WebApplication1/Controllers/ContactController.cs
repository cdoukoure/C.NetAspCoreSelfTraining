using WebAspCoreDapper.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using WebAspCoreDapper.Interfaces;

namespace WebAspCoreDapper.Controllers
{
    public class ContactController : Controller
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=Integration_CharlesDoukour;Integrated Security=True";

        private IContactService _serviceContact;

        public ContactController(IContactService service)
        {
            _serviceContact = service;
        }

        // GET: Clear all entries for Contact entity
        public ActionResult ClearContact()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var lineNumber =
                    connection.Execute("CLEAR_TABLE_CONTACT", new { }, commandType: CommandType.StoredProcedure);
            }
            return RedirectToAction("Index");
        }

        // GET: Contact  
        public ActionResult Index()
        {
            ViewData["Message"] = "Your service1 random value is: ";

            List<Contact> ContactList = new List<Contact>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ContactList = connection.Query<Contact>("select Id, LastName, FirstName, DateOfBirth, PhoneNumber from Contact").AsList();
            }
            return View(ContactList);
        }

        public IActionResult MultiCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultiCreate(IndexFormClass model)
        {
            var rnd = new Random();
            Contact[] contactList = new Contact[model.LineNumber];

            for (var i = 0; i < model.LineNumber; i++)
            {
                contactList[i] = new Contact()
                {
                    FirstName = _serviceContact.GetRandomString(8, 16, 2),
                    LastName = _serviceContact.GetRandomString(6, 10, 2),
                    DateOfBirth = _serviceContact.GetRandomDateTime(),
                    PhoneNumber = rnd.Next(11111111, 99999999)
                };
                // contactList.Append(contact);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"insert into Contact(FirstName, LastName, DateOfBirth, PhoneNumber) values (@FirstName, @LastName, @DateOfBirth, @PhoneNumber)";
                connection.Execute(sql, contactList);
            }

            return RedirectToAction("Index");
            // return View();
        }
        
        // GET: Contact/Details/5  
        public ActionResult Details(int id)
        {
            Contact _contact = new Contact();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                _contact = connection.Query<Contact>("Select * From Contact " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(_contact);
        }

        // GET: Contact/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create  
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                // TODO: Add insert logic here  
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"insert into Contact(FirstName, LastName, DateOfBirth, PhoneNumber) values (@FirstName, @LastName, @DateOfBirth, @PhoneNumber)";
                    connection.Execute(sql, contact);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Contact/Edit/5  
        public ActionResult Edit(int id)
        {
            Contact contact = new Contact();
            int ID = id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                contact = connection.Query<Contact>("Select * From Contact WHERE Id = @Id", new { Id = id }).SingleOrDefault();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5  
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                // TODO: Add update logic here
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // string sql = "update Contact set ContactName='" + collection.FirstName + "',City='" + _Contact.City + "',PhoneNumber='" + _Contact.PhoneNumber + "' where Contactid=" + _Contact.ContactID;

                    string sql =@"update Contact set FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, PhoneNumber = @PhoneNumber
where Id = @Id";
                    int rowsAffected = connection.Execute(sql, contact);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5  
        public ActionResult Delete(int id)
        {
            Contact _Contact = new Contact();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                _Contact = connection.Query<Contact>("Select * From Contact " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(_Contact);
        }

        // POST: Contact/Delete/5  
        [HttpPost]
        public ActionResult Delete(Contact contact)
        {
            try
            {
                // TODO: Add delete logic here  
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // string sqlQuery = "Delete From Contact WHERE Id = @Id";

                    // int rowsAffected = connection.Execute(sqlQuery, contact);

                    DynamicParameters p = new DynamicParameters();

                    p.Add("@ContactID", contact.Id);

                    var lineNumber =
                        connection.Execute("DELETE_CONTACT", p, commandType: CommandType.StoredProcedure);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}