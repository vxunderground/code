﻿// Decompiled with JetBrains decompiler
// Type: .
// Assembly: AudioHD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A79492AA-5FAA-4ED2-ACC6-3D90AD665D99
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00000-msil\Trojan-Dropper.Win32.Sysn.awyx-36fae8d04bf5f7d873dd5aa10ad92403f80b9af8b6ef91319e70ea2c9c043024.exe

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace \u0001
{
  internal sealed class \u0001
  {
    private static \u0001.\u0001 \u0001;
    private long \u0001 = DateTime.Now.Ticks;

    [DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]
    private static extern int \u000F(
      IntPtr process,
      int minimumWorkingSetSize,
      int maximumWorkingSetSize);

    private void \u000F()
    {
      try
      {
        using (Process currentProcess = Process.GetCurrentProcess())
          \u0001.\u0001.\u000F(currentProcess.Handle, -1, -1);
      }
      catch
      {
      }
    }

    private void \u000F(object sender, EventArgs e)
    {
      long ticks = DateTime.Now.Ticks;
      if (ticks - this.\u0001 <= 10000000L)
        return;
      this.\u0001 = ticks;
      this.\u000F();
    }

    private \u0001()
    {
      // ISSUE: method pointer
      Application.Idle += new EventHandler((object) this, __methodptr(\u000F));
      this.\u000F();
    }

    public static void \u0010()
    {
      if (Environment.OSVersion.Platform != PlatformID.Win32NT)
        return;
      \u0001.\u0001.\u0001 = new \u0001.\u0001();
    }
  }
}