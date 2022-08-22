﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.InfoCards.InfocardExtendedInformationEntry
// Assembly: infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 516D8B44-4448-4D2C-8B8E-FFBB3FFE472B
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00000-msil\Virus.Win32.Expiro.w-69bb73081eac86b8cf86f45e33515d0095855636967076e2b593d7a30cd80a07.exe

using Microsoft.InfoCards.Diagnostics;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.InfoCards
{
  internal class InfocardExtendedInformationEntry : IXmlSerializable
  {
    private string m_xmlElement;

    public void Serialize(BinaryWriter writer) => Utility.SerializeString(writer, this.m_xmlElement);

    public void Deserialize(BinaryReader reader) => this.m_xmlElement = Utility.DeserializeString(reader);

    public string GetXml() => this.m_xmlElement;

    public System.Xml.Schema.XmlSchema GetSchema() => (System.Xml.Schema.XmlSchema) null;

    public void WriteXml(XmlWriter writer)
    {
      if (writer == null)
        throw InfoCardTrace.ThrowHelperArgumentNull(nameof (writer));
      XmlReader reader = InfoCardSchemas.CreateReader(this.m_xmlElement);
      writer.WriteNode(reader, false);
    }

    public void ReadXml(XmlReader reader)
    {
      XmlReader xmlReader = reader.IsStartElement() ? reader.ReadSubtree() : throw InfoCardTrace.ThrowHelperError((Exception) new InvalidCardException(SR.GetString("UnexpectedElement")));
      xmlReader.Read();
      this.m_xmlElement = xmlReader.ReadOuterXml();
      xmlReader.Close();
    }
  }
}