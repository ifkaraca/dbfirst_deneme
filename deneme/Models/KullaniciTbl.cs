using System;
using System.Collections.Generic;

namespace deneme.Models;

public partial class KullaniciTbl
{
    public int Id { get; set; }

    public string KullaniciAdi { get; set; }

    public string KullaniciSoyad { get; set; }

    public string KullaniciTlf { get; set; }

    public string KullaniciSehir { get; set; }
}
