using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordConvTool.Service;

namespace SQLite.Services
{
    interface IService<T>
    {
        void setInBo(IBo inBo);
        T execute();
    }
}
