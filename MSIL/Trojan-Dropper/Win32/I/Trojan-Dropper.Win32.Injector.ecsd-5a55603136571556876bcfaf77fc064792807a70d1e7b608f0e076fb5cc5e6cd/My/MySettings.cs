﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.My.MySettings
// Assembly: Services, Version=1.0.0.0, Culture=neutral
// MVID: 9B55F703-4EB8-46BB-927B-A4635A31F4B1
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00002-msil\Trojan-Dropper.Win32.Injector.ecsd-5a55603136571556876bcfaf77fc064792807a70d1e7b608f0e076fb5cc5e6cd.exe

using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WindowsApplication1.My
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [CompilerGenerated]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());
    private static bool addedHandler;
    private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private static void AutoSaveSettings(object sender, EventArgs e)
    {
      if (!MyProject.Application.SaveMySettingsOnExit)
        return;
      MySettingsProperty.Settings.Save();
    }

    public static MySettings Default
    {
      get
      {
        if (!MySettings.addedHandler)
        {
          object handlerLockObject = MySettings.addedHandlerLockObject;
          ObjectFlowControl.CheckForSyncLockOnValueType(handlerLockObject);
          Monitor.Enter(handlerLockObject);
          try
          {
            if (!MySettings.addedHandler)
            {
              MyProject.Application.Shutdown += (ShutdownEventHandler) ((sender, e) =>
              {
                if (!MyProject.Application.SaveMySettingsOnExit)
                  return;
                MySettingsProperty.Settings.Save();
              });
              MySettings.addedHandler = true;
            }
          }
          finally
          {
            Monitor.Exit(handlerLockObject);
          }
        }
        MySettings defaultInstance = MySettings.defaultInstance;
        return defaultInstance;
      }
    }
  }
}