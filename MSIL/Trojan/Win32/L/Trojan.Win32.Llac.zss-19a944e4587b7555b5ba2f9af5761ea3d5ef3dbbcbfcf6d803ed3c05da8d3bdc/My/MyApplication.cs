﻿// Decompiled with JetBrains decompiler
// Type: Osmanlı_Stub.My.MyApplication
// Assembly: Osmanlı Stub, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D861F35C-B25E-47D0-AB37-24B6B26AD263
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00000-msil\Trojan.Win32.Llac.zss-19a944e4587b7555b5ba2f9af5761ea3d5ef3dbbcbfcf6d803ed3c05da8d3bdc.exe

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Osmanlı_Stub.My
{
  [GeneratedCode("MyTemplate", "8.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  internal class MyApplication : WindowsFormsApplicationBase
  {
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DebuggerHidden]
    [STAThread]
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
      this.EnableVisualStyles = false;
      this.SaveMySettingsOnExit = true;
      this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
    }

    [DebuggerStepThrough]
    protected override void OnCreateMainForm() => this.MainForm = (Form) MyProject.Forms.Module1;
  }
}