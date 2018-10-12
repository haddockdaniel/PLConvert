// Decompiled with JetBrains decompiler
// Type: PLConvert.PLName
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLName : StaticData
  {
    private static string[] CorpWordsStartsWith = new string[8]
    {
      "USA ",
      "U.S.A. ",
      "USA, ",
      "The ",
      "Value ",
      "Canada ",
      "Canadian",
      "Court "
    };
    private static string[] CorpWordsEndsWith = new string[19]
    {
      "Ltd",
      "Limited",
      " Inc",
      " Inc.",
      "Incorporated",
      " Corp",
      "Co.",
      " Co",
      " Compan",
      "LLC",
      "L.L.C.",
      "LLP",
      "L.L.P",
      "PLC",
      "P.L.C.",
      " Value",
      "P.C.",
      " Court",
      "PC"
    };
    private static string[] CorpWords = new string[183]
    {
      "Ltd",
      "Limited",
      " Inc",
      "Incorporated",
      " Corp",
      "Co.",
      " Co ",
      " Compan",
      "LLC",
      "L.L.C.",
      "LLP",
      "L.L.P",
      "PLC",
      "P.L.C.",
      " PC",
      " Charter",
      " Account",
      "Probate",
      "Public",
      " Value ",
      "Division",
      "Div.",
      "Const.",
      "Construction",
      "Manufactur",
      "Production",
      "Court ",
      "Court,",
      " Assoc",
      "Assn",
      "Group",
      "Society",
      "Foundation",
      " Club",
      "Coalition",
      "Federation",
      "United",
      "League",
      "Estate",
      "Memorial",
      "Alliance",
      "Union",
      "Commission",
      "Amalgamat",
      "Director",
      "Executive",
      "Health",
      "Benefit",
      "Serivce",
      "Transit",
      "Energy",
      "Control",
      "Deputy",
      "Sheriff ",
      " Village ",
      " Town ",
      " City ",
      " County ",
      " Region ",
      " District ",
      " State ",
      " Province ",
      "Canada",
      "Canadian",
      "America",
      "U.S.",
      "Federal",
      "National",
      "International",
      "Intl",
      "Realty",
      "Realtor",
      "Ins.",
      "Insurance",
      "Medical",
      " Condo",
      "Metropolitan",
      "Metro.",
      " Metro ",
      "Mutual",
      "Casualty",
      "Underwriter",
      " Auto ",
      " Fire ",
      "Fidelity",
      "Business",
      "Develplment",
      "Financ",
      "Communication",
      "Motors",
      "Advertis",
      "Industr",
      "Electric",
      " Gas ",
      "Legal",
      "Lawyer",
      "Educat",
      "Tavern",
      "Advocate",
      ".com",
      ".org",
      ".edu",
      "Mortgage",
      "Trust",
      "Bank ",
      "Securit",
      "Offic",
      " Fund ",
      "University",
      "College",
      "Academy",
      "Authority",
      "Service",
      "Holding",
      "Express",
      "Xpress",
      "Special",
      "Admin",
      "Discover",
      "Chemical",
      "Reporting",
      "Credit",
      "Counsel",
      " Times ",
      "Township",
      "Phone",
      "Guide",
      "Bankruptcy",
      "Network",
      " Law ",
      "School",
      "News",
      "Citizen",
      "Independant",
      "Northwest",
      "Northeast",
      "Northern",
      "Eastern",
      "Western",
      "Southern",
      "Market",
      "Hospital",
      "Lexis",
      "Nexis",
      "'s",
      "Center",
      "Centre",
      "Deluxe",
      "Univers",
      "County",
      "Courier",
      " Depot",
      "Design",
      "Laborator",
      "Consult",
      "Football",
      "Freeway",
      "Highway",
      "HWY",
      "General",
      "Dollar",
      "Hardware",
      "Software",
      "Coffee",
      "Bakery",
      " Of ",
      "1",
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9",
      "0",
      "#",
      "(",
      ")",
      " v ",
      " v. ",
      " Vs ",
      " Vs. "
    };
    private static string[] PrefixWords = new string[21]
    {
      "Mr.",
      "Mrs.",
      "Dr.",
      "Ms.",
      "Hon.",
      "Rt. Hon.",
      "Mlle.",
      "Mme.",
      "Prof.",
      "Mr",
      "Mrs",
      "Dr",
      "Ms",
      "Hon",
      "Rt Hon",
      "Mlle",
      "Mme",
      "Prof",
      "Miss",
      "Sir",
      "Reverend"
    };
    private static string[] SuffixWords = new string[15]
    {
      "Jr.",
      "Jr",
      "Sr.",
      "Sr",
      " III",
      " II",
      " I",
      " IV",
      "M.D.",
      "MD",
      "CPA",
      "C.P.A",
      "Esq",
      "Esq.",
      "Esquire"
    };
    private CPostItem m_Title;
    private CPostItem m_First;
    private CPostItem m_Middle;
    private CPostItem m_Last;
    private CPostItem m_Suffix;
    private CPostItem m_Company;
    private CPostItem m_AttnPos;
    private CPostItem m_IsCorp;
    private string m_LastFirst;
    private string m_FirstLast;
    private CPostItem m_DisplayName;
    private CPostItem m_NameKey;

    public string Company
    {
      get
      {
        return this.m_Company.sValue;
      }
      set
      {
        this.m_Company.SetValue(value);
      }
    }

    public string DisplayName
    {
      get
      {
        return this.m_DisplayName.sValue;
      }
    }

    public string First
    {
      get
      {
        return this.m_First.sValue;
      }
      set
      {
        this.m_First.SetValue(value);
      }
    }

    public string FirstLast
    {
      get
      {
        return this.m_FirstLast;
      }
      set
      {
        this.Clear();
        this.m_FirstLast = value;
        this.ParseName();
      }
    }

    public bool IsCorp
    {
      get
      {
        return this.m_IsCorp.bValue;
      }
      set
      {
        this.m_IsCorp.SetValue(value);
      }
    }

    public string Last
    {
      get
      {
        return this.m_Last.sValue;
      }
      set
      {
        this.m_Last.SetValue(value);
      }
    }

    public string LastFirst
    {
      get
      {
        return this.m_LastFirst;
      }
      set
      {
        this.Clear();
        this.m_LastFirst = value;
        this.ParseName();
      }
    }

    public string Middle
    {
      get
      {
        return this.m_Middle.sValue;
      }
      set
      {
        this.m_Middle.SetValue(value);
      }
    }

    public string NameKey
    {
      get
      {
        return this.m_NameKey.sValue;
      }
    }

    public string Position
    {
      get
      {
        return this.m_AttnPos.sValue;
      }
      set
      {
        this.m_AttnPos.SetValue(value);
      }
    }

    public string Suffix
    {
      get
      {
        return this.m_Suffix.sValue;
      }
      set
      {
        this.m_Suffix.SetValue(value);
      }
    }

    public string Title
    {
      get
      {
        return this.m_Title.sValue;
      }
      set
      {
        this.m_Title.SetValue(value);
      }
    }

    public PLName()
    {
    }

    public PLName(PLName.eNameType NT)
    {
      this.Initialize(NT);
    }

    public void AddFields(uint handle)
    {
      this.m_hndPOST = handle;
      this.AddRecord();
    }

    public override void AddRecord()
    {
      this.MakeNameKey();
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
      this.m_NameKey.AddField(this.m_hndPOST);
      this.m_LastFirst = string.Empty;
      this.m_FirstLast = string.Empty;
    }

    public override void Clear()
    {
      base.Clear();
      this.m_NameKey.Clear();
      this.m_LastFirst = string.Empty;
      this.m_FirstLast = string.Empty;
    }

    public void GetExistingRecord(uint handle)
    {
      this.m_hndExisting = handle;
      this.GetExistingRecord();
    }

    public override void GetExistingRecord()
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndExisting);
      this.MakeNameKey();
    }

    private static int GetIDFromNN(string sNN)
    {
      return 0;
    }

    public void GetRecord(uint handle)
    {
      this.m_hndGET = handle;
      this.GetRecord();
    }

    public override void GetRecord()
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
      this.MakeNameKey();
    }

    private void Initialize(PLName.eNameType NT)
    {
      switch (NT)
      {
        case PLName.eNameType.CLIENT:
          List<CPostItem> postItems1 = this.PostItems;
          CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.STRING, "ClientTitle");
          CPostItem cpostItem2 = cpostItem1;
          this.m_Title = cpostItem1;
          postItems1.Add(cpostItem2);
          List<CPostItem> postItems2 = this.PostItems;
          CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "ClientFirstName");
          CPostItem cpostItem4 = cpostItem3;
          this.m_First = cpostItem3;
          postItems2.Add(cpostItem4);
          List<CPostItem> postItems3 = this.PostItems;
          CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "ClientInitial");
          CPostItem cpostItem6 = cpostItem5;
          this.m_Middle = cpostItem5;
          postItems3.Add(cpostItem6);
          List<CPostItem> postItems4 = this.PostItems;
          CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "ClientLastName");
          CPostItem cpostItem8 = cpostItem7;
          this.m_Last = cpostItem7;
          postItems4.Add(cpostItem8);
          List<CPostItem> postItems5 = this.PostItems;
          CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "ClientSuffix");
          CPostItem cpostItem10 = cpostItem9;
          this.m_Suffix = cpostItem9;
          postItems5.Add(cpostItem10);
          List<CPostItem> postItems6 = this.PostItems;
          CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "ClientCompany");
          CPostItem cpostItem12 = cpostItem11;
          this.m_Company = cpostItem11;
          postItems6.Add(cpostItem12);
          List<CPostItem> postItems7 = this.PostItems;
          CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "ClientAttnPos");
          CPostItem cpostItem14 = cpostItem13;
          this.m_AttnPos = cpostItem13;
          postItems7.Add(cpostItem14);
          List<CPostItem> postItems8 = this.PostItems;
          CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.BOOL, "ClientIsCorpClnt");
          CPostItem cpostItem16 = cpostItem15;
          this.m_IsCorp = cpostItem15;
          postItems8.Add(cpostItem16);
          List<CPostItem> postItems9 = this.PostItems;
          CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "ClientName");
          CPostItem cpostItem18 = cpostItem17;
          this.m_DisplayName = cpostItem17;
          postItems9.Add(cpostItem18);
          break;
        case PLName.eNameType.CLNT_onMAT:
          List<CPostItem> postItems10 = this.PostItems;
          CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, "ClientTitle");
          CPostItem cpostItem20 = cpostItem19;
          this.m_Title = cpostItem19;
          postItems10.Add(cpostItem20);
          List<CPostItem> postItems11 = this.PostItems;
          CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "ClientFirstName");
          CPostItem cpostItem22 = cpostItem21;
          this.m_First = cpostItem21;
          postItems11.Add(cpostItem22);
          List<CPostItem> postItems12 = this.PostItems;
          CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "ClientInitial");
          CPostItem cpostItem24 = cpostItem23;
          this.m_Middle = cpostItem23;
          postItems12.Add(cpostItem24);
          List<CPostItem> postItems13 = this.PostItems;
          CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "ClientLastName");
          CPostItem cpostItem26 = cpostItem25;
          this.m_Last = cpostItem25;
          postItems13.Add(cpostItem26);
          List<CPostItem> postItems14 = this.PostItems;
          CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "ClientSuffix");
          CPostItem cpostItem28 = cpostItem27;
          this.m_Suffix = cpostItem27;
          postItems14.Add(cpostItem28);
          List<CPostItem> postItems15 = this.PostItems;
          CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "ClientCompany");
          CPostItem cpostItem30 = cpostItem29;
          this.m_Company = cpostItem29;
          postItems15.Add(cpostItem30);
          List<CPostItem> postItems16 = this.PostItems;
          CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem32 = cpostItem31;
          this.m_AttnPos = cpostItem31;
          postItems16.Add(cpostItem32);
          List<CPostItem> postItems17 = this.PostItems;
          CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.BOOL, "ClientIsCorp");
          CPostItem cpostItem34 = cpostItem33;
          this.m_IsCorp = cpostItem33;
          postItems17.Add(cpostItem34);
          List<CPostItem> postItems18 = this.PostItems;
          CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "ClientDisplayAs");
          CPostItem cpostItem36 = cpostItem35;
          this.m_DisplayName = cpostItem35;
          postItems18.Add(cpostItem36);
          break;
        case PLName.eNameType.MAT_BILL1:
          List<CPostItem> postItems19 = this.PostItems;
          CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "BillingTitle");
          CPostItem cpostItem38 = cpostItem37;
          this.m_Title = cpostItem37;
          postItems19.Add(cpostItem38);
          List<CPostItem> postItems20 = this.PostItems;
          CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.STRING, "BillingFirstName");
          CPostItem cpostItem40 = cpostItem39;
          this.m_First = cpostItem39;
          postItems20.Add(cpostItem40);
          List<CPostItem> postItems21 = this.PostItems;
          CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.STRING, "BillingInitial");
          CPostItem cpostItem42 = cpostItem41;
          this.m_Middle = cpostItem41;
          postItems21.Add(cpostItem42);
          List<CPostItem> postItems22 = this.PostItems;
          CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "BillingLastName");
          CPostItem cpostItem44 = cpostItem43;
          this.m_Last = cpostItem43;
          postItems22.Add(cpostItem44);
          List<CPostItem> postItems23 = this.PostItems;
          CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.STRING, "BillingSuffix");
          CPostItem cpostItem46 = cpostItem45;
          this.m_Suffix = cpostItem45;
          postItems23.Add(cpostItem46);
          List<CPostItem> postItems24 = this.PostItems;
          CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.STRING, "BillingCompany");
          CPostItem cpostItem48 = cpostItem47;
          this.m_Company = cpostItem47;
          postItems24.Add(cpostItem48);
          List<CPostItem> postItems25 = this.PostItems;
          CPostItem cpostItem49 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem50 = cpostItem49;
          this.m_AttnPos = cpostItem49;
          postItems25.Add(cpostItem50);
          List<CPostItem> postItems26 = this.PostItems;
          CPostItem cpostItem51 = new CPostItem(CPostItem.DataType.BOOL, "BillingIsCorp");
          CPostItem cpostItem52 = cpostItem51;
          this.m_IsCorp = cpostItem51;
          postItems26.Add(cpostItem52);
          List<CPostItem> postItems27 = this.PostItems;
          CPostItem cpostItem53 = new CPostItem(CPostItem.DataType.STRING, "Not_in_use_here");
          CPostItem cpostItem54 = cpostItem53;
          this.m_DisplayName = cpostItem53;
          postItems27.Add(cpostItem54);
          break;
        case PLName.eNameType.MAT_BILL2:
          List<CPostItem> postItems28 = this.PostItems;
          CPostItem cpostItem55 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingTitle");
          CPostItem cpostItem56 = cpostItem55;
          this.m_Title = cpostItem55;
          postItems28.Add(cpostItem56);
          List<CPostItem> postItems29 = this.PostItems;
          CPostItem cpostItem57 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingFirstName");
          CPostItem cpostItem58 = cpostItem57;
          this.m_First = cpostItem57;
          postItems29.Add(cpostItem58);
          List<CPostItem> postItems30 = this.PostItems;
          CPostItem cpostItem59 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingInitial");
          CPostItem cpostItem60 = cpostItem59;
          this.m_Middle = cpostItem59;
          postItems30.Add(cpostItem60);
          List<CPostItem> postItems31 = this.PostItems;
          CPostItem cpostItem61 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingLastName");
          CPostItem cpostItem62 = cpostItem61;
          this.m_Last = cpostItem61;
          postItems31.Add(cpostItem62);
          List<CPostItem> postItems32 = this.PostItems;
          CPostItem cpostItem63 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingSuffix");
          CPostItem cpostItem64 = cpostItem63;
          this.m_Suffix = cpostItem63;
          postItems32.Add(cpostItem64);
          List<CPostItem> postItems33 = this.PostItems;
          CPostItem cpostItem65 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingCompany");
          CPostItem cpostItem66 = cpostItem65;
          this.m_Company = cpostItem65;
          postItems33.Add(cpostItem66);
          List<CPostItem> postItems34 = this.PostItems;
          CPostItem cpostItem67 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem68 = cpostItem67;
          this.m_AttnPos = cpostItem67;
          postItems34.Add(cpostItem68);
          List<CPostItem> postItems35 = this.PostItems;
          CPostItem cpostItem69 = new CPostItem(CPostItem.DataType.BOOL, "SecondBillingIsCorp");
          CPostItem cpostItem70 = cpostItem69;
          this.m_IsCorp = cpostItem69;
          postItems35.Add(cpostItem70);
          List<CPostItem> postItems36 = this.PostItems;
          CPostItem cpostItem71 = new CPostItem(CPostItem.DataType.STRING, "Not_in_use_here");
          CPostItem cpostItem72 = cpostItem71;
          this.m_DisplayName = cpostItem71;
          postItems36.Add(cpostItem72);
          break;
        case PLName.eNameType.VENDOR:
          List<CPostItem> postItems37 = this.PostItems;
          CPostItem cpostItem73 = new CPostItem(CPostItem.DataType.STRING, "VendorNameTitle");
          CPostItem cpostItem74 = cpostItem73;
          this.m_Title = cpostItem73;
          postItems37.Add(cpostItem74);
          List<CPostItem> postItems38 = this.PostItems;
          CPostItem cpostItem75 = new CPostItem(CPostItem.DataType.STRING, "VendorNameFirst");
          CPostItem cpostItem76 = cpostItem75;
          this.m_First = cpostItem75;
          postItems38.Add(cpostItem76);
          List<CPostItem> postItems39 = this.PostItems;
          CPostItem cpostItem77 = new CPostItem(CPostItem.DataType.STRING, "VendorNameMiddle");
          CPostItem cpostItem78 = cpostItem77;
          this.m_Middle = cpostItem77;
          postItems39.Add(cpostItem78);
          List<CPostItem> postItems40 = this.PostItems;
          CPostItem cpostItem79 = new CPostItem(CPostItem.DataType.STRING, "VendorNameLast");
          CPostItem cpostItem80 = cpostItem79;
          this.m_Last = cpostItem79;
          postItems40.Add(cpostItem80);
          List<CPostItem> postItems41 = this.PostItems;
          CPostItem cpostItem81 = new CPostItem(CPostItem.DataType.STRING, "VendorNameSuffix");
          CPostItem cpostItem82 = cpostItem81;
          this.m_Suffix = cpostItem81;
          postItems41.Add(cpostItem82);
          List<CPostItem> postItems42 = this.PostItems;
          CPostItem cpostItem83 = new CPostItem(CPostItem.DataType.STRING, "VendorCompany");
          CPostItem cpostItem84 = cpostItem83;
          this.m_Company = cpostItem83;
          postItems42.Add(cpostItem84);
          List<CPostItem> postItems43 = this.PostItems;
          CPostItem cpostItem85 = new CPostItem(CPostItem.DataType.STRING, "VendorAttnPos");
          CPostItem cpostItem86 = cpostItem85;
          this.m_AttnPos = cpostItem85;
          postItems43.Add(cpostItem86);
          List<CPostItem> postItems44 = this.PostItems;
          CPostItem cpostItem87 = new CPostItem(CPostItem.DataType.BOOL, "VendorIsCorpVendor");
          CPostItem cpostItem88 = cpostItem87;
          this.m_IsCorp = cpostItem87;
          postItems44.Add(cpostItem88);
          List<CPostItem> postItems45 = this.PostItems;
          CPostItem cpostItem89 = new CPostItem(CPostItem.DataType.STRING, "VendorName");
          CPostItem cpostItem90 = cpostItem89;
          this.m_DisplayName = cpostItem89;
          postItems45.Add(cpostItem90);
          break;
        case PLName.eNameType.CONTACT:
          List<CPostItem> postItems46 = this.PostItems;
          CPostItem cpostItem91 = new CPostItem(CPostItem.DataType.STRING, "ContactTitle");
          CPostItem cpostItem92 = cpostItem91;
          this.m_Title = cpostItem91;
          postItems46.Add(cpostItem92);
          List<CPostItem> postItems47 = this.PostItems;
          CPostItem cpostItem93 = new CPostItem(CPostItem.DataType.STRING, "ContactFirstName");
          CPostItem cpostItem94 = cpostItem93;
          this.m_First = cpostItem93;
          postItems47.Add(cpostItem94);
          List<CPostItem> postItems48 = this.PostItems;
          CPostItem cpostItem95 = new CPostItem(CPostItem.DataType.STRING, "ContactMiddleName");
          CPostItem cpostItem96 = cpostItem95;
          this.m_Middle = cpostItem95;
          postItems48.Add(cpostItem96);
          List<CPostItem> postItems49 = this.PostItems;
          CPostItem cpostItem97 = new CPostItem(CPostItem.DataType.STRING, "ContactLastName");
          CPostItem cpostItem98 = cpostItem97;
          this.m_Last = cpostItem97;
          postItems49.Add(cpostItem98);
          List<CPostItem> postItems50 = this.PostItems;
          CPostItem cpostItem99 = new CPostItem(CPostItem.DataType.STRING, "ContactSuffix");
          CPostItem cpostItem100 = cpostItem99;
          this.m_Suffix = cpostItem99;
          postItems50.Add(cpostItem100);
          List<CPostItem> postItems51 = this.PostItems;
          CPostItem cpostItem101 = new CPostItem(CPostItem.DataType.STRING, "ContactCompany");
          CPostItem cpostItem102 = cpostItem101;
          this.m_Company = cpostItem101;
          postItems51.Add(cpostItem102);
          List<CPostItem> postItems52 = this.PostItems;
          CPostItem cpostItem103 = new CPostItem(CPostItem.DataType.STRING, "ContactPosition");
          CPostItem cpostItem104 = cpostItem103;
          this.m_AttnPos = cpostItem103;
          postItems52.Add(cpostItem104);
          List<CPostItem> postItems53 = this.PostItems;
          CPostItem cpostItem105 = new CPostItem(CPostItem.DataType.BOOL, "ContactIsCorporation");
          CPostItem cpostItem106 = cpostItem105;
          this.m_IsCorp = cpostItem105;
          postItems53.Add(cpostItem106);
          List<CPostItem> postItems54 = this.PostItems;
          CPostItem cpostItem107 = new CPostItem(CPostItem.DataType.STRING, "ContactName");
          CPostItem cpostItem108 = cpostItem107;
          this.m_DisplayName = cpostItem107;
          postItems54.Add(cpostItem108);
          break;
      }
      this.m_NameKey = new CPostItem(CPostItem.DataType.STRING, "NameKey");
      this.m_LastFirst = string.Empty;
      this.m_FirstLast = string.Empty;
    }

    protected override void Initialize()
    {
    }

    public static bool IsCorporation(string sName)
    {
      string[] separator = new string[1]{ " " };
      string[] strArray = sName.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      bool flag;
      if ((strArray.GetLength(0) <= 1 ? 0 : (strArray.GetLength(0) < 7 ? 1 : 0)) != 0)
      {
        foreach (string str in PLName.CorpWordsStartsWith)
        {
          if (sName.ToLower().StartsWith(str.ToLower()))
            return true;
        }
        foreach (string str in PLName.CorpWordsEndsWith)
        {
          if (sName.ToLower().EndsWith(str.ToLower()))
            return true;
        }
        foreach (string corpWord in PLName.CorpWords)
        {
          if (sName.ToLower().Contains(corpWord.ToLower()))
            return true;
        }
        if ((sName.IndexOf("&") >= 0 ? 1 : (sName.ToLower().IndexOf(" and ") >= 0 ? 1 : 0)) != 0)
        {
          switch (strArray.GetLength(0))
          {
            case 3:
              if ((strArray[1] == "&" ? 0 : (!(strArray[1].ToLower() == "and") ? 1 : 0)) == 0)
                return true;
              break;
            case 4:
              if (strArray[0].EndsWith(",") && (strArray[2] == "&" || strArray[2].ToLower() == "and"))
                return true;
              break;
            case 5:
              if (strArray[0].EndsWith(",") && strArray[1].EndsWith(",") && (strArray[3] == "&" || strArray[3].ToLower() == "and"))
                return true;
              break;
            case 6:
              if (strArray[0].EndsWith(",") && strArray[1].EndsWith(",") && strArray[2].EndsWith(",") && (strArray[4] == "&" || strArray[4].ToLower() == "and"))
                return true;
              break;
          }
          flag = false;
        }
        else
          flag = false;
      }
      else
        flag = true;
      return flag;
    }

    public void MakeNameKey()
    {
      string empty = string.Empty;
      string str;
      if (!this.IsCorp)
      {
        str = this.First + this.Middle + this.Last;
        if (string.IsNullOrEmpty(str))
          str = this.Company;
      }
      else
      {
        str = this.Company;
        if (string.IsNullOrEmpty(str))
          str = this.First + this.Middle + this.Last;
      }
      string Val = str.ToUpper().Trim().Replace(".", "");
      while (Val.IndexOf(" ") >= 0)
        Val = Val.Replace(" ", "");
      if (string.IsNullOrEmpty(Val))
        return;
      this.m_NameKey.SetValue(Val);
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    public void ParseFirstLast()
    {
      string str1 = this.FirstLast;
      if (string.IsNullOrEmpty(str1))
        this.Last = "-Name not Supplied-";
      else if ((str1.IndexOf("&") > 0 ? 0 : (str1.ToLower().IndexOf(" and ") <= 0 ? 1 : 0)) != 0)
      {
        foreach (string prefixWord in PLName.PrefixWords)
        {
          if (str1.ToUpper().StartsWith(prefixWord.ToUpper()))
          {
            this.Title = prefixWord.Trim();
            str1 = str1.Remove(0, this.Title.Length).Trim();
            if (string.IsNullOrEmpty(str1))
              return;
            break;
          }
        }
        foreach (string suffixWord in PLName.SuffixWords)
        {
          if (str1.ToUpper().EndsWith(suffixWord.ToUpper()))
          {
            this.Suffix = suffixWord.Trim().ToUpper();
            str1 = str1.Substring(0, str1.Length - suffixWord.Length);
            if (string.IsNullOrEmpty(str1))
              return;
            break;
          }
        }
        char[] anyOf = new char[7]
        {
          ',',
          '.',
          '/',
          '\\',
          ';',
          ':',
          '*'
        };
        while (str1.LastIndexOfAny(anyOf) >= 0)
          str1 = str1.Remove(str1.LastIndexOfAny(anyOf), 1).Trim();
        if (str1.IndexOf(" ") <= 0)
        {
          this.Last = str1;
        }
        else
        {
          this.First = str1.Substring(0, str1.IndexOf(" "));
          string str2 = str1.Substring(str1.IndexOf(" ")).Trim();
          if (str2.IndexOf(" ") > 0)
            this.Middle = str2.Substring(0, str2.IndexOf(" "));
          this.Last = str2.Substring(str2.IndexOf(" ") + 1);
        }
        if (!this.Last.Equals(""))
          return;
        this.Last = "-Name not Supplied-";
      }
      else
      {
        this.Last = str1.Substring(str1.LastIndexOf(" ")).Trim();
        this.First = str1.Substring(0, str1.LastIndexOf(" ")).Trim();
      }
    }

    public void ParseLastFirst()
    {
      string lastFirst = this.LastFirst;
      if (!string.IsNullOrEmpty(lastFirst))
      {
        int length = 0;
        if (length == 0)
          length = lastFirst.IndexOf(";") > 0 ? lastFirst.IndexOf(";") : 0;
        if (length == 0)
          length = lastFirst.IndexOf(":") > 0 ? lastFirst.IndexOf(":") : 0;
        if (length == 0)
          length = lastFirst.IndexOf("/") > 0 ? lastFirst.IndexOf("/") : 0;
        if (length == 0)
          length = lastFirst.IndexOf(",") > 0 ? lastFirst.IndexOf(",") : 0;
        if (length == 0)
          length = lastFirst.IndexOf(" ") > 0 ? lastFirst.IndexOf(" ") : 0;
        if (length != 0)
        {
          this.Last = lastFirst.Substring(0, length);
          string str1 = lastFirst.Remove(0, this.Last.Length + 1).Trim();
          if (string.IsNullOrEmpty(str1))
            return;
          string str2;
          if ((str1.IndexOf("&") >= 0 ? 0 : (str1.ToLower().IndexOf(" and ") < 0 ? 1 : 0)) != 0)
          {
            foreach (string prefixWord in PLName.PrefixWords)
            {
              if (str1.ToUpper().StartsWith(prefixWord.ToUpper()))
              {
                this.Title = prefixWord.Trim();
                str1 = str1.Remove(0, this.Title.Length).Trim();
                if (string.IsNullOrEmpty(str1))
                  return;
                break;
              }
            }
            if ((str1.IndexOf("&") >= 0 ? 0 : (str1.ToLower().IndexOf(" and ") < 0 ? 1 : 0)) != 0)
            {
              foreach (string suffixWord in PLName.SuffixWords)
              {
                if (str1.ToUpper().EndsWith(suffixWord.ToUpper()))
                {
                  this.Suffix = suffixWord.Trim();
                  str1 = str1.Substring(0, str1.Length - suffixWord.Length).Trim();
                  char[] anyOf = new char[7]
                  {
                    ',',
                    '.',
                    '/',
                    '\\',
                    ';',
                    ':',
                    '*'
                  };
                  while (str1.LastIndexOfAny(anyOf) >= 0)
                    str1 = str1.Remove(str1.LastIndexOfAny(anyOf)).Trim();
                  if (string.IsNullOrEmpty(str1))
                    return;
                  break;
                }
              }
              if (str1.IndexOf(" ") <= 0)
              {
                this.First = str1;
              }
              else
              {
                this.First = str1.Substring(0, str1.IndexOf(" "));
                this.Middle = str1.Substring(str1.IndexOf(" ")).Trim();
              }
              if (this.Last.Equals(""))
                this.Last = "-Name not Supplied-";
            }
            else
            {
              this.First = str1;
              str2 = "";
            }
          }
          else
          {
            this.First = str1;
            str2 = "";
          }
        }
        else
          this.Last = lastFirst;
      }
      else
        this.Last = "-Name not Supplied-";
    }

    public void ParseName()
    {
      if (!string.IsNullOrEmpty(this.LastFirst))
      {
        if (!PLName.IsCorporation(this.LastFirst))
        {
          this.ParseLastFirst();
        }
        else
        {
          this.Company = this.LastFirst;
          this.IsCorp = true;
        }
      }
      else
      {
        if (string.IsNullOrEmpty(this.FirstLast))
          return;
        if (!PLName.IsCorporation(this.FirstLast))
        {
          this.ParseFirstLast();
        }
        else
        {
          this.Company = this.FirstLast;
          this.IsCorp = true;
        }
      }
    }

    private static void ReadTable()
    {
    }

    public override void Send()
    {
    }

    public void SetFieldValues(string title, string first, string middle, string last, string suffix, string company, string attentionPosition, bool is_corp)
    {
      this.Title = title;
      this.First = first;
      this.Middle = middle;
      this.Last = last;
      this.Suffix = suffix;
      this.Company = company;
      this.Position = attentionPosition;
      this.IsCorp = is_corp;
    }

    public enum eNameType : byte
    {
      CLIENT = 1,
      CLNT_onMAT = 2,
      MAT_BILL1 = 3,
      MAT_BILL2 = 4,
      VENDOR = 5,
      CONTACT = 6,
    }
  }
}
