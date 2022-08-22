﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.HashCoreRequest
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: ADE0A079-11DB-4A46-8BDE-D2A592CA8DEA
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Expiro.w-1f15ee7e9f7da02b6bfb4c5a5e6484eb9fa71b82d3699c54bcc7a31794b4a66d.exe

using Microsoft.InfoCards.Diagnostics;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

namespace Microsoft.InfoCards
{
  internal class HashCoreRequest : ClientRequest
  {
    private int m_cryptoSession;
    private byte[] m_inBlock;

    public HashCoreRequest(
      Process callingProcess,
      WindowsIdentity callingIdentity,
      IntPtr rpcHandle,
      Stream inArgs,
      Stream outArgs)
      : base(callingProcess, callingIdentity, rpcHandle, inArgs, outArgs)
    {
    }

    protected override void OnMarshalInArgs()
    {
      BinaryReader binaryReader = (BinaryReader) new InfoCardBinaryReader(this.InArgs);
      this.m_cryptoSession = binaryReader.ReadInt32();
      int count = binaryReader.ReadInt32();
      this.m_inBlock = binaryReader.ReadBytes(count);
      InfoCardTrace.ThrowInvalidArgumentConditional(0 == this.m_cryptoSession, "cryptoSession");
    }

    protected override void OnProcess()
    {
      try
      {
        ((HashCryptoSession) CryptoSession.Find(this.m_cryptoSession, this.CallerPid, this.RequestorIdentity.User)).HashCore(this.m_inBlock);
      }
      finally
      {
        Array.Clear((Array) this.m_inBlock, 0, this.m_inBlock.Length);
      }
    }

    protected override void OnMarshalOutArgs()
    {
    }
  }
}