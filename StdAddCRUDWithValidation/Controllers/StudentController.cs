using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StdAddCRUDWithValidation.Models;

namespace StdAddCRUDWithValidation.Controllers
{
    public class StudentController : Controller
    {
        // Hardcoded data for demo purposes
        private static List<Student> students = new List<Student>
    {
        new Student { Id = 1, Name = "John Doe", Age = 20, Address = new Address { Id = 1, Street = "123 Main St", City = "New York", Country = "USA" } },
        new Student { Id = 2, Name = "Jane Smith", Age = 22, Address = new Address { Id = 2, Street = "456 Oak St", City = "Los Angeles", Country = "USA" } }
    };

        // Index: Display list of students
        public ActionResult Index()
        {
            return View(students);
        }

        // Details: Show details of a specific student
        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // Create: Show form to create a new student
        public ActionResult Create()
        {
            return View();
        }

        // Create: Handle form submission
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Max(s => s.Id) + 1;
                student.Address.Id = students.Max(s => s.Address.Id) + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Edit: Show form to edit an existing student
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // Edit: Handle form submission for updates
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
                if (existingStudent != null)
                {
                    existingStudent.Name = student.Name;
                    existingStudent.Age = student.Age;
                    existingStudent.Address = student.Address;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Delete: Show confirmation page to delete a student
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // Delete: Handle deletion
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }

}