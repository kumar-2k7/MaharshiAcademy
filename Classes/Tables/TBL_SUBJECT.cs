using System;

namespace Classes.Tables
{
    public class TBL_SUBJECT
    {
        public int SUBJECT_ID { get; set; }
        public string SUBCAT_ID { get; set; }
        public string SUBJECT_NAME { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime MODIFIED_ON { get; set; }
        public int MODIFIED_BY { get; set; }
        public string PURGEFLAG { get; set; }
    }
}
