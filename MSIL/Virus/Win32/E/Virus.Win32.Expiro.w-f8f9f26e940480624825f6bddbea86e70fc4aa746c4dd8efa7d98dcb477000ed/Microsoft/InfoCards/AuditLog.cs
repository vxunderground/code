﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.AuditLog
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 1D4D5564-A025-490C-AF1D-DF4FBB709D1F
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Expiro.w-f8f9f26e940480624825f6bddbea86e70fc4aa746c4dd8efa7d98dcb477000ed.exe

using Microsoft.InfoCards.Diagnostics;

namespace Microsoft.InfoCards
{
  internal static class AuditLog
  {
    public static void AuditCardWritten() => InfoCardTrace.Audit(EventCode.AUDIT_CARD_WRITTEN);

    public static void AuditCardDeletion() => InfoCardTrace.Audit(EventCode.AUDIT_CARD_DELETE);

    public static void AuditCardImport() => InfoCardTrace.Audit(EventCode.AUDIT_CARD_IMPORT);

    public static void AuditStoreImport() => InfoCardTrace.Audit(EventCode.AUDIT_STORE_IMPORT);

    public static void AuditStoreExport() => InfoCardTrace.Audit(EventCode.AUDIT_STORE_EXPORT);

    public static void AuditStoreDeletion() => InfoCardTrace.Audit(EventCode.AUDIT_STORE_DELETE);
  }
}