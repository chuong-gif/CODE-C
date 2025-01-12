using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLamThu_02
{
    public interface INhanVien
    {
        string MaSo { get; }
        int NamSinh { get; set; }
        string Ten { get; set; }

    }
}
