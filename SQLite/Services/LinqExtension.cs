using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordConvertTool;
using WordConvTool;
using WordConvTool.Model;

namespace WordConverter.Services
{
    public static class LinqExtension
    {
        private static CommonFunction common = new CommonFunction();

        public static IQueryable<UserMst> UserMstWhereLike(
            this IQueryable<UserMst> source, object[] keyword)
        {
            Expression<Func<UserMst, bool>> predict = x => x.USER_NAME == "";

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1)
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString()) && x.ROLE == keyword[2].ToString().ToIntType();
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1)
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString());
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                String.IsNullOrEmpty(keyword[0].ToString()))
            {
                predict = x => x.USER_NAME.Contains(keyword[1].ToString()) && x.ROLE == keyword[2].ToString().ToIntType();
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                String.IsNullOrEmpty(keyword[1].ToString()))
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.ROLE == keyword[2].ToString().ToIntType();
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()))
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType();
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[1].ToString()))
            {
                predict = x => x.USER_NAME.Contains(keyword[1].ToString());
                return source.Where(predict);
            }

            if (keyword[2].ToString().ToIntType() != -1)
            {
                predict = x => x.ROLE == keyword[2].ToString().ToIntType();
                return source.Where(predict);
            }

            return source.Where(predict);
        }


        public static IQueryable<WordDic> WordDicWhereLike(
        this IQueryable<WordDic> source, object[] keyword)
        {
            Expression<Func<WordDic, bool>> predict = x => x.RONRI_NAME1 == "";

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1)
            {
                predict = x => x.RONRI_NAME1 == keyword[0].ToString() && x.RONRI_NAME2.Contains(keyword[1].ToString()) && x.BUTSURI_NAME == keyword[2].ToString();
                return source.Where(predict);
            }

            return source.Where(predict);
        }
    }
}
