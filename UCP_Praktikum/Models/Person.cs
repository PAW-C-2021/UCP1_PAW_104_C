using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_Praktikum.Models
{
    public partial class Person
    {
        public Person()
        {
            Borrows = new HashSet<Borrow>();
        }

        public int IdPerson { get; set; }
        public string NmPerson { get; set; }
        public string NoTelp { get; set; }
        public string Gender { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}
