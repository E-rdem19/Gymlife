using System.ComponentModel.DataAnnotations;

namespace GymLife.API.Models
{
    public class Instructor
    {
        [Key]
        public int EgitmenID { get; set; }
        public string? AD { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Sifre { get; set; }
        public string? Telefon { get; set; }
        public string? Resim { get; set; }
        public int Yas { get; set; }

        // Şimdilik basit tutalım, tablo ilişkileri daha sonra
        public int? BransID { get; set; }
        public string? Aciklama { get; set; }
        public int? ProgramID { get; set; }
        


        public string? Rol { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Youtube { get; set; }
    }
}