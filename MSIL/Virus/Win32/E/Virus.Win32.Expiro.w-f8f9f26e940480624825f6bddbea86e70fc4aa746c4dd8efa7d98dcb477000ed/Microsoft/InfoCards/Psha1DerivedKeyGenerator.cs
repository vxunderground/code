﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.Psha1DerivedKeyGenerator
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 1D4D5564-A025-490C-AF1D-DF4FBB709D1F
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Expiro.w-f8f9f26e940480624825f6bddbea86e70fc4aa746c4dd8efa7d98dcb477000ed.exe

using Microsoft.InfoCards.Diagnostics;
using System;
using System.Security.Cryptography;

namespace Microsoft.InfoCards
{
  internal sealed class Psha1DerivedKeyGenerator
  {
    private byte[] key;

    public Psha1DerivedKeyGenerator(byte[] key) => this.key = key != null ? key : throw InfoCardTrace.ThrowHelperArgumentNull(nameof (key));

    public byte[] GenerateDerivedKey(byte[] label, byte[] nonce, int derivedKeySize, int position)
    {
      if (label == null)
        throw InfoCardTrace.ThrowHelperArgumentNull(nameof (label));
      if (nonce == null)
        throw InfoCardTrace.ThrowHelperArgumentNull(nameof (nonce));
      return new Psha1DerivedKeyGenerator.ManagedPsha1(this.key, label, nonce).GetDerivedKey(derivedKeySize, position);
    }

    private sealed class ManagedPsha1
    {
      private byte[] aValue;
      private byte[] buffer;
      private byte[] chunk;
      private KeyedHashAlgorithm hmac;
      private int index;
      private int position;
      private byte[] secret;
      private byte[] seed;

      public ManagedPsha1(byte[] secret, byte[] label, byte[] seed)
      {
        this.secret = secret;
        this.seed = new byte[checked (label.Length + seed.Length)];
        label.CopyTo((Array) this.seed, 0);
        seed.CopyTo((Array) this.seed, label.Length);
        this.aValue = this.seed;
        this.chunk = new byte[0];
        this.index = 0;
        this.position = 0;
        this.hmac = (KeyedHashAlgorithm) new HMACSHA1(secret, true);
        this.buffer = new byte[checked (unchecked (this.hmac.HashSize / 8) + this.seed.Length)];
      }

      public byte[] GetDerivedKey(int derivedKeySize, int position)
      {
        if (derivedKeySize < 0)
          throw InfoCardTrace.ThrowHelperError((Exception) new ArgumentOutOfRangeException(nameof (derivedKeySize), SR.GetString("ValueMustBeNonNegative")));
        if (this.position > position)
          throw InfoCardTrace.ThrowHelperError((Exception) new ArgumentOutOfRangeException(nameof (position), SR.GetString("ValueMustBeInRange", (object) 0, (object) this.position)));
        while (this.position < position)
        {
          int num = (int) this.GetByte();
        }
        int length = derivedKeySize / 8;
        byte[] derivedKey = new byte[length];
        for (int index = 0; index < length; ++index)
          derivedKey[index] = this.GetByte();
        return derivedKey;
      }

      private byte GetByte()
      {
        if (this.index >= this.chunk.Length)
        {
          this.hmac.Initialize();
          this.aValue = this.hmac.ComputeHash(this.aValue);
          this.aValue.CopyTo((Array) this.buffer, 0);
          this.seed.CopyTo((Array) this.buffer, this.aValue.Length);
          this.hmac.Initialize();
          this.chunk = this.hmac.ComputeHash(this.buffer);
          this.index = 0;
        }
        ++this.position;
        return this.chunk[this.index++];
      }
    }
  }
}