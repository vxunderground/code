﻿// Decompiled with JetBrains decompiler
// Type: .
// Assembly: syncuiLoader, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F112AE9C-7564-463C-8834-3BB2BC4FBE1B
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Trojan.Win32.Llac.aamy-d1153c91831872cfeacf510426d9b4752eab5933102816559dcd2628b12a7253.exe

using \u0001;
using SmartAssembly.SmartExceptionsCore;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace \u0001
{
  internal sealed class \u0003
  {
    private static Assembly \u0001;
    private static string[] \u0001;

    internal static void \u0003()
    {
      try
      {
        try
        {
          AppDomain.CurrentDomain.ResourceResolve += new ResolveEventHandler(\u0003.\u0003);
        }
        catch (Exception ex)
        {
        }
      }
      catch (Exception ex)
      {
        throw UnhandledException.\u0003(ex);
      }
    }

    internal static Assembly \u0003([In] object obj0, [In] ResolveEventArgs obj1)
    {
      string[] strArray1;
      string name;
      int index;
      try
      {
        if ((object) \u0003.\u0001 == null)
        {
          Monitor.Enter((object) (strArray1 = \u0003.\u0001));
          try
          {
            \u0003.\u0001 = Assembly.Load("{a20cd604-49cf-4ebe-a00c-0da3002f5679}, PublicKeyToken=3e56350693f7355e");
            if ((object) \u0003.\u0001 != null)
              \u0003.\u0001 = \u0003.\u0001.GetManifestResourceNames();
          }
          finally
          {
            Monitor.Exit((object) strArray1);
          }
        }
        name = obj1.Name;
        for (index = 0; index < \u0003.\u0001.Length; ++index)
        {
          if (\u0003.\u0001[index] == name)
            return \u0003.\u0001;
        }
        return (Assembly) null;
      }
      catch (Exception ex)
      {
        string str = name;
        // ISSUE: variable of a boxed type
        __Boxed<int> local = (ValueType) index;
        string[] strArray2 = strArray1;
        object obj = obj0;
        ResolveEventArgs resolveEventArgs = obj1;
        throw UnhandledException.\u0003(ex, (object) str, (object) local, (object) strArray2, obj, (object) resolveEventArgs);
      }
    }

    static \u0003()
    {
      try
      {
        \u0003.\u0001 = (Assembly) null;
        \u0003.\u0001 = new string[0];
      }
      catch (Exception ex)
      {
        throw UnhandledException.\u0003(ex);
      }
    }
  }
}