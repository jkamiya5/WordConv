using SQLite.Services;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Services
{
    class ShinseiInitService : IService<ShinseiInitServiceInBo, ShinseiInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private ShinseiInitServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(ShinseiInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShinseiInitServiceOutBo execute()
        {
            ShinseiInitServiceOutBo shinseiInitOutBo = new ShinseiInitServiceOutBo();
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
                                                         RONRI_NAME2 = a.RONRI_NAME2,
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
