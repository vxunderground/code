﻿// Decompiled with JetBrains decompiler
// Type: .
// Assembly: a5b7ee8e-cbdf-4eff-9144-efd0c433f3fe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 97CE9FDF-0921-44CB-AE13-1E9A2A550F0F
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00000-msil\Virus.Win32.Sality.sil-9eb937e4a3faa7c29e8cc85118a5c87d65f8716c89e5d1b13d7d7bc334ec8975.exe

using \u0001;
using \u0002;
using SmartAssembly.SmartExceptionsCore;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace \u0001
{
  internal sealed class \u0006
  {
    [NonSerialized]
    internal static \u0001.\u0002 \u0001;
    private static string \u0001;
    private static string \u0002;
    private static byte[] \u0001;
    private static Hashtable \u0001;
    private static bool \u0001;
    private static int \u0001;

    public static string \u0003([In] int obj0)
    {
      string str1;
      int num1;
      int num2;
      int num3;
      byte[] numArray1;
      string str2;
      try
      {
        obj0 -= \u0006.\u0001;
        if (\u0006.\u0001)
        {
          str1 = (string) \u0083\u0005.\u007E\u0005\u0006((object) \u0006.\u0001, (object) obj0);
          if (str1 != null)
            return str1;
        }
        num1 = 0;
        num2 = obj0;
        num3 = (int) \u0006.\u0001[num2++];
        if ((num3 & 128) == 0)
        {
          num1 = num3;
          if (num1 == 0)
            return string.Empty;
        }
        else
          num1 = (num3 & 64) != 0 ? ((num3 & 31) << 24) + ((int) \u0006.\u0001[num2++] << 16) + ((int) \u0006.\u0001[num2++] << 8) + (int) \u0006.\u0001[num2++] : ((num3 & 63) << 8) + (int) \u0006.\u0001[num2++];
        string str3;
        try
        {
          numArray1 = \u009A\u0004.\u008E\u0004(\u001E\u0003.\u007E\u0003\u0007((object) \u001F\u0003.\u0005\u0007(), \u0006.\u0001, num2, num1));
          str2 = \u0084\u0005.\u0098\u0003(\u001E\u0003.\u007E\u0003\u0007((object) \u001F\u0003.\u0005\u0007(), numArray1, 0, numArray1.Length));
          if (\u0006.\u0001)
          {
            try
            {
              \u0001\u0005.\u007E\u0002\u0006((object) \u0006.\u0001, (object) obj0, (object) str2);
            }
            catch
            {
            }
          }
          str3 = str2;
        }
        catch
        {
          str3 = (string) null;
        }
        return str3;
      }
      catch (Exception ex)
      {
        string str4 = str1;
        // ISSUE: variable of a boxed type
        __Boxed<int> local1 = (ValueType) num1;
        // ISSUE: variable of a boxed type
        __Boxed<int> local2 = (ValueType) num2;
        // ISSUE: variable of a boxed type
        __Boxed<int> local3 = (ValueType) num3;
        byte[] numArray2 = numArray1;
        string str5 = str2;
        string str6;
        string str7 = str6;
        // ISSUE: variable of a boxed type
        __Boxed<int> local4 = (ValueType) obj0;
        throw UnhandledException.\u0003(ex, (object) str4, (object) local1, (object) local2, (object) local3, (object) numArray2, (object) str5, (object) str7, (object) local4);
      }
    }

    static \u0006()
    {
      Assembly assembly1;
      Stream stream1;
      int length;
      byte[] numArray1;
      try
      {
        \u0003.\u0003();
        \u0006.\u0001 = "1";
        \u0006.\u0002 = "17";
        \u0006.\u0001 = (byte[]) null;
        \u0006.\u0001 = (Hashtable) null;
        \u0006.\u0001 = false;
        \u0006.\u0001 = 0;
        if (\u0008\u0003.\u0081\u0003(\u0006.\u0001, "1"))
        {
          \u0006.\u0001 = true;
          \u0006.\u0001 = new Hashtable();
        }
        \u0006.\u0001 = \u008D\u0005.\u008C\u0004(\u0006.\u0002);
        assembly1 = \u0003\u0003.\u0082\u0006();
        stream1 = \u001F\u0004.\u007E\u001C\u0006((object) assembly1, "{97ce9fdf-0921-44cb-ae13-1e9a2a550f0f}");
        try
        {
          length = \u009F\u0004.\u0089\u0004(\u0006\u0004.\u007E\u0015\u0007((object) stream1));
          numArray1 = new byte[length];
          int num = \u008C\u0003.\u007E\u001B\u0007((object) stream1, numArray1, 0, length);
          \u0006.\u0001 = \u0006.\u0003(numArray1);
          numArray1 = (byte[]) null;
          \u0087\u0005.\u007E\u0018\u0007((object) stream1);
        }
        finally
        {
          if (stream1 != null)
            \u0087\u0005.\u007E\u001F\u0003((object) stream1);
        }
      }
      catch (Exception ex)
      {
        Assembly assembly2 = assembly1;
        Stream stream2 = stream1;
        // ISSUE: variable of a boxed type
        __Boxed<int> local = (ValueType) length;
        byte[] numArray2 = numArray1;
        throw UnhandledException.\u0003(ex, (object) assembly2, (object) stream2, (object) local, (object) numArray2);
      }
    }
  }
}