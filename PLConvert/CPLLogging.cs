// Decompiled with JetBrains decompiler
// Type: PLConvert.CPLLogging
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.IO;

namespace PLConvert
{
  public class CPLLogging
  {
    private StreamWriter m_Writer;
    private bool bFirstWriteDone;

    public CPLLogging()
    {
      string path1 = Path.GetTempPath() + "PLConvLog";
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      DateTime now = DateTime.Now;
      string path2 = path1 + "\\PLQB" + now.ToString("MMdd") + ".log";
      this.bFirstWriteDone = File.Exists(path2);
      this.m_Writer = new StreamWriter(path2, true);
    }

    public void AddException(Exception objErr)
    {
      this.AddException(objErr, "");
    }

    public void AddException(Exception objErr, string sInfo)
    {
      Exception exception = objErr;
      string sText = "Exception";
      string str = "  ";
      if (!sInfo.Equals(""))
        sText = sText + " - " + sInfo;
      this.AddString(sText);
      this.AddString(str + exception.Message, true);
      while (true)
      {
        Exception innerException = exception.InnerException;
        exception = innerException;
        if (innerException != null)
        {
          str += "  ";
          this.AddString(str + exception.Message, true);
        }
        else
          break;
      }
    }

    public void AddString(string sText)
    {
      this.AddString(sText, false);
    }

    public void AddString(string sText, bool bSupressDate)
    {
      string str = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss - ");
      if (bSupressDate)
      {
        for (int index = 0; index < str.Length; ++index)
          this.m_Writer.Write(" ");
      }
      else
      {
        if (this.bFirstWriteDone)
          this.m_Writer.WriteLine();
        this.bFirstWriteDone = true;
        this.m_Writer.Write(str);
      }
      this.m_Writer.WriteLine(sText);
      this.m_Writer.Flush();
    }

    public void Close()
    {
      this.m_Writer.Flush();
      this.m_Writer.Close();
    }
  }
}
