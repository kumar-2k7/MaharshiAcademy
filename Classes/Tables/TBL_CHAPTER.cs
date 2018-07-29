using System;

namespace Classes.Tables
{
    public class TBL_CHAPTER
    {
        public int CHAPTER_ID { get; set; }
        public string SUBJECT_ID { get; set; }
        public string CHAPTER_NAME { get; set; }
        public int CHAPTER_ORDERING { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime MODIFIED_ON { get; set; }
        public int MODIFIED_BY { get; set; }
        public string PURGEFLAG { get; set; }
    }
}
