// Decompiled with JetBrains decompiler
// Type: PLConvert.PLLink
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using PLXMLLnkLib;
using System;
using System.Windows.Forms;

namespace PLConvert
{
  public class PLLink
  {
    public static PCLawATLClass m_PLConnect;

    public static bool LinkFailed { get; set; }

    static PLLink()
    {
      try
      {
        PLLink.m_PLConnect = new PCLawATLClass();
      }
      catch (Exception ex)
      {
        string message = ex.Message;
        int num = (int) MessageBox.Show("Failed to Link to PCLaw");
      }
      if (PLLink.m_PLConnect.SetCompanyInfo("DI20050428-55935-99480", "CNV") != 0)
        throw new Exception(string.Format("Unable to access PCLaw.\nEither the correct password was not entered into the Link Login Screen, or PCLaw has not been run since an update was installed.\nRun PCLaw and try again."));
      PLLink.m_PLConnect.RecordIndexerCommand("disable");
    }

    public static PCLawATLClass GetLink()
    {
      if (PLLink.m_PLConnect == null)
      {
        PLLink.m_PLConnect = new PCLawATLClass();
        if (!PLLink.m_PLConnect.SetCompanyInfo("DI20050428-55935-99480", "CNV").Equals(0))
        {
          PLLink.LinkFailed = true;
        }
        else
        {
          PLLink.LinkFailed = false;
          PLLink.m_PLConnect.RecordIndexerCommand("disable");
        }
      }
      return PLLink.m_PLConnect;
    }

    public static void ResetLogFile()
    {
      PLLink.m_PLConnect.LinkLog_CloseLog();
      PLLink.m_PLConnect.LinkLog_Reset();
    }

    public static void ResetPCLawDefaults()
    {
      PLLink.m_PLConnect.ResetPCLawDefaults();
    }

    public static void ShowLogFile()
    {
      PLLink.m_PLConnect.LinkLog_Show();
    }
  }
}
