using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.BusinessEntities
{
    public class dtoUser
    {
        private string _AUTO_ID;
        private string _USER_ID;
        private string _USER_PWD;
        private int _USER_TYPE;

        public string AUTO_ID { get { return _AUTO_ID; } set { _AUTO_ID = value; } }
        public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
        public string USER_PWD { get { return _USER_PWD; } set { _USER_PWD = value; } }
        public int USER_TYPE { get { return _USER_TYPE; } set { _USER_TYPE = value; } }
    }
}
