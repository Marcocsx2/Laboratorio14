using API.Repository;
using DOMINIO;
using MVCAJAX.Models;
using SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
        StudentService Service;

        public StudentController()
        {
            Service = new StudentService();
        }

        [System.Web.Http.HttpGet]
        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            List<Student> studentsList = Service.Get();
            List<StudentModel> students = new List<StudentModel>();

            foreach (var item in studentsList)
            {
                students.Add(mapObj.Translate(item));
            }

            Console.WriteLine("students studentsstudents");
            Console.WriteLine(students);

            return Json(students);
        }
        [System.Web.Http.HttpGet]
        public JsonResult<StudentModel> GetStudents(int id)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            Student studentDetail = Service.GetById(id);
            StudentModel student = mapObj.Translate(studentDetail);
            return Json(student);
        }

        [System.Web.Http.HttpPost]
        public bool InsertStudent(StudentModel student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
                Student studentObj = mapObj.Translate(student);
                Service.Insert(studentObj);
                status = true;

            }
            return status;
        }

        [System.Web.Http.HttpPut]
        public bool UpdateStudent(StudentModel student)
        {
            bool status = false;
            EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
            Student studentObj = mapObj.Translate(student);
            Service.Update(studentObj, studentObj.studentID);
            status = true;
            return status;
        }

        [System.Web.Mvc.HttpDelete]
        public bool DeleteStudent(int id)
        {
            bool status = false;
            Service.Delete(id);
            status = true;
            return status;
        }
    }
}
