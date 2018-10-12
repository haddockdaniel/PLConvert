using ConvHelper;
using PLXMLLnkLib;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PLConvert
{
    public class PLClient : StaticData
    {
        protected uint m_hndSubFld = 0;

        protected uint m_hndExistingSubFld = 0;

        public PLName Name;

        public PLAddress Address;

        public PLPhone Phone;

        private CPostItem m_MajorClientID;

        private CPostItem m_IsMajorClient;

        private CPostItem m_IntroLawyerID;

        private CPostItem m_ContactID;

        private CPostItem m_CustomTabID;

        private CPostItem m_CustomTabEntityID;

        private CPostItem m_CustomTabType;

        private CPostItem m_CustomTabLinkID;

        private CPostItem m_CustomTabFldIDs;

        private CPostItem m_CustomTabFldValuesRAW;

        private CPostItem m_CustomTabFldValuesDisp;

        private CPostItem m_CustomTabTemplate;

        private CPostItem m_CustomTabHelpType;

        private ArrayList m_CustomTabIDArr;

        private ArrayList m_CustomTabEntityIDArr;

        private ArrayList m_CustomTabTypeArr;

        private ArrayList m_CustomTabLinkIDArr;

        private ArrayList m_CustomTabFieldInfoArr;

        private ArrayList m_CustomTabFieldIDsArr;

        private ArrayList m_CustomTabFldValuesRAWArr;

        private ArrayList m_htCustomTabHelpTypeArr;

        private static Dictionary<string, int> m_MapNNtoID;

        private static Dictionary<int, string> m_MapIDtoNN;

        private static Dictionary<string, int> m_MapNNtoContactID;

        private static Dictionary<string, int> m_MapExtID1toPLID;

        private static Dictionary<string, int> m_MapExtID2toPLID;

        private static Dictionary<string, int> m_MapNameKeytoPLID;

        private static Dictionary<int, int> m_mapClientIDtoContactID;

        private static Dictionary<int, int> m_mapContactIDtoClientID;

        private static Dictionary<int, string> m_MapPLIDtoQBID;

        internal static int m_nClientNN;

        private static bool m_bRead;

        private static string m_sFieldList;

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

        public int IntroLawyerID
        {
            get
            {
                return this.m_IntroLawyerID.nValue;
            }
            set
            {
                this.m_IntroLawyerID.SetValue(value);
            }
        }

        public string IntroLwrNN
        {
            get
            {
                return PLLawyer.GetNNFromID(this.m_IntroLawyerID.nValue);
            }
            set
            {
                this.m_IntroLawyerID.SetValue(PLLawyer.GetIDFromNN(value));
            }
        }

        public bool IsMajorClient
        {
            get
            {
                return this.m_IsMajorClient.bValue;
            }
            set
            {
                this.m_IsMajorClient.SetValue(value);
            }
        }

        public string MajorClientNN
        {
            get
            {
                return PLClient.GetNNFromID(this.m_MajorClientID.nValue);
            }
            set
            {
                this.m_MajorClientID.SetValue(PLClient.GetIDFromNN(value));
            }
        }

        private int nMajorClientID
        {
            get
            {
                return this.m_MajorClientID.nValue;
            }
            set
            {
                this.m_MajorClientID.SetValue(value);
            }
        }

        static PLClient()
        {
            PLClient.m_sFieldList = "";
            PLClient.m_nClientNN = 0;
            PLClient.m_sFieldList = "ClientID|ClientNum|ClientFirstName|ClientInitial|ClientLastName|ClientCompany";
            PLClient.m_bRead = false;
        }

        public PLClient()
        {
            this.Initialize();
            PLClient.m_sFieldList = "ClientID|ClientNum|ClientFirstName|ClientInitial|ClientLastName|ClientCompany|ClientPersonContactID|ClientQuickBooksID";
        }

        public PLClient(string sFieldList)
        {
            this.Initialize();
            PLClient.m_sFieldList = sFieldList;
        }

        public void AddCustomTab(int nTabID, int nTabEntityID, int nTabLinkID)
        {
            ArrayList arrayLists = null;
            int num = 1;
            this.m_CustomTabIDArr.Add(nTabID);
            this.m_CustomTabEntityIDArr.Add(nTabEntityID);
            this.m_CustomTabTypeArr.Add(num);
            this.m_CustomTabLinkIDArr.Add(nTabLinkID);
            arrayLists = new ArrayList();
            this.m_CustomTabFieldIDsArr = new ArrayList();
            this.m_CustomTabFldValuesRAWArr = new ArrayList();
            this.m_htCustomTabHelpTypeArr = new ArrayList();
            arrayLists.Add(this.m_CustomTabFieldIDsArr);
            arrayLists.Add(this.m_CustomTabFldValuesRAWArr);
            arrayLists.Add(this.m_htCustomTabHelpTypeArr);
            this.m_CustomTabFieldInfoArr.Add(arrayLists);
        }

        public void AddCustomTabFields(int nTabIndex, int nFieldID, string sFieldValue, int nHelpType)
        {
            ArrayList item = null;
            if (this.m_CustomTabFieldInfoArr.Count > nTabIndex - 1)
            {
                item = (ArrayList)this.m_CustomTabFieldInfoArr[nTabIndex - 1];
            }
            if (item == null)
            {
                item = new ArrayList();
                this.m_CustomTabFieldIDsArr = new ArrayList();
                this.m_CustomTabFldValuesRAWArr = new ArrayList();
                this.m_htCustomTabHelpTypeArr = new ArrayList();
                item.Add(this.m_CustomTabFieldIDsArr);
                item.Add(this.m_CustomTabFldValuesRAWArr);
                item.Add(this.m_htCustomTabHelpTypeArr);
                this.m_CustomTabFieldInfoArr.Add(item);
            }
            this.m_CustomTabFieldIDsArr = (ArrayList)item[0];
            this.m_CustomTabFldValuesRAWArr = (ArrayList)item[1];
            this.m_htCustomTabHelpTypeArr = (ArrayList)item[2];
            this.m_CustomTabFieldIDsArr.Add(nFieldID);
            this.m_CustomTabFldValuesRAWArr.Add(sFieldValue);
            this.m_htCustomTabHelpTypeArr.Add(nHelpType);
        }

        public static void AddMapClientIDtoContactID(int Key, int Value)
        {
            if ((Key == 0 ? false : Value != 0))
            {
                if (PLClient.m_mapClientIDtoContactID == null)
                {
                    PLClient.m_mapClientIDtoContactID = new Dictionary<int, int>();
                }
                if (!PLClient.m_mapClientIDtoContactID.ContainsKey(Key))
                {
                    PLClient.m_mapClientIDtoContactID.Add(Key, Value);
                }
            }
        }

        public static void AddMapContactIDtoClientID(int Key, int Value)
        {
            if ((Key == 0 ? false : Value != 0))
            {
                if (PLClient.m_mapContactIDtoClientID == null)
                {
                    PLClient.m_mapContactIDtoClientID = new Dictionary<int, int>();
                }
                if (!PLClient.m_mapContactIDtoClientID.ContainsKey(Key))
                {
                    PLClient.m_mapContactIDtoClientID.Add(Key, Value);
                }
            }
        }

        public static void AddMapExtID1toPLID(string Key, int Value)
        {
            if (!string.IsNullOrEmpty(Key))
            {
                if (PLClient.m_MapExtID1toPLID == null)
                {
                    PLClient.m_MapExtID1toPLID = new Dictionary<string, int>();
                }
                if (!PLClient.m_MapExtID1toPLID.ContainsKey(Key))
                {
                    PLClient.m_MapExtID1toPLID.Add(Key, Value);
                }
            }
        }

        public static void AddMapExtID2toPLID(string Key, int Value)
        {
            if (!string.IsNullOrEmpty(Key))
            {
                if (PLClient.m_MapExtID2toPLID == null)
                {
                    PLClient.m_MapExtID2toPLID = new Dictionary<string, int>();
                }
                if (!PLClient.m_MapExtID2toPLID.ContainsKey(Key))
                {
                    PLClient.m_MapExtID2toPLID.Add(Key, Value);
                }
            }
        }

        public static void AddMapIDtoNN(int Key, string Value)
        {
            if (!Key.Equals(0))
            {
                if (PLClient.m_MapIDtoNN == null)
                {
                    PLClient.m_MapIDtoNN = new Dictionary<int, string>();
                }
                if (!PLClient.m_MapIDtoNN.ContainsKey(Key))
                {
                    PLClient.m_MapIDtoNN.Add(Key, Value);
                }
            }
        }

        public static void AddMapNameKeytoPLID(string Key, int Value)
        {
            Key = Key.ToUpper();
            if (!string.IsNullOrEmpty(Key))
            {
                if (PLClient.m_MapNameKeytoPLID == null)
                {
                    PLClient.m_MapNameKeytoPLID = new Dictionary<string, int>();
                }
                if (!PLClient.m_MapNameKeytoPLID.ContainsKey(Key))
                {
                    PLClient.m_MapNameKeytoPLID.Add(Key, Value);
                }
            }
        }

        public static void AddMapNNtoContactID(string Key, int Value)
        {
            Key = Key.ToUpper();
            if (!string.IsNullOrEmpty(Key))
            {
                if (PLClient.m_MapNNtoContactID == null)
                {
                    PLClient.m_MapNNtoContactID = new Dictionary<string, int>();
                }
                if (!PLClient.m_MapNNtoContactID.ContainsKey(Key))
                {
                    PLClient.m_MapNNtoContactID.Add(Key, Value);
                }
            }
        }

        public static void AddMapNNtoID(string Key, int Value)
        {
            Key = Key.ToUpper();
            if (!string.IsNullOrEmpty(Key))
            {
                if (PLClient.m_MapNNtoID == null)
                {
                    PLClient.m_MapNNtoID = new Dictionary<string, int>();
                }
                if (!PLClient.m_MapNNtoID.ContainsKey(Key))
                {
                    PLClient.m_MapNNtoID.Add(Key, Value);
                }
            }
        }

        public static void AddMapPLIDtoQBID(int Key, string Value)
        {
            if ((Key.Equals(0) ? false : !Value.Equals("")))
            {
                if (PLClient.m_MapPLIDtoQBID == null)
                {
                    PLClient.m_MapPLIDtoQBID = new Dictionary<int, string>();
                }
                if (PLClient.m_MapPLIDtoQBID.ContainsKey(Key))
                {
                    PLClient.m_MapPLIDtoQBID.Remove(Key);
                }
                PLClient.m_MapPLIDtoQBID.Add(Key, Value);
            }
        }

        public override void AddRecord()
        {
            string str;
            short i = 0;
            short j = 0;
            object obj = new object();
            ArrayList item = null;
            if (this.m_hndPOST == 0)
            {
                this.m_hndPOST = base.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
            }
            if (this.m_hndSubFld == 0)
            {
                this.m_hndSubFld = base.GetLink().SubField_CreateHandle();
            }
            if (this.m_NickName.m_bIsSet)
            {
                if ((!this.m_ID.m_bIsSet ? true : this.m_ID.nValue.Equals(0)))
                {
                    if ((PLClient.GetIDFromNN(base.NickName) > 0 || base.NickName.Length.Equals(0) ? true : base.NickName.Length > 6))
                    {
                        PLClient.m_nClientNN = PLClient.m_nClientNN + 1;
                        str = PLClient.m_nClientNN.ToString();
                        base.NickName = string.Concat("~", str);
                    }
                }
            }
            else if ((!this.m_ID.m_bIsSet ? true : this.m_ID.nValue.Equals(0)))
            {
                PLClient.m_nClientNN = PLClient.m_nClientNN + 1;
                str = PLClient.m_nClientNN.ToString();
                base.NickName = string.Concat("~", str);
            }
            this.Name.AddFields(this.m_hndPOST);
            this.Address.AddFields(this.m_hndPOST);
            this.Phone.AddFields(this.m_hndPOST);
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.AddField(this.m_hndPOST);
            }
            for (i = 1; i <= this.m_CustomTabIDArr.Count; i = (short)(i + 1))
            {
                this.m_CustomTabID.SetValue(Convert.ToInt32(this.m_CustomTabIDArr[i - 1]));
                this.m_CustomTabID.AddRepeatField(this.m_hndPOST, i);
                this.m_CustomTabEntityID.SetValue(Convert.ToInt32(this.m_CustomTabEntityIDArr[i - 1]));
                this.m_CustomTabEntityID.AddRepeatField(this.m_hndPOST, i);
                this.m_CustomTabType.SetValue(Convert.ToInt32(this.m_CustomTabTypeArr[i - 1]));
                this.m_CustomTabType.AddRepeatField(this.m_hndPOST, i);
                this.m_CustomTabLinkID.SetValue(Convert.ToInt32(this.m_CustomTabLinkIDArr[i - 1]));
                this.m_CustomTabLinkID.AddRepeatField(this.m_hndPOST, i);
                item = (ArrayList)this.m_CustomTabFieldInfoArr[i - 1];
                if (item != null)
                {
                    this.m_CustomTabFieldIDsArr = (ArrayList)item[0];
                    base.GetLink().SubField_Reset(this.m_hndSubFld);
                    for (j = 0; j < this.m_CustomTabFieldIDsArr.Count; j = (short)(j + 1))
                    {
                        base.GetLink().SubField_AddValueString(this.m_hndSubFld, j + 1, this.m_CustomTabFieldIDsArr[j].ToString());
                    }
                    base.GetLink().SubField_String(this.m_hndSubFld, ref obj);
                    this.m_CustomTabFldIDs.SetValue(obj.ToString());
                    this.m_CustomTabFldIDs.AddRepeatField(this.m_hndPOST, i);
                    this.m_CustomTabFldValuesRAWArr = (ArrayList)item[1];
                    base.GetLink().SubField_Reset(this.m_hndSubFld);
                    for (j = 0; j < this.m_CustomTabFldValuesRAWArr.Count; j = (short)(j + 1))
                    {
                        base.GetLink().SubField_AddValueString(this.m_hndSubFld, j + 1, this.m_CustomTabFldValuesRAWArr[j].ToString());
                    }
                    base.GetLink().SubField_String(this.m_hndSubFld, ref obj);
                    this.m_CustomTabFldValuesRAW.SetValue(obj.ToString());
                    this.m_CustomTabFldValuesRAW.AddRepeatField(this.m_hndPOST, i);
                    this.m_htCustomTabHelpTypeArr = (ArrayList)item[2];
                    base.GetLink().SubField_Reset(this.m_hndSubFld);
                    for (j = 0; j < this.m_htCustomTabHelpTypeArr.Count; j = (short)(j + 1))
                    {
                        base.GetLink().SubField_AddValueString(this.m_hndSubFld, j + 1, this.m_htCustomTabHelpTypeArr[j].ToString());
                    }
                    base.GetLink().SubField_String(this.m_hndSubFld, ref obj);
                    this.m_CustomTabHelpType.SetValue(obj.ToString());
                    this.m_CustomTabHelpType.AddRepeatField(this.m_hndPOST, i);
                    this.m_CustomTabFieldIDsArr.Clear();
                    while (this.m_CustomTabFieldIDsArr.Count > 0)
                    {
                        this.m_CustomTabFieldIDsArr.RemoveAt(0);
                    }
                    this.m_CustomTabFldValuesRAWArr.Clear();
                    while (this.m_CustomTabFldValuesRAWArr.Count > 0)
                    {
                        this.m_CustomTabFldValuesRAWArr.RemoveAt(0);
                    }
                    this.m_htCustomTabHelpTypeArr.Clear();
                    while (this.m_htCustomTabHelpTypeArr.Count > 0)
                    {
                        this.m_htCustomTabHelpTypeArr.RemoveAt(0);
                    }
                }
            }
            this.m_CustomTabIDArr.Clear();
            while (this.m_CustomTabIDArr.Count > 0)
            {
                this.m_CustomTabIDArr.RemoveAt(0);
            }
            this.m_CustomTabEntityIDArr.Clear();
            while (this.m_CustomTabEntityIDArr.Count > 0)
            {
                this.m_CustomTabEntityIDArr.RemoveAt(0);
            }
            this.m_CustomTabTypeArr.Clear();
            while (this.m_CustomTabTypeArr.Count > 0)
            {
                this.m_CustomTabTypeArr.RemoveAt(0);
            }
            this.m_CustomTabLinkIDArr.Clear();
            while (this.m_CustomTabLinkIDArr.Count > 0)
            {
                this.m_CustomTabLinkIDArr.RemoveAt(0);
            }
            this.m_CustomTabFieldInfoArr.Clear();
            while (this.m_CustomTabFieldInfoArr.Count > 0)
            {
                this.m_CustomTabFieldInfoArr.RemoveAt(0);
            }
            base.GetLink().TablePOST_AddRecord(this.m_hndPOST);
            PLClient mLCounter = this;
            mLCounter.m_lCounter = mLCounter.m_lCounter + 1;
            if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
            {
                this.Send();
            }
        }

        public override void Clear()
        {
            base.Clear();
            this.Name.Clear();
            this.Address.Clear();
            this.Phone.Clear();
        }

        public static void ClearMapClientIDtoContactID()
        {
            if (PLClient.m_mapClientIDtoContactID != null)
            {
                PLClient.m_mapClientIDtoContactID.Clear();
                PLClient.m_mapClientIDtoContactID = null;
            }
        }

        public static void ClearMapContactIDtoClientID()
        {
            if (PLClient.m_mapContactIDtoClientID != null)
            {
                PLClient.m_mapContactIDtoClientID.Clear();
                PLClient.m_mapContactIDtoClientID = null;
            }
        }

        public static void ClearMapExtID1toPLID()
        {
            if (PLClient.m_MapExtID1toPLID != null)
            {
                PLClient.m_MapExtID1toPLID.Clear();
                PLClient.m_MapExtID1toPLID = null;
            }
        }

        public static void ClearMapExtID2toPLID()
        {
            if (PLClient.m_MapExtID2toPLID != null)
            {
                PLClient.m_MapExtID2toPLID.Clear();
                PLClient.m_MapExtID2toPLID = null;
            }
        }

        public static void ClearMapIDtoNN()
        {
            if (PLClient.m_MapIDtoNN != null)
            {
                PLClient.m_MapIDtoNN.Clear();
                PLClient.m_MapIDtoNN = null;
            }
        }

        public static void ClearMapNameKeytoPLID()
        {
            if (PLClient.m_MapNameKeytoPLID != null)
            {
                PLClient.m_MapNameKeytoPLID.Clear();
                PLClient.m_MapNameKeytoPLID = null;
            }
        }

        public static void ClearMapNNtoContactID()
        {
            if (PLClient.m_MapNNtoContactID != null)
            {
                PLClient.m_MapNNtoContactID.Clear();
                PLClient.m_MapNNtoContactID = null;
            }
        }

        public static void ClearMapNNtoID()
        {
            if (PLClient.m_MapNNtoID != null)
            {
                PLClient.m_MapNNtoID.Clear();
                PLClient.m_MapNNtoID = null;
            }
        }

        public static void ClearMapPLIDtoQBID()
        {
            if (PLClient.m_MapPLIDtoQBID != null)
            {
                PLClient.m_MapPLIDtoQBID.Clear();
                PLClient.m_MapPLIDtoQBID = null;
            }
        }

        public static int GetClientIDFromContactID(int Key)
        {
            int num;
            if (!Key.Equals(0))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_mapContactIDtoClientID != null)
                {
                    num = (PLClient.m_mapContactIDtoClientID.ContainsKey(Key) ? PLClient.m_mapContactIDtoClientID[Key] : 0);
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static int GetContactIDFromClientID(int Key)
        {
            int num;
            if (!Key.Equals(0))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_mapClientIDtoContactID != null)
                {
                    num = (PLClient.m_mapClientIDtoContactID.ContainsKey(Key) ? PLClient.m_mapClientIDtoContactID[Key] : 0);
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static int GetContactIDFromNN(string Key)
        {
            int num;
            Key = Key.ToUpper();
            if (!string.IsNullOrEmpty(Key))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_MapNNtoContactID != null)
                {
                    num = (PLClient.m_MapNNtoContactID.ContainsKey(Key) ? Convert.ToInt32(PLClient.m_MapNNtoContactID[Key]) : 0);
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static int GetCount()
        {
            int num;
            if (!PLClient.m_bRead)
            {
                PLClient.ReadTable();
            }
            num = (PLClient.m_MapNNtoID != null ? PLClient.m_MapNNtoID.Count : 0);
            return num;
        }

        public override void GetExistingRecord()
        {
            this.Clear();
            this.Name.GetExistingRecord(this.m_hndExisting);
            this.Address.GetExistingRecord(this.m_hndExisting);
            this.Phone.GetExistingRecord(this.m_hndExisting);
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.GetField(this.m_hndExisting);
            }
        }

        public static int GetIDFromExtID1(string Key)
        {
            int num;
            if (string.IsNullOrEmpty(Key))
            {
                num = 0;
            }
            else if (PLClient.m_MapExtID1toPLID != null)
            {
                num = (PLClient.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLClient.m_MapExtID1toPLID[Key]) : 0);
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static int GetIDFromExtID2(string Key)
        {
            int num;
            if (string.IsNullOrEmpty(Key))
            {
                num = 0;
            }
            else if (PLClient.m_MapExtID2toPLID != null)
            {
                num = (PLClient.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLClient.m_MapExtID2toPLID[Key]) : 0);
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static int GetIDFromNameKey(string Key)
        {
            int num;
            Key = Key.ToUpper();
            if (!string.IsNullOrEmpty(Key))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_MapNameKeytoPLID != null)
                {
                    num = ((PLClient.m_MapNameKeytoPLID.Count == 0 ? false : PLClient.m_MapNameKeytoPLID.ContainsKey(Key)) ? Convert.ToInt32(PLClient.m_MapNameKeytoPLID[Key]) : 0);
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static int GetIDFromNN(string Key)
        {
            int num;
            Key = Key.ToUpper();
            if (!string.IsNullOrEmpty(Key))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_MapNNtoID != null)
                {
                    num = (PLClient.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLClient.m_MapNNtoID[Key]) : 0);
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static string GetNextClientNN()
        {
            string empty = string.Empty;
            object obj = new object();
            PLLink.GetLink().GetNextAvailClient(ref obj);
            return obj.ToString();
        }

        public static string GetNNFromID(int nID)
        {
            string empty;
            if (!nID.Equals(0))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_MapIDtoNN != null)
                {
                    empty = (PLClient.m_MapIDtoNN.ContainsKey(nID) ? PLClient.m_MapIDtoNN[nID].ToString() : string.Empty);
                }
                else
                {
                    empty = string.Empty;
                }
            }
            else
            {
                empty = string.Empty;
            }
            return empty;
        }

        public static int GetPLIDFromQBID(string sQBID)
        {
            int num;
            if (!sQBID.Equals(""))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_MapPLIDtoQBID == null)
                {
                    num = 0;
                }
                else if (PLClient.m_MapPLIDtoQBID.ContainsValue(sQBID))
                {
                    int key = 0;
                    Dictionary<int, string>.Enumerator enumerator = PLClient.m_MapPLIDtoQBID.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Dictionary<int, string> mMapPLIDtoQBID = PLClient.m_MapPLIDtoQBID;
                        KeyValuePair<int, string> current = enumerator.Current;
                        if (mMapPLIDtoQBID[current.Key].ToUpper().CompareTo(sQBID.ToUpper()) == 0)
                        {
                            current = enumerator.Current;
                            key = current.Key;
                        }
                    }
                    num = key;
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public static string GetQBIDFromPLID(int nID)
        {
            string str;
            if (!nID.Equals(0))
            {
                if (!PLClient.m_bRead)
                {
                    PLClient.ReadTable();
                }
                if (PLClient.m_MapPLIDtoQBID != null)
                {
                    str = (PLClient.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLClient.m_MapPLIDtoQBID[nID]) : "");
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        public override void GetRecord()
        {
            this.Clear();
            if (this.m_hndGET == 0)
            {
                this.m_hndGET = base.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0);
            }
            this.Name.GetRecord(this.m_hndGET);
            this.Address.GetRecord(this.m_hndGET);
            this.Phone.GetRecord(this.m_hndGET);
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.GetField(this.m_hndGET);
            }
        }

        protected override void Initialize()
        {
            this.m_sTableName = "Client";
            PLClient.m_nClientNN = 0;
            this.Name = new PLName(PLName.eNameType.CLIENT);
            this.Address = new PLAddress(PLAddress.eAddType.CLIENT);
            this.Phone = new PLPhone(PLPhone.ePhoneType.CLIENT);
            List<CPostItem> postItems = this.PostItems;
            CPostItem cPostItem = new CPostItem(CPostItem.DataType.STRING, "ClientNum");
            CPostItem cPostItem1 = cPostItem;
            this.m_NickName = cPostItem;
            postItems.Add(cPostItem1);
            List<CPostItem> cPostItems = this.PostItems;
            CPostItem cPostItem2 = new CPostItem(CPostItem.DataType.LONG, "ClientID");
            cPostItem1 = cPostItem2;
            this.m_ID = cPostItem2;
            cPostItems.Add(cPostItem1);
            List<CPostItem> postItems1 = this.PostItems;
            CPostItem cPostItem3 = new CPostItem(CPostItem.DataType.LONG, "ClientStatus");
            cPostItem1 = cPostItem3;
            this.m_Status = cPostItem3;
            postItems1.Add(cPostItem1);
            List<CPostItem> cPostItems1 = this.PostItems;
            CPostItem cPostItem4 = new CPostItem(CPostItem.DataType.LONG, "ClientIDMajor");
            cPostItem1 = cPostItem4;
            this.m_MajorClientID = cPostItem4;
            cPostItems1.Add(cPostItem1);
            List<CPostItem> postItems2 = this.PostItems;
            CPostItem cPostItem5 = new CPostItem(CPostItem.DataType.BOOL, "ClientIsMajorClient");
            cPostItem1 = cPostItem5;
            this.m_IsMajorClient = cPostItem5;
            postItems2.Add(cPostItem1);
            List<CPostItem> cPostItems2 = this.PostItems;
            CPostItem cPostItem6 = new CPostItem(CPostItem.DataType.LONG, "LawyerIDClient");
            cPostItem1 = cPostItem6;
            this.m_IntroLawyerID = cPostItem6;
            cPostItems2.Add(cPostItem1);
            List<CPostItem> postItems3 = this.PostItems;
            CPostItem cPostItem7 = new CPostItem(CPostItem.DataType.LONG, "ClientPersonContactID");
            cPostItem1 = cPostItem7;
            this.m_ContactID = cPostItem7;
            postItems3.Add(cPostItem1);
            List<CPostItem> cPostItems3 = this.PostItems;
            CPostItem cPostItem8 = new CPostItem(CPostItem.DataType.LONG, "ClientTransactionChange");
            cPostItem1 = cPostItem8;
            this.m_TransactionChgID = cPostItem8;
            cPostItems3.Add(cPostItem1);
            List<CPostItem> postItems4 = this.PostItems;
            CPostItem cPostItem9 = new CPostItem(CPostItem.DataType.LONG, "ClientTransactionNew");
            cPostItem1 = cPostItem9;
            this.m_TransactionNewID = cPostItem9;
            postItems4.Add(cPostItem1);
            List<CPostItem> cPostItems4 = this.PostItems;
            CPostItem cPostItem10 = new CPostItem(CPostItem.DataType.STRING, "ClientQuickBooksID");
            cPostItem1 = cPostItem10;
            this.m_QuickBooksID = cPostItem10;
            cPostItems4.Add(cPostItem1);
            List<CPostItem> postItems5 = this.PostItems;
            CPostItem cPostItem11 = new CPostItem(CPostItem.DataType.RepeatLONG, "ClntCustomTabID");
            cPostItem1 = cPostItem11;
            this.m_CustomTabID = cPostItem11;
            postItems5.Add(cPostItem1);
            List<CPostItem> cPostItems5 = this.PostItems;
            CPostItem cPostItem12 = new CPostItem(CPostItem.DataType.RepeatLONG, "ClntCustomTabEntityID");
            cPostItem1 = cPostItem12;
            this.m_CustomTabEntityID = cPostItem12;
            cPostItems5.Add(cPostItem1);
            List<CPostItem> postItems6 = this.PostItems;
            CPostItem cPostItem13 = new CPostItem(CPostItem.DataType.RepeatLONG, "ClntCustomTabEntityType");
            cPostItem1 = cPostItem13;
            this.m_CustomTabType = cPostItem13;
            postItems6.Add(cPostItem1);
            List<CPostItem> cPostItems6 = this.PostItems;
            CPostItem cPostItem14 = new CPostItem(CPostItem.DataType.RepeatLONG, "ClntCustomTabLinkID");
            cPostItem1 = cPostItem14;
            this.m_CustomTabLinkID = cPostItem14;
            cPostItems6.Add(cPostItem1);
            List<CPostItem> postItems7 = this.PostItems;
            CPostItem cPostItem15 = new CPostItem(CPostItem.DataType.RepeatSTRING, "ClntCustomTabFieldIDs");
            cPostItem1 = cPostItem15;
            this.m_CustomTabFldIDs = cPostItem15;
            postItems7.Add(cPostItem1);
            List<CPostItem> cPostItems7 = this.PostItems;
            CPostItem cPostItem16 = new CPostItem(CPostItem.DataType.RepeatSTRING, "ClntCustomTabFieldValuesRAW");
            cPostItem1 = cPostItem16;
            this.m_CustomTabFldValuesRAW = cPostItem16;
            cPostItems7.Add(cPostItem1);
            List<CPostItem> postItems8 = this.PostItems;
            CPostItem cPostItem17 = new CPostItem(CPostItem.DataType.RepeatSTRING, "ClntCustomTabFieldValuesDISPLAY");
            cPostItem1 = cPostItem17;
            this.m_CustomTabFldValuesDisp = cPostItem17;
            postItems8.Add(cPostItem1);
            List<CPostItem> cPostItems8 = this.PostItems;
            CPostItem cPostItem18 = new CPostItem(CPostItem.DataType.RepeatSTRING, "ClntCustomTabBillingTemplate");
            cPostItem1 = cPostItem18;
            this.m_CustomTabTemplate = cPostItem18;
            cPostItems8.Add(cPostItem1);
            List<CPostItem> postItems9 = this.PostItems;
            CPostItem cPostItem19 = new CPostItem(CPostItem.DataType.RepeatSTRING, "ClntCustomTabHelpType");
            cPostItem1 = cPostItem19;
            this.m_CustomTabHelpType = cPostItem19;
            postItems9.Add(cPostItem1);
            List<CPostItem> cPostItems9 = this.PostItems;
            CPostItem cPostItem20 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
            cPostItem1 = cPostItem20;
            this.m_ExternalID_1 = cPostItem20;
            cPostItems9.Add(cPostItem1);
            List<CPostItem> postItems10 = this.PostItems;
            CPostItem cPostItem21 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
            cPostItem1 = cPostItem21;
            this.m_ExternalID_2 = cPostItem21;
            postItems10.Add(cPostItem1);
            this.m_CustomTabIDArr = new ArrayList();
            this.m_CustomTabEntityIDArr = new ArrayList();
            this.m_CustomTabTypeArr = new ArrayList();
            this.m_CustomTabLinkIDArr = new ArrayList();
            this.m_CustomTabFieldInfoArr = new ArrayList();
        }

        public override string MakeNN(bool bSetNickName)
        {
            throw new NotImplementedException();
        }

        private static void ReadTable()
        {
            if (!PLClient.m_bRead)
            {
                uint num = 0;
                object obj = new object();
                if (PLClient.m_MapNameKeytoPLID == null)
                {
                    PLClient.m_MapNameKeytoPLID = new Dictionary<string, int>();
                }
                num = PLLink.GetLink().TableGET_CreateHandle("Client", 0, 0, 0);
                PLLink.GetLink().TableGET_AddFilter(num, "ClientStatus", "EQ", "0", 1);
                if (!PLClient.m_sFieldList.Equals(""))
                {
                    PLLink.GetLink().TableGET_AddDirective(num, "FieldList", PLClient.m_sFieldList);
                }
                while (PLLink.GetLink().TableGET_GetNextRecord(num) == 0)
                {
                    PLLink.GetLink().TableGET_RecordField_ValueString(num, "ClientNum", "", ref obj);
                    string str = obj.ToString().ToUpper().Trim();
                    int num1 = PLLink.GetLink().TableGET_RecordField_ValueI32(num, "ClientID");
                    PLClient.AddMapIDtoNN(num1, str);
                    PLClient.AddMapNNtoID(str, num1);
                    int num2 = PLLink.GetLink().TableGET_RecordField_ValueI32(num, "ClientPersonContactID");
                    PLClient.AddMapNNtoContactID(str, num2);
                    PLClient.AddMapClientIDtoContactID(num1, num2);
                    PLClient.AddMapContactIDtoClientID(num2, num1);
                    PLLink.GetLink().TableGET_RecordField_ValueString(num, "ClientFirstName", "", ref obj);
                    string str1 = obj.ToString().ToUpper().Trim();
                    PLLink.GetLink().TableGET_RecordField_ValueString(num, "ClientInitial", "", ref obj);
                    string str2 = obj.ToString().ToUpper().Trim();
                    PLLink.GetLink().TableGET_RecordField_ValueString(num, "ClientLastName", "", ref obj);
                    string str3 = obj.ToString().ToUpper().Trim();
                    PLLink.GetLink().TableGET_RecordField_ValueString(num, "ClientCompany", "", ref obj);
                    string str4 = obj.ToString().ToUpper().Trim();
                    string str5 = string.Concat(str1, str2, str3, str4);
                    str5 = str5.ToUpper().Trim();
                    while (str5.IndexOf("  ") > 0)
                    {
                        str5 = str5.Replace("  ", " ");
                    }
                    PLClient.AddMapNameKeytoPLID(str5, num1);
                    PLLink.GetLink().TableGET_RecordField_ValueString(num, "ClientQuickBooksID", "", ref obj);
                    string str6 = obj.ToString().ToUpper().Trim();
                    if (!str6.Equals(""))
                    {
                        PLClient.AddMapPLIDtoQBID(num1, str6);
                    }
                }
                PLLink.GetLink().TableGET_CloseHandle(num);
                num = 0;
                PLClient.m_bRead = true;
            }
        }

        public override void Send()
        {
            string str;
            string str1;
            string str2;
            string message;
            string str3;
            string str4;
            string str5;
            FormatException formatException;
            object obj = new object();
            object obj1 = new object();
            object obj2 = new object();
            object obj3 = new object();
            object obj4 = new object();
            object obj5 = new object();
            object obj6 = new object();
            short num = 0;
            short num1 = 0;
            string empty = string.Empty;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            int num2 = 0;
            int num3 = 0;
            this.m_lSendErrorCount = (long)0;
            try
            {
                base.GetLink().TablePOST_Send(this.m_hndPOST, ref obj, ref obj1);
                goto Label0;
            }
            catch (NullReferenceException nullReferenceException1)
            {
                NullReferenceException nullReferenceException = nullReferenceException1;
                str = (nullReferenceException.Data == null ? "" : nullReferenceException.Data.ToString());
                str1 = (nullReferenceException.HelpLink == null ? "" : nullReferenceException.HelpLink.ToString());
                str2 = (nullReferenceException.InnerException == null ? "" : nullReferenceException.InnerException.ToString());
                message = nullReferenceException.Message;
                str3 = (nullReferenceException.Source == null ? "" : nullReferenceException.Source.ToString());
                str4 = (nullReferenceException.StackTrace == null ? "" : nullReferenceException.StackTrace.ToString());
                str5 = (nullReferenceException.TargetSite == null ? "" : nullReferenceException.TargetSite.ToString());
                base.GetLink().LinkLog_AddLinkLogMessage(string.Concat("Clients, Null Ref Execption: ", message));
                base.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
                base.GetLink().TablePOST_Reset(this.m_hndPOST);
            }
            catch (AccessViolationException accessViolationException1)
            {
                AccessViolationException accessViolationException = accessViolationException1;
                str = (accessViolationException.Data == null ? "" : accessViolationException.Data.ToString());
                str1 = (accessViolationException.HelpLink == null ? "" : accessViolationException.HelpLink.ToString());
                str2 = (accessViolationException.InnerException == null ? "" : accessViolationException.InnerException.ToString());
                message = accessViolationException.Message;
                str3 = (accessViolationException.Source == null ? "" : accessViolationException.Source.ToString());
                str4 = (accessViolationException.StackTrace == null ? "" : accessViolationException.StackTrace.ToString());
                str5 = (accessViolationException.TargetSite == null ? "" : accessViolationException.TargetSite.ToString());
                base.GetLink().LinkLog_AddLinkLogMessage(string.Concat("Clients, Access Violation Execption: ", message));
                base.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
                base.GetLink().TablePOST_Reset(this.m_hndPOST);
            }
            catch (FormatException formatException1)
            {
                formatException = formatException1;
                str = (formatException.Data == null ? "" : formatException.Data.ToString());
                str1 = (formatException.HelpLink == null ? "" : formatException.HelpLink.ToString());
                str2 = (formatException.InnerException == null ? "" : formatException.InnerException.ToString());
                message = formatException.Message;
                str3 = (formatException.Source == null ? "" : formatException.Source.ToString());
                str4 = (formatException.StackTrace == null ? "" : formatException.StackTrace.ToString());
                str5 = (formatException.TargetSite == null ? "" : formatException.TargetSite.ToString());
                base.GetLink().LinkLog_AddLinkLogMessage(string.Concat("Clients, Format Execption: ", message));
                base.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
                base.GetLink().TablePOST_Reset(this.m_hndPOST);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                str = (exception.Data == null ? "" : exception.Data.ToString());
                str1 = (exception.HelpLink == null ? "" : exception.HelpLink.ToString());
                str2 = (exception.InnerException == null ? "" : exception.InnerException.ToString());
                message = exception.Message;
                str3 = (exception.Source == null ? "" : exception.Source.ToString());
                str4 = (exception.StackTrace == null ? "" : exception.StackTrace.ToString());
                str5 = (exception.TargetSite == null ? "" : exception.TargetSite.ToString());
                base.GetLink().LinkLog_AddLinkLogMessage(string.Concat("Clients, Catch All Execption: ", message));
                base.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
                base.GetLink().TablePOST_Reset(this.m_hndPOST);
                this.m_lCounter = 0;
            }
            return;
        Label0:
            try
            {
                num = Convert.ToInt16(obj);
                num1 = Convert.ToInt16(obj1);
                PLXMLData.m_lErrorCount = PLXMLData.m_lErrorCount + (long)num1;
                if ((num1 > 0 ? true : this.m_lCounter != num))
                {
                    base.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
                    PLClient mLSendErrorCount = this;
                    mLSendErrorCount.m_lSendErrorCount = mLSendErrorCount.m_lSendErrorCount + (long)1;
                }
                while (base.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref obj2, ref obj3, ref obj4, ref obj5) == 0)
                {
                    if (Convert.ToInt32(obj3) <= 0)
                    {
                        num3 = Convert.ToInt32(obj2);
                        base.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, empty, ref obj6);
                        empty1 = obj6.ToString();
                        PLClient.AddMapIDtoNN(num3, empty1);
                        PLClient.AddMapNNtoID(empty1, num3);
                        base.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, empty, ref obj6);
                        if (!obj6.ToString().Equals(""))
                        {
                            PLClient.AddMapExtID1toPLID(obj6.ToString(), num3);
                        }
                        base.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, empty, ref obj6);
                        if (!obj6.ToString().Equals(""))
                        {
                            PLClient.AddMapExtID2toPLID(obj6.ToString(), num3);
                        }
                        base.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "NameKey", empty, ref obj6);
                        if (!obj6.ToString().Equals(""))
                        {
                            PLClient.AddMapNameKeytoPLID(obj6.ToString(), num3);
                        }
                        base.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "ClientPersonContactID", empty, ref obj6);
                        if (StringManip.IsNumeric(obj6.ToString()))
                        {
                            num2 = StringManip.NullToInt(obj6);
                            if (num2 != 0)
                            {
                                PLClient.AddMapNNtoContactID(empty1, num2);
                                PLClient.AddMapClientIDtoContactID(num3, num2);
                                PLClient.AddMapContactIDtoClientID(num2, num3);
                            }
                        }
                        base.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "ClientQuickBooksID", empty, ref obj6);
                        empty2 = obj6.ToString().ToUpper().Trim();
                        if (!empty2.Equals(""))
                        {
                            PLClient.AddMapPLIDtoQBID(num3, empty2);
                        }
                    }
                }
                base.GetLink().TablePOST_Reset(this.m_hndPOST);
                this.m_lCounter = 0;
                base.GetLink().SubField_CloseHandle(this.m_hndSubFld);
                this.m_hndSubFld = 0;
            }
            catch (FormatException formatException2)
            {
                formatException = formatException2;
                str = (formatException.Data == null ? "" : formatException.Data.ToString());
                str1 = (formatException.HelpLink == null ? "" : formatException.HelpLink.ToString());
                str2 = (formatException.InnerException == null ? "" : formatException.InnerException.ToString());
                message = formatException.Message;
                str3 = (formatException.Source == null ? "" : formatException.Source.ToString());
                str4 = (formatException.StackTrace == null ? "" : formatException.StackTrace.ToString());
                str5 = (formatException.TargetSite == null ? "" : formatException.TargetSite.ToString());
                base.GetLink().LinkLog_AddLinkLogMessage(string.Concat("Clients Reading posted items, Catch All Execption: ", message));
                base.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
                this.m_lCounter = 0;
                return;
            }
        }

        public void SetFieldValues(string nickname, int id, PLXMLData.eSTATUS status, string major_client_nn, bool is_major_client, int intro_lawyer_id, string external_id1, string external_id2)
        {
            base.NickName = nickname;
            base.ID = id;
            base.Status = status;
            this.MajorClientNN = major_client_nn;
            this.IsMajorClient = is_major_client;
            this.IntroLawyerID = intro_lawyer_id;
            base.ExternalID_1 = external_id1;
            base.ExternalID_2 = external_id2;
        }

        public void SetFieldValues(string nickname, string intro_lawyer_nn, string external_id1, string external_id2)
        {
            base.NickName = nickname;
            this.IntroLwrNN = intro_lawyer_nn;
            base.ExternalID_1 = external_id1;
            base.ExternalID_2 = external_id2;
        }

        public enum eCUSTOMTABLNKTYPE
        {
            MATTER,
            CLIENT,
            CONTACT,
            VENDOR
        }
    }
}