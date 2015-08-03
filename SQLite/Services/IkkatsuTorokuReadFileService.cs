using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLite.Form
{
    class IkkatsuTorokuReadFileService : IService<IkkatsuTorokuReadFileServiceOutBo>
    {
        public void setInBo(WordConvTool.Service.IBo inBo)
        {
            throw new NotImplementedException();
        }

        public IkkatsuTorokuReadFileServiceOutBo execute()
        {
            IkkatsuTorokuReadFileServiceOutBo outBo = new IkkatsuTorokuReadFileServiceOutBo();
            return outBo;
        }
    }
}
