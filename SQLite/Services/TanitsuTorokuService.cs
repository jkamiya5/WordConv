using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;

namespace WordConverter.Services
{
    class TanitsuTorokuInitService : IService<TanitsuTorokuInitServiceInBo, TanitsuTorokuInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private TanitsuTorokuInitServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(TanitsuTorokuInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TanitsuTorokuInitServiceOutBo execute()
        {
            TanitsuTorokuInitServiceOutBo outBo = new TanitsuTorokuInitServiceOutBo();
            List<HenshuWordBo> wordList = new List<HenshuWordBo>();

            if (!String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                string ronriName = this.inBo.clipboardText;
                using (var context = new MyContext())
                {
                    IQueryable<HenshuWordBo> words = from a in context.WordDic
                                                     join b in context.UserMst on a.USER_ID equals b.USER_ID
                                                     select new HenshuWordBo
                                                     {
                                                         WORD_ID = a.WORD_ID,
                                                         RONRI_NAME1 = a.RONRI_NAME1,
                                                         BUTSURI_NAME = a.BUTSURI_NAME,
                                                         USER_NAME = b.USER_NAME,
                                                         CRE_DATE = a.CRE_DATE,
                                                         VERSION = (int)a.VERSION
                                                     };
                    String condition = ronriName.Trim();
                    HenshuWordBo[] dispWords = words.Where(x => x.RONRI_NAME1.IndexOf(condition) > -1).ToArray();

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
            }
            outBo.henshuWordBoList = wordList;
            return outBo;
        }
    }
}
