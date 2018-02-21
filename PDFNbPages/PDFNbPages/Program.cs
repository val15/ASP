using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFNbPages
{
    class Program
    {
        static void Main(string[] args)
        {
            // create PDFDocument and load from file

    PdfDocument document = new PdfDocument();


    string FileName = "unlock.pdf";


    document.LoadFromFile(FileName);




	//get page count


    int PageNumber = document.Pages.Count;

    Console.WriteLine("Page count: {0}", PageNumber);



	//remove one page of document

    document.Pages.RemoveAt(1);


	//get the number of pages

    PageNumber = document.Pages.Count;


    Console.WriteLine("Second page count:{0}", PageNumber);

    Console.ReadLine();


	//close the document

    document.Close();

            Console.ReadLine();
        }
    }
}
