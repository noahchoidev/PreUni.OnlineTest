using PreUni.College.DAL.CollegeDbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreUni.College.DAL.Model
{
    public class StudentModel
    {
        public int RollId { get; set; }

        public int StudentId { get; set; }

        public String Name { get; set; }

        public int AttendType { get; set; }

        public String MakeupType { get; set; }

        public String MakeupRefClassId { get; set; }

        public String MakeupDetail { get; set; }

        public StudentMedicalCondition MediCondition { get; set; }

        public string Comment { get; set; }
    }

    public class StudentListModel
    {
        public int ClassId { get; set; }

        public int ClassDayNo { get; set; }

        public DateTime ClassDate { get; set; }

        public List<StudentModel> StdLst { get; set; }
    }
}