using OtoServisSatis.BL.Repositories;
using OtoServisSatis.DAL;
using OtoServisSatis.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OtoServisSatis.BL
{
    public class AracManager : Repository<Entities.Arac>
    {
        private DatabaseContext _context;

        public AracManager()
        {
            _context = new DatabaseContext();
        }

        public List<(string MarkaAdi, int AracSayisi)> GetAracMarkaGruplama()
        {
            return _context.Arac
                .GroupBy(a => a.MarkaId)
                .Select(group => new
                {
                    MarkaAdi = group.FirstOrDefault().marka.Adi, // Marka adı
                    AracSayisi = group.Count()                   // Araç sayısı
                })
                .ToList()
                .Select(g => (g.MarkaAdi, g.AracSayisi))
                .ToList();
        }
    }
}
