using System;

namespace Classes.Tables
{
    public class TBL_SUB_CATEGORY
    {
        public int SUBCAT_ID { get; set; }
        public int MAIN_COURSE_ID { get; set; }
        public string SUBCAT_NAME { get; set; }
        public string SUBCAT_DESC { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime MODIFIED_ON { get; set; }
        public int MODIFIED_BY { get; set; }
        public string PURGEFLAG { get; set; }
    }
}
