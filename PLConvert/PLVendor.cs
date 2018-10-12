// Decompiled with JetBrains decompiler
// Type: PLConvert.PLVendor
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PLConvert
{
  public class PLVendor : StaticData
  {
    public static int m_nVendorNN = 0;
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapNameKeytoPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    public PLName Name;
    public PLAddress Address;
    public PLPhone Phone;
    private CPostItem m_DefExpCode;
    private CPostItem m_DefGLAcctID;
    public string DefGLAcctNN;
    private CPostItem m_US1099BoxNumber;
    private CPostItem m_US1099ID;
    private CPostItem m_US1099Type;
    private CPostItem m_AcctNum;
    private CPostItem m_ActiveFlag;
    private CPostItem m_DefGSTCat;
    private CPostItem m_DiscDays1;
    private CPostItem m_DiscPct1;
    private CPostItem m_DiscDays2;
    private CPostItem m_DiscPct2;
    private CPostItem m_DiscDays3;
    private CPostItem m_DiscPct3;
    private CPostItem m_Notes;
    private CPostItem m_Terms;
    private CPostItem m_ContactID;
    private static Dictionary<int, string> m_MapIDtoQuickBooksID;

    public string AcctNum
    {
      get
      {
        return this.m_AcctNum.sValue;
      }
      set
      {
        this.m_AcctNum.sValue = value;
      }
    }

    public bool ActiveFlag
    {
      get
      {
        return this.m_ActiveFlag.bValue;
      }
      set
      {
        this.m_ActiveFlag.SetValue(value);
      }
    }

    public int ContactID
    {
      get
      {
        return this.m_ContactID.nValue;
      }
      set
      {
        this.m_ContactID.SetValue(value);
      }
    }

    private int DefExpCodeID
    {
      get
      {
        return this.m_DefExpCode.nValue;
      }
      set
      {
        this.m_DefExpCode.SetValue(value);
      }
    }

    public string DefExpCodeNN
    {
      get
      {
        return PLExpCode.GetNNFromID(this.m_DefExpCode.nValue);
      }
      set
      {
        this.m_DefExpCode.SetValue(PLExpCode.GetIDFromNN(value));
      }
    }

    private int DefGLAcctID
    {
      get
      {
        return this.m_DefGLAcctID.nValue;
      }
      set
      {
        this.m_DefGLAcctID.SetValue(value);
      }
    }

    public int DefGSTCat
    {
      get
      {
        return this.m_DefGSTCat.nValue;
      }
      set
      {
        this.m_DefGSTCat.SetValue(value);
      }
    }

    public int DiscDays1
    {
      get
      {
        return this.m_DiscDays1.nValue;
      }
      set
      {
        this.m_DiscDays1.SetValue(value);
      }
    }

    public int DiscDays2
    {
      get
      {
        return this.m_DiscDays2.nValue;
      }
      set
      {
        this.m_DiscDays2.SetValue(value);
      }
    }

    public int DiscDays3
    {
      get
      {
        return this.m_DiscDays3.nValue;
      }
      set
      {
        this.m_DiscDays3.SetValue(value);
      }
    }

    public double DiscPct1
    {
      get
      {
        return this.m_DiscPct1.dValue;
      }
      set
      {
        this.m_DiscPct1.SetValue(value);
      }
    }

    public double DiscPct2
    {
      get
      {
        return this.m_DiscPct2.dValue;
      }
      set
      {
        this.m_DiscPct2.SetValue(value);
      }
    }

    public double DiscPct3
    {
      get
      {
        return this.m_DiscPct3.dValue;
      }
      set
      {
        this.m_DiscPct3.SetValue(value);
      }
    }

    public string Notes
    {
      get
      {
        return this.m_Notes.sValue;
      }
      set
      {
        this.m_Notes.SetValue(value);
      }
    }

    public string Terms
    {
      get
      {
        return this.m_Terms.sValue;
      }
      set
      {
        this.m_Terms.SetValue(value);
      }
    }

    public int US1099BoxNumber
    {
      get
      {
        return this.m_US1099BoxNumber.nValue;
      }
      set
      {
        this.m_US1099BoxNumber.SetValue(value);
      }
    }

    public string US1099ID
    {
      get
      {
        return this.m_US1099ID.sValue;
      }
      set
      {
        this.m_US1099ID.SetValue(value);
      }
    }

    public string US1099Type
    {
      get
      {
        return this.m_US1099Type.sValue;
      }
      set
      {
        this.m_US1099Type.SetValue(value);
      }
    }

    public PLVendor()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if (PLVendor.m_MapExtID1toPLID.ContainsKey(Key))
        return;
      PLVendor.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if (PLVendor.m_MapExtID2toPLID.ContainsKey(Key))
        return;
      PLVendor.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if (PLVendor.m_MapIDtoNN.ContainsKey(Key))
        return;
      PLVendor.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapIDtoQuickBooksID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!string.IsNullOrEmpty(Value) ? 1 : 0)) == 0)
        return;
      if (PLVendor.m_MapIDtoQuickBooksID == null)
        PLVendor.m_MapIDtoQuickBooksID = new Dictionary<int, string>();
      if (!PLVendor.m_MapIDtoQuickBooksID.ContainsKey(Key))
        PLVendor.m_MapIDtoQuickBooksID.Add(Key, Value);
    }

    public static void AddMapNameKeytoPLID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLVendor.m_MapNameKeytoPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLVendor.m_MapNameKeytoPLID.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if (PLVendor.m_MapNNtoID.ContainsKey(Key))
        return;
      PLVendor.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
      {
        ++PLVendor.m_nVendorNN;
        this.NickName = "~" + PLVendor.m_nVendorNN.ToString();
      }
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLVendor.GetIDFromNN(this.NickName) > 0)
      {
        ++PLVendor.m_nVendorNN;
        this.NickName = "~" + PLVendor.m_nVendorNN.ToString();
      }
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 6 ? 1 : 0)) != 0)
      {
        ++PLVendor.m_nVendorNN;
        this.NickName = "~" + PLVendor.m_nVendorNN.ToString();
      }
      this.Name.AddFields(this.m_hndPOST);
      this.Address.AddFields(this.m_hndPOST);
      this.Phone.AddFields(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_NickName.AddField(this.m_hndPOST);
      if (this.DefExpCodeNN.Length > 0)
      {
        int idFromNn = PLExpCode.GetIDFromNN(this.DefExpCodeNN);
        if (idFromNn > 0)
        {
          this.DefExpCodeID = idFromNn;
          this.m_DefExpCode.AddField(this.m_hndPOST);
          this.DefExpCodeNN = "";
        }
      }
      if (this.DefGLAcctNN.Length > 0)
      {
        int idFromNn = PLGLAccts.GetIDFromNN(this.DefExpCodeNN);
        if (idFromNn > 0)
        {
          this.DefGLAcctID = idFromNn;
          this.m_DefGLAcctID.AddField(this.m_hndPOST);
          this.DefGLAcctNN = "";
        }
      }
      this.m_US1099BoxNumber.AddField(this.m_hndPOST);
      this.m_US1099ID.AddField(this.m_hndPOST);
      this.m_US1099Type.AddField(this.m_hndPOST);
      this.m_AcctNum.AddField(this.m_hndPOST);
      this.m_ActiveFlag.AddField(this.m_hndPOST);
      this.m_DefGSTCat.AddField(this.m_hndPOST);
      this.m_DiscDays1.AddField(this.m_hndPOST);
      this.m_DiscPct1.AddField(this.m_hndPOST);
      this.m_DiscDays2.AddField(this.m_hndPOST);
      this.m_DiscPct2.AddField(this.m_hndPOST);
      this.m_DiscDays3.AddField(this.m_hndPOST);
      this.m_DiscPct3.AddField(this.m_hndPOST);
      this.m_Notes.AddField(this.m_hndPOST);
      this.m_Terms.AddField(this.m_hndPOST);
      this.m_QuickBooksID.AddField(this.m_hndPOST);
      this.m_ContactID.AddField(this.m_hndPOST);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLVendor plVendor = this;
      plVendor.m_lCounter = plVendor.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.Name.Clear();
      this.Address.Clear();
      this.Phone.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLVendor.m_MapExtID1toPLID == null)
        return;
      PLVendor.m_MapExtID1toPLID.Clear();
      PLVendor.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLVendor.m_MapExtID2toPLID == null)
        return;
      PLVendor.m_MapExtID2toPLID.Clear();
      PLVendor.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLVendor.m_MapIDtoNN == null)
        return;
      PLVendor.m_MapIDtoNN.Clear();
      PLVendor.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapIDtoQuickBooksID()
    {
      if (PLVendor.m_MapIDtoQuickBooksID == null)
        return;
      PLVendor.m_MapIDtoQuickBooksID.Clear();
      PLVendor.m_MapIDtoQuickBooksID = (Dictionary<int, string>) null;
    }

    public static void ClearMapNameKeytoPLID()
    {
      if (PLVendor.m_MapNameKeytoPLID == null)
        return;
      PLVendor.m_MapNameKeytoPLID.Clear();
      PLVendor.m_MapNameKeytoPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLVendor.m_MapNNtoID == null)
        return;
      PLVendor.m_MapNNtoID.Clear();
      PLVendor.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      this.Name.GetExistingRecord(this.m_hndExisting);
      this.Address.GetExistingRecord(this.m_hndExisting);
      this.Phone.GetExistingRecord(this.m_hndExisting);
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndExisting);
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLVendor.m_MapExtID1toPLID == null ? 0 : (PLVendor.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLVendor.m_MapExtID1toPLID[Key]) : 0);
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLVendor.m_MapExtID2toPLID == null ? 0 : (PLVendor.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLVendor.m_MapExtID2toPLID[Key]) : 0);
    }

    public static int GetIDFromNameKey(string Key)
    {
      if (!PLVendor.bRead)
        PLVendor.ReadTable();
      Key = Key.ToUpper();
      return (PLVendor.m_MapNameKeytoPLID.Count == 0 ? 0 : (PLVendor.m_MapNameKeytoPLID.ContainsKey(Key) ? 1 : 0)) != 0 ? Convert.ToInt32(PLVendor.m_MapNameKeytoPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLVendor.bRead)
        PLVendor.ReadTable();
      Key = Key.ToUpper();
      return (Key.Equals("") ? 0 : (PLVendor.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) != 0 ? Convert.ToInt32(PLVendor.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int Key)
    {
      if (!PLVendor.bRead)
        PLVendor.ReadTable();
      return (Key.Equals(0) ? 0 : (PLVendor.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) != 0 ? PLVendor.m_MapIDtoNN[Key].ToString() : "";
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLVendor.bRead)
          PLVendor.ReadTable();
        if (PLVendor.m_MapIDtoQuickBooksID == null)
          num1 = 0;
        else if (PLVendor.m_MapIDtoQuickBooksID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLVendor.m_MapIDtoQuickBooksID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> idtoQuickBooksId = PLVendor.m_MapIDtoQuickBooksID;
            KeyValuePair<int, string> current = enumerator.Current;
            if (idtoQuickBooksId[current.Key].ToUpper().CompareTo(sQBID.ToUpper()) == 0)
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

    public static string GetQuickBooksIDFromID(int Key)
    {
      string str;
      if (!Key.Equals(0))
      {
        if (!PLVendor.bRead)
          PLVendor.ReadTable();
        str = PLVendor.m_MapIDtoQuickBooksID == null ? string.Empty : (PLVendor.m_MapIDtoQuickBooksID.ContainsKey(Key) ? Convert.ToString(PLVendor.m_MapIDtoQuickBooksID[Key]) : string.Empty);
      }
      else
        str = string.Empty;
      return str;
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.Name.GetRecord(this.m_hndGET);
      this.Address.GetRecord(this.m_hndGET);
      this.Phone.GetRecord(this.m_hndGET);
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Vendor";
      this.Name = new PLName(PLName.eNameType.VENDOR);
      this.Address = new PLAddress(PLAddress.eAddType.VENDOR);
      this.Phone = new PLPhone(PLPhone.ePhoneType.VENDOR);
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "VendorID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "VendorStatus");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Status = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "VendorNickName");
      CPostItem cpostItem6 = cpostItem5;
      this.m_NickName = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "DefExplCodeID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_DefExpCode = cpostItem7;
      postItems4.Add(cpostItem8);
      this.DefExpCodeNN = "";
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "DefGLAcctID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_DefGLAcctID = cpostItem9;
      postItems5.Add(cpostItem10);
      this.DefGLAcctNN = "";
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "Vendor1099BoxNum");
      CPostItem cpostItem12 = cpostItem11;
      this.m_US1099BoxNumber = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "Vendor1099ID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_US1099ID = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.STRING, "Vendor1099Type");
      CPostItem cpostItem16 = cpostItem15;
      this.m_US1099Type = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "VendorAcctNum");
      CPostItem cpostItem18 = cpostItem17;
      this.m_AcctNum = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.BOOL, "VendorActiveFlag");
      CPostItem cpostItem20 = cpostItem19;
      this.m_ActiveFlag = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "VendorDefGSTCat");
      CPostItem cpostItem22 = cpostItem21;
      this.m_DefGSTCat = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "VendorDiscDays1");
      CPostItem cpostItem24 = cpostItem23;
      this.m_DiscDays1 = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.DOUBLE, "VendorDiscPct1");
      CPostItem cpostItem26 = cpostItem25;
      this.m_DiscPct1 = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.LONG, "VendorDiscDays2");
      CPostItem cpostItem28 = cpostItem27;
      this.m_DiscDays2 = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.DOUBLE, "VendorDiscPct2");
      CPostItem cpostItem30 = cpostItem29;
      this.m_DiscPct2 = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.LONG, "VendorDiscDays3");
      CPostItem cpostItem32 = cpostItem31;
      this.m_DiscDays3 = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.DOUBLE, "VendorDiscPct3");
      CPostItem cpostItem34 = cpostItem33;
      this.m_DiscPct3 = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "VendorNotes");
      CPostItem cpostItem36 = cpostItem35;
      this.m_Notes = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "VendorTerms");
      CPostItem cpostItem38 = cpostItem37;
      this.m_Terms = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.LONG, "VendorTransactionChange");
      CPostItem cpostItem40 = cpostItem39;
      this.m_TransactionChgID = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.LONG, "VendorTransactionNew");
      CPostItem cpostItem42 = cpostItem41;
      this.m_TransactionNewID = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "VendorQuickBooksID");
      CPostItem cpostItem44 = cpostItem43;
      this.m_QuickBooksID = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.LONG, "VendorPersonContactID");
      CPostItem cpostItem46 = cpostItem45;
      this.m_ContactID = cpostItem45;
      postItems23.Add(cpostItem46);
      List<CPostItem> postItems24 = this.PostItems;
      CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.STRING, "VendorExternalID1");
      CPostItem cpostItem48 = cpostItem47;
      this.m_ExternalID_1 = cpostItem47;
      postItems24.Add(cpostItem48);
      List<CPostItem> postItems25 = this.PostItems;
      CPostItem cpostItem49 = new CPostItem(CPostItem.DataType.STRING, "VendorExternalID2");
      CPostItem cpostItem50 = cpostItem49;
      this.m_ExternalID_2 = cpostItem49;
      postItems25.Add(cpostItem50);
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLVendor.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      string empty = string.Empty;
      string szText = "VendorID|VendorNickName|VendorQuickBooksID";
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Vendor", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "VendorStatus", "EQ", "0", 1);
      PLLink.GetLink().TableGET_AddDirective(createHandle, "FieldList", szText);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "VendorNickName", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "VendorID");
        PLVendor.AddMapIDtoNN(recordFieldValueI32, Key);
        PLVendor.AddMapNNtoID(Key, recordFieldValueI32);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "VendorQuickBooksID", "", ref szValue);
        if (!szValue.ToString().ToUpper().Trim().Equals(""))
          PLVendor.AddMapIDtoQuickBooksID(recordFieldValueI32, szValue.ToString());
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLVendor.bRead = true;
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
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      }
      catch (Exception ex)
      {
        string str1 = ex.Data == null ? "" : ex.Data.ToString();
        string str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        string str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        string message = ex.Message;
        string str4 = ex.Source == null ? "" : ex.Source.ToString();
        string str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        string str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
        return;
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLVendor plVendor = this;
        plVendor.m_lSendErrorCount = plVendor.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLVendor.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          PLVendor.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLVendor.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLVendor.AddMapExtID2toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "NameKey", szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLVendor.AddMapNameKeytoPLID(szValue.ToString().Trim(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_QuickBooksID.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLVendor.AddMapIDtoQuickBooksID(int32, szValue.ToString());
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
