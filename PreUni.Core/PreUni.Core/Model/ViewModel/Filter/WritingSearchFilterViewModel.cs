using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreUni.Core.Model.ViewModel
{
    public class WritingSearchFilterViewModel
    {
        public int TestTypeID { get; set; }

        public int Year { get; set; }

        public string Term { get; set; }

        public int? TestNo { get; set; }

        public string BranchCode { get; set; }

        public int? ClassID { get; set; }

        public int? IsFinish { get; set; }

        public int? IsMarked { get; set; }

        public string Email { get; set; }
    }
}
