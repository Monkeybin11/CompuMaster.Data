Imports NUnit.Framework

Namespace CompuMaster.Test.Data

    <TestFixture(Category:="XLS Reader")> Public Class XlsReader

#If Not CI_Build Then
        <Test()> Public Sub ReadLastCell()
            Dim TestFile As String = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\test_for_lastcell_e50aka95.xls")

            'Read and compare written test data
            '==================================

            'read the existing file, auto-detect column-types, take datatable and compare it with the written data: it should be always the same (or must be argumented and discussed with Jochen why it isn't)
            'the number of columns and rows should be always 2
            Dim ReReadData As DataTable
            ReReadData = CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "test")
            Assert.AreEqual(0, ReReadData.Rows.Count, "SaveAndReadEmptyStates #10") 'because last 4 lines only contains DBNull/nothing/empty string values
            Assert.AreEqual(1, ReReadData.Columns.Count, "SaveAndReadEmptyStates #11") 'but the column "string" has been defined by the column header
        End Sub

        <Test()> Public Sub ReadTestFileQnA()
            Dim file As String
            Dim dt As DataTable
            file = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\Q&A.xlsx")
            dt = CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(file, "Rund um das NT")
            Assert.AreEqual(35, dt.Rows.Count, "Row-Length")
            file = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\Q&A.xls")
            dt = CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(file, "Rund um das NT")
            Assert.AreEqual(35, dt.Rows.Count, "Row-Length")
        End Sub

        <Test()> Public Sub ReadFormatExcel95()
            Dim TestFile As String = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\test_for_lastcell_e50aka95.xls")
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "test")
            TestFile = AssemblyTestEnvironment.TestFileAbsolutePath("app_data\xls95.xls", True, True)
            CompuMaster.Data.DatabaseManagement.CreateMsExcelFile(TestFile, CompuMaster.Data.DatabaseManagement.MsExcelFileType.MsExcel95Xls)
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "Table1")
        End Sub

        <Test()> Public Sub ReadFormatExcel97()
            Dim TestFile As String = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\test_for_lastcell_e70aka97-2003.xls")
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "test")
            TestFile = AssemblyTestEnvironment.TestFileAbsolutePath("app_data\xls97.xls", True, True)
            CompuMaster.Data.DatabaseManagement.CreateMsExcelFile(TestFile, CompuMaster.Data.DatabaseManagement.MsExcelFileType.MsExcel97Xls)
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "Table1")
        End Sub

        <Test()> Public Sub ReadFormatExcel2007xlsx()
            Dim TestFile As String = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\test_for_lastcell_e12aka2007.xlsx")
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "test")
            TestFile = AssemblyTestEnvironment.TestFileAbsolutePath("app_data\xls207.xlsx", True, True)
            CompuMaster.Data.DatabaseManagement.CreateMsExcelFile(TestFile, CompuMaster.Data.DatabaseManagement.MsExcelFileType.MsExcel2007Xlsx)
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "Table1")
        End Sub

        <Test()> Public Sub ReadFormatExcel2007xlsb()
            Dim TestFile As String = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\test_for_lastcell_e12aka2007.xlsb")
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "test")
            TestFile = AssemblyTestEnvironment.TestFileAbsolutePath("app_data\xls207.xlsb", True, True)
            CompuMaster.Data.DatabaseManagement.CreateMsExcelFile(TestFile, CompuMaster.Data.DatabaseManagement.MsExcelFileType.MsExcel2007Xlsb)
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "Table1")
        End Sub

        <Test()> Public Sub ReadFormatExcel2007xlsm()
            Dim TestFile As String = AssemblyTestEnvironment.TestFileAbsolutePath("testfiles\test_for_lastcell_e12aka2007.xlsm")
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "test")
            TestFile = AssemblyTestEnvironment.TestFileAbsolutePath("app_data\xls207.xlsm", True, True)
            CompuMaster.Data.DatabaseManagement.CreateMsExcelFile(TestFile, CompuMaster.Data.DatabaseManagement.MsExcelFileType.MsExcel2007Xlsm)
            CompuMaster.Data.XlsReader.ReadDataTableFromXlsFile(TestFile, "Table1")
        End Sub
#End If

    End Class

End Namespace