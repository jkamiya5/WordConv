using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Common;
using WordConverter.Form;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Services
{
    class UserKanriSearchService : IService<UserKanriSearchServiceInBo, UserKanriSearchServiceOutBo>
    {
        private UserKanriSearchServiceInBo inBo;
        private static CommonFunction common = new CommonFunction();

        public void setInBo(UserKanriSearchServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public UserKanriSearchServiceOutBo execute()
        {
            UserKanriSearchServiceOutBo outBo = new UserKanriSearchServiceOutBo();
            using (var context = new MyContext())
            {
                IQueryable<UserBo> users = from a in context.UserMst
                                           where a.DELETE_FLG == 0
                                           select new UserBo
                                           {
                                               USER_ID = a.USER_ID,
                                               EMP_ID = a.EMP_ID,
                                               USER_NAME = a.USER_NAME,
                                               KENGEN = a.KENGEN,
                                               MAIL_ID = a.MAIL_ID,
                                               MAIL_ADDRESS = a.MAIL_ADDRESS,
                                               PASSWORD = a.PASSWORD,
                                               CRE_DATE = a.CRE_DATE,
                                               SANKA_KAHI = (a.SANKA_KAHI == 0 ? true : false),
                                               VERSION = a.VERSION
                                           };

                object[] keywords = new object[3];
                keywords[0] = this.inBo.empId;
                keywords[1] = this.inBo.userName;
                keywords[2] = this.inBo.kengenSelectedIndex;
                IQueryable<UserBo> us = users.UserMstWhereLike(keywords).OrderByDescending(item => item);

                List<UserBo> usersList = new List<UserBo>();
                if (us.Count() > 0)
                {
                    usersList = us.ToList();
                }
                outBo.usersList = usersList;
            }
            return outBo;
        }
    }
}
