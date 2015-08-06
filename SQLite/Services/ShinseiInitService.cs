using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool.Model;

namespace SQLite.Form
{
    class ShinseiInitService : IService<ShinseiInitServiceInBo, ShinseiInitServiceOutBo>
    {
        private ShinseiInitServiceInBo inBo;

        public void setInBo(ShinseiInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public ShinseiInitServiceOutBo execute()
        {

            ShinseiInitServiceOutBo shinseiInitOutBo = new ShinseiInitServiceOutBo();

            List<ShinseiBo> shinsei = new List<ShinseiBo>();
            List<ShinseiBo> dispShinseiList = null;

            using (var context = new MyContext())
            {
                IQueryable<ShinseiBo> shinseiWords = from a in context.WordShinsei
                                                     join b in context.UserMst on a.USER_ID equals b.USER_ID into tmpUser
                                                     from u in tmpUser.DefaultIfEmpty()
                                                     where a.STATUS == 0
                                                     select new ShinseiBo
                                                     {
                                                         SHINSEI_ID = a.SHINSEI_ID,
                                                         RONRI_NAME1 = a.RONRI_NAME1,
                                                         BUTSURI_NAME = a.BUTSURI_NAME,
                                                         USER_NAME = null != u ? u.USER_NAME : "",
                                                         CRE_DATE = a.CRE_DATE,
                                                         STATUS = ((ShinseiKbn)a.STATUS).ToString(),
                                                         VERSION = (int)a.VERSION
                                                     };

                dispShinseiList = shinseiWords.Where(a => a.SHINSEI_ID != 0).ToList();
            }
            shinseiInitOutBo.dispShinseiList = dispShinseiList;
            return shinseiInitOutBo;
        }
    }
}
