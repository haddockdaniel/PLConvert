using PLXMLLnkLib;
using System;
using System.Collections.Generic;

namespace PLConvert
{
    public class PLExpense : TransactionData
    {
        private CPostItem m_MatterID;

        private CPostItem m_Date;

        private CPostItem m_EntryType;

        private CPostItem m_GSTCat;

        private CPostItem m_Amount;

        private CPostItem m_CheckNum;

        private CPostItem m_PaidTo;

        private CPostItem m_InvDate;

        private CPostItem m_HoldFlag;

        private CPostItem m_IsSoftCost;

        private CPostItem m_Quantity;

        private CPostItem m_Rate;

        private CPostItem m_MarkupAmt;

        private CPostItem m_MarkupPct;

        private CPostItem m_Explanation;

        private CPostItem m_InvoiceNumber;

        private CPostItem m_GLID;

        private CPostItem m_ActivityID;

        private CPostItem m_InvoiceID;

        public static bool m_bAllowEntOnClosedMtr;

        public double Amount
        {
            get
            {
                return this.m_Amount.dValue;
            }
            set
            {
                this.m_Amount.SetValue(value);
            }
        }

        public string CheckNum
        {
            get
            {
                return this.m_CheckNum.sValue;
            }
            set
            {
                this.m_CheckNum.SetValue(value);
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

        private PLExpense.eExpEntryType EntryType
        {
            get
            {
                return (PLExpense.eExpEntryType)this.m_EntryType.nValue;
            }
            set
            {
                this.m_EntryType.SetValue((int)value);
            }
        }

        public string Explanation
        {
            get
            {
                return this.m_Explanation.sValue;
            }
            set
            {
                this.m_Explanation.SetValue(value);
            }
        }

        public int ExplCodeID
        {
            get
            {
                return this.m_ActivityID.nValue;
            }
            set
            {
                this.m_ActivityID.SetValue(value);
            }
        }

        public string ExplCodeNN
        {
            get
            {
                return PLExpCode.GetNNFromID(this.m_ActivityID.nValue);
            }
            set
            {
                this.m_ActivityID.SetValue(PLExpCode.GetIDFromNN(value));
            }
        }

        public int GLID
        {
            get
            {
                return this.m_GLID.nValue;
            }
            set
            {
                this.m_GLID.SetValue(value);
            }
        }

        public string GLNN
        {
            get
            {
                return PLGLAccts.GetNNFromID(this.m_GLID.nValue);
            }
            set
            {
                this.m_GLID.SetValue(PLGLAccts.GetIDFromNN(value));
            }
        }

        public TransactionData.eGST_CAT GSTCat
        {
            get
            {
                return (TransactionData.eGST_CAT)this.m_GSTCat.nValue;
            }
            set
            {
                this.m_GSTCat.SetValue((int)value);
            }
        }

        public PLExpense.eExpHoldFlag HoldFlag
        {
            get
            {
                return (PLExpense.eExpHoldFlag)this.m_HoldFlag.nValue;
            }
            set
            {
                this.m_HoldFlag.SetValue(Convert.ToInt32(value));
            }
        }

        public int InvDate
        {
            get
            {
                return this.m_InvDate.nValue;
            }
            set
            {
                this.m_InvDate.SetValue(value);
            }
        }

        public int InvoiceID
        {
            get
            {
                return this.m_InvoiceID.nValue;
            }
            set
            {
                this.m_InvoiceID.SetValue(value);
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

        public bool IsSoftCost
        {
            get
            {
                return this.m_IsSoftCost.bValue;
            }
            set
            {
                this.m_IsSoftCost.SetValue(value);
            }
        }

        public double MarkupAmt
        {
            get
            {
                return this.m_MarkupAmt.dValue;
            }
            set
            {
                this.m_MarkupAmt.SetValue(value);
            }
        }

        public double MarkupPct
        {
            get
            {
                return this.m_MarkupPct.dValue;
            }
            set
            {
                this.m_MarkupPct.SetValue(value);
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

        public string PaidTo
        {
            get
            {
                return this.m_PaidTo.sValue;
            }
            set
            {
                this.m_PaidTo.SetValue(value);
            }
        }

        public double Quantity
        {
            get
            {
                return this.m_Quantity.dValue;
            }
            set
            {
                this.m_Quantity.SetValue(value);
            }
        }

        public double Rate
        {
            get
            {
                return this.m_Rate.dValue;
            }
            set
            {
                this.m_Rate.SetValue(value);
            }
        }

        static PLExpense()
        {
            PLExpense.m_bAllowEntOnClosedMtr = false;
        }

        public PLExpense()
        {
            this.Initialize();
        }

        public override void AddRecord()
        {
            if (this.m_hndPOST == 0)
            {
                this.m_hndPOST = base.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
                base.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", (PLExpense.m_bAllowEntOnClosedMtr ? "1" : "0"));
            }
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.AddField(this.m_hndPOST);
            }
            base.GetLink().TablePOST_AddRecord(this.m_hndPOST);
            PLExpense mLCounter = this;
            mLCounter.m_lCounter = mLCounter.m_lCounter + 1;
            if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
            {
                this.Send();
            }
        }

        protected override bool GetAllowEntOnClosedMtr()
        {
            return PLExpense.m_bAllowEntOnClosedMtr;
        }

        protected override void Initialize()
        {
            this.m_sTableName = "Expense";
            List<CPostItem> postItems = this.PostItems;
            CPostItem cPostItem = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntStatus");
            CPostItem cPostItem1 = cPostItem;
            this.m_Status = cPostItem;
            postItems.Add(cPostItem1);
            List<CPostItem> cPostItems = this.PostItems;
            CPostItem cPostItem2 = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntID");
            cPostItem1 = cPostItem2;
            this.m_ID = cPostItem2;
            cPostItems.Add(cPostItem1);
            List<CPostItem> postItems1 = this.PostItems;
            CPostItem cPostItem3 = new CPostItem(CPostItem.DataType.LONG, "MatterID");
            cPostItem1 = cPostItem3;
            this.m_MatterID = cPostItem3;
            postItems1.Add(cPostItem1);
            List<CPostItem> cPostItems1 = this.PostItems;
            CPostItem cPostItem4 = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntDate");
            cPostItem1 = cPostItem4;
            this.m_Date = cPostItem4;
            cPostItems1.Add(cPostItem1);
            List<CPostItem> postItems2 = this.PostItems;
            CPostItem cPostItem5 = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntEntryType");
            cPostItem1 = cPostItem5;
            this.m_EntryType = cPostItem5;
            postItems2.Add(cPostItem1);
            List<CPostItem> cPostItems2 = this.PostItems;
            CPostItem cPostItem6 = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntGSTCat");
            cPostItem1 = cPostItem6;
            this.m_GSTCat = cPostItem6;
            cPostItems2.Add(cPostItem1);
            List<CPostItem> postItems3 = this.PostItems;
            CPostItem cPostItem7 = new CPostItem(CPostItem.DataType.DOUBLE, "ExpenseEntAmount");
            cPostItem1 = cPostItem7;
            this.m_Amount = cPostItem7;
            postItems3.Add(cPostItem1);
            List<CPostItem> cPostItems3 = this.PostItems;
            CPostItem cPostItem8 = new CPostItem(CPostItem.DataType.STRING, "ExpenseEntCheckNum");
            cPostItem1 = cPostItem8;
            this.m_CheckNum = cPostItem8;
            cPostItems3.Add(cPostItem1);
            List<CPostItem> postItems4 = this.PostItems;
            CPostItem cPostItem9 = new CPostItem(CPostItem.DataType.STRING, "ExpenseEntPaidTo");
            cPostItem1 = cPostItem9;
            this.m_PaidTo = cPostItem9;
            postItems4.Add(cPostItem1);
            List<CPostItem> cPostItems4 = this.PostItems;
            CPostItem cPostItem10 = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntInvDate");
            cPostItem1 = cPostItem10;
            this.m_InvDate = cPostItem10;
            cPostItems4.Add(cPostItem1);
            List<CPostItem> postItems5 = this.PostItems;
            CPostItem cPostItem11 = new CPostItem(CPostItem.DataType.LONG, "ExpenseEntHoldFlag");
            cPostItem1 = cPostItem11;
            this.m_HoldFlag = cPostItem11;
            postItems5.Add(cPostItem1);
            List<CPostItem> cPostItems5 = this.PostItems;
            CPostItem cPostItem12 = new CPostItem(CPostItem.DataType.BOOL, "ExpenseEntIsSoftCost");
            cPostItem1 = cPostItem12;
            this.m_IsSoftCost = cPostItem12;
            cPostItems5.Add(cPostItem1);
            List<CPostItem> postItems6 = this.PostItems;
            CPostItem cPostItem13 = new CPostItem(CPostItem.DataType.DOUBLE, "ExpenseEntQuantity");
            cPostItem1 = cPostItem13;
            this.m_Quantity = cPostItem13;
            postItems6.Add(cPostItem1);
            List<CPostItem> cPostItems6 = this.PostItems;
            CPostItem cPostItem14 = new CPostItem(CPostItem.DataType.DOUBLE, "ExpenseEntRate");
            cPostItem1 = cPostItem14;
            this.m_Rate = cPostItem14;
            cPostItems6.Add(cPostItem1);
            List<CPostItem> postItems7 = this.PostItems;
            CPostItem cPostItem15 = new CPostItem(CPostItem.DataType.DOUBLE, "ExpenseEntMarkupAmt");
            cPostItem1 = cPostItem15;
            this.m_MarkupAmt = cPostItem15;
            postItems7.Add(cPostItem1);
            List<CPostItem> cPostItems7 = this.PostItems;
            CPostItem cPostItem16 = new CPostItem(CPostItem.DataType.DOUBLE, "ExpenseEntMarkupPct");
            cPostItem1 = cPostItem16;
            this.m_MarkupPct = cPostItem16;
            cPostItems7.Add(cPostItem1);
            List<CPostItem> postItems8 = this.PostItems;
            CPostItem cPostItem17 = new CPostItem(CPostItem.DataType.STRING, "ExpenseEntExplanation");
            cPostItem1 = cPostItem17;
            this.m_Explanation = cPostItem17;
            postItems8.Add(cPostItem1);
            List<CPostItem> cPostItems8 = this.PostItems;
            CPostItem cPostItem18 = new CPostItem(CPostItem.DataType.LONG, "InvoiceNumber");
            cPostItem1 = cPostItem18;
            this.m_InvoiceNumber = cPostItem18;
            cPostItems8.Add(cPostItem1);
            List<CPostItem> postItems9 = this.PostItems;
            CPostItem cPostItem19 = new CPostItem(CPostItem.DataType.LONG, "GLID");
            cPostItem1 = cPostItem19;
            this.m_GLID = cPostItem19;
            postItems9.Add(cPostItem1);
            List<CPostItem> cPostItems9 = this.PostItems;
            CPostItem cPostItem20 = new CPostItem(CPostItem.DataType.LONG, "ActivityID");
            cPostItem1 = cPostItem20;
            this.m_ActivityID = cPostItem20;
            cPostItems9.Add(cPostItem1);
            List<CPostItem> postItems10 = this.PostItems;
            CPostItem cPostItem21 = new CPostItem(CPostItem.DataType.LONG, "InvoiceID");
            cPostItem1 = cPostItem21;
            this.m_InvoiceID = cPostItem21;
            postItems10.Add(cPostItem1);
            List<CPostItem> cPostItems10 = this.PostItems;
            CPostItem cPostItem22 = new CPostItem(CPostItem.DataType.STRING, "ExpenseEntQuickBooksID");
            cPostItem1 = cPostItem22;
            this.m_QuickBooksID = cPostItem22;
            cPostItems10.Add(cPostItem1);
            List<CPostItem> postItems11 = this.PostItems;
            CPostItem cPostItem23 = new CPostItem(CPostItem.DataType.LONG, "ExpenseReverseID");
            cPostItem1 = cPostItem23;
            this.m_ReverseEntryID = cPostItem23;
            postItems11.Add(cPostItem1);
        }

        public enum eExpEntryType : short
        {
            EXP_REC = 1600
        }

        public enum eExpHoldFlag : byte
        {
            NO_HOLD,
            HOLD,
            NEVER_BILL
        }
    }
}