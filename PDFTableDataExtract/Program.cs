using System;
using Aspose.Pdf;
using Aspose.Pdf.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

const string PDF_FILE_NAME = @"Table Example - Fixed.pdf";
string filePathName = System.IO.Path.Combine(@"SampleFiles", PDF_FILE_NAME);

ReadUsingAspose(filePathName);

static void ReadUsingAspose(string fileName)
{
    // Instantiate the license to avoid trial limitations while reading table data from PDF
    //License asposePdfLicense = new License();
    //asposePdfLicense.SetLicense("Aspose.pdf.lic");

    // Load source PDF document having a table in it
    Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(fileName);

    // Declare and initialize TableAbsorber class object for reading table from the PDF
    Aspose.Pdf.Text.TableAbsorber tableAbsorber = new Aspose.Pdf.Text.TableAbsorber();

    // Parse all the tables from the desired page in the PDF 
    tableAbsorber.Visit(pdfDocument.Pages[1]);

    // Get reference to the first table in the parsed collection
    AbsorbedTable absorbedTable = tableAbsorber.TableList[0];

    // Iterate through all the rows in the PDF table
    foreach (AbsorbedRow pdfTableRow in absorbedTable.RowList)
    {
        // Iterate through all the cells in the pdf table row
        foreach (AbsorbedCell pdfTableCell in pdfTableRow.CellList)
        {
            // Fetch all the text fragments in the cell
            TextFragmentCollection textFragmentCollection = pdfTableCell.TextFragments;

            // Iterate through all the text fragments
            foreach (TextFragment textFragment in textFragmentCollection)
            {
                // Display the text
                Console.WriteLine(textFragment.Text);
            }
        }
    }
    System.Console.WriteLine("Done");
}