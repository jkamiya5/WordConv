using SQLite.Form;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvTool.Service;


namespace WordConvertTool
{
    class StrategyDispBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected IBo inBo;
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        protected IBo executeQuery(int status)
        {
            ShinseiInitServiceOutBo shinseiInitOutBo = new ShinseiInitServiceOutBo();

            List<ShinseiBo> shinsei = new List<ShinseiBo>();
            List<ShinseiBo> dispShinseiList = null;

            using (var context = new MyContext())
            {
                IQueryable<ShinseiBo> shinseiWords = from a in context.WordShinsei
                                                     join b in context.UserMst on a.USER_ID equals b.USER_ID into tmpUser
                                                     from u in tmpUser.DefaultIfEmpty()
                                                     where a.STATUS == status
                                                     select new ShinseiBo
                                                        {
                                                            SHINSEI_ID = a.WORD_ID,
                                                            RONRI_NAME1 = a.RONRI_NAME1,
                                                            BUTSURI_NAME = a.BUTSURI_NAME,
                                                            USER_NAME = null != u ? u.USER_NAME : "",
                                                            CRE_DATE = a.CRE_DATE,
                                                            VERSION = (int)a.VERSION
                                                        };

                dispShinseiList = shinseiWords.ToList();
            }
            shinseiInitOutBo.dispShinseiList = dispShinseiList;
            return shinseiInitOutBo;
            //this.inBo.DataSource = dispShinseiList;
            //common.addCheckBox(ref this.inBo);
            //common.viewWidthSetting(ref this.inBo, 20, 65);
            //return this.inBo;
        }
    }
}
