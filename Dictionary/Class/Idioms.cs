using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.DictionaryBL.Idioms;
using Dictionary.DictionaryDA;

namespace Dictionary.Class
{
    public class Idioms
    {
        /// <summary>
        /// GetAllIdiormInDatabase
        /// </summary>
        /// <returns></returns>
        public List<Idiorm> GetAllIdiormInDatabase()
        {
            using (var context = new EnViEntities1())
            {
                var result = (from a in context.idioms
                              select new Idiorm()
                              {
                                  ID = a.ID,
                                  EnWord = a.EnWord,
                                  ViWord = a.ViWord
                              }).ToList();
                return result;
            }
        }
    }
}
