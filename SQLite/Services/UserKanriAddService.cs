using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WordConverter.Common;
using WordConverter.Form;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;

namespace WordConverter.Services
{
    class UserKanriAddService : IService<UserKanriAddServiceInBo, UserKanriAddServiceOutBo>
    {
        private static CommonFunction common = new CommonFunction();
        private UserKanriAddServiceInBo inBo;

        public void setInBo(UserKanriAddServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public UserKanriAddServiceOutBo execute()
        {
            UserKanriAddServiceOutBo outBo = new UserKanriAddServiceOutBo();
            if (String.IsNullOrEmpty(this.inBo.userName)
                || String.IsNullOrEmpty(this.inBo.empId)
                || this.inBo.kengenSelectedIndex.ToString().ToIntType() == -1)
            {
                outBo.errorMessage = "ユーザーID、ユーザー名、権限は必須項目です。\n";
                return outBo;
            }

            using (var context = new MyContext())
            {
                int condition = this.inBo.empId.ToIntType();
                var products = context.UserMst
                    .Where(x => x.EMP_ID == condition)
                    .ToArray();

                if (products.Count() > 0)
                {
                    outBo.errorMessage = "既に登録されています\n";
                    return outBo;
                }
            }

            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.inBo.userKanriDataGridView1.Rows[i].Cells["EMP_ID"].Value.ToString().ToIntType()
                    == this.inBo.empId.ToIntType())
                {
                    outBo.errorMessage = "既に追加されています\n";
                    return outBo;
                }
            }

            List<UserBo> userList = new List<UserBo>();
            UserBo user = new UserBo();

            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                user = new UserBo();
                user.EMP_ID = this.inBo.userKanriDataGridView1.Rows[i].Cells["EMP_ID"].Value.ToString().ToIntType();
                user.USER_NAME = this.inBo.userKanriDataGridView1.Rows[i].Cells["USER_NAME"].Value.ToString();
                user.KENGEN = this.inBo.userKanriDataGridView1.Rows[i].Cells["KENGEN"].Value.ToString().ToIntType();
                userList.Add(user);
            }

            user = new UserBo();
            user.EMP_ID = this.inBo.empId.ToIntType();
            user.USER_NAME = this.inBo.userName;
            user.KENGEN = this.inBo.kengenSelectedIndex;
            userList.Add(user);
            outBo.userList = userList;

            return outBo;
        }
    }
}
