using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.Core.Model
{
    /// <summary>
    /// This model does not go through optimal processing.
    /// So, data from all the different tables is put together in a dirty way.
    /// No DB normalization is due to the poor database design.
    /// Think of why this table is not good. 
    /// Remote server has to process and response this big data whenver the client makes a request.
    /// </summary>
    public class OnlineWritingModel
    {
        public int ID { get; set; }

        //
        public int StudentID { get; set; }
        //
        public string StudentName { get; set; }
        //
        public int TestID { get; set; }

        public int TestTypeID { get; set; }
        //
        public string TestName { get; set; }
        //
        public int? TestNo { get; set; }

        public int SubjectID { get; set; }
        //
        public string SubjectName { get; set; }
        //
        public int? ClassID { get; set; }
        //
        public int ClassNo { get; set; }

        public string ClassDay { get; set; }
        //
        public int Year { get; set; }
        //
        public string Term { get; set; }
        //
        public string BranchCode { get; set; }
        //
        public string BranchName { get; set; }

        public string WritingText { get; set; }

        public string Mark { get; set; }

        public string OriginalMark { get; set; }

        public string Comment { get; set; }
        //
        public int? IsFinish { get; set; }
        //
        public int? Score { get; set; }
        //
        public string Marker { get; set; }
    }
}
