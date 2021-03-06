﻿Imports System
Imports System.Drawing
Imports DevExpress.Spreadsheet

Namespace SpreadsheetExamples

    Public NotInheritable Class WorksheetActions

        Private Sub New()
        End Sub

        #Region "Actions"
        Public Shared AssignActiveWorksheetAction As Action(Of Workbook) = AddressOf AssignActiveWorksheet
        Public Shared AddWorksheetAction As Action(Of Workbook) = AddressOf AddWorksheet
        Public Shared RemoveWorksheetAction As Action(Of Workbook) = AddressOf RemoveWorksheet
        Public Shared RenameWorksheetAction As Action(Of Workbook) = AddressOf RenameWorksheet
        Public Shared CopyWorksheetWithinWorkbookAction As Action(Of Workbook) = AddressOf CopyWorksheetWithinWorkbook
        Public Shared CopyWorksheetBetweenWorkbooksAction As Action(Of Workbook) = AddressOf CopyWorksheetBetweenWorkbooks
        Public Shared MoveWorksheetAction As Action(Of Workbook) = AddressOf MoveWorksheet
        Public Shared ShowHideWorksheetAction As Action(Of Workbook) = AddressOf ShowHideWorksheet
        Public Shared ShowHideGridlinesAction As Action(Of Workbook) = AddressOf ShowHideGridlines
        Public Shared ShowHideHeadingsAction As Action(Of Workbook) = AddressOf ShowHideHeadings
        Public Shared PageSetupAction As Action(Of Workbook) = AddressOf PageSetup
        Public Shared ZoomWorksheetAction As Action(Of Workbook) = AddressOf ZoomWorksheet

        #End Region

        Private Shared Sub AssignActiveWorksheet(ByVal workbook As Workbook)
'            #Region "#ActiveWorksheet"
            ' Set the second worksheet under the "Sheet2" name as active.
            workbook.Worksheets.ActiveWorksheet = workbook.Worksheets("Sheet2")
'            #End Region ' #ActiveWorksheet
        End Sub

        Private Shared Sub AddWorksheet(ByVal workbook As Workbook)
'            #Region "#AddWorksheet"
            ' Add a new worksheet to the workbook. The worksheet will be inserted into the end of the existing worksheet collection
            ' under the name "SheetN", where N is a number following the largest number used in worksheet names in the previously existing collection.
            workbook.Worksheets.Add()

            ' Add a new worksheet under the specified name.
            workbook.Worksheets.Add().Name = "TestSheet1"

            workbook.Worksheets.Add("TestSheet2")

            ' Add a new worksheet to the specified position in the collection of worksheets.
            workbook.Worksheets.Insert(1, "TestSheet3")

            workbook.Worksheets.Insert(3)

'            #End Region ' #AddWorksheet
        End Sub

        Private Shared Sub RemoveWorksheet(ByVal workbook As Workbook)
'            #Region "#DeleteWorksheet"
            ' Delete the "Sheet2" worksheet from the workbook.
            workbook.Worksheets.Remove(workbook.Worksheets("Sheet2"))

            ' Delete the first worksheet from the workbook.
            workbook.Worksheets.RemoveAt(0)
'            #End Region ' #DeleteWorksheet
        End Sub

        Private Shared Sub RenameWorksheet(ByVal workbook As Workbook)
'            #Region "#RenameWorksheet"
            ' Change the name of the second worksheet.
            workbook.Worksheets(1).Name = "Renamed Sheet"
'            #End Region ' #RenameWorksheet
        End Sub

        Private Shared Sub CopyWorksheetWithinWorkbook(ByVal workbook As Workbook)

            workbook.Worksheets("Sheet1").Cells.FillColor = Color.LightSteelBlue
            workbook.Worksheets("Sheet1").Cells("A1").ColumnWidthInCharacters = 50
            workbook.Worksheets("Sheet1").Cells("A1").Value = "Sheet1's Content"

'            #Region "#CopyWorksheet"
            ' Add a new worksheet to a workbook.
            workbook.Worksheets.Add("Sheet1_Copy")

            ' Copy all information (content and formatting) to the newly created worksheet 
            ' from the "Sheet1" worksheet.
            workbook.Worksheets("Sheet1_Copy").CopyFrom(workbook.Worksheets("Sheet1"))
