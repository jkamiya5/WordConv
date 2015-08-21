using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Common;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

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

            using (var context = new MyContext())
            {
                IQueryable<HenshuWordBo> ws = from a in context.WordDic
                                              join b in context.UserMst on a.USER_ID equals b.USER_ID
                                              select new HenshuWordBo
                                              {
                                                  WORD_ID = a.WORD_ID,
                                                  RONRI_NAME1 = a.RONRI_NAME1,
                                                  RONRI_NAME2 = a.RONRI_NAME2,
                                                  BUTSURI_NAME = a.BUTSURI_NAME,
                                                  USER_NAME = b.USER_NAME,
                                                  CRE_DATE = a.CRE_DATE,
                                                  VERSION = (int)a.VERSION
                                              };

                object[] keywords = new object[3];
                keywords[0] = this.inBo.ronrimei1TextBox;
                keywords[1] = this.inBo.ronrimei2TextBox;
                keywords[2] = this.inBo.butsurimeiTextBox;

                IQueryable<HenshuWordBo> words = ws.WordDicWhereLike(keywords);

                List<HenshuWordBo> wordList = new List<HenshuWordBo>();
                if (words.Count() > 0)
                {
                    wordList = words.ToList();
                }
                outBo.wordList = wordList;
            }

            return outBo;
        }
    }
}
