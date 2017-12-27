using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
{
    public class Worker
    {
        int id_w;
        String surname;
        int id_dep;

        public Worker(int i, string s, int i_d)
        {
            id_w = i;
            surname = s;
            id_dep = i_d;
        }

        public int ID_W
        {
            get
            {
                return id_w;
            }

            set
            {
                id_w = value;
            }
        }

        public int ID_Dep
        {
            get
            {
                return id_dep;
            }

            set
            {
                id_dep = value;
            }
        }

        public String Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public override string ToString()
        {
            return "(id=" + this.id_w.ToString() + "; Фамилия =" + this.surname + "; id отдела =" + this.id_dep + ")";
        }
    }
}