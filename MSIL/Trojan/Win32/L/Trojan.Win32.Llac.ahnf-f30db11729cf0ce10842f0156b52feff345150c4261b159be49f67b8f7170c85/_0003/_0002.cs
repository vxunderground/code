﻿// Decompiled with JetBrains decompiler
// Type: .
// Assembly: Stub, Version=10.1.0.54, Culture=neutral, PublicKeyToken=null
// MVID: B6CAF90E-24AA-429E-AF0C-6337F759D114
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Trojan.Win32.Llac.ahnf-f30db11729cf0ce10842f0156b52feff345150c4261b159be49f67b8f7170c85.exe

using \u0003;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace \u0003
{
  internal class \u0002
  {
    private static bool \u0002([In] Assembly obj0, [In] Assembly obj1)
    {
      byte[] publicKey1 = obj0.GetName().GetPublicKey();
label_19:
      byte[] publicKey2 = obj1.GetName().GetPublicKey();
      int num1 = publicKey2 == null ? 1 : 0;
      int num2 = 0;
      int num3;
      int num4;
      int num5;
      if (num2 == 0)
      {
        if (num2 == 0)
        {
          num4 = publicKey1 == null ? 1 : 0;
          num3 = num1;
        }
        else
        {
          num5 = num1;
          goto label_15;
        }
      }
      else
        goto label_17;
label_5:
      if (num3 != num4)
        return false;
      int num6;
      if (publicKey2 != null)
        num6 = 0;
      else
        goto label_18;
label_9:
      int index = num6;
      if (false)
        goto label_19;
      else
        goto label_16;
label_15:
      index = num5;
label_16:
      int num7 = index;
      num2 = publicKey2.Length;
      num1 = num7;
label_17:
      int num8 = num2;
      if (num1 < num8)
      {
        num3 = (int) publicKey2[index];
        num4 = (int) publicKey1[index];
        if (true)
        {
          if (num3 != num4)
          {
            int num9 = 0;
            if (num9 == 0)
              return num9 != 0;
            num6 = num9;
            goto label_9;
          }
          else
          {
            num5 = index + 1;
            goto label_15;
          }
        }
        else
          goto label_5;
      }
label_18:
      return true;
    }

    public static byte[] \u0002([In] byte[] obj0)
    {
      Assembly callingAssembly = Assembly.GetCallingAssembly();
      Assembly assembly;
      if (true)
        assembly = callingAssembly;
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      if ((object) assembly != (object) executingAssembly)
        goto label_51;
label_4:
      \u0003.\u0002.\u0007 obj1 = new \u0003.\u0002.\u0007(obj0);
      byte[] numArray1 = new byte[0];
      int num1 = obj1.\u0003();
      int num2;
      int num3;
      int num4;
      if (num1 == 67324752)
      {
        short num5 = (short) obj1.\u0002();
        int num6 = obj1.\u0002();
        int num7 = obj1.\u0002();
        if (num1 != 67324752 || num5 != (short) 20 || num6 != 0 || num7 != 8)
          throw new FormatException("Wrong Header Signature");
        obj1.\u0003();
        obj1.\u0003();
        obj1.\u0003();
        int length = obj1.\u0003();
        int count1 = obj1.\u0002();
        int count2 = obj1.\u0002();
        int num8;
        int num9;
        do
        {
          if (count1 > 0)
          {
            byte[] buffer = new byte[(int) checked ((uint) count1)];
            obj1.Read(buffer, 0, count1);
          }
          \u0003.\u0002.\u0001 obj2;
          if (true)
          {
            int num10 = count2;
            byte[] buffer1;
            while (true)
            {
              if (num10 > 0)
              {
                byte[] buffer2 = new byte[(int) checked ((uint) count2)];
                obj1.Read(buffer2, 0, count2);
              }
              buffer1 = new byte[(int) checked ((uint) unchecked (obj1.Length - obj1.Position))];
              num8 = obj1.Read(buffer1, 0, buffer1.Length);
              num9 = 8;
              if (num9 != 0)
              {
                if (num9 == 0)
                  num10 = num8;
                else
                  break;
              }
              else
                goto label_52;
            }
            obj2 = new \u0003.\u0002.\u0001(buffer1);
          }
          numArray1 = new byte[(int) checked ((uint) length)];
          obj2.\u0002(numArray1, 0, numArray1.Length);
        }
        while (false);
        goto label_48;
label_52:
        num4 = num9;
        num3 = num8;
        goto label_20;
      }
      else
      {
        num2 = num1 >> 24;
        num3 = num1 - (num2 << 24);
      }
label_19:
      num4 = 8223355;
label_20:
      if (num3 != num4)
        throw new FormatException("Unknown Header");
      int length1;
      int num11;
      if (num2 == 1)
      {
        length1 = obj1.\u0003();
        numArray1 = new byte[(int) checked ((uint) length1)];
        num11 = 0;
        goto label_25;
      }
      else
        goto label_26;
label_24:
      int num12;
      byte[] buffer3;
      new \u0003.\u0002.\u0001(buffer3).\u0002(numArray1, num11, num12);
      num11 += num12;
label_25:
      if (num11 < length1)
      {
        int length2 = obj1.\u0003();
        num12 = obj1.\u0003();
        buffer3 = new byte[(int) checked ((uint) length2)];
        obj1.Read(buffer3, 0, buffer3.Length);
        goto label_24;
      }
label_26:
      if (num2 == 2)
      {
        byte[] numArray2 = new byte[8]
        {
          (byte) 237,
          (byte) 86,
          (byte) 22,
          (byte) 215,
          (byte) 95,
          (byte) 47,
          (byte) 235,
          (byte) 111
        };
        byte[] numArray3 = new byte[8]
        {
          (byte) 84,
          (byte) 38,
          (byte) 151,
          (byte) 251,
          (byte) 18,
          (byte) 152,
          (byte) 106,
          (byte) 67
        };
        using (\u0001 obj3 = new \u0001())
        {
          using (ICryptoTransform cryptoTransform = obj3.\u0002(numArray2, numArray3, true))
            numArray1 = \u0003.\u0002.\u0002(cryptoTransform.TransformFinalBlock(obj0, 4, obj0.Length - 4));
        }
      }
      if (num2 == 3)
      {
        byte[] numArray4 = new byte[16]
        {
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1,
          (byte) 1
        };
        byte[] numArray5 = new byte[16]
        {
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2,
          (byte) 2
        };
        using (\u0002.\u0003 obj4 = new \u0002.\u0003())
        {
          ICryptoTransform cryptoTransform = obj4.\u0002(numArray4, numArray5, true);
          try
          {
            numArray1 = \u0003.\u0002.\u0002(cryptoTransform.TransformFinalBlock(obj0, 4, obj0.Length - 4));
          }
          finally
          {
            if (cryptoTransform == null)
              goto label_42;
label_41:
            cryptoTransform.Dispose();
label_42:
            if (false)
              goto label_41;
          }
        }
      }
label_48:
      obj1.Close();
      return numArray1;
label_51:
      int num13 = \u0003.\u0002.\u0002(executingAssembly, assembly) ? 1 : 0;
      if (true)
      {
        if (num13 == 0)
        {
          if (true)
            return (byte[]) null;
          goto label_24;
        }
        else
          goto label_4;
      }
      else
      {
        num3 = num13;
        goto label_19;
      }
    }

    internal sealed class \u0001
    {
      private static readonly int[] \u0001;
      private static readonly int[] \u0002;
      private static readonly int[] \u0003;
      private static readonly int[] \u0004;
      private int \u0001;
      private int \u0002;
      private int \u0003;
      private int \u0004;
      private int \u0005;
      private bool \u0001;
      private \u0003.\u0002.\u0002 \u0001;
      private \u0003.\u0002.\u0003 \u0001;
      private \u0003.\u0002.\u0005 \u0001;
      private \u0003.\u0002.\u0004 \u0001;
      private \u0003.\u0002.\u0004 \u0002;

      public \u0001([In] byte[] obj0)
      {
        this.\u0001 = new \u0003.\u0002.\u0002();
        this.\u0001 = new \u0003.\u0002.\u0003();
        this.\u0001 = 2;
        this.\u0001.\u0002(obj0, 0, obj0.Length);
      }

      private bool \u0002()
      {
        int num1 = this.\u0001.\u0002();
label_30:
        int num2;
        int num3;
        int num4;
        while (true)
        {
          int num5 = num1;
          if (true)
            goto label_31;
label_4:
          if (num5 < 258)
            break;
label_6:
          if (((num2 = this.\u0001.\u0002(this.\u0001)) & -256) != 0)
          {
            if (num2 >= 257)
            {
              this.\u0003 = \u0003.\u0002.\u0001.\u0001[num2 - 257];
              this.\u0002 = \u0003.\u0002.\u0001.\u0002[num2 - 257];
            }
            else
              goto label_8;
          }
          else
          {
            this.\u0001.\u0002(num2);
            num5 = --num1;
            goto label_4;
          }
label_14:
          int num6 = this.\u0002;
label_15:
          if (true)
          {
            if (num6 > 0)
            {
              this.\u0001 = 8;
              int num7 = this.\u0001.\u0002(this.\u0002);
              if (num7 >= 0)
              {
                this.\u0001.\u0002(this.\u0002);
                this.\u0003 += num7;
              }
              else
                goto label_18;
            }
            this.\u0001 = 9;
          }
          else
            goto label_26;
label_21:
          int index1 = this.\u0002.\u0002(this.\u0001);
          if (index1 >= 0)
          {
            this.\u0004 = \u0003.\u0002.\u0001.\u0003[index1];
            this.\u0002 = \u0003.\u0002.\u0001.\u0004[index1];
          }
          else
            goto label_22;
label_24:
          int num8;
          if (this.\u0002 > 0)
          {
            this.\u0001 = 10;
            num8 = this.\u0001.\u0002(this.\u0002);
            num6 = num8;
          }
          else
            goto label_29;
label_26:
          if (num6 >= 0)
          {
            this.\u0001.\u0002(this.\u0002);
            this.\u0004 += num8;
          }
          else
            goto label_27;
label_29:
          this.\u0001.\u0002(this.\u0003, this.\u0004);
          num1 -= this.\u0003;
          this.\u0001 = 7;
          continue;
label_31:
          int num9;
          for (int index2 = 258; num5 >= index2; num5 = num9)
          {
            num9 = this.\u0001;
            if (true)
            {
              int num10 = 7;
              if (num10 != 0)
              {
                switch (num9 - num10)
                {
                  case 0:
                    goto label_6;
                  case 1:
                    goto label_14;
                  case 2:
                    goto label_21;
                  case 3:
                    goto label_24;
                  default:
                    goto label_30;
                }
              }
              else
                index2 = num10;
            }
            else
            {
              num3 = num9;
              goto label_9;
            }
          }
          num4 = 1;
          if (num4 == 0)
          {
            num6 = num4;
            goto label_15;
          }
          else
            goto label_3;
        }
        return true;
label_8:
        num3 = num2;
label_9:
        if (num3 >= 0)
          goto label_11;
label_10:
        return false;
label_11:
        this.\u0002 = (\u0003.\u0002.\u0004) null;
        this.\u0001 = (\u0003.\u0002.\u0004) null;
        this.\u0001 = 2;
        if (true)
          return true;
        goto label_10;
label_18:
        return false;
label_22:
        return false;
label_27:
        return false;
label_3:
        return num4 != 0;
      }

      private bool \u0003()
      {
        int num1 = 4;
        if (num1 != 0)
        {
          if (num1 != 0)
          {
            int num2 = this.\u0001;
            switch (num2)
            {
              case 2:
                goto label_35;
              case 3:
                this.\u0005 = num2 = this.\u0001.\u0002(16);
                break;
              case 4:
label_19:
                if (this.\u0001.\u0002(16) < 0)
                  return false;
                this.\u0001.\u0002(16);
                this.\u0001 = 5;
                goto case 5;
              case 5:
                num1 = this.\u0001.\u0002(this.\u0001, this.\u0005);
                goto label_23;
              case 6:
                if (!this.\u0001.\u0002(this.\u0001))
                  return false;
                this.\u0001 = this.\u0001.\u0002();
                this.\u0002 = this.\u0001.\u0003();
                if (true)
                {
                  this.\u0001 = 7;
                  goto case 7;
                }
                else
                  break;
              case 7:
              case 8:
              case 9:
              case 10:
                return this.\u0002();
              case 12:
                return false;
              default:
                return false;
            }
            if (true)
            {
              if (num2 < 0)
                return false;
              this.\u0001.\u0002(16);
              this.\u0001 = 4;
              goto label_19;
            }
            else
              goto label_24;
          }
          else
            goto label_38;
label_35:
          if (this.\u0001)
          {
            this.\u0001 = 12;
            return false;
          }
label_37:
          int num3 = this.\u0001.\u0002(3);
label_38:
          if (num3 < 0)
            return false;
          this.\u0001.\u0002(3);
          if (true)
          {
            if ((num3 & 1) != 0)
              this.\u0001 = true;
            switch (num3 >> 1)
            {
              case 0:
                this.\u0001.\u0002();
                this.\u0001 = 3;
                goto label_12;
              case 1:
                this.\u0001 = \u0003.\u0002.\u0004.\u0001;
                break;
              case 2:
                this.\u0001 = new \u0003.\u0002.\u0005();
                this.\u0001 = 6;
                goto label_12;
              default:
                goto label_12;
            }
          }
          if (true)
          {
            this.\u0002 = \u0003.\u0002.\u0004.\u0002;
            this.\u0001 = 7;
          }
          else
            goto label_37;
label_12:
          if (true)
            return true;
          goto label_35;
        }
label_23:
        int num4 = num1;
label_24:
        this.\u0005 -= num4;
        if (this.\u0005 != 0)
          return !this.\u0001.\u0002();
        this.\u0001 = 2;
        return true;
      }

      public int \u0002([In] byte[] obj0, [In] int obj1, [In] int obj2)
      {
        int num1 = 3;
        int num2;
        while (true)
        {
          if (num1 != 0)
          {
            num2 = 0;
            goto label_15;
          }
label_6:
          int num3 = num2;
          int num4;
          int num5;
          if (true)
          {
            int num6 = num4;
            num2 = num3 + num6;
            obj2 -= num4;
            num5 = obj2;
          }
          else
            goto label_13;
label_8:
          if (num5 == 0)
            break;
label_10:
          num5 = this.\u0003() ? 1 : 0;
          if (true)
          {
            if (num5 == 0)
              num3 = this.\u0001.\u0003();
            else
              goto label_15;
          }
          else
            goto label_8;
label_13:
          if (num3 <= 0 || this.\u0001 == 11)
            goto label_14;
label_15:
          int num7;
          do
          {
            num7 = this.\u0001;
            if (true)
            {
              if (num7 == 11)
                goto label_10;
            }
            else
              goto label_5;
          }
          while (false);
          goto label_16;
label_5:
          num1 = num7;
          continue;
label_16:
          int num8 = this.\u0001.\u0002(obj0, obj1, obj2);
          if (true)
            num4 = num8;
          obj1 += num4;
          goto label_6;
        }
        return num2;
label_14:
        return num2;
      }

      static \u0001()
      {
        do
        {
          int length1 = 29;
label_1:
          int[] numArray1 = new int[length1];
          // ISSUE: field reference
          RuntimeHelpers.InitializeArray((Array) numArray1, __fieldref (\u0003.\u0003.\u0001));
          \u0003.\u0002.\u0001.\u0001 = numArray1;
          while (true)
          {
            \u0003.\u0002.\u0001.\u0002 = new int[29]
            {
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              0,
              1,
              1,
              1,
              1,
              2,
              2,
              2,
              2,
              3,
              3,
              3,
              3,
              4,
              4,
              4,
              4,
              5,
              5,
              5,
              5,
              0
            };
            if (true)
            {
              if (true)
                \u0003.\u0002.\u0001.\u0003 = new int[30]
                {
                  1,
                  2,
                  3,
                  4,
                  5,
                  7,
                  9,
                  13,
                  17,
                  25,
                  33,
                  49,
                  65,
                  97,
                  129,
                  193,
                  257,
                  385,
                  513,
                  769,
                  1025,
                  1537,
                  2049,
                  3073,
                  4097,
                  6145,
                  8193,
                  12289,
                  16385,
                  24577
                };
              else
                continue;
            }
            int length2 = 30;
            if (length2 == 0)
            {
              length1 = length2;
              goto label_1;
            }
            else
            {
              int[] numArray2 = new int[length2];
              // ISSUE: field reference
              RuntimeHelpers.InitializeArray((Array) numArray2, __fieldref (\u0003.\u0003.\u0001));
              \u0003.\u0002.\u0001.\u0004 = numArray2;
              break;
            }
          }
        }
        while (false);
      }
    }

    internal sealed class \u0002
    {
      private byte[] \u0001;
      private int \u0001 = 0;
      private int \u0002 = 0;
      private uint \u0001 = 0;
      private int \u0003 = 0;

      public int \u0002([In] int obj0)
      {
label_0:
        int num1 = this.\u0003;
        int num2;
        while (true)
        {
          int num3 = obj0;
          if (num1 < num3)
            goto label_14;
label_5:
          long num4 = (long) this.\u0001;
          int num5 = 1;
          int num6 = obj0;
label_6:
          int num7 = 31;
          int num8;
          int num9;
          while (true)
          {
            int num10 = num6 & num7;
            num8 = num5 << num10;
            num9 = 1;
            if (num9 != 0)
            {
              while (true)
              {
                if (true)
                {
                  if (num9 == 0)
                  {
                    num6 = num9;
                    num5 = num8;
                    goto label_6;
                  }
                  else
                    goto label_11;
                }
              }
              num7 = num9;
              num6 = num9;
              num5 = num8;
            }
            else
              break;
          }
label_11:
          long num11 = (long) (num8 - num9);
          num2 = (int) (num4 & num11);
          if (false)
          {
            num1 = num2;
            continue;
          }
          goto label_3;
label_14:
          if (this.\u0001 != this.\u0002)
          {
            \u0003.\u0002.\u0002 obj1 = this;
            int num12 = (int) obj1.\u0001;
            byte[] numArray = this.\u0001;
            \u0003.\u0002.\u0002 obj2 = this;
            int num13;
            int num14 = num13 = obj2.\u0001;
            obj2.\u0001 = num13 + 1;
            int index = num14;
            int num15 = ((int) numArray[index] & (int) byte.MaxValue | ((int) this.\u0001[this.\u0001++] & (int) byte.MaxValue) << 8) << this.\u0003;
            obj1.\u0001 = (uint) (num12 | num15);
            if (true)
            {
              this.\u0003 += 16;
              goto label_5;
            }
            else
              goto label_0;
          }
          else
            break;
        }
        return -1;
label_3:
        return num2;
      }

      public void \u0002([In] int obj0)
      {
label_0:
        this.\u0001 >>= obj0;
label_1:
        if (true)
        {
label_6:
          this.\u0003 -= obj0;
          do
          {
            if (true)
            {
              if (false)
                goto label_1;
            }
            else
              goto label_6;
          }
          while (false);
        }
        else
          goto label_0;
      }

      [SpecialName]
      public int \u0002() => this.\u0003;

      [SpecialName]
      public int \u0003()
      {
        int num1 = this.\u0002;
        int num2;
        while (true)
        {
          int num3 = this.\u0001;
          int num4 = num1 - num3;
          if (true)
          {
            if (false)
            {
              num1 = num4;
            }
            else
            {
              num1 = num4;
              break;
            }
          }
          else
          {
            num2 = num4;
            goto label_5;
          }
        }
        goto label_8;
label_5:
        if (true)
          return num2;
        num1 = num2;
label_8:
        int num5 = this.\u0003 >> 3;
        num2 = num1 + num5;
        goto label_5;
      }

      public void \u0002()
      {
        this.\u0001 >>= this.\u0003 & 7;
        this.\u0003 &= -8;
      }

      [SpecialName]
      public bool \u0002() => this.\u0001 == this.\u0002;

      public int \u0002([In] byte[] obj0, [In] int obj1, [In] int obj2)
      {
        if (true)
          goto label_22;
label_4:
        int num1;
        int num2;
        while (true)
        {
          int num3 = this.\u0003;
          int num4 = 0;
          if (num4 == 0)
            goto label_5;
label_3:
          num1 = num3 + num4;
          continue;
label_5:
          int num5;
          int num6;
          if (num4 == 0)
          {
            if (true)
            {
              if (num3 <= num4 || obj2 <= 0)
              {
                num2 = obj2;
              }
              else
              {
                obj0[obj1++] = (byte) this.\u0001;
                goto label_24;
              }
            }
            else
            {
              num6 = num4;
              num5 = num3;
              goto label_13;
            }
          }
          else
            goto label_21;
label_9:
          int num7;
          if (num2 != 0)
            num7 = this.\u0002;
          else
            break;
label_12:
          int num8 = this.\u0001;
          int num9 = num7 - num8;
          num5 = obj2;
          num6 = num9;
label_13:
          if (num5 > num6)
            obj2 = num9;
          Array.Copy((Array) this.\u0001, this.\u0001, (Array) obj0, obj1, obj2);
          this.\u0001 += obj2;
          if ((this.\u0001 - this.\u0002 & 1) != 0)
          {
            this.\u0001 = (uint) this.\u0001[this.\u0001++] & (uint) byte.MaxValue;
            this.\u0003 = 8;
          }
          if (true)
          {
            if (true)
            {
              int num10 = num1;
              if (false)
              {
                num7 = num10;
                goto label_12;
              }
              else
              {
                num4 = obj2;
                num3 = num10;
              }
            }
            else
              break;
          }
          else
            goto label_24;
label_21:
          num2 = num3 + num4;
          if (false)
            goto label_9;
          else
            goto label_2;
label_24:
          this.\u0001 >>= 8;
          this.\u0003 -= 8;
          obj2--;
          int num11 = num1;
          num4 = 1;
          num3 = num11;
          goto label_3;
        }
        return num1;
label_2:
        return num2;
label_22:
        num1 = 0;
        goto label_4;
      }

      public void \u0002([In] byte[] obj0, [In] int obj1, [In] int obj2)
      {
        if (true)
          goto label_6;
label_4:
        this.\u0003 += 8;
label_5:
        this.\u0001 = obj0;
        this.\u0001 = obj1;
        int num;
        this.\u0002 = num;
        return;
label_6:
        if (this.\u0001 < this.\u0002)
          throw new InvalidOperationException();
        num = obj1 + obj2;
        if (0 > obj1 || obj1 > num || num > obj0.Length)
          throw new ArgumentOutOfRangeException();
        if ((obj2 & 1) != 0)
        {
          this.\u0001 |= (uint) (((int) obj0[obj1++] & (int) byte.MaxValue) << this.\u0003);
          goto label_4;
        }
        else
          goto label_5;
      }
    }

    internal sealed class \u0003
    {
      private byte[] \u0001 = new byte[32768];
      private int \u0001 = 0;
      private int \u0002 = 0;

      public void \u0002([In] int obj0)
      {
        int num1;
        if (true)
        {
          \u0003.\u0002.\u0003 obj = this;
          int num2;
          num1 = num2 = obj.\u0002;
          obj.\u0002 = num2 + 1;
        }
        int num3 = num1;
        if (false)
          goto label_2;
label_1:
        if (num3 != 32768)
        {
          byte[] numArray = this.\u0001;
          \u0003.\u0002.\u0003 obj = this;
          int num4;
          int num5 = num4 = obj.\u0001;
          obj.\u0001 = num4 + 1;
          int index = num5;
          int num6 = (int) (byte) obj0;
          numArray[index] = (byte) num6;
          num3 = -1;
        }
        else
          goto label_7;
label_2:
        if (true)
        {
          if (num3 != 0)
          {
            this.\u0001 &= (int) short.MaxValue;
            return;
          }
        }
        else
          goto label_1;
label_7:
        throw new InvalidOperationException();
      }

      private void \u0002([In] int obj0, [In] int obj1, [In] int obj2)
      {
        int num1 = 0;
        if (num1 == 0)
        {
          if (num1 == 0)
            goto label_5;
        }
        else
          goto label_6;
label_2:
        if (false)
          return;
        byte[] numArray = this.\u0001;
        \u0003.\u0002.\u0003 obj = this;
        int num2;
        int num3 = num2 = obj.\u0001;
        obj.\u0001 = num2 + 1;
        int index = num3;
        int num4 = (int) this.\u0001[obj0++];
        numArray[index] = (byte) num4;
        this.\u0001 &= (int) short.MaxValue;
        goto label_10;
label_5:
        num1 = 0;
label_6:
        int num5;
        int num6;
        if (num1 == 0)
        {
          int num7 = obj1;
          num6 = num7 - 1;
          num5 = num7;
        }
        else
          goto label_10;
label_8:
        obj1 = num6;
        if (num5 <= 0)
          return;
        goto label_2;
label_10:
        num5 = obj0;
        num6 = (int) short.MaxValue;
        if (num6 != 0)
        {
          obj0 = num5 & num6;
          goto label_5;
        }
        else
          goto label_8;
      }

      public void \u0002([In] int obj0, [In] int obj1)
      {
        if ((this.\u0002 += obj0) > 32768)
          throw new InvalidOperationException();
        int sourceIndex = this.\u0001 - obj1 & (int) short.MaxValue;
        int num = 32768 - obj0;
        if (sourceIndex <= num && this.\u0001 < num)
        {
          if (obj0 <= obj1)
          {
            Array.Copy((Array) this.\u0001, sourceIndex, (Array) this.\u0001, this.\u0001, obj0);
            this.\u0001 += obj0;
          }
          else
          {
            while (obj0-- > 0)
              this.\u0001[this.\u0001++] = this.\u0001[sourceIndex++];
          }
        }
        else
          this.\u0002(sourceIndex, obj0, obj1);
      }

      public int \u0002([In] \u0003.\u0002.\u0002 obj0, [In] int obj1)
      {
        int val1_1 = obj1;
        int val1_2;
        int val2_1;
        if (true)
        {
          int val2_2 = 32768;
          if (val2_2 != 0)
            val2_2 -= this.\u0002;
          int num = Math.Min(val1_1, val2_2);
          val2_1 = obj0.\u0003();
          val1_2 = num;
        }
        else
          goto label_16;
label_15:
        int num1 = Math.Min(val1_2, val2_1);
        if (true)
        {
          obj1 = num1;
          val1_1 = 32768;
        }
        else
          val1_1 = num1;
label_16:
        int num2 = this.\u0001;
        int num3;
        while (true)
        {
          int num4 = val1_1 - num2;
          int num5;
          int num6;
          do
          {
            val1_2 = obj1;
            val2_1 = num4;
            if (true)
            {
              if (val1_2 > val2_1)
              {
                num3 = obj0.\u0002(this.\u0001, this.\u0001, num4);
                num5 = num3;
                num6 = num4;
                if (true)
                {
                  if (num5 == num6)
                    num3 += obj0.\u0002(this.\u0001, 0, obj1 - num4);
                }
                else
                  goto label_2;
              }
              else
                num3 = obj0.\u0002(this.\u0001, this.\u0001, obj1);
              this.\u0001 = this.\u0001 + num3 & (int) short.MaxValue;
            }
            else
              goto label_15;
          }
          while (false);
          break;
label_2:
          num2 = num6;
          val1_1 = num5;
        }
        this.\u0002 += num3;
        return num3;
      }

      public int \u0002() => 32768 - this.\u0002;

      public int \u0003() => this.\u0002;

      public int \u0002([In] byte[] obj0, [In] int obj1, [In] int obj2)
      {
        int num1 = this.\u0001;
        int num2 = obj2;
        int num3;
        while (true)
        {
          int num4 = this.\u0002;
          if (num2 <= num4)
            goto label_18;
          else
            goto label_17;
label_3:
          int num5;
          int num6;
          if (num6 == 0)
          {
            num2 = num5;
            continue;
          }
label_4:
          num1 = num5 & (int) short.MaxValue;
label_5:
          num3 = obj2;
          num5 = obj2;
          num6 = 0;
          int num7;
          int num8;
          if (num6 == 0)
          {
            int length;
            if (num6 == 0)
            {
              if (num6 == 0)
              {
                int num9 = num1;
                length = num5 - num9;
                int num10 = length;
                num6 = 0;
                num5 = num10;
              }
              else
                goto label_4;
            }
            if (num5 > num6)
            {
              Array.Copy((Array) this.\u0001, 32768 - length, (Array) obj0, obj1, length);
              int num11 = obj1;
              num8 = length;
              num7 = num11;
            }
            else
              goto label_12;
          }
          else
            goto label_3;
label_11:
          obj1 = num7 + num8;
          obj2 = num1;
label_12:
          Array.Copy((Array) this.\u0001, num1 - obj2, (Array) obj0, obj1, obj2);
          this.\u0002 -= num3;
          if (this.\u0002 >= 0)
          {
            if (false)
              goto label_5;
            else
              goto label_15;
          }
          else
            break;
label_17:
          obj2 = this.\u0002;
          goto label_5;
label_18:
          num7 = this.\u0001 - this.\u0002;
          num8 = obj2;
          if (true)
          {
            int num12 = num7 + num8;
            num6 = 8;
            num5 = num12;
            goto label_3;
          }
          else
            goto label_11;
        }
        throw new InvalidOperationException();
label_15:
        return num3;
      }
    }

    internal sealed class \u0004
    {
      private short[] \u0001;
      public static readonly \u0003.\u0002.\u0004 \u0001;
      public static readonly \u0003.\u0002.\u0004 \u0002;

      static \u0004()
      {
label_0:
        byte[] numArray = new byte[288];
        int num = 0;
        if (false)
          goto label_6;
        else
          goto label_16;
label_4:
        while (num < 280)
          numArray[num++] = (byte) 7;
        goto label_8;
label_6:
        if (true)
          numArray[num++] = (byte) 8;
        else
          goto label_13;
label_8:
        if (num >= 288)
        {
          if (true)
          {
            \u0003.\u0002.\u0004.\u0001 = new \u0003.\u0002.\u0004(numArray);
            numArray = new byte[32];
            num = 0;
            while (num < 32)
              numArray[num++] = (byte) 5;
          }
          else
            goto label_0;
        }
        else
          goto label_6;
label_13:
        if (false)
          goto label_4;
label_14:
        \u0003.\u0002.\u0004.\u0002 = new \u0003.\u0002.\u0004(numArray);
        if (true)
          return;
        goto label_13;
label_16:
        while (num < 144)
          numArray[num++] = (byte) 8;
        for (; num < 256; numArray[num++] = (byte) 9)
        {
          if (false)
            goto label_14;
        }
        goto label_4;
      }

      public \u0004([In] byte[] obj0) => this.\u0002(obj0);

      private void \u0002([In] byte[] obj0)
      {
        int[] numArray1 = new int[16];
label_1:
        int[] numArray2 = new int[16];
        for (int index1 = 0; index1 < obj0.Length; ++index1)
        {
          int num1 = (int) obj0[index1];
          int num2;
          if (true)
            num2 = num1;
          if (num2 <= 0)
            continue;
          int[] numArray3;
          int index2;
          int num3 = (numArray3 = numArray1)[(IntPtr) (index2 = num2)] + 1;
          numArray3[index2] = num3;
        }
        int num4 = 0;
        int length = 512;
        for (int index = 1; index <= 15; ++index)
        {
          numArray2[index] = num4;
          num4 += numArray1[index] << 16 - index;
          if (index >= 10)
          {
            int num5 = numArray2[index] & 130944;
            if (true)
            {
              if (true)
              {
                int num6 = num4 & 130944;
                if (true)
                  length += num6 - num5 >> 16 - index;
                else
                  goto label_1;
              }
              else
                goto label_17;
            }
            else
              goto label_27;
          }
        }
        this.\u0001 = new short[(int) checked ((uint) length)];
        int num7 = 512;
        int num8 = 15;
label_13:
        int index3 = num8;
        goto label_23;
label_15:
        int num9 = numArray1[index3] << 16 - index3;
        int num10;
        num8 = num10 - num9;
        int num11;
        if (true)
        {
          num4 = num8;
          num11 = num4 & 130944;
        }
        else
          goto label_13;
label_17:
        int num12;
        for (int index4 = num11; index4 < num12; index4 = num10 + 128)
        {
          if (true)
          {
            this.\u0001[(int) \u0003.\u0002.\u0006.\u0002(index4)] = (short) (-num7 << 4 | index3);
            num7 += 1 << index3 - 9;
            num10 = index4;
            if (false)
              goto label_15;
          }
          else
            goto label_17;
        }
        --index3;
label_23:
        if (index3 >= 10)
        {
          num12 = num4 & 130944;
          num10 = num4;
          goto label_15;
        }
label_24:
        int index5 = 0;
        goto label_36;
label_27:
        int index6;
        int index7;
        int num13;
        int num14;
        if (true)
        {
          if (index6 <= 9)
          {
            do
            {
              this.\u0001[index7] = (short) (index5 << 4 | index6);
              index7 += 1 << index6;
            }
            while (index7 < 512);
          }
          else
          {
            int num15 = (int) this.\u0001[index7 & 511];
            int num16 = 1;
            int num17 = num15 & 15;
            if (true)
            {
              int num18 = num17 & 31;
              int num19 = num16 << num18;
              int num20 = -(num15 >> 4);
              do
              {
                this.\u0001[num20 | index7 >> 9] = (short) (index5 << 4 | index6);
                index7 += 1 << index6;
              }
              while (index7 < num19);
            }
            else
            {
              num14 = num17;
              num13 = num16;
              goto label_37;
            }
          }
          numArray2[index6] = num4 + (1 << 16 - index6);
        }
        else
          goto label_24;
label_35:
        ++index5;
label_36:
        num13 = index5;
        num14 = obj0.Length;
label_37:
        if (num13 >= num14)
          return;
        index6 = (int) obj0[index5];
        if (index6 != 0)
        {
          num4 = numArray2[index6];
          index7 = (int) \u0003.\u0002.\u0006.\u0002(num4);
          goto label_27;
        }
        else
          goto label_35;
      }

      public int \u0002([In] \u0003.\u0002.\u0002 obj0)
      {
        int num1 = obj0.\u0002(9);
        int num2;
        int num3;
        int num4;
        int num5;
        int num6;
        int num7;
        int num8;
        while (true)
        {
          int index = num1;
          if (num1 < 0)
            goto label_20;
          else
            goto label_25;
label_3:
          int num9;
          if (num5 < 0)
          {
            num9 = -(num2 >> 4);
            int num10 = num2 & 15;
            num5 = obj0.\u0002(num10);
          }
          else
          {
            obj0.\u0002(num2 & 15);
            num7 = num2;
            if (false)
            {
              num5 = num7;
              goto label_12;
            }
            else
              break;
          }
label_8:
          if (true)
          {
            if (true)
              num6 = num5;
            else
              goto label_18;
          }
          else
            goto label_3;
label_11:
          index = num6;
label_12:
          if (true)
          {
            if (num5 >= 0)
            {
              num3 = (int) this.\u0001[num9 | index >> 9];
              if (false)
                goto label_20;
              else
                goto label_15;
            }
            else
            {
              int num11 = obj0.\u0002();
              int num12 = obj0.\u0002(num11);
              int num13 = (int) this.\u0001[num9 | num12 >> 9];
              if ((num13 & 15) <= num11)
              {
                obj0.\u0002(num13 & 15);
                num5 = num13;
              }
              else
                goto label_19;
            }
          }
          else
            goto label_8;
label_18:
          num8 = num5 >> 4;
          if (false)
          {
            num1 = num8;
            continue;
          }
          goto label_5;
label_20:
          num4 = obj0.\u0002();
          num2 = (int) this.\u0001[obj0.\u0002(num4)];
          if (num2 >= 0)
          {
            num5 = num2;
            num6 = 15;
            if (num6 == 0)
              goto label_11;
            else
              goto label_22;
          }
          else
            goto label_24;
label_25:
          num5 = num2 = (int) this.\u0001[index];
          goto label_3;
        }
        return num7 >> 4;
label_15:
        obj0.\u0002(num3 & 15);
        return num3 >> 4;
label_5:
        return num8;
label_19:
        return -1;
label_22:
        if ((num5 & num6) <= num4)
        {
          obj0.\u0002(num2 & 15);
          return num2 >> 4;
        }
label_24:
        return -1;
      }
    }

    internal sealed class \u0005
    {
      private static readonly int[] \u0001;
      private static readonly int[] \u0002;
      private byte[] \u0001;
      private byte[] \u0002;
      private \u0003.\u0002.\u0004 \u0001;
      private int \u0001;
      private int \u0002;
      private int \u0003;
      private int \u0004;
      private int \u0005;
      private int \u0006;
      private byte \u0001;
      private int \u0007;
      private static readonly int[] \u0003;

      public bool \u0002([In] \u0003.\u0002.\u0002 obj0)
      {
        while (true)
        {
          switch (this.\u0001)
          {
            case 0:
              this.\u0002 = obj0.\u0002(5);
              if (this.\u0002 >= 0)
              {
                this.\u0002 += 257;
                obj0.\u0002(5);
                this.\u0001 = 1;
                goto case 1;
              }
              else
                goto label_1;
            case 1:
              this.\u0003 = obj0.\u0002(5);
              if (this.\u0003 >= 0)
              {
                ++this.\u0003;
                obj0.\u0002(5);
                this.\u0005 = this.\u0002 + this.\u0003;
                this.\u0002 = new byte[(int) checked ((uint) this.\u0005)];
                this.\u0001 = 2;
                goto case 2;
              }
              else
                goto label_3;
            case 2:
              this.\u0004 = obj0.\u0002(4);
              if (this.\u0004 >= 0)
              {
                this.\u0004 += 4;
                obj0.\u0002(4);
                this.\u0001 = new byte[19];
                this.\u0007 = 0;
                this.\u0001 = 3;
                goto case 3;
              }
              else
                goto label_6;
            case 3:
              for (; this.\u0007 < this.\u0004; ++this.\u0007)
              {
                int num = obj0.\u0002(3);
                if (num < 0)
                  return false;
                obj0.\u0002(3);
                this.\u0001[\u0003.\u0002.\u0005.\u0003[this.\u0007]] = (byte) num;
              }
              this.\u0001 = new \u0003.\u0002.\u0004(this.\u0001);
              this.\u0001 = (byte[]) null;
              this.\u0007 = 0;
              this.\u0001 = 4;
              goto case 4;
            case 4:
              int num1;
              while (((num1 = this.\u0001.\u0002(obj0)) & -16) == 0)
              {
                this.\u0002[this.\u0007++] = this.\u0001 = (byte) num1;
                if (this.\u0007 == this.\u0005)
                  return true;
              }
              if (num1 >= 0)
              {
                if (num1 >= 17)
                  this.\u0001 = (byte) 0;
                this.\u0006 = num1 - 16;
                this.\u0001 = 5;
                goto case 5;
              }
              else
                goto label_17;
            case 5:
              int num2 = \u0003.\u0002.\u0005.\u0002[this.\u0006];
              int num3 = obj0.\u0002(num2);
              if (num3 >= 0)
              {
                obj0.\u0002(num2);
                int num4 = num3 + \u0003.\u0002.\u0005.\u0001[this.\u0006];
                while (num4-- > 0)
                  this.\u0002[this.\u0007++] = this.\u0001;
                if (this.\u0007 != this.\u0005)
                {
                  this.\u0001 = 4;
                  continue;
                }
                goto label_27;
              }
              else
                goto label_22;
            default:
              continue;
          }
        }
label_1:
        return false;
label_3:
        return false;
label_6:
        return false;
label_17:
        return false;
label_22:
        return false;
label_27:
        return true;
      }

      public \u0003.\u0002.\u0004 \u0002()
      {
        byte[] destinationArray = new byte[(int) checked ((uint) this.\u0002)];
        Array.Copy((Array) this.\u0002, 0, (Array) destinationArray, 0, this.\u0002);
        return new \u0003.\u0002.\u0004(destinationArray);
      }

      public \u0003.\u0002.\u0004 \u0003()
      {
        int num = this.\u0003;
        int length;
        while (true)
        {
          length = (int) checked ((uint) num);
          if (false)
            num = length;
          else
            break;
        }
        byte[] destinationArray = new byte[length];
        if (true)
          Array.Copy((Array) this.\u0002, this.\u0002, (Array) destinationArray, 0, this.\u0003);
        return new \u0003.\u0002.\u0004(destinationArray);
      }

      static \u0005()
      {
        int length = 3;
        if (length != 0)
        {
          int[] numArray = new int[length];
          // ISSUE: field reference
          RuntimeHelpers.InitializeArray((Array) numArray, __fieldref (\u0003.\u0003.\u0001));
          \u0003.\u0002.\u0005.\u0001 = numArray;
        }
        else
          goto label_4;
label_2:
        do
        {
          \u0003.\u0002.\u0005.\u0002 = new int[3]
          {
            2,
            3,
            7
          };
        }
        while (false);
        length = 19;
label_4:
        int[] numArray1 = new int[length];
        // ISSUE: field reference
        RuntimeHelpers.InitializeArray((Array) numArray1, __fieldref (\u0003.\u0003.\u0001));
        \u0003.\u0002.\u0005.\u0003 = numArray1;
        if (false)
          goto label_2;
      }
    }

    internal sealed class \u0006
    {
      private static readonly int[] \u0001;
      private static readonly byte[] \u0001;
      private static readonly short[] \u0001;
      private static readonly byte[] \u0002;
      private static readonly short[] \u0002;
      private static readonly byte[] \u0003;

      public static short \u0002([In] int obj0) => (short) ((int) \u0003.\u0002.\u0006.\u0001[obj0 & 15] << 12 | (int) \u0003.\u0002.\u0006.\u0001[obj0 >> 4 & 15] << 8 | (int) \u0003.\u0002.\u0006.\u0001[obj0 >> 8 & 15] << 4 | (int) \u0003.\u0002.\u0006.\u0001[obj0 >> 12]);

      static \u0006()
      {
label_0:
        \u0003.\u0002.\u0006.\u0001 = new int[19]
        {
          16,
          17,
          18,
          0,
          8,
          7,
          9,
          6,
          10,
          5,
          11,
          4,
          12,
          3,
          13,
          2,
          14,
          1,
          15
        };
        int length1;
        if (true)
        {
          \u0003.\u0002.\u0006.\u0001 = new byte[16]
          {
            (byte) 0,
            (byte) 8,
            (byte) 4,
            (byte) 12,
            (byte) 2,
            (byte) 10,
            (byte) 6,
            (byte) 14,
            (byte) 1,
            (byte) 9,
            (byte) 5,
            (byte) 13,
            (byte) 3,
            (byte) 11,
            (byte) 7,
            (byte) 15
          };
          \u0003.\u0002.\u0006.\u0001 = new short[286];
          \u0003.\u0002.\u0006.\u0002 = new byte[286];
          if (true)
          {
            length1 = 0;
            goto label_23;
          }
        }
        else
          goto label_15;
label_7:
        int index;
        int num1;
        while (true)
        {
          num1 = index;
          if (true)
          {
            if (num1 < 256)
            {
              \u0003.\u0002.\u0006.\u0001[index] = \u0003.\u0002.\u0006.\u0002(256 + index << 7);
              \u0003.\u0002.\u0006.\u0002[index++] = (byte) 9;
            }
            else
              break;
          }
          else
            goto label_12;
        }
label_11:
        num1 = index;
label_12:
        if (num1 < 280)
        {
          \u0003.\u0002.\u0006.\u0001[index] = \u0003.\u0002.\u0006.\u0002(index - 256 << 9);
          if (true)
          {
            \u0003.\u0002.\u0006.\u0002[index++] = (byte) 7;
            goto label_11;
          }
          else
            goto label_0;
        }
label_15:
        for (; index < 286; \u0003.\u0002.\u0006.\u0002[index++] = (byte) 8)
          \u0003.\u0002.\u0006.\u0001[index] = \u0003.\u0002.\u0006.\u0002(index - 88 << 8);
        int length2 = 30;
label_17:
        if (length2 != 0)
        {
          \u0003.\u0002.\u0006.\u0002 = new short[length2];
          length1 = 30;
          if (length1 != 0)
          {
            \u0003.\u0002.\u0006.\u0003 = new byte[length1];
            index = 0;
          }
          else
            goto label_23;
        }
        else
          goto label_22;
label_21:
        length2 = index;
label_22:
        if (length2 >= 30)
          return;
        \u0003.\u0002.\u0006.\u0002[index] = \u0003.\u0002.\u0006.\u0002(index << 11);
        \u0003.\u0002.\u0006.\u0003[index] = (byte) 5;
        ++index;
        goto label_21;
label_23:
        index = length1;
        int num2;
        int num3;
        while (true)
        {
          num2 = index;
          num3 = 144;
          if (num3 != 0)
          {
            if (num2 < num3)
            {
              \u0003.\u0002.\u0006.\u0001[index] = \u0003.\u0002.\u0006.\u0002(48 + index << 8);
              \u0003.\u0002.\u0006.\u0002[index++] = (byte) 8;
            }
            else
              goto label_7;
          }
          else
            break;
        }
        length2 = num3;
        length2 = num2;
        goto label_17;
      }
    }

    internal sealed class \u0007 : MemoryStream
    {
      public int \u0002() => this.ReadByte() | this.ReadByte() << 8;

      public int \u0003() => this.\u0002() | this.\u0002() << 16;

      public \u0007([In] byte[] obj0)
        : base(obj0, false)
      {
      }
    }
  }
}