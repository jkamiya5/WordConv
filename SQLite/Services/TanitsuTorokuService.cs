using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace SQLite.Form
{
    class TanitsuTorokuInitService : IService<TanitsuTorokuInitServiceOutBo>
    {
        private TanitsuTorokuInitServiceInBo inBo;

        public void setInBo(WordConvTool.Service.IBo inBo)
        {
            this.inBo = (TanitsuTorokuInitServiceInBo)inBo;
        }

        public TanitsuTorokuInitServiceOutBo execute()
        {
            TanitsuTorokuInitServiceOutBo outBo = new TanitsuTorokuInitServiceOutBo();
            return outBo;
        }
    }
}
