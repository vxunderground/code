﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.RecipientIdentity
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: ADE0A079-11DB-4A46-8BDE-D2A592CA8DEA
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00000-msil\Virus.Win32.Expiro.w-67b630ead60119692b9abbdfd8717c96904ef041127c2cae033c86b718eaa61e.exe

using Microsoft.InfoCards.Diagnostics;
using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace Microsoft.InfoCards
{
  internal class RecipientIdentity
  {
    private EndpointAddress m_address;
    private string m_identifier = string.Empty;
    private string m_organizationIdentifier = string.Empty;
    private string m_organizationPPIDIdentifier = string.Empty;
    private bool m_hasBeenValidated;

    public static RecipientIdentity CreateIdentity(
      EndpointAddress epr,
      bool validate)
    {
      if (epr.Identity is X509CertificateEndpointIdentity)
      {
        if (((X509CertificateEndpointIdentity) epr.Identity).Certificates == null || ((X509CertificateEndpointIdentity) epr.Identity).Certificates.Count < 1)
          throw InfoCardTrace.ThrowHelperError((Exception) new PolicyValidationException());
        RecipientIdentity identity = (RecipientIdentity) new X509RecipientIdentity(epr, ((X509CertificateEndpointIdentity) epr.Identity).Certificates);
        if (validate)
          identity.Validate();
        return identity;
      }
      RecipientIdentity identity1 = epr.Identity == null ? new RecipientIdentity(epr) : throw InfoCardTrace.ThrowHelperError((Exception) new IdentityValidationException(SR.GetString("UnsupportedIdentityType")));
      if (validate)
        identity1.Validate();
      return identity1;
    }

    public RecipientIdentity(EndpointAddress epr) => this.m_address = epr;

    public EndpointAddress Address => this.m_address;

    protected bool HasBeenValidated
    {
      set => this.m_hasBeenValidated = value;
      get => this.m_hasBeenValidated;
    }

    protected string Identifier
    {
      set => this.m_identifier = value;
    }

    protected string OrganizationIdentifier
    {
      set => this.m_organizationIdentifier = value;
    }

    protected string OrganizationPPIDIdentifier
    {
      set => this.m_organizationPPIDIdentifier = value;
    }

    public virtual void Validate()
    {
      if (this.m_hasBeenValidated)
        return;
      using (SHA256 shA256 = (SHA256) new SHA256Managed())
      {
        this.m_identifier = Convert.ToBase64String(shA256.ComputeHash(Encoding.Unicode.GetBytes(this.m_address.Uri.Host)));
        this.m_organizationIdentifier = this.m_identifier;
        this.m_organizationPPIDIdentifier = this.m_identifier;
      }
      this.m_hasBeenValidated = true;
    }

    public virtual string GetIdentifier()
    {
      InfoCardTrace.Assert(this.HasBeenValidated, "Identity has not been validated");
      return this.m_identifier;
    }

    public virtual string GetOrganizationIdentifier()
    {
      InfoCardTrace.Assert(this.HasBeenValidated, "Identity has not been validated");
      return this.m_organizationIdentifier;
    }

    public virtual string GetOrganizationPPIDIdentifier()
    {
      InfoCardTrace.Assert(this.HasBeenValidated, "Identity has not been validated");
      return this.m_organizationPPIDIdentifier;
    }

    public virtual string GetName() => this.m_address.Uri.Host;
  }
}