﻿// Decompiled with JetBrains decompiler
// Type: Autodesk.AutoCAD.ADMigrator.Properties.Settings
// Assembly: ADMigrator, Version=18.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1EA8663B-E949-4FAD-ABC5-280393847F56
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Sality.sil-906e49d7772808af1fb67511fd33b01c809079fddb77015425883ca9739cad33.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Autodesk.AutoCAD.ADMigrator.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string ImportInitialDirectory
    {
      get => (string) this[nameof (ImportInitialDirectory)];
      set => this[nameof (ImportInitialDirectory)] = (object) value;
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    [UserScopedSetting]
    public string ExportInitialDirectory
    {
      get => (string) this[nameof (ExportInitialDirectory)];
      set => this[nameof (ExportInitialDirectory)] = (object) value;
    }

    private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
    {
    }

    private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
    {
    }
  }
}