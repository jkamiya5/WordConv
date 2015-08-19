using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;

namespace WordConverter.Services
{
    class TanitsuTorokuSearchService : IService<TanitsuTorokuSearchServiceInBo, TanitsuTorokuSearchServiceOutBo>
    {
        private TanitsuTorokuSearchServiceInBo inBo;

        public void setInBo(TanitsuTorokuSearchServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public TanitsuTorokuSearchServiceOutBo execute()
        {
            TanitsuTorokuSearchServiceOutBo outBo = new TanitsuTorokuSearchServiceOutBo();

            List<HenshuWordBo> wordList = new List<HenshuWordBo>();
            using (var context = new MyContext())
            {
                String condition = this.inBo.ronrimei1.Trim();
                IQueryable<HenshuWordBo> words = from a in context.WordDic
                                                 join b in context.UserMst on a.USER_ID equals b.USER_ID
                                                 where a.RONRI_NAME1.StartsWith(condition)
                                                 select new HenshuWordBo
                                                 {
                                                     WORD_ID = a.WORD_ID,
                                                     RONRI_NAME1 = a.RONRI_NAME1,
                                                     BUTSURI_NAME = a.BUTSURI_NAME,
                                                     USER_NAME = b.USER_NAME,
                                                     CRE_DATE = a.CRE_DATE,
                                                     VERSION = (int)a.VERSION
                                                 };

                HenshuWordBo[] dispWords = words.ToArray();

                foreach (var word in dispWords)
                {
                    HenshuWordBo w = new HenshuWordBo();
                    w.WORD_ID = word.WORD_ID;
                    w.RONRI_NAME1 = word.RONRI_NAME1;
                    w.BUTSURI_NAME = word.BUTSURI_NAME;
                    w.USER_NAME = word.USER_NAME;
                    w.CRE_DATE = word.CRE_DATE;
                    w.VERSION = (int)word.VERSION;
                    wordList.Add(w);
                }
            }
            outBo.wordList = wordList;
            return outBo;
        }
    }
}
