// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGBTranObj
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

namespace PLConvert
{
  public class PLGBTranObj
  {
    private int m_nTransactionDate;
    private int m_nMatterID;
    private string m_sRcvdFrom;
    private string m_sRcptNum;
    private string m_sExpl;
    private int m_nBankAcctID;
    private int m_nInvID;
    private int m_nInvNum;
    private int m_nInvDate;
    private double m_dAmount;
    private PLGBEnt.eGBEntryType m_eEntryType;

    public double Amount
    {
      get
      {
        return this.m_dAmount;
      }
      set
      {
        this.m_dAmount = value;
      }
    }

    public int BankAcctID
    {
      get
      {
        return this.m_nBankAcctID;
      }
      set
      {
        this.m_nBankAcctID = value;
      }
    }

    public PLGBEnt.eGBEntryType EntryType
    {
      get
      {
        return this.m_eEntryType;
      }
      set
      {
        this.m_eEntryType = value;
      }
    }

    public string Expl
    {
      get
      {
        return this.m_sExpl;
      }
      set
      {
        this.m_sExpl = value;
      }
    }

    public int InvDate
    {
      get
      {
        return this.m_nInvDate;
      }
      set
      {
        this.m_nInvDate = value;
      }
    }

    public int InvID
    {
      get
      {
        return this.m_nInvID;
      }
      set
      {
        this.m_nInvID = value;
      }
    }

    public int InvNum
    {
      get
      {
        return this.m_nInvNum;
      }
      set
      {
        this.m_nInvNum = value;
      }
    }

    public int MatterID
    {
      get
      {
        return this.m_nMatterID;
      }
      set
      {
        this.m_nMatterID = value;
      }
    }

    public string RcptNum
    {
      get
      {
        return this.m_sRcptNum;
      }
      set
      {
        this.m_sRcptNum = value;
      }
    }

    public string RcvdFrom
    {
      get
      {
        return this.m_sRcvdFrom;
      }
      set
      {
        this.m_sRcvdFrom = value;
      }
    }

    public int TransactionDate
    {
      get
      {
        return this.m_nTransactionDate;
      }
      set
      {
        this.m_nTransactionDate = value;
      }
    }

    public PLGBTranObj()
    {
      this.m_nTransactionDate = 19820101;
      this.m_nMatterID = 0;
      this.m_sRcvdFrom = "";
      this.m_sRcptNum = "";
      this.m_sExpl = "";
      this.m_nBankAcctID = 0;
      this.m_nInvID = 0;
      this.m_nInvNum = 0;
      this.m_nInvDate = 0;
      this.m_dAmount = 0.0;
      this.m_eEntryType = (PLGBEnt.eGBEntryType) 0;
    }

    public PLGBTranObj(int nDate, int nMatterID, string sRcvdFrom, string sRcptNum, string sExpl, int nBankID, double dAmt, PLGBEnt.eGBEntryType eEntryType, int nInvID, int nInvNum, int nInvDate)
    {
      this.m_nTransactionDate = nDate;
      this.m_nMatterID = nMatterID;
      this.m_sRcvdFrom = sRcvdFrom;
      this.m_sRcptNum = sRcptNum;
      this.m_sExpl = sExpl;
      this.m_nBankAcctID = nBankID;
      this.m_nInvID = nInvID;
      this.m_nInvNum = nInvNum;
      this.m_nInvDate = nInvDate;
      this.m_dAmount = dAmt;
      this.m_eEntryType = eEntryType;
    }
  }
}
