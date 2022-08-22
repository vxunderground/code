﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.UIAgentAsyncEndRequest
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 1D4D5564-A025-490C-AF1D-DF4FBB709D1F
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Expiro.w-f8f9f26e940480624825f6bddbea86e70fc4aa746c4dd8efa7d98dcb477000ed.exe

using Microsoft.InfoCards.Diagnostics;
using System;
using System.IO;
using System.Text;

namespace Microsoft.InfoCards
{
  internal abstract class UIAgentAsyncEndRequest : UIAgentRequest
  {
    private int m_asyncHandle;
    private bool m_isCompleted;
    private object m_result;
    private bool m_isCancelled;

    public UIAgentAsyncEndRequest(
      IntPtr rpcHandle,
      Stream inArgs,
      Stream outArgs,
      ClientUIRequest parent)
      : base(rpcHandle, inArgs, outArgs, parent)
    {
    }

    public object Result
    {
      get
      {
        InfoCardTrace.Assert(this.m_isCompleted, "Attempt to pick up async result before completion.");
        return this.m_result;
      }
    }

    public bool IsCancelled
    {
      get
      {
        InfoCardTrace.Assert(this.m_isCompleted, "Attempt to pick up async result before completion.");
        return this.m_isCancelled;
      }
    }

    protected override void OnMarshalInArgs()
    {
      this.m_asyncHandle = new InfoCardBinaryReader(this.InArgs, Encoding.Unicode).ReadInt32();
      InfoCardTrace.Assert(0 != this.m_asyncHandle, "null async handle");
    }

    protected override void OnProcess()
    {
      using (RpcAsyncResult rpcAsyncResult = this.ParentRequest.WaitForAsyncCompletion(this.m_asyncHandle))
      {
        this.m_isCancelled = rpcAsyncResult.IsCanceled;
        if (!this.m_isCancelled)
          this.m_result = rpcAsyncResult.Result;
      }
      this.m_isCompleted = true;
    }

    protected override sealed void OnMarshalOutArgs()
    {
      BinaryWriter writer = new BinaryWriter(this.OutArgs, Encoding.Unicode);
      writer.Write(this.IsCancelled);
      if (this.IsCancelled)
        return;
      this.OnMarshalAsyncOutArgs(writer);
    }

    protected virtual void OnMarshalAsyncOutArgs(BinaryWriter writer)
    {
    }
  }
}