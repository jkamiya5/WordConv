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

                Expression<Func<UserBo, dynamic>> f;
                long empId = 99999;

                if (!String.IsNullOrEmpty(this.inBo.empId))
                {
                    empId = this.inBo.empId.ToKeyType();
                }
                object[] keywords = null;
                keywords[0] = this.inBo.empId;
                keywords[1] = this.inBo.userName;
                keywords[2] = this.inBo.kengenSelectedIndex;
                //IEnumerable<UserMst> dataSource = context.UserMst.ToList().Where();
                //var query = dataSource.AsQueryable().Where(GetExpressionTreeWhere(keywords)).
                //                                OrderByDescending(item => item);
                //                               //select new 
                //                               //UserBo{
                //                               //    USER_ID = a.USER_ID,
                //                               //    EMP_ID = a.EMP_ID,
                //                               //    USER_NAME = a.USER_NAME,
                //                               //    KENGEN = a.ROLE,
                //                               //    MAIL_ID = a.MAIL_ID,
                //                               //    MAIL_ADDRESS = a.MAIL_ADDRESS,
                //                               //    PASSWORD = a.PASSWORD,
                //                               //    SANKA_KAHI = (a.SANKA_KAHI == 0 ? true : false),
                //                               //    VERSION = a.VERSION
                //                               //};
                //                           //where (a.USER_NAME.StartsWith(condition)
                //                           //         || a.EMP_ID == empId
                //                           //         //|| a.ROLE == this.inBo.kengenSelectedIndex)
                //                           //where (GetExpressionTreeWhere(keywords))
                //                           //select 
                //                           //new UserBo
                //                           //{
                //                           //    USER_ID = a.USER_ID,
                //                           //    EMP_ID = a.EMP_ID,
                //                           //    USER_NAME = a.USER_NAME,
                //                           //    KENGEN = a.ROLE,
                //                           //    MAIL_ID = a.MAIL_ID,
                //                           //    MAIL_ADDRESS = a.MAIL_ADDRESS,
                //                           //    PASSWORD = a.PASSWORD,
                //                           //    SANKA_KAHI = (a.SANKA_KAHI == 0 ? true : false),
                //                           //    VERSION = a.VERSION
                //                           //};
                ////outBo.usersList = users.ToList();
            }
            return outBo;
        }
    }

    public static class LinqExtension
    {
        public static Expression<Func<UserMst, bool>> WhereLike(
          this Expression<Func<UserMst, bool>> items, object[] keyword)
        {
            Expression<Func<UserMst, bool>> predict1 = x => x.EMP_ID == keyword[0].ToString().ToIntType();
            Expression<Func<UserMst, bool>> predict2 = x => x.USER_NAME.Contains(keyword[1].ToString());
            Expression<Func<UserMst, bool>> predict3 = x => x.ROLE == keyword[2].ToString().ToIntType();
            Expression<Func<UserMst, bool>> predict4 = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString());
            Expression<Func<UserMst, bool>> predict5 = x => x.USER_NAME.Contains(keyword[1].ToString()) && x.ROLE == keyword[2].ToString().ToIntType();
            Expression<Func<UserMst, bool>> predict6 = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.ROLE == keyword[2].ToString().ToIntType();
            Expression<Func<UserMst, bool>> predict7 = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString()) && x.ROLE == keyword[2].ToString().ToIntType();

            return predict1;
        }
    }
}
