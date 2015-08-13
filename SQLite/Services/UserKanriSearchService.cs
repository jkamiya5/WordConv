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

                object[] keywords = new object[3];
                keywords[0] = this.inBo.empId.NullAble();
                keywords[1] = this.inBo.userName.NullAble();
                keywords[2] = this.inBo.kengenSelectedIndex.NullAble();

                IEnumerable<UserMst> dataSource = context.UserMst.ToList();
                IQueryable<UserBo> users = from a in dataSource.AsQueryable().
                                               WhereLike(keywords).
                                               OrderByDescending(item => item)

                                           select new UserBo
                                           {
                                               USER_ID = a.USER_ID,
                                               EMP_ID = a.EMP_ID,
                                               USER_NAME = a.USER_NAME,
                                               KENGEN = a.ROLE,
                                               MAIL_ID = a.MAIL_ID,
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

    public static class LinqExtension
    {
        public static IQueryable<UserMst> WhereLike(
            this IQueryable<UserMst> source, object[] keyword)
        {
            Expression<Func<UserMst, bool>> predict = null;
            int i = 0;
            string condtion = keyword[i].ToString().AddCondtion(i);

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                !String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString()) && x.ROLE == keyword[2].ToString().ToIntType();
            }

            //if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString());
            //}

            //if (!String.IsNullOrEmpty(keyword[1].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[2].ToString()) &&
            //    String.IsNullOrEmpty(keyword[0].ToString()))
            //{
            //    predict = x => x.USER_NAME.Contains(keyword[1].ToString()) && x.ROLE == keyword[2].ToString().ToIntType();
            //}

            //if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
            //    !String.IsNullOrEmpty(keyword[2].ToString()) &&
            //    String.IsNullOrEmpty(keyword[1].ToString()))
            //{
            //    predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.ROLE == keyword[2].ToString().ToIntType();
            //}

            //if (!String.IsNullOrEmpty(keyword[0].ToString()))
            //{
            //    predict = x => x.EMP_ID == keyword[0].ToString().ToIntType();
            //}

            //if (!String.IsNullOrEmpty(keyword[1].ToString()))
            //{
            //    predict = x => x.USER_NAME.Contains(keyword[1].ToString());
            //}

            //if (!String.IsNullOrEmpty(keyword[2].ToString()))
            //{
            //    predict = x => x.ROLE == keyword[2].ToString().ToIntType();
            //}

            return source.Where(predict);
        }
    }
}
