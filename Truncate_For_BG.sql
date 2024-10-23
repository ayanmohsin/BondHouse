Delete From EX_SetupAccount where
 AccountNo not in ('011','011-1-02','011-3-04','011-4-05','012','011-1-02','011-2-03','011-3-04','43502','012-227-203','71010013','7101004','7101005','011-3-04','7101008','6101004')
 
SELECT * FRom EX_ControlAccounts;



truncate table EX_PrsTransactions;
truncate table EX_TransactionsDetail
truncate table EX_TransactionsMaster
truncate table EX_JournalVoucherDetail
truncate table EX_JournalVoucherMaster
truncate table EX_TransTT
truncate table EX_Closing

select * From EX_Login where UserId != 'Admin'