using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7
{
    public class workers_department
    {
        int id_w;
        int id_dep;

        public workers_department(int i, int i_d)
        {
            id_w = i;
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

        public override string ToString()
        {
            return "(Отдел =" + this.id_dep.ToString() + "; Сотрудник =" + this.id_w.ToString() + ")";
        }
    }
}