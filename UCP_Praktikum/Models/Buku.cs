using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_Praktikum.Models
{
    public partial class Buku
    {
        public Buku()
        {
            Borrows = new HashSet<Borrow>();
        }

        public int IdBuku { get; set; }
        public string JudulBuku { get; set; }
        public string Penulis { get; set; }
        public string Penerbit { get; set; }
        public string ThTerbit { get; set; }
        public int? Halaman { get; set; }
        public string Isbn { get; set; }
        public string Kategori { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}
