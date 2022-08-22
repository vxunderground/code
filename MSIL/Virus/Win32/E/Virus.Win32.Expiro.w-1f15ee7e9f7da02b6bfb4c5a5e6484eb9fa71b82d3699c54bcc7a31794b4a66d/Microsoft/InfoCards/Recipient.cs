﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.Recipient
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: ADE0A079-11DB-4A46-8BDE-D2A592CA8DEA
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Virus.Win32.Expiro.w-1f15ee7e9f7da02b6bfb4c5a5e6484eb9fa71b82d3699c54bcc7a31794b4a66d.exe

using Microsoft.InfoCards.Diagnostics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.InfoCards
{
  internal class Recipient
  {
    private const int InvalidRow = 0;
    private const byte Version = 1;
    private const byte m_marker = 29;
    public const int CERT_NAME_ATTR_TYPE = 3;
    public const string szOID_SUBJECT_CN = "2.5.4.3";
    public const string szOID_ORGANIZATION_NAME = "2.5.4.10";
    public const string szOID_LOCALITY_NAME = "2.5.4.7";
    public const string szOID_STATE_OR_PROVINCE_NAME = "2.5.4.8";
    public const string szOID_COUNTRY_NAME = "2.5.4.6";
    private const int attributeMaxLength = 1024;
    private static readonly Recipient.RecipientAttribute CNAttr = new Recipient.RecipientAttribute("2.5.4.3", "CN");
    private static readonly Recipient.RecipientAttribute OrgAttr = new Recipient.RecipientAttribute("2.5.4.10", "O");
    private static readonly Recipient.RecipientAttribute LocalityAttr = new Recipient.RecipientAttribute("2.5.4.7", "L");
    private static readonly Recipient.RecipientAttribute StateOrProvinceAttr = new Recipient.RecipientAttribute("2.5.4.8", "S");
    private static readonly Recipient.RecipientAttribute CountryAttr = new Recipient.RecipientAttribute("2.5.4.6", "C");
    private string m_recipientId;
    private string m_recipientOrganizationId;
    private string m_issuerName;
    private string m_subjectName;
    private uint m_privacyNoticeVersion;
    private Recipient.IdentityType m_type;
    private Recipient.TrustDecision m_trustDecision;
    private Recipient.RecipientCertParameters m_recipientParams = new Recipient.RecipientCertParameters("", "", "", "", "", Utility.SubjectAtrributeHAFlags.NotEnabled);
    private bool m_isCertCached;
    private int m_rowId;
    private byte[] m_publicKey;
    private List<X509Logo> m_logoMetadata;

    public Recipient(Stream stream)
      : this(stream, false)
    {
    }

    public Recipient(Stream stream, RecipientIdentity identity, bool isCertCached)
      : this(stream, isCertCached)
    {
      if (!(identity is X509RecipientIdentity recipientIdentity))
        return;
      this.m_type = Recipient.IdentityType.X509;
      this.AddLogoMetadata(recipientIdentity.LeafCertificate);
      this.m_recipientParams = recipientIdentity.RecipientParams;
    }

    private Recipient(Stream stream, bool isCertCached)
    {
      this.m_isCertCached = isCertCached;
      this.Deserialize(stream);
    }

    public Recipient(RecipientIdentity identity, bool isCertCached, uint privacyNoticeVersion)
    {
      this.m_trustDecision = Recipient.TrustDecision.NoTrustDecision;
      this.m_isCertCached = isCertCached;
      this.m_privacyNoticeVersion = privacyNoticeVersion;
      this.m_recipientId = identity.GetIdentifier();
      this.m_recipientOrganizationId = identity.GetOrganizationIdentifier();
      this.m_subjectName = identity.GetName();
      if (!(identity is X509RecipientIdentity recipientIdentity))
        return;
      this.m_type = Recipient.IdentityType.X509;
      this.m_issuerName = recipientIdentity.LeafCertificate.GetNameInfo(X509NameType.SimpleName, true);
      this.m_recipientParams = recipientIdentity.RecipientParams;
      this.m_publicKey = recipientIdentity.LeafCertificate.GetPublicKey();
      this.AddLogoMetadata(recipientIdentity.LeafCertificate);
    }

    public Recipient(
      X509Certificate2 cert,
      string recipientId,
      string recipientOrgId,
      bool isCertCached,
      uint privacyNoticeVersion,
      Recipient.RecipientCertParameters recipientParameters)
    {
      this.m_type = Recipient.IdentityType.X509;
      this.m_trustDecision = Recipient.TrustDecision.NoTrustDecision;
      this.m_publicKey = cert.GetPublicKey();
      this.m_isCertCached = isCertCached;
      this.m_privacyNoticeVersion = privacyNoticeVersion;
      this.m_subjectName = cert.FriendlyName;
      if (string.IsNullOrEmpty(this.m_subjectName))
        this.m_subjectName = cert.GetNameInfo(X509NameType.SimpleName, false);
      this.m_issuerName = cert.GetNameInfo(X509NameType.SimpleName, true);
      this.m_recipientId = recipientId;
      this.m_recipientOrganizationId = recipientOrgId;
      this.m_recipientParams = recipientParameters;
      this.AddLogoMetadata(cert);
    }

    public string RecipientId
    {
      get
      {
        InfoCardTrace.Assert(!string.IsNullOrEmpty(this.m_recipientId), "Must be populated before this property is accessed");
        return this.m_recipientId;
      }
    }

    public Recipient.RecipientCertParameters RecipientParameters => this.m_recipientParams;

    public uint PrivacyPolicyVersion
    {
      get => this.m_privacyNoticeVersion;
      set => this.m_privacyNoticeVersion = value;
    }

    private static byte[] CertGetRecipientIdBytesForChainTrust(
      X509Certificate2 recipientCert,
      X509Certificate2Collection supportingRecipientCerts,
      Recipient.IdType idtype,
      out Recipient.RecipientCertParameters recipientParams)
    {
      recipientParams = new Recipient.RecipientCertParameters("", "", "", "", "", Utility.SubjectAtrributeHAFlags.NotEnabled);
      string str1 = "";
      string certAttribute1 = Recipient.GetCertAttribute(Recipient.OrgAttr.Name, recipientCert.Handle);
      string certAttribute2 = Recipient.GetCertAttribute(Recipient.LocalityAttr.Name, recipientCert.Handle);
      string certAttribute3 = Recipient.GetCertAttribute(Recipient.StateOrProvinceAttr.Name, recipientCert.Handle);
      string certAttribute4 = Recipient.GetCertAttribute(Recipient.CountryAttr.Name, recipientCert.Handle);
      recipientParams.m_cn = Recipient.GetCertAttribute(Recipient.CNAttr.Name, recipientCert.Handle);
      recipientParams.m_organization = certAttribute1;
      recipientParams.m_locality = certAttribute2;
      recipientParams.m_state = certAttribute3;
      recipientParams.m_country = certAttribute4;
      if (string.IsNullOrEmpty(certAttribute1))
      {
        if (string.IsNullOrEmpty(recipientParams.m_cn))
          return recipientCert.GetPublicKey();
        return Encoding.Unicode.GetBytes(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "|{0}=\"{1}\"|", new object[2]
        {
          (object) Recipient.CNAttr.DelimitingString,
          (object) recipientParams.m_cn
        }));
      }
      string str2;
      if (Recipient.IdType.OrganizationId == idtype || Recipient.IdType.PPIDSeed == idtype)
        str2 = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "|{0}=\"{1}\"|{2}=\"{3}\"|{4}=\"{5}\"|{6}=\"{7}\"|", (object) Recipient.OrgAttr.DelimitingString, (object) certAttribute1, (object) Recipient.LocalityAttr.DelimitingString, (object) certAttribute2, (object) Recipient.StateOrProvinceAttr.DelimitingString, (object) certAttribute3, (object) Recipient.CountryAttr.DelimitingString, (object) certAttribute4);
      else
        str2 = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "|{0}=\"{1}\"|{2}=\"{3}\"|{4}=\"{5}\"|{6}=\"{7}\"|{8}=\"{9}\"|", (object) Recipient.CNAttr.DelimitingString, (object) recipientParams.m_cn, (object) Recipient.OrgAttr.DelimitingString, (object) certAttribute1, (object) Recipient.LocalityAttr.DelimitingString, (object) certAttribute2, (object) Recipient.StateOrProvinceAttr.DelimitingString, (object) certAttribute3, (object) Recipient.CountryAttr.DelimitingString, (object) certAttribute4);
      Utility.SubjectAtrributeHAFlags certFlags = Utility.SubjectAtrributeHAFlags.NotEnabled;
      string s;
      if (Utility.GetCertHAFlags(recipientCert, supportingRecipientCerts, ref certFlags))
      {
        recipientParams.m_certHAFlags = certFlags;
        int num = Utility.IsSubjectAtrributeHAFlagsSet(certFlags, Utility.SubjectAtrributeHAFlags.LocStateCountryHA) ^ Utility.IsSubjectAtrributeHAFlagsSet(certFlags, Utility.SubjectAtrributeHAFlags.OrganizationHA) ? 1 : 0;
        s = str2;
        if (string.IsNullOrEmpty(s))
          throw InfoCardTrace.ThrowHelperError((Exception) new UntrustedRecipientException(SR.GetString("InvalidHACertificateStructure")));
      }
      else
      {
        X509Chain chain;
        try
        {
          InfoCardX509Validator.ValidateChain(recipientCert, supportingRecipientCerts, out chain);
        }
        catch (SecurityTokenValidationException ex)
        {
          throw InfoCardTrace.ThrowHelperError((Exception) new UntrustedRecipientException(SR.GetString("UnableToBuildChainForNonHARecipient"), (Exception) ex));
        }
        if (Recipient.IdType.OrganizationId == idtype)
          str1 = "|Non-EV";
        if (idtype == Recipient.IdType.RecipientId)
        {
          for (int index = 1; index < chain.ChainElements.Count; ++index)
            str1 = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "|ChainElement=\"{0}\"{1}", new object[2]
            {
              (object) chain.ChainElements[index].Certificate.Subject,
              (object) str1
            });
        }
        s = str1 + str2;
      }
      return Encoding.Unicode.GetBytes(s);
    }

    public static string CertGetRecipientOrganizationPPIDSeedHash(
      X509Certificate2 recipientCert,
      X509Certificate2Collection supportingRecipientCerts,
      bool isChainTrusted)
    {
      byte[] buffer = isChainTrusted ? Recipient.CertGetRecipientIdBytesForChainTrust(recipientCert, supportingRecipientCerts, Recipient.IdType.PPIDSeed, out Recipient.RecipientCertParameters _) : recipientCert.GetPublicKey();
      byte[] hash;
      using (SHA256 shA256 = (SHA256) new SHA256Managed())
        hash = shA256.ComputeHash(buffer);
      return Convert.ToBase64String(hash);
    }

    public static string CertGetRecipientOrganizationIdHash(
      X509Certificate2 recipientCert,
      X509Certificate2Collection supportingRecipientCerts,
      bool isChainTrusted)
    {
      byte[] buffer = isChainTrusted ? Recipient.CertGetRecipientIdBytesForChainTrust(recipientCert, supportingRecipientCerts, Recipient.IdType.OrganizationId, out Recipient.RecipientCertParameters _) : recipientCert.GetPublicKey();
      byte[] hash;
      using (SHA256 shA256 = (SHA256) new SHA256Managed())
        hash = shA256.ComputeHash(buffer);
      return Convert.ToBase64String(hash);
    }

    public static string CertGetRecipientIdHash(
      X509Certificate2 recipientCert,
      X509Certificate2Collection supportingRecipientCerts,
      bool isChainTrusted,
      out Recipient.RecipientCertParameters recipientParams)
    {
      byte[] buffer;
      if (!isChainTrusted)
      {
        buffer = recipientCert.GetPublicKey();
        recipientParams = new Recipient.RecipientCertParameters(Recipient.GetCertAttribute(Recipient.CNAttr.Name, recipientCert.Handle), Recipient.GetCertAttribute(Recipient.OrgAttr.Name, recipientCert.Handle), Recipient.GetCertAttribute(Recipient.LocalityAttr.Name, recipientCert.Handle), Recipient.GetCertAttribute(Recipient.StateOrProvinceAttr.Name, recipientCert.Handle), Recipient.GetCertAttribute(Recipient.CountryAttr.Name, recipientCert.Handle), Utility.SubjectAtrributeHAFlags.NotEnabled);
      }
      else
        buffer = Recipient.CertGetRecipientIdBytesForChainTrust(recipientCert, supportingRecipientCerts, Recipient.IdType.RecipientId, out recipientParams);
      byte[] hash;
      using (SHA256 shA256 = (SHA256) new SHA256Managed())
        hash = shA256.ComputeHash(buffer);
      return Convert.ToBase64String(hash);
    }

    private static string GetCertAttribute(string geographicAttributeName, IntPtr certHandle)
    {
      StringBuilder pszNameString = new StringBuilder(1024);
      NativeMethods.CertGetNameString(certHandle, 3, 0, geographicAttributeName, pszNameString, 1024);
      return pszNameString.ToString();
    }

    public Recipient.TrustDecision Trust
    {
      set => this.m_trustDecision = value;
      get => this.m_trustDecision;
    }

    private void ThrowIfNotComplete()
    {
      bool flag = this.m_recipientId != null && null != this.m_subjectName;
      if (Recipient.IdentityType.X509 == this.m_type)
        flag = flag && this.m_issuerName != null && !Utility.ArrayIsNullOrEmpty((Array) this.m_publicKey);
      if (!flag)
        throw InfoCardTrace.ThrowHelperError((Exception) new SerializationIncompleteException(this.GetType()));
    }

    private void AddLogoMetadata(X509Certificate2 cert)
    {
      X509LogoTypeExtension logoTypeExtension = X509LogoTypeExtension.FromCertificate(cert);
      if (logoTypeExtension == null)
        return;
      logoTypeExtension.TryDecodeExtension();
      this.m_logoMetadata = logoTypeExtension.Logos;
    }

    public void Serialize(BinaryWriter writer) => this.AgentSerialize(writer);

    public void AgentSerialize(BinaryWriter writer)
    {
      this.ThrowIfNotComplete();
      writer.Write((byte) 1);
      writer.Write((byte) this.m_type);
      writer.Write(this.m_isCertCached);
      writer.Write((uint) this.m_recipientParams.m_certHAFlags);
      Utility.SerializeString(writer, this.m_recipientParams.m_cn);
      Utility.SerializeString(writer, this.m_recipientParams.m_organization);
      Utility.SerializeString(writer, this.m_recipientParams.m_locality);
      Utility.SerializeString(writer, this.m_recipientParams.m_state);
      Utility.SerializeString(writer, this.m_recipientParams.m_country);
      Utility.SerializeString(writer, this.m_recipientId);
      Utility.SerializeString(writer, this.m_recipientOrganizationId);
      Utility.SerializeString(writer, this.m_issuerName);
      Utility.SerializeString(writer, this.m_subjectName);
      writer.Write(this.m_privacyNoticeVersion);
      Utility.SerializeBytes(writer, this.m_publicKey);
      writer.Write((byte) this.m_trustDecision);
      if (this.m_logoMetadata == null)
      {
        writer.Write(0);
      }
      else
      {
        writer.Write(this.m_logoMetadata.Count);
        foreach (X509Logo x509Logo in this.m_logoMetadata)
          x509Logo.Serialize(writer);
      }
      writer.Write((byte) 29);
    }

    public void SerializeToStore(BinaryWriter writer)
    {
      this.ThrowIfNotComplete();
      writer.Write((byte) 1);
      writer.Write((uint) this.m_recipientParams.m_certHAFlags);
      Utility.SerializeString(writer, this.m_recipientParams.m_cn);
      Utility.SerializeString(writer, this.m_recipientParams.m_organization);
      Utility.SerializeString(writer, this.m_recipientParams.m_locality);
      Utility.SerializeString(writer, this.m_recipientParams.m_state);
      Utility.SerializeString(writer, this.m_recipientParams.m_country);
      Utility.SerializeString(writer, this.m_recipientId);
      Utility.SerializeString(writer, this.m_recipientOrganizationId);
      Utility.SerializeString(writer, this.m_issuerName);
      Utility.SerializeString(writer, this.m_subjectName);
      writer.Write(this.m_privacyNoticeVersion);
      Utility.SerializeBytes(writer, this.m_publicKey);
      writer.Write((byte) this.m_trustDecision);
      writer.Write((byte) 29);
    }

    public void Deserialize(Stream stream)
    {
      BinaryReader reader = (BinaryReader) new InfoCardBinaryReader(stream, Encoding.Unicode);
      if ((byte) 1 != reader.ReadByte())
        InfoCardTrace.Assert(false, "version mismatch deserializing recipient stream");
      this.m_recipientParams = new Recipient.RecipientCertParameters();
      this.m_recipientParams.m_certHAFlags = (Utility.SubjectAtrributeHAFlags) reader.ReadUInt32();
      this.m_recipientParams.m_cn = Utility.DeserializeString(reader);
      this.m_recipientParams.m_organization = Utility.DeserializeString(reader);
      this.m_recipientParams.m_locality = Utility.DeserializeString(reader);
      this.m_recipientParams.m_state = Utility.DeserializeString(reader);
      this.m_recipientParams.m_country = Utility.DeserializeString(reader);
      this.m_recipientId = Utility.DeserializeString(reader);
      this.m_recipientOrganizationId = Utility.DeserializeString(reader);
      this.m_issuerName = Utility.DeserializeString(reader);
      this.m_subjectName = Utility.DeserializeString(reader);
      this.m_privacyNoticeVersion = reader.ReadUInt32();
      this.m_publicKey = reader.ReadBytes(reader.ReadInt32());
      this.m_type = this.m_publicKey.Length != 0 ? Recipient.IdentityType.X509 : Recipient.IdentityType.DNS;
      this.m_trustDecision = (Recipient.TrustDecision) reader.ReadByte();
      if ((byte) 29 != reader.ReadByte())
        InfoCardTrace.Assert(false, "Invalid stream detected deserilizing recipient");
      this.ThrowIfNotComplete();
    }

    public void Save(StoreConnection con)
    {
      DataRow row = this.TryGetRow(con, QueryDetails.FullHeader);
      if (row == null)
      {
        row = new DataRow();
        row.ObjectType = -3;
        row.GlobalId = (GlobalId) Guid.NewGuid();
      }
      row.SetIndexValue("ix_name", (object) this.m_recipientId);
      MemoryStream output = new MemoryStream();
      this.SerializeToStore(new BinaryWriter((Stream) output, Encoding.Unicode));
      row.SetDataField(output.ToArray());
      con.Save(row);
      this.m_rowId = row.LocalId;
    }

    public override string ToString() => base.ToString();

    public bool IsOrganizationVerified()
    {
      Utility.SubjectAtrributeHAFlags atrributeHaFlags = Utility.SubjectAtrributeHAFlags.Enabled | Utility.SubjectAtrributeHAFlags.OrganizationHA;
      return (this.m_recipientParams.m_certHAFlags & atrributeHaFlags) == atrributeHaFlags;
    }

    protected DataRow TryGetRow(StoreConnection con, QueryDetails details) => con.GetSingleRow(QueryDetails.FullHeader, new QueryParameter("ix_objecttype", new object[1]
    {
      (object) -3
    }), new QueryParameter("ix_name", new object[1]
    {
      (object) this.m_recipientId
    }));

    public enum TrustDecision : byte
    {
      NoTrustDecision,
      IsTrusted,
      IsNotTrusted,
      PolicyVersionChange,
    }

    public enum IdentityType : byte
    {
      DNS,
      X509,
    }

    private enum IdType : byte
    {
      RecipientId,
      OrganizationId,
      PPIDSeed,
    }

    public struct RecipientCertParameters
    {
      public string m_cn;
      public string m_organization;
      public string m_locality;
      public string m_state;
      public string m_country;
      public Utility.SubjectAtrributeHAFlags m_certHAFlags;

      public RecipientCertParameters(
        string cn,
        string organization,
        string locality,
        string state,
        string country,
        Utility.SubjectAtrributeHAFlags certHAFlags)
      {
        this.m_cn = cn;
        this.m_organization = organization;
        this.m_locality = locality;
        this.m_state = state;
        this.m_country = country;
        this.m_certHAFlags = certHAFlags;
      }
    }

    private struct RecipientAttribute
    {
      private string m_name;
      private string m_delimitingString;

      public RecipientAttribute(string name, string delimitingString)
      {
        this.m_name = name;
        this.m_delimitingString = delimitingString;
      }

      public string DelimitingString => this.m_delimitingString;

      public string Name => this.m_name;
    }
  }
}