using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarlo
{
   public class ObjectComboBox
    {
        public int id;
        public String name;

        public ObjectComboBox(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
