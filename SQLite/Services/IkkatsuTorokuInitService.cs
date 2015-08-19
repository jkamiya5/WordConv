using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;

namespace WordConverter.Services
{
    public class IkkatsuTorokuInitService : IService<IkkatsuTorokuInitServiceInBo, IkkatsuTorokuInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private IkkatsuTorokuInitServiceInBo inBo = new IkkatsuTorokuInitServiceInBo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InBo"></param>
        internal void setInBo(IkkatsuTorokuInitServiceInBo InBo)
        {
            this.inBo = InBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal IkkatsuTorokuInitServiceOutBo execute()
        {
            IkkatsuTorokuInitServiceOutBo outBo = new IkkatsuTorokuInitServiceOutBo();

            List<HenshuWordBo> wordList = new List<HenshuWordBo>();

            if (!String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                string key = this.inBo.clipboardText;
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);
                bool isExistWordDic = false;
                foreach (String ronriName in keys)
                {
                    isExistWordDic = false;

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
                        HenshuWordBo[] dispWords = words.Where(x => x.RONRI_NAME1 == condition).ToArray();

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
                            isExistWordDic = true;
                        }
                    }
                    if (!isExistWordDic)
                    {
                        HenshuWordBo w = new HenshuWordBo();
                        w.RONRI_NAME1 = ronriName;
                        wordList.Add(w);
                    }
                }
            }
            outBo.henshuWordBoList = wordList;
            return outBo;
        }

        void IService<IkkatsuTorokuInitServiceInBo, IkkatsuTorokuInitServiceOutBo>.setInBo(IkkatsuTorokuInitServiceInBo inBo)
        {
            throw new NotImplementedException();
        }

        IkkatsuTorokuInitServiceOutBo IService<IkkatsuTorokuInitServiceInBo, IkkatsuTorokuInitServiceOutBo>.execute()
        {
            throw new NotImplementedException();
        }
    }
}
