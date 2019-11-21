using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class StudentManagement
    {
        public PM14034[] GetAllStudent()
        {
            var db = new TESToopCSEntities();
            var student = db.PM14034.ToArray();

            return student;
        }
        public PM14034 GetStudent(int id)
        {
            var db = new TESToopCSEntities();
            var student = db.PM14034.Find(id);

            return student;
        }
        public void CreateStudent(string code, string name, bool gender, string hometown)
        {
            var NewStudent = new PM14034();
            NewStudent.code = code;
            NewStudent.name = name;
            NewStudent.HomeTown = hometown;
            NewStudent.gender = gender;

            var db = new TESToopCSEntities();
            db.PM14034.Add(NewStudent);
            db.SaveChanges();

        }
        public void UpdateStudent(int id,string code, string name, bool gender, string hometown)
        {
            var db = new TESToopCSEntities();
            var OldStudent = db.PM14034.Find(id);
            OldStudent.name = name;
            OldStudent.code = code;
            OldStudent.gender = gender;
            OldStudent.HomeTown = hometown;

            db.Entry(OldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var db = new TESToopCSEntities();
            var DeleteStudent = db.PM14034.Find(id);
            db.PM14034.Remove(DeleteStudent);
            db.SaveChanges();
        }
    }
}
