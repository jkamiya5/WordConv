using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using WordConverter.Services;
using WordConvertTool;
using WordConvTool;
using WordConvTool.Model;

namespace WordConverter.Form
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
                String condition = this.inBo.userName.Trim();

                object[] keywords = new object[3];
                keywords[0] = this.inBo.empId;
                keywords[1] = this.inBo.userName;
                keywords[2] = this.inBo.kengenSelectedIndex;

                IEnumerable<UserMst> dataSource = context.UserMst.ToList();
                IQueryable<UserBo> users = from a in dataSource.AsQueryable().
                                               UserMstWhereLike(keywords).
                                               OrderByDescending(item => item)

                                           select new UserBo
                                           {
                                               USER_ID = a.USER_ID,
                                               EMP_ID = a.EMP_ID,
                                               USER_NAME = a.USER_NAME,
                                               KENGEN = a.KENGEN,
                                               MAIL_ID = a.MAIL_ID,
                                               MAIL_ADDRESS = a.MAIL_ADDRESS,
                                               PASSWORD = a.PASSWORD,
                                               SANKA_KAHI = (a.SANKA_KAHI == 0 ? true : false),
                                               VERSION = a.VERSION
                                           };

                List<UserBo> usersList = new List<UserBo>();
                if (users.Count() > 0)
                {
                   usersList  = users.ToList();
                }
                outBo.usersList = usersList;
            }
            return outBo;
        }
    }
}
