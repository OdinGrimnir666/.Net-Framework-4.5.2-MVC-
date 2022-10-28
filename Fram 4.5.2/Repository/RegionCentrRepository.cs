using Fram_4._5._2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fram_4._5._2.Repository
{
    public class RegionCentrRepository : IRegionCentrRepository
    {
        ApplicationDbContext _context;

        public RegionCentrRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<RegionalCenter>> GetRegionCentrAsunc()
        {
            return await _context.RegionalCenter.ToListAsync();
        }

        public async Task InitialRegion()
        {
            if(await _context.RegionalCenter.CountAsync() == 0)
            {
                string[] RangeCent = new string[] { "Киевская","Львовская", "Днепропетровская", "Харьковская", "Ивано-Франковская",
                    "Тернопольская","Винницкая","Запорожская","Одесская","Ровненская","Хмельницкая","Волынская" ,"Полтавская",
                "Житомирская","Кировоградская","Черкасская","Черновицкая","Черниговская","Николаевская","Закарпатская","Сумская","Херсонская",
                "Донецкая","Луганская","Республика Крым"};

                List<RegionalCenter> ListCent = new List<RegionalCenter>();
                foreach (var item in RangeCent)
                {
                    ListCent.Add(new RegionalCenter() { Name = item });
                }
                _context.RegionalCenter.AddRange(ListCent);
                await _context.SaveChangesAsync();
            }

        }
    }
}