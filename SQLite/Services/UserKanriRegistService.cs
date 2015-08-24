using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConverter.Common;
using WordConverter.Const;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Services
{
    class UserKanriRegistService : IService<UserKanriRegistServiceInBo, UserKanriRegistServiceOutBo>
    {
        private UserKanriRegistServiceInBo inBo;
        private static CommonFunction common = new CommonFunction();

        public void setInBo(UserKanriRegistServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        public UserKanriRegistServiceOutBo execute()
        {
            UserKanriRegistServiceOutBo outBo = new UserKanriRegistServiceOutBo();
            if (this.inputCheck(this.inBo, ref outBo)) { return outBo; }

            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                using (var context = new MyContext())
                {
                    long condtion = Convert.ToInt64(this.inBo.userKanriDataGridView1.Rows[i].Cells["USER_ID"].Value.ToString());
                    var upUser = context.UserMst.Where(x => x.USER_ID == condtion);
                    if (upUser.Count() == 1)
                    {
                        var u = context.UserMst.Single(x => x.USER_ID == condtion);
                        u.EMP_ID = this.inBo.userKanriDataGridView1.Rows[i].Cells["EMP_ID"].Value.ToString().ToIntType();
                        u.USER_NAME = Convert.ToString(this.inBo.userKanriDataGridView1.Rows[i].Cells["USER_NAME"].Value);
                        u.KENGEN = this.inBo.userKanriDataGridView1.Rows[i].Cells["KENGEN"].Value.ToString().ToIntType();
                        u.SANKA_KAHI = (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells["SANKA_KAHI"].Value ? 0 : 1;
                        u.MAIL_ID = this.inBo.userKanriDataGridView1.Rows[i].Cells["MAIL_ID"].Value.ToString();
                        u.MAIL_ADDRESS = this.inBo.userKanriDataGridView1.Rows[i].Cells["MAIL_ADDRESS"].Value.ToString();
                        u.PASSWORD = this.inBo.userKanriDataGridView1.Rows[i].Cells["PASSWORD"].Value.ToString();
                        u.CRE_DATE = System.DateTime.Now.ToString();
                        context.SaveChanges();
                        continue;
                    }
                    UserMst user = new UserMst();
                    user.EMP_ID = this.inBo.userKanriDataGridView1.Rows[i].Cells["EMP_ID"].Value.ToString().ToIntType();
                    user.USER_NAME = this.inBo.userKanriDataGridView1.Rows[i].Cells["USER_NAME"].Value.ToString();
                    user.KENGEN = this.inBo.userKanriDataGridView1.Rows[i].Cells["KENGEN"].Value.ToString().ToIntType();
                    user.SANKA_KAHI = (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells["SANKA_KAHI"].Value ? 0 : 1;
                    user.MAIL_ID = this.inBo.userKanriDataGridView1.Rows[i].Cells["MAIL_ID"].Value.ToString();
                    user.MAIL_ADDRESS = this.inBo.userKanriDataGridView1.Rows[i].Cells["MAIL_ADDRESS"].Value.ToString();
                    user.PASSWORD = this.inBo.userKanriDataGridView1.Rows[i].Cells["PASSWORD"].Value.ToString();
                    user.CRE_DATE = System.DateTime.Now.ToString();
                    context.UserMst.Add(user);
                    context.SaveChanges();
                }
            }
            return outBo;
        }

        private bool inputCheck(UserKanriRegistServiceInBo userKanriRegistServiceInBo, ref UserKanriRegistServiceOutBo outBo)
        {
            bool isExistCheck = false;
            for (int i = 0; i < this.inBo.userKanriDataGridView1.Rows.Count; i++)
            {
                if (this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == null
                    || (bool)this.inBo.userKanriDataGridView1.Rows[i].Cells[0].Value == false)
                {
                    continue;
                }

                if (this.inBo.userKanriDataGridView1.Rows[i].Cells["MAIL_ID"].Value == null
                    || this.inBo.userKanriDataGridView1.Rows[i].Cells["MAIL_ADDRESS"].Value == null
                    || this.inBo.userKanriDataGridView1.Rows[i].Cells["PASSWORD"].Value == null)
                {
                    outBo.errorMessage = "社員ID:" + this.inBo.userKanriDataGridView1.Rows[i].Cells["EMP_ID"].Value.ToString() + MessageConst.ERR_006;
                    return true;
                }
                isExistCheck = true;
            }
            if (!isExistCheck)
            {
                outBo.errorMessage = MessageConst.ERR_005;
                return true;
            }
            return false;
        }
    }
}
