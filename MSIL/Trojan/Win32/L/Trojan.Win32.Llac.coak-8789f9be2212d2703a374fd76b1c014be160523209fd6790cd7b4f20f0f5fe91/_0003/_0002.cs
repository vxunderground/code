﻿// Decompiled with JetBrains decompiler
// Type: .
// Assembly: RC4STUB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 160606E6-36B6-4FBA-AFEC-6A83B6EA2ADB
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare.00004-msil\Trojan.Win32.Llac.coak-8789f9be2212d2703a374fd76b1c014be160523209fd6790cd7b4f20f0f5fe91.exe

using \u0002;
using \u0003;
using \u0004;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace \u0003
{
  [GeneratedCode("MyTemplate", "8.0.0.0")]
  internal sealed class \u0002
  {
    private static readonly \u0003.\u0002.\u0003<\u0001> \u0001 = new \u0003.\u0002.\u0003<\u0001>();
    private static readonly \u0003.\u0002.\u0003<\u0002.\u0002> \u0001 = new \u0003.\u0002.\u0003<\u0002.\u0002>();
    private static readonly \u0003.\u0002.\u0003<User> \u0001 = new \u0003.\u0002.\u0003<User>();
    private static \u0003.\u0002.\u0003<\u0003.\u0002.\u0001> \u0001 = new \u0003.\u0002.\u0003<\u0003.\u0002.\u0001>();
    private static readonly \u0003.\u0002.\u0003<\u0003.\u0002.\u0002> \u0001 = new \u0003.\u0002.\u0003<\u0003.\u0002.\u0002>();

    [DebuggerNonUserCode]
    static \u0002()
    {
    }

    [SpecialName]
    internal static \u0002.\u0002 \u0002() => \u0003.\u0002.\u0001.\u0002();

    [SpecialName]
    internal static \u0003.\u0002.\u0001 \u0002() => \u0003.\u0002.\u0001.\u0002();

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class \u0001
    {
      public \u0001 \u0001;
      [ThreadStatic]
      private static Hashtable \u0001;

      [DebuggerNonUserCode]
      [SpecialName]
      public \u0001 \u0002()
      {
        this.\u0001 = \u0003.\u0002.\u0001.\u0002<\u0001>(this.\u0001);
        return this.\u0001;
      }

      private static T \u0002<T>([In] T obj0) where T : Form, new()
      {
        if ((object) obj0 != null && !obj0.IsDisposed)
          return obj0;
        if (\u0003.\u0002.\u0001.\u0001 != null)
        {
          // ISSUE: type reference
          if (\u0010\u0002.\u007E\u007F\u0002((object) \u0003.\u0002.\u0001.\u0001, (object) \u001B\u0002.\u0015\u0002(__typeref (T))))
            throw new InvalidOperationException(\u008D.\u0083(\u0001.\u0002(88), new string[0]));
        }
        else
          goto label_10;
label_4:
        // ISSUE: type reference
        \u0006\u0002.\u007E\u001F\u0002((object) \u0003.\u0002.\u0001.\u0001, (object) \u001B\u0002.\u0015\u0002(__typeref (T)), (object) null);
        try
        {
          return new T();
        }
        catch (TargetInvocationException ex) when (
        {
          // ISSUE: unable to correctly present filter
          ProjectData.SetProjectError((Exception) ex);
          if (\u000F\u0002.\u007E\u0004\u0002((object) ex) != null)
          {
            SuccessfulFiltering;
          }
          else
            throw;
        }
        )
        {
          throw new InvalidOperationException(\u008D.\u0083(\u0001.\u0002(129), new string[1]
          {
            \u008A.\u007E\u0003\u0002((object) \u000F\u0002.\u007E\u0004\u0002((object) ex))
          }), \u000F\u0002.\u007E\u0004\u0002((object) ex));
        }
        finally
        {
          // ISSUE: type reference
          \u0097.\u007E\u0081\u0002((object) \u0003.\u0002.\u0001.\u0001, (object) \u001B\u0002.\u0015\u0002(__typeref (T)));
        }
label_10:
        \u0003.\u0002.\u0001.\u0001 = new Hashtable();
        goto label_4;
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public \u0001()
      {
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals([In] object obj0) => \u0010\u0002.\u0094((object) this, \u008C.\u009D\u0002(obj0));

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() => \u0017\u0002.\u0095((object) this);

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() => \u008A.\u0093((object) this);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class \u0002
    {
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals([In] object obj0) => \u0010\u0002.\u0094((object) this, \u008C.\u009D\u0002(obj0));

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() => \u0017\u0002.\u0095((object) this);

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() => \u008A.\u0093((object) this);

      [EditorBrowsable(EditorBrowsableState.Never)]
      public \u0002()
      {
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class \u0003<T> where T : new()
    {
      [SpecialName]
      internal T \u0002()
      {
        // ISSUE: reference to a compiler-generated field
        if ((object) \u0003.\u0002.\u0003<T>.\u0001 == null)
          goto label_2;
label_1:
        // ISSUE: reference to a compiler-generated field
        return \u0003.\u0002.\u0003<T>.\u0001;
label_2:
        // ISSUE: reference to a compiler-generated field
        \u0003.\u0002.\u0003<T>.\u0001 = new T();
        goto label_1;
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public \u0003()
      {
      }
    }
  }
}