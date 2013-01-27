using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SQLiteCon
{
    public class Student
    {
        private String _id;
        private String _name;
        private DateTime _birthday;
        private double _height;
        private int _weight;

        [DisplayName("學號")]
        public String Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [DisplayName("姓名")]
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        [DisplayName("生日")]
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }

        [DisplayName("身高")]
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        [DisplayName("體重")]
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        public int SID { get; set; }
    }
}
