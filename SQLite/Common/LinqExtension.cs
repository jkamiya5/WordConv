using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WordConverter.Common;
using WordConverter.Form;
using WordConvertTool;
using WordConvTool;
using WordConvTool.Model;

namespace WordConverter.Common
{
    public static class LinqExtension
    {
        private static CommonFunction common = new CommonFunction();

        /// <summary>
        /// 単一編集画面検索条件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<UserBo> UserMstWhereLike(
            this IQueryable<UserBo> source, object[] keyword)
        {
            Expression<Func<UserBo, bool>> predict = x => 1 == 1;
            var empId = keyword[0].ToString().ToIntType();
            var userName = keyword[1].ToString();
            var kengen = keyword[2].ToString().ToIntType();

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 && 
                keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.EMP_ID == empId && x.USER_NAME.Contains(userName) && x.KENGEN == kengen;
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                (keyword[2].ToString().ToIntType() == -1 ||
                keyword[2].ToString().ToIntType() == 2))
            {
                predict = x => x.EMP_ID == empId && x.USER_NAME.Contains(userName);
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.EMP_ID == empId && x.KENGEN == kengen;
                return source.Where(predict);
            }

            if (String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                keyword[2].ToString().ToIntType() != -1 &&
                keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.USER_NAME.Contains(userName) && x.KENGEN == kengen;
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()))
            {
                predict = x => x.EMP_ID == empId;
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[1].ToString()))
            {
                predict = x => x.USER_NAME.Contains(userName);
                return source.Where(predict);
            }

            if (keyword[2].ToString().ToIntType() != -1 && keyword[2].ToString().ToIntType() != 2)
            {
                predict = x => x.KENGEN == kengen;
                return source.Where(predict);
            }

            return source.Where(predict);
        }


        /// <summary>
        /// ユーザーマスタ画面検索条件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<HenshuWordBo> WordDicWhereLike(
        this IQueryable<HenshuWordBo> source, object[] keyword)
        {
            Expression<Func<HenshuWordBo, bool>> predict = x => 1 == 1;
            var ronriname1 = keyword[0].ToString();
            var ronriname2 = keyword[1].ToString();
            var butsuriname = keyword[2].ToString();

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                !String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME1.Contains(ronriname1) && x.RONRI_NAME2.Contains(ronriname2) && x.BUTSURI_NAME.Contains(butsuriname);
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME1.Contains(ronriname1) && x.RONRI_NAME2.Contains(ronriname2);
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                String.IsNullOrEmpty(keyword[1].ToString()) &&
                !String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME1.Contains(ronriname1) && x.BUTSURI_NAME.Contains(butsuriname);
                return source.Where(predict);
            }

            if (String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                !String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME2.Contains(ronriname2) && x.BUTSURI_NAME.Contains(butsuriname);
                return source.Where(predict);
            }

            if (!String.IsNullOrEmpty(keyword[0].ToString()) &&
                String.IsNullOrEmpty(keyword[1].ToString()) &&
                String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME1.Contains(ronriname1);
                return source.Where(predict);
            }

            if (String.IsNullOrEmpty(keyword[0].ToString()) &&
                !String.IsNullOrEmpty(keyword[1].ToString()) &&
                String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.RONRI_NAME2.Contains(ronriname2);
                return source.Where(predict);
            }

            if (String.IsNullOrEmpty(keyword[0].ToString()) &&
                String.IsNullOrEmpty(keyword[1].ToString()) &&
                !String.IsNullOrEmpty(keyword[2].ToString()))
            {
                predict = x => x.BUTSURI_NAME.Contains(butsuriname);
                return source.Where(predict);
            }

            return source.Where(predict);
        }
    }
}
