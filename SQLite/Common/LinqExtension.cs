using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordConverter.Common;
using WordConvertTool;
using WordConvTool;
using WordConvTool.Model;

namespace WordConverter.Common
{
    public static class LinqExtension
    {
        private static CommonFunction common = new CommonFunction();

        public static IQueryable<UserMst> UserMstWhereLike(
            this IQueryable<UserMst> source, object[] keyword)
        {
            Expression<Func<UserMst, bool>> predict = null;

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1)
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.USER_NAME.Contains(keyword[1].ToString()) && x.KENGEN == keyword[2].ToString().ToIntType();
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
                predict = x => x.USER_NAME.Contains(keyword[1].ToString()) && x.KENGEN == keyword[2].ToString().ToIntType();
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                String.IsNullOrEmpty(keyword[1].ToString()))
            {
                predict = x => x.EMP_ID == keyword[0].ToString().ToIntType() && x.KENGEN == keyword[2].ToString().ToIntType();
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
                predict = x => x.KENGEN == keyword[2].ToString().ToIntType();
                return source.Where(predict);
            }

            return source.Where(predict);
        }


        public static IQueryable<HenshuWordBo> WordDicWhereLike(
        this IQueryable<HenshuWordBo> source, object[] keyword)
        {
            Expression<Func<HenshuWordBo, bool>> predict = null;

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                !String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME1.Contains(keyword[0].ToString()) && x.RONRI_NAME2.Contains(keyword[1].ToString()) && x.BUTSURI_NAME.Contains(keyword[2].ToString());
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME1.Contains(keyword[0].ToString()) && x.RONRI_NAME2.Contains(keyword[1].ToString());
                return source.Where(predict);
            }

            return source.Where(predict);
        }
    }
}
