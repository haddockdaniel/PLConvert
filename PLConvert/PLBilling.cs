// Decompiled with JetBrains decompiler
// Type: PLConvert.PLBilling
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PLConvert
{
  public class PLBilling : TransactionData
  {
    private Dictionary<int, PLGBTranObj> m_htExpEntries = new Dictionary<int, PLGBTranObj>();
    private Dictionary<int, PLGBTranObj> m_htDisbEntries = new Dictionary<int, PLGBTranObj>();
    private int nSends = 0;
    private int nAdds = 0;
    public static bool m_bAllowEntOnClosedMtr = false;
    public bool bAutoCreateCharges;
    private CPostItem m_MatterID;
    private CPostItem m_CollLawyerID;
    private CPostItem m_TypeOfLawID;
    private CPostItem m_DepartmentID;
    private CPostItem m_InvID;
    private CPostItem m_InvoiceNumber;
    private CPostItem m_Date;
    private CPostItem m_InterestRate;
    private CPostItem m_EntryType;
    private CPostItem m_CutoffDate;
    private CPostItem m_Fees;
    private CPostItem m_Hours;
    private CPostItem m_Disbs;
    private CPostItem m_GSTFees;
    private CPostItem m_GSTDisbs;
    private CPostItem m_PSTFees;
    private CPostItem m_PSTDisbs;
    private CPostItem m_SoftCosts;
    public string idCascade;
    private Dictionary<int, PLARLawyerAlloc> m_htAlloc;
    public PLARLawyerAlloc Alloc;
    private static Dictionary<int, int> m_cMapInvIDtoMattID;
    private static Dictionary<string, int> m_cMapExtID1toInvID;
    private static Dictionary<string, int> m_cMapExtID2toInvDate;
    private static Dictionary<string, int> m_cMapExtID2toInvNum;
    private static Dictionary<string, int> m_cMapExtID2toInvID;
    private static Dictionary<int, string> m_MapIDtoQuickBooksID;
    private StreamWriter writerA;
    private StreamWriter writerS;

    public int CollLawyerID
    {
      get
      {
        return this.m_CollLawyerID.nValue;
      }
      set
      {
        this.m_CollLawyerID.SetValue(value);
      }
    }

    public string CollLawyerNN
    {
      get
      {
        return PLLawyer.GetNNFromID(this.m_CollLawyerID.nValue);
      }
      set
      {
        this.m_CollLawyerID.SetValue(PLLawyer.GetIDFromNN(value));
      }
    }

    public int Date
    {
      get
      {
        return this.m_Date.nValue;
      }
      set
      {
        this.m_Date.SetValue(value);
      }
    }

    public int DepartmentID
    {
      get
      {
        return this.m_DepartmentID.nValue;
      }
      set
      {
        this.m_DepartmentID.SetValue(value);
      }
    }

    public string DepartmentNN
    {
      get
      {
        return PLDepartment.GetNNFromID(this.m_DepartmentID.nValue);
      }
      set
      {
        this.m_DepartmentID.SetValue(PLDepartment.GetIDFromNN(value));
      }
    }

    public double Disbs
    {
      get
      {
        return this.m_Disbs.dValue;
      }
      set
      {
        this.m_Disbs.SetValue(value);
      }
    }

    public double Fees
    {
      get
      {
        return this.m_Fees.dValue;
      }
      set
      {
        this.m_Fees.SetValue(value);
      }
    }

    public double GSTDisbs
    {
      get
      {
        return this.m_GSTDisbs.dValue;
      }
      set
      {
        this.m_GSTDisbs.SetValue(value);
      }
    }

    public double GSTFees
    {
      get
      {
        return this.m_GSTFees.dValue;
      }
      set
      {
        this.m_GSTFees.SetValue(value);
      }
    }

    public double Hours
    {
      get
      {
        return this.m_Hours.dValue;
      }
      set
      {
        this.m_Hours.SetValue(value);
      }
    }

    public double InterestRate
    {
      get
      {
        return this.m_InterestRate.dValue;
      }
      set
      {
        this.m_InterestRate.SetValue(value);
      }
    }

    public int InvID
    {
      get
      {
        return this.m_InvID.nValue;
      }
      set
      {
        this.m_InvID.SetValue(value);
      }
    }

    public int InvoiceNumber
    {
      get
      {
        return this.m_InvoiceNumber.nValue;
      }
      set
      {
        this.m_InvoiceNumber.SetValue(value);
      }
    }

    public int MatterID
    {
      get
      {
        return this.m_MatterID.nValue;
      }
      set
      {
        this.m_MatterID.SetValue(value);
      }
    }

    public string MatterNN
    {
      get
      {
        return PLMatter.GetNNFromID(this.m_MatterID.nValue);
      }
      set
      {
        this.m_MatterID.SetValue(PLMatter.GetIDFromNN(value));
      }
    }

    public double PSTDisbs
    {
      get
      {
        return this.m_PSTDisbs.dValue;
      }
      set
      {
        this.m_PSTDisbs.SetValue(value);
      }
    }

    public double PSTFees
    {
      get
      {
        return this.m_PSTFees.dValue;
      }
      set
      {
        this.m_PSTFees.SetValue(value);
      }
    }

    public int Seconds
    {
      get
      {
        return (int) (this.m_Hours.dValue * 3600.0);
      }
      set
      {
        this.m_Hours.SetValue((double) value / 3600.0);
      }
    }

    public double SoftCosts
    {
      get
      {
        return this.m_SoftCosts.dValue;
      }
      set
      {
        this.m_SoftCosts.SetValue(value);
      }
    }

    public int TypeOfLawID
    {
      get
      {
        return this.m_TypeOfLawID.nValue;
      }
      set
      {
        this.m_TypeOfLawID.SetValue(value);
      }
    }

    public string TypeOfLawNN
    {
      get
      {
        return PLTypeOfLaw.GetNNFromID(this.m_TypeOfLawID.nValue);
      }
      set
      {
        this.m_TypeOfLawID.SetValue(PLTypeOfLaw.GetIDFromNN(value));
      }
    }

    public PLBilling()
    {
      this.Initialize();
    }

    public void AddAllocation()
    {
      if (!this.m_htAlloc.ContainsKey(this.Alloc.LawyerID))
      {
        PLARLawyerAlloc plarLawyerAlloc = new PLARLawyerAlloc()
        {
          LawyerID = this.Alloc.LawyerID,
          GLID = this.Alloc.GLID,
          Seconds = this.Alloc.Seconds,
          Amount = this.Alloc.Amount
        };
        this.m_htAlloc.Add(plarLawyerAlloc.LawyerID, plarLawyerAlloc);
      }
      else
      {
        PLARLawyerAlloc plarLawyerAlloc1 = this.m_htAlloc[this.Alloc.LawyerID];
        plarLawyerAlloc1.Seconds = plarLawyerAlloc1.Seconds + this.Alloc.Seconds;
        PLARLawyerAlloc plarLawyerAlloc2 = this.m_htAlloc[this.Alloc.LawyerID];
        plarLawyerAlloc2.Amount = plarLawyerAlloc2.Amount + this.Alloc.Amount;
      }
      this.Alloc.Clear();
    }

    public static void AddMapExtID1toInvID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLBilling.m_cMapExtID1toInvID == null)
        PLBilling.m_cMapExtID1toInvID = new Dictionary<string, int>();
      if (!PLBilling.m_cMapExtID1toInvID.ContainsKey(Key))
        PLBilling.m_cMapExtID1toInvID.Add(Key, Value);
    }

    public static void AddMapExtID2toInvDate(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLBilling.m_cMapExtID2toInvDate == null)
        PLBilling.m_cMapExtID2toInvDate = new Dictionary<string, int>();
      if (!PLBilling.m_cMapExtID2toInvDate.ContainsKey(Key))
        PLBilling.m_cMapExtID2toInvDate.Add(Key, Value);
    }

    public static void AddMapExtID2toInvID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLBilling.m_cMapExtID2toInvID == null)
        PLBilling.m_cMapExtID2toInvID = new Dictionary<string, int>();
      if (!PLBilling.m_cMapExtID2toInvID.ContainsKey(Key))
        PLBilling.m_cMapExtID2toInvID.Add(Key, Value);
    }

    public static void AddMapExtID2toInvNum(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLBilling.m_cMapExtID2toInvNum == null)
        PLBilling.m_cMapExtID2toInvNum = new Dictionary<string, int>();
      if (!PLBilling.m_cMapExtID2toInvNum.ContainsKey(Key))
        PLBilling.m_cMapExtID2toInvNum.Add(Key, Value);
    }

    public static void AddMapIDtoQuickBooksID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLBilling.m_MapIDtoQuickBooksID == null)
        PLBilling.m_MapIDtoQuickBooksID = new Dictionary<int, string>();
      if (!PLBilling.m_MapIDtoQuickBooksID.ContainsKey(Key))
        PLBilling.m_MapIDtoQuickBooksID.Add(Key, Value);
    }

    public static void AddMapInvIDtoMattID(int Key, int Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLBilling.m_cMapInvIDtoMattID == null)
        PLBilling.m_cMapInvIDtoMattID = new Dictionary<int, int>();
      if (!PLBilling.m_cMapInvIDtoMattID.ContainsKey(Key))
        PLBilling.m_cMapInvIDtoMattID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      int nInvID = 0;
      int nInvNum = 0;
      int nInvDate = 0;
      bool autoCreateCharges = this.bAutoCreateCharges;
      this.bAutoCreateCharges = true;
      this.AddRecord(ref nInvID, ref nInvNum, ref nInvDate);
      this.bAutoCreateCharges = autoCreateCharges;
    }

    public void AddRecord(ref int nInvID, ref int nInvNum, ref int nInvDate)
    {
      KeyValuePair<int, PLARLawyerAlloc> keyValuePair1 = new KeyValuePair<int, PLARLawyerAlloc>();
      if ((int) this.m_hndPOST == 0)
      {
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
        this.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", PLBilling.m_bAllowEntOnClosedMtr ? "1" : "0");
      }
      int matterId = this.MatterID;
      double disbs = this.Disbs;
      double softCosts = this.SoftCosts;
      int date = this.Date;
      Dictionary<int, PLARLawyerAlloc> dictionary = new Dictionary<int, PLARLawyerAlloc>();
      string path1 = Path.GetTempPath() + "PCLAWLOG";
      if (!Directory.Exists(path1))
        Directory.CreateDirectory(path1);
      string path2 = path1 + "\\AddRec.txt";
      if (this.writerA == null)
        this.writerA = new StreamWriter(path2);
      PLBilling plBilling1 = this;
      plBilling1.nAdds = plBilling1.nAdds + 1;
      this.writerA.Write(this.nAdds.ToString("000") + ".  " + DateTime.Now.ToString() + "     ");
      this.writerA.Flush();
      try
      {
        this.m_EntryType.SetValue(3073);
        this.m_CutoffDate.SetValue(this.Date);
        this.m_ID.AddField(this.m_hndPOST);
        this.m_Status.AddField(this.m_hndPOST);
        this.m_MatterID.AddField(this.m_hndPOST);
        this.m_CollLawyerID.AddField(this.m_hndPOST);
        if ((!this.m_TypeOfLawID.m_bIsSet ? 1 : (this.m_TypeOfLawID.nValue.Equals(0) ? 1 : 0)) != 0)
        {
          this.TypeOfLawNN = "NA~";
          if (this.m_TypeOfLawID.nValue.Equals(0))
          {
            PLTypeOfLaw plTypeOfLaw1 = new PLTypeOfLaw();
            plTypeOfLaw1.NickName = "NA~";
            plTypeOfLaw1.Name = "Not Supplied";
            PLTypeOfLaw plTypeOfLaw2 = plTypeOfLaw1;
            plTypeOfLaw2.AddRecord();
            plTypeOfLaw2.SendLast();
            this.TypeOfLawNN = "NA~";
          }
        }
        if (this.TypeOfLawID == 0)
          this.TypeOfLawID = 6;
        this.m_TypeOfLawID.AddField(this.m_hndPOST);
        this.m_DepartmentID.AddField(this.m_hndPOST);
        this.m_InvID.AddField(this.m_hndPOST);
        if (this.m_InvoiceNumber.nValue >= 1000000)
          this.m_InvoiceNumber.nValue = this.m_InvoiceNumber.nValue % 1000000;
        if (this.m_InvoiceNumber.nValue == 0)
          this.m_InvoiceNumber.nValue = 100000;
        nInvDate = date;
        nInvNum = this.InvoiceNumber;
        this.m_InvoiceNumber.AddField(this.m_hndPOST);
        this.m_Date.AddField(this.m_hndPOST);
        this.m_InterestRate.AddField(this.m_hndPOST);
        this.m_EntryType.AddField(this.m_hndPOST);
        this.m_CutoffDate.AddField(this.m_hndPOST);
        this.m_Fees.AddField(this.m_hndPOST);
        this.m_Hours.AddField(this.m_hndPOST);
        this.m_Disbs.AddField(this.m_hndPOST);
        this.m_GSTFees.AddField(this.m_hndPOST);
        this.m_GSTDisbs.AddField(this.m_hndPOST);
        this.m_PSTFees.AddField(this.m_hndPOST);
        this.m_PSTDisbs.AddField(this.m_hndPOST);
        this.m_SoftCosts.AddField(this.m_hndPOST);
        this.m_QuickBooksID.AddField(this.m_hndPOST);
        this.m_ExternalID_1.AddField(this.m_hndPOST);
        this.m_ExternalID_2.AddField(this.m_hndPOST);
        int nRepeat = 0;
        foreach (KeyValuePair<int, PLARLawyerAlloc> keyValuePair2 in this.m_htAlloc)
        {
          PLARLawyerAlloc plarLawyerAlloc = new PLARLawyerAlloc()
          {
            LawyerID = keyValuePair2.Value.LawyerID,
            GLID = keyValuePair2.Value.GLID,
            Hours = keyValuePair2.Value.Hours,
            Amount = keyValuePair2.Value.Amount
          };
          dictionary.Add(plarLawyerAlloc.LawyerID, plarLawyerAlloc);
          ++nRepeat;
          keyValuePair2.Value.AddRepeatFields(this.m_hndPOST, nRepeat);
        }
        this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
        PLBilling plBilling2 = this;
        plBilling2.m_lCounter = plBilling2.m_lCounter + 1;
        this.Send(ref nInvID, ref nInvNum, ref nInvDate);
        this.writerA.Write("\"" + nInvID.ToString() + "\"\r\n");
        if (nInvID.Equals(0))
        {
          this.writerA.Close();
          this.writerA.Dispose();
          this.writerA = (StreamWriter) null;
          this.writerS.Close();
          this.writerS.Dispose();
          this.writerS = (StreamWriter) null;
        }
      }
      catch
      {
      }
      if ((!this.bAutoCreateCharges ? 0 : (!this.PostQuickBooksIDOnly ? 1 : 0)) != 0)
      {
        if (dictionary.Count > 0)
        {
          PLTimeEntry plTimeEntry = new PLTimeEntry();
          foreach (KeyValuePair<int, PLARLawyerAlloc> keyValuePair2 in dictionary)
          {
            plTimeEntry.Amount = keyValuePair2.Value.Amount;
            plTimeEntry.Date = nInvDate;
            plTimeEntry.Explanation = "Billed Fees";
            plTimeEntry.Hours = keyValuePair2.Value.Hours;
            plTimeEntry.DateEntered = nInvDate;
            plTimeEntry.InvDate = nInvDate;
            plTimeEntry.InvNumber = nInvNum;
            plTimeEntry.InvoiceID = nInvID;
            plTimeEntry.LawyerID = keyValuePair2.Value.LawyerID;
            plTimeEntry.MatterID = matterId;
            if (!plTimeEntry.Hours.Equals(0.0))
            {
              plTimeEntry.EntryType = PLTimeEntry.eFeeEntryType.TimeEnt;
              plTimeEntry.Rate = plTimeEntry.Amount / plTimeEntry.Hours;
            }
            else
              plTimeEntry.EntryType = PLTimeEntry.eFeeEntryType.FEE_ENTRY;
            plTimeEntry.TaskNN = "BW";
            plTimeEntry.AddRecord();
          }
          plTimeEntry.SendLast();
        }
        if (!disbs.Equals(0.0))
        {
          PLExpense plExpense = new PLExpense();
          double dAmt = disbs;
          if (!dAmt.Equals(0.0))
          {
            PLGBTranObj plgbTranObj = new PLGBTranObj(nInvDate, matterId, "Opening Balance", "OB", "Billed Disbursements", 0, dAmt, PLGBEnt.eGBEntryType.EXP_COB, nInvID, nInvNum, nInvDate);
            plExpense.MatterID = matterId;
            plExpense.GLNN = "9999";
            plExpense.Amount = disbs;
            plExpense.CheckNum = "OB";
            plExpense.Date = nInvDate;
            plExpense.Explanation = "Billed Disbursements";
            plExpense.PaidTo = "Opening Balance";
            plExpense.InvDate = nInvDate;
            plExpense.InvoiceID = nInvID;
            plExpense.InvoiceNumber = nInvNum;
            plExpense.AddRecord();
            plExpense.SendLast();
          }
          if (disbs.Equals(0.0))
            ;
        }
      }
      this.m_htAlloc.Clear();
      dictionary.Clear();
    }

    public override void Clear()
    {
      base.Clear();
      this.m_htAlloc.Clear();
    }

    public static void ClearMapExtID1toInvID()
    {
      if (PLBilling.m_cMapExtID1toInvID == null)
        return;
      PLBilling.m_cMapExtID1toInvID.Clear();
      PLBilling.m_cMapExtID1toInvID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toInvDate()
    {
      if (PLBilling.m_cMapExtID2toInvDate == null)
        return;
      PLBilling.m_cMapExtID2toInvDate.Clear();
      PLBilling.m_cMapExtID2toInvDate = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toInvID()
    {
      if (PLBilling.m_cMapExtID2toInvID == null)
        return;
      PLBilling.m_cMapExtID2toInvID.Clear();
      PLBilling.m_cMapExtID2toInvID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toInvNum()
    {
      if (PLBilling.m_cMapExtID2toInvNum == null)
        return;
      PLBilling.m_cMapExtID2toInvNum.Clear();
      PLBilling.m_cMapExtID2toInvNum = (Dictionary<string, int>) null;
    }

    public static void ClearMapInvIDtoMattID()
    {
      if (PLBilling.m_cMapInvIDtoMattID == null)
        return;
      PLBilling.m_cMapInvIDtoMattID.Clear();
      PLBilling.m_cMapInvIDtoMattID = (Dictionary<int, int>) null;
    }

    public static void ClearMapInvIDtoQuickBooksID()
    {
      if (PLBilling.m_MapIDtoQuickBooksID == null)
        return;
      PLBilling.m_MapIDtoQuickBooksID.Clear();
      PLBilling.m_MapIDtoQuickBooksID = (Dictionary<int, string>) null;
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLBilling.m_bAllowEntOnClosedMtr;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndExisting);
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "FeeAllocLawyerID");
      for (int index = 1; index <= recurringFieldCount; ++index)
      {
        this.Alloc.GetRepeatFields(this.m_hndExisting, recurringFieldCount);
        this.AddAllocation();
      }
    }

    public static int GetInvDatefromExtID2(string Key)
    {
      return (string.IsNullOrEmpty(Key) ? 0 : (PLBilling.m_cMapExtID2toInvDate != null ? 1 : 0)) == 0 ? 0 : (PLBilling.m_cMapExtID2toInvDate.ContainsKey(Key) ? Convert.ToInt32(PLBilling.m_cMapExtID2toInvDate[Key]) : 0);
    }

    public static int GetInvIDfromExtID1(string Key)
    {
      return (string.IsNullOrEmpty(Key) ? 0 : (PLBilling.m_cMapExtID1toInvID != null ? 1 : 0)) == 0 ? 0 : (PLBilling.m_cMapExtID1toInvID.ContainsKey(Key) ? Convert.ToInt32(PLBilling.m_cMapExtID1toInvID[Key]) : 0);
    }

    public static int GetInvIDfromExtID2(string Key)
    {
      return (string.IsNullOrEmpty(Key) ? 0 : (PLBilling.m_cMapExtID2toInvID != null ? 1 : 0)) == 0 ? 0 : (PLBilling.m_cMapExtID2toInvID.ContainsKey(Key) ? Convert.ToInt32(PLBilling.m_cMapExtID2toInvID[Key]) : 0);
    }

    public static int GetInvNumfromExtID2(string Key)
    {
      return (string.IsNullOrEmpty(Key) ? 0 : (PLBilling.m_cMapExtID2toInvNum != null ? 1 : 0)) == 0 ? 0 : (PLBilling.m_cMapExtID2toInvNum.ContainsKey(Key) ? Convert.ToInt32(PLBilling.m_cMapExtID2toInvNum[Key]) : 0);
    }

    public static int GetMattIDfromInvID(int Key)
    {
      return (Key.Equals(0) ? 0 : (PLBilling.m_cMapInvIDtoMattID != null ? 1 : 0)) == 0 ? 0 : (PLBilling.m_cMapInvIDtoMattID.ContainsKey(Key) ? Convert.ToInt32(PLBilling.m_cMapInvIDtoMattID[Key]) : 0);
    }

    public static string GetQuickBooksIDfromInvID(int Key)
    {
      return (Key.Equals(0) ? 0 : (PLBilling.m_MapIDtoQuickBooksID != null ? 1 : 0)) == 0 ? string.Empty : (PLBilling.m_MapIDtoQuickBooksID.ContainsKey(Key) ? Convert.ToString(PLBilling.m_MapIDtoQuickBooksID[Key]) : string.Empty);
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "FeeAllocLawyerID");
      for (int index = 1; index <= recurringFieldCount; ++index)
      {
        this.Alloc.GetRepeatFields(this.m_hndGET, recurringFieldCount);
        this.AddAllocation();
      }
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Billing";
      this.bAutoCreateCharges = true;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "ARInvID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "ARInvStatus");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Status = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "MatterID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_MatterID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "CollLawyerID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_CollLawyerID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "TypeofLawID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_TypeOfLawID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "DepartmentID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_DepartmentID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "ARInvID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_InvID = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "ARInvInvoiceNumber");
      CPostItem cpostItem16 = cpostItem15;
      this.m_InvoiceNumber = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "ARInvDate");
      CPostItem cpostItem18 = cpostItem17;
      this.m_Date = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvIntRate");
      CPostItem cpostItem20 = cpostItem19;
      this.m_InterestRate = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "ARInvEntryType");
      CPostItem cpostItem22 = cpostItem21;
      this.m_EntryType = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "ARInvCutoffDate");
      CPostItem cpostItem24 = cpostItem23;
      this.m_CutoffDate = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvFees");
      CPostItem cpostItem26 = cpostItem25;
      this.m_Fees = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvHours");
      CPostItem cpostItem28 = cpostItem27;
      this.m_Hours = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvDisbs");
      CPostItem cpostItem30 = cpostItem29;
      this.m_Disbs = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvGSTFees");
      CPostItem cpostItem32 = cpostItem31;
      this.m_GSTFees = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvGSTDisbs");
      CPostItem cpostItem34 = cpostItem33;
      this.m_GSTDisbs = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvPSTFees");
      CPostItem cpostItem36 = cpostItem35;
      this.m_PSTFees = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvPSTDisbs");
      CPostItem cpostItem38 = cpostItem37;
      this.m_PSTDisbs = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.DOUBLE, "ARInvSoftCosts");
      CPostItem cpostItem40 = cpostItem39;
      this.m_SoftCosts = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.STRING, "ARQuickBooksID");
      CPostItem cpostItem42 = cpostItem41;
      this.m_QuickBooksID = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      CPostItem cpostItem44 = cpostItem43;
      this.m_ExternalID_1 = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      CPostItem cpostItem46 = cpostItem45;
      this.m_ExternalID_2 = cpostItem45;
      postItems23.Add(cpostItem46);
      List<CPostItem> postItems24 = this.PostItems;
      CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.LONG, "ARInvReverseID");
      CPostItem cpostItem48 = cpostItem47;
      this.m_ReverseEntryID = cpostItem47;
      postItems24.Add(cpostItem48);
      this.m_htAlloc = new Dictionary<int, PLARLawyerAlloc>();
      this.Alloc = new PLARLawyerAlloc();
    }

    public bool Send(ref int nInvID, ref int nInvNum, ref int nInvDate)
    {
      object nProcessed = new object();
      object nExceptions = new object();
      object vunIDCreated = new object();
      object nExceptionError = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      object szValue = new object();
      short num1 = 0;
      string empty = string.Empty;
      double num2 = 0.0;
      double num3 = 0.0;
      double dAmt1 = 0.0;
      double num4 = 0.0;
      this.m_lSendErrorCount = 0L;
      if (this.writerS == null)
      {
        try
        {
          string path = Path.GetTempPath() + "PCLAWLOG";
          if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
          this.writerS = new StreamWriter(path + "\\Send.txt");
        }
        catch
        {
        }
      }
      PLBilling plBilling1 = this;
      plBilling1.nSends = plBilling1.nSends + 1;
      StreamWriter writerS = this.writerS;
      string str1 = this.nSends.ToString("000");
      DateTime now = DateTime.Now;
      this.idCascade = "";
      this.idCascade = nInvID.ToString();
      writerS.Write(str1 + ".  " + now.ToString() + "     ");
      string str2;
      string str3;
      string str4;
      string message;
      string str5;
      string str6;
      string str7;
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      }
      catch (NullReferenceException ex)
      {
        this.idCascade = this.idCascade + " : " + ex.Message;
        NullReferenceException referenceException = ex;
        str2 = referenceException.Data == null ? string.Empty : referenceException.Data.ToString();
        str3 = referenceException.HelpLink == null ? string.Empty : referenceException.HelpLink.ToString();
        str4 = referenceException.InnerException == null ? string.Empty : referenceException.InnerException.ToString();
        message = referenceException.Message;
        str5 = referenceException.Source == null ? string.Empty : referenceException.Source.ToString();
        str6 = referenceException.StackTrace == null ? string.Empty : referenceException.StackTrace.ToString();
        str7 = referenceException.TargetSite == (MethodBase) null ? string.Empty : referenceException.TargetSite.ToString();
        PLBilling plBilling2 = this;
        plBilling2.m_lSendErrorCount = plBilling2.m_lSendErrorCount + 1L;
        this.ResetPOSTHandle();
        return false;
      }
      catch (AccessViolationException ex)
      {
        this.idCascade = this.idCascade + " : " + ex.Message;
        AccessViolationException violationException = ex;
        str2 = violationException.Data == null ? string.Empty : violationException.Data.ToString();
        str3 = violationException.HelpLink == null ? string.Empty : violationException.HelpLink.ToString();
        str4 = violationException.InnerException == null ? string.Empty : violationException.InnerException.ToString();
        message = violationException.Message;
        str5 = violationException.Source == null ? string.Empty : violationException.Source.ToString();
        str6 = violationException.StackTrace == null ? string.Empty : violationException.StackTrace.ToString();
        str7 = violationException.TargetSite == (MethodBase) null ? string.Empty : violationException.TargetSite.ToString();
        PLBilling plBilling2 = this;
        plBilling2.m_lSendErrorCount = plBilling2.m_lSendErrorCount + 1L;
        this.ResetPOSTHandle();
        return false;
      }
      catch (FormatException ex)
      {
        this.idCascade = this.idCascade + " : " + ex.Message;
        FormatException formatException = ex;
        str2 = formatException.Data == null ? string.Empty : formatException.Data.ToString();
        str3 = formatException.HelpLink == null ? string.Empty : formatException.HelpLink.ToString();
        str4 = formatException.InnerException == null ? string.Empty : formatException.InnerException.ToString();
        message = formatException.Message;
        str5 = formatException.Source == null ? string.Empty : formatException.Source.ToString();
        str6 = formatException.StackTrace == null ? string.Empty : formatException.StackTrace.ToString();
        str7 = formatException.TargetSite == (MethodBase) null ? string.Empty : formatException.TargetSite.ToString();
        PLBilling plBilling2 = this;
        plBilling2.m_lSendErrorCount = plBilling2.m_lSendErrorCount + 1L;
        this.ResetPOSTHandle();
        return false;
      }
      catch (Exception ex)
      {
        this.idCascade = this.idCascade + " : GenTopException: " + ex.Message;
        return false;
      }
      bool flag;
      try
      {
        num1 = Convert.ToInt16(nProcessed);
        short int16 = Convert.ToInt16(nExceptions);
        PLXMLData.m_lErrorCount += (long) int16;
        if ((int) int16 > 0)
        {
          this.idCascade = this.idCascade + " : num1 > 0";
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          this.ResetPOSTHandle();
          this.m_lCounter = 0;
          PLBilling plBilling2 = this;
          plBilling2.m_lSendErrorCount = plBilling2.m_lSendErrorCount + 1L;
          flag = false;
        }
        else if (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
        {
          nInvID = Convert.ToInt32(vunIDCreated);
          this.idCascade = this.idCascade + " : got in! : " + nInvID.ToString();
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_GSTDisbs.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            num2 = Convert.ToDouble(szValue);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_GSTFees.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            num3 = Convert.ToDouble(szValue);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_PSTDisbs.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            dAmt1 = Convert.ToDouble(szValue);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_PSTFees.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            num4 = Convert.ToDouble(szValue);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_CollLawyerID.sLinkName, empty, ref szValue);
          int int32_1 = Convert.ToInt32(szValue);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_MatterID.sLinkName, empty, ref szValue);
          int int32_2 = Convert.ToInt32(szValue);
          PLBilling.AddMapInvIDtoMattID(nInvID, int32_2);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, empty, ref szValue);
          PLBilling.AddMapExtID1toInvID(szValue.ToString(), nInvID);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, empty, ref szValue);
          string Key = szValue.ToString();
          PLBilling.AddMapExtID2toInvID(Key, nInvID);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_InvoiceNumber.sLinkName, empty, ref szValue);
          nInvNum = Convert.ToInt32(szValue);
          PLBilling.AddMapExtID2toInvNum(Key, nInvNum);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_Date.sLinkName, empty, ref szValue);
          nInvDate = Convert.ToInt32(szValue);
          PLBilling.AddMapExtID2toInvDate(Key, nInvDate);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_QuickBooksID.sLinkName, empty, ref szValue);
          PLBilling.AddMapIDtoQuickBooksID(nInvID, szValue.ToString());
          if ((!this.UseReverseEntryID ? 0 : (this.m_ReverseEntryID != null ? 1 : 0)) != 0)
          {
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ReverseEntryID.sLinkName, empty, ref szValue);
            this.ReverseEntryID = Convert.ToInt32(szValue);
          }
          this.ResetPOSTHandle();
          this.m_lCounter = 0;
          if (!this.PostQuickBooksIDOnly)
          {
            double num5 = num3 + num2;
            double dAmt2 = 0.0;
            if ((!num5.Equals(0.0) ? 1 : (!num4.Equals(0.0) ? 1 : 0)) != 0)
            {
              PLTimeEntry plTimeEntry = new PLTimeEntry();
              if (!num5.Equals(0.0))
              {
                plTimeEntry.Amount = num5;
                plTimeEntry.Date = nInvDate;
                plTimeEntry.InvDate = nInvDate;
                plTimeEntry.EntryType = PLTimeEntry.eFeeEntryType.FEE_GST;
                plTimeEntry.Explanation = "Taxes on Fees";
                plTimeEntry.InvNumber = nInvNum;
                plTimeEntry.InvoiceID = nInvID;
                plTimeEntry.LawyerID = int32_1;
                plTimeEntry.MatterID = int32_2;
                plTimeEntry.TaskNN = "NBW";
                plTimeEntry.AddRecord();
              }
              if (!num4.Equals(0.0))
              {
                plTimeEntry.Amount = num4;
                plTimeEntry.Date = nInvDate;
                plTimeEntry.InvDate = nInvDate;
                plTimeEntry.EntryType = PLTimeEntry.eFeeEntryType.FEE_STAX;
                plTimeEntry.InvNumber = nInvNum;
                plTimeEntry.Explanation = "Sales Tax on Invoice " + nInvNum.ToString();
                plTimeEntry.InvoiceID = nInvID;
                plTimeEntry.LawyerID = int32_1;
                plTimeEntry.MatterID = int32_2;
                plTimeEntry.TaskNN = "NBW";
                plTimeEntry.AddRecord();
              }
              plTimeEntry.SendLast();
            }
            if ((!dAmt2.Equals(0.0) ? 1 : (!dAmt1.Equals(0.0) ? 1 : 0)) != 0)
            {
              PLGBEnt plgbEnt = new PLGBEnt();
              if (!dAmt2.Equals(0.0))
              {
                this.m_htDisbEntries.Add(this.m_htDisbEntries.Count, new PLGBTranObj(nInvDate, int32_2, "Taxes on Invoice " + nInvNum.ToString(), "tax", "Taxes on Disbursements", PLGBAcct.GetIDFromNN("1"), dAmt2, PLGBEnt.eGBEntryType.DISB_GST, nInvID, nInvNum, nInvDate));
                plgbEnt.Date = nInvDate;
                plgbEnt.EntryType = PLGBEnt.eGBEntryType.DISB_GST;
                plgbEnt.PaidTo = "Taxes on Invoice " + nInvNum.ToString();
                plgbEnt.TotalAmount = dAmt2;
                plgbEnt.BankAcctID = PLGBAcct.GetIDFromNN("1");
                plgbEnt.CheckNum = nInvNum.ToString();
                plgbEnt.Alloc.Explanation = "Taxes on Disbursements";
                plgbEnt.Alloc.GLID = PLGLAccts.GetSuspenseID();
                plgbEnt.Alloc.GSTCat = TransactionData.eGST_CAT.NOT_SET;
                plgbEnt.Alloc.InvDate = nInvDate;
                plgbEnt.Alloc.InvID = nInvID;
                plgbEnt.Alloc.InvNumber = nInvNum;
                plgbEnt.Alloc.MatterID = int32_2;
                plgbEnt.Alloc.Amount = plgbEnt.TotalAmount;
                plgbEnt.Alloc.EntryType = PLGBAlloc.eGBAllocEntryType.DISB_GST;
                plgbEnt.AddGBAllocation();
                plgbEnt.AddRecord();
              }
              if (!dAmt1.Equals(0.0))
              {
                this.m_htDisbEntries.Add(this.m_htDisbEntries.Count, new PLGBTranObj(nInvDate, int32_2, "Sales Tax on Disbursements " + nInvNum.ToString(), "tax", "Sales Tax on Disbursements", PLGBAcct.GetIDFromNN("1"), dAmt1, PLGBEnt.eGBEntryType.DISB_STAX, nInvID, nInvNum, nInvDate));
                plgbEnt.Date = nInvDate;
                plgbEnt.EntryType = PLGBEnt.eGBEntryType.DISB_STAX;
                plgbEnt.PaidTo = "Sales Tax on Disbursements " + nInvNum.ToString();
                plgbEnt.TotalAmount = dAmt1;
                plgbEnt.BankAcctID = PLGBAcct.GetIDFromNN("1");
                plgbEnt.Alloc.Explanation = "Sales Tax on Disbursements";
                plgbEnt.Alloc.GLNN = "9999";
                plgbEnt.Alloc.GSTCat = TransactionData.eGST_CAT.NOT_SET;
                plgbEnt.Alloc.InvDate = nInvDate;
                plgbEnt.Alloc.InvID = nInvID;
                plgbEnt.Alloc.InvNumber = nInvNum;
                plgbEnt.Alloc.MatterID = int32_2;
                plgbEnt.Alloc.EntryType = PLGBAlloc.eGBAllocEntryType.DISB_STAX;
                plgbEnt.Alloc.Amount = plgbEnt.TotalAmount;
                plgbEnt.AddGBAllocation();
                plgbEnt.AddRecord();
              }
              plgbEnt.SendLast();
            }
          }
          this.writerS.Write("\"" + nInvID.ToString() + "\"\r\n");
          flag = true;
        }
        else
        {
          this.idCascade = this.idCascade + " : !tablepost.NextResilt (last else)";
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          this.ResetPOSTHandle();
          this.m_lCounter = 0;
          PLBilling plBilling2 = this;
          plBilling2.m_lSendErrorCount = plBilling2.m_lSendErrorCount + 1L;
          flag = false;
        }
      }
      catch (Exception ex)
      {
        this.idCascade = this.idCascade + " : GenBottomException: " + ex.Message;
        Exception exception = ex;
        str2 = exception.Data == null ? "" : exception.Data.ToString();
        str3 = exception.HelpLink == null ? "" : exception.HelpLink.ToString();
        str4 = exception.InnerException == null ? "" : exception.InnerException.ToString();
        message = exception.Message;
        str5 = exception.Source == null ? "" : exception.Source.ToString();
        str6 = exception.StackTrace == null ? "" : exception.StackTrace.ToString();
        str7 = exception.TargetSite == (MethodBase) null ? "" : exception.TargetSite.ToString();
        PLBilling plBilling2 = this;
        plBilling2.m_lSendErrorCount = plBilling2.m_lSendErrorCount + 1L;
        this.ResetPOSTHandle();
        flag = false;
      }
      return flag;
    }

    public override void SendLast()
    {
      int nInvID = 0;
      int nInvNum = 0;
      int nInvDate = 0;
      if (this.m_lCounter > 0)
        this.Send(ref nInvID, ref nInvNum, ref nInvDate);
      if ((int) this.m_hndPOST != 0)
      {
        this.GetLink().TablePOST_CloseHandle(this.m_hndPOST);
        this.m_hndPOST = 0U;
      }
      if (this.writerA != null)
      {
        this.writerA.Close();
        this.writerA.Dispose();
        this.writerA = (StreamWriter) null;
      }
      if (this.writerS != null)
      {
        this.writerS.Close();
        this.writerS.Dispose();
        this.writerS = (StreamWriter) null;
      }
      KeyValuePair<int, PLGBTranObj> current;
      if (!this.PostQuickBooksIDOnly)
      {
        PLExpense plExpense = new PLExpense();
        Dictionary<int, PLGBTranObj>.Enumerator enumerator = this.m_htExpEntries.GetEnumerator();
        while (enumerator.MoveNext())
        {
          current = enumerator.Current;
          PLGBTranObj plgbTranObj = current.Value;
          plExpense.MatterID = plgbTranObj.MatterID;
          plExpense.GLNN = "9999";
          plExpense.Amount = plgbTranObj.Amount;
          plExpense.CheckNum = plgbTranObj.RcptNum;
          plExpense.Date = plgbTranObj.TransactionDate;
          plExpense.Explanation = plgbTranObj.Expl;
          plExpense.PaidTo = plgbTranObj.RcvdFrom;
          plExpense.InvDate = plgbTranObj.InvDate;
          plExpense.InvoiceID = plgbTranObj.InvID;
          plExpense.InvoiceNumber = plgbTranObj.InvNum;
          plExpense.AddRecord();
        }
        plExpense.SendLast();
      }
      this.m_htExpEntries.Clear();
      if (!this.PostQuickBooksIDOnly)
      {
        PLGBEnt plgbEnt = new PLGBEnt();
        Dictionary<int, PLGBTranObj>.Enumerator enumerator = this.m_htDisbEntries.GetEnumerator();
        while (enumerator.MoveNext())
        {
          current = enumerator.Current;
          PLGBTranObj plgbTranObj = current.Value;
          plgbEnt.Date = plgbTranObj.TransactionDate;
          plgbEnt.EntryType = plgbTranObj.EntryType;
          plgbEnt.PaidTo = plgbTranObj.RcvdFrom;
          plgbEnt.TotalAmount = plgbTranObj.Amount;
          plgbEnt.BankAcctID = plgbTranObj.BankAcctID;
          plgbEnt.Alloc.Explanation = plgbTranObj.Expl;
          plgbEnt.Alloc.GLNN = "9999";
          plgbEnt.Alloc.GSTCat = TransactionData.eGST_CAT.NO;
          plgbEnt.Alloc.InvDate = plgbTranObj.InvDate;
          plgbEnt.Alloc.InvID = plgbTranObj.InvID;
          plgbEnt.Alloc.InvNumber = plgbTranObj.InvNum;
          plgbEnt.Alloc.MatterID = plgbTranObj.MatterID;
          plgbEnt.Alloc.Amount = plgbEnt.TotalAmount;
          if (plgbTranObj.EntryType == PLGBEnt.eGBEntryType.DISB_GST)
            plgbEnt.Alloc.EntryType = PLGBAlloc.eGBAllocEntryType.DISB_GST;
          else if (plgbTranObj.EntryType == PLGBEnt.eGBEntryType.DISB_STAX)
            plgbEnt.Alloc.EntryType = PLGBAlloc.eGBAllocEntryType.DISB_STAX;
          plgbEnt.AddGBAllocation();
          plgbEnt.AddRecord();
        }
        plgbEnt.SendLast();
      }
      this.m_htDisbEntries.Clear();
    }

    public override string ToString()
    {
      return "Billing";
    }
  }
}
