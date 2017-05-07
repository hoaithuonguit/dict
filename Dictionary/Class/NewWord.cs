using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary.DictionaryBL.Word;
using Dictionary.DictionaryBL.BaseWords;
using Dictionary.DictionaryDA;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Transactions;

namespace Dictionary.Class
{
    public class NewWord
    {
        /// <summary>
        /// GetAllWordFromDatabase-- using for init Mainform
        /// </summary>
        /// <returns> ToList<Word> </returns>
        public List<Word> GetAllWordFromDatabase()
        {
            using (var context = new EnViEntities1())
            {
                var result = (from a in context.ENWORDs
                              select new Word()
                              {
                                  ID = a.ID,
                                  EnWord = a.EnWord1,
                                  ViWord = a.EnVi,
                                  Type = a.Type,
                                  Example = a.Example,
                                  Favorite = a.Favote,
                              }).ToList<Word>();
                return result;

            }
        }
        public List<BaseWord> Init()
        {
            using (var context = new EnViEntities1())
            {
                var result = (from a in context.ENWORDs
                              select new BaseWord()
                              {
                                  ID = a.ID,
                                  EnWord = a.EnWord1,
                                  ViWord = a.EnVi
                              }).ToList();
                return result;
            }
        }
        /// <summary>
        /// GetWordWhenSearch
        /// </summary>
        /// <param name="inKeyWords"></param>
        /// <returns> List of result search </returns>
        public List<Word> GetWordWhenSearch(string inKeyWords)
        {
            using (var context = new EnViEntities1())
            {
                var result = (from a in context.ENWORDs
                              where a.EnWord1 == inKeyWords
                              select new Word()
                              {
                                  EnWord = a.EnWord1,
                                  ViWord = a.EnVi,
                                  Type = a.Type,
                                  Example = a.Example,
                                  Favorite = a.Favote
                              }).ToList();
                if (result != null) return result;
                else return null;
            }
        }

        public void SetFavorite(string inWord)
        {
            using (var context = new EnViEntities1())
            {
                // update table EnWord!
                try
                {

                    var a = context.ENWORDs.Single(p => p.EnWord1.Equals(inWord));
                    a.Favote = 1;
                    context.SaveChanges();

                }
                catch (Exception ex)
                {

                }
                //insert word to Favorite Table
                try
                {

                }
                catch (Exception e)
                { }

            }
        }

        /// <summary>
        /// InsertNewWords
        /// </summary>
        /// <param name="inID"></param>
        /// <param name="inEnWord"></param>
        /// <param name="inViWord"></param>
        /// <param name="inType"></param>
        /// <param name="inExample"></param>
        public void InsertNewWords(int inID, string inEnWord, string inViWord, string inType, string inExample)
        {
            using (var context = new EnViEntities1())
            {
                var result = (from a in context.ENWORDs
                              where a.EnWord1 == inEnWord
                              select a).ToList();
                if (result.Count() > 0) MessageBox.Show("this word is existed!");
                else
                {
                    using (var trans = new TransactionScope())
                    {
                        try
                        {

                            Word word = new Word()
                            {
                                ID = inID,
                                EnWord = inEnWord,
                                ViWord = inViWord,
                                Type = inType,
                                Example = inExample
                            };
                            context.Entry(word);
                            context.SaveChanges();
                            trans.Complete();

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }



    }
}
