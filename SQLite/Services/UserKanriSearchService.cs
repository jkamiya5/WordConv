using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

                Expression<Func<UserBo, dynamic>> f;
                long empId = 99999;

                if (!String.IsNullOrEmpty(this.inBo.userId))
                {
                    empId = this.inBo.userId.ToKeyType();
                }

                IQueryable<UserBo> users = from a in context.UserMst
                                           where (a.USER_NAME.StartsWith(condition)
                                                    || a.EMP_ID == empId
                                                    //|| a.ROLE == this.inBo.kengenSelectedIndex)
                                                    )
                                           select new UserBo
                                           {
                                               USER_ID = a.USER_ID,
                                               EMP_ID = a.EMP_ID,
                                               USER_NAME = a.USER_NAME,
                                               KENGEN = a.ROLE,
                                               MAIL_ADDRESS = a.MAIL_ADDRESS,
                                               PASSWORD = a.PASSWORD,
                                               SANKA_KAHI = (a.SANKA_KAHI == 0 ? true : false),
                                               VERSION = a.VERSION
                                           };
                outBo.usersList = users.ToList();
            }

            return outBo;
        }
    }
}
