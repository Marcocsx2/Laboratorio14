using DOMINIO;
using INFRAESTRUCTURA;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE
{
    public class StudentService
    {
        public List<Student> Get()
        {
            List<Student> students = null;
            using (var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }

        public Student GetById(int ID)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(ID);
            }
            return student;
        }

        public void Insert(Student student)
        {

            try
            {
                using (var context = new SchoolContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }
        public void Update(Student student, int ID)
        {
            using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(ID);
                studentNew.studentName = student.studentName;
                studentNew.studentAddress = student.studentAddress;

                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.Find(ID);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
