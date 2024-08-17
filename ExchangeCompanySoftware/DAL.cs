using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace ExchangeCompanySoftware
{
    public class DAL
    {
        string gstrUserId = ConfigurationManager.AppSettings["UserId"];
        string gstrPwd = ConfigurationManager.AppSettings["Password"];

        bool _IsExecuteFromTransaction = false;
        public DAL()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        
        public bool CheckMac(string strMac)
        {
            DataTable dtb = new DataTable();
            DataSet ds = new DataSet();
            string strQuery;
            SqlConnection cn = sqlcn();
            cn.Open();
            strQuery = "Select Mac from SystemMac Where Mac = '" + strMac + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(strQuery, sqlcn());
            adpt.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            cn.Dispose();
        }

        
        public DataSet pGetDataSet(string strQry)
        {
            SqlConnection cn = sqlcn();

            DataTable dtb = new DataTable();
            DataSet ds = new DataSet();
            string strQuery;
            strQuery = strQry;
            cn.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strQuery, cn);
            adpt.Fill(ds);
            cn.Dispose();
            return ds;
        }
        
        public DataSet GetDataSet(string strQry)
        {
            //if (CheckMac(strMAC))
            //{
            //    if (gstrUserId == strUserId && gstrPwd == strPassword)
            //    {
            DataTable dtb = new DataTable();
            DataSet ds = new DataSet();
            string strQuery;
            strQuery = strQry;
            SqlConnection cn = sqlcn();
            cn.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(strQuery, cn);
            adpt.SelectCommand.CommandTimeout = 0;
            adpt.Fill(ds);
            cn.Dispose();
            return ds;
            //    }
            //    return null;
            //}
            //return null;
        }

        
        public byte[] GetCompressDataSet(string strQry)
        {
            DataTable dtb = new DataTable();
            DataSet ds = new DataSet();
            SqlConnection psqlcn = sqlcn();
            byte[] data = null;
            try
            {
                string strQuery;
                strQuery = strQry;
                //if (_req.UserId == gstrUserId && _req.Password == gstrPwd)
                //{
                psqlcn.Open();
                SqlDataAdapter adpt = new SqlDataAdapter(strQuery, psqlcn);
                adpt.SelectCommand.CommandTimeout = 0;
                adpt.Fill(ds);
                data = CompressData(ds);
                psqlcn.Close();
                psqlcn.Dispose();
                //}
            }
            catch (Exception ex)
            {
                psqlcn.Close();
                psqlcn.Dispose();

            }
            return data;
        }

        private byte[] CompressData(DataSet ds)
        {

            try
            {
                byte[] data;
                MemoryStream memStream = new MemoryStream();
                GZipStream zipStream = new GZipStream(memStream, CompressionMode.Compress);
                ds.WriteXml(zipStream, XmlWriteMode.WriteSchema);
                zipStream.Close();
                data = memStream.ToArray();
                memStream.Close();
                return data;
            }
            catch (Exception)
            {

                throw;
            }


        }


        //if (strQry.Contains("@") == true)
        //{

        //    string[] strQuery1 = strQry.Split(new char[] { '@' });
        //    for (int i = 0; i < strQuery1.Count(); i++)
        //    {
        //        SqlDataAdapter adpt = new SqlDataAdapter(strQuery1[i], sqlcn());
        //        adpt.Fill(ds);
        //    }
        //}


        //public void DmlexecuteInTransaction(string strQuery)
        //{
        //    TransactionOptions options = new TransactionOptions();
        //    options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
        //    options.Timeout = new TimeSpan(0, 2, 0);
        //    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
        //    {
        //        Dmlexecute(strQuery);
        //        scope.Complete();
        //    }

        //}
        
        public void Dmlexecute(string strQuery, string pUserID, string pPassword)
        {
            SqlCommand sqlcmd;
            SqlConnection CN = sqlcn();
            if (gstrUserId == pUserID && gstrPwd == pPassword)
            {


                if (!_IsExecuteFromTransaction)
                {
                    TransactionOptions options = new TransactionOptions();
                    options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                    options.Timeout = new TimeSpan(0, 2, 0);
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
                    {
                        sqlcmd = new SqlCommand();
                        sqlcmd.Connection = CN;
                        sqlcmd.CommandText = strQuery;
                        sqlcmd.CommandTimeout = 600;
                        sqlcmd.Connection.Open();
                        sqlcmd.ExecuteNonQuery();
                        CN.Dispose();
                        scope.Complete();

                    }
                }
                else
                {
                    sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlcn();
                    sqlcmd.CommandText = strQuery;
                    sqlcmd.CommandTimeout = 600;
                    sqlcmd.Connection.Open();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Connection.Close();
                    sqlcn().Close();
                }
            }
        }

        public string GetTransNo(string strTransType, string strBranchCode, DateTime dtSystemDate)
        {
            DataSet ds = new DataSet();
            string strQuery = "Select Transactionno = Transactionno + 1 From EX_TransNo Where TransactionType = '" + strTransType + "' and '" + dtSystemDate + "' between DateFrom and DateTo  and BRanchCode = '" + strBranchCode + "' ;Select Transactionno = Transactionno + 1,BranchCode From EX_TransNo Where TransactionType = '" + strTransType + "' and '" + dtSystemDate + "' between DateFrom and DateTo  ";
            ds = pGetDataSet(strQuery);
            string strTransNo = "N";
            if (ds.Tables[0].Rows.Count > 0)
            {
                strTransNo = ds.Tables[0].Rows[0][0].ToString();
            }
            else if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0][1].ToString() == "0")
                {
                    strTransNo = ds.Tables[1].Rows[0][0].ToString();
                }
            }

            return strTransNo;
        }
        
        public DataSet InsertMasterRecord(ref string pstrError, DataSet pDataset, string strTransType, string[] strTableName, string strCondition, string strPKColumn, string strButtonState, string strBranchCode, DateTime dtSystemDate, string strUserId, string strPassword)
        {
            DataSet ds = new DataSet();
            _IsExecuteFromTransaction = true;
            string strdsTableDetail = null;
            string strdsTableMaster = null;
            string strQueryMaster;
            string strQueryDetail;
            string strMainQueryMaster;
            string strMainQueryDetail;

            strdsTableMaster = "Master";
            strdsTableDetail = "Detail";
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            string strQuery = "";
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                try
                {
                    if (strButtonState == "ADD")
                    {

                        string strVoucherNo = GetTransNo(strTransType, strBranchCode, dtSystemDate);
                        if (strVoucherNo == "N")
                        {
                            pstrError = "Time Period of Transaction No is Expire";
                            return null;
                        }
                        for (int i = 0; i < pDataset.Tables[0].Rows.Count; i++)
                        {
                            pDataset.Tables[0].Rows[i][strPKColumn] = pDataset.Tables[0].Rows[i][strPKColumn].ToString().Replace("||", strVoucherNo);
                        }
                        if (pDataset.Tables.Count > 1)
                        {
                            for (int i = 0; i < pDataset.Tables[1].Rows.Count; i++)
                            {
                                pDataset.Tables[1].Rows[i][strPKColumn] = pDataset.Tables[1].Rows[i][strPKColumn].ToString().Replace("||", strVoucherNo);
                            }
                        }
                        strCondition = strCondition.Replace("||", strVoucherNo);
                    }
                    ds = new DataSet();
                    strMainQueryMaster = "Select * from " + strTableName[0] + " Where 1=2";
                    SqlDataAdapter sqladpt = new SqlDataAdapter(strMainQueryMaster, sqlcn());
                    sqladpt.Fill(ds);

                    strQueryMaster = "";
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName == "ServerDate")
                        {
                            pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName] = DateTime.Now;
                        }
                        if (strQueryMaster == "")
                        {
                            strQueryMaster = "Insert into " + strTableName[0] + " Select  '" + pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName].ToString() + "',";
                        }
                        else
                        {
                            string strColumn = pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName].ToString();
                            strQueryMaster = strQueryMaster + "'" + strColumn + "',";
                        }
                    }
                    strQueryMaster = strQueryMaster.ToString().Remove(strQueryMaster.ToString().Length - 1).ToString();
                    strQuery = strQueryMaster + ";";
                    //Dmlexecute(strQueryMaster);
                    strMainQueryDetail = "";
                    if (pDataset.Tables.Count > 1)
                    {
                        ds = new DataSet();
                        strMainQueryDetail = "Select * from " + strTableName[1] + " Where 1=2";
                        SqlDataAdapter sqladptDet = new SqlDataAdapter(strMainQueryDetail, sqlcn());
                        sqladptDet.Fill(ds);

                        for (int intRows = 0; intRows < pDataset.Tables[strdsTableDetail].Rows.Count; intRows++)
                        {
                            strQueryMaster = "";
                            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                            {
                                if (strQueryMaster == "")
                                {
                                    strQueryMaster = "Insert into " + strTableName[1] + " Select  '" + pDataset.Tables[strdsTableDetail].Rows[intRows][ds.Tables[0].Columns[i].ColumnName.ToString()].ToString() + "',";
                                }
                                else
                                {
                                    string strColumn = pDataset.Tables[strdsTableDetail].Rows[intRows][ds.Tables[0].Columns[i].ColumnName.ToString()].ToString();
                                    strQueryMaster = strQueryMaster + "'" + strColumn + "',";
                                }

                            }
                            strQueryMaster = strQueryMaster.ToString().Remove(strQueryMaster.ToString().Length - 1).ToString();
                            strQuery = strQuery + strQueryMaster + ";";
                            //      Dmlexecute(strQueryMaster);
                        }
                    }
                    if (strTransType != null)
                    {
                        DataSet pds = new DataSet();
                        string pstrQuery = "Select Transactionno = Transactionno + 1,BranchCode From EX_TransNo Where TransactionType = '" + strTransType + "' and '" + dtSystemDate + "' between DateFrom and DateTo  ";
                        pds = pGetDataSet(pstrQuery);
                        string strbranchCode = "0";
                        if (pds.Tables[0].Rows[0][1].ToString() != "0")
                        {
                            if (pDataset.Tables[strdsTableMaster].Columns.Contains("BranchCode"))
                            {
                                strBranchCode = pDataset.Tables[strdsTableMaster].Rows[0]["BranchCode"].ToString();
                            }
                        }
                        else
                        {
                            strBranchCode = "0";
                        }
                        strQueryMaster = "Update EX_TransNo set Transactionno = Transactionno + 1 Where TransactionType = '" + strTransType + "' and BranchCode = '" + strBranchCode + "'";
                        strQuery = strQuery + strQueryMaster + ";";
                        //Dmlexecute(strQueryMaster);
                    }
                    pstrError = MultipleDML(strQuery, strUserId, strPassword);
                    if (pstrError != "OK")
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    pstrError = ex.Message;
                    return null;
                }

                if (strMainQueryDetail != "")
                {
                    string strMasterQuery = strMainQueryMaster.Replace("Where 1=2", "") + " " + strCondition;
                    string strDetailQuery = strMainQueryDetail.Replace("Where 1=2", "") + " " + strCondition;
                    ds = pGetDataSet(strMasterQuery + ";" + strDetailQuery);
                }
                else
                {
                    string strMasterQuery = strMainQueryMaster.Replace("Where 1=2", "") + " " + strCondition;
                    ds = pGetDataSet(strMasterQuery);
                }
                scope.Complete();
                pstrError = "OK";
                return ds;
            }
        }

        
        public DataSet UpdateMasterRecord(ref string pstrError, DataSet pDataset, string[] strTableName, string strCondition, string strUserId, string strPassword)
        {
            DataSet ds = new DataSet();
            DataSet dsChek = new DataSet();
            string strdsTableDetail = null;
            string strdsTableMaster = null;
            string strQueryMaster;
            string strQueryDetail;
            string strMainQueryMaster;
            string strMainQueryDetail;
            string strQuery1 = "";
            double intMaxRecNo = 0;
            string strError = "";
            _IsExecuteFromTransaction = true;

            strdsTableMaster = "Master";
            strdsTableDetail = "Detail";
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);

            string strQuery = "Select Max(RecNo) as RecNo from " + strTableName[0] + " " + strCondition + " ";
            ds = pGetDataSet(strQuery);
            intMaxRecNo = Convert.ToDouble(ds.Tables[0].Rows[0]["RecNo"]) + 1;


            strMainQueryMaster = "Select * From " + strTableName[0] + " " + strCondition + " and RecNo = " + intMaxRecNo + " - 1  ";
            dsChek = pGetDataSet(strMainQueryMaster);

            if (dsChek.Tables[0].Rows[0]["Status"].ToString() == "U")
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
                {
                    try
                    {

                        intMaxRecNo = Convert.ToInt32(pDataset.Tables[strdsTableMaster].Rows[0]["RecNo"].ToString());

                        strQueryDetail = "Delete From " + strTableName[0] + " " + strCondition;
                        // Dmlexecute(strQueryDetail,strUserId,strPassword);
                        strQuery1 = strQueryDetail + ";";
                        if (strTableName[1] != null)
                        {
                            strQueryDetail = "Delete From " + strTableName[1] + " " + strCondition;
                            //Dmlexecute(strQueryDetail);
                            strQuery1 = strQuery1 + strQueryDetail + ";";
                        }
                        ds = new DataSet();
                        strMainQueryMaster = "Select * from " + strTableName[0] + " where 1=2";
                        SqlDataAdapter sqladpt = new SqlDataAdapter(strMainQueryMaster, sqlcn());
                        sqladpt.Fill(ds);
                        strQueryMaster = "";
                        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        {

                            if (ds.Tables[0].Columns[i].ColumnName == "ServerDate")
                            {
                                pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName] = DateTime.Now;
                            }
                            if (strQueryMaster == "")
                            {
                                strQueryMaster = "Insert into " + strTableName[0] + " Select  '" + pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName].ToString() + "',";
                            }
                            else
                            {
                                string strColumn = pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName].ToString();
                                strQueryMaster = strQueryMaster + "'" + strColumn + "',";
                            }
                        }
                        strQueryMaster = strQueryMaster.ToString().Remove(strQueryMaster.ToString().Length - 1).ToString();
                        strQuery1 = strQuery1 + strQueryMaster + ";";
                        //Dmlexecute(strQueryMaster);
                        strMainQueryDetail = "";
                        if (pDataset.Tables.Count > 1)
                        {
                            ds = new DataSet();
                            strMainQueryDetail = "Select * from " + strTableName[1] + "  where 1=2 ";
                            SqlDataAdapter sqladptDet = new SqlDataAdapter(strMainQueryDetail, sqlcn());
                            sqladptDet.Fill(ds);

                            for (int intRows = 0; intRows < pDataset.Tables[strdsTableDetail].Rows.Count; intRows++)
                            {
                                strQueryMaster = "";
                                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                                {
                                    if (strQueryMaster == "")
                                    {
                                        strQueryMaster = "Insert into " + strTableName[1] + " Select  '" + pDataset.Tables[strdsTableDetail].Rows[intRows][ds.Tables[0].Columns[i].ColumnName.ToString()].ToString() + "',";
                                    }
                                    else
                                    {
                                        string strColumn = pDataset.Tables[strdsTableDetail].Rows[intRows][ds.Tables[0].Columns[i].ColumnName.ToString()].ToString();
                                        strQueryMaster = strQueryMaster + "'" + strColumn + "',";
                                    }

                                }

                                strQueryMaster = strQueryMaster.ToString().Remove(strQueryMaster.ToString().Length - 1).ToString();
                                strQuery1 = strQuery1 + strQueryMaster + ";";

                                //Dmlexecute(strQueryMaster);
                            }
                        }
                        strError = MultipleDML(strQuery1, strUserId, strPassword);
                        pstrError = strError;
                        if (strError != "OK")
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        pstrError = ex.Message;
                        return null;
                    }
                    strMainQueryMaster = strMainQueryMaster.Replace("where 1=2", "");
                    strMainQueryDetail = strMainQueryDetail.Replace("where 1=2", "");
                    if (strMainQueryDetail != "")
                    {
                        ds = pGetDataSet("" + strMainQueryMaster + " " + strCondition + ";" + strMainQueryDetail + " " + strCondition + "");
                    }
                    else
                    {
                        ds = pGetDataSet(strMainQueryMaster + " " + strCondition);
                    }
                    scope.Complete();

                }

            }
            else if (dsChek.Tables[0].Rows[0]["Status"].ToString() == "A")
            {
                try
                {
                    string strInsert = "";
                    string strQueryInsert = "";
                    strQuery1 = "";
                    ds = null;
                    ds = pGetDataSet(strMainQueryMaster);
                    string strUpdate;
                    strUpdate = "Update " + strTableName[0] + " set Status = 'H' " + strCondition + " and RecNo = " + intMaxRecNo + " - 1  ";
                    strQuery1 = strUpdate + ";";
                    //Dmlexecute(strUpdate);
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    {
                        if (ds.Tables[0].Columns[i].ColumnName.ToString() == "RecNo")
                        {
                            pDataset.Tables[strdsTableMaster].Rows[0]["RecNo"] = intMaxRecNo;
                        }
                        if (strQueryInsert == "")
                        {
                            strQueryInsert = "Insert into " + strTableName[0] + " Select  '" + pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName].ToString() + "',";
                        }
                        else
                        {

                            string strColumn = pDataset.Tables[strdsTableMaster].Rows[0][ds.Tables[0].Columns[i].ColumnName].ToString();
                            strQueryInsert = strQueryInsert + "'" + strColumn + "',";
                        }
                    }

                    strQueryInsert = strQueryInsert.ToString().Remove(strQueryInsert.ToString().Length - 1).ToString();
                    strQuery1 = strQuery1 + strQueryInsert;

                    //Dmlexecute(strQueryInsert);
                    strMainQueryDetail = "";

                    if (pDataset.Tables.Count > 1)
                    {

                        ds = new DataSet();
                        strMainQueryDetail = "Select * from " + strTableName[1] + " where 1=2";
                        SqlDataAdapter sqladptDet = new SqlDataAdapter(strMainQueryDetail, sqlcn());
                        sqladptDet.Fill(ds);

                        for (int intRows = 0; intRows < pDataset.Tables[strdsTableDetail].Rows.Count; intRows++)
                        {
                            strQueryMaster = "";
                            if (pDataset.Tables[strdsTableDetail].Columns["RecNo"].ColumnName.ToString() == "RecNo")
                            {
                                pDataset.Tables[strdsTableDetail].Rows[intRows]["RecNo"] = intMaxRecNo;
                            }
                            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                            {
                                if (strQueryMaster == "")
                                {
                                    strQueryMaster = "Insert into " + strTableName[1] + " Select  '" + pDataset.Tables[strdsTableDetail].Rows[intRows][ds.Tables[0].Columns[i].ColumnName.ToString()].ToString() + "',";
                                }
                                else
                                {
                                    string strColumn = pDataset.Tables[strdsTableDetail].Rows[intRows][ds.Tables[0].Columns[i].ColumnName.ToString()].ToString();
                                    strQueryMaster = strQueryMaster + "'" + strColumn + "',";
                                }

                            }

                            strQueryMaster = strQueryMaster.ToString().Remove(strQueryMaster.ToString().Length - 1).ToString();

                            strQuery1 = strQuery1 + strQueryMaster + ";";
                            //Dmlexecute(strQueryMaster);
                        }
                    }
                    pstrError = MultipleDML(strQuery1, strUserId, strPassword);
                }
                catch (Exception ex)
                {
                    pstrError = ex.Message;
                    return null;
                }
            }
            if (pDataset.Tables.Count > 1)
            {
                strMainQueryMaster = "Select * from " + strTableName[0] + " " + strCondition + " and RecNo = " + intMaxRecNo + ";Select * from " + strTableName[1] + " " + strCondition + " and RecNo = " + intMaxRecNo + "";
            }
            else
            {
                strMainQueryMaster = "Select * from " + strTableName[0] + " " + strCondition + " and RecNo = " + intMaxRecNo + "";
            }

            ds = pGetDataSet(strMainQueryMaster);


            return ds;

        }


        #region New Procedure
        public class InsertParameters
        {
            public DataSet DataSetForSave { get; set; }
            public string ButtonState { get; set; }
            public string ObjectName { get; set; }
            public string OtherDML { get; set; }
            public string TransType { get; set; }

        }

        
        //public byte[] ExecuteJsonResult(string strQuery)
        //{
        //    byte[] data = null;
        //    DataSet ds = GetDataSet(strQuery);
        //    string strError = "";
        //    DataSet dsSchema = new DataSet();
        //    DataTable dtbData = new DataTable("Data");
        //    dtbData.Columns.Add("JsonData");
        //    dtbData.Rows.Add();
        //    string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
        //    dtbData.Rows[0][0] = json;
        //    dsSchema.Tables.Add(dtbData);
        //    data = CompressData(dsSchema);
        //    return data;
        //}


        
        public void InsertUpdateForm(InsertParameters isp, ref DataSet ds, ref string strError)
        {
            string lstrError = "";
            List<DMLClass> _lstDMLClass = new List<DMLClass>();
            InsertParameters _isp = isp;
            #region New SaveData()
            DataTable dtMasterInsert;
            DataSet pDataset = _isp.DataSetForSave;
            string strButtonState = _isp.ButtonState;
            string sIdentityColumn = "";
            string strOtherDML = _isp.OtherDML;
            string strTransType = _isp.TransType;

            string lstrErr = "";
            string strGetMaster = "Select * from " + pDataset.Tables[0].TableName + " Where 1=2";
            ds = GetSchema(strGetMaster, gstrUserId, gstrPwd, ref lstrErr);
            DataTable dtSchemaq = ds.Tables[0];

            if (lstrErr != "OK")
            {
                strError = lstrErr;
                return;
            }
            foreach (DataColumn dc in dtSchemaq.Columns)
            {
                if (dc.AutoIncrement)
                {
                    if (sIdentityColumn == "")
                    {
                        sIdentityColumn = "@" + dc.ColumnName;
                        break;
                    }
                }
            }
            if (sIdentityColumn == "")
            {

                strError = "Identity Column not Found";
                return;
            }
            if (strButtonState == "EDIT")
            {
                strOtherDML += " Delete From SYS_AuthStatus Where UserId = '@UserId1' and AuthLevel = @AuthLevel1 and ObjectId = '@ObjectId1' and Status = '@Status1' and RecNo =  " + sIdentityColumn;

            }
            strOtherDML += ";Insert into SYS_AuthStatus (RecNo,ObjectId,Status,AuthLevel,UserId) values (" + sIdentityColumn + ",'@ObjectId1','@Status1',@AuthLevel1,'@UserId1')";
            if (pDataset.Tables[0].Columns.Contains("AuthLevel"))
            {
                strOtherDML = strOtherDML.Replace("@AuthLevel1", pDataset.Tables[0].Rows[0]["AuthLevel"].ToString());
            }
            else
            {
                strOtherDML = strOtherDML.Replace("@AuthLevel1", "-1");
            }
            strOtherDML = strOtherDML.Replace("@Status1", pDataset.Tables[0].Rows[0]["Status"].ToString());
            strOtherDML = strOtherDML.Replace("@ObjectId1", _isp.ObjectName.ToString());
            strOtherDML = strOtherDML.Replace("@UserId1", pDataset.Tables[0].Rows[0]["UserId"].ToString());



            string iUser = "";
            bool isMaster = true;
            if (strButtonState == "ADD")
            {
                foreach (DataTable dt in pDataset.Tables)
                {
                    dtMasterInsert = dt;
                    ds = new DataSet();
                    lstrErr = "";
                    strGetMaster = "Select * from " + dt.TableName + " Where 1=2";
                    ds = GetSchema(strGetMaster, gstrUserId, gstrPwd, ref lstrErr);
                    DataTable dtSchema = ds.Tables[0];

                    if (lstrErr != "OK")
                    {
                        strError = lstrErr;
                        ds = pDataset;
                        return;
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DMLClass cls = new DMLClass();
                        SqlParameter sParam;
                        string strQ = "insert into " + dt.TableName;
                        if (strButtonState == "EDIT")
                        {
                            if (isMaster)
                            {
                                strQ = "Update " + dt.TableName + " set ";
                            }
                        }
                        string strVal = "";
                        string strColumn = "";
                        List<SqlParameter> sqlParam = new List<SqlParameter>();
                        foreach (DataColumn dtCol in dtSchema.Columns)
                        {
                            if (!dtCol.AutoIncrement)
                            {
                                if (dt.Columns.Contains(dtCol.ColumnName))
                                {
                                    if (iUser == "")
                                    {
                                        if (dt.Columns.Contains("UserId"))
                                        {
                                            iUser = Convert.ToString(dt.Rows[0]["UserId"]);
                                        }
                                    }
                                    if (dt.Columns.Contains("ServerDate"))
                                    {
                                        pDataset.Tables[0].Rows[0]["ServerDate"] = DateTime.Now;
                                    }
                                    strColumn += dtCol.ColumnName + ",";
                                    strVal += "@" + dtCol.ColumnName + ",";
                                    object value = CheckEmptyValue(dtCol, dt.Rows[i][dtCol.ColumnName]);
                                    sParam = new SqlParameter("@" + dtCol.ColumnName, SqlHelper.GetDbType(dtCol.DataType));
                                    sParam.Value = value;
                                    sqlParam.Add(sParam);
                                }
                            }
                        }

                        cls.ParameterCollection = sqlParam;
                        strColumn = strColumn.ToString().Remove(strColumn.ToString().Length - 1).ToString();
                        strVal = strVal.ToString().Remove(strVal.ToString().Length - 1).ToString();
                        strQ += "(" + strColumn + ")values" + "(" + strVal + ")";
                        cls.Query = strQ;
                        _lstDMLClass.Add(cls);
                    }
                    isMaster = false;
                }
                if (strOtherDML != null)
                {
                    DMLClass clsOtherDML = new DMLClass();
                    SqlParameter sParam2 = new SqlParameter(sIdentityColumn, 0);
                    List<SqlParameter> sqlParam2 = new List<SqlParameter>();

                    clsOtherDML.Query = strOtherDML;
                    sqlParam2.Add(sParam2);
                    clsOtherDML.ParameterCollection = sqlParam2;
                    _lstDMLClass.Add(clsOtherDML);
                }
                if (iUser == "")
                {
                    strError = "User Id not found";
                    return;
                }
                if (strTransType != null)
                {
                    string strTypeQuery = UpdateTransNO(iUser, strTransType);
                    DMLClass clsOtherDML = new DMLClass();
                    clsOtherDML.Query = strTypeQuery;
                    _lstDMLClass.Add(clsOtherDML);
                }
            }
            else
            {
                int iRecNo = 0;
                object oRecNo = pDataset.Tables[0].Rows[0][sIdentityColumn.Replace("@", "")];
                if (oRecNo != null)
                {
                    if (oRecNo.ToString() != "")
                    {
                        iRecNo = Convert.ToInt32(oRecNo);
                    }
                }
                if (iRecNo == 0)
                {
                    strError = "PK Value not found.";
                    return;
                }
                foreach (DataTable dt in pDataset.Tables)
                {
                    dtMasterInsert = dt;
                    ds = new DataSet();
                    lstrErr = "";
                    strGetMaster = "Select * from " + dt.TableName + " Where 1=2";
                    ds = GetSchema(strGetMaster, gstrUserId, gstrPwd, ref lstrErr);
                    DataTable dtSchema = ds.Tables[0];

                    if (lstrErr != "OK")
                    {

                        strError = lstrErr;
                        ds = pDataset;
                        return;
                    }
                    string strDelete = "";
                    if (!isMaster)
                    {
                        //if (dt.Rows.Count > 0)
                        //{
                        DMLClass cls = new DMLClass();
                        SqlParameter sParam;
                        List<SqlParameter> sqlParam = new List<SqlParameter>();

                        strDelete = "Delete From " + dt.TableName + " Where " + sIdentityColumn.Replace("@", "").ToString() + " = " + sIdentityColumn + ";";
                        cls.Query = strDelete;
                        sParam = new SqlParameter(sIdentityColumn, SqlHelper.GetDbType(dt.Columns[sIdentityColumn.Replace("@", "").ToString()].DataType));

                        // object value = CheckEmptyValue(dt.Columns[sIdentityColumn.Replace("@", "").ToString()], dt.Rows[0][dt.Columns[sIdentityColumn.Replace("@", "").ToString()]]);
                        sParam.Value = iRecNo;
                        sqlParam.Add(sParam);

                        cls.ParameterCollection = sqlParam;

                        _lstDMLClass.Add(cls);

                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DMLClass cls = new DMLClass();
                        SqlParameter sParam;
                        string strQ = "";

                        strQ += "insert into " + dt.TableName;
                        if (isMaster)
                        {
                            strQ = "Update " + dt.TableName + " set ";
                        }
                        string strVal = "";
                        string strColumn = "";
                        List<SqlParameter> sqlParam = new List<SqlParameter>();
                        foreach (DataColumn dtCol in dtSchema.Columns)
                        {

                            if (!dtCol.AutoIncrement)
                            {
                                if (dt.Columns.Contains(dtCol.ColumnName))
                                {
                                    if (iUser == "")
                                    {
                                        if (dt.Columns.Contains("UserId"))
                                        {
                                            iUser = Convert.ToString(dt.Rows[0]["UserId"]);
                                        }
                                    }
                                    if (isMaster)
                                    {
                                        strColumn += dtCol.ColumnName + "=" + "@" + dtCol.ColumnName + ",";
                                    }
                                    else
                                    {
                                        strColumn += dtCol.ColumnName + ",";
                                        strVal += "@" + dtCol.ColumnName + ",";
                                    }
                                    object value = CheckEmptyValue(dtCol, dt.Rows[i][dtCol.ColumnName]);
                                    sParam = new SqlParameter("@" + dtCol.ColumnName, SqlHelper.GetDbType(dtCol.DataType));
                                    sParam.Value = value;
                                    sqlParam.Add(sParam);
                                }

                            }
                            else
                            {
                                if (isMaster)
                                {
                                    object value = CheckEmptyValue(dtCol, dt.Rows[i][dtCol.ColumnName]);
                                    sParam = new SqlParameter("@" + dtCol.ColumnName, SqlHelper.GetDbType(dtCol.DataType));
                                    sParam.Value = value;
                                    sqlParam.Add(sParam);
                                }
                            }
                        }
                        cls.ParameterCollection = sqlParam;
                        strColumn = strColumn.ToString().Remove(strColumn.ToString().Length - 1).ToString();
                        if (strVal != "")
                        {
                            strVal = strVal.ToString().Remove(strVal.ToString().Length - 1).ToString();

                        }
                        if (isMaster)
                        {
                            strQ += " " + strColumn + " Where " + sIdentityColumn.Replace("@", "") + " = " + sIdentityColumn;
                        }
                        else
                        {
                            strQ += "(" + strColumn + ")values" + "(" + strVal + ")";

                        }
                        cls.Query = strQ;
                        _lstDMLClass.Add(cls);
                    }
                    isMaster = false;
                }
                if (strOtherDML != null)
                {
                    DMLClass clsOtherDML = new DMLClass();
                    SqlParameter sParam2 = new SqlParameter(sIdentityColumn, 0);
                    List<SqlParameter> sqlParam2 = new List<SqlParameter>();

                    clsOtherDML.Query = strOtherDML;
                    sqlParam2.Add(sParam2);
                    clsOtherDML.ParameterCollection = sqlParam2;
                    _lstDMLClass.Add(clsOtherDML);
                }
                DMLClass clsHistory = new DMLClass();

                int iRec = Convert.ToInt32(pDataset.Tables[0].Rows[0][sIdentityColumn.Replace("@", "")]);
                string strHistory = "";
                foreach (DataTable Dt in pDataset.Tables)
                {
                    strHistory += " Select * from " + Dt.TableName + " Where " + sIdentityColumn.Replace("@", "") + " = " + iRec.ToString() + ";";
                }
                DataSet pdsd = GetDataSet(strHistory);
                pdsd.Tables[0].Rows[0]["Status"] = "H";
                for (int i = 0; i < pDataset.Tables.Count; i++)
                {
                    pdsd.Tables[i].TableName = pDataset.Tables[i].TableName;
                }
                string strXmlSchema = pdsd.GetXmlSchema();
                string strXML = pdsd.GetXml();
                string sMUserId = iUser;
                if (pdsd.Tables[0].Columns.Contains("MUserId"))
                {
                    sMUserId = pdsd.Tables[0].Rows[0]["MUserId"].ToString();
                }

                string strQueryHistorySave = " insert into SYS_History Select '" + _isp.ObjectName + "'," + iRec + ", '" + strXML.Replace("'", "''") + "', '" + strXmlSchema.Replace("'", "''") + "','" + DateTime.Now + "','" + sMUserId + "'";


                clsHistory.Query = strQueryHistorySave;
                _lstDMLClass.Add(clsHistory);


            }




            int iRecord = 0;
            string lstrEr = ExecuteQuery(_lstDMLClass, sIdentityColumn, ref iRecord);
            if (lstrEr != "OK")
            {
                strError = lstrEr;
                ds = pDataset;
                return;
            }

            string strQuery = " Select * from " + pDataset.Tables[0].TableName + " Where " + sIdentityColumn.Replace("@", "") + " = " + iRecord + ";";
            if (pDataset.Tables.Count > 1)
            {
                for (int i = 1; i < pDataset.Tables.Count; i++)
                {

                    DataTable dtb = pDataset.Tables[i];
                    if (dtb.Columns.Contains("DataSourceQuery"))
                    {
                        strQuery += dtb.Rows[0]["DataSourceQuery"] + " Where " + sIdentityColumn.Replace("@", "") + " =" + iRecord + ";";
                    }
                    else
                    {
                        strQuery += "Select * from " + dtb.TableName + " Where " + sIdentityColumn.Replace("@", "") + " =" + iRecord + ";";
                    }
                }
            }
            DataSet dsd = GetDataSet(strQuery);
            for (int i = 0; i < dsd.Tables.Count; i++)
            {
                dsd.Tables[i].TableName = pDataset.Tables[i].TableName;
            }
            ds = dsd;
            strError = "OK";
            #endregion

        }

        
        public DataSet GetSchema(string strQry, string strUserId, string strPwd, ref string strError)
        {
            DataTable dtb = new DataTable();
            DataSet ds = new DataSet();
            SqlConnection psqlcn = sqlcn();

            try
            {

                string strQuery;
                strQuery = strQry;
                if (strUserId == gstrUserId && strPwd == gstrPwd)
                {
                    psqlcn.Open();
                    SqlDataAdapter adpt = new SqlDataAdapter(strQuery, psqlcn);
                    adpt.FillSchema(ds, SchemaType.Mapped);
                    psqlcn.Close();
                    psqlcn.Dispose();
                    strError = "OK";
                }
            }
            catch (Exception ex)
            {
                psqlcn.Close();
                strError = ex.Message.ToString();
                psqlcn.Dispose();
                ds = null;

            }
            return ds;


        }


        private class DMLClass
        {
            int _Priority;
            public int Priority
            {
                get
                {
                    return _Priority; ;
                }
                set
                {
                    _Priority = value;
                }
            }
            string _Query;

            public string Query
            {
                get
                {
                    return _Query;
                }
                set
                {
                    _Query = value;
                }
            }
            List<SqlParameter> _pCollection;
            public List<SqlParameter> ParameterCollection
            {
                get
                {
                    return _pCollection;
                }
                set
                {
                    _pCollection = value;
                }
            }
        }

        private object CheckEmptyValue(DataColumn dtColumn, object value)
        {
            if (dtColumn.DataType == typeof(byte[]))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        byte[] arr = (byte[])value;
                        value = arr;
                    }
                    else
                    {
                        value = DBNull.Value;
                    }
                }
                else
                {
                    value = DBNull.Value;
                }

            }
            if (dtColumn.DataType == typeof(int))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        int iValue = Convert.ToInt32(value);
                        value = iValue;
                    }
                    else
                    {
                        value = 0;
                    }
                }
                else
                {
                    value = 0;
                }
            }
            if (dtColumn.DataType == typeof(double))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        double iValue = Convert.ToDouble(value);
                        value = iValue;
                    }
                    else
                    {
                        value = 0;
                    }
                }
                else
                {
                    value = 0;
                }
            }
            if (dtColumn.DataType == typeof(decimal))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        decimal iValue = Convert.ToDecimal(value);
                        value = iValue;
                    }
                    else
                    {
                        value = 0;
                    }
                }
                else
                {
                    value = 0;
                }
            }
            if (dtColumn.DataType == typeof(string))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        string strValue = (string)value;
                        value = strValue;
                    }
                    else
                    {
                        value = DBNull.Value;
                    }
                }
                else
                {
                    value = DBNull.Value;
                }
            }
            if (dtColumn.DataType == typeof(DateTime))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        DateTime dtValue = Convert.ToDateTime(value);
                        value = dtValue;
                    }
                    else
                    {
                        value = DBNull.Value;
                    }
                }
                else
                {
                    value = DBNull.Value;
                }
            }
            if (dtColumn.DataType == typeof(Boolean))
            {
                if (value != null)
                {
                    if (value.ToString() != "")
                    {
                        Boolean bValue = Convert.ToBoolean(value);
                        value = bValue;
                    }
                    else
                    {
                        value = false;
                    }
                }
                else
                {
                    value = false;
                }
            }


            return value;
        }

        public static class SqlHelper
        {
            private static Dictionary<Type, SqlDbType> typeMap;

            // Create and populate the dictionary in the static constructor
            static SqlHelper()
            {
                typeMap = new Dictionary<Type, SqlDbType>();

                typeMap[typeof(string)] = SqlDbType.NVarChar;
                typeMap[typeof(char[])] = SqlDbType.NVarChar;
                typeMap[typeof(byte)] = SqlDbType.TinyInt;
                typeMap[typeof(short)] = SqlDbType.SmallInt;
                typeMap[typeof(int)] = SqlDbType.Int;
                typeMap[typeof(long)] = SqlDbType.BigInt;
                typeMap[typeof(byte[])] = SqlDbType.Image;
                typeMap[typeof(bool)] = SqlDbType.Bit;
                typeMap[typeof(DateTime)] = SqlDbType.DateTime2;
                typeMap[typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset;
                typeMap[typeof(decimal)] = SqlDbType.Money;
                typeMap[typeof(float)] = SqlDbType.Real;
                typeMap[typeof(double)] = SqlDbType.Float;
                typeMap[typeof(TimeSpan)] = SqlDbType.Time;
                /* ... and so on ... */
            }

            // Non-generic argument-based method
            public static SqlDbType GetDbType(Type giveType)
            {
                // Allow nullable types to be handled
                giveType = Nullable.GetUnderlyingType(giveType) ?? giveType;

                if (typeMap.ContainsKey(giveType))
                {
                    return typeMap[giveType];
                }

                throw new ArgumentException("{giveType.FullName} is not a supported .NET class");
            }

            // Generic version
            public static SqlDbType GetDbType<T>()
            {
                return GetDbType(typeof(T));
            }
        }

        private string UpdateTransNO(string iUser, string strType)
        {
            #region Update Transaction No
            string strError = "";
            string strUpdateTransNo = "";
            if (strType != null)
            {
                if (strType != "")
                {
                    string strQuery = "Select BranchCode From SYS_TransNo Where TransactionType = '" + strType + "';Select * from SM_User Where RecNo = '" + iUser + "' ";
                    DataSet dsd = GetDataSet(strQuery);
                    if (dsd.Tables[0].Rows.Count > 0)
                    {
                        string strBranchCode = dsd.Tables[1].Rows[0]["BranchCode"].ToString();
                        string strBranchwise = dsd.Tables[0].Rows[0]["BranchCode"].ToString();
                        if (strBranchwise == "0")
                        {
                            strUpdateTransNo = "Update SYS_TransNo set Transactionno = Transactionno + 1 Where TransactionType = '" + strType + "' and BranchCode = 0";
                        }
                        else
                        {
                            strUpdateTransNo = "Update SYS_TransNo set Transactionno = Transactionno + 1 Where TransactionType = '" + strType + "' and BranchCode = '" + strBranchCode + "'";
                        }
                    }


                }
                return strUpdateTransNo;
            }
            #endregion
            return null;
        }

        private string ExecuteQuery(List<DMLClass> lst, string sIdentityColumn, ref int iRecNo)
        {
            SqlConnection db = sqlcn();
            SqlTransaction transaction = null;
            try
            {
                db.Open();
                transaction = db.BeginTransaction();
                int newID = 0;
                var para = lst[0].ParameterCollection.Find(x => x.ParameterName == sIdentityColumn);
                if (para != null)
                {
                    if (para.Value.ToString() != "")
                    {
                        newID = Convert.ToInt32(para.Value);

                    }
                }



                foreach (DMLClass _lst in lst)
                {
                    if (_lst.Query != null)
                    {
                        if (_lst.Query == "")
                        {
                            continue;

                        }
                    }
                    else
                    {
                        continue;
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = db;
                    if (newID == 0)
                    {
                        cmd.CommandText = _lst.Query + ";SELECT CAST(scope_identity() AS int)";
                    }
                    else
                    {
                        cmd.CommandText = _lst.Query;
                    }
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 0;
                    if (_lst.ParameterCollection != null)
                    {
                        foreach (SqlParameter sqlPm in _lst.ParameterCollection)
                        {
                            if (sqlPm != null)
                            {
                                if (sqlPm.ParameterName == sIdentityColumn)
                                {
                                    sqlPm.Value = newID;
                                }
                                cmd.Parameters.Add(sqlPm);

                            }
                        }
                    }

                    if (newID == 0)
                    {
                        newID = Convert.ToInt32(cmd.ExecuteScalar());
                        iRecNo = newID;
                    }
                    else
                    {
                        int iRead = cmd.ExecuteNonQuery();
                        iRecNo = newID;
                    }
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
                transaction.Commit();
                db.Close();
                db.Dispose();
                return "OK";
            }
            catch (SqlException sqlError)
            {
                transaction.Rollback();
                db.Close();
                db.Dispose();
                iRecNo = 0;
                return sqlError.Message;
            }
        }
        #endregion


        
        public DataSet DeleteRecord(string[] strTableName, string strCondition, string strUserId, string strPassword)
        {
            DataSet ds = new DataSet();
            DataSet dsChek = new DataSet();
            string strdsTableDetail = null;
            string strdsTableMaster = null;
            string strQueryMaster;
            string strQueryDetail;
            string strMainQueryMaster;
            string strMainQueryDetail = "";
            double intMaxRecNo;
            strdsTableMaster = "Master";
            strdsTableDetail = "Detail";
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = new TimeSpan(0, 2, 0);
            _IsExecuteFromTransaction = true;

            string strQuery = "Select Max(RecNo) as RecNo from " + strTableName[0] + " " + strCondition + " ";
            ds = pGetDataSet(strQuery);
            intMaxRecNo = Convert.ToDouble(ds.Tables[0].Rows[0]["RecNo"]);


            strMainQueryMaster = "Select * From " + strTableName[0] + " " + strCondition + " and RecNo = " + intMaxRecNo + " ";
            dsChek = pGetDataSet(strMainQueryMaster);
            if (dsChek.Tables[0].Rows[0]["Status"].ToString() == "U" && Convert.ToInt16(dsChek.Tables[0].Rows[0]["RecNo"].ToString()) == 1)
            {
                strMainQueryMaster = "Select * From " + strTableName[0] + " " + strCondition;
                strQueryDetail = "Delete From " + strTableName[0] + " " + strCondition + " and RecNo = " + intMaxRecNo + "";
                Dmlexecute(strQueryDetail, strUserId, strPassword);
                strMainQueryDetail = "";
                if (strTableName[1] != null)
                {
                    strMainQueryDetail = "Select * From " + strTableName[1] + " " + strCondition;
                    strQueryDetail = "Delete From " + strTableName[1] + " " + strCondition + " and RecNo = " + intMaxRecNo + "";
                    Dmlexecute(strQueryDetail, strUserId, strPassword);
                }
            }
            else if (dsChek.Tables[0].Rows[0]["Status"].ToString() == "U" && Convert.ToInt16(dsChek.Tables[0].Rows[0]["RecNo"].ToString()) > 1)
            {
                strQueryDetail = "Update " + strTableName[0] + " set Status = 'X' " + strCondition + " and RecNo = " + intMaxRecNo + "";
                Dmlexecute(strQueryDetail, strUserId, strPassword);
            }
            else if (dsChek.Tables[0].Rows[0]["Status"].ToString() == "A")
            {
                strQueryDetail = "Update " + strTableName[0] + " set Status = 'X' " + strCondition + " and RecNo = " + intMaxRecNo + "";
                Dmlexecute(strQueryDetail, strUserId, strPassword);
            }
            if (strMainQueryDetail != "")
            {
                ds = pGetDataSet("" + strMainQueryMaster + ";" + strMainQueryDetail + "");
            }
            else
            {
                ds = pGetDataSet(strMainQueryMaster);
            }
            return ds;
        }

        private SqlConnection sqlcn()
        {
            SqlConnection cn = new SqlConnection();
            string sConnString = General.gendPoint;
            cn.ConnectionString = sConnString;


            return cn;
        }
        
        public DateTime[] GETEXETIME(string strServerLocalPath)
        {
            DateTime[] dt = new DateTime[3];
            FileInfo fi1 = new FileInfo(strServerLocalPath);
            dt[0] = Convert.ToDateTime(File.GetCreationTime(strServerLocalPath).ToString("dd/MMM/yyyy"));
            dt[1] = File.GetLastWriteTime(strServerLocalPath);
            dt[2] = File.GetLastAccessTime(strServerLocalPath);
            return dt;
        }
        
        public string MultipleDML(string strQuery, string strUserId, string strPwd)
        { 
            SqlConnection db = sqlcn();
            SqlTransaction transaction;
            if (gstrUserId == strUserId && gstrPwd == strPwd)
            {
                db.Open();
                transaction = db.BeginTransaction();
                try
                {
                    string[] strQry = strQuery.Split(';');
                    for (int i = 0; i < strQry.Count(); i++)
                    {
                        if (strQry[i] != "")
                        {
                            new SqlCommand(strQry[i], db, transaction).ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    db.Dispose();
                    return "OK";
                }
                catch (SqlException sqlError)
                {
                    transaction.Rollback();
                    db.Dispose();
                    return sqlError.Message.ToString();
                }

            }
            else
            {
                return "incorrect UserId /Password";
            }
        }

    }
}
