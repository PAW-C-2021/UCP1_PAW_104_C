using System;
using System.Collections.Generic;

#nullable disable

namespace UCP_Praktikum.Models
{
    public partial class Borrow
    {
        public int IdBorrow { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int IdBuku { get; set; }
        public int IdPerson { get; set; }

        public virtual Buku IdBukuNavigation { get; set; }
        public virtual Person IdPersonNavigation { get; set; }
    }
}
