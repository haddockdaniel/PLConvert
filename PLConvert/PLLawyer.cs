// Decompiled with JetBrains decompiler
// Type: PLConvert.PLLawyer
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PLConvert
{
  public class PLLawyer : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    private static bool bRead = false;
    private CPostItem m_IsPartner;
    private CPostItem m_Initials;
    private CPostItem m_Name;
    private CPostItem m_Classification;
    private CPostItem m_DepartmentID;
    private CPostItem m_DiaryActive;
    private CPostItem m_MembershipNumber;
    private CPostItem m_LegalAidNumber;
    private CPostItem m_ICBCNumber;
    private CPostItem m_StateTaxNumber;
    private CPostItem m_FedTaxNumber;
    private CPostItem m_AttorneyGeneralNumber;
    private CPostItem m_Flags;
    private CPostItem m_RateID;
    private CPostItem m_RateAmt;
    private CPostItem m_RateDate;
    private List<PLLawyer.LawyerRate> m_RateArr;
    private static Dictionary<string, int> m_MapNNtoID;
    private static Dictionary<int, string> m_MapIDtoNN;
    private static Dictionary<string, int> m_MapExtID1toPLID;
    private static Dictionary<string, int> m_MapExtID2toPLID;
    private static Dictionary<int, int> m_MapPLIDtoGLID;
    private static Dictionary<int, string> m_MapPLIDtoQBID;

    public string AttorneyGeneralNumber
    {
      get
      {
        return this.m_AttorneyGeneralNumber.sValue;
      }
      set
      {
        this.m_AttorneyGeneralNumber.SetValue(value);
      }
    }

    public PLLawyer.LawyerClassification Classification
    {
      get
      {
        return (PLLawyer.LawyerClassification) this.m_Classification.nValue;
      }
      set
      {
        this.m_Classification.SetValue((int) value);
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

    public bool DiaryActive
    {
      get
      {
        return this.m_DiaryActive.bValue;
      }
      set
      {
        this.m_DiaryActive.SetValue(value);
      }
    }

    public string FedTaxNumber
    {
      get
      {
        return this.m_FedTaxNumber.sValue;
      }
      set
      {
        this.m_FedTaxNumber.SetValue(value);
      }
    }

    public int Flags
    {
      get
      {
        return this.m_Flags.nValue;
      }
      set
      {
        this.m_Flags.SetValue(value);
      }
    }

    public string ICBCNumber
    {
      get
      {
        return this.m_ICBCNumber.sValue;
      }
      set
      {
        this.m_ICBCNumber.SetValue(value);
      }
    }

    public string Initials
    {
      get
      {
        return this.m_Initials.sValue;
      }
      set
      {
        this.m_Initials.SetValue(value);
      }
    }

    public bool IsPartner
    {
      get
      {
        return this.m_IsPartner.bValue;
      }
      set
      {
        this.m_IsPartner.SetValue(value);
      }
    }

    public string LegalAidNumber
    {
      get
      {
        return this.m_LegalAidNumber.sValue;
      }
      set
      {
        this.m_LegalAidNumber.SetValue(value);
      }
    }

    public string MembershipNumber
    {
      get
      {
        return this.m_MembershipNumber.sValue;
      }
      set
      {
        this.m_MembershipNumber.SetValue(value);
      }
    }

    public string Name
    {
      get
      {
        return this.m_Name.sValue;
      }
      set
      {
        this.m_Name.SetValue(value);
      }
    }

    public string StateTaxNumber
    {
      get
      {
        return this.m_StateTaxNumber.sValue;
      }
      set
      {
        this.m_StateTaxNumber.SetValue(value);
      }
    }

    public PLLawyer()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLLawyer.m_MapExtID1toPLID == null)
        PLLawyer.m_MapExtID1toPLID = new Dictionary<string, int>();
      if (!PLLawyer.m_MapExtID1toPLID.ContainsKey(Key))
        PLLawyer.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLLawyer.m_MapExtID2toPLID == null)
        PLLawyer.m_MapExtID2toPLID = new Dictionary<string, int>();
      if (!PLLawyer.m_MapExtID2toPLID.ContainsKey(Key))
        PLLawyer.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLLawyer.m_MapIDtoNN == null)
        PLLawyer.m_MapIDtoNN = new Dictionary<int, string>();
      if (!PLLawyer.m_MapIDtoNN.ContainsKey(Key))
        PLLawyer.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLLawyer.m_MapNNtoID == null)
        PLLawyer.m_MapNNtoID = new Dictionary<string, int>();
      if (!PLLawyer.m_MapNNtoID.ContainsKey(Key))
        PLLawyer.m_MapNNtoID.Add(Key, Value);
    }

    public static void AddMapPLIDtoGLID(int Key, int Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLLawyer.m_MapPLIDtoGLID == null)
        PLLawyer.m_MapPLIDtoGLID = new Dictionary<int, int>();
      if (!PLLawyer.m_MapPLIDtoGLID.ContainsKey(Key))
        PLLawyer.m_MapPLIDtoGLID.Add(Key, Value);
    }

    public static void AddMapPLIDtoQBID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLLawyer.m_MapPLIDtoQBID == null)
        PLLawyer.m_MapPLIDtoQBID = new Dictionary<int, string>();
      if (PLLawyer.m_MapPLIDtoQBID.ContainsKey(Key))
        PLLawyer.m_MapPLIDtoQBID.Remove(Key);
      PLLawyer.m_MapPLIDtoQBID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLLawyer.m_NNs == null)
        PLLawyer.m_NNs = new List<string>();
      PLLawyer.m_NNs.Add(sNickname.ToLower());
    }

    public void AddRate(int RateID, double dRate, int nDate)
    {
      if (RateID == 0)
        return;
      if (nDate == 0)
        nDate = 19820101;
      for (int index = 0; index < this.m_RateArr.Count; ++index)
      {
        if ((this.m_RateArr[index].RateID != RateID ? 1 : (this.m_RateArr[index].RateDate != nDate ? 1 : 0)) == 0)
        {
          this.m_RateArr[index].RateAmount = dRate;
          return;
        }
      }
      this.m_RateArr.Add(new PLLawyer.LawyerRate(RateID, dRate, nDate));
    }

    public void AddRate(string RateNN, double dRate, int nDate)
    {
      this.AddRate(PLRate.GetIDFromNN(RateNN), dRate, nDate);
    }

    public void AddRate(int RateID, double dRate)
    {
      this.AddRate(RateID, dRate, 19820101);
    }

    public void AddRate(string RateNN, double dRate)
    {
      this.AddRate(PLRate.GetIDFromNN(RateNN), dRate, 19820101);
    }

    public override void AddRecord()
    {
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLLawyer.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      PLLawyer.AddNicknameToList(this.NickName);
      base.AddRecord();
      for (short index = 1; (int) index <= this.m_RateArr.Count; ++index)
      {
        this.m_RateID.SetValue(this.m_RateArr[(int) index - 1].RateID);
        this.m_RateID.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_RateAmt.SetValue(this.m_RateArr[(int) index - 1].RateAmount);
        this.m_RateAmt.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_RateDate.SetValue(this.m_RateArr[(int) index - 1].RateDate);
        this.m_RateDate.AddRepeatField(this.m_hndPOST, (int) index);
      }
      this.m_RateArr.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLLawyer plLawyer = this;
      plLawyer.m_lCounter = plLawyer.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.m_RateArr.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLLawyer.m_MapExtID1toPLID == null)
        return;
      PLLawyer.m_MapExtID1toPLID.Clear();
      PLLawyer.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLLawyer.m_MapExtID2toPLID == null)
        return;
      PLLawyer.m_MapExtID2toPLID.Clear();
      PLLawyer.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLLawyer.m_MapIDtoNN == null)
        return;
      PLLawyer.m_MapIDtoNN.Clear();
      PLLawyer.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLLawyer.m_MapNNtoID == null)
        return;
      PLLawyer.m_MapNNtoID.Clear();
      PLLawyer.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static void ClearMapPLIDtoGLID()
    {
      if (PLLawyer.m_MapPLIDtoGLID == null)
        return;
      PLLawyer.m_MapPLIDtoGLID.Clear();
      PLLawyer.m_MapPLIDtoGLID = (Dictionary<int, int>) null;
    }

    public static void ClearMapPLIDtoQBID()
    {
      if (PLLawyer.m_MapPLIDtoQBID == null)
        return;
      PLLawyer.m_MapPLIDtoQBID.Clear();
      PLLawyer.m_MapPLIDtoQBID = (Dictionary<int, string>) null;
    }

    public override void GetExistingRecord()
    {
      base.GetExistingRecord();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "RateID");
      for (int nRepeat = 0; nRepeat < recurringFieldCount; ++nRepeat)
      {
        this.m_RateID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_RateAmt.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_RateDate.GetRepeatField(this.m_hndExisting, nRepeat);
        this.AddRate(this.m_RateID.nValue, this.m_RateAmt.dValue, this.m_RateDate.nValue);
        this.m_RateID.Clear();
        this.m_RateAmt.Clear();
        this.m_RateDate.Clear();
      }
    }

    public static int GetGLIDFromPLID(int nID)
    {
      int num;
      if (!nID.Equals(0))
      {
        if (!PLLawyer.bRead)
          PLLawyer.ReadTable();
        num = PLLawyer.m_MapPLIDtoGLID == null ? 0 : (PLLawyer.m_MapPLIDtoGLID.ContainsKey(nID) ? Convert.ToInt32(PLLawyer.m_MapPLIDtoGLID[nID]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return !Key.Equals("") ? (PLLawyer.m_MapExtID1toPLID == null ? 0 : (PLLawyer.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLLawyer.m_MapExtID1toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !Key.Equals("") ? (PLLawyer.m_MapExtID2toPLID == null ? 0 : (PLLawyer.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLLawyer.m_MapExtID2toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      Key = Key.ToUpper();
      int num;
      if (!Key.Equals(""))
      {
        if (!PLLawyer.bRead)
          PLLawyer.ReadTable();
        num = PLLawyer.m_MapNNtoID == null ? 0 : (PLLawyer.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLLawyer.m_MapNNtoID[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static string GetNNFromID(int nID)
    {
      string str;
      if (!nID.Equals(0))
      {
        if (!PLLawyer.bRead)
          PLLawyer.ReadTable();
        str = PLLawyer.m_MapIDtoNN == null ? "" : (PLLawyer.m_MapIDtoNN.ContainsKey(nID) ? PLLawyer.m_MapIDtoNN[nID].ToString() : "");
      }
      else
        str = "";
      return str;
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLLawyer.bRead)
          PLLawyer.ReadTable();
        if (PLLawyer.m_MapPLIDtoQBID == null)
          num1 = 0;
        else if (PLLawyer.m_MapPLIDtoQBID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLLawyer.m_MapPLIDtoQBID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> mapPliDtoQbid = PLLawyer.m_MapPLIDtoQBID;
            KeyValuePair<int, string> current = enumerator.Current;
            if (mapPliDtoQbid[current.Key].ToUpper().CompareTo(sQBID.ToUpper()) == 0)
            {
              current = enumerator.Current;
              num2 = current.Key;
            }
          }
          num1 = num2;
        }
        else
          num1 = 0;
      }
      else
        num1 = 0;
      return num1;
    }

    public static string GetQBIDFromPLID(int nID)
    {
      string str;
      if (!nID.Equals(0))
      {
        if (!PLLawyer.bRead)
          PLLawyer.ReadTable();
        str = PLLawyer.m_MapPLIDtoQBID == null ? "" : (PLLawyer.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLLawyer.m_MapPLIDtoQBID[nID]) : "");
      }
      else
        str = "";
      return str;
    }

    public double GetRateAmountFromRateID(int RateID)
    {
      double num1 = 0.0;
      int num2 = 0;
      double num3;
      if (this.m_RateArr != null)
      {
        for (int index = 0; index < this.m_RateArr.Count; ++index)
        {
          if (this.m_RateArr[index].RateID == RateID && this.m_RateArr[index].RateDate >= num2)
          {
            num2 = this.m_RateArr[index].RateDate;
            num1 = this.m_RateArr[index].RateAmount;
          }
        }
        num3 = num1;
      }
      else
        num3 = 0.0;
      return num3;
    }

    public override void GetRecord()
    {
      base.GetRecord();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "RateID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_RateID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_RateAmt.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_RateDate.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddRate(this.m_RateID.nValue, this.m_RateAmt.dValue, this.m_RateDate.nValue);
        this.m_RateID.Clear();
        this.m_RateAmt.Clear();
        this.m_RateDate.Clear();
      }
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "Lawyer";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.BOOL, "LawyerHasPartnerAccts");
      CPostItem cpostItem2 = cpostItem1;
      this.m_IsPartner = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "LawyerID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      this.sIDLinkName = "LawyerID";
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "LawyerInitials");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Initials = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "LawyerName");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Name = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "LawyerNickName");
      CPostItem cpostItem10 = cpostItem9;
      this.m_NickName = cpostItem9;
      postItems5.Add(cpostItem10);
      this.sNicknameLinkName = "LawyerNickName";
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "LawyerStatus");
      CPostItem cpostItem12 = cpostItem11;
      this.m_Status = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "LawyerClassificationID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Classification = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "DepartmentID");
      CPostItem cpostItem16 = cpostItem15;
      this.m_DepartmentID = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.BOOL, "LawyerDiaryActive");
      CPostItem cpostItem18 = cpostItem17;
      this.m_DiaryActive = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, "LawyerMemberNum");
      CPostItem cpostItem20 = cpostItem19;
      this.m_MembershipNumber = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "LawyerLegalAidNumber");
      CPostItem cpostItem22 = cpostItem21;
      this.m_LegalAidNumber = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "LawyerICBCNumber");
      CPostItem cpostItem24 = cpostItem23;
      this.m_ICBCNumber = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "LawyerStateTaxNumber");
      CPostItem cpostItem26 = cpostItem25;
      this.m_StateTaxNumber = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "LawyerFedTaxNumber");
      CPostItem cpostItem28 = cpostItem27;
      this.m_FedTaxNumber = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "LawyerAttorneyGeneralNumber");
      CPostItem cpostItem30 = cpostItem29;
      this.m_AttorneyGeneralNumber = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.LONG, "LawyerFlags");
      CPostItem cpostItem32 = cpostItem31;
      this.m_Flags = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.LONG, "LawyerTransactionChangeID");
      CPostItem cpostItem34 = cpostItem33;
      this.m_TransactionChgID = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.LONG, "LawyerTransNewID");
      CPostItem cpostItem36 = cpostItem35;
      this.m_TransactionNewID = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "LawyerQuickBooksID");
      CPostItem cpostItem38 = cpostItem37;
      this.m_QuickBooksID = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.RepeatLONG, "RateID");
      CPostItem cpostItem40 = cpostItem39;
      this.m_RateID = cpostItem39;
      postItems20.Add(cpostItem40);
      this.m_RateAmt = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "LawyerInternalRate");
      this.m_RateDate = new CPostItem(CPostItem.DataType.RepeatLONG, "LawyerRateStartDate");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      this.m_RateArr = new List<PLLawyer.LawyerRate>();
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLLawyer.bRead)
        PLLawyer.ReadTable();
      string str = this.MakeListNN(this.Name, PLLawyer.m_NNs, (short) 4);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLLawyer.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      string empty = string.Empty;
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Lawyer", 0, 0, 0U);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "LawyerStatus", "", ref szValue);
        int int32 = Convert.ToInt32(szValue.ToString().ToUpper().Trim());
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "LawyerNickName", "", ref szValue);
        string str1 = szValue.ToString().ToUpper().Trim();
        if (int32 <= 0 || (str1.ToLower() == "it~" ? 0 : (str1.ToLower() != "int~" ? 1 : 0)) == 0)
        {
          int recordFieldValueI32_1 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "LawyerID");
          int recordFieldValueI32_2 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "LawyerFeesAccountID");
          PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "LawyerQuickBooksID", "", ref szValue);
          string str2 = szValue.ToString().ToUpper().Trim();
          PLLawyer.AddMapNNtoID(str1, recordFieldValueI32_1);
          PLLawyer.AddMapIDtoNN(recordFieldValueI32_1, str1);
          PLLawyer.AddMapPLIDtoGLID(recordFieldValueI32_1, recordFieldValueI32_2);
          PLLawyer.AddNicknameToList(str1);
          if (!str2.Equals(""))
            PLLawyer.AddMapPLIDtoQBID(recordFieldValueI32_1, str2);
        }
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLLawyer.bRead = true;
    }

    public override void Send()
    {
      object nProcessed = new object();
      object nExceptions = new object();
      object vunIDCreated = new object();
      object nExceptionError = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      object szValue = new object();
      string szDefault = "";
      this.m_lSendErrorCount = 0L;
      string str1;
      string str2;
      string str3;
      string str4;
      string str5;
      string str6;
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      }
      catch (AccessViolationException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("AccessViolationException Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (FormatException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("Format Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("Catch All Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
        return;
      }
      try
      {
        short int16_1 = Convert.ToInt16(nProcessed);
        short int16_2 = Convert.ToInt16(nExceptions);
        PLXMLData.m_lErrorCount += (long) int16_2;
        if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        {
          this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
          PLLawyer plLawyer = this;
          plLawyer.m_lSendErrorCount = plLawyer.m_lSendErrorCount + 1L;
        }
        while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
        {
          if (Convert.ToInt32(nExceptionError) <= 0)
          {
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
            PLLawyer.AddMapExtID1toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
            this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
            PLLawyer.AddMapExtID2toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
            PLGLAccts plglAccts = new PLGLAccts();
            plglAccts.AddFilter("LawyerID", PLXMLData.eFilterCompare.EQ, vunIDCreated.ToString(), 1);
            while (plglAccts.GetNextRecord() == 0)
            {
              PLGLAccts.AddMapNNtoID(plglAccts.NickName, plglAccts.ID);
              PLGLAccts.AddMapIDtoNN(plglAccts.ID, plglAccts.NickName);
            }
          }
        }
        PLLawyer.ClearMapIDtoNN();
        PLLawyer.ClearMapNNtoID();
        PLLawyer.ClearMapPLIDtoGLID();
        PLLawyer.ClearMapPLIDtoQBID();
        PLLawyer.bRead = false;
        PLLawyer.ReadTable();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().LinkLog_AddLinkLogMessage("Catch All Execption: " + message);
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
      }
    }

    public enum LawyerClassification : sbyte
    {
      NullLawyerType = -1,
      SeniorPartner = 10,
      Partner = 20,
      JrPartner = 30,
      Associate = 40,
      Paralegal = 50,
      TimeKeeper = 60,
      LawClerk = 70,
      Student = 80,
    }

    private class LawyerRate
    {
      public int RateID;
      public double RateAmount;
      public int RateDate;

      public LawyerRate(int rateID, double rateAmount, int rateDate)
      {
        this.RateID = rateID;
        this.RateDate = rateDate;
        this.RateAmount = rateAmount;
      }
    }
  }
}
