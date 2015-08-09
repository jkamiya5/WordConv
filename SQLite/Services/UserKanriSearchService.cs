using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WordConverter.Services;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Form
{
    class UserKanriSearchService : IService<UserKanriSearchServiceInBo, UserKanriSearchServiceOutBo>
    {
        private UserKanriSearchServiceInBo inBo;
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

                Expression<Func<UserBo, dynamic>> f;
                long userId = 99999;

                if (!String.IsNullOrEmpty(this.inBo.userId))
                {
                    userId = (long)Convert.ToInt64(this.inBo.userId);
                    //f = p => new { p.USER_ID };
                }

                IQueryable<UserBo> users = from a in context.UserMst
                                           where (a.USER_NAME.StartsWith(condition)
                                                    && a.USER_ID == userId
                                                    && a.ROLE == this.inBo.kengenSelectedIndex)
                                           //where (f.)
                                           select new UserBo
                                           {
                                               USER_ID = a.USER_ID,
                                               USER_NAME = a.USER_NAME,
                                               KENGEN = a.ROLE,
                                               MAIL_ADDRESS = a.MAIL_ADDRESS,
                                               PASSWORD = a.PASSWORD,
                                               SANKA_KAHI = ((SankaKahi)a.SANKA_KAHI).ToString(),
                                               VERSION = a.VERSION
                                           };
                outBo.usersList = users.ToList();
            }

            return outBo;
        }
    }
}