'            #End Region ' #CopyWorksheet
        End Sub

        Private Shared Sub CopyWorksheetBetweenWorkbooks(ByVal workbook As Workbook)
'            #Region "#CopyWorksheetsBetweenWorkbooks"
            ' Create a source workbook.
            Dim sourceWorkbook As New Workbook()

            ' Add a new worksheet.
            sourceWorkbook.Worksheets.Add()

            ' Modify the second worksheet of the source workbook to be copied.
            sourceWorkbook.Worksheets(1).Cells("A1").Value = "A worksheet to be copied"
            sourceWorkbook.Worksheets(1).Cells("A1").Font.Color = Color.ForestGreen

            ' Copy the second worksheet of the source workbook into the first worksheet of another workbook.
            workbook.Worksheets(0).CopyFrom(sourceWorkbook.Worksheets(1))
'            #End Region ' #CopyWorksheetsBetweenWorkbooks
        End Sub

        Private Shared Sub MoveWorksheet(ByVal workbook As Workbook)
'            #Region "#MoveWorksheet"
            ' Move the first worksheet to the position of the last worksheet within the workbook.
            workbook.Worksheets(0).Move(workbook.Worksheets.Count - 1)
'            #End Region ' #MoveWorksheet
        End Sub

        Private Shared Sub ShowHideWorksheet(ByVal workbook As Workbook)
'            #Region "#ShowHideWorksheet"
            ' Hide the worksheet under the "Sheet2" name and prevent end-users from unhiding it via user interface.
            ' To make this worksheet visible again, use the Worksheet.Visible property.
            workbook.Worksheets("Sheet2").VisibilityType = WorksheetVisibilityType.VeryHidden

            ' Hide the "Sheet3" worksheet. 
            ' In this state a worksheet can be unhidden via user interface.
            workbook.Worksheets("Sheet3").Visible = False
'            #End Region ' #ShowHideWorksheet
        End Sub

        Private Shared Sub ShowHideGridlines(ByVal workbook As Workbook)
'            #Region "#ShowHideGridlines"
            ' Hide gridlines on the first worksheet.
            workbook.Worksheets(0).ActiveView.ShowGridlines = False
'            #End Region ' #ShowHideGridlines
        End Sub

        Private Shared Sub ShowHideHeadings(ByVal workbook As Workbook)
'            #Region "#ShowHideHeadings"
            ' Hide row and column headings in the first worksheet.
            workbook.Worksheets(0).ActiveView.ShowHeadings = False
'            #End Region ' #ShowHideHeadings
        End Sub

        Private Shared Sub PageSetup(ByVal workbook As Workbook)
'            #Region "#ViewType"
            ' Select the worksheet view type.
            workbook.Worksheets(0).ActiveView.ViewType = WorksheetViewType.PageLayout
'            #End Region ' #ViewType

'            #Region "#PageOrientation"
            ' Set the page orientation to Landscape.
            workbook.Worksheets(0).ActiveView.Orientation = PageOrientation.Landscape
'            #End Region ' #PageOrientation

'            #Region "#PageMargins"
            ' Select a unit of measure used within the workbook.
            workbook.Unit = DevExpress.Office.DocumentUnit.Inch

            ' Access page margins.
            Dim pageMargins As Margins = workbook.Worksheets(0).ActiveView.Margins

            ' Specify page margins.
            pageMargins.Left = 1
            pageMargins.Top = 1.5F
            pageMargins.Right = 1
            pageMargins.Bottom = 0.8F

            ' Specify header and footer margins.
            pageMargins.Header = 1
            pageMargins.Footer = 0.4F
'            #End Region ' #PageMargins

'            #Region "#PaperSize"
            ' Select the page's paper size.
            workbook.Worksheets(0).ActiveView.PaperKind = System.Drawing.Printing.PaperKind.A4
'            #End Region ' #PaperSize
        End Sub

        Private Shared Sub ZoomWorksheet(ByVal workbook As Workbook)
'            #Region "#WorksheetZoom"
            ' Zoom in the worksheet view. 
            workbook.Worksheets(0).ActiveView.Zoom = 150
'            #End Region ' #WorksheetZoom
        End Sub

    End Class
End Namespace
