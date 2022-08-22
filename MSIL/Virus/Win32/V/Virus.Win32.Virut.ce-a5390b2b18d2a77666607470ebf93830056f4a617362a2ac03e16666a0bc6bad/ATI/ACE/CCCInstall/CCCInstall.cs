﻿// Decompiled with JetBrains decompiler
// Type: ATI.ACE.CCCInstall.CCCInstall
// Assembly: CCCInstall, Version=2.0.3163.17516, Culture=neutral, PublicKeyToken=null
// MVID: FB1048F0-5C3B-4430-944F-CD20B70875CD
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Virut.ce-a5390b2b18d2a77666607470ebf93830056f4a617362a2ac03e16666a0bc6bad.exe

using ATI.ACE.CCCInstall.Tasks;
using Microsoft.Win32;
using MsGac.Fusion.Native;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ATI.ACE.CCCInstall
{
  internal class CCCInstall
  {
    private const int MAX_NUM_ARGS = 4;
    private const int MIN_NUM_ARGS = 1;
    private const string ACE_PACKAGE_REGKEY32 = "SOFTWARE\\ATI\\ACE";
    private const string ACE_PACKAGE_REGKEY64 = "SOFTWARE\\Wow6432Node\\ATI\\ACE";
    private const string INSTALL_BRANDING_REGKEY = "SOFTWARE\\ATI Technologies\\Install\\ccc-branding";
    private const string REGKEY_LOCATION = "Location";
    private const string REGKEY_INSTALLDIR = "InstallDir";
    private const string ARG_NGEN_UPDATE = "ngen:update";
    private const string ARG_NGEN_INSTALL = "ngen:i";
    private const string ARG_GAC_INSTALL = "gac:i";
    private const string ARG_NGEN_UNINSTALL = "ngen:u";
    private const string ARG_GAC_UNINSTALL = "gac:u";
    private const string ARG_ALL_INSTALL = "all:i";
    private const string ARG_ALL_UNINSTALL = "all:u";
    private const string ARG_CREATEREG = "createreg";
    private const string ARG_CREATEVERSION = "createversion";
    private const string ARG_FILE = "-f";
    private const string ARG_BYPACKAGE = "-p";
    private const string ARG_ALLPACKAGES = "-a";
    private const string ARG_FORCEALLPACKAGES = "-fa";
    private const string ARG_FORCEBRANDING = "-fb";
    private const string ARG_NOLOG = "/nolog";
    private const int ACTION = 0;
    private const int SPEC = 1;
    private const int OPTIONAL_ARG = 2;
    private const string ARG_TOKEN = "90ba9c70f846762e";
    private const string ARG_BRANDING = "Branding";
    private const string ARG_CCCBRANDING = "ccc-branding";
    private string[] args;
    private CCCInstallLog Log;
    private bool showLog = true;
    private static bool allPackages;
    private static bool gacInstall;
    private static bool gacUninstall;

    private static void Main(string[] args)
    {
      ATI.ACE.CCCInstall.CCCInstall cccInstall = new ATI.ACE.CCCInstall.CCCInstall(args);
      try
      {
        if (!ATI.ACE.CCCInstall.CCCInstall.allPackages)
          return;
        if (ATI.ACE.CCCInstall.CCCInstall.gacInstall)
        {
          RegistryKey subKey = Registry.LocalMachine.CreateSubKey(ATI.ACE.CCCInstall.CCCInstall.AceRegKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
          (subKey == null ? (RegistryKey) null : subKey.CreateSubKey("Assemblies", RegistryKeyPermissionCheck.ReadWriteSubTree))?.CreateSubKey("Installed");
        }
        else
        {
          if (!ATI.ACE.CCCInstall.CCCInstall.gacUninstall)
            return;
          RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(ATI.ACE.CCCInstall.CCCInstall.AceRegKey);
          (registryKey == null ? (RegistryKey) null : registryKey.OpenSubKey("Assemblies", true))?.DeleteSubKey("Installed", false);
        }
      }
      catch (Exception ex)
      {
      }
    }

    private static string AceRegKey => IntPtr.Size == 8 ? "SOFTWARE\\Wow6432Node\\ATI\\ACE" : "SOFTWARE\\ATI\\ACE";

    public CCCInstall(string[] argsParam)
    {
      if (argsParam.Length < 1)
        this.ShowInvalidFormatError();
      if (argsParam[argsParam.Length - 1].Equals("/nolog", StringComparison.InvariantCultureIgnoreCase))
      {
        this.showLog = false;
        this.args = new string[argsParam.Length - 1];
        for (int index = 0; index < argsParam.Length - 1; ++index)
          this.args[index] = argsParam[index];
      }
      else
        this.args = argsParam;
      if (this.args.Length < 1 || this.args.Length > 4)
        this.ShowInvalidFormatError();
      this.Log = new CCCInstallLog(this.showLog);
      try
      {
        this.Log.LogMessage("ARGS passed: " + string.Join(" ", argsParam));
        if (this.args[0].Equals("createreg", StringComparison.InvariantCultureIgnoreCase))
          this.ParseSpecArg((ITask) new RegistryTasks(this.Log, Action.CreateReg));
        else if (this.args[0].Equals("createversion", StringComparison.InvariantCultureIgnoreCase) && this.args[1].Equals("-f", StringComparison.InvariantCultureIgnoreCase))
          new VersionTasks(this.Log, Action.CreateVersion).Run(this.args[2]);
        else if (this.args[0].Equals("ngen:update", StringComparison.InvariantCultureIgnoreCase))
          new NgenTasks(this.Log, Action.UpdateNgen).Run("");
        else if (this.args[0].Equals("gac:i", StringComparison.InvariantCultureIgnoreCase))
        {
          ATI.ACE.CCCInstall.CCCInstall.gacInstall = true;
          this.ParseSpecArg((ITask) new GACTasks(this.Log, Action.InstallGAC));
        }
        else if (this.args[0].Equals("gac:u", StringComparison.InvariantCultureIgnoreCase))
        {
          ATI.ACE.CCCInstall.CCCInstall.gacUninstall = true;
          this.ParseSpecArg((ITask) new GACTasks(this.Log, Action.UninstallGAC));
        }
        else if (this.args[0].Equals("ngen:i", StringComparison.InvariantCultureIgnoreCase))
          this.ParseSpecArg((ITask) new NgenTasks(this.Log, Action.InstallNGen));
        else if (this.args[0].Equals("ngen:u", StringComparison.InvariantCultureIgnoreCase))
          this.ParseSpecArg((ITask) new NgenTasks(this.Log, Action.UninstallNGen));
        else if (this.args[0].Equals("all:i", StringComparison.InvariantCultureIgnoreCase))
        {
          ATI.ACE.CCCInstall.CCCInstall.gacInstall = true;
          this.ParseSpecArg((ITask) new GACTasks(this.Log, Action.InstallGAC));
          this.ParseSpecArg((ITask) new NgenTasks(this.Log, Action.InstallNGen));
          this.ParseSpecArg((ITask) new RegistryTasks(this.Log, Action.CreateReg));
        }
        else if (this.args[0].Equals("all:u", StringComparison.InvariantCultureIgnoreCase))
        {
          ATI.ACE.CCCInstall.CCCInstall.gacUninstall = true;
          this.ParseSpecArg((ITask) new NgenTasks(this.Log, Action.UninstallNGen));
          this.ParseSpecArg((ITask) new GACTasks(this.Log, Action.UninstallGAC));
        }
        else
          this.ShowInvalidFormatError();
      }
      finally
      {
        if (this.showLog && this.Log != null)
          this.Log.LogFinished();
      }
    }

    private void RunOnPackage(string packageName, ITask task)
    {
      string name = ATI.ACE.CCCInstall.CCCInstall.AceRegKey + "\\Packages\\" + packageName;
      RegistryKey registryKey = (RegistryKey) null;
      try
      {
        registryKey = Registry.LocalMachine.OpenSubKey(name, false);
        if (registryKey == null)
          this.Log.LogMessage("Error: The registry key " + name + " does not exist.");
        else if (!(registryKey.GetValue("Location") is string str))
          this.Log.LogMessage(string.Format("Error: The registry key {0}\\{1} does not exist.", (object) name, (object) "Location"));
        else
          task.Run(str + "\\Install.xml");
      }
      catch (Exception ex)
      {
        this.Log.LogException(ex);
      }
      finally
      {
        registryKey?.Close();
      }
    }

    private StringCollection GetLanguages(RegistryKey ACEKey)
    {
      StringCollection languages = new StringCollection();
      if (ACEKey == null)
      {
        this.Log.LogMessage("Error: The registry key " + (object) ACEKey + " does not exist.");
      }
      else
      {
        try
        {
          RegistryKey registryKey = ACEKey.OpenSubKey("Languages", false);
          if (registryKey == null)
          {
            this.Log.LogMessage("Error: The registry key " + (object) ACEKey + "\\Languages does not exist.");
          }
          else
          {
            string[] subKeyNames = registryKey.GetSubKeyNames();
            if (subKeyNames.Length > 0)
            {
              for (int index = 0; index < subKeyNames.Length; ++index)
              {
                if (!subKeyNames[index].Equals("en-US"))
                  languages.Add(subKeyNames[index]);
              }
            }
          }
        }
        catch (Exception ex)
        {
          this.Log.LogException(ex);
        }
      }
      return languages;
    }

    private void RunOnAllPackages(ITask task)
    {
      RegistryKey ACEKey = (RegistryKey) null;
      try
      {
        ACEKey = Registry.LocalMachine.OpenSubKey(ATI.ACE.CCCInstall.CCCInstall.AceRegKey, false);
        if (ACEKey == null)
        {
          this.Log.LogMessage("Error: The registry key " + ATI.ACE.CCCInstall.CCCInstall.AceRegKey + " does not exist.");
        }
        else
        {
          StringCollection languages = this.GetLanguages(ACEKey);
          RegistryKey registryKey1 = ACEKey.OpenSubKey("Packages", false);
          if (registryKey1 == null)
          {
            this.Log.LogMessage("Error: The registry key " + ATI.ACE.CCCInstall.CCCInstall.AceRegKey + "\\Packages does not exist.");
          }
          else
          {
            foreach (string subKeyName in registryKey1.GetSubKeyNames())
            {
              try
              {
                RegistryKey registryKey2 = registryKey1.OpenSubKey(subKeyName);
                if (registryKey2 != null)
                {
                  string str1 = registryKey2.GetValue("Location") as string;
                  string filePath1 = str1 + "\\Install.xml";
                  task.Run(filePath1);
                  foreach (string str2 in languages)
                  {
                    string filePath2 = string.Format("{0}\\{1}\\Install.xml", (object) str1, (object) str2);
                    task.Run(filePath2);
                  }
                }
              }
              catch (Exception ex)
              {
                this.Log.LogException(ex);
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        this.Log.LogException(ex);
      }
      finally
      {
        ACEKey?.Close();
      }
    }

    private void RunUnGacAll(ITask task)
    {
      try
      {
        this.Log.LogMessage("Option selected: Force remove all ATI file in the GAC");
        IAssemblyCache ppAsmCache;
        FusionApi.CreateAssemblyCache(out ppAsmCache, 0U);
        int num1 = 0;
        string str = "";
        MsGac.Fusion.Native.IAssemblyEnum ppEnum;
        FusionApi.CreateAssemblyEnum(out ppEnum, IntPtr.Zero, (MsGac.Fusion.Native.IAssemblyName) null, ASM_CACHE_FLAGS.ASM_CACHE_GAC, IntPtr.Zero);
        RegistryKey registryKey1 = (RegistryKey) null;
        RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(ATI.ACE.CCCInstall.CCCInstall.AceRegKey, false);
        if (registryKey2 != null)
          registryKey1 = registryKey2.OpenSubKey("Packages", false);
        else
          this.Log.LogMessage("Error: The registry key " + ATI.ACE.CCCInstall.CCCInstall.AceRegKey + " does not exist.");
        if (registryKey1 == null)
        {
          this.Log.LogMessage("Error: The registry key " + ATI.ACE.CCCInstall.CCCInstall.AceRegKey + "\\Packages does not exist.");
        }
        else
        {
          RegistryKey registryKey3 = registryKey1.OpenSubKey("Branding");
          if (registryKey3 != null)
            str = registryKey3.GetValue("Location") as string;
        }
        MsGac.Fusion.Native.IAssemblyName ppName;
        while (ppEnum.GetNextAssembly(IntPtr.Zero, out ppName, 0U) == 0)
        {
          uint lpcwBuffer = 0;
          ppName.GetName(ref lpcwBuffer, (StringBuilder) null);
          StringBuilder pwzName = new StringBuilder((int) lpcwBuffer);
          ppName.GetName(ref lpcwBuffer, pwzName);
          MsGac.Fusion.Native.ASM_NAME[] values = (MsGac.Fusion.Native.ASM_NAME[]) Enum.GetValues(typeof (MsGac.Fusion.Native.ASM_NAME));
          for (int index1 = 0; index1 < values.Length; ++index1)
          {
            uint pcbProperty = 0;
            IntPtr num2 = IntPtr.Zero;
            try
            {
              ppName.GetProperty(values[index1], IntPtr.Zero, ref pcbProperty);
              num2 = Marshal.AllocHGlobal((int) pcbProperty);
              ppName.GetProperty(values[index1], num2, ref pcbProperty);
              if (values[index1] == MsGac.Fusion.Native.ASM_NAME.PUBLIC_KEY_TOKEN)
              {
                byte[] destination = new byte[(int) pcbProperty];
                Marshal.Copy(num2, destination, 0, (int) pcbProperty);
                StringBuilder stringBuilder = new StringBuilder(2 * (int) pcbProperty);
                for (int index2 = 0; index2 < destination.Length; ++index2)
                  stringBuilder.AppendFormat("{0:x2}", (object) destination[index2]);
                if (stringBuilder.ToString() == "90ba9c70f846762e")
                {
                  string pszAssemblyName = pwzName.ToString();
                  if (this.args.Length > 2 && this.args[2] == "-b" && File.Exists(str + "\\" + pszAssemblyName + ".dll"))
                  {
                    this.Log.LogMessage("Skipping Branding file: - " + str + "\\" + pszAssemblyName + ".dll");
                  }
                  else
                  {
                    uint pulDisposition;
                    ppAsmCache.UninstallAssembly(0U, pszAssemblyName, (FUSION_INSTALL_REFERENCE[]) null, out pulDisposition);
                    if (pulDisposition != 1U)
                      this.Log.LogMessage("Uninstall \"" + pszAssemblyName + "\" failed, ERROR!!!");
                    else
                      this.Log.LogMessage("Uninstall \"" + pszAssemblyName + "\" success");
                    ++num1;
                  }
                }
              }
            }
            catch
            {
            }
            finally
            {
              if (num2 != IntPtr.Zero)
                Marshal.FreeHGlobal(num2);
            }
          }
        }
        this.Log.LogMessage("Total assembly removed: " + (object) num1);
      }
      catch (Exception ex)
      {
        this.Log.LogException(ex);
      }
    }

    private void RunUnGacBranding(ITask task)
    {
      try
      {
        this.Log.LogMessage("Option selected: Force remove all ATI branding file in the GAC");
        IAssemblyCache ppAsmCache;
        FusionApi.CreateAssemblyCache(out ppAsmCache, 0U);
        int num1 = 0;
        string str = "";
        MsGac.Fusion.Native.IAssemblyEnum ppEnum;
        FusionApi.CreateAssemblyEnum(out ppEnum, IntPtr.Zero, (MsGac.Fusion.Native.IAssemblyName) null, ASM_CACHE_FLAGS.ASM_CACHE_GAC, IntPtr.Zero);
        string name = "SOFTWARE\\ATI Technologies\\Install\\ccc-branding";
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name, false);
        if (registryKey == null)
          this.Log.LogMessage("Error: The registry key " + name + "\\Packages does not exist.");
        else
          str = registryKey.GetValue("InstallDir") as string;
        if (str.Length < 1)
        {
          this.Log.LogMessage("ERROR, unable to locate Branding folder!!!");
        }
        else
        {
          MsGac.Fusion.Native.IAssemblyName ppName;
          while (ppEnum.GetNextAssembly(IntPtr.Zero, out ppName, 0U) == 0)
          {
            uint lpcwBuffer = 0;
            ppName.GetName(ref lpcwBuffer, (StringBuilder) null);
            StringBuilder pwzName = new StringBuilder((int) lpcwBuffer);
            ppName.GetName(ref lpcwBuffer, pwzName);
            MsGac.Fusion.Native.ASM_NAME[] values = (MsGac.Fusion.Native.ASM_NAME[]) Enum.GetValues(typeof (MsGac.Fusion.Native.ASM_NAME));
            for (int index1 = 0; index1 < values.Length; ++index1)
            {
              uint pcbProperty = 0;
              IntPtr num2 = IntPtr.Zero;
              try
              {
                ppName.GetProperty(values[index1], IntPtr.Zero, ref pcbProperty);
                num2 = Marshal.AllocHGlobal((int) pcbProperty);
                ppName.GetProperty(values[index1], num2, ref pcbProperty);
                if (values[index1] == MsGac.Fusion.Native.ASM_NAME.PUBLIC_KEY_TOKEN)
                {
                  byte[] destination = new byte[(int) pcbProperty];
                  Marshal.Copy(num2, destination, 0, (int) pcbProperty);
                  StringBuilder stringBuilder = new StringBuilder(2 * (int) pcbProperty);
                  for (int index2 = 0; index2 < destination.Length; ++index2)
                    stringBuilder.AppendFormat("{0:x2}", (object) destination[index2]);
                  if (stringBuilder.ToString() == "90ba9c70f846762e")
                  {
                    string pszAssemblyName = pwzName.ToString();
                    int length = this.args.Length;
                    if (File.Exists(str + "\\" + pszAssemblyName + ".dll"))
                    {
                      uint pulDisposition;
                      ppAsmCache.UninstallAssembly(0U, pszAssemblyName, (FUSION_INSTALL_REFERENCE[]) null, out pulDisposition);
                      if (pulDisposition != 1U)
                      {
                        this.Log.LogMessage("Uninstall \"" + pszAssemblyName + "\" failed, ERROR!!!");
                      }
                      else
                      {
                        this.Log.LogMessage("Uninstall \"" + pszAssemblyName + "\" success");
                        ++num1;
                      }
                    }
                    else
                      this.Log.LogMessage("Skipping file, not branding: - " + str + "\\" + pszAssemblyName + ".dll");
                  }
                }
              }
              catch
              {
              }
              finally
              {
                if (num2 != IntPtr.Zero)
                  Marshal.FreeHGlobal(num2);
              }
            }
          }
          this.Log.LogMessage("Total assembly removed: " + (object) num1);
        }
      }
      catch (Exception ex)
      {
        this.Log.LogException(ex);
      }
    }

    private void RecurseOnRegKey(RegistryKey key, ITask task)
    {
      try
      {
        if (key == null)
        {
          this.Log.LogMessage("Error: Key is null");
        }
        else
        {
          string str = key.GetValue("Location", (object) string.Empty) as string;
          if (string.IsNullOrEmpty(str))
          {
            foreach (string subKeyName in key.GetSubKeyNames())
              this.RecurseOnRegKey(key.OpenSubKey(subKeyName), task);
          }
          else
          {
            string filePath = str + "\\Install.xml";
            task.Run(filePath);
          }
        }
      }
      catch (Exception ex)
      {
        this.Log.LogException(ex);
      }
      finally
      {
        key?.Close();
      }
    }

    private void ParseSpecArg(ITask task)
    {
      if (this.args[1].Equals("-f", StringComparison.InvariantCultureIgnoreCase))
      {
        if (this.args.Length <= 4)
          task.Run(this.args[2]);
        else
          this.ShowInvalidFormatError();
      }
      else if (this.args[1].Equals("-p", StringComparison.InvariantCultureIgnoreCase))
      {
        if (this.args.Length <= 4)
          this.RunOnPackage(this.args[2], task);
        else
          this.ShowInvalidFormatError();
      }
      else if (this.args[1].Equals("-a", StringComparison.InvariantCultureIgnoreCase))
      {
        ATI.ACE.CCCInstall.CCCInstall.allPackages = true;
        if (this.args.Length >= 1)
          this.RunOnAllPackages(task);
        else
          this.ShowInvalidFormatError();
      }
      else if (this.args[1].Equals("-fa", StringComparison.InvariantCultureIgnoreCase))
      {
        ATI.ACE.CCCInstall.CCCInstall.gacUninstall = true;
        ATI.ACE.CCCInstall.CCCInstall.allPackages = true;
        if (this.args.Length >= 1)
          this.RunUnGacAll(task);
        else
          this.ShowInvalidFormatError();
      }
      else if (this.args[1].Equals("-fb", StringComparison.InvariantCultureIgnoreCase))
      {
        if (this.args.Length >= 1)
          this.RunUnGacBranding(task);
        else
          this.ShowInvalidFormatError();
      }
      else
        this.ShowInvalidFormatError();
    }

    private void ShowInvalidFormatError()
    {
      Console.WriteLine("ATI (R) Catalyst Control Center Utility");
      Console.WriteLine("Copyright (C) ATI Technologies 2006.");
      Console.WriteLine("");
      Console.WriteLine("Usage: CCCInstall.exe <action> <inputMode> [filePath|packageName] [noLog]");
      Console.WriteLine("");
      Console.WriteLine("Actions:");
      Console.WriteLine("  ngen:i");
      Console.WriteLine("    Adds assemblies specified in the xml file into Native Assembly Cache");
      Console.WriteLine("  ngen:u");
      Console.WriteLine("    Removes assemblies specified in the xml file from Native Assembly Cache");
      Console.WriteLine("  ngen:update");
      Console.WriteLine("    Updates the ngened images and recompiles invalidated ones.");
      Console.WriteLine("  gac:i");
      Console.WriteLine("    Adds assemblies specified in the xml file into GAC");
      Console.WriteLine("  gac:u");
      Console.WriteLine("    Removes assemblies specified in the xml file from GAC");
      Console.WriteLine("  createreg");
      Console.WriteLine("    Creates a registry containing the full name of the assemblies");
      Console.WriteLine("  createversion");
      Console.WriteLine("    Creates a dat file with the version number to be placed in the registry (-f only)");
      Console.WriteLine("    Ex: Core-Static\\CCCInstall.exe createversion -f Core-Static\\ACE.dat");
      Console.WriteLine("");
      Console.WriteLine("InputModes:");
      Console.WriteLine("  -f <filePath>");
      Console.WriteLine("    Gets list of assemblies from Install.xml at the specified path");
      Console.WriteLine("  -p <packageName>");
      Console.WriteLine("    Uses the Install.xml for the specified package referenced in the registry");
      Console.WriteLine("  -a");
      Console.WriteLine("    Reads the registry for all packages with a valid Install.xml, but skip branding");
      Console.WriteLine("  -fa");
      Console.WriteLine("    Option to remove all ATI file from the GAC without looking at XML files.");
      Console.WriteLine("  -fa -b");
      Console.WriteLine("    Option to remove all ATI file from the GAC, but skip branding files.");
      Console.WriteLine("  -fb");
      Console.WriteLine("    Option to remove all ATI branding file from the GAC without looking at XML files.");
      Console.WriteLine("");
      Console.WriteLine("NoLog:");
      Console.WriteLine("  /nolog");
      Console.WriteLine("    Suppresses log file generation");
      Console.WriteLine("");
      Console.WriteLine("");
      if (this.showLog && this.Log != null)
      {
        this.Log.LogMessage("Invalid syntax.");
        this.Log.LogFinished();
      }
      Environment.Exit(1);
    }
  }
}