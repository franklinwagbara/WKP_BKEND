using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Backend_UMR_Work_Program
{
    public class ReturnData
    {
        private string _table;
        private string _role;
        private string _requestId;
        private int _draw;
        private int _recordsTotal;
        private int _recordsFiltered;
        private string _data;
        private int _PreviousPage;
        private bool _HasPreviousPage;
        private int _NextPage;
        private bool _HasNextPage;
        private double _totalPages;
        private string _SN;

        #region " ... Properties ... "
        public string SN
        {
            get { return _SN; }
            set { _SN = value; }
        }
        public string role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string table
        {
            get { return _table; }
            set { _table = value; }
        }
        public string requestId
        {
            get { return _requestId; }
            set { _requestId = value; }
        }
        public int draw
        {
            get { return _draw; }
            set { _draw = value; }
        }
        public int recordsTotal
        {
            get { return _recordsTotal; }
            set { _recordsTotal = value; }
        }
        public int recordsFiltered
        {
            get { return _recordsFiltered; }
            set { _recordsFiltered = value; }
        }
        public string data
        {
            get { return _data; }
            set { _data = value; }
        }
        public int PreviousPage
        {
            get { return _PreviousPage; }
            set { _PreviousPage = value; }
        }
        public bool HasPreviousPage
        {
            get { return _HasPreviousPage; }
            set { _HasPreviousPage = value; }
        }
        public int NextPage
        {
            get { return _NextPage; }
            set { _NextPage = value; }
        }
        public bool HasNextPage
        {
            get { return _HasNextPage; }
            set { _HasNextPage = value; }
        }
        public double totalPages
        {
            get { return _totalPages; }
            set { _totalPages = value; }
        }
        #endregion

        //public string parseJSONData(String rt = "22")
        //{
        //    StringBuilder sb = new StringBuilder();

        //    string sData2 = "{ \"data\": " + rt + " }";

        //    return sData2;
        //}

        public string parseJSONDataOnly(ReturnData rt)
        {
            StringBuilder sb = new StringBuilder();

            string sData2 = "{ \"data\": " + rt.data + " }";

            return sData2;
        }

        //public string parseJSONData(ReturnData rt)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    //foreach (string s in _data)
        //    //    sb.Append(s + ",");

        //    //string sData = sb.ToString();
        //    //sData = sData.Remove(sData.Count() - 1, 1);       //remove last comma

        //    string sData2 = "{ \"draw\": " + rt.draw.ToString() + ", " +
        //                      "\"recordsTotal\": " + rt.recordsTotal.ToString() + ", " +
        //                      "\"recordsFiltered\": " + rt.recordsFiltered.ToString() + ", " +
        //                      "\"table\": \"" + rt.table + "\", " +
        //                      "\"totalPages\": \"" + rt.totalPages + "\", " +
        //                      "\"role\": \"" + rt.role + "\", " +
        //                      "\"PreviousPage\": " + rt.PreviousPage + ", " +
        //                      "\"HasPreviousPage\": \"" + rt.HasPreviousPage + "\", " +
        //                      "\"NextPage\": " + rt.NextPage + ", " +
        //                      "\"HasNextPage\": \"" + rt.HasNextPage + "\", " +
        //                      "\"data\": " + rt.data +
        //                      " }";

        //    // testing purposes...
        //    //File.WriteAllText("c:\\temp\\SampleText.txt", sData2);

        //    return sData2;
        //}

        //public string parseJSONData(nes_project_classes rt)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    //foreach (string s in _data)
        //    //    sb.Append(s + ",");

        //    //string sData = sb.ToString();
        //    //sData = sData.Remove(sData.Count() - 1, 1);       //remove last comma

        //    string sData2 = "{ 'd': " + rt.SN.ToString() + "}";

        //    // testing purposes...
        //    //File.WriteAllText("c:\\temp\\SampleText.txt", sData2);

        //    return sData2;
        //}
    }
}