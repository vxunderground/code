﻿// Decompiled with JetBrains decompiler
// Type: MicrosoftWindows.My.MyApplication
// Assembly: LethalKeyloggerStubFREE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CDA884B2-DDEA-4F9B-B77F-DA62A4B22D2E
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Trojan-Spy.MSIL.KeyLogger.cuw-8978a533113cb238230aa54274a793f958cac462d3c087972be36a1149c3ade9.exe

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace MicrosoftWindows.My
{
  [GeneratedCode("MyTemplate", "8.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal class MyApplication : WindowsFormsApplicationBase
  {
    [STAThread]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DebuggerHidden]
    internal static void Main(string[] Args)
    {
      try
      {
        Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
      }
      finally
      {
      }
      MyProject.Application.Run(Args);
    }

    [DebuggerStepThrough]
    public MyApplication()
      : base(AuthenticationMode.Windows)
    {
      this.IsSingleInstance = false;
      this.EnableVisualStyles = true;
      this.SaveMySettingsOnExit = true;
      this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
    }

    [DebuggerStepThrough]
    protected override void OnCreateMainForm() => this.MainForm = (Form) MyProject.Forms.Form1;
  }
}